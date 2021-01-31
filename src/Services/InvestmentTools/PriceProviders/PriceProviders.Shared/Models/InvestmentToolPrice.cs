using System;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Util;
using PriceProviders.Shared.Abstractions;

namespace PriceProviders.Shared.Models
{
    [DynamoDBTable("InvestmentToolPrices")]
    public class InvestmentToolPrice : IEntity
    {
        [DynamoDBHashKey("key")]
        public string Key { get; set; }
        [DynamoDBRangeKey("priceDate")]
        public string PriceDate { get; set; }
        [DynamoDBProperty("investmentTool")]
        public InvestmentTool InvestmentTool { get; set; }
        [DynamoDBProperty("salesPrice")]
        public double SalesPrice { get; set; }
        [DynamoDBProperty("buyingPrice")]
        public double BuyingPrice { get; set; }

        public InvestmentToolPrice(string key, DateTime priceDate, InvestmentTool investmentTool, double salesPrice,
            double buyingPrice)
        {
            Key = key;
            PriceDate = priceDate.ToString(AWSSDKUtils.ISO8601DateFormat);
            InvestmentTool = investmentTool;
            SalesPrice = salesPrice;
            BuyingPrice = buyingPrice;
        }

        public InvestmentToolPrice()
        {
            
        }

    }
}
