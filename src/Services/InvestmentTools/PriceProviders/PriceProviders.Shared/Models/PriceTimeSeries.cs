using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.DataModel;

namespace PriceProviders.Shared.Models
{
    [DynamoDBTable("PriceTimeSeries")]
    public class PriceTimeSeries<T> where T:InvestmentToolPrice
    {
        [DynamoDBHashKey("id")]
        public string Id { get; set; }
        [DynamoDBProperty("priceTime")] 
        public string PriceTime { get; set; }
        [DynamoDBProperty("price")]
        public T Price { get; set; }
        [DynamoDBProperty("dailyPriceId")]
        public string DailyPriceId { get; set; }
    }
}
