using System;

namespace Ims.Api.Application.Modules.Infrastructure.Models.Account
{
    public class AccountLookupResponseModel
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; }
        public int AccountTypeId { get; set; }
        public int InvestmentToolTypeId { get; set; }
        public string InvestmentToolTypeName { get; set; }

    }
}
