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
    public class ApplicationsController : ApiController
    {
        private OperatorEntities1 db = new OperatorEntities1();

        // GET: api/Applications
        public IHttpActionResult GetApplications()
        {
            return Ok(db.Applications.ToList().ConvertAll(x => new ResponseApplications(x)));
        }

        // GET: api/Applications/5
        [ResponseType(typeof(Applications))]
        public IHttpActionResult GetApplications(int id)
        {
            var applications = db.Applications.Where(x => x.id_application == id).ToList();
            if (applications == null)
            {
                return NotFound();
            }

            return Ok(applications.ConvertAll(x => new ResponseApplications(x)));
        }

        // PUT: api/Applications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutApplications(int id, Applications applications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applications.id_application)
            {
                return BadRequest();
            }

            db.Entry(applications).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationsExists(id))
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

        // POST: api/Applications
        [ResponseType(typeof(Applications))]
        public IHttpActionResult PostApplications(Applications applications)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Applications.Add(applications);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = applications.id_application }, applications);
        }

        // DELETE: api/Applications/5
        [ResponseType(typeof(Applications))]
        public IHttpActionResult DeleteApplications(int id)
        {
            var applications = db.Applications.FirstOrDefault(x => x.id_application == id);
            if (applications == null)
            {
                return NotFound();
            }

            db.Applications.Remove(applications);
            db.SaveChanges();

            return Ok(applications);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationsExists(int id)
        {
            return db.Applications.Count(e => e.id_application == id) > 0;
        }
    }
}