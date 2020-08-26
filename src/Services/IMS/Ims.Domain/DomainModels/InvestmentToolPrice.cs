using Ax3.IMS.Domain.Types;
using System;

namespace Ims.Domain.DomainModels
{
    public class InvestmentToolPrice : Entity
    {
        private DateTime _priceDate;
        private Guid _investmentToolId;
        public InvestmentTool InvestmentTool { get; set; }
        private double _salesPrice;
        private double _buyingPrice;
        
        public InvestmentToolPrice(DateTime priceDate,
            Guid investmentToolId,
            double salesPrice,
            double buyingPrice)
        {
            _priceDate = priceDate;
            _investmentToolId = investmentToolId;
            _salesPrice = salesPrice;
            _buyingPrice = buyingPrice;
        }
    }
}
