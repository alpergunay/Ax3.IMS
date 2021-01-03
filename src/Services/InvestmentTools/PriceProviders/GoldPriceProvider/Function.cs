using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;
using Autofac;
using AutoMapper;
using Ax3.IMS.Infrastructure.Configuration.Settings;
using Ax3.IMS.Infrastructure.EventBus;
using Ax3.IMS.Infrastructure.EventBus.Abstractions;
using Ax3.IMS.Infrastructure.EventBus.EFEventStore.Services;
using Ax3.IMS.Infrastructure.EventBus.RabbitMQ;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PriceProviders.Shared.Abstractions;
using PriceProviders.Shared.Data;
using PriceProviders.Shared.Models;
using RabbitMQ.Client;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace GoldPriceProvider
{
    public class Function
    {
        private ServiceCollection _serviceCollection;

        public Function()
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddCustomConfiguration(configuration);
            _serviceCollection.AddCustomIntegrations();
            _serviceCollection.AddEventBus();
            _serviceCollection.AddTransient<IPrice<ForeignCurrencyPrice>, PriceFromPgp<ForeignCurrencyPrice>>();
            _serviceCollection.AddAutoMapper(mce => { mce.AddProfile<DtoToDomainMapperProfile>(); },
                typeof(Function).GetTypeInfo().Assembly);
            _serviceCollection.AddTransient<App>();
            _serviceCollection.AddDefaultAWSOptions(configuration.GetAWSOptions());
            _serviceCollection.AddSingleton<IConfiguration>(configuration);
            _serviceCollection.AddAWSService<IAmazonDynamoDB>();
            _serviceCollection.AddTransient<IDynamoDBContext, DynamoDBContext>();
            _serviceCollection.AddTransient<IRepository<ForeignCurrencyPrice>, Repository<ForeignCurrencyPrice>>();
        }

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<string> FunctionHandler(string input, ILambdaContext context)
        {
            await using var serviceProvider = _serviceCollection.BuildServiceProvider();
            return await serviceProvider.GetService<App>().Run();
        }

        public class App
        {
            private readonly IPrice<ForeignCurrencyPrice> _pgpPriceProvider;
            private readonly IRepository<ForeignCurrencyPrice> _repository;

            public App(IPrice<ForeignCurrencyPrice> priceProvider, IRepository<ForeignCurrencyPrice> repository)
            {
                _pgpPriceProvider = priceProvider;
                _repository = repository;
            }

            public async Task<string> Run()
            {
                try
                {
                    var currencies = JsonSerializer.Deserialize<List<InvestmentTool>>(
                        Environment.GetEnvironmentVariable("currencies"), new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                        });
                    var url = Environment.GetEnvironmentVariable("url");

                    if (currencies == null || currencies.Count <= 0 || string.IsNullOrEmpty(url)) return "OK";
                    foreach (var currency in currencies)
                    {
                        LambdaLogger.Log($"Getting prices from provider for {currency.Code}...");
                        var currentPrice = await _pgpPriceProvider.GetCurrentPrice(currency.Code, url);
                        currentPrice.InvestmentTool = currency;
                        LambdaLogger.Log(currentPrice.ToString() + " CurrentPrice Is : " + currentPrice.BuyingPrice);
                        await _repository.SavePriceAsync(currentPrice);
                    }

                    return "OK";
                }
                catch (Exception e)
                {
                    LambdaLogger.Log("Unexpected exception." + e.Message);
                    throw;
                }

            }
        }
    }

    internal static class CustomExtensionsMethods
    {
        private static ApplicationSettings _settings;
        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            _settings = new ApplicationSettings();
            configuration.GetSection(typeof(ApplicationSettings).Name).Bind(_settings);
            return services;
        }
        public static IServiceCollection AddEventBus(this IServiceCollection services)
        {
            var subscriptionClientName = _settings.SubscriptionClientName;
            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMqPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var logger = sp.GetRequiredService<ILogger<EventBusRabbitMQ>>();
                var eventBusSubscriptionManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(_settings.ServiceBus.RetryCount))
                {
                    retryCount = int.Parse(_settings.ServiceBus.RetryCount);
                }

                return new EventBusRabbitMQ(rabbitMqPersistentConnection, logger, iLifetimeScope, eventBusSubscriptionManager, subscriptionClientName, retryCount);
            });
            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            return services;
        }
        public static IServiceCollection AddCustomIntegrations(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
                sp => (DbConnection c) => new IntegrationEventLogService(c));

            //services.AddTransient<IImsIntegrationEventService, ImsIntegrationEventService>();

            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var uriBuilder = new UriBuilder(_settings.ServiceBus.RabbitMQUrl)
                {
                    Scheme = _settings.ServiceBus.Scheme,
                    Port = int.Parse(_settings.ServiceBus.Port) // default port for scheme
                };
                var factory = new ConnectionFactory()
                {
                    DispatchConsumersAsync = true,
                    Uri = uriBuilder.Uri
                };
                if (!string.IsNullOrEmpty(_settings.ServiceBus.RabbitUsername))
                {
                    factory.UserName = _settings.ServiceBus.RabbitUsername;
                }

                if (!string.IsNullOrEmpty(_settings.ServiceBus.RabbitPassword))
                {
                    factory.Password = _settings.ServiceBus.RabbitPassword;
                }

                var retryCount = 5;
                if (!string.IsNullOrEmpty(_settings.ServiceBus.RetryCount))
                {
                    retryCount = int.Parse(_settings.ServiceBus.RetryCount);
                }
                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });

            return services;
        }
    }
}
