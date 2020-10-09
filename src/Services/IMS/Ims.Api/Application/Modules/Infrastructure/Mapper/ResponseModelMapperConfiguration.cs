using AutoMapper;
using Ims.Api.Application.Modules.Infrastructure.Models.AccountType;
using Ims.Api.Application.Modules.Infrastructure.Models.DirectionType;
using Ims.Api.Application.Modules.Infrastructure.Models.InvestmentToolType;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreType;
using Ims.Api.Application.Modules.Infrastructure.Models.TransactionType;
using Ims.Domain.DomainModels;

namespace Ims.Api.Application.Modules.Infrastructure.Mapper
{
    public class ResponseModelMapperConfiguration : Profile
    {
        public ResponseModelMapperConfiguration()
        {
            CreateMapForStoreType();
            CreateMapForAccountType();
            CreateMapForTransactionType();
            CreateMapForDirectionType();
            CreateMapForInvestmentToolType();
        }

        private void CreateMapForStoreType()
        {
            CreateMap<StoreType, StoreTypeResponseModel>();
        }
        private void CreateMapForAccountType()
        {
            CreateMap<AccountType, AccountTypeResponseModel>();
        }
        private void CreateMapForTransactionType()
        {
            CreateMap<TransactionType, TransactionTypeResponseModel>();
        }
        private void CreateMapForDirectionType()
        {
            CreateMap<DirectionType, DirectionTypeResponseModel>();
        }
        private void CreateMapForInvestmentToolType()
        {
            CreateMap<InvestmentToolType, InvestmentToolTypeResponseModel>();
        }
    }
}
