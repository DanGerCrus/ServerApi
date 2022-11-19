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
    public class name_serviceController : ApiController
    {
        private OperatorEntities1 db = new OperatorEntities1();

        // GET: api/name_service
        public IHttpActionResult Getname_service()
        {
            return Ok(db.name_service.ToList().ConvertAll(x => new ResponseName_service(x)));
        }

        // GET: api/name_service/5
        [ResponseType(typeof(name_service))]
        public IHttpActionResult Getname_service(int id)
        {
            var name_service = db.name_service.Where(x => x.id_name_service == id).ToList();
            if (name_service == null)
            {
                return NotFound();
            }

            return Ok(name_service.ConvertAll(x => new ResponseName_service(x)));
        }

        // PUT: api/name_service/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putname_service(int id, name_service name_service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != name_service.id_name_service)
            {
                return BadRequest();
            }

            db.Entry(name_service).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!name_serviceExists(id))
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

        // POST: api/name_service
        [ResponseType(typeof(name_service))]
        public IHttpActionResult Postname_service(name_service name_service)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.name_service.Add(name_service);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (name_serviceExists(name_service.id_name_service))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = name_service.id_name_service }, name_service);
        }

        // DELETE: api/name_service/5
        [ResponseType(typeof(name_service))]
        public IHttpActionResult Deletename_service(int id)
        {
            var name_service = db.name_service.FirstOrDefault(x => x.id_name_service == id);
            if (name_service == null)
            {
                return NotFound();
            }

            db.name_service.Remove(name_service);
            db.SaveChanges();

            return Ok(name_service);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool name_serviceExists(int id)
        {
            return db.name_service.Count(e => e.id_name_service == id) > 0;
        }
    }
}