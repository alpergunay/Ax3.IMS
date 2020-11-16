using AutoMapper;
using Ims.Api.Application.Modules.Infrastructure.Models.Store;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreBranch;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreType;
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
            CreateMapForStoreType();
            CreateMapForStoreBranch();
        }

        private void CreateMapForStoreBranch()
        {
            CreateMap<StoreBranch, StoreBranchResponseModel>()
                .ForMember(m => m.StoreId, d => d.MapFrom(s => s.Store.Id))
                .ForMember(m => m.StoreName, d => d.MapFrom(s => s.Store.Name))
                .ForMember(m => m.StoreTypeId, d => d.MapFrom(s => s.Store.StoreType.EnumId))
                .ForMember(m => m.StoreTypeName, d => d.MapFrom(s => s.Store.StoreType.Name));
        }

        private void CreateMapForStore()
        {
            CreateMap<Store, StoreResponseModel>()
                .ForMember(m => m.StoreTypeName, d => d.MapFrom(s => s.StoreType.Name))
                .ForMember(m => m.StoreTypeId, d => d.MapFrom(s => s.StoreType.EnumId));
        }

        private void CreateMapForTransactionType()
        {
            CreateMap<TransactionType, TransactionTypeResponseModel>();
        }
        private void CreateMapForStoreType()
        {
            CreateMap<StoreType, StoreTypeResponseModel>().ForMember(m => m.Id, d => d.MapFrom(s => s.EnumId)); ;
        }
    }
}
