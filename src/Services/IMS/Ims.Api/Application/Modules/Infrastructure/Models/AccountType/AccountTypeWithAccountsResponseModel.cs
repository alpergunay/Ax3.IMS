using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ims.Api.Application.Modules.Infrastructure.Models.Account;

namespace Ims.Api.Application.Modules.Infrastructure.Models.AccountType
{
    public class AccountTypeWithAccountsResponseModel
    {
        public int Id { get; set; }
        public string AccountTypeName { get; set; }
        public List<AccountLookupResponseModel> Accounts { get; set; }
    }
}
