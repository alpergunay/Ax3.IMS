using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models.Account
{
    public class UpdateAccountRequestModel
    {
        public string Id { get; set; }
        public string StoreBranchId { get; set; }
        public int AccountTypeId { get; set; }
        public string InvestmentToolId { get; set; }
        public string AccountNo { get; set; }
        public string AccountName { get; set; }
    }
}
