using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Logging;
using PriceProviders.Shared.Extensions;
using PriceProviders.Shared.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Util;

namespace PriceProviders.Shared.Data
{
    public class PriceRepository : Repository<InvestmentToolPrice> 
    {
        public PriceRepository(IAmazonDynamoDB dynamoDb, IDynamoDBContext context, ILogger<InvestmentToolPrice> logger)
        :base(dynamoDb, context, logger)
        {
            
        }
        public override async Task SaveAsync(InvestmentToolPrice currentPrice)
        {
            try
            {
                _logger.LogInformation("Saving current price...");
                /* 1. Get the latest price for investment tool
                 * 2. Fill the buying and sales price
                 * 3. Save as a new document
                 */
                var queryFilter = new QueryFilter("key", QueryOperator.Equal, currentPrice.Key);
                queryFilter.AddCondition("priceDate", QueryOperator.LessThan,
                    DateTime.Now.ToString(AWSSDKUtils.ISO8601DateFormat));
                var latestPrice = (await _context.FromQueryAsync<InvestmentToolPrice>(new QueryOperationConfig
                {
                    Limit = 1,
                    Filter = queryFilter,
                    BackwardSearch = true
                }).GetNextSetAsync()).FirstOrDefault();


                if (latestPrice != null)
                {
                    var newPrice = new InvestmentToolPrice(currentPrice.Key, DateTime.Now, currentPrice.InvestmentTool,
                        currentPrice.SalesPrice > 0 ? currentPrice.SalesPrice : latestPrice.SalesPrice,
                        currentPrice.BuyingPrice > 0 ? currentPrice.BuyingPrice : latestPrice.BuyingPrice);
                    _context.SaveAsync(newPrice).Wait();
                }
                else
                {
                    _context.SaveAsync(currentPrice).Wait();
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error occured while saving the current foreign price: " + e.Message);
                throw;
            }
        }
    }
}
