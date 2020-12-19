using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Ims.Api.Application.Modules.Infrastructure.Commands
{
    public class SellInvestmentToolCommand : IRequest<bool>
    {
        public string SourceAccountId { get; set; }
        public DateTime TransactionDate { get; set; }
        public double? Rate { get; set; }
        public double Amount { get; set; }
        public string DestinationAccountId { get; set; }
        public string Description { get; set; }

        public SellInvestmentToolCommand(string sourceAccountId, DateTime transactionDate,
            double? rate, double amount, string destinationAccountId, string description)
        {
            SourceAccountId = sourceAccountId;
            TransactionDate = transactionDate;
            Rate = rate;
            Amount = amount;
            DestinationAccountId = destinationAccountId;
            Description = description;
        }
    }
}