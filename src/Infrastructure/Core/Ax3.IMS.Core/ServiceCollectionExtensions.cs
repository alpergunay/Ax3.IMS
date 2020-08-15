using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ax3.IMS.Infrastructure.Core
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterConfiguration<TConfiguration>(this IServiceCollection services, IConfiguration configuration)
            where TConfiguration : class, new()
        {
            var settings = Activator.CreateInstance<TConfiguration>();
            configuration.GetSection(typeof(TConfiguration).Name).Bind(settings);

            services.Configure<TConfiguration>(opt => configuration.GetSection(typeof(TConfiguration).Name));
            services.AddSingleton(settings);
        }

        //public static void UseSerilogSinkConfiguration(this IServiceCollection services, Action<LoggingSettings, LoggerSinkConfiguration> sinkConfiguration)
        //{
        //    ShellInitializationParameters.LoggerSinkProviders.Add(sinkConfiguration);
        //}
    }
}