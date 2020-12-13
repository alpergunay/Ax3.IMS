using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ax3.IMS.Domain.Types;

namespace Ims.Domain.DomainModels
{
    public class Account : Entity
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public User User { get; set; }
        public Guid StoreBranchId { get; private set; }
        public StoreBranch StoreBranch { get; set; }
        public int AccountTypeId { get; private set; }
        public AccountType AccountType { get; set; }
        public Guid InvestmentToolId { get; private set; }
        public InvestmentTool InvestmentTool { get; set; }
        public string AccountNo { get; private set; }
        public string AccountName { get; private set; }
        public virtual List<AccountTransaction> AccountTransactions { get; set; }

        public Account(Guid storeBranchId, int accountTypeId, Guid investmentToolId, string accountNo,
            string accountName)
        {
            StoreBranchId = storeBranchId;
            AccountTypeId = accountTypeId;
            InvestmentToolId = investmentToolId;
            AccountNo = accountNo;
            AccountName = accountName;
        }

        public void Update(string accountNo,
            string accountName)
        {
            AccountNo = accountNo;
            AccountName = accountName;
        }
        public double GetBalance()
        {
            if (AccountTransactions == null) 
                return 0;
            var plus = AccountTransactions.Where(at => at.TransactionType.DirectionTypeId == DirectionType.Positive.EnumId)
                .Sum(s => s.Amount);
            var minus =  AccountTransactions.Where(at => at.TransactionType.DirectionTypeId == DirectionType.Negative.EnumId)
                .Sum(s => s.Amount);

            return plus - minus;
        }
        public bool CheckBalanceForWithdraw(double withdrawAmount)
        {
            return withdrawAmount <= GetBalance();
        }
    }
}
