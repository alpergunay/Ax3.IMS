using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ims.Infrastructure.Repositories
{
    public class AccountRepository : GenericRepository<ImsContext, Account, Guid>, IAccountRepository
    {
        public AccountRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override async Task<Account> FindOrDefaultAsync(Guid entityId)
        {
            var account = await Context.Accounts
                .Include(a => a.StoreBranch)
                .Include(a => a.StoreBranch.Store)
                .Include(a => a.StoreBranch.Store.StoreType)
                .Include(a => a.InvestmentTool)
                .Include(a => a.InvestmentTool.InvestmentToolType)
                .Include(at=>at.AccountTransactions).ThenInclude(tt=>tt.TransactionType)
                .FirstOrDefaultAsync(a => a.Id == entityId);
            return account;
        }
    }
}
