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
    public class Abonents_equipmentController : ApiController
    {
        private OperatorEntities1 db = new OperatorEntities1();

        // GET: api/Abonents_equipment
        public IHttpActionResult GetAbonents_equipment()
        {
            return Ok(db.Abonents_equipment.ToList().ConvertAll(x => new ResponseAbonents_equipment(x))); ;
        }

        // GET: api/Abonents_equipment/5
        [ResponseType(typeof(Abonents_equipment))]
        public IHttpActionResult GetAbonents_equipment(int id)
        {
            Abonents_equipment abonents_equipment = db.Abonents_equipment.Find(id);
            var Abonents_equipment = db.Abonents_equipment.Where(x => x.id_equipment == id).ToList();
            {
                return NotFound();
            }
#pragma warning disable CS0162 // Обнаружен недостижимый код
            return Ok(Abonents_equipment.ConvertAll(x => new ResponseAbonents_equipment(x)));
#pragma warning restore CS0162 // Обнаружен недостижимый код
        }

        // PUT: api/Abonents_equipment/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAbonents_equipment(int id, Abonents_equipment abonents_equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != abonents_equipment.id_equipment)
            {
                return BadRequest();
            }

            db.Entry(abonents_equipment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Abonents_equipmentExists(id))
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

        // POST: api/Abonents_equipment
        [ResponseType(typeof(Abonents_equipment))]
        public IHttpActionResult PostAbonents_equipment(Abonents_equipment abonents_equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Abonents_equipment.Add(abonents_equipment);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = abonents_equipment.id_equipment }, abonents_equipment);
        }

        // DELETE: api/Abonents_equipment/5
        [ResponseType(typeof(Abonents_equipment))]
        public IHttpActionResult DeleteAbonents_equipment(int id)
        {
            var Abonents_equipment  = db.Abonents_equipment.FirstOrDefault(x => x.id_equipment == id);
            if (Abonents_equipment == null)
            {
                return NotFound();
            }

            db.Abonents_equipment.Remove(Abonents_equipment);
            db.SaveChanges();

            return Ok(Abonents_equipment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Abonents_equipmentExists(int id)
        {
            return db.Abonents_equipment.Count(e => e.id_equipment == id) > 0;
        }
    }
}
