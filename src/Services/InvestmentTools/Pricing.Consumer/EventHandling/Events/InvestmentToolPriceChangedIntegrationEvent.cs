using Ax3.IMS.Infrastructure.EventBus.Events;
using PriceProviders.Shared.Models;

namespace Pricing.Consumer.EventHandling.Events
{
    public class InvestmentToolPriceChangedIntegrationEvent : IntegrationEvent
    {
        public InvestmentTool InvestmentTool { get; set; }
        public double BuyingPrice { get; set; }
        public double SellingPrice { get; set; }

        public InvestmentToolPriceChangedIntegrationEvent(InvestmentTool investmentTool, double buyingPrice,
            double sellingPrice)
        {
            InvestmentTool = investmentTool;
            BuyingPrice = buyingPrice;
            SellingPrice = sellingPrice;
        }
    }
}
