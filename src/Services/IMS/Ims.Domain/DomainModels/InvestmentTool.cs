using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Ax3.IMS.Domain.Types;
using Ims.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Ims.Domain.DomainModels
{
    public class InvestmentTool : Entity
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public int InvestmentToolTypeId { get; private set; }
        public InvestmentToolType InvestmentToolType { get; set; }

        public InvestmentTool(string code, string name, int investmentToolTypeId)
        {
            Code = code;
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ImsDomainException(nameof(name));
            InvestmentToolTypeId = investmentToolTypeId;
        }

        public void Update(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
