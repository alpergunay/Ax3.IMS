using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Logging;
using PriceProviders.Shared.Extensions;
using PriceProviders.Shared.Models;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace PriceProviders.Shared.Data
{
    public class PriceRepository<T> : Repository<T> where T: InvestmentToolPrice
    {
        public PriceRepository(IAmazonDynamoDB dynamoDb, IDynamoDBContext context, ILogger<T> logger)
        :base(dynamoDb, context, logger)
        {
            
        }
        public override async Task SaveAsync(T currentPrice)
        {
            try
            {
                _logger.LogInformation("Saving current price...");
                /*
                 * 1. Find the document with price date and investment tool
                 * 2. Update Today Price
                 * 3. Insert new price
                 * 4. If search is unsuccessful, create new document
                 */
                var priceId = currentPrice.ToDynamoDbDateId();
                _logger.LogInformation("priceID = " + priceId);
                var dailyPrice = _context.LoadAsync<DailyInvestmentToolPrices<T>>(priceId).Result;
                if (dailyPrice == null)
                {
                    _logger.LogInformation("Could not find the price. Adding first time for the new day...");
                    dailyPrice = new DailyInvestmentToolPrices<T>
                    {
                        PriceDate = currentPrice.PriceDate.ToDynamoDbDate(),
                        InvestmentToolCode = currentPrice.InvestmentTool.Code,
                        InvestmentToolName = currentPrice.InvestmentTool.Name,
                        Day = currentPrice.PriceDate.Day,
                        Month = currentPrice.PriceDate.Month,
                        Price = currentPrice,
                        WeekNumber = ISOWeek.GetWeekOfYear(currentPrice.PriceDate),
                        Year = currentPrice.PriceDate.Year,
                        Id = priceId,
                        LastUpdateTime = DateTime.Now.ToDynamoDbDateTime()
                    };
                    await _context.SaveAsync(dailyPrice);
                    _logger.LogInformation("New date is successfully saved.");
                }
                else
                {
                    _logger.LogInformation("Found daily price. Updating the item...");
                    dailyPrice.Price = currentPrice;
                    dailyPrice.LastUpdateTime = DateTime.Now.ToDynamoDbDateTime();
                    _context.SaveAsync(dailyPrice).GetAwaiter();
                    _logger.LogInformation("New date is successfully saved.");
                }
                var priceTimeSeries = new PriceTimeSeries<T>
                {
                    DailyPriceId = priceId,
                    Id = currentPrice.ToDynamoDbTimeId(),
                    PriceTime = currentPrice.PriceDate.ToDynamoDbDateTime(),
                    Price = currentPrice
                };
                await _context.SaveAsync(priceTimeSeries);
                _logger.LogInformation("Current price is saved to database.");
            }
            catch (Exception e)
            {
                _logger.LogError("Error occured while saving the current foreign price: " + e.Message);
                throw e;
            }
        }
    }
}
