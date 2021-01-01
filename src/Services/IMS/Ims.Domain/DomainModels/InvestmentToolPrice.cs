using Ax3.IMS.Domain.Types;
using System;

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
    }
}
