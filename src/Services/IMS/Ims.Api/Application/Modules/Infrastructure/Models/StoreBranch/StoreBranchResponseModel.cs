using System;

namespace Ims.Api.Application.Modules.Infrastructure.Models.StoreBranch
{
    public class StoreBranchResponseModel : BaseResponseModel
    {
        public string Name { get; set; }
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public int StoreTypeId { get; set; }
        public string StoreTypeName { get; set; }
    }
}
