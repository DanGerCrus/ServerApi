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
    public class ContractsController : ApiController
    {
        private OperatorEntities1 db = new OperatorEntities1();

        // GET: api/Contracts
        public IHttpActionResult GetContracts()
        {
            return Ok(db.Contracts.ToList().ConvertAll(x => new ResponseContracts(x)));
        }
        
        // GET: api/Contracts/5
        [ResponseType(typeof(Contracts))]
        public IHttpActionResult GetContracts(int id)
        {
            var contracts = db.Contracts.Where(x => x.id_abonent == id).ToList();
            if (contracts == null)
            {
                return NotFound();
            }

            return Ok(contracts.ConvertAll(x => new ResponseContracts(x)));
        }

        // PUT: api/Contracts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContracts(int id, Contracts contracts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contracts.id_cotract)
            {
                return BadRequest();
            }

            db.Entry(contracts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractsExists(id))
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

        // POST: api/Contracts
        [ResponseType(typeof(Contracts))]
        public IHttpActionResult PostContracts(Contracts contracts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Contracts.Add(contracts);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contracts.id_cotract }, contracts);
        }

        // DELETE: api/Contracts/5
        [ResponseType(typeof(Contracts))]
        public IHttpActionResult DeleteContracts(int id)
        {
            var contracts = db.Contracts.FirstOrDefault(x => x.id_cotract == id);
            if (contracts == null)
            {
                return NotFound();
            }

            db.Contracts.Remove(contracts);
            db.SaveChanges();

            return Ok(contracts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContractsExists(int id)
        {
            return db.Contracts.Count(e => e.id_cotract == id) > 0;
        }
    }
}