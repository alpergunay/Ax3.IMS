using System;
using System.Collections.Generic;

namespace Ims.Domain.DomainModels
{
    public class CountryInvestmentTool
    {
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public List<InvestmentTool> InvestmentTools { get; set; }
    }
}
