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
    public class Tbl_AccionesController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Acciones
        public Tbl_AccionesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_Acciones> GetTbl_Acciones()
        {
            return db.Tbl_Acciones;
        }

        // GET: api/Tbl_Acciones/5
        [ResponseType(typeof(Tbl_Acciones))]
        public IHttpActionResult GetTbl_Acciones(int id)
        {
            Tbl_Acciones tbl_Acciones = db.Tbl_Acciones.Find(id);
            if (tbl_Acciones == null)
            {
                return NotFound();
            }

            return Ok(tbl_Acciones);
        }

        // PUT: api/Tbl_Acciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Acciones(int id, Tbl_Acciones tbl_Acciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Acciones.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Acciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_AccionesExists(id))
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

        // POST: api/Tbl_Acciones
        [ResponseType(typeof(Tbl_Acciones))]
        public IHttpActionResult PostTbl_Acciones(Tbl_Acciones tbl_Acciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Acciones.Add(tbl_Acciones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Acciones.ID }, tbl_Acciones);
        }

        // DELETE: api/Tbl_Acciones/5
        [ResponseType(typeof(Tbl_Acciones))]
        public IHttpActionResult DeleteTbl_Acciones(int id)
        {
            Tbl_Acciones tbl_Acciones = db.Tbl_Acciones.Find(id);
            if (tbl_Acciones == null)
            {
                return NotFound();
            }

            db.Tbl_Acciones.Remove(tbl_Acciones);
            db.SaveChanges();

            return Ok(tbl_Acciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_AccionesExists(int id)
        {
            return db.Tbl_Acciones.Count(e => e.ID == id) > 0;
        }
    }
}