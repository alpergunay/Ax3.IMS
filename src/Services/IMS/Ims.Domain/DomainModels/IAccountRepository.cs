using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ims.Domain.DomainModels
{
    public interface IAccountRepository
    {
        Task<ICollection<T>> GetAllAsync<T>() where T : class;
        Account Add(Account entity);
        void Update(Account entity);
        Task<Account> FindAsync(Guid entityId);
    }
}
