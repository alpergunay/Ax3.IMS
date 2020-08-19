using Europcar.RentoCloud.EventBus.Abstractions;
using Europcar.RentoCloud.EventBus.Events;
using Europcar.RentoCloud.Infrastructure.EventBus.IntegrationEventLogEF;
using Europcar.RentoCloud.Infrastructure.EventBus.IntegrationEventLogEF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Data.Common;
using System.Threading.Tasks;
using Web.Infrastructure;

namespace Web.API.Application.Modules.Infrastructure.IntegrationEvents
{
    public class WebIntegrationEventService : IWebIntegrationEventService
    {
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IEventBus _eventBus;
        private readonly RentoCloudContext _testContext;
        private readonly IIntegrationEventLogService _eventLogService;
        private readonly ILogger<WebIntegrationEventService> _logger;

        public WebIntegrationEventService(IEventBus eventBus,
            RentoCloudContext testContext,
            IntegrationEventLogContext eventLogContext,
            Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory,
            ILogger<WebIntegrationEventService> logger)
        {
            _testContext = testContext ?? throw new ArgumentNullException(nameof(testContext));
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
            _eventLogService = _integrationEventLogServiceFactory(_testContext.Database.GetDbConnection());
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task PublishEventsThroughEventBusAsync(Guid transactionId)
        {
            var pendingLogEvents = await _eventLogService.RetrieveEventLogsPendingToPublishAsync(transactionId);

            foreach (var logEvt in pendingLogEvents)
            {
                _logger.LogInformation("----- Publishing integration event: {IntegrationEventId} from {AppName} - ({@IntegrationEvent})", logEvt.EventId, Program.AppName, logEvt.IntegrationEvent);

                try
                {
                    await _eventLogService.MarkEventAsInProgressAsync(logEvt.EventId);
                    _eventBus.Publish(logEvt.IntegrationEvent);
                    await _eventLogService.MarkEventAsPublishedAsync(logEvt.EventId);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "ERROR publishing integration event: {IntegrationEventId} from {AppName}", logEvt.EventId, Program.AppName);

                    await _eventLogService.MarkEventAsFailedAsync(logEvt.EventId);
                }
            }
        }

        public async Task AddAndSaveEventAsync(IntegrationEvent evt)
        {
            _logger.LogInformation("----- Enqueuing integration event {IntegrationEventId} to repository ({@IntegrationEvent})", evt.Id, evt);

            await _eventLogService.SaveEventAsync(evt, _testContext.GetCurrentTransaction());
        }
    }
}