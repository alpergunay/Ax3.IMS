using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace CurrencyPriceProvider.Models
{
    [DynamoDBTable("DailyInvestmentToolPrices")]
    public class DailyInvestmentToolPrices<T> 
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
        [DynamoDBProperty("todayPrice")]
        public T TodayPrice { get; set; }
        [DynamoDBProperty("investmentTool")]
        public InvestmentTool InvestmentTool { get; set; }
        [DynamoDBProperty("prices")]
        public List<T> Prices { get; private set; }

        

        public DailyInvestmentToolPrices()
        {
            Prices = new List<T>();
        }

        public void AddPrice(T price)
        {
            Prices?.Add(price);
            //TODO Add exception for the case of empty Prices list.
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
