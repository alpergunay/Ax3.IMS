using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class TransactionType : Enumeration
    {
        public int DirectionTypeId { get;  private set; }
        public DirectionType DirectionType { get; set; }

        public static TransactionType PutInvestmentToolToAccount = new TransactionType(1, "PutInvestmentToolToAccount", "Hesaba Koy", 1);
        public static TransactionType PullInvestmentToolFromAccount = new TransactionType(2, "PullInvestmentToolFromAccount", "Hesaptan Çek", 2);
        public static TransactionType BuyInvestmentTool = new TransactionType(3, "BuyInvestmentTool", "Satın Alındı", 1);
        public static TransactionType SellInvestmentTool = new TransactionType(4, "SellInvestmentTool", "Satış Yapıldı", 2);

        public TransactionType(int enumId, string code, string name, int directionTypeId):base(enumId, code, name)
        {
            DirectionTypeId = directionTypeId;
        }
    }
}
