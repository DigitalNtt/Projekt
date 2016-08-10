[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Projekt.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Projekt.App_Start.NinjectWebCommon), "Stop")]


namespace Projekt.App_Start
{
    using System;
    using System.Linq;
    using System.Web;
    using Ninject;
    using Ninject.Web.Common;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Projekt.Service.Interface;
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        private static IKernel CreateKernel()
        {
            var settings = new NinjectSettings();
            settings.LoadExtensions = true;
            settings.ExtensionSearchPatterns = settings.ExtensionSearchPatterns.Union(new string[] { "EvidencijaClanova.*.dll" }).ToArray();
            var kernel = new StandardKernel(settings);
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);

                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }
        private static void RegisterServices(IKernel kernel)
        {
            //var VehicleMakeService = kernel.Get<IVehicleMakeService>();
            //kernel.Rebind<IVehicleMakeService>().To(VehicleMakeService.GetType());

            //var VehicleModelService = kernel.Get<IVehicleModelService>();
            //kernel.Rebind<IVehicleModelService>().To(VehicleModelService.GetType());
            
        }
    }
}