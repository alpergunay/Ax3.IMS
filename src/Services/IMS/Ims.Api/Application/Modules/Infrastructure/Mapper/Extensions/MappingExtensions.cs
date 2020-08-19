using AutoMapper;
using Europcar.RentoCloud.Domain.Types;
using System;
using System.Collections.Generic;
using Web.API.Application.Modules.Infrastructure.Models;

namespace Web.API.Application.Modules.Infrastructure.Mapper.Extensions
{
    public static class MappingExtensions
    {
        private static TDestination Map<TDestination>(this object source)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(WepApiMapperConfiguration));
            });

            return configuration.CreateMapper().Map<TDestination>(source);
        }

        private static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(typeof(WepApiMapperConfiguration));
            });

            return configuration.CreateMapper().Map(source, destination);
        }

        public static TEntity ToEntity<TEntity>(this BaseViewModel model) where TEntity : Entity
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            return model.Map<TEntity>();
        }

        public static TEntity ToEntity<TEntity>(this BaseViewModel model, TEntity entity) where TEntity : Entity
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return model.MapTo(entity);
        }

        public static TModel ToModel<TModel>(this Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return entity.Map<TModel>();
        }

        public static IEnumerable<TModel> ToModel<TModel>(this IEnumerable<Entity> entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return entity.Map<IEnumerable<TModel>>();
        }
    }
}