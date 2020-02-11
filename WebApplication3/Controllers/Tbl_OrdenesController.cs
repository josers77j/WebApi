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
    public class Tbl_OrdenesController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Ordenes
        public Tbl_OrdenesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_Ordenes> GetTbl_Ordenes()
        {
            return db.Tbl_Ordenes;
        }

        // GET: api/Tbl_Ordenes/5
        [ResponseType(typeof(Tbl_Ordenes))]
        public IHttpActionResult GetTbl_Ordenes(int id)
        {
            Tbl_Ordenes tbl_Ordenes = db.Tbl_Ordenes.Find(id);
            if (tbl_Ordenes == null)
            {
                return NotFound();
            }

            return Ok(tbl_Ordenes);
        }

        // PUT: api/Tbl_Ordenes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Ordenes(int id, Tbl_Ordenes tbl_Ordenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Ordenes.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Ordenes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_OrdenesExists(id))
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

        // POST: api/Tbl_Ordenes
        [ResponseType(typeof(Tbl_Ordenes))]
        public IHttpActionResult PostTbl_Ordenes(Tbl_Ordenes tbl_Ordenes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Ordenes.Add(tbl_Ordenes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Ordenes.ID }, tbl_Ordenes);
        }

        // DELETE: api/Tbl_Ordenes/5
        [ResponseType(typeof(Tbl_Ordenes))]
        public IHttpActionResult DeleteTbl_Ordenes(int id)
        {
            Tbl_Ordenes tbl_Ordenes = db.Tbl_Ordenes.Find(id);
            if (tbl_Ordenes == null)
            {
                return NotFound();
            }

            db.Tbl_Ordenes.Remove(tbl_Ordenes);
            db.SaveChanges();

            return Ok(tbl_Ordenes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_OrdenesExists(int id)
        {
            return db.Tbl_Ordenes.Count(e => e.ID == id) > 0;
        }
    }
}