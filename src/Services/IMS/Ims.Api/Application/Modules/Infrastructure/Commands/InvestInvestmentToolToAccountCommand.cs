using MediatR;
using System;

namespace Ims.Api.Application.Modules.Infrastructure.Commands
{
    public class InvestInvestmentToolToAccountCommand : IRequest<bool>
    {
        public string AccountId { get; private set; }
        public int TransactionTypeId { get; private set; }
        public double? Rate { get; private set; }
        public double Amount { get; private set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; private set; }

        public InvestInvestmentToolToAccountCommand(string accountId, int transactionTypeId, double rate, double amount, string description)
        {
            AccountId = accountId;
            TransactionTypeId = transactionTypeId;
            Rate = rate;
            Amount = amount;
            Description = description;
        }
    }
}
