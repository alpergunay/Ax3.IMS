using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ax3.IMS.Domain;

namespace Ims.Domain.DomainModels
{
    public interface IAccountRepository : IRepository<Account>
    {
        IQueryable<object> GetUserAccountsAsQueryable(string user);
    }
}
