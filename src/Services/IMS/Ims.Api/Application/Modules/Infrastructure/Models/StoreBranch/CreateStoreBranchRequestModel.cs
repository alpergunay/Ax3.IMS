using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ims.Api.Application.Modules.Infrastructure.Models.StoreBranch
{
    public class CreateStoreBranchRequestModel
    {
        public string StoreId { get; set; }
        public string Name { get; set; }
    }
}
