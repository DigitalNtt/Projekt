using Projekt.Model.Interface;
using Projekt.DAL.Entities;

namespace Projekt.Model.Mapping
{
    public static class AutoMapperMaps
    {
        public static void Initialize()
        {
            AutoMapper.Mapper.CreateMap<VehicleMake, VehicleMakePoco>().ReverseMap();
            AutoMapper.Mapper.CreateMap<VehicleMake, IVehicleMake>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IVehicleMake, VehicleMakePoco>().ReverseMap();

            AutoMapper.Mapper.CreateMap<VehicleModel, VehicleModelPoco>().ReverseMap();
            AutoMapper.Mapper.CreateMap<VehicleModel, IVehicleModel>().ReverseMap();
            AutoMapper.Mapper.CreateMap<IVehicleModel, VehicleModelPoco>().ReverseMap();
        }
    }
}
