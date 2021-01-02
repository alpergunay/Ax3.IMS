using System;
using Amazon.DynamoDBv2.DataModel;

namespace CurrencyPriceProvider.Models
{
    [DynamoDBTable("ForeignCurrencyPrice")]
    public class ForeignCurrencyPrice : InvestmentToolPrice
    {
        [DynamoDBIgnore]
        public Guid Id { get; set; }
        [DynamoDBProperty("currencyCode")]
        public string CurrencyCode { get; set; }
        [DynamoDBProperty("openingPrice")]
        public double OpeningPrice { get; private set; }
        [DynamoDBProperty("closingPrice")]
        public double ClosingPrice { get; private set; }
        [DynamoDBProperty("highestPrice")]
        public double HighestPrice { get; private set; }
        [DynamoDBProperty("lowestPrice")]
        public double LowestPrice { get; private set; }

        public ForeignCurrencyPrice()
        {
            
        }
    }
}
