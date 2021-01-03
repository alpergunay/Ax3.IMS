using System;
using System.Collections.Generic;
using System.Text;
using Amazon.DynamoDBv2.DataModel;

namespace PriceProviders.Shared.Models
{
    [DynamoDBTable("GoldPrice")]
    public class GoldPrice : InvestmentToolPrice
    {
        [DynamoDBIgnore]
        public Guid Id { get; set; }
        [DynamoDBProperty("goldCode")]
        public string CurrencyCode { get; set; }
        [DynamoDBProperty("openingPrice")]
        public double OpeningPrice { get; private set; }
        [DynamoDBProperty("closingPrice")]
        public double ClosingPrice { get; private set; }
        [DynamoDBProperty("highestPrice")]
        public double HighestPrice { get; private set; }
        [DynamoDBProperty("lowestPrice")]
        public double LowestPrice { get; private set; }

        public GoldPrice()
        {

        }
    }
}
