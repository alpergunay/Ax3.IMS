using FluentValidation;
using Ims.Api.Application.Modules.Infrastructure.Commands;

namespace Ims.Api.Application.Modules.Infrastructure.Validations
{
    public class SellInvestmentToolCommandValidator : AbstractValidator<SellInvestmentToolCommand>
    {
        public SellInvestmentToolCommandValidator()
        {
            RuleFor(command => command.SourceAccountId).SetValidator(new GuidValidator())
                .NotEmpty().WithMessage("Invalid source account");

            RuleFor(command => command.DestinationAccountId).SetValidator(new GuidValidator())
                .NotEmpty().WithMessage("Invalid destination account");

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
