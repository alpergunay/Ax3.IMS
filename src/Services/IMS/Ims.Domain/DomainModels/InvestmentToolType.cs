using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class InvestmentToolType : Enumeration
    {
        public static InvestmentToolType ForeignExchange = new InvestmentToolType(1, "FE", "Foreign Exchange");
        public static InvestmentToolType Stock = new InvestmentToolType(2, "ST", "Stock");
        public static InvestmentToolType LocalCurrency = new InvestmentToolType(3, "LC", "Local Currency");
        public static InvestmentToolType Emtia = new InvestmentToolType(4, "EM", "Emtia");
        public static InvestmentToolType Fund = new InvestmentToolType(5, "FU", "Fund");
        public InvestmentToolType(int enumId, string code, string name) 
            : base(enumId, code, name)
        {
            
        }
    }
}
