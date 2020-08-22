using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class AccountTransaction : Entity
    {
        private Guid _accountId;
        public Account Account { get; set; }
        private int _transactionTypeId;
        public TransactionType TransactionType { get; set; }
        private DateTime _transactionDate;
        private double _amount;
        private double _rate;

        public AccountTransaction(Guid accountId, int transactionTypeId, DateTime transactionDate, double amount, double rate)
        {
            _accountId = accountId;
            _transactionTypeId = transactionTypeId;
            _transactionDate = transactionDate;
            _amount = amount;
            _rate = rate;
        }
    }
}
