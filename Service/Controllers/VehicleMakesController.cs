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
    public class VehicleMakesController : ApiController
    {
        private ProjektDBSQL db = new ProjektDBSQL();

        // GET: api/VehicleMakes
        public IQueryable<VehicleMake> GetVehicleMake()
        {
            return db.VehicleMake;
        }

        // GET: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMake))]
        public IHttpActionResult GetVehicleMake(decimal id)
        {
            VehicleMake vehicleMake = db.VehicleMake.Find(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(vehicleMake);
        }

        // PUT: api/VehicleMakes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleMake(decimal id, VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleMake.id)
            {
                return BadRequest();
            }

            db.Entry(vehicleMake).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleMakeExists(id))
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

        // POST: api/VehicleMakes
        [ResponseType(typeof(VehicleMake))]
        public IHttpActionResult PostVehicleMake(VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleMake.Add(vehicleMake);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleMake.id }, vehicleMake);
        }

        // DELETE: api/VehicleMakes/5
        [ResponseType(typeof(VehicleMake))]
        public IHttpActionResult DeleteVehicleMake(decimal id)
        {
            VehicleMake vehicleMake = db.VehicleMake.Find(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            db.VehicleMake.Remove(vehicleMake);
            db.SaveChanges();

            return Ok(vehicleMake);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleMakeExists(decimal id)
        {
            return db.VehicleMake.Count(e => e.id == id) > 0;
        }
    }
}