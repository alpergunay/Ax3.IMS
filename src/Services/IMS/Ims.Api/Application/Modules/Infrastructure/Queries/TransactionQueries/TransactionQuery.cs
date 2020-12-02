using Castle.Core.Internal;
using System;

namespace Ims.Api.Application.Modules.Infrastructure.Queries.TransactionQueries
{
    public class TransactionQuery : ITransactionQuery
    {
        private readonly string _connectionString;

        public TransactionQuery(string connectionString)
        {
            _connectionString = connectionString.IsNullOrEmpty() ? throw new ArgumentNullException() : connectionString;
        }
    }
}
