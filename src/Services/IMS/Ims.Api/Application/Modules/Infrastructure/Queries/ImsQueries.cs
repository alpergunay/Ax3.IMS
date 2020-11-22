using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Dapper;
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
using Npgsql;

namespace Ims.Api.Application.Modules.Infrastructure.Queries
{
    public class ImsQueries : IImsQueries
    {
        private readonly string _connectionString;

        public ImsQueries(string connectionString)
        {
            _connectionString = connectionString.IsNullOrEmpty() ? throw new ArgumentNullException() : connectionString;
        }
        public async Task<IEnumerable<StoreTypeResponseModel>> GetStoreTypesAsync()
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<StoreTypeResponseModel>("SELECT * FROM ims.store_types");
            }
        }
        public async Task<IEnumerable<StoreResponseModel>> GetStoresAsync()
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<StoreResponseModel>("SELECT * FROM ims.stores");
            }
        }
        public async Task<IEnumerable<StoreBranchResponseModel>> GetStoreBranchesAsync()
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<StoreBranchResponseModel>("SELECT * FROM ims.store_branches");
            }
        }

        public async Task<IEnumerable<InvestmentToolTypeResponseModel>> GetInvestmentToolTypesAsync()
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<InvestmentToolTypeResponseModel>("SELECT * FROM ims.investment_tool_types");
            }
        }

        public async Task<IEnumerable<AccountTypeResponseModel>> GetAccountTypesAsync()
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<AccountTypeResponseModel>("SELECT * FROM ims.account_types");
            }
        }

        public async Task<IEnumerable<InvestmentToolResponseModel>> GetInvestmentToolsAsync()
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<InvestmentToolResponseModel>("SELECT * FROM ims.investment_tools");
            }
        }

        public async Task<IEnumerable<AccountTypeResponseModel>> FilterAccountTypesAsync(string queryString)
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var x = await connection.QueryAsync<AccountTypeResponseModel>("SELECT * FROM ims.account_types " +
                                                                        "WHERE name LIKE @t", new { t = "%" + queryString + "%" });
                return x;
            }
        }
        public async Task<IEnumerable<StoreTypeResponseModel>> FilterStoreTypesAsync(string queryString)
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var x = await connection.QueryAsync<StoreTypeResponseModel>("SELECT * FROM ims.store_types " +
                                                                            "WHERE name LIKE @t", new { t = "%" + queryString + "%" });
                return x;
            }
        }
        public async Task<IEnumerable<StoreResponseModel>> FilterStoresAsync<T>(BaseFilterRequestModel<int> filter)
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var x = await connection.QueryAsync<StoreResponseModel>("SELECT * FROM ims.stores " +
                                                                            "WHERE name LIKE @t AND (store_type_id=@stid OR @stid=0)", new { t = "%" + filter.typed + "%", stid= Equals(filter.id, default(T)) ? 0 : filter.id });
                return x;
            }
        }
        public async Task<IEnumerable<StoreBranchResponseModel>> FilterStoreBranchesAsync<T>(BaseFilterRequestModel<Guid> filter)
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<StoreBranchResponseModel>("SELECT * FROM ims.store_branches " +
                                                                        "WHERE name LIKE @t AND (store_id=@stid OR @stid IS NULL)", new { t = "%" + filter.typed + "%", stid = Equals(filter.id, default(T)) ? default(Guid) : filter.id });
            }
        }

        public async Task<IEnumerable<InvestmentToolResponseModel>> FilterInvestmentToolAsync<T>(BaseFilterRequestModel<int> queryString)
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<InvestmentToolResponseModel>("SELECT * FROM ims.investment_tools " +
                                                                                "WHERE name LIKE @t AND (investment_tool_type_id=@ittid OR @ittid=0)", new { t = "%" + queryString.typed + "%", ittid = Equals(queryString.id, default(T)) ? 0 : queryString.id });
            }
        }

        public async Task<IEnumerable<InvestmentToolTypeResponseModel>> FilterInvestmentToolTypesAsync<T>(BaseFilterRequestModel<T> queryString)
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                return await connection.QueryAsync<InvestmentToolTypeResponseModel>("SELECT * FROM ims.investment_tool_types " +
                                                                                    "WHERE name LIKE @t", new { t = "%" + queryString.typed + "%" });
            }
        }

        public async Task<IEnumerable<TransactionTypeResponseModel>> GetTransactionTypesAsync()
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<TransactionTypeResponseModel>("SELECT * FROM ims.transaction_types");
            }
        }

        public async Task<IEnumerable<DirectionTypeResponseModel>> GetDirectionTypesAsync()
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<DirectionTypeResponseModel>("SELECT * FROM ims.direction_types");
            }
        }

        public async Task<IEnumerable<AccountResponseModel>> GetAccountsAsync(Guid userId)
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<AccountResponseModel>(@"SELECT a.id as Id,
                                                                               a.account_no as AccountNo,
                                                                               at.id as AccountTypeId,
                                                                               at.name as AccountTypeName,
                                                                               sb.id as StoreBranchId,
                                                                               sb.name as StoreBranchName,
                                                                               s.id as StoreId,
                                                                               s.name as StoreName,
                                                                               it.id as InvestmentToolId,
                                                                               it.name as InvestmentToolName
                                                                        FROM accounts a
                                                                        INNER JOIN account_types at on at.id = a.account_type_id
                                                                        INNER JOIN store_branches sb on sb.id = a.store_branch_id
                                                                        INNER JOIN stores s on s.id = sb.store_id
                                                                        INNER JOIN investment_tools it on it.id = a.investment_tool_id
                                                                        WHERE a.creator = @user_id", new {user_id = userId});
            }
        }

        public async Task<IEnumerable<AccountResponseModel>> FilterAccountsAsync<T>(BaseFilterRequestModel<T> queryString)
        {
            await using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<AccountResponseModel>(@"SELECT a.id as Id,
                                                                               a.account_no as AccountNo,
                                                                               at.id as AccountTypeId,
                                                                               at.name as AccountTypeName,
                                                                               sb.id as StoreBranchId,
                                                                               sb.name as StoreBranchName,
                                                                               s.id as StoreId,
                                                                               s.name as StoreName,
                                                                               it.id as InvestmentToolId,
                                                                               it.name as InvestmentToolName
                                                                        FROM accounts a
                                                                        INNER JOIN account_types at on at.id = a.account_type_id
                                                                        INNER JOIN store_branches sb on sb.id = a.store_branch_id
                                                                        INNER JOIN stores s on s.id = sb.store_id
                                                                        INNER JOIN investment_tools it on it.id = a.investment_tool_id
                                                                        WHERE a.creator = @user_id AND a.account_name LIKE @t", new { user_id = queryString.id, t = "%" + queryString.typed + "%" });
            }
        }
    }
}
