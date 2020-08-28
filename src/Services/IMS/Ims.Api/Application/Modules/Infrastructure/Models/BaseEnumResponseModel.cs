using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models
{
    public class BaseEnumResponseModel:IBaseModel
    {
        public int EnumId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
