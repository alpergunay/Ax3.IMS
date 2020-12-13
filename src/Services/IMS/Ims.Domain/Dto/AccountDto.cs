namespace Ims.Domain.Dto
{
    public class AccountDto
    {
        public int AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }
        public string InvestmentToolId { get; set; }
        public string InvestmentToolName { get; set; }
        public string InvestmentToolCode { get; set; }
        public string AccountName { get; set; }
        public string Id { get; set; }
        public double Balance { get; set; }
    }
}
