using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System.IO;
using Autofac;
using Ax3.IMS.Infrastructure.Cache.Redis;
using PriceProviders.Shared.Abstractions;
using PriceProviders.Shared.Models;
using Pricing.BackgroundServices.Data;
using Pricing.BackgroundServices.Extensions;

namespace Pricing.BackgroundServices
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;
        public static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);
        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();
            IHost host = CreateHostBuilder(args, configuration)
                .Build();

            //Apply Migrations
            var lifetimeScope = host.Services.GetAutofacRoot();
            var repository = lifetimeScope.Resolve<IRepository<InvestmentTool>>();
            var cacheManager = lifetimeScope.Resolve<ICacheManager>();

            new InvestmentToolSeeder()
                .SeedAsync(repository, cacheManager, configuration.GetValue<bool>("SeedData"))
                .Wait();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
                .ConfigureAppConfiguration(builder =>
                {
                    builder.Sources.Clear();
                    builder.AddConfiguration(configuration);
                })
                .ConfigureLogging((host, builder) => builder.UseSerilog(host.Configuration).AddSerilog());
        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}.json", optional: true)
                .AddEnvironmentVariables();
            return builder.Build();
        }
    }
}
