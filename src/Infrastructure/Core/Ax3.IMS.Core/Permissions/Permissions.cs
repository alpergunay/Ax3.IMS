using System.Collections.Generic;

namespace Ax3.IMS.Infrastructure.Core.Permissions
{
    public class Permissions
    {
        public enum Permission
        {
            View,
            Create,
            Edit,
            Delete,
            Filter,
            Group,
            Export
        }

        public const string ClaimType = "permission";

        public static class Account
        {
            public const string View = "Permissions.Account.View";
            public const string Create = "Permissions.Account.Create";
            public const string Edit = "Permissions.Account.Edit";
            public const string Delete = "Permissions.Account.Delete";
            public const string Filter = "Permissions.Account.Filter";
            public const string Group = "Permissions.Account.Group";
            public const string Export = "Permissions.Account.Export";
        }

        public static class Location
        {
            public const string View = "Permissions.Location.View";
            public const string Create = "Permissions.Location.Create";
            public const string Edit = "Permissions.Location.Edit";
            public const string Delete = "Permissions.Location.Delete";
            public const string Filter = "Permissions.Location.Filter";
            public const string Group = "Permissions.Location.Group";
            public const string Export = "Permissions.Location.Export";
        }

        public static class Role
        {
            public const string View = "Permissions.Role.View";
            public const string Create = "Permissions.Role.Create";
            public const string Edit = "Permissions.Role.Edit";
            public const string Delete = "Permissions.Role.Delete";
            public const string Filter = "Permissions.Role.Filter";
            public const string Group = "Permissions.Role.Group";
            public const string Export = "Permissions.Role.Export";
        }

        public static class Country
        {
            public const string View = "Permissions.Country.View";
            public const string Create = "Permissions.Country.Create";
            public const string Edit = "Permissions.Country.Edit";
            public const string Delete = "Permissions.Country.Delete";
            public const string Filter = "Permissions.Country.Filter";
            public const string Group = "Permissions.Country.Group";
            public const string Export = "Permissions.Country.Export";
        }

        public static class Region
        {
            public const string View = "Permissions.Region.View";
            public const string Create = "Permissions.Region.Create";
            public const string Edit = "Permissions.Region.Edit";
            public const string Delete = "Permissions.Region.Delete";
            public const string Filter = "Permissions.Region.Filter";
            public const string Group = "Permissions.Region.Group";
            public const string Export = "Permissions.Region.Export";
        }

        public static class City
        {
            public const string View = "Permissions.City.View";
            public const string Create = "Permissions.City.Create";
            public const string Edit = "Permissions.City.Edit";
            public const string Delete = "Permissions.City.Delete";
            public const string Filter = "Permissions.City.Filter";
            public const string Group = "Permissions.City.Group";
            public const string Export = "Permissions.City.Export";
        }

        public static class Town
        {
            public const string View = "Permissions.Town.View";
            public const string Create = "Permissions.Town.Create";
            public const string Edit = "Permissions.Town.Edit";
            public const string Delete = "Permissions.Town.Delete";
            public const string Filter = "Permissions.Town.Filter";
            public const string Group = "Permissions.Town.Group";
            public const string Export = "Permissions.Town.Export";
        }

        public static class Currency
        {
            public const string View = "Permissions.Currency.View";
            public const string Create = "Permissions.Currency.Create";
            public const string Edit = "Permissions.Currency.Edit";
            public const string Delete = "Permissions.Currency.Delete";
            public const string Filter = "Permissions.Currency.Filter";
            public const string Group = "Permissions.Currency.Group";
            public const string Export = "Permissions.Currency.Export";
        }

        public static class Language
        {
            public const string View = "Permissions.Language.View";
            public const string Create = "Permissions.Language.Create";
            public const string Edit = "Permissions.Language.Edit";
            public const string Delete = "Permissions.Language.Delete";
            public const string Filter = "Permissions.Language.Filter";
            public const string Group = "Permissions.Language.Group";
            public const string Export = "Permissions.Language.Export";
        }

        public static class Localization
        {
            public const string View = "Permissions.Localization.View";
            public const string Create = "Permissions.Localization.Create";
            public const string Edit = "Permissions.Localization.Edit";
            public const string Delete = "Permissions.Localization.Delete";
            public const string Filter = "Permissions.Localization.Filter";
            public const string Group = "Permissions.Localization.Group";
            public const string Export = "Permissions.Localization.Export";
        }

        public static class LocationType
        {
            public const string View = "Permissions.LocationType.View";
        }

        public static class AccountFunction
        {
            public const string View = "Permissions.AccountFunction.View";
            public const string Create = "Permissions.AccountFunction.Create";
            public const string Edit = "Permissions.AccountFunction.Edit";
            public const string Delete = "Permissions.AccountFunction.Delete";
            public const string Filter = "Permissions.AccountFunction.Filter";
            public const string Group = "Permissions.AccountFunction.Group";
            public const string Export = "Permissions.AccountFunction.Export";
        }

        public static class Address
        {
            public const string View = "Permissions.Address.View";
            public const string Create = "Permissions.Address.Create";
            public const string Edit = "Permissions.Address.Edit";
            public const string Delete = "Permissions.Address.Delete";
            public const string Filter = "Permissions.Address.Filter";
            public const string Group = "Permissions.Address.Group";
            public const string Export = "Permissions.Address.Export";
        }

        public static class Contact
        {
            public const string View = "Permissions.Contact.View";
            public const string Create = "Permissions.Contact.Create";
            public const string Edit = "Permissions.Contact.Edit";
            public const string Delete = "Permissions.Contact.Delete";
            public const string Filter = "Permissions.Contact.Filter";
            public const string Group = "Permissions.Contact.Group";
            public const string Export = "Permissions.Contact.Export";
        }

        public static class VehicleGroup
        {
            public const string View = "Permissions.Group.View";
            public const string Create = "Permissions.Group.Create";
            public const string Edit = "Permissions.Group.Edit";
            public const string Delete = "Permissions.Group.Delete";
            public const string Filter = "Permissions.Group.Filter";
            public const string Group = "Permissions.Group.Group";
            public const string Export = "Permissions.Group.Export";
        }

        public static class Manufacturer
        {
            public const string View = "Permissions.Manufacturer.View";
            public const string Create = "Permissions.Manufacturer.Create";
            public const string Edit = "Permissions.Manufacturer.Edit";
            public const string Delete = "Permissions.Manufacturer.Delete";
            public const string Filter = "Permissions.Manufacturer.Filter";
            public const string Group = "Permissions.Manufacturer.Group";
            public const string Export = "Permissions.Manufacturer.Export";
        }

        public static class Model
        {
            public const string View = "Permissions.Model.View";
            public const string Create = "Permissions.Model.Create";
            public const string Edit = "Permissions.Model.Edit";
            public const string Delete = "Permissions.Model.Delete";
            public const string Filter = "Permissions.Model.Filter";
            public const string Group = "Permissions.Model.Group";
            public const string Export = "Permissions.Model.Export";
        }

        public static class VehicleActivity
        {
            public const string View = "Permissions.VehicleActivity.View";
            public const string Create = "Permissions.VehicleActivity.Create";
            public const string Edit = "Permissions.VehicleActivity.Edit";
            public const string Delete = "Permissions.VehicleActivity.Delete";
            public const string Filter = "Permissions.VehicleActivity.Filter";
            public const string Group = "Permissions.VehicleActivity.Group";
            public const string Export = "Permissions.VehicleActivity.Export";
        }

        public static class VehicleAlternateGroup
        {
            public const string View = "Permissions.VehicleAlternateGroup.View";
            public const string Create = "Permissions.VehicleAlternateGroup.Create";
            public const string Edit = "Permissions.VehicleAlternateGroup.Edit";
            public const string Delete = "Permissions.VehicleAlternateGroup.Delete";
            public const string Filter = "Permissions.VehicleAlternateGroup.Filter";
            public const string Group = "Permissions.VehicleAlternateGroup.Group";
            public const string Export = "Permissions.VehicleAlternateGroup.Export";
        }

        public static class VehicleOwnership
        {
            public const string View = "Permissions.VehicleOwnership.View";
            public const string Create = "Permissions.VehicleOwnership.Create";
            public const string Edit = "Permissions.VehicleOwnership.Edit";
            public const string Delete = "Permissions.VehicleOwnership.Delete";
            public const string Filter = "Permissions.VehicleOwnership.Filter";
            public const string Group = "Permissions.VehicleOwnership.Group";
            public const string Export = "Permissions.VehicleOwnership.Export";
        }

        public static class VehicleClass
        {
            public const string View = "Permissions.VehicleClass.View";
            public const string Create = "Permissions.VehicleClass.Create";
            public const string Edit = "Permissions.VehicleClass.Edit";
            public const string Delete = "Permissions.VehicleClass.Delete";
            public const string Filter = "Permissions.VehicleClass.Filter";
            public const string Group = "Permissions.VehicleClass.Group";
            public const string Export = "Permissions.VehicleClass.Export";
        }

        public static class StationType
        {
            public const string View = "Permissions.StationType.View";
            public const string Create = "Permissions.StationType.Create";
            public const string Edit = "Permissions.StationType.Edit";
            public const string Delete = "Permissions.StationType.Delete";
            public const string Filter = "Permissions.StationType.Filter";
            public const string Group = "Permissions.StationType.Group";
            public const string Export = "Permissions.StationType.Export";
        }

        public static class StationGroup
        {
            public const string View = "Permissions.StationGroup.View";
            public const string Create = "Permissions.StationGroup.Create";
            public const string Edit = "Permissions.StationGroup.Edit";
            public const string Delete = "Permissions.StationGroup.Delete";
            public const string Filter = "Permissions.StationGroup.Filter";
            public const string Group = "Permissions.StationGroup.Group";
            public const string Export = "Permissions.StationGroup.Export";
        }

        public static class StationShift
        {
            public const string View = "Permissions.StationShift.View";
            public const string Create = "Permissions.StationShift.Create";
            public const string Edit = "Permissions.StationShift.Edit";
            public const string Delete = "Permissions.StationShift.Delete";
            public const string Filter = "Permissions.StationShift.Filter";
            public const string Group = "Permissions.StationShift.Group";
            public const string Export = "Permissions.StationShift.Export";
        }

        public static class Station
        {
            public const string View = "Permissions.Station.View";
            public const string Create = "Permissions.Station.Create";
            public const string Edit = "Permissions.Station.Edit";
            public const string Delete = "Permissions.Station.Delete";
            public const string Filter = "Permissions.Station.Filter";
            public const string Group = "Permissions.Station.Group";
            public const string Export = "Permissions.Station.Export";
        }

        public static class StationScope
        {
            public const string View = "Permissions.StationScope.View";
            public const string Create = "Permissions.StationScope.Create";
            public const string Edit = "Permissions.StationScope.Edit";
            public const string Delete = "Permissions.StationScope.Delete";
            public const string Filter = "Permissions.StationScope.Filter";
            public const string Group = "Permissions.StationScope.Group";
            public const string Export = "Permissions.StationScope.Export";
        }

        public static class StationOperationScope
        {
            public const string View = "Permissions.StationOperationScope.View";
            public const string Create = "Permissions.StationOperationScope.Create";
            public const string Edit = "Permissions.StationOperationScope.Edit";
            public const string Delete = "Permissions.StationOperationScope.Delete";
            public const string Filter = "Permissions.StationOperationScope.Filter";
            public const string Group = "Permissions.StationOperationScope.Group";
            public const string Export = "Permissions.StationOperationScope.Export";
        }

        public static class VehiclePlates
        {
            public const string View = "Permissions.VehiclePlates.View";
            public const string Create = "Permissions.VehiclePlates.Create";
            public const string Edit = "Permissions.VehiclePlates.Edit";
            public const string Delete = "Permissions.VehiclePlates.Delete";
            public const string Filter = "Permissions.VehiclePlates.Filter";
            public const string Group = "Permissions.VehiclePlates.Group";
            public const string Export = "Permissions.VehiclePlates.Export";
        }

        public static class Vehicle
        {
            public const string View = "Permissions.Vehicle.View";
            public const string Create = "Permissions.Vehicle.Create";
            public const string Edit = "Permissions.Vehicle.Edit";
            public const string Delete = "Permissions.Vehicle.Delete";
            public const string Filter = "Permissions.Vehicle.Filter";
            public const string Group = "Permissions.Vehicle.Group";
            public const string Export = "Permissions.Vehicle.Export";
        }

        public static class VehicleBody
        {
            public const string View = "Permissions.VehicleBody.View";
            public const string Create = "Permissions.VehicleBody.Create";
            public const string Edit = "Permissions.VehicleBody.Edit";
            public const string Delete = "Permissions.VehicleBody.Delete";
            public const string Filter = "Permissions.VehicleBody.Filter";
            public const string Group = "Permissions.VehicleBody.Group";
            public const string Export = "Permissions.VehicleBody.Export";
        }

        public static class VehicleStation
        {
            public const string View = "Permissions.VehicleStation.View";
            public const string Create = "Permissions.VehicleStation.Create";
            public const string Edit = "Permissions.VehicleStation.Edit";
            public const string Delete = "Permissions.VehicleStation.Delete";
            public const string Filter = "Permissions.VehicleStation.Filter";
            public const string Group = "Permissions.VehicleStation.Group";
            public const string Export = "Permissions.VehicleStation.Export";
        }

        public static class AccountType
        {
            public const string View = "Permissions.AccountType.View";
        }

        public static class AddressType
        {
            public const string View = "Permissions.AddressType.View";
        }

        public static class GearType
        {
            public const string View = "Permissions.GearType.View";
        }

        public static class Color
        {
            public const string View = "Permissions.Color.View";
        }

        public static class FuelType
        {
            public const string View = "Permissions.FuelType.View";
        }

        public static class Ownership
        {
            public const string View = "Permissions.Ownership.View";
        }

        public static class PoolType
        {
            public const string View = "Permissions.PoolType.View";
        }

        public static class Status
        {
            public const string View = "Permissions.Status.View";
        }

        public static class VehicleActivityType
        {
            public const string View = "Permissions.VehicleActivityType.View";
        }

        public static class PointOfSales
        {
            public const string View = "Permissions.PointOfSales.View";
            public const string Create = "Permissions.PointOfSales.Create";
            public const string Edit = "Permissions.PointOfSales.Edit";
            public const string Delete = "Permissions.PointOfSales.Delete";
            public const string Filter = "Permissions.PointOfSales.Filter";
            public const string Group = "Permissions.PointOfSales.Group";
            public const string Export = "Permissions.PointOfSales.Export";
        }

        public static class CarPark
        {
            public const string View = "Permissions.CarPark.View";
            public const string Create = "Permissions.CarPark.Create";
            public const string Edit = "Permissions.CarPark.Edit";
            public const string Delete = "Permissions.CarPark.Delete";
            public const string Filter = "Permissions.CarPark.Filter";
            public const string Group = "Permissions.CarPark.Group";
            public const string Export = "Permissions.CarPark.Export";
        }

        public static class CalculationType
        {
            public const string View = "Permissions.CalculationType.View";
        }

        public static class LimitationType
        {
            public const string View = "Permissions.LimitationType.View";
        }

        public static class RevenueGroup
        {
            public const string View = "Permissions.RevenueGroup.View";
        }

        public static class ServiceType
        {
            public const string View = "Permissions.ServiceType.View";
        }

        public static class AccountAdditionalServiceMapping
        {
            public const string View = "Permissions.AccountAdditionalServiceMapping.View";
            public const string Create = "Permissions.AccountAdditionalServiceMapping.Create";
            public const string Edit = "Permissions.AccountAdditionalServiceMapping.Edit";
            public const string Delete = "Permissions.AccountAdditionalServiceMapping.Delete";
            public const string Filter = "Permissions.AccountAdditionalServiceMapping.Filter";
            public const string Group = "Permissions.AccountAdditionalServiceMapping.Group";
            public const string Export = "Permissions.AccountAdditionalServiceMapping.Export";
        }

        public static class AdditionalService
        {
            public const string View = "Permissions.AdditionalService.View";
            public const string Create = "Permissions.AdditionalService.Create";
            public const string Edit = "Permissions.AdditionalService.Edit";
            public const string Delete = "Permissions.AdditionalService.Delete";
            public const string Filter = "Permissions.AdditionalService.Filter";
            public const string Group = "Permissions.AdditionalService.Group";
            public const string Export = "Permissions.AdditionalService.Export";
        }

        public static class RateInclusiveAdditionalServices
        {
            public const string View = "Permissions.RateInclusiveAdditionalService.View";
            public const string Create = "Permissions.RateInclusiveAdditionalService.Create";
            public const string Edit = "Permissions.RateInclusiveAdditionalService.Edit";
            public const string Delete = "Permissions.RateInclusiveAdditionalService.Delete";
            public const string Filter = "Permissions.RateInclusiveAdditionalService.Filter";
            public const string Group = "Permissions.RateInclusiveAdditionalService.Group";
            public const string Export = "Permissions.RateInclusiveAdditionalService.Export";
        }

        public static class RateInsuranceExcessPolicies
        {
            public const string View = "Permissions.RateInsuranceExcessPolicies.View";
            public const string Create = "Permissions.RateInsuranceExcessPolicies.Create";
            public const string Edit = "Permissions.RateInsuranceExcessPolicies.Edit";
            public const string Delete = "Permissions.RateInsuranceExcessPolicies.Delete";
            public const string Filter = "Permissions.RateInsuranceExcessPolicies.Filter";
            public const string Group = "Permissions.RateInsuranceExcessPolicies.Group";
            public const string Export = "Permissions.RateInsuranceExcessPolicies.Export";
        }

        public static class RateInsuranceExcessPolicyRates
        {
            public const string View = "Permissions.RateInsuranceExcessPolicyRates.View";
            public const string Create = "Permissions.RateInsuranceExcessPolicyRates.Create";
            public const string Edit = "Permissions.RateInsuranceExcessPolicyRates.Edit";
            public const string Delete = "Permissions.RateInsuranceExcessPolicyRates.Delete";
            public const string Filter = "Permissions.RateInsuranceExcessPolicyRates.Filter";
            public const string Group = "Permissions.RateInsuranceExcessPolicyRates.Group";
            public const string Export = "Permissions.RateInsuranceExcessPolicyRates.Export";
        }

        public static class Rates
        {
            public const string View = "Permissions.Rates.View";
            public const string Create = "Permissions.Rates.Create";
            public const string Edit = "Permissions.Rates.Edit";
            public const string Delete = "Permissions.Rates.Delete";
            public const string Filter = "Permissions.Rates.Filter";
            public const string Group = "Permissions.Rates.Group";
            public const string Export = "Permissions.Rates.Export";
        }

        public static class RateDetails
        {
            public const string View = "Permissions.RateDetails.View";
            public const string Create = "Permissions.RateDetails.Create";
            public const string Edit = "Permissions.RateDetails.Edit";
            public const string Delete = "Permissions.RateDetails.Delete";
            public const string Filter = "Permissions.RateDetails.Filter";
            public const string Group = "Permissions.RateDetails.Group";
            public const string Export = "Permissions.RateDetails.Export";
        }

        public static class RateDetailsDayIntervals
        {
            public const string View = "Permissions.RateDetailsDayIntervals.View";
            public const string Create = "Permissions.RateDetailsDayIntervals.Create";
            public const string Edit = "Permissions.RateDetailsDayIntervals.Edit";
            public const string Delete = "Permissions.RateDetailsDayIntervals.Delete";
            public const string Filter = "Permissions.RateDetailsDayIntervals.Filter";
            public const string Group = "Permissions.RateDetailsDayIntervals.Group";
            public const string Export = "Permissions.RateDetailsDayIntervals.Export";
        }

        public static class RateZone
        {
            public const string View = "Permissions.RateZone.View";
            public const string Create = "Permissions.RateZone.Create";
            public const string Edit = "Permissions.RateZone.Edit";
            public const string Delete = "Permissions.RateZone.Delete";
            public const string Filter = "Permissions.RateZone.Filter";
            public const string Group = "Permissions.RateZone.Group";
            public const string Export = "Permissions.RateZone.Export";
        }

        public static class RateZoneStation
        {
            public const string View = "Permissions.RateZoneStation.View";
            public const string Create = "Permissions.RateZoneStation.Create";
            public const string Edit = "Permissions.RateZoneStation.Edit";
            public const string Delete = "Permissions.RateZoneStation.Delete";
            public const string Filter = "Permissions.RateZoneStation.Filter";
            public const string Group = "Permissions.RateZoneStation.Group";
            public const string Export = "Permissions.RateZoneStation.Export";
        }

        public static class AccidentType
        {
            public const string View = "Permissions.AccidentType.View";
            public const string Create = "Permissions.AccidentType.Create";
            public const string Edit = "Permissions.AccidentType.Edit";
            public const string Delete = "Permissions.AccidentType.Delete";
            public const string Filter = "Permissions.AccidentType.Filter";
            public const string Group = "Permissions.AccidentType.Group";
            public const string Export = "Permissions.AccidentType.Export";
        }

        public static class DamageElement
        {
            public const string View = "Permissions.DamageElement.View";
            public const string Create = "Permissions.DamageElement.Create";
            public const string Edit = "Permissions.DamageElement.Edit";
            public const string Delete = "Permissions.DamageElement.Delete";
            public const string Filter = "Permissions.DamageElement.Filter";
            public const string Group = "Permissions.DamageElement.Group";
            public const string Export = "Permissions.DamageElement.Export";
        }

        public static class DamageArea
        {
            public const string View = "Permissions.DamageArea.View";
            public const string Create = "Permissions.DamageArea.Create";
            public const string Edit = "Permissions.DamageArea.Edit";
            public const string Delete = "Permissions.DamageArea.Delete";
            public const string Filter = "Permissions.DamageArea.Filter";
            public const string Group = "Permissions.DamageArea.Group";
            public const string Export = "Permissions.DamageArea.Export";
        }

        public static class AccidentStatus
        {
            public const string View = "Permissions.AccidentStatus.View";
        }

        public static class AccidentChargeoutType
        {
            public const string View = "Permissions.AccidentType.View";
        }

        public static class AccidentImageType
        {
            public const string View = "Permissions.AccidentImageType.View";
        }

        public static class AccidentDriverType
        {
            public const string View = "Permissions.AccidentDriverType.View";
            public const string Create = "Permissions.AccidentDriverType.Create";
            public const string Edit = "Permissions.AccidentDriverType.Edit";
            public const string Delete = "Permissions.AccidentDriverType.Delete";
            public const string Filter = "Permissions.AccidentDriverType.Filter";
            public const string Group = "Permissions.AccidentDriverType.Group";
            public const string Export = "Permissions.AccidentDriverType.Export";
        }

        public static class AccidentImage
        {
            public const string View = "Permissions.AccidentImage.View";
            public const string Create = "Permissions.AccidentImage.Create";
            public const string Edit = "Permissions.AccidentImage.Edit";
            public const string Delete = "Permissions.AccidentImage.Delete";
            public const string Filter = "Permissions.AccidentImage.Filter";
            public const string Group = "Permissions.AccidentImage.Group";
            public const string Export = "Permissions.AccidentImage.Export";
        }

        public static class Accident
        {
            public const string View = "Permissions.Accident.View";
            public const string Create = "Permissions.Accident.Create";
            public const string Edit = "Permissions.Accident.Edit";
            public const string Delete = "Permissions.Accident.Delete";
            public const string Filter = "Permissions.Accident.Filter";
            public const string Group = "Permissions.Accident.Group";
            public const string Export = "Permissions.Accident.Export";
        }

        public static class AccidentVehicle
        {
            public const string View = "Permissions.AccidentVehicle.View";
            public const string Create = "Permissions.AccidentVehicle.Create";
            public const string Edit = "Permissions.AccidentVehicle.Edit";
            public const string Delete = "Permissions.AccidentVehicle.Delete";
            public const string Filter = "Permissions.AccidentVehicle.Filter";
            public const string Group = "Permissions.AccidentVehicle.Group";
            public const string Export = "Permissions.AccidentVehicle.Export";
        }

        public static class DamageAreaBodyCordinates
        {
            public const string View = "Permissions.DamageAreaBodyCordinates.View";
            public const string Create = "Permissions.DamageAreaBodyCordinates.Create";
            public const string Edit = "Permissions.DamageAreaBodyCordinates.Edit";
            public const string Delete = "Permissions.DamageAreaBodyCordinates.Delete";
            public const string Filter = "Permissions.DamageAreaBodyCordinates.Filter";
            public const string Group = "Permissions.DamageAreaBodyCordinates.Group";
            public const string Export = "Permissions.DamageAreaBodyCordinates.Export";
        }

        public static class TrafficViolationType
        {
            public const string View = "Permissions.TrafficViolationType.View";
            public const string Create = "Permissions.TrafficViolationType.Create";
            public const string Edit = "Permissions.TrafficViolationType.Edit";
            public const string Delete = "Permissions.TrafficViolationType.Delete";
            public const string Filter = "Permissions.TrafficViolationType.Filter";
            public const string Group = "Permissions.TrafficViolationType.Group";
            public const string Export = "Permissions.TrafficViolationType.Export";
        }

        public static class TrafficViolation
        {
            public const string View = "Permissions.TrafficViolation.View";
            public const string Create = "Permissions.TrafficViolation.Create";
            public const string Edit = "Permissions.TrafficViolation.Edit";
            public const string Delete = "Permissions.TrafficViolation.Delete";
            public const string Filter = "Permissions.TrafficViolation.Filter";
            public const string Group = "Permissions.TrafficViolation.Group";
            public const string Export = "Permissions.TrafficViolation.Export";
        }

        public static class User
        {
            public const string View = "Permissions.User.View";
            public const string Create = "Permissions.User.Create";
            public const string Edit = "Permissions.User.Edit";
            public const string Delete = "Permissions.User.Delete";
            public const string Filter = "Permissions.User.Filter";
            public const string Group = "Permissions.User.Group";
            public const string Export = "Permissions.User.Export";
        }

        public static class DynamicDataType
        {
            public const string View = "Permissions.DynamicDataType.View";
        }

        public static class DynamicTypeSource
        {
            public const string View = "Permissions.DynamicTypeSource.View";
        }

        public static class DynamicType
        {
            public const string View = "Permissions.DynamicType.View";
            public const string Create = "Permissions.DynamicType.Create";
            public const string Edit = "Permissions.DynamicType.Edit";
            public const string Delete = "Permissions.DynamicType.Delete";
            public const string Filter = "Permissions.DynamicType.Filter";
            public const string Group = "Permissions.DynamicType.Group";
            public const string Export = "Permissions.DynamicType.Export";
        }

        public static class DynamicValue
        {
            public const string View = "Permissions.DynamicValue.View";
            public const string Create = "Permissions.DynamicValue.Create";
            public const string Edit = "Permissions.DynamicValue.Edit";
            public const string Delete = "Permissions.DynamicValue.Delete";
            public const string Filter = "Permissions.DynamicValue.Filter";
            public const string Group = "Permissions.DynamicValue.Group";
            public const string Export = "Permissions.DynamicValue.Export";
        }

        public static class VehiclePolicyType
        {
            public const string View = "Permissions.VehiclePolicyType.View";
        }

        public static class VehiclePolicy
        {
            public const string View = "Permissions.VehiclePolicy.View";
            public const string Create = "Permissions.VehiclePolicy.Create";
            public const string Edit = "Permissions.VehiclePolicy.Edit";
            public const string Delete = "Permissions.VehiclePolicy.Delete";
            public const string Filter = "Permissions.VehiclePolicy.Filter";
            public const string Group = "Permissions.VehiclePolicy.Group";
            public const string Export = "Permissions.VehiclePolicy.Export";
        }

        // GetPermitionList tanimlanan tüm yetkileri liste halinde döner. Yeni bir yetki grubu eklendiğide typeof(Permissions.*) tanımlaması yapılmalıdır.
        public static List<string> GetPermitionList()
        {
            List<string> permissions = new List<string>();
            try
            {
                foreach (var field in typeof(Permissions).GetNestedTypes())
                {
                    foreach (var item in field.GetFields())
                    {
                        if (item.FieldType.IsClass)
                            permissions.Add(item.GetValue(null).ToString());
                    }
                }
                return permissions;
            }
            catch
            {
                return permissions;
            }
        }
    }
}