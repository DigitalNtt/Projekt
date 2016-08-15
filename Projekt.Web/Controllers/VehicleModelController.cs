using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekt.Web.ViewModels;
using Projekt.Service.Interface;
using Projekt.Model.Interface;
using Projekt.Model;
using Projekt.Repository.Filters;

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