using System;
using Ax3.IMS.Infrastructure.EventBus.Events;

namespace Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Events
{
    public class UserCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }

        public UserCreatedIntegrationEvent(Guid userId, string userName, string name, string surname, string email)
        {
            UserId = userId;
            UserName = userName;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
