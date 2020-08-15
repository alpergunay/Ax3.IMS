using System;
using Autofac;
using Ax3.IMS.Infrastructure.Core;
using Ax3.IMS.Domain.Types;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Ax3.IMS.DataAccess.Mongo
{
    public static class Extensions
    {
        public static void AddMongo(this ContainerBuilder builder)
        {
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>();
                var options = configuration.GetOptions<MongoDbOptions>("mongo");

                return options;
            }).SingleInstance();

            builder.Register(context =>
            {
                var options = context.Resolve<MongoDbOptions>();

                return new MongoClient(options.ConnectionString);
            }).SingleInstance();

            builder.Register(context =>
            {
                var options = context.Resolve<MongoDbOptions>();
                var client = context.Resolve<MongoClient>();
                return client.GetDatabase(options.Database);

            }).InstancePerLifetimeScope();

            builder.RegisterType<MongoDbInitializer>()
                .As<IMongoDbInitializer>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MongoDbSeeder>()
                .As<IMongoDbSeeder>()
                .InstancePerLifetimeScope();

            builder.RegisterType<MongoContext>()
                .As<IMongoContext>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
        }

        //Comment Not : MongoRepository is converted to abstract MongoBaseRepository
        public static void AddMongoRepository<TEntity>(this ContainerBuilder builder,string collectionName)
            where TEntity : IMongoEntity
            => builder.Register(ctx => new Repository<TEntity>(ctx.Resolve<IMongoDatabase>(), collectionName))
                .As<IRepository<TEntity>>()
                .InstancePerLifetimeScope();


        
    }
}
