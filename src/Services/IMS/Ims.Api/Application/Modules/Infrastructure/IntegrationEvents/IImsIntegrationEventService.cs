using System;
using System.Threading.Tasks;
using Ax3.IMS.Infrastructure.EventBus.Events;

namespace Ims.Api.Application.Modules.Infrastructure.IntegrationEvents
{
    public interface IImsIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);

        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
}