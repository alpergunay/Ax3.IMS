using System.Threading.Tasks;
using Ax3.IMS.Infrastructure.EventBus.Abstractions;
using Castle.Core.Logging;
using Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Events;
using Ims.Domain.DomainModels;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Handlers
{
    public class UserCreatedIntegrationEventHandler : IIntegrationEventHandler<UserCreatedIntegrationEvent>
    {
        private readonly ILogger<UserCreatedIntegrationEventHandler> _logger;
        private readonly IUserRepository _userRepository;
        public UserCreatedIntegrationEventHandler(ILogger<UserCreatedIntegrationEventHandler> logger,
            IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task Handle(UserCreatedIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);
                var user = new User(@event.UserId, @event.UserName, @event.Name, @event.Surname, null, string.Empty,
                    @event.Email, null, null);
                _userRepository.Add(user);
                await _userRepository.UnitOfWork.SaveEntitiesAsync();
            }
        }
    }
}
