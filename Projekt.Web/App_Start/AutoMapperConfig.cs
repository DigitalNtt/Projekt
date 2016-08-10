using Projekt.Model.Mapping;
using Projekt.Model;
using Projekt.Model.Interface;
using Projekt.ViewModels;
using AutoMapper;

namespace Projekt.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Initialize()
        {
            AutoMapperMaps.Initialize();
            Mapper.CreateMap<VehicleMakeViewModel, VehicleMakePoco>().ReverseMap();
            Mapper.CreateMap<VehicleMakeViewModel, IVehicleMake>().ReverseMap();
            Mapper.CreateMap<VehicleModelViewModel, VehicleModelPoco>().ReverseMap();
            Mapper.CreateMap<VehicleModelViewModel, IVehicleModel>().ReverseMap();
        }
    }
}