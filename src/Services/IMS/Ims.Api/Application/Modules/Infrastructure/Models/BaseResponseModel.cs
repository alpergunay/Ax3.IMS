using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models
{
    public class BaseResponseModel : IBaseModel
    {
        public Guid Id { get; set; }
    }
}
