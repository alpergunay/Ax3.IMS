using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ims.Api.Application.Modules.Infrastructure.IntegrationEvents;
using Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Events;
using Ims.Domain.DomainModels;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Writers;

namespace Ims.Api.Application.Modules.Infrastructure.Commands.CommandHandling
{
    public class BuyInvestmentToolCommandHandler : IRequestHandler<BuyInvestmentToolCommand, bool>
    {
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IImsIntegrationEventService _imsIntegrationEventService;
        private readonly ILogger<BuyInvestmentToolCommandHandler> _logger;

        public BuyInvestmentToolCommandHandler(IAccountTransactionRepository accountTransactionRepository,
            IImsIntegrationEventService imsIntegrationEventService,
            ILogger<BuyInvestmentToolCommandHandler> logger,
            IAccountRepository accountRepository)
        {
            _accountTransactionRepository = accountTransactionRepository;
            _imsIntegrationEventService = imsIntegrationEventService;
            _logger = logger;
            _accountRepository = accountRepository;
        }
        public async Task<bool> Handle(BuyInvestmentToolCommand request, CancellationToken cancellationToken)
        {
            //Start source account process
            var sourceAccount = await _accountRepository.FindOrDefaultAsync(Guid.Parse(request.SourceAccountId));

            if (sourceAccount == null || !sourceAccount.CheckBalanceForWithdraw(request.Amount * request.Rate ?? 1))
                return false;
            
            var accountBalanceChangedIntegrationEvent = new AccountBalanceChangedIntegrationEvent();
            accountBalanceChangedIntegrationEvent.EffectedAccountIds.Add(Guid.Parse(request.SourceAccountId));

            var transactionForSourceAccount = new AccountTransaction(Guid.Parse(request.SourceAccountId),
                TransactionType.PullInvestmentToolFromAccount.EnumId, request.TransactionDate, request.Amount * request.Rate ?? 1,
                request.Rate ?? 1);
            _logger.LogInformation("----- Creating Transaction - Transaction: {@Transaction}", transactionForSourceAccount);
            _accountTransactionRepository.Add(transactionForSourceAccount);

            //Start destination account process
            var destinationAccount = await _accountRepository.FindOrDefaultAsync(Guid.Parse(request.DestinationAccountId));
            if (destinationAccount == null)
                return false;

            accountBalanceChangedIntegrationEvent.EffectedAccountIds.Add(Guid.Parse(request.DestinationAccountId));
            await _imsIntegrationEventService.AddAndSaveEventAsync(accountBalanceChangedIntegrationEvent);

            var transactionForDestinationAccount = new AccountTransaction(Guid.Parse(request.DestinationAccountId),
                TransactionType.BuyInvestmentTool.EnumId, request.TransactionDate, request.Amount,
                request.Rate ?? 1);

            _logger.LogInformation("----- Creating Transaction - Transaction: {@Transaction}", transactionForDestinationAccount);
            _accountTransactionRepository.Add(transactionForDestinationAccount);

            return await _accountTransactionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
