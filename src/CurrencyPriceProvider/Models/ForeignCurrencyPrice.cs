using System;
using Amazon.DynamoDBv2.DataModel;

namespace CurrencyPriceProvider.Models
{
    public class ForeignCurrencyPrice : InvestmentToolPrice
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }
        [DynamoDBProperty]
        public string CurrencyCode { get; set; }
        [DynamoDBProperty]
        public double OpeningPrice { get; private set; }
        [DynamoDBProperty]
        public double ClosingPrice { get; private set; }
        [DynamoDBProperty]
        public double HighestPrice { get; private set; }
        [DynamoDBProperty]
        public double LowestPrice { get; private set; }

        public ForeignCurrencyPrice()
        {
            
        }
    }
}
