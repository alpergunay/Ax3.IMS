using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ims.Api.Application.Modules.Infrastructure.Models.Account;
using Ims.Api.Application.Modules.Infrastructure.Models.AccountType;
using Ims.Api.Application.Modules.Infrastructure.Models.DirectionType;
using Ims.Api.Application.Modules.Infrastructure.Models.InvestmentToolType;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreType;
using Ims.Api.Application.Modules.Infrastructure.Models.TransactionType;

namespace Ims.Api.Application.Modules.Infrastructure.Queries
{
    public interface IImsQueries
    {
        Task<IEnumerable<StoreTypeResponseModel>> GetStoreTypesAsync();
        Task<IEnumerable<InvestmentToolTypeResponseModel>> GetInvestmentToolTypesAsync();
        Task<IEnumerable<AccountTypeResponseModel>> GetAccountTypesAsync();
        Task<IEnumerable<AccountTypeResponseModel>> FilterAccountTypesAsync(string typed);
        Task<IEnumerable<TransactionTypeResponseModel>> GetTransactionTypesAsync();
        Task<IEnumerable<DirectionTypeResponseModel>> GetDirectionTypesAsync();
        Task<IEnumerable<AccountResponseModel>> GetAccountsAsync(Guid userId);

    }
}
