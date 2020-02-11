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
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class Tbl_EstadoController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Estado
        public Tbl_EstadoController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_Estado> GetTbl_Estado()
        {
            return db.Tbl_Estado;
        }

        // GET: api/Tbl_Estado/5
        [ResponseType(typeof(Tbl_Estado))]
        public IHttpActionResult GetTbl_Estado(int id)
        {
            Tbl_Estado tbl_Estado = db.Tbl_Estado.Find(id);
            if (tbl_Estado == null)
            {
                return NotFound();
            }

            return Ok(tbl_Estado);
        }

        // PUT: api/Tbl_Estado/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Estado(int id, Tbl_Estado tbl_Estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Estado.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Estado).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_EstadoExists(id))
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

        // POST: api/Tbl_Estado
        [ResponseType(typeof(Tbl_Estado))]
        public IHttpActionResult PostTbl_Estado(Tbl_Estado tbl_Estado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Estado.Add(tbl_Estado);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Estado.ID }, tbl_Estado);
        }

        // DELETE: api/Tbl_Estado/5
        [ResponseType(typeof(Tbl_Estado))]
        public IHttpActionResult DeleteTbl_Estado(int id)
        {
            Tbl_Estado tbl_Estado = db.Tbl_Estado.Find(id);
            if (tbl_Estado == null)
            {
                return NotFound();
            }

            db.Tbl_Estado.Remove(tbl_Estado);
            db.SaveChanges();

            return Ok(tbl_Estado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_EstadoExists(int id)
        {
            return db.Tbl_Estado.Count(e => e.ID == id) > 0;
        }
    }
}