using Projekt.Model;
using Projekt.Model.Interface;
using Projekt.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Projekt.Web.Controllers
{
    public class VehicleModelController : Controller
    {
        protected IVehicleModelService Service { get; private set; }

        public VehicleModelController(IVehicleModelService service)
        {
            this.Service = service;
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<IVehicleModel> VehicleModels = await Service.GetAsync();
            return View(AutoMapper.Mapper.Map<List<VehicleModelPoco>>(VehicleModels));
        }

        //// GET: VehicleMake
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}