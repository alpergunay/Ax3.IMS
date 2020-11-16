using System;

namespace Ims.Api.Application.Modules.Infrastructure.Models.Store
{
    public class StoreResponseModel :BaseResponseModel
    {
        public string Name { get; set; }
        public int StoreTypeId { get; set; }
        public string StoreTypeName { get; set; }
    }
}
