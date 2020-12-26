using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ax3.IMS.Infrastructure.Configuration.Settings;
using Identity.Api.Certificates;
using Identity.Api.Data;
using Identity.Api.Devspaces;
using Identity.Api.Models;
using Identity.Api.Services;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using System;
using System.Data.Common;
using System.Reflection;
using System.Security.Cryptography;
using Ax3.IMS.Infrastructure.EventBus;
using Ax3.IMS.Infrastructure.EventBus.Abstractions;
using Ax3.IMS.Infrastructure.EventBus.EFEventStore.Services;
using Ax3.IMS.Infrastructure.EventBus.RabbitMQ;
using HealthChecks.UI.Client;
using Identity.Api.Configuration;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace Identity.Api
{
    public class Startup
    {
        private ApplicationSettings _settings;
        public IConfiguration AppConfiguration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            AppConfiguration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            IdentityModelEventSource.ShowPII = true;

            _settings = new ApplicationSettings();
            AppConfiguration.GetSection(nameof(ApplicationSettings)).Bind(_settings);

            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(_settings.Persistence.ConnectionString,
                    npgsqlOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                        //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorCodesToAdd: null);
                    }).UseSnakeCaseNamingConvention());

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            var connectionString = _settings.Persistence.ConnectionString;
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddIdentityServer(x =>
                {
                    x.IssuerUri = "null";
                    x.Authentication.CookieLifetime = TimeSpan.FromDays(365);
                })
                .AddDevspacesIfNeeded(AppConfiguration.GetValue("EnableDevspaces", false))
                .AddSigningCredential(Certificate.Get())
                .AddAspNetIdentity<ApplicationUser>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseNpgsql(connectionString,
                        npgsqlOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(migrationsAssembly);
                            //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorCodesToAdd: null);
                        }).UseSnakeCaseNamingConvention();
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = builder => builder.UseNpgsql(connectionString,
                        npgsqlOptionsAction: sqlOptions =>
                        {
                            sqlOptions.MigrationsAssembly(migrationsAssembly);
                            //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency
                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30),
                                errorCodesToAdd: null);
                        }).UseSnakeCaseNamingConvention();
                })
                .AddInMemoryIdentityResources(Config.GetResources())
                .AddInMemoryApiScopes(Config.GetApiScopes())
                .AddInMemoryClients(Config.GetClients(Config.GetApiClients(AppConfiguration)))
                .AddInMemoryApiResources(Config.GetApiResources())
                .Services.AddTransient<IProfileService, ProfileService>();

            services.AddCustomConfiguration(AppConfiguration)
                .AddIntegrationServices()
                .AddEventBus();


            services.AddHealthChecks()
                .AddCheck("self", () => HealthCheckResult.Healthy())
                .AddNpgSql(AppConfiguration["ConnectionString"],
                    name: "IdentityDB-check",
                    tags: new string[] { "IdentityDB" });

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 0;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();

            //added for CSP problem in inline css and js attributes
            app.Use((context, next) =>
            {
                var rng = new RNGCryptoServiceProvider();
                var nonceBytes = new byte[32];
                rng.GetBytes(nonceBytes);
                var nonce = Convert.ToBase64String(nonceBytes);
                context.Items.Add("ScriptNonce", nonce);
                context.Response.Headers.Add("Content-Security-Policy",
                    new[] { string.Format("script-src-attr 'self' 'nonce-{0}'", nonce) });
                return next();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                await next().ConfigureAwait(false);
            });

            app.UseForwardedHeaders();
            app.UseIdentityServer();
            app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });
            app.UseRouting();

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
        }
    }

    internal static class CustomExtensionsMethods
    {
        private static ApplicationSettings _settings;
        public static IServiceCollection AddIntegrationServices(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
                sp => (DbConnection c) => new IntegrationEventLogService(c));
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
    }
}