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
    public class AbonentsController : ApiController
    {
        private OperatorEntities1 db = new OperatorEntities1();

        // GET: api/Abonents
        public IHttpActionResult GetAbonents()
        {
            return Ok(db.Abonents.ToList().ConvertAll(x => new ResponseAbonents(x)));
        }

        // GET: api/Abonents/5
        [ResponseType(typeof(Abonents))]
        public IHttpActionResult GetAbonents(int id)
        {
            Abonents abonents = db.Abonents.Find(id);
            if (abonents == null)
            {
                return NotFound();
            }

            return Ok(abonents);
        }

        // PUT: api/Abonents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAbonents(int id, Abonents abonents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != abonents.id_abonent)
            {
                return BadRequest();
            }

            db.Entry(abonents).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbonentsExists(id))
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

        // POST: api/Abonents
        [ResponseType(typeof(Abonents))]
        public IHttpActionResult PostAbonents(Abonents abonents)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Abonents.Add(abonents);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = abonents.id_abonent }, abonents);
        }

        // DELETE: api/Abonents/5
        [ResponseType(typeof(Abonents))]
        public IHttpActionResult DeleteAbonents(int id)
        {
            Abonents abonents = db.Abonents.Find(id);
            if (abonents == null)
            {
                return NotFound();
            }

            db.Abonents.Remove(abonents);
            db.SaveChanges();

            return Ok(abonents);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AbonentsExists(int id)
        {
            return db.Abonents.Count(e => e.id_abonent == id) > 0;
        }
    }
}