using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Infrastructure.EventBus.Events;

namespace Pricing.BackgroundServices.Events
{
    public class InvestmentToolPriceChangedIntegrationEvent : IntegrationEvent
    {
        public string InvestmentToolCode { get; set; }
        public double BuyingPrice { get; set; }
        public double SellingPrice { get; set; }

        public InvestmentToolPriceChangedIntegrationEvent(string investmentToolCode, double buyingPrice, double sellingPrice)
        {
            InvestmentToolCode = investmentToolCode;
            BuyingPrice = buyingPrice;
            SellingPrice = sellingPrice;
        }
    }
}
