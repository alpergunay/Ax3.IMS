using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Ims.Api.Application.Modules.Infrastructure.Commands;

namespace Ims.Api.Application.Modules.Infrastructure.Validations
{
    public class BuyInvestmentToolCommandValidator : AbstractValidator<BuyInvestmentToolCommand>
    {
        public BuyInvestmentToolCommandValidator()
        {
            RuleFor(command => command.SourceAccountId).SetValidator(new GuidValidator())
                .NotEmpty().WithMessage("Source account cannot be empty");

            RuleFor(command => command.DestinationAccountId).SetValidator(new GuidValidator())
                .NotEmpty().WithMessage("Destination account cannot be empty");

            RuleFor(command => command.Amount)
                .NotEmpty().WithMessage("Amount cannot be empty")
                .GreaterThan(0).WithMessage("Amount must be greater than 0");

            RuleFor(command => command.Rate)
                .GreaterThan(0).WithMessage("Rate must be greater than 0");

            RuleFor(command => command.TransactionDate)
                .NotEmpty().WithMessage("Transaction Date cannot be empty");
        }
    }
}
