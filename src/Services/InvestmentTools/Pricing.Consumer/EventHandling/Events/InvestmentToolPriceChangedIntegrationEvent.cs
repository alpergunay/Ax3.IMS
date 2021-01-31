using System;
using Ax3.IMS.Infrastructure.EventBus.Events;
using PriceProviders.Shared.Models;

namespace Pricing.Consumer.EventHandling.Events
{
    public class InvestmentToolPriceChangedIntegrationEvent : IntegrationEvent
    {
        public InvestmentTool InvestmentTool { get; set; }
        public DateTime PriceDate { get; set; }
        public double BuyingPrice { get; set; }
        public double SalesPrice { get; set; }

        public InvestmentToolPriceChangedIntegrationEvent(InvestmentTool investmentTool, DateTime priceDate, double buyingPrice,
            double salesPrice)
        {
            InvestmentTool = investmentTool;
            BuyingPrice = buyingPrice;
            SalesPrice = salesPrice;
            PriceDate = priceDate;
        }
    }
}
