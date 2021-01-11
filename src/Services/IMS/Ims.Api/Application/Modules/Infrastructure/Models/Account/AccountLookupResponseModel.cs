namespace Ims.Api.Application.Modules.Infrastructure.Models.Account
{
    public class AccountLookupResponseModel
    {
        public int AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }
        public string StoreName { get; set; }
        public string StoreBranchName { get; set; }
        public string InvestmentToolId { get; set; }
        public string InvestmentToolName { get; set; }
        public string InvestmentToolCode { get; set; }
        public string AccountName { get; set; }
        public string Id { get; set; }
        public double Balance { get; set; }
        public double BalanceInLocalCurrency { get; set; }
    }
}
