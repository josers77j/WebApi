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
    public class Tbl_DetalleOrdenController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_DetalleOrden
        public Tbl_DetalleOrdenController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_DetalleOrden> GetTbl_DetalleOrden()
        {
            return db.Tbl_DetalleOrden;
        }

        // GET: api/Tbl_DetalleOrden/5
        [ResponseType(typeof(Tbl_DetalleOrden))]
        public IHttpActionResult GetTbl_DetalleOrden(int id)
        {
            Tbl_DetalleOrden tbl_DetalleOrden = db.Tbl_DetalleOrden.Find(id);
            if (tbl_DetalleOrden == null)
            {
                return NotFound();
            }

            return Ok(tbl_DetalleOrden);
        }

        // PUT: api/Tbl_DetalleOrden/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_DetalleOrden(int id, Tbl_DetalleOrden tbl_DetalleOrden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_DetalleOrden.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_DetalleOrden).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_DetalleOrdenExists(id))
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

        // POST: api/Tbl_DetalleOrden
        [ResponseType(typeof(Tbl_DetalleOrden))]
        public IHttpActionResult PostTbl_DetalleOrden(Tbl_DetalleOrden tbl_DetalleOrden)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_DetalleOrden.Add(tbl_DetalleOrden);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_DetalleOrden.ID }, tbl_DetalleOrden);
        }

        // DELETE: api/Tbl_DetalleOrden/5
        [ResponseType(typeof(Tbl_DetalleOrden))]
        public IHttpActionResult DeleteTbl_DetalleOrden(int id)
        {
            Tbl_DetalleOrden tbl_DetalleOrden = db.Tbl_DetalleOrden.Find(id);
            if (tbl_DetalleOrden == null)
            {
                return NotFound();
            }

            db.Tbl_DetalleOrden.Remove(tbl_DetalleOrden);
            db.SaveChanges();

            return Ok(tbl_DetalleOrden);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_DetalleOrdenExists(int id)
        {
            return db.Tbl_DetalleOrden.Count(e => e.ID == id) > 0;
        }
    }
}