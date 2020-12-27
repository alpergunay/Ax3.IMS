using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class InvestmentToolType : Enumeration
    {
        public static InvestmentToolType Currency = new InvestmentToolType(1, "CU", "Currency");
        public static InvestmentToolType Stock = new InvestmentToolType(2, "ST", "Stock");
        public static InvestmentToolType Emtia = new InvestmentToolType(3, "EM", "Emtia");
        public static InvestmentToolType Fund = new InvestmentToolType(4, "FU", "Fund");
        public static InvestmentToolType Gold = new InvestmentToolType(5, "AU", "Gold");
        public InvestmentToolType(int enumId, string code, string name) 
            : base(enumId, code, name)
        {
            
        }
    }
}
