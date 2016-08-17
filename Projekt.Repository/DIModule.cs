using Ninject.Extensions.Factory;
using Projekt.DAL;
using Projekt.Repository.Interface;
using Projekt.Repository.Repositories;

namespace Projekt.Repository
{
    internal class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IVehicleModelRepository>().To<VehicleModelRepository>();
            Bind<IVehicleMakeRepository>().To<VehicleMakeRepository>();

            Bind<IProjektContext>().To<ProjektContext>();
            Bind<IRepository>().To<Repositories.Repository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUnitOfWorkFactory>().ToFactory();
        }
    }
}