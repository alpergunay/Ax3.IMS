using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class Country : Entity
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public Guid? InvestmentToolId { get; set; }
        public InvestmentTool InvestmentTool { get; set; }
        public Country(string code, string name, Guid? investmentToolId)
        {
            Code = code;
            Name = name;
            InvestmentToolId = investmentToolId;
        }
    }
}
