using Amazon.Lambda.Core;
using AutoMapper;
using CurrencyPriceProvider.Abstractions;
using CurrencyPriceProvider.Configuration;
using CurrencyPriceProvider.Implementations;
using CurrencyPriceProvider.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using CurrencyPriceProvider.Data;
using Microsoft.Extensions.Configuration;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CurrencyPriceProvider
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
            _serviceCollection.AddTransient<IPrice<ForeignCurrencyPrice>,PriceFromPgp<ForeignCurrencyPrice>>();
            _serviceCollection.AddAutoMapper(mce =>
            {
                mce.AddProfile<DtoToDomainMapperProfile>();
            }, typeof(Function).GetTypeInfo().Assembly);
            _serviceCollection.AddTransient<App>();
            _serviceCollection.AddDefaultAWSOptions(configuration.GetAWSOptions());
            _serviceCollection.AddSingleton<IConfiguration>(configuration);
            _serviceCollection.AddAWSService<IAmazonDynamoDB>();
            _serviceCollection.AddTransient<IDynamoDBContext, DynamoDBContext>();
            _serviceCollection.AddTransient<IRepository, Repository>();
        }

        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            using ServiceProvider serviceProvider = _serviceCollection.BuildServiceProvider();
            return serviceProvider.GetService<App>().Run();
        }
    }
    public class App
    {
        private readonly IPrice<ForeignCurrencyPrice> _pgpPriceProvider;
        private readonly IRepository _repository;
        public App(IPrice<ForeignCurrencyPrice> priceProvider, IRepository repository)
        {
            _pgpPriceProvider = priceProvider;
            _repository = repository;
        }

        public string Run()
        {
            try
            {
                LambdaLogger.Log("Getting prices from provider...");
                var currentPrice = _pgpPriceProvider.GetCurrentPrice("USD").Result;
                LambdaLogger.Log(currentPrice.ToString() + " CurrentPrice Is : " + currentPrice.ClosingPrice);
                _repository.Put(currentPrice);
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
