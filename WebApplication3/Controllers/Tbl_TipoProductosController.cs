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
    public class Tbl_TipoProductosController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_TipoProductos
        public Tbl_TipoProductosController()
        {
            db.Configuration.ProxyCreationEnabled = false;

        }
        public IQueryable<Tbl_TipoProductos> GetTbl_TipoProductos()
        {
            return db.Tbl_TipoProductos;
        }

        // GET: api/Tbl_TipoProductos/5
        [ResponseType(typeof(Tbl_TipoProductos))]
        public IHttpActionResult GetTbl_TipoProductos(int id)
        {
            Tbl_TipoProductos tbl_TipoProductos = db.Tbl_TipoProductos.Find(id);
            if (tbl_TipoProductos == null)
            {
                return NotFound();
            }

            return Ok(tbl_TipoProductos);
        }

        // PUT: api/Tbl_TipoProductos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_TipoProductos(int id, Tbl_TipoProductos tbl_TipoProductos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_TipoProductos.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_TipoProductos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_TipoProductosExists(id))
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

        // POST: api/Tbl_TipoProductos
        [ResponseType(typeof(Tbl_TipoProductos))]
        public IHttpActionResult PostTbl_TipoProductos(Tbl_TipoProductos tbl_TipoProductos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_TipoProductos.Add(tbl_TipoProductos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_TipoProductos.ID }, tbl_TipoProductos);
        }

        // DELETE: api/Tbl_TipoProductos/5
        [ResponseType(typeof(Tbl_TipoProductos))]
        public IHttpActionResult DeleteTbl_TipoProductos(int id)
        {
            Tbl_TipoProductos tbl_TipoProductos = db.Tbl_TipoProductos.Find(id);
            if (tbl_TipoProductos == null)
            {
                return NotFound();
            }

            db.Tbl_TipoProductos.Remove(tbl_TipoProductos);
            db.SaveChanges();

            return Ok(tbl_TipoProductos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_TipoProductosExists(int id)
        {
            return db.Tbl_TipoProductos.Count(e => e.ID == id) > 0;
        }
    }
}