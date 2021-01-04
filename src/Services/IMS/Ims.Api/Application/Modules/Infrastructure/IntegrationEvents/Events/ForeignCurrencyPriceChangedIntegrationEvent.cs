using Ax3.IMS.Infrastructure.EventBus.Events;
using System;

namespace Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Events
{
    public class ForeignCurrencyPriceChangedIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; private set; }
        public DateTime PriceDate { get; private set; }
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public string CurrencyCode { get; private set; }
        public double SalesPrice { get; private set; }
        public double BuyingPrice { get; private set; }
        public double OpeningPrice { get; private set; }
        public double ClosingPrice { get; private set; }
        public double HighestPrice { get; private set; }
        public double LowestPrice { get; private set; }
        public ForeignCurrencyPriceChangedIntegrationEvent(Guid id, DateTime priceDate, int hour, int minute,
            string currencyCode, double salesPrice, double buyingPrice, double openingPrice, double closingPrice,
            double highestPrice, double lowestPrice)
        {
            Id = id;
            PriceDate = priceDate;
            Hour = hour;
            Minute = minute;
            CurrencyCode = currencyCode;
            SalesPrice = salesPrice;
            BuyingPrice = buyingPrice;
            OpeningPrice = openingPrice;
            ClosingPrice = closingPrice;
            HighestPrice = highestPrice;
            LowestPrice = lowestPrice;
        }
    }
}
