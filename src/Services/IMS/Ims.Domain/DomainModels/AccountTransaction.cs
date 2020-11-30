using System;
using System.Collections.Generic;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class AccountTransaction : Entity
    {
        public Guid AccountId { get; private set; }
        public Account Account { get; set; }
        public int TransactionTypeId { get; private set; }
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; private set; }
        public double Amount { get; private set; }
        public double Rate { get; private set; }

        public AccountTransaction(Guid accountId, int transactionTypeId, DateTime transactionDate, double amount, double rate)
        {
            AccountId = accountId;
            TransactionTypeId = transactionTypeId;
            TransactionDate = transactionDate;
            Amount = amount;
            Rate = rate;
        }
    }
}
