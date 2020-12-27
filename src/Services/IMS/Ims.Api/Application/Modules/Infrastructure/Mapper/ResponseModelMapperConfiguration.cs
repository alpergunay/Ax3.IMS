using AutoMapper;
using Ims.Api.Application.Modules.Infrastructure.Models.Account;
using Ims.Api.Application.Modules.Infrastructure.Models.AccountType;
using Ims.Api.Application.Modules.Infrastructure.Models.InvestmentTool;
using Ims.Api.Application.Modules.Infrastructure.Models.InvestmentToolType;
using Ims.Api.Application.Modules.Infrastructure.Models.Store;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreBranch;
using Ims.Api.Application.Modules.Infrastructure.Models.StoreType;
using Ims.Api.Application.Modules.Infrastructure.Models.TransactionType;
using Ims.Domain.DomainModels;
using Ims.Domain.Dto;

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
            CreateMapForInvestmentToolType();
            CreateMapForInvestmentTool();
            CreateMapForAccount();
            CreateMapForAccountDto();
        }

        private void CreateMapForAccountDto()
        {
            CreateMap<AccountDto, AccountLookupResponseModel>();
        }
        private void CreateMapForAccount()
        {
            CreateMap<Account, AccountResponseModel>()
                .ForMember(m => m.StoreId, d => d.MapFrom(s => s.StoreBranch.Store.Id))
                .ForMember(m => m.StoreName, d => d.MapFrom(s => s.StoreBranch.Store.Name))
                .ForMember(m => m.AccountTypeId, d => d.MapFrom(s => s.AccountType.EnumId))
                .ForMember(m => m.AccountTypeName, d => d.MapFrom(s => s.AccountType.Name))
                .ForMember(m => m.InvestmentToolName, d => d.MapFrom(s => s.InvestmentTool.Name))
                .ForMember(m => m.InvestmentToolTypeId, d => d.MapFrom(s => s.InvestmentTool.InvestmentToolType.EnumId))
                .ForMember(m => m.InvestmentToolTypeName, d => d.MapFrom(s => s.InvestmentTool.InvestmentToolType.Name))
                .ForMember(m => m.StoreBranchName, d => d.MapFrom(s => s.StoreBranch.Name))
                .ForMember(m => m.StoreTypeId, d => d.MapFrom(s => s.StoreBranch.Store.StoreType.EnumId))
                .ForMember(m => m.StoreTypeName, d => d.MapFrom(s => s.StoreBranch.Store.StoreType.Name))
                .ForMember(m => m.AccountName, d => d.MapFrom(s => s.AccountName))
                .ForMember(m => m.Balance, d => d.MapFrom(s => s.GetBalance()));

        }

        private void CreateMapForInvestmentToolType()
        {
            CreateMap<InvestmentToolType, InvestmentToolTypeResponseModel>()
                .ForMember(m => m.Id, d => d.MapFrom(s => s.EnumId));
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
        private void CreateMapForInvestmentTool()
        {
            CreateMap<InvestmentTool, InvestmentToolResponseModel>()
                .ForMember(m => m.InvestmentToolTypeName, d => d.MapFrom(s => s.InvestmentToolType.Name))
                .ForMember(m => m.InvestmentToolTypeId, d => d.MapFrom(s => s.InvestmentToolType.EnumId))
                .ForMember(m => m.CountryId, d => d.MapFrom(s => s.Country.Id))
                .ForMember(m => m.CountryName, d => d.MapFrom(s => s.Country.Name));
        }

        private void CreateMapForTransactionType()
        {
            CreateMap<TransactionType, TransactionTypeResponseModel>()
                .ForMember(m => m.Id, d => d.MapFrom(s => s.EnumId));

        }
        private void CreateMapForStoreType()
        {
            CreateMap<StoreType, StoreTypeResponseModel>().ForMember(m => m.Id, d => d.MapFrom(s => s.EnumId));
        }
    }
}
