using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models.Store
{
    public class CreateStoreRequestModel
    {
        public string Name { get; set; }
        public int StoreTypeId { get; set; }
    }
}
