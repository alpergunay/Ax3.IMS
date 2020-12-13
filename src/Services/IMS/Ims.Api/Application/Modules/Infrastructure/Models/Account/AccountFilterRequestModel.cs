using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models.Account
{
    public class AccountFilterRequestModel : BaseFilterRequestModel<string>
    {
        public string InvestmentToolId { get; set; }
    }
}
