using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Dapper;
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
    }
}
