using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using CurrencyPriceProvider.Models;
using CurrencyPriceProvider.Models.PgDtos;
using Epoch.net;

namespace CurrencyPriceProvider.Configuration
{
    public class DtoToDomainMapperProfile : Profile
    {
        public DtoToDomainMapperProfile()
        {
            ShouldMapField = fieldInfo => false;
            ShouldMapProperty = propertyInfo => false;

            CreateMap<PgForeignCurrencyCurrentPriceDto, ForeignCurrencyPrice>()
                .ForMember(x => x.PriceDate, o => o.MapFrom(d => DateTime.Now))
                .ForMember(x => x.BuyingPrice, o => o.MapFrom(d => d.excBuyRate))
                .ForMember(x => x.SalesPrice, o => o.MapFrom(d => d.excSellRate))
                .ForMember(x => x.CurrencyCode, o => o.MapFrom(d => "USD"))
                .ForMember(x => x.Hour, o => o.MapFrom(d => DateTime.Now.Hour))
                .ForMember(x => x.Minute, o => o.MapFrom(d => DateTime.Now.Minute));
        }
    }
}
