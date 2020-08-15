using Ax3.IMS.Infrastructure.Core.Services;
using Ax3.IMS.DataAccess.EntityFramework.Interceptors;
using Ax3.IMS.Domain.Types;
using Ax3.IMS.Infrastructure.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Ax3.IMS.DataAccess.EntityFramework
{
    public class BaseDbContext<TContext> : DbContext
        where TContext : DbContext
    {
        private static bool isAnyFilterInitilized;

        private string IdPropertyName { get; } = typeof(IEntity<>).GetProperties().First().Name;
        private readonly IUserService _userService;
        public int? TenantId { get; set; }

        protected BaseDbContext(DbContextOptions<TContext> options, IUserService userService)
            : base(options)
        {
            _userService = userService;
        }

        protected BaseDbContext(DbContextOptions<TContext> options) : base(options)
        {
        }

        public override int SaveChanges()
        {
            var interceptionContext = GetInterceptionContext();
            var interceptors = DbInterceptorsProvider.Get().ToList();

            interceptors.ForEach(i => i.Before(interceptionContext));
            EntitySoftDelete();
            var result = base.SaveChanges();
            interceptors.ForEach(i => i.After(interceptionContext));

            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var interceptionContext = GetInterceptionContext();
            var interceptors = DbInterceptorsProvider.Get().ToList();

            interceptors.ForEach(i => i.Before(interceptionContext));
            EntitySoftDelete();
            var result = await base.SaveChangesAsync(cancellationToken);
            interceptors.ForEach(i => i.After(interceptionContext));

            return result;
        }

        protected static void InitilizeGlobalFilters<T>(Expression<Func<T, bool>> filterExpression)
            where T : class
        {
            QueryFilterManager.Filter<T>(p => p.Where(filterExpression));

            isAnyFilterInitilized = true;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseLazyLoadingProxies(false);
            if (isAnyFilterInitilized)
            {
                QueryFilterManager.InitilizeGlobalFilter(this);
            }

            optionsBuilder.UseLoggerFactory(ImsLogging.LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties())
                .Where(p => p.GetColumnType() == null))
            {
                if (property.ClrType == typeof(decimal))
                {
                    property.SetColumnType("decimal(30, 8)");
                }

                //modelBuilder.SnakeCaseifyNames(); // PostgreSQL
                modelBuilder.EnableSoftDelete();
            }

            foreach (var type in modelBuilder.Model.GetEntityTypes()
                .Where(t => t.ClrType.GetInterfaces()
                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntity<>))))
            {
                var property = type.GetProperties().First(p => p.Name == IdPropertyName);
                var attr = property.PropertyInfo.GetCustomAttribute<ColumnAttribute>();

                if (!string.IsNullOrEmpty(attr?.Name))
                {
                    property.SetColumnName(attr.Name);
                }
                else
                {
                    property.SetColumnName(type.ClrType.Name + IdPropertyName);
                }
            }

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()))
            {
                var attr = property.PropertyInfo.GetCustomAttribute<SqlColumnTypeAttribute>();
                if (!string.IsNullOrEmpty(attr?.ColumnType))
                {
                    property.SetColumnType(attr.ColumnType);
                }
            }
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        private DbInterceptionContext GetInterceptionContext()
        {
            var entries = ChangeTracker.Entries().ToList();
            var entriesByState = entries.ToLookup(row => row.State);

            return new DbInterceptionContext
            {
                DbContext = this,
                Entries = entries,
                EntriesByState = entriesByState,
                UserId = this._userService.GetUserName()
            };
        }

        private void EntitySoftDelete()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.State == EntityState.Deleted)
                {
                    Entity entity = (Entity)item.Entity;
                    entity.IsDeleted = true;
                    item.State = EntityState.Modified;
                }
            }
        }
    }
}