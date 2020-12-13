using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ax3.IMS.Infrastructure.EventBus.Events;

namespace Ims.Api.Application.Modules.Infrastructure.IntegrationEvents.Events
{
    public class AccountBalanceChangedIntegrationEvent : IntegrationEvent
    {
        public List<Guid> EffectedAccountIds { get; set; }

        public AccountBalanceChangedIntegrationEvent()
        {
            EffectedAccountIds ??= new List<Guid>();
        }
    }
}
