using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Lambda.Core;
using CurrencyPriceProvider.Abstractions;
using CurrencyPriceProvider.Extensions;
using CurrencyPriceProvider.Models;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace CurrencyPriceProvider.Data
{
    public class Repository<T> : IRepository<T> where T:InvestmentToolPrice
    {
        private readonly IAmazonDynamoDB _dynamoDb;
        private readonly IDynamoDBContext _context;

        private const string TableNameDailyPrice = "DailyInvestmentToolPrices";
        private const string TableNamePriceTimeSeries = "PriceTimeSeries";

        public Repository(IAmazonDynamoDB dynamoDb, IDynamoDBContext context)
        {
            _dynamoDb = dynamoDb;
            _context = context;
        }
        public async Task SavePriceAsync(T currentPrice)
        {
            try
            {
                LambdaLogger.Log("Saving current price...");
                /*
                 * 1. Find the document with price date and investment tool
                 * 2. Update Today Price
                 * 3. Insert new price
                 * 4. If search is unsuccessful, create new document
                 */
                var priceId = currentPrice.ToDynamoDbDateId();
                LambdaLogger.Log("priceID = " + priceId);

                var dailyPrice = await _context.LoadAsync<DailyInvestmentToolPrices<T>>(priceId);

                if (dailyPrice == null)
                {
                    LambdaLogger.Log("Could not find the price. Adding first time for the new day...");
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
                    LambdaLogger.Log("New date is successfully saved");
                }
                else
                {
                    LambdaLogger.Log("Found daily price. Updating the item...");
                    dailyPrice.Price = currentPrice;
                    dailyPrice.LastUpdateTime = DateTime.Now.ToDynamoDbDateTime();
                    await _context.SaveAsync(dailyPrice);
                    LambdaLogger.Log("New date is successfully saved");
                }
                var priceTimeSeries = new PriceTimeSeries<T>
                {
                    DailyPriceId = priceId,
                    Id = currentPrice.ToDynamoDbTimeId(),
                    PriceTime = currentPrice.PriceDate.ToDynamoDbDateTime(),
                    Price = currentPrice
                };
                await _context.SaveAsync(priceTimeSeries);
                LambdaLogger.Log("Current price is saved to database");
            }
            catch (Exception e)
            {
                LambdaLogger.Log("Error occured while saving the current foreign price: " + e.Message);
                throw e;
            }
        }
        public void Get()
        {
            
        }
    }
}
