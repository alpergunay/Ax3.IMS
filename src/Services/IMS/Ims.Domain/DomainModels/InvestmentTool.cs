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
        private string _code;
        private string _name;
        private int _investmentToolTypeId;
        public InvestmentToolType InvestmentToolType { get; set; }

        public InvestmentTool(string code, string name, int investmentToolTypeId)
        {
            _code = code;
            _name = !string.IsNullOrWhiteSpace(name) ? name : throw new ImsDomainException(nameof(name));
            _investmentToolTypeId = investmentToolTypeId;
        }
    }
}
