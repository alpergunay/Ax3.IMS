using Ax3.IMS.Infrastructure.EventBus.Abstractions;
using Pricing.Consumer.EventHandling.Events;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PriceProviders.Shared.Abstractions;
using PriceProviders.Shared.Models;

namespace Pricing.Consumer.EventHandling.EventHandlers
{
    public class InvestmentToolPriceChangedIntegrationEventHandler : IIntegrationEventHandler<InvestmentToolPriceChangedIntegrationEvent>
    {
        private readonly ILogger<InvestmentToolPriceChangedIntegrationEventHandler> _logger;
        private readonly IRepository<InvestmentToolPrice> _repository;
        public InvestmentToolPriceChangedIntegrationEventHandler(
            ILogger<InvestmentToolPriceChangedIntegrationEventHandler> logger,
            IRepository<InvestmentToolPrice> repository)
        {
            _logger = logger;
            _repository = repository;
        }
        public Task Handle(InvestmentToolPriceChangedIntegrationEvent @event)
        {
            _logger.LogInformation($"Handling {nameof(InvestmentToolPriceChangedIntegrationEvent)} for {@event.InvestmentTool.Code}...");
            var investmentToolPrice = new InvestmentToolPrice(@event.InvestmentTool.Key, @event.PriceDate, @event.InvestmentTool, @event.SalesPrice, @event.BuyingPrice);
            return _repository.SaveAsync(investmentToolPrice);
        }
    }
}
