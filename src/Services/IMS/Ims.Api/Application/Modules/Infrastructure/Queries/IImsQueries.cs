using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ims.Api.Application.Modules.Infrastructure.Models;
using Ims.Api.Application.Modules.Infrastructure.Models.Account;
using Ims.Api.Application.Modules.Infrastructure.Models.AccountType;
using Ims.Api.Application.Modules.Infrastructure.Models.DirectionType;
using Ims.Api.Application.Modules.Infrastructure.Models.InvestmentTool;
using Ims.Api.Application.Modules.Infrastructure.Models.InvestmentToolType;
using Ims.Api.Application.Modules.Infrastructure.Models.Store;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreBranch;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreType;
using Ims.Api.Application.Modules.Infrastructure.Models.TransactionType;

namespace Ims.Api.Application.Modules.Infrastructure.Queries
{
    public interface IImsQueries
    {
        Task<IEnumerable<StoreTypeResponseModel>> GetStoreTypesAsync();
        Task<IEnumerable<StoreResponseModel>> GetStoresAsync();
        Task<IEnumerable<StoreBranchResponseModel>> GetStoreBranchesAsync();
        Task<IEnumerable<InvestmentToolTypeResponseModel>> GetInvestmentToolTypesAsync();
        Task<IEnumerable<AccountTypeResponseModel>> GetAccountTypesAsync();
        Task<IEnumerable<InvestmentToolResponseModel>> GetInvestmentToolsAsync();
        Task<IEnumerable<AccountTypeResponseModel>> FilterAccountTypesAsync(string typed);
        Task<IEnumerable<StoreTypeResponseModel>> FilterStoreTypesAsync(string queryString);
        Task<IEnumerable<StoreResponseModel>> FilterStoresAsync<T>(BaseFilterRequestModel<int> queryString);
        Task<IEnumerable<StoreBranchResponseModel>> FilterStoreBranchesAsync<T>(BaseFilterRequestModel<Guid> queryString);
        Task<IEnumerable<InvestmentToolResponseModel>> FilterInvestmentToolAsync<T>(BaseFilterRequestModel<int> queryString);
        Task<IEnumerable<InvestmentToolTypeResponseModel>> FilterInvestmentToolTypesAsync(string queryString);
        Task<IEnumerable<TransactionTypeResponseModel>> GetTransactionTypesAsync();
        Task<IEnumerable<DirectionTypeResponseModel>> GetDirectionTypesAsync();
        Task<IEnumerable<AccountResponseModel>> GetAccountsAsync(Guid userId);
        Task<IEnumerable<AccountLookupResponseModel>> FilterAccountsAsync<T>(BaseFilterRequestModel<T> queryString);
    }
}
