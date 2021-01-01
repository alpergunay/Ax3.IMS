using System;
using CurrencyPriceProvider.Abstractions;

namespace CurrencyPriceProvider.Models
{
    public class InvestmentToolPrice : IEntity
    {
        public DateTime PriceDate { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public InvestmentTool InvestmentTool { get; set; }
        public double SalesPrice { get; set; }
        public double BuyingPrice { get; set; }

        public InvestmentToolPrice()
        {
            
        }
    }
}
