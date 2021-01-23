using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Microsoft.Extensions.Logging;
using PriceProviders.Shared.Abstractions;
using PriceProviders.Shared.Models;

namespace PriceProviders.Shared.Data
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        protected readonly IAmazonDynamoDB _dynamoDb;
        protected readonly IDynamoDBContext _context;
        protected readonly ILogger<T> _logger;
        public Repository(IAmazonDynamoDB dynamoDb, IDynamoDBContext context, ILogger<T> logger)
        {
            _dynamoDb = dynamoDb;
            _context = context;
            _logger = logger;
        }
        public virtual Task SaveAsync(T entity)
        {
            return _context.SaveAsync(entity);
        }

        public virtual async Task<T> GetAsync(string entityId)
        {
            return await _context.LoadAsync<T>(entityId);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            var conditions = new List<ScanCondition>();
            return await _context.ScanAsync<T>(conditions).GetRemainingAsync();
        }

        public virtual async Task<T> ScanWithKey(string nameOfKey, string key)
        {
            var conditions = new List<ScanCondition>();

            conditions.Add(new ScanCondition(nameOfKey, ScanOperator.Equal, key));
            return (await _context.ScanAsync<T>(conditions).GetRemainingAsync()).FirstOrDefault();
        }
    }
}
