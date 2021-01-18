using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models
{
    public class CountryResponseModel : BaseResponseModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid LocalCurrencyId { get; set; }
        public string LocalCurrencyName { get; set; }
    }
}
