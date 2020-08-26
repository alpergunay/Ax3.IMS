using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models
{
    public class BaseRequestModel<T>
    {
        public T Id { get; set; }
    }

    public class BaseEntityRequestModel : BaseRequestModel<Guid>
    {
    }

    public class BaseEnumRequestModel : BaseRequestModel<int>
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
