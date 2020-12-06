using Ims.Api.Application.Modules.Infrastructure.IntegrationEvents;
using Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Events;
using Ims.Domain.DomainModels;
using Ims.Infrastructure.Idempotency;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Commands.CommandHandling
{
    public class WithdrawInvestmentToolFromAccountCommandHandler : IRequestHandler<WithdrawInvestmentToolFromAccountCommand, bool>
    {
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IImsIntegrationEventService _imsIntegrationEventService;
        private readonly ILogger<WithdrawInvestmentToolFromAccountCommandHandler> _logger;

        public WithdrawInvestmentToolFromAccountCommandHandler(IAccountTransactionRepository accountTransactionRepository,
            IAccountRepository accountRepository,
            IImsIntegrationEventService imsIntegrationEventService,
            ILogger<WithdrawInvestmentToolFromAccountCommandHandler> logger)
        {
            _accountTransactionRepository = accountTransactionRepository;
            _accountRepository = accountRepository;
            _imsIntegrationEventService = imsIntegrationEventService;
            _logger = logger;
        }
        public async Task<bool> Handle(WithdrawInvestmentToolFromAccountCommand request, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.FindOrDefaultAsync(Guid.Parse(request.AccountId));
            if (account == null || !account.CheckBalanceForWithdraw(request.Amount))
                return false;
            //Notify for reporting
            var accountBalanceChangedIntegrationEvent = new AccountBalanceChangedIntegrationEvent(Guid.Parse(request.AccountId));
            await _imsIntegrationEventService.AddAndSaveEventAsync(accountBalanceChangedIntegrationEvent);

            var transaction = new AccountTransaction(Guid.Parse(request.AccountId), request.TransactionTypeId, request.TransactionDate, request.Amount, request.Rate ?? 1);

            _logger.LogInformation("----- Creating Transaction - Transaction: {@Transaction}", transaction);
            _accountTransactionRepository.Add(transaction);
            return await _accountTransactionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
    // Use for Idempotency in Command process
    public class WithdrawIdentifiedInvestmentToolFromAccountCommandHandler : IdentifiedCommandHandler<WithdrawInvestmentToolFromAccountCommand, bool>
    {
        public WithdrawIdentifiedInvestmentToolFromAccountCommandHandler(
            IMediator mediator,
            IRequestManager requestManager,
            ILogger<IdentifiedCommandHandler<WithdrawInvestmentToolFromAccountCommand, bool>> logger)
            : base(mediator, requestManager, logger)
        {
        }

        protected override bool CreateResultForDuplicateRequest()
        {
            return true;                // Ignore duplicate requests for processing order.
        }
    }
}
