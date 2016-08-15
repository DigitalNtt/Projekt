using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projekt.Model;
using Projekt.Model.Interface;
using Projekt.Web.ViewModels;

namespace Projekt.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Model.Mapping.AutoMapperMaps.Initialize();

            AutoMapper.Mapper.CreateMap<VehicleMakeViewModel, VehicleMakePoco>().ReverseMap();
            AutoMapper.Mapper.CreateMap<VehicleMakeViewModel, IVehicleMake>().ReverseMap();

            AutoMapper.Mapper.CreateMap<VehicleModelViewModel, VehicleModelPoco>().ReverseMap();
            AutoMapper.Mapper.CreateMap<VehicleModelViewModel, IVehicleModel>().ReverseMap();
        }
    }
}