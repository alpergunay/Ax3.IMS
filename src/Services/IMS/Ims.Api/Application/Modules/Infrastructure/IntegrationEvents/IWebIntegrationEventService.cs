using Europcar.RentoCloud.EventBus.Events;
using System;
using System.Threading.Tasks;

namespace Web.API.Application.Modules.Infrastructure.IntegrationEvents
{
    public interface IWebIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);

        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
}