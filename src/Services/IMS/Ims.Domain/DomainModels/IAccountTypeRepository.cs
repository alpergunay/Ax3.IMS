using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ax3.IMS.Domain;

namespace Ims.Domain.DomainModels
{
    public interface IAccountTypeRepository:IRepository<AccountType>
    {
        IQueryable<AccountType> GetWithAccounts(string userName, string typed);
    }
}
