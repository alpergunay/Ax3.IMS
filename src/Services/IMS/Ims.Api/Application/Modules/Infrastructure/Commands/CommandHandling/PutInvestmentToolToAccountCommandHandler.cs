using System;
using Ims.Api.Application.Modules.Infrastructure.IntegrationEvents;
using Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Events;
using Ims.Domain.DomainModels;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Commands.CommandHandling
{
    public class PutInvestmentToolToAccountCommandHandler : IRequestHandler<PutInvestmentToolToAccountCommand, bool>
    {
        private readonly IAccountTransactionRepository _accountTransactionRepository;
        private readonly IImsIntegrationEventService _imsIntegrationEventService;
        private readonly ILogger<PutInvestmentToolToAccountCommandHandler> _logger;

        public PutInvestmentToolToAccountCommandHandler(IAccountTransactionRepository accountTransactionRepository,
            IImsIntegrationEventService imsIntegrationEventService,
            ILogger<PutInvestmentToolToAccountCommandHandler> logger)
        {
            _accountTransactionRepository = accountTransactionRepository;
            _imsIntegrationEventService = imsIntegrationEventService;
            _logger = logger;
        }
        public async Task<bool> Handle(PutInvestmentToolToAccountCommand request, CancellationToken cancellationToken)
        {
            //Notify for reporting
            var accountBalanceChangedIntegrationEvent = new AccountBalanceChangedIntegrationEvent(Guid.Parse(request.AccountId));
            await _imsIntegrationEventService.AddAndSaveEventAsync(accountBalanceChangedIntegrationEvent);
            
            var transaction = new AccountTransaction(Guid.Parse(request.AccountId), request.TransactionTypeId, request.TransactionDate, request.Amount, request.Rate ?? 1);

            _logger.LogInformation("----- Creating Transaction - Transaction: {@Transaction}", transaction);
            _accountTransactionRepository.Add(transaction);
            return await _accountTransactionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}
