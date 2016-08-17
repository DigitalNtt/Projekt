using Projekt.Service.Interface;

namespace Projekt.Service
{
    internal class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleModelService>().To<VehicleModelService>();
            Bind<IVehicleMakeService>().To<VehicleMakeService>();
        }
    }
}