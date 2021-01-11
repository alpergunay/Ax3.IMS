using AutoMapper;
using Ax3.IMS.DataAccess.EntityFramework;
using Ims.Domain.DomainModels;
using Ims.Domain.Dto;
using System;
using System.Linq;

namespace Ims.Infrastructure.Repositories
{
    public class AccountTypeRepository : GenericRepository<ImsContext, AccountType, Guid>, IAccountTypeRepository
    {
        public AccountTypeRepository(ImsContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public IQueryable<AccountDto> GetWithAccounts(string user, string typed, string investmentToolId)
        {
            typed ??= "";
            investmentToolId ??= "";
            var query = (from att in Context.AccountTypes
                         join a in Context.Accounts on att.EnumId equals a.AccountTypeId
                         join sb in Context.StoreBranches on a.StoreBranchId equals sb.Id
                         join s in Context.Stores on sb.StoreId equals s.Id
                         join st in Context.StoreTypes on s.StoreTypeId equals st.EnumId
                         join it in Context.InvestmentTools on a.InvestmentToolId equals it.Id
                         join itt in Context.InvestmentToolTypes on it.InvestmentToolTypeId equals itt.EnumId
                         join u in Context.Users on a.Creator equals u.UserName
                         where a.Creator == user && (investmentToolId == "" || a.InvestmentToolId == Guid.Parse(investmentToolId)) && a.AccountName.ToUpper().Contains(typed.ToUpper())
                         select new 
                             {
                                 AccountTypeId = att.EnumId,
                                 AccountTypeName = att.Name,
                                 StoreName = s.Name,
                                 StoreBranchName = sb.Name,
                                 InvestmentToolId = it.Id,
                                 InvestmentToolName = it.Name,
                                 InvestmentToolCode = it.Code,
                                 Id = a.Id.ToString(),
                                 AccountName = a.AccountName,
                                 Balance = (Context.AccountTransactions
                                               .Where(i => i.AccountId == a.Id && i.TransactionType.DirectionTypeId == DirectionType.Positive.EnumId).DefaultIfEmpty()
                                               .Sum(at => (double?)at.Amount ?? 0)) - (Context.AccountTransactions
                                               .Where(i => i.AccountId == a.Id && i.TransactionType.DirectionTypeId ==
                                                           DirectionType.Negative.EnumId).DefaultIfEmpty()
                                               .Sum(at => (double?)at.Amount ?? 0)),
                                LocalCurrencyId = u.LocalCurrencyId

                         }).Select(adt=>new AccountDto
            {
                AccountTypeId = adt.AccountTypeId,
                AccountTypeName = adt.AccountTypeName,
                StoreName = adt.StoreName,
                StoreBranchName = adt.StoreBranchName,
                InvestmentToolId = adt.InvestmentToolId.ToString(),
                InvestmentToolName = adt.InvestmentToolName,
                InvestmentToolCode = adt.InvestmentToolCode,
                Id = adt.Id,
                AccountName = adt.AccountName,
                Balance = adt.Balance,
                BalanceInLocalCurrency = adt.InvestmentToolId != adt.LocalCurrencyId ? (adt.Balance * (Context.InvestmentToolPrices
                    .Where(p => p.PriceDate <= DateTime.Now.Date && p.InvestmentToolId == adt.InvestmentToolId)
                    .OrderByDescending(p => p.PriceDate)
                    .DefaultIfEmpty().Select(p => p.BuyingPrice).FirstOrDefault())) : 1.0
            });

            return query;
        }
    }
}
