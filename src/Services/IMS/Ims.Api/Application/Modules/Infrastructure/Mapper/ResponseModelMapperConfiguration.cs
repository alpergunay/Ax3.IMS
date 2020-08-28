using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreType;
using Ims.Domain.DomainModels;

namespace Ims.Api.Application.Modules.Infrastructure.Mapper
{
    public class ResponseModelMapperConfiguration : Profile
    {
        public ResponseModelMapperConfiguration()
        {
            CreateMapForStoreType();
        }

        private void CreateMapForStoreType()
        {
            CreateMap<StoreType, StoreTypeResponseModel>();
        }
    }
}
