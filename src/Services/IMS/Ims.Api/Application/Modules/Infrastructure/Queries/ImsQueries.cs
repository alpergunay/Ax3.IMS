using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Dapper;
using Ims.Api.Application.Modules.Infrastructure.Models.Account;
using Ims.Api.Application.Modules.Infrastructure.Models.AccountType;
using Ims.Api.Application.Modules.Infrastructure.Models.DirectionType;
using Ims.Api.Application.Modules.Infrastructure.Models.InvestmentToolType;
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
                                                                        WHERE a.user_id = @user_id", new {user_id = userId});
            }
        }
    }
}
