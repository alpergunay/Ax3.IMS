using System;
using System.Linq;
using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Ims.Infrastructure.Repositories
{
    public class AccountTypeRepository : GenericRepository<ImsContext, AccountType, Guid>, IAccountTypeRepository
    {
        public AccountTypeRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IQueryable<AccountType> GetWithAccounts(string userName, string typed)
        {
            return Context.AccountTypes
                .Include(a => a.Accounts)
                .ThenInclude(a=>a.AccountTransactions)
                .ThenInclude(t=>t.TransactionType)
                .ThenInclude(d=>d.DirectionType)
                .Where(at => at.Accounts
                    .Any(a => a.Creator == userName && 
                              a.AccountName
                                  .ToUpper()
                                  .Contains(typed == null ? "" : typed.ToUpper())));
        }
    }
}
