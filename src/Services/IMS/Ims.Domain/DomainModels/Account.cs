﻿using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class Account : Entity
    {
        private Guid _userId;
        public User User { get; set; }

        private Guid _storeBranchId;
        public StoreBranch StoreBranch { get; set; }
        private Guid _accountTypeId;
        public AccountType AccountType { get; set; }
        private Guid _investmentToolId;
        public InvestmentTool InvestmentTool { get; set; }
        private string _accountNo;

        public Account(Guid userId, Guid storeBranchId, Guid accountTypeId, Guid investmentToolId, string accountNo)
        {
            _userId = userId;
            _storeBranchId = storeBranchId;
            _accountTypeId = accountTypeId;
            _investmentToolId = investmentToolId;
            _accountNo = accountNo;
        }
    }
}