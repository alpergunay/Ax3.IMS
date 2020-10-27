using AutoMapper;
using Ims.Api.Application.Modules.Infrastructure.Models.Store;
using Ims.Api.Application.Modules.Infrastructure.Models.TransactionType;
using Ims.Domain.DomainModels;

namespace Ims.Api.Application.Modules.Infrastructure.Mapper
{
    public class ResponseModelMapperConfiguration : Profile
    {
        public ResponseModelMapperConfiguration()
        {
            CreateMapForTransactionType();
            CreateMapForStore();
        }

        private void CreateMapForStore()
        {
            CreateMap<Store, StoreResponseModel>()
                .ForMember(m => m.StoreTypeName, d => d.MapFrom(s => s.StoreType.Name));
        }

        private void CreateMapForTransactionType()
        {
            CreateMap<TransactionType, TransactionTypeResponseModel>();
        }
    }
}
