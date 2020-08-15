using Ax3.IMS.Infrastructure.Configuration.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ax3.IMS.Infrastructure.Configuration.File
{
    public static class JsonConfigurationExtensions
    {
        private static void UseJsonConfiguration(this IServiceCollection services, string basePath, string[] args = null, params Tuple<string, bool>[] fileOpts)
        {
            var builder = new ConfigurationBuilder().SetBasePath(basePath);
            foreach (var fileOpt in fileOpts)
            {
                builder.AddJsonFile(fileOpt.Item1, optional: fileOpt.Item2, reloadOnChange: true);
            }

            builder.AddEnvironmentVariables();
            builder.AddCommandLine(args ?? new string[0]);

            var configuration = builder.Build();
            services.AddSingleton<IConfiguration>(configuration);
        }

        private static void UseJsonConfiguration(this IServiceCollection services, string basePath, string[] args = null, params string[] fileNames)
        {
            UseJsonConfiguration(services, basePath, args, fileNames.Select(x => new Tuple<string, bool>(x, true)).ToArray());
        }

        public static void UseJsonConfiguration(this IServiceCollection services, IHostEnvironment env, string[] args = null, params string[] fileNames)
        {
            var options = new List<Tuple<string, bool>>(fileNames.Select(x => new Tuple<string, bool>(x, false)));
            options.AddRange(fileNames.Select(fileName =>
                new Tuple<string, bool>(
                    $"{Path.GetFileNameWithoutExtension(fileName)}.{env.EnvironmentName}{Path.GetExtension(fileName)}",
                    true)));

            UseJsonConfiguration(services, basePath: env.ContentRootPath, args: args, fileOpts: options.ToArray());
        }

        public static EndpointSettings GetJsonEndpointSetting(this IConfigurationBuilder builder, string basePath, string fileName)
        {
            var config = builder
                .SetBasePath(basePath)
                .AddJsonFile(fileName, optional: false, reloadOnChange: false)
                .Build();

            var endpoint = new EndpointSettings();
            config.GetSection(typeof(EndpointSettings).Name).Bind(endpoint);
            return endpoint;
        }
    }
}