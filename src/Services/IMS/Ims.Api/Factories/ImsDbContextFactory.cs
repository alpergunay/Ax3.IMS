﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Ims.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Ims.Api.Factories
{
    //public class ImsDbContextFactory : IDesignTimeDbContextFactory<ImsContext>
    //{
    //    public ImsContext CreateDbContext(string[] args)
    //    {
    //        var config = new ConfigurationBuilder()
    //            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
    //            .AddJsonFile("appsettings.json")
    //            .AddEnvironmentVariables()
    //            .Build();

    //        var optionsBuilder = new DbContextOptionsBuilder<ImsContext>();

    //        optionsBuilder.UseNpgsql(config["ApplicationSettings:Persistence:ConnectionString"],
    //            npgsqlOptionsAction: sqlOptions =>
    //            {
    //                sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
    //            }).UseSnakeCaseNamingConvention();
    //        return new ImsContext(optionsBuilder.Options);
    //    }
    //}
}
