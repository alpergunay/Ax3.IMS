using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace ax3_ims_angular
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .ConfigureAppConfiguration((builderContext, config) =>
                        {
                            config.AddEnvironmentVariables();
                        })
                        .ConfigureLogging((hostingContext, builder) =>
                        {
                            builder.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                            builder.AddConsole();
                            builder.AddDebug();
                        })
                        .UseSerilog((builderContext, config) =>
                        {
                            config
                                .MinimumLevel.Information()
                                .Enrich.FromLogContext()
                                .WriteTo.Console();
                        });
                });
    }
}
