using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                .Include(at => at.AccountTransactions).ThenInclude(tt => tt.TransactionType)
                .FirstOrDefaultAsync(a => a.Id == entityId);
            return account;
        }

        public IQueryable<object> GetUserAccountsAsQueryable(string user)
        {
            var query = (from a in Context.Accounts
                         join att in Context.AccountTypes on a.AccountTypeId equals att.EnumId
                         join sb in Context.StoreBranches on a.StoreBranchId equals sb.Id
                         join s in Context.Stores on sb.StoreId equals s.Id
                         join st in Context.StoreTypes on s.StoreTypeId equals st.EnumId
                         join it in Context.InvestmentTools on a.InvestmentToolId equals it.Id
                         join itt in Context.InvestmentToolTypes on it.InvestmentToolTypeId equals itt.EnumId
                         where a.Creator == user
                         select
                             new
                             {
                                 Id = a.Id,
                                 UserId = a.Creator,
                                 StoreBranchId = sb.Id,
                                 StoreBranchName = sb.Name,
                                 StoreId = s.Id,
                                 StoreName = s.Name,
                                 StoreTypeId = st.EnumId,
                                 StoreTypeName = st.Name,
                                 AccountTypeId = att.EnumId,
                                 AccountTypeName = att.Name,
                                 InvestmentToolId = it.Id,
                                 InvestmentToolName = it.Name,
                                 InvestmentToolTypeId = itt.EnumId,
                                 InvestmentToolTypeName = itt.Name,
                                 AccountNo = a.AccountNo,
                                 AccountName = a.AccountName,
                                 Balance = (Context.AccountTransactions
                                               .Where(i => i.AccountId == a.Id && i.TransactionType.DirectionTypeId == DirectionType.Positive.EnumId).DefaultIfEmpty()
                                               .Sum(at=>(double?) at.Amount ?? 0)) - (Context.AccountTransactions
                                               .Where(i => i.AccountId == a.Id && i.TransactionType.DirectionTypeId ==
                                                           DirectionType.Negative.EnumId).DefaultIfEmpty()
                                               .Sum(at => (double?)at.Amount ?? 0))
                             });

            return query;
        }
    }
}
