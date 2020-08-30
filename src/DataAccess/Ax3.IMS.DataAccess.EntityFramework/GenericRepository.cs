using Ax3.IMS.Domain.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ax3.IMS.DataAccess.Core;
using Ax3.IMS.Domain;
using Z.EntityFramework.Plus;
using IsolationLevel = System.Data.IsolationLevel;

namespace Ax3.IMS.DataAccess.EntityFramework
{
    public abstract class GenericRepository<TContext, TEntity, TEntityId>
        where TContext : DbContext
        where TEntity : class, IEntity<TEntityId>
    {
        protected TContext Context { get; }

        protected DbSet<TEntity> DbSet { get; }
        protected TransactionScope ReadUncommitedTransactionScopeAsync => new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.ReadUncommitted }, TransactionScopeAsyncFlowOption.Enabled);
        protected IMapper Mapper { get; }
        protected GenericRepository(TContext context, IMapper mapper)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
            Context.ChangeTracker.AutoDetectChangesEnabled = false;
            Mapper = mapper;
        }

        public ICollection<TEntity> GetAll()
        {
            return DbSet.ToList();
        }
        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }
        public async Task<ICollection<T>> GetAllAsync<T>() where T : class
        {
            return await DbSet.AsQueryable().ProjectTo<T>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return DbSet.AsQueryable();
        }
        public IQueryable<TEntity> GetAllAsNoFilterQueryable()
        {
            return DbSet.AsNoFilter();
        }

        public ICollection<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).ToList();
        }

        public async Task<ICollection<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<ICollection<TEntity>> FindAsNoFilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoFilter().Where(predicate).ToListAsync();
        }

        public async Task<ICollection<TEntity>> FindAsync(IEnumerable<TEntityId> ids)
        {
            return await DbSet.Where(e => ids.Contains(e.Id)).ToListAsync();
        }

        public async Task<ICollection<TEntity>> FindAsNoFilterAsync(IEnumerable<TEntityId> ids)
        {
            return await DbSet.AsNoFilter().Where(e => ids.Contains(e.Id)).ToListAsync();
        }

        public TEntity Find(TEntityId entityId)
        {
            return DbSet.Single(GetByIdPredicate(entityId));
        }

        public Task<TEntity> FindAsync(TEntityId entityId)
        {
            return DbSet.SingleAsync(GetByIdPredicate(entityId));
        }

        public TEntity FindOrDefault(TEntityId entityId)
        {
            return DbSet.SingleOrDefault(GetByIdPredicate(entityId));
        }

        public Task<TEntity> FindOrDefaultAsync(TEntityId entityId)
        {
            return DbSet.SingleOrDefaultAsync(GetByIdPredicate(entityId));
        }

        public virtual IQueryable<TEntity> FindAsQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).AsQueryable();
        }

        public virtual TEntity Add(TEntity entity)
        {
            return DbSet.Add(entity).Entity;
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            return entities.Select(entity => DbSet.Add(entity).Entity);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AnyAsync(predicate);
        }

        public virtual TEntity Delete(TEntity entity)
        {
            return DbSet.Remove(entity).Entity;
        }

        public virtual IEnumerable<TEntity> DeleteRange(IEnumerable<TEntity> entities)
        {
            return entities.Select(entity => DbSet.Remove(entity).Entity);
        }

        public Task<int> DeleteQueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate).DeleteAsync();
        }

        public virtual void Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return Context.Database.BeginTransaction(isolationLevel);
        }
        private static Expression<Func<TEntity, bool>> GetByIdPredicate(TEntityId entityId) => e => (object)e.Id == (object)entityId;

        public virtual async Task<PagedResult<TD>> RetrievePagedResultAsync<TS, TD>(Expression<Func<TS, bool>> predicate, List<OrderBy> orderBy = null, Paging paging = null, params Expression<Func<TS, object>>[] includeExpressions) where TS : class
        {
            return await RetrieveAsQueryable<TS>(predicate, orderBy, includeExpressions).PaginateAsync<TS, TD>(paging, Mapper);
        }
        protected virtual IQueryable<T> RetrieveAsQueryable<T>(Expression<Func<T, bool>> predicate, List<OrderBy> orderBy = null, params Expression<Func<T, object>>[] includeExpressions) where T : class
        {
            var query = Context.Set<T>().AsQueryable<T>();

            if (includeExpressions?.Any() ?? false)
                query = includeExpressions.Aggregate(query, (current, expression) => current.Include(expression));

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy(orderBy);

            return query;
        }


    }
}