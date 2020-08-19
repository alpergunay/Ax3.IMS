using System;
using System.Collections.Generic;
using System.Text;

namespace Ims.Domain.DomainModels
{
    public class InvestmentToolPrice
    {
        public DateTime PriceDate { get; set; }
        public InvestmentTool InvestmentTool { get; set; }
        public double SalesPrice { get; set; }
        public double BuyingPrice { get; set; }

        public InvestmentToolPrice(DateTime priceDate,
            InvestmentTool investmentTool,
            double salesPrice,
            double buyingPrice)
        {
            PriceDate = priceDate;
            this.InvestmentTool = investmentTool;
            SalesPrice = salesPrice;
            BuyingPrice = buyingPrice;
        }
    }
}
