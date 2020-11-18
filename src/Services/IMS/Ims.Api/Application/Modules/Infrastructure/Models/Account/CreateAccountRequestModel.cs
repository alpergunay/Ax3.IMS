namespace Ims.Api.Application.Modules.Infrastructure.Models.Account
{
    public class CreateAccountRequestModel
    {
        public string StoreBranchId { get; set; }
        public int AccountTypeId { get; set; }
        public string InvestmentToolId { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
    }
}
