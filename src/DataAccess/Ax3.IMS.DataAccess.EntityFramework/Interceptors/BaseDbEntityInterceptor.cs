using Ax3.IMS.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace Ax3.IMS.DataAccess.EntityFramework.Interceptors
{
    public abstract class BaseDbEntityInterceptor : IDbInterceptor
    {
        private static readonly EntityState[] TrackedStates = { EntityState.Added, EntityState.Modified, EntityState.Deleted };
        private string _userId;

        protected BaseDbEntityInterceptor()
        {
        }

        public void Before(DbInterceptionContext context)
        {
            var added = context.EntriesByState[EntityState.Added];
            var modified = context.EntriesByState[EntityState.Modified];
            var deleted = context.EntriesByState[EntityState.Deleted];
            _userId = context.UserId;

            OnBefore(added, modified, deleted);
        }

        public void After(DbInterceptionContext context)
        {
            var added = context.EntriesByState[EntityState.Added];
            var modified = context.EntriesByState[EntityState.Modified];
            var deleted = context.EntriesByState[EntityState.Deleted];
            _userId = context.UserId;
            OnAfter(added, modified, deleted);
        }

        protected virtual void OnBefore(IEnumerable<EntityEntry> added, IEnumerable<EntityEntry> modified, IEnumerable<EntityEntry> deleted)
        {
            foreach (var item in added)
            {
                var entity = (item.Entity as Entity);
                entity.CreatedOn = DateTime.UtcNow;
                entity.ModifiedOn = DateTime.UtcNow;
                entity.Creator = _userId;
                entity.Modifier = _userId;
            }

            foreach (var item in modified)
            {
                var entity = (item.Entity as Entity);
                entity.ModifiedOn = DateTime.UtcNow;
                entity.Modifier = _userId;
            }

            foreach (var item in deleted)
            {
                var entity = (item.Entity as Entity);
                entity.ModifiedOn = DateTime.UtcNow;
                entity.Modifier = _userId;
                entity.IsDeleted = true;
            }
        }

        protected virtual void OnAfter(IEnumerable<EntityEntry> added, IEnumerable<EntityEntry> modified, IEnumerable<EntityEntry> deleted)
        {
        }
    }
}