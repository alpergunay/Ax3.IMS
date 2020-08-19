using AutoMapper;
using Europcar.RentoCloud.Domain.Types;
using System.Linq;
using Web.API.Application.Modules.Infrastructure.Models;
using Web.API.Application.Modules.Infrastructure.Models.Accidents;
using Web.API.Application.Modules.Infrastructure.Models.Accounts;
using Web.API.Application.Modules.Infrastructure.Models.Calculators;
using Web.API.Application.Modules.Infrastructure.Models.City;
using Web.API.Application.Modules.Infrastructure.Models.Country;
using Web.API.Application.Modules.Infrastructure.Models.DynamicType;
using Web.API.Application.Modules.Infrastructure.Models.Localization;
using Web.API.Application.Modules.Infrastructure.Models.LocationType;
using Web.API.Application.Modules.Infrastructure.Models.Region;
using Web.API.Application.Modules.Infrastructure.Models.Roles;
using Web.API.Application.Modules.Infrastructure.Models.Stations;
using Web.API.Application.Modules.Infrastructure.Models.Town;
using Web.API.Application.Modules.Infrastructure.Models.TrafficViolations;
using Web.API.Application.Modules.Infrastructure.Models.Vehicles;
using Web.Domain.DomainModels.Infrastructure.Accidents;
using Web.Domain.DomainModels.Infrastructure.Accounts;
using Web.Domain.DomainModels.Infrastructure.Calculators;
using Web.Domain.DomainModels.Infrastructure.Cities;
using Web.Domain.DomainModels.Infrastructure.Countries;
using Web.Domain.DomainModels.Infrastructure.Districts;
using Web.Domain.DomainModels.Infrastructure.DynamicType;
using Web.Domain.DomainModels.Infrastructure.Localization;
using Web.Domain.DomainModels.Infrastructure.Locations;
using Web.Domain.DomainModels.Infrastructure.Regions;
using Web.Domain.DomainModels.Infrastructure.Stations;
using Web.Domain.DomainModels.Infrastructure.TrafficViolations;
using Web.Domain.DomainModels.Infrastructure.Users;
using Web.Domain.DomainModels.Infrastructure.Vehicles;

namespace Web.API.Application.Modules.Infrastructure.Mapper
{
    public class WepApiMapperConfiguration : Profile
    {
        public WepApiMapperConfiguration()
        {
            CreateCurrencyMaps();
            CreateLanguageMaps();
            CreateCountryMaps();
            CreateRegionMaps();
            CreateCityMaps();
            CreateLocalizationMaps();
            CreateTownMaps();
            CreateLocationTypeMaps();
            CreateLocalizationMaps();
            CreateAccountTypeMaps();
            CreateAccountFunctionTypeMaps();
            CreateAddressTypeMaps();
            CreateContactTypeMaps();
            CreateColorEnumTypeMaps();
            CreateFuelEnumTypeMaps();
            CreateGearEnumTypeMaps();
            CreateOwnershipEnumTypeMaps();
            CreatePoolEnumTypeMaps();
            CreateStatusEnumTypeMaps();
            CreateGroupMaps();
            CreateManufacturerMaps();
            CreateModelMaps();
            CreateVehicleActivityMaps();
            CreateVehicleAlternateGroupMaps();
            CreateVehicleClassMaps();
            CreateVehicleOwnershipMaps();
            CreateVehiclePlatesMaps();
            CreateVehicleMaps();
            CreateVehicleStationMaps();
            CreateLocalizationMaps();
            CreateStationTypeMaps();
            CreateStationGroupMaps();
            CreateStationShiftMaps();
            CreateStationMaps();
            CreateStationOperationScopeMaps();
            CreateStationScope();
            CreatePointOfSalesMaps();
            CreateCarParkMaps();
            CreateApplicationRoleMaps();
            CreateCarParkMaps();
            AccountAdditionalServiceMappingMaps();
            AdditionalServiceMaps();
            RateDetailsDayIntervalsMaps();
            RateDetailsMaps();
            RateZoneMaps();
            RateZoneStationsMaps();
            RateInclusiveAdditionalServicesMaps();
            RateInsuranceExcessPoliciesMaps();
            RateInsuranceExcessPolicyRateMaps();
            RateMaps();
            CalculationTypeMaps();
            LimitationTypeMaps();
            RevenueGroupMaps();
            ServiceTypeMaps();
            CreateVehicleBodyMaps();
            AccidentTypeRoleMaps();
            DamageElementRoleMaps();
            DamageAreaRoleMaps();
            AccidentChargeoutTypeRoleMaps();
            AccidentStatusRoleMaps();
            AccidentImageTypeRoleMaps();
            AccidentDriverTypeRoleMaps();
            AccidentImageRoleMaps();
            AccidentRoleMaps();
            AccidentVehicleRoleMaps();
            DamageAreaBodyCordinatesRoleMaps();
            TrafficViolationTypesRoleMaps();
            TrafficViolationsRoleMaps();
            CreateDynamicTypeMaps();
            CreateDynamicValueMaps();
            VehiclePolicyMaps();

            EnumTypeMaps<VehicleActivityType, VehicleActivityTypeRequestModel>();
            EnumTypeMaps<AccountType, AccountTypeRequestModel>();
            EnumTypeMaps<AddressType, AddressTypeRequestModel>();
            EnumTypeMaps<DynamicDataTypes, DynamicDataTypesRequestModel>();
            EnumTypeMaps<DynamicTypeSource, DynamicTypeSourceRequesModel>();
        }

        private void CreateDynamicTypeMaps()
        {
            CreateMap<DynamicTypes, DynamicTypesRequestModel>()
                .ForMember(dest => dest.DataTypeCode, src => src.MapFrom(x => x.DataType.Code))
                .ForMember(dest => dest.DataTypeDescription, src => src.MapFrom(x => x.DataType.Name))
                .ForMember(dest => dest.SourceCode, src => src.MapFrom(x => x.Source.Code))
                .ForMember(dest => dest.SourceDescription, src => src.MapFrom(x => x.Source.Name));
            CreateMap<DynamicTypesRequestModel, DynamicTypes>();
        }

        private void CreateDynamicValueMaps()
        {
            CreateMap<DynamicValues, DynamicValuesRequestModel>()
                .ForMember(dest => dest.DynamicTypeCode, src => src.MapFrom(x => x.DynamicTypes.Key))
                .ForMember(dest => dest.DynamicTypeDescription, src => src.MapFrom(x => x.DynamicTypes.Description))
                .ForMember(dest => dest.Key, src => src.MapFrom(x => x.DynamicTypes.DataType.Code))
                .ForMember(dest => dest.Description, src => src.MapFrom(x => x.DynamicTypes.DataType.Name));
            CreateMap<DynamicValuesRequestModel, DynamicValues>();
            EnumTypeMaps<VehiclePolicyType, VehiclePolicyTypeRequestModel>();
        }

        private void CreateCurrencyMaps()
        {
            CreateMap<Currency, CurrencyRequestModel>()
                .ForMember(dest => dest.RoundingTypeId, src => src.MapFrom(x => x.RoundingType.EnumId));
            CreateMap<CurrencyRequestModel, Currency>();
        }

        private void CreateLanguageMaps()
        {
            CreateMap<Language, LanguageRequestModel>();
            CreateMap<LanguageRequestModel, Language>();
        }

        private void CreateCountryMaps()
        {
            CreateMap<Country, CountryRequestModel>();
            CreateMap<CountryRequestModel, Country>();
        }

        private void CreateRegionMaps()
        {
            CreateMap<Region, RegionRequestModel>();
            CreateMap<RegionRequestModel, Region>();
        }

        private void CreateCityMaps()
        {
            CreateMap<City, CityRequestModel>()
                .ForMember(dest => dest.CountryName, src => src.MapFrom(x => x.Country.Description));
            CreateMap<CityRequestModel, City>();
        }

        private void CreateLocalizationMaps()
        {
            CreateMap<LocaleStringResource, LocalizationRequestModel>()
                .ForMember(dest => dest.LanguageName, src => src.MapFrom(x => x.Language.Name));
            CreateMap<LocalizationRequestModel, LocaleStringResource>();
        }

        private void CreateTownMaps()
        {
            CreateMap<Town, TownRequestModel>()
                .ForMember(dest => dest.CityName, src => src.MapFrom(x => x.City.Description));
            CreateMap<TownRequestModel, Town>();
        }

        private void CreateLocationTypeMaps()
        {
            CreateMap<LocationType, LocationTypeRequestModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<LocationTypeRequestModel, LocationType>();
        }

        private void CreateAccountTypeMaps()
        {
            CreateMap<Account, AccountRequestModel>();
            CreateMap<AccountRequestModel, Account>();
        }

        private void CreateAccountFunctionTypeMaps()
        {
            CreateMap<AccountFunction, AccountFunctionRequestModel>()
               .ForMember(dest => dest.AccountTypeName, src => src.MapFrom(x => x.AccountType.Code))
               .ForMember(dest => dest.AccountTypeDescription, src => src.MapFrom(x => x.AccountType.Name));
            CreateMap<AccountFunctionRequestModel, AccountFunction>();
        }

        private void CreateAddressTypeMaps()
        {
            CreateMap<Address, AddressRequestModel>();
            CreateMap<AddressRequestModel, Address>();
        }

        private void CreateContactTypeMaps()
        {
            CreateMap<Contact, ContactRequestModel>();
            CreateMap<ContactRequestModel, Contact>();
        }

        private void CreateColorEnumTypeMaps()
        {
            CreateMap<Color, ColorRequestModel>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<ColorRequestModel, Color>();
        }

        private void CreateFuelEnumTypeMaps()
        {
            CreateMap<FuelType, FuelTypeRequestModel>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<FuelTypeRequestModel, FuelType>();
        }

        private void CreateGearEnumTypeMaps()
        {
            CreateMap<GearType, GearTypeRequestModel>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<GearTypeRequestModel, GearType>();
        }

        private void CreateOwnershipEnumTypeMaps()
        {
            CreateMap<Ownership, OwnershipRequestModel>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<OwnershipRequestModel, Ownership>();
        }

        private void CreatePoolEnumTypeMaps()
        {
            CreateMap<PoolType, PoolTypeRequestModel>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<PoolTypeRequestModel, PoolType>();
        }

        private void CreateStatusEnumTypeMaps()
        {
            CreateMap<Status, StatusRequestModel>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<StatusRequestModel, Status>();
        }

        private void CreateGroupMaps()
        {
            CreateMap<Group, GroupRequestModel>();
            CreateMap<GroupRequestModel, Group>();
        }

        private void CreateManufacturerMaps()
        {
            CreateMap<Manufacturer, ManufacturerRequestModel>();
            CreateMap<ManufacturerRequestModel, Manufacturer>();
        }

        private void CreateModelMaps()
        {
            CreateMap<Model, ModelRequestModel>();
            CreateMap<ModelRequestModel, Model>();
        }

        private void CreateVehicleActivityMaps()
        {
            CreateMap<VehicleActivity, VehicleActivityRequestModel>()
                .ForMember(dest => dest.VehicleCode, src => src.MapFrom(x => x.Vehicle.Code))
                .ForMember(dest => dest.VehicleDescription, src => src.MapFrom(x => x.Vehicle.Description))
                .ForMember(dest => dest.ActivityTypeCode, src => src.MapFrom(x => x.ActivityType.Code))
                .ForMember(dest => dest.ActivityTypDescription, src => src.MapFrom(x => x.ActivityType.Name));
            CreateMap<VehicleActivityRequestModel, VehicleActivity>();
        }

        private void CreateVehicleAlternateGroupMaps()
        {
            CreateMap<VehicleAlternateGroup, VehicleAlternateGroupRequestModel>();
            CreateMap<VehicleAlternateGroupRequestModel, VehicleAlternateGroup>();
        }

        private void CreateVehicleClassMaps()
        {
            CreateMap<VehicleClass, VehicleClassRequestModel>();
            CreateMap<VehicleClassRequestModel, VehicleClass>();
        }

        private void CreateVehicleOwnershipMaps()
        {
            CreateMap<VehicleOwnership, VehicleOwnershipRequestModel>();
            CreateMap<VehicleOwnershipRequestModel, VehicleOwnership>();
        }

        private void CreateVehiclePlatesMaps()
        {
            CreateMap<VehiclePlates, VehiclePlatesRequestModel>();
            CreateMap<VehiclePlatesRequestModel, VehiclePlates>();
        }

        private void CreateVehicleMaps()
        {
            CreateMap<Vehicle, VehicleRequestModel>();
            CreateMap<VehicleRequestModel, Vehicle>();
        }

        private void CreateVehicleBodyMaps()
        {
            CreateMap<VehicleBody, VehicleBodyRequestModel>();
            CreateMap<VehicleBodyRequestModel, VehicleBody>();
        }

        private void CreateVehicleStationMaps()
        {
            CreateMap<VehicleStation, VehicleStationRequestModel>()
                .ForMember(dest => dest.VehicleCode, src => src.MapFrom(x => x.Vehicle.Code))
                .ForMember(dest => dest.VehicleDescription, src => src.MapFrom(x => x.Vehicle.Description))
                .ForMember(dest => dest.StationCode, src => src.MapFrom(x => x.Station.Code))
                .ForMember(dest => dest.StationDescription, src => src.MapFrom(x => x.Station.Description));
            CreateMap<VehicleStationRequestModel, VehicleStation>();
        }

        private void CreateStationTypeMaps()
        {
            CreateMap<StationType, StationTypeRequestModel>();
            CreateMap<StationTypeRequestModel, StationType>();
        }

        private void CreateStationGroupMaps()
        {
            CreateMap<StationGroup, StationGroupRequestModel>();
            CreateMap<StationGroupRequestModel, StationGroup>();
        }

        private void CreateStationShiftMaps()
        {
            CreateMap<StationShift, StationShiftRequestModel>();
            CreateMap<StationShiftRequestModel, StationShift>();
        }

        private void CreateStationMaps()
        {
            CreateMap<Station, StationRequestModel>();
            CreateMap<StationRequestModel, Station>();
        }

        private void CreateStationScope()
        {
            CreateMap<StationScope, StationScopeRequestModel>();
            CreateMap<StationScopeRequestModel, StationScope>();
        }

        private void CreateStationOperationScopeMaps()
        {
            CreateMap<StationOperationScope, StationOperationScopeRequestModel>();
            CreateMap<StationOperationScopeRequestModel, StationOperationScope>();
        }

        private void CreatePointOfSalesMaps()
        {
            CreateMap<PointOfSale, PointOfSalesRequestModel>();
            CreateMap<PointOfSalesRequestModel, PointOfSale>();
        }

        private void CreateCarParkMaps()
        {
            CreateMap<CarPark, CarParkRequestModel>();
            CreateMap<CarParkRequestModel, CarPark>();
        }

        private void AccountAdditionalServiceMappingMaps()
        {
            CreateMap<AccountAdditionalServiceMapping, AccountAdditionalServiceMappingRequestModel>();
            CreateMap<AccountAdditionalServiceMappingRequestModel, AccountAdditionalServiceMapping>();
        }

        private void AdditionalServiceMaps()
        {
            CreateMap<AdditionalService, AdditionalServiceRequestModel>();
            CreateMap<AdditionalServiceRequestModel, AdditionalService>();
        }

        private void RateDetailsDayIntervalsMaps()
        {
            CreateMap<RateDetailsDayIntervals, RateDetailsDayIntervalsRequestModel>();
            CreateMap<RateDetailsDayIntervalsRequestModel, RateDetailsDayIntervals>();
        }

        private void RateDetailsMaps()
        {
            CreateMap<RateDetails, RateDetailsRequestModel>();
            CreateMap<RateDetailsRequestModel, RateDetails>();
        }

        private void RateInclusiveAdditionalServicesMaps()
        {
            CreateMap<RateInclusiveAdditionalServices, RateInclusiveAdditionalServicesRequestModel>();
            CreateMap<RateInclusiveAdditionalServicesRequestModel, RateInclusiveAdditionalServices>();
        }

        private void RateInsuranceExcessPoliciesMaps()
        {
            CreateMap<RateInsuranceExcessPolicies, RateInsuranceExcessPoliciesRequestModel>();
            CreateMap<RateInsuranceExcessPoliciesRequestModel, RateInsuranceExcessPolicies>();
        }

        private void RateInsuranceExcessPolicyRateMaps()
        {
            CreateMap<RateInsuranceExcessPolicyRates, RateInsuranceExcessPolicyRatesRequestModel>();
            CreateMap<RateInsuranceExcessPolicyRatesRequestModel, RateInsuranceExcessPolicyRates>();
        }

        private void RateZoneMaps()
        {
            CreateMap<RateZone, RateZoneRequestModel>();
            CreateMap<RateZoneRequestModel, RateZone>();
        }

        private void RateZoneStationsMaps()
        {
            CreateMap<RateZoneStations, RateZoneStationRequestModel>();
            CreateMap<RateZoneStationRequestModel, RateZoneStations>();
        }

        private void RateMaps()
        {
            CreateMap<Rates, RatesRequestModel>();
            CreateMap<RatesRequestModel, Rates>();
        }

        private void CalculationTypeMaps()
        {
            CreateMap<CalculationType, CalculationTypeRequestModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<CalculationTypeRequestModel, CalculationType>();
        }

        private void LimitationTypeMaps()
        {
            CreateMap<LimitationType, LimitationTypeRequestModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<LimitationTypeRequestModel, LimitationType>();
        }

        private void RevenueGroupMaps()
        {
            CreateMap<RevenueGroup, RevenueGroupRequestModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<RevenueGroupRequestModel, RevenueGroup>();
        }

        private void ServiceTypeMaps()
        {
            CreateMap<ServiceType, ServiceTypeRequestModel>()
                .ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<ServiceTypeRequestModel, ServiceType>();
        }

        private void CreateApplicationRoleMaps()
        {
            CreateMap<ApplicationRole, RoleRequestModel>();
            CreateMap<RoleRequestModel, ApplicationRole>();
        }

        private void AccidentTypeRoleMaps()
        {
            CreateMap<AccidentType, AccidentTypeRequestModel>();
            CreateMap<AccidentTypeRequestModel, AccidentType>();
        }

        private void DamageElementRoleMaps()
        {
            CreateMap<DamageElement, DamageElementRequestModel>();
            CreateMap<DamageElementRequestModel, DamageElement>();
        }

        private void DamageAreaRoleMaps()
        {
            CreateMap<DamageArea, DamageAreaRequestModel>();
            CreateMap<DamageAreaRequestModel, DamageArea>();
        }

        private void AccidentChargeoutTypeRoleMaps()
        {
            CreateMap<AccidentChargeoutType, AccidentChargeoutTypeRequestModel>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<AccidentChargeoutTypeRequestModel, AccidentChargeoutType>();
        }

        private void AccidentStatusRoleMaps()
        {
            CreateMap<AccidentStatus, AccidentStatusRequestModel>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<AccidentStatusRequestModel, AccidentStatus>();
        }

        private void AccidentImageTypeRoleMaps()
        {
            CreateMap<AccidentImageType, AccidentImageTypeRequestModel>().ForMember(dest => dest.Id, src => src.MapFrom(x => x.EnumId));
            CreateMap<AccidentImageTypeRequestModel, AccidentImageType>();
        }

        private void AccidentDriverTypeRoleMaps()
        {
            CreateMap<AccidentDriverType, AccidentDriverTypeRequestModel>();
            CreateMap<AccidentDriverTypeRequestModel, AccidentDriverType>();
        }

        private void AccidentImageRoleMaps()
        {
            CreateMap<AccidentImage, AccidentImageRequestModel>();
            CreateMap<AccidentImageRequestModel, AccidentImage>();
        }

        private void AccidentRoleMaps()
        {
            CreateMap<Accident, AccidentRequestModel>();
            CreateMap<AccidentRequestModel, Accident>();
        }

        private void AccidentVehicleRoleMaps()
        {
            CreateMap<AccidentVehicle, AccidentVehicleRequestModel>();
            CreateMap<AccidentImageRequestModel, AccidentVehicle>();
        }

        private void DamageAreaBodyCordinatesRoleMaps()
        {
            CreateMap<DamageAreaBodyCoordinates, DamageAreaBodyCordinatesRequestModel>();
            CreateMap<DamageAreaBodyCordinatesRequestModel, DamageAreaBodyCoordinates>();
        }

        private void EnumTypeMaps<Tenum, TenumRequest>()
            where Tenum : Enumeration
            where TenumRequest : BaseEnumViewModel
        {
            CreateMap<Tenum, TenumRequest>()
                .ForMember("Id", src => src.MapFrom("EnumId"));
            CreateMap<TenumRequest, Tenum>()
               .ForMember("EnumId", src => src.MapFrom("Id"));
        }

        private void TrafficViolationTypesRoleMaps()
        {
            CreateMap<TrafficViolationType, TrafficViolationTypeRequestModel>();
            CreateMap<TrafficViolationTypeRequestModel, TrafficViolationType>();
        }

        private void TrafficViolationsRoleMaps()
        {
            CreateMap<TrafficViolation, TrafficViolationRequestModel>();
            CreateMap<TrafficViolationRequestModel, TrafficViolation>();
        }

        private void VehiclePolicyMaps()
        {
            CreateMap<VehiclePolicy, VehiclePolicyRequestModel>();
            CreateMap<VehiclePolicyRequestModel, VehiclePolicy>();
        }
    }
}