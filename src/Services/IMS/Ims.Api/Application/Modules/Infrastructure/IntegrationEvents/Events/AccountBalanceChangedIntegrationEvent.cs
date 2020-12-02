using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ax3.IMS.Infrastructure.EventBus.Events;

namespace Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Events
{
    public class AccountBalanceChangedIntegrationEvent : IntegrationEvent
    {
        public Guid AccountId { get; set; }

        public AccountBalanceChangedIntegrationEvent(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
