using System;
using Ims.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace Ims.Api.Factories
{
    public class ImsDbContextFactory : IDesignTimeDbContextFactory<ImsContext>
    {
        public ImsContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile($"appsettings.Development.json", optional: false)
                .AddEnvironmentVariables()
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<ImsContext>();
            optionsBuilder.UseNpgsql(config["ApplicationSettings:Persistence:ConnectionString"],
                npgsqlOptionsAction: sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(typeof(ImsContext).GetTypeInfo().Assembly.GetName().Name);
                }).UseSnakeCaseNamingConvention();

            return new ImsContext(optionsBuilder.Options);
        }
    }
}
