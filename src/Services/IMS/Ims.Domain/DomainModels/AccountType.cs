using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class AccountType : Enumeration
    {
        public static AccountType Deposit = new AccountType(1, "VDL", "Vadeli Hesap");
        public static AccountType Draw = new AccountType(2, "VDS", "Vadesiz Hesap");
        public static AccountType Invest = new AccountType(3, "YAT", "Yatırım");

        public AccountType(int enumId, string code, string name)
            : base(enumId, code, name)
        {

        }
    }
}
