using Autofac;
using Ax3.IMS.Infrastructure.Configuration.Settings;
using Ax3.IMS.Infrastructure.Core.Http.Filters;
using Ax3.IMS.Infrastructure.EventBus;
using Ax3.IMS.Infrastructure.EventBus.Abstractions;
using Ax3.IMS.Infrastructure.EventBus.EFEventStore;
using Ax3.IMS.Infrastructure.EventBus.EFEventStore.Services;
using Ax3.IMS.Infrastructure.EventBus.RabbitMQ;
using CacheManager.Core;
using EFCoreSecondLevelCacheInterceptor;
using FluentValidation.AspNetCore;
using Ims.Api.Application.Modules.Infrastructure.IntegrationEvents;
using Ims.Api.Controllers;
using Ims.Api.Services;
using Ims.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using AutoMapper;
using HealthChecks.UI.Client;
using Ims.Api.Application.Modules.Infrastructure.Mapper;
using Ims.Api.Infrastructure.AutofacModules;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Ims.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityModelEventSource.ShowPII = true;
            services
                //.UseSerilogSinkConfiguration(CustomColoredConsole.SinkConfiguration)
                .AddCustomMvc()
                .AddCustomConfiguration(Configuration)
                .AddCustomHealthChecks()
                .AddCustomSwagger(Configuration)
                .Add2NdLevelCache()
                .AddCustomDbContext()
                .AddCustomIntegrations()
                .AddEventBus()
                .AddCustomAuthentication(Configuration)
                .AddAutoMapper();
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new ApplicationModule(Configuration["ApplicationSettings:Persistence:ConnectionString"]));
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ApiCallMiddleware>();
            var pathBase = Configuration["PATH_BASE"];
            app.UseCors("CorsPolicy");

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"{ (!string.IsNullOrEmpty(pathBase) ? pathBase : string.Empty) }/swagger/v1/swagger.json", "Ims.Api V1");
                    c.OAuthClientId("imsapiswaggerui");
                    c.OAuthAppName("API Swagger UI");
                });

            app.UseRouting();
            ConfigureAuth(app);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
                endpoints.MapHealthChecks("/liveness", new HealthCheckOptions
                {
                    Predicate = r => r.Name.Contains("self")
                });
            });
            ConfigureEventBus(app);
        }
        private static void ConfigureEventBus(IApplicationBuilder app)
        {
            app.ApplicationServices.GetRequiredService<IEventBus>();

            //eventBus.Subscribe<VehicleModelCreatedIntegrationEvent, IIntegrationEventHandler<VehicleModelCreatedIntegrationEvent>>();
            //Other integration events....
        }
        protected virtual void ConfigureAuth(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }

    internal static class CustomExtensionsMethods
    {
        private static ApplicationSettings _settings;

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            // Add framework services.
            services.AddControllers(options => options.Filters.Add(typeof(ExceptionHandlingFilter)))
                .AddApplicationPart(typeof(StoreTypeController).Assembly)
                .AddNewtonsoftJson(x =>
                    x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation(fv => fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .SetIsOriginAllowed((host) => true)
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddHttpContextAccessor();
            return services;
        }
        public static IServiceCollection AddCustomConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            _settings = new ApplicationSettings();
            configuration.GetSection(typeof(ApplicationSettings).Name).Bind(_settings);
            services.Configure<ApplicationSettings>(configuration);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Instance = context.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "Please refer to the errors property for additional details."
                    };

                    return new BadRequestObjectResult(problemDetails)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });

            return services;
        }
        public static IServiceCollection AddCustomHealthChecks(this IServiceCollection services)
        {
            var hcBuilder = services.AddHealthChecks();

            hcBuilder.AddCheck("self", () => HealthCheckResult.Healthy());

            hcBuilder
                .AddNpgSql(
                    _settings.Persistence.ConnectionString,
                    name: "DB-check",
                    tags: new string[] { "db" });

            hcBuilder
                .AddRabbitMQ(
                    $"amqp://{_settings.ServiceBus.RabbitMQUrl}",
                    name: "rabbitmqbus-check",
                    tags: new string[] { "mqbus" });

            return services;
        }
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "IMS - Investment Management System Service HTTP API",
                    Version = "v1",
                    Description = "Service HTTP API"
                });
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            AuthorizationUrl = new Uri($"{configuration.GetValue<string>("IdentityUrl")}/connect/authorize"),
                            TokenUrl = new Uri($"{configuration.GetValue<string>("IdentityUrl")}/connect/token"),
                            Scopes = new Dictionary<string, string>()
                            {
                                { "imsapi", "Swagger UI" }
                            }
                        }
                    }
                });

                options.OperationFilter<AuthorizeCheckOperationFilter>();
            });

            return services;
        }
        public static IServiceCollection Add2NdLevelCache(this IServiceCollection services)
        {
            var jss = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto
            };

            const string redisConfigurationKey = "ims";
            services.AddSingleton(typeof(ICacheManagerConfiguration),
                new CacheManager.Core.ConfigurationBuilder()
                    .WithJsonSerializer(serializationSettings: jss, deserializationSettings: jss)
                    .WithUpdateMode(CacheUpdateMode.Up)
                    .WithRedisConfiguration(redisConfigurationKey, config =>
                    {
                        config.WithAllowAdmin()
                            .WithDatabase(_settings.Cache.Database ?? 1)
                            .WithEndpoint(_settings.Cache.ServerAddress, _settings.Cache.PortNumber)
                            .WithPassword(_settings.Cache.Password)
                            // Enables keyspace notifications to react on eviction/expiration of items.
                            // Make sure that all servers are configured correctly and 'notify-keyspace-events' is at least set to 'Exe', otherwise CacheManager will not retrieve any events.
                            // You can try 'Egx' or 'eA' value for the `notify-keyspace-events` too.
                            // See https://redis.io/topics/notifications#configuration for configuration details.
                            .EnableKeyspaceEvents();
                    })
                    .WithMaxRetries(100)
                    .WithRetryTimeout(50)
                    .WithRedisCacheHandle(redisConfigurationKey)
                    .Build());
            services.AddSingleton(typeof(ICacheManager<>), typeof(BaseCacheManager<>));

            services.AddEFSecondLevelCache(options =>
                options.UseCacheManagerCoreProvider().DisableLogging(true));
            return services;
        }
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ImsContext>((serviceProvider, options) =>
                options.UseNpgsql(_settings.Persistence.ConnectionString,
                        npgsqlOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                        }).UseSnakeCaseNamingConvention()
                    .AddInterceptors(serviceProvider.GetRequiredService<SecondLevelCacheInterceptor>()));

            services.AddDbContext<IntegrationEventLogContext>(options =>
                options.UseNpgsql(_settings.Persistence.ConnectionString,
                    npgsqlOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorCodesToAdd: null);
                    })
                    .UseSnakeCaseNamingConvention());
            return services;
        }
        public static IServiceCollection AddCustomIntegrations(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
                sp => (DbConnection c) => new IntegrationEventLogService(c));

            services.AddTransient<IImsIntegrationEventService, ImsIntegrationEventService>();

            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
                var factory = new ConnectionFactory()
                {
                    HostName = _settings.ServiceBus.RabbitMQUrl,
                    DispatchConsumersAsync = true
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
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // prevent from mapping "sub" claim to nameidentifier.
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            var identityUrl = configuration.GetValue<string>("IdentityUrl");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;
                options.Audience = "imsapi";
            });

            return services;
        }
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new RequestModelMapperConfiguration());
                cfg.AddProfile(new ResponseModelMapperConfiguration());
            });
            mapperConfig.AssertConfigurationIsValid();
            services.AddSingleton(provider => mapperConfig.CreateMapper());
            return services;
        }
    }
}
