using Ax3.IMS.Infrastructure.EventBus.Abstractions;
using Pricing.Consumer.EventHandling.Events;
using System;
using System.Threading.Tasks;

namespace Pricing.Consumer.EventHandling.EventHandlers
{
    public class InvestmentToolPriceChangedIntegrationEventHandler : IIntegrationEventHandler<InvestmentToolPriceChangedIntegrationEvent>
    {
        public InvestmentToolPriceChangedIntegrationEventHandler()
        {
            
        }
        public Task Handle(InvestmentToolPriceChangedIntegrationEvent @event)
        {
            throw new NotImplementedException();
        }
    }
}
