using System;

namespace Ims.Api.Application.Modules.Infrastructure.Models.Account
{
    public class AccountResponseModel : BaseResponseModel
    {
        public Guid UserId { get; set; }
        public Guid StoreBranchId { get; set; }
        public string StoreBranchName { get; set; }
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public Guid AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }
        public Guid InvestmentToolId { get; set; }
        public string InvestmentToolName { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
    }
}
