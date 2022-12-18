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
            var abonents = db.Abonents.Where(x => x.id_abonent == id).ToList();
            if (abonents == null)
            {
                return NotFound();
            }

            return Ok(abonents.ConvertAll(x => new ResponseAbonents(x)));
        }

        // PUT: api/Abonents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAbonents(Abonents abonents)
        {
            var abonent = db.Abonents.FirstOrDefault(x => x.id_abonent == abonents.id_abonent);
            if (abonent == null)
            {
                return Ok("Не найден");

            }
            abonent.Name = abonents.Name;
            abonent.MiddleName = abonents.MiddleName;
            abonent.LastName = abonents.LastName;
            db.SaveChangesAsync();
            return Ok(abonent);


        }

        // POST: api/Abonents
        [ResponseType(typeof(Abonents))]
        public IHttpActionResult PostAbonents(Abonents abonents)
        {
            abonents.number_phone = "+79245623241";
            abonents.passport_data = "4561 1234";
            abonents.adress = "чкалдоыфшар 87";
            abonents.personal_schet = "1234";
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
            var abonent = db.Abonents.FirstOrDefault(x => x.id_abonent == id);
            if (abonent == null)
            {
                return NotFound();
            }

            db.Abonents.Remove(abonent);
            db.SaveChanges();

            return Ok(abonent);
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