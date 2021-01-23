using System;
using System.Net.WebSockets;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PriceProviders.Shared.Abstractions;
using PriceProviders.Shared.Data;
using PriceProviders.Shared.Models;
using Pricing.BackgroundServices.Extensions;
using Pricing.BackgroundServices.Services;

namespace Pricing.BackgroundServices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services
                .AddCustomConfiguration(Configuration)
                .AddDefaultAWSOptions(Configuration.GetAWSOptions())
                .AddCustomHealthCheck(this.Configuration)
                .AddOptions()
                .AddHostedService<PriceFeederService>()
                .AddCustomIntegrations()
                .AddRedisCache()
                .AddEventBus();

            services.AddAWSService<IAmazonDynamoDB>();
            services.AddTransient<IDynamoDBContext, DynamoDBContext>();
            services.AddTransient<IRepository<InvestmentTool>, InvestmentToolRepository>();

            services.AddSingleton<ClientWebSocket>(sp =>
            {
                var socket = new ClientWebSocket();
                socket.Options.KeepAliveInterval = TimeSpan.FromDays(10);
                return socket;
            });
        }


        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
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
}