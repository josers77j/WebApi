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
    public class Tbl_RelacionController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Relacion
        public Tbl_RelacionController()
        {
            db.Configuration.ProxyCreationEnabled = false;

        }
        public IQueryable<Tbl_Relacion> GetTbl_Relacion()
        {
            return db.Tbl_Relacion;
        }

        // GET: api/Tbl_Relacion/5
        [ResponseType(typeof(Tbl_Relacion))]
        public IHttpActionResult GetTbl_Relacion(int id)
        {
            Tbl_Relacion tbl_Relacion = db.Tbl_Relacion.Find(id);
            if (tbl_Relacion == null)
            {
                return NotFound();
            }

            return Ok(tbl_Relacion);
        }

        // PUT: api/Tbl_Relacion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Relacion(int id, Tbl_Relacion tbl_Relacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Relacion.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Relacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_RelacionExists(id))
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

        // POST: api/Tbl_Relacion
        [ResponseType(typeof(Tbl_Relacion))]
        public IHttpActionResult PostTbl_Relacion(Tbl_Relacion tbl_Relacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Relacion.Add(tbl_Relacion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Relacion.ID }, tbl_Relacion);
        }

        // DELETE: api/Tbl_Relacion/5
        [ResponseType(typeof(Tbl_Relacion))]
        public IHttpActionResult DeleteTbl_Relacion(int id)
        {
            Tbl_Relacion tbl_Relacion = db.Tbl_Relacion.Find(id);
            if (tbl_Relacion == null)
            {
                return NotFound();
            }

            db.Tbl_Relacion.Remove(tbl_Relacion);
            db.SaveChanges();

            return Ok(tbl_Relacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_RelacionExists(int id)
        {
            return db.Tbl_Relacion.Count(e => e.ID == id) > 0;
        }
    }
}