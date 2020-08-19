using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Ax3.IMS.Domain.Types;
using Ims.Domain.Exceptions;

namespace Ims.Domain.DomainModels
{
    public class InvestmentTool : Entity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public InvestmentToolType InvestmentToolType { get; set; }

        public InvestmentTool(Guid id,
            Guid creator,
            string code,
            string description,
            InvestmentToolType investmentToolType)
        {
            Code = code;
            Description = !string.IsNullOrWhiteSpace(description) ? description : throw new ImsDomainException(nameof(description));
            this.InvestmentToolType = investmentToolType;
        }
    }
}
