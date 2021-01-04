using Ax3.IMS.Domain;
using System.Linq;

namespace Ims.Domain.DomainModels
{
    public interface IAccountRepository : IRepository<Account>
    {
        IQueryable<object> GetUserAccountsAsQueryable(string user);
    }
}
