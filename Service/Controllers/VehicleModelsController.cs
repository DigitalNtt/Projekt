using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Service.Models;

namespace Service.Controllers
{
    public class VehicleModelsController : ApiController
    {
        private ProjektDBSQL db = new ProjektDBSQL();

        // GET: api/VehicleModels
        public IQueryable<VehicleModel> GetVehicleModel()
        {
            return db.VehicleModel;
        }

        // GET: api/VehicleModels/5
        [ResponseType(typeof(VehicleModel))]
        public IHttpActionResult GetVehicleModel(decimal id)
        {
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(vehicleModel);
        }

        // PUT: api/VehicleModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleModel(decimal id, VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleModel.id)
            {
                return BadRequest();
            }

            db.Entry(vehicleModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VehicleModels
        [ResponseType(typeof(VehicleModel))]
        public IHttpActionResult PostVehicleModel(VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleModel.Add(vehicleModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleModel.id }, vehicleModel);
        }

        // DELETE: api/VehicleModels/5
        [ResponseType(typeof(VehicleModel))]
        public IHttpActionResult DeleteVehicleModel(decimal id)
        {
            VehicleModel vehicleModel = db.VehicleModel.Find(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            db.VehicleModel.Remove(vehicleModel);
            db.SaveChanges();

            return Ok(vehicleModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleModelExists(decimal id)
        {
            return db.VehicleModel.Count(e => e.id == id) > 0;
        }
    }
}