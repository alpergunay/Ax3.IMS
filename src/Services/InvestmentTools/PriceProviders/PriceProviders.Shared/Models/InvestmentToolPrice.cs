using System;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using PriceProviders.Shared.Abstractions;

namespace PriceProviders.Shared.Models
{
    [DynamoDBTable("InvestmentToolPrice")]
    public class InvestmentToolPrice : IEntity
    {
        [DynamoDBProperty("priceDate")]
        public DateTime PriceDate { get; set; }
        [DynamoDBProperty("hour")]
        public int Hour { get; set; }
        [DynamoDBProperty("minute")]
        public int Minute { get; set; }
        [DynamoDBProperty("investmentTool")]
        public InvestmentTool InvestmentTool { get; set; }
        [DynamoDBProperty("salesPrice")]
        public double SalesPrice { get; set; }
        [DynamoDBProperty("buyingPrice")]
        public double BuyingPrice { get; set; }

        public InvestmentToolPrice()
        {
            
        }
    }
}
