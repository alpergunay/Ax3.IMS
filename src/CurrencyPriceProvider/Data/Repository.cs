using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.Core;
using CurrencyPriceProvider.Abstractions;
using CurrencyPriceProvider.Models;

namespace CurrencyPriceProvider.Data
{
    public class Repository : IRepository
    {
        private readonly IAmazonDynamoDB _dynamoDb;
        private readonly IDynamoDBContext _context;

        private readonly string tableName = "DailyInvestmentToolPrices";
        public Repository(IAmazonDynamoDB dynamoDb, IDynamoDBContext context)
        {
            _dynamoDb = dynamoDb;
            _context = context;
        }
        public async Task Put(InvestmentToolPrice currentPrice)
        {
            try
            {
                LambdaLogger.Log("Saving current price...");
                var investmentTool = new InvestmentTool("USD", "Dollar");
                var todayCurrentPrice = new DailyInvestmentToolPrices<InvestmentToolPrice>
                {
                    PriceDate = DateTime.Today.ToString(),
                    InvestmentTool = investmentTool,
                    TodayPrice = currentPrice,
                    Day = DateTime.Now.Day,
                    Month = DateTime.Now.Month,
                    Id = Guid.NewGuid().ToString(),
                    Prices = { currentPrice },
                    WeekNumber = ISOWeek.GetWeekOfYear(DateTime.Now),
                    Year = DateTime.Now.Year
                };
                await _context.SaveAsync(todayCurrentPrice);
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
