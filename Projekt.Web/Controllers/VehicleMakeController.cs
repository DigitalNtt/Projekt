using Projekt.Model;
using Projekt.Model.Interface;
using Projekt.Service.Interface;
using Projekt.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Projekt.Web.Controllers
{
    public class VehicleMakeController : Controller
    {
        protected IVehicleMakeService Service { get; private set; }

        public VehicleMakeController(IVehicleMakeService service)
        {
            this.Service = service;
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<IVehicleMake> VehicleMakes = await Service.GetAsync();
            return View(AutoMapper.Mapper.Map<List<VehicleMakePoco>>(VehicleMakes));
        }

        public async Task<ActionResult> Details(int id)
        {
            IVehicleMake VehicleMake = await Service.GetAsync(id);
            if (VehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(VehicleMake);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Name,Abrv")] VehicleMakeViewModel VehicleMake)
        {
            if (ModelState.IsValid)
            {
                await Service.AddAsync(AutoMapper.Mapper.Map<VehicleMakePoco>(VehicleMake));
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            IVehicleMake VehicleMake = await Service.GetAsync(id);
            if (VehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(VehicleMake);
        }

        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Abrv")] VehicleMakeViewModel VehicleMake)
        {
            if (ModelState.IsValid)
            {
                await Service.UpdateAsync(AutoMapper.Mapper.Map<VehicleMakePoco>(VehicleMake));
                return RedirectToAction("Index");
            }
            return View();
        }

        //// GET: VehicleMake
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}