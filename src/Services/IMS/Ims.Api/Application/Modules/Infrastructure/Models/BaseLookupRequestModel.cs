using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models
{
    public class BaseFilterRequestModel
    {
        public string typed { get; set; }
        public int? id { get; set; }
    }
}
