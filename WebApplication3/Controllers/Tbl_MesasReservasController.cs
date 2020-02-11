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
    public class Tbl_MesasReservasController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_MesasReservas
        public Tbl_MesasReservasController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_MesasReservas> GetTbl_MesasReservas()
        {
            return db.Tbl_MesasReservas;
        }

        // GET: api/Tbl_MesasReservas/5
        [ResponseType(typeof(Tbl_MesasReservas))]
        public IHttpActionResult GetTbl_MesasReservas(int id)
        {
            Tbl_MesasReservas tbl_MesasReservas = db.Tbl_MesasReservas.Find(id);
            if (tbl_MesasReservas == null)
            {
                return NotFound();
            }

            return Ok(tbl_MesasReservas);
        }

        // PUT: api/Tbl_MesasReservas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_MesasReservas(int id, Tbl_MesasReservas tbl_MesasReservas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_MesasReservas.id)
            {
                return BadRequest();
            }

            db.Entry(tbl_MesasReservas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_MesasReservasExists(id))
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

        // POST: api/Tbl_MesasReservas
        [ResponseType(typeof(Tbl_MesasReservas))]
        public IHttpActionResult PostTbl_MesasReservas(Tbl_MesasReservas tbl_MesasReservas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_MesasReservas.Add(tbl_MesasReservas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_MesasReservas.id }, tbl_MesasReservas);
        }

        // DELETE: api/Tbl_MesasReservas/5
        [ResponseType(typeof(Tbl_MesasReservas))]
        public IHttpActionResult DeleteTbl_MesasReservas(int id)
        {
            Tbl_MesasReservas tbl_MesasReservas = db.Tbl_MesasReservas.Find(id);
            if (tbl_MesasReservas == null)
            {
                return NotFound();
            }

            db.Tbl_MesasReservas.Remove(tbl_MesasReservas);
            db.SaveChanges();

            return Ok(tbl_MesasReservas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_MesasReservasExists(int id)
        {
            return db.Tbl_MesasReservas.Count(e => e.id == id) > 0;
        }
    }
}