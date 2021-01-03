using Ax3.IMS.Domain.Types;
using System;
using Ax3.IMS.Infrastructure.Core.Exception;

namespace Ims.Domain.DomainModels
{
    public class InvestmentToolPrice : Entity
    {
        public DateTime PriceDate { get; private set; }
        public Guid InvestmentToolId { get; private set; }
        public InvestmentTool InvestmentTool { get; set; }
        public double SalesPrice { get; protected set; }
        public double BuyingPrice { get; protected set; }


        public InvestmentToolPrice(DateTime priceDate,
            Guid investmentToolId,
            double salesPrice,
            double buyingPrice)
        {
            PriceDate = priceDate;
            InvestmentToolId = investmentToolId;
            SalesPrice = salesPrice;
            BuyingPrice = buyingPrice;
        }

        public void UpdatePrices(double salesPrice, double buyingPrice)
        {
            if(salesPrice <=0 || buyingPrice<=0)
                throw new DomainException("Sales Price or Buying Price cannot be less than 0");

            SalesPrice = salesPrice;
            BuyingPrice = buyingPrice;
        }
    }
}
