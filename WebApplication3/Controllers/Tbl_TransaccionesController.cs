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
    public class Tbl_TransaccionesController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Transacciones
        public Tbl_TransaccionesController()
        {
            db.Configuration.ProxyCreationEnabled = false;

        }
        public IQueryable<Tbl_Transacciones> GetTbl_Transacciones()
        {
            return db.Tbl_Transacciones;
        }

        // GET: api/Tbl_Transacciones/5
        [ResponseType(typeof(Tbl_Transacciones))]
        public IHttpActionResult GetTbl_Transacciones(int id)
        {
            Tbl_Transacciones tbl_Transacciones = db.Tbl_Transacciones.Find(id);
            if (tbl_Transacciones == null)
            {
                return NotFound();
            }

            return Ok(tbl_Transacciones);
        }

        // PUT: api/Tbl_Transacciones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Transacciones(int id, Tbl_Transacciones tbl_Transacciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Transacciones.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Transacciones).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_TransaccionesExists(id))
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

        // POST: api/Tbl_Transacciones
        [ResponseType(typeof(Tbl_Transacciones))]
        public IHttpActionResult PostTbl_Transacciones(Tbl_Transacciones tbl_Transacciones)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Transacciones.Add(tbl_Transacciones);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Transacciones.ID }, tbl_Transacciones);
        }

        // DELETE: api/Tbl_Transacciones/5
        [ResponseType(typeof(Tbl_Transacciones))]
        public IHttpActionResult DeleteTbl_Transacciones(int id)
        {
            Tbl_Transacciones tbl_Transacciones = db.Tbl_Transacciones.Find(id);
            if (tbl_Transacciones == null)
            {
                return NotFound();
            }

            db.Tbl_Transacciones.Remove(tbl_Transacciones);
            db.SaveChanges();

            return Ok(tbl_Transacciones);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_TransaccionesExists(int id)
        {
            return db.Tbl_Transacciones.Count(e => e.ID == id) > 0;
        }
    }
}