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
using ServerApi.Models;
using ServerApi.Сlasses;

namespace ServerApi.Controllers
{
    public class ServicesController : ApiController
    {
        private OperatorEntities1 db = new OperatorEntities1();

        // GET: api/Services
        public IHttpActionResult GetServices()
        {
            return Ok(db.Services.ToList().ConvertAll(x => new ResponceServices(x)));
        }

        // GET: api/Services/5
        [ResponseType(typeof(Services))]
        public IHttpActionResult GetServices(int id)
        {
            var services = db.Services.Where(x => x.id_abonent == id).ToList();
            if (services == null)
            {
                return NotFound();
            }

            return Ok(services.ConvertAll(x => new ResponceServices(x)));
        }

        // PUT: api/Services/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServices(int id, Services services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != services.id_service)
            {
                return BadRequest();
            }

            db.Entry(services).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesExists(id))
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

        // POST: api/Services
        [ResponseType(typeof(Services))]
        public IHttpActionResult PostServices(Services services)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Services.Add(services);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = services.id_service }, services);
        }

        // DELETE: api/Services/5
        [ResponseType(typeof(Services))]
        public IHttpActionResult DeleteServices(int id)
        {
            var services = db.Services.FirstOrDefault(x => x.id_service == id);
            if (services == null)
            {
                return NotFound();
            }

            db.Services.Remove(services);
            db.SaveChanges();

            return Ok(services);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServicesExists(int id)
        {
            return db.Services.Count(e => e.id_service == id) > 0;
        }
    }
}