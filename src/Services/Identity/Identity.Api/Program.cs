using Autofac;
using Autofac.Extensions.DependencyInjection;
using Ax3.IMS.Infrastructure.Configuration.Settings;
using Ax3.IMS.Infrastructure.Core.Http.Extensions;
using Identity.Api.Data;
using Identity.Api.Models;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.IO;

namespace Identity.Api
{
    public class Program
    {
        public static readonly string Namespace = typeof(Program).Namespace;

        public static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.',
                                                                                          Namespace.LastIndexOf('.') - 1) +
            1);

        public static void Main(string[] args)
        {
            try
            {
                var configuration = GetConfiguration();
                Log.Logger = CreateSerilogLogger(configuration);
                Log.Information("Configuring web host ({ApplicationContext})...", AppName);
                IHost host = CreateHostBuilder(args, configuration).Build();

                Log.Information("Applying migrations ({ApplicationContext})...", AppName);

                var lifetimeScope = host.Services.GetAutofacRoot();

                host.MigrateDbContext<PersistedGrantDbContext>(lifetimeScope,
                                                               (__, ___) =>
                {
                })
                    .MigrateDbContext<ApplicationDbContext>(lifetimeScope,
                                                            (context, container) =>
                                                            {
                                                                var env = lifetimeScope.Resolve<IWebHostEnvironment>();
                                                                var settings = lifetimeScope.Resolve<IOptions<ApplicationSettings>>();
                                                                var logger = lifetimeScope.Resolve<ILogger<ApplicationDbContextSeed>>();
                                                                var userManager = lifetimeScope.Resolve<UserManager<ApplicationUser>>();
                                                                var roleManager = lifetimeScope.Resolve<RoleManager<ApplicationRole>>();

                                                                new ApplicationDbContextSeed()
                                .SeedAsync(context, env, logger, roleManager, userManager)
                                                                    .Wait();
                                                            })
                    .MigrateDbContext<ConfigurationDbContext>(lifetimeScope,
                                                              (context, services) =>
                                                              {
                                                                  ConfigurationDbContextSeed
                            .SeedAsync(context, configuration)
                                                                      .Wait();
                                                              });
                Log.Information("Starting web host ({ApplicationContext})...", AppName);
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
                //return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) => Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseContentRoot(Directory.GetCurrentDirectory());
                webBuilder.UseConfiguration(configuration);
            });

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                             optional: true)
                .AddJsonFile("appsettings.Local.json", optional: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }

        private static Serilog.ILogger CreateSerilogLogger(IConfiguration configuration)
        {
            var seqServerUrl = configuration["ApplicationSettings:Logging:SinkUrl"];

            return new LoggerConfiguration()
                .MinimumLevel
                .Verbose()
                .Enrich
                .WithProperty("ApplicationContext", AppName)
                .Enrich
                .FromLogContext()
                .WriteTo
                .Console()
                .WriteTo
                .Seq(string.IsNullOrWhiteSpace(seqServerUrl) ? "http://seq" : seqServerUrl)
                .ReadFrom
                .Configuration(configuration)
                .CreateLogger();
        }
    }
}