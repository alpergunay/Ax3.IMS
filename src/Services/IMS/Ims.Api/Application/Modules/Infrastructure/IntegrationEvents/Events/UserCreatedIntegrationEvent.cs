using Europcar.RentoCloud.EventBus.Events;
using System;

namespace Web.API.Application.Modules.Infrastructure.IntegrationEvents.Events
{
    public class UserCreatedIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RequestId { get; set; }

        public UserCreatedIntegrationEvent(Guid id, string username, string name, string surname, string email, string password, Guid requestId)
        {
            UserId = id;
            Username = username;
            Name = name;
            Surname = surname;
            RequestId = requestId;
            Email = email;
            Password = password;
        }
    }
}
