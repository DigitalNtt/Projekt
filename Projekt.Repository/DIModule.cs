using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Repository.Interface;
using Projekt.DAL;
using Projekt.Repository.Repositories;
using Ninject.Extensions.Factory;

namespace Projekt.Repository
{
    class DIModule : Ninject.Modules.NinjectModule
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
