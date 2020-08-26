using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ax3.IMS.Domain.Types;
using Microsoft.EntityFrameworkCore.Storage;

namespace Ax3.IMS.Domain
{
    public interface IRepository<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        ICollection<T> GetAll();
        IQueryable<T> GetAllAsQueryable();
        IQueryable<T> GetAllAsNoFilterQueryable();
        ICollection<T> Find(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindAsNoFilterAsync(Expression<Func<T, bool>> predicate);
        Task<ICollection<T>> FindAsync(IEnumerable<Guid> ids);
        Task<ICollection<T>> FindAsNoFilterAsync(IEnumerable<Guid> ids);
        T Find(Guid entityId);
        Task<T> FindAsync(Guid entityId);
        T FindOrDefault(Guid entityId);
        Task<T> FindOrDefaultAsync(Guid entityId);
        IQueryable<T> FindAsQueryable(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
        T Delete(T entity);
        IEnumerable<T> DeleteRange(IEnumerable<T> entities);
        Task<int> DeleteQueryAsync(Expression<Func<T, bool>> predicate);
        void Update(T entity);
        Task<int> SaveChangesAsync();
        int SaveChanges();
        IDbContextTransaction BeginTransaction(IsolationLevel isolationLevel);
        static Expression<Func<T, bool>> GetByIdPredicate(Guid entityId) => e => (object)e.Id == (object)entityId;
    }
}
