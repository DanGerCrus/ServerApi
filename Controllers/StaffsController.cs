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
    public class StaffsController : ApiController
    {
        private OperatorEntities1 db = new OperatorEntities1();

        // GET: api/Staffs
        public IHttpActionResult GetStaff()
        {
            return Ok(db.Staff.ToList().ConvertAll(x => new ResponceStaff(x)));
        }

        // GET: api/Staffs/5
        [ResponseType(typeof(Staff))]
        public IHttpActionResult GetStaff(int id)
        {
            var staff = db.Staff.Where(x => x.id_staff == id).ToList();
            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff.ConvertAll(x => new ResponceStaff(x)));
        }

        // PUT: api/Staffs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStaff(int id, Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staff.id_staff)
            {
                return BadRequest();
            }

            db.Entry(staff).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        // POST: api/Staffs
        [ResponseType(typeof(Staff))]
        public IHttpActionResult PostStaff(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Staff.Add(staff);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = staff.id_staff }, staff);
        }

        // DELETE: api/Staffs/5
        [ResponseType(typeof(Staff))]
        public IHttpActionResult DeleteStaff(int id)
        {
            var staff = db.Staff.FirstOrDefault(x => x.id_staff == id);
            if (staff == null)
            {
                return NotFound();
            }

            db.Staff.Remove(staff);
            db.SaveChanges();

            return Ok(staff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StaffExists(int id)
        {
            return db.Staff.Count(e => e.id_staff == id) > 0;
        }
    }
}