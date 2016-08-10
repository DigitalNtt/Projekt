using PagedList;
using Projekt.DAL;
using Projekt.DAL.Entities;
using Projekt.Model.Interface;
using Projekt.Repository.Filters;
using Projekt.Service.Interface;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using Projekt.Model;
using Projekt.ViewModels;

namespace Projekt.Web
{
    public class VehicleMakeController : Controller
    {
        private ProjektContext db = new ProjektContext();

        //protected IVehicleMakeService Service { get; private set; }

        //public VehicleMakeController(IVehicleMakeService service)
        //{
        //    this.Service = service;
        //}

        //public async Task<ActionResult> Index()
        //{
        //    var vehicleMakes = await Service.GetAsync();
        //    return View(vehicleMakes);
        //}

        //public async Task<ActionResult> Index(string searchString, string currentFilter, int pageNumber = 0, int pageSize = 0)
        //{
        //    var vehicleMakes = await Service.GetAsync(new VehicleMakeFilter(searchString, pageNumber, pageSize));
        //    return View(vehicleMakes);
        //}

        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    IVehicleMake vehicleMake = await Service.GetAsync(id);
        //    if (vehicleMake == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicleMake);
        //}

        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    IVehicleMake vehicleMake = await Service.GetAsync(id);
        //    if (vehicleMake == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(vehicleMake);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "id,Name,Abrv")] VehicleMakeViewModel vehicleMake)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        await Service.UpdateAsync(Mapper.Map<VehicleMakePoco>(vehicleMake));
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        // GET: VehicleMakes
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var makes = from s in db.VehicleMakes
                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                makes = makes.Where(s => s.Name.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    makes = makes.OrderByDescending(s => s.Name);
                    break;

                default:
                    makes = makes.OrderBy(s => s.Name);
                    break;
            }

            int pageSize = 15;
            int pageNumber = (page ?? 1);

            return View(makes.ToPagedList(pageNumber, pageSize));
        }

        // GET: VehicleMakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleMakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Abrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                db.VehicleMakes.Add(vehicleMake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicleMake);
        }

        // GET: VehicleMakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Abrv")] VehicleMake vehicleMake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleMake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleMake);
        }

        // GET: VehicleMakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            if (vehicleMake == null)
            {
                return HttpNotFound();
            }
            return View(vehicleMake);
        }

        // POST: VehicleMakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleMake vehicleMake = db.VehicleMakes.Find(id);
            db.VehicleMakes.Remove(vehicleMake);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}