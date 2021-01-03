using Ax3.IMS.Infrastructure.EventBus.Abstractions;
using Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Events;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Handlers
{
    public class ForeignCurrencyPriceChangedIntegrationEventHandler : IIntegrationEventHandler<ForeignCurrencyPriceChangedIntegrationEvent>
    {
        private readonly ILogger<ForeignCurrencyPriceChangedIntegrationEventHandler> _logger;

        public ForeignCurrencyPriceChangedIntegrationEventHandler(ILogger<ForeignCurrencyPriceChangedIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(ForeignCurrencyPriceChangedIntegrationEvent @event)
        {
            _logger.LogInformation("Handling event {eventName}", nameof(@event));
            return null;
        }
    }
}
