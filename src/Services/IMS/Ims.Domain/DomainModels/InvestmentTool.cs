﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Ax3.IMS.Domain.Types;
using Ims.Domain.Exceptions;

namespace Ims.Domain.DomainModels
{
    public class InvestmentTool : Entity
    {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Symbol { get; set; }
        public int InvestmentToolTypeId { get; private set; }
        public InvestmentToolType InvestmentToolType { get; set; }

        public InvestmentTool(string code, string name, string symbol, int investmentToolTypeId)
        {
            Code = code;
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ImsDomainException(nameof(name));
            InvestmentToolTypeId = investmentToolTypeId;
            Symbol = symbol;
        }

        public void Update(string code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}
