using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PriceProviders.Shared.Models
{
    [DynamoDBTable("DailyInvestmentToolPrices")]
    public class DailyInvestmentToolPrices<T> where T:InvestmentToolPrice
    {
        [DynamoDBHashKey("id")]
        public string Id { get; set; }
        [DynamoDBProperty("priceDate")]
        public string PriceDate { get; set; }
        [DynamoDBProperty("year")]
        public int Year { get; set; }
        [DynamoDBProperty("month")]
        public int Month { get; set; }
        [DynamoDBProperty("weekNumber")]
        public int WeekNumber { get; set; }
        [DynamoDBProperty("day")]
        public int Day { get; set; }
        [DynamoDBProperty("investmentToolCode")]
        public string InvestmentToolCode { get; set; }
        [DynamoDBProperty("investmentToolName")]
        public string InvestmentToolName { get; set; }
        [DynamoDBProperty("lastUpdateTime")]
        public string LastUpdateTime { get; set; }
        [DynamoDBProperty("price")]
        public T Price { get; set; }

        public DailyInvestmentToolPrices()
        {
        }
        public void SetPriceDate(DateTime priceDate)
        {
            PriceDate = priceDate.Date.ToString();
            Year = priceDate.Year;
            Month = priceDate.Month;
            WeekNumber = ISOWeek.GetWeekOfYear(priceDate);
            Day = priceDate.Day;
        }

    }
}
