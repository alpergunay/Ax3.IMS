using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models.User
{
    public class UpdateUserRequestModel
    {
        public string Id { get; set; }
        public Guid CountryId { get; set; }
        public Guid CurrencyId { get; set; }
    }
}
