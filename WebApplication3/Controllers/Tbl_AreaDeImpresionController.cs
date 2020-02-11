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
    public class Tbl_AreaDeImpresionController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_AreaDeImpresion
        public Tbl_AreaDeImpresionController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_AreaDeImpresion> GetTbl_AreaDeImpresion()
        {
            return db.Tbl_AreaDeImpresion;
        }

        // GET: api/Tbl_AreaDeImpresion/5
        [ResponseType(typeof(Tbl_AreaDeImpresion))]
        public IHttpActionResult GetTbl_AreaDeImpresion(int id)
        {
            Tbl_AreaDeImpresion tbl_AreaDeImpresion = db.Tbl_AreaDeImpresion.Find(id);
            if (tbl_AreaDeImpresion == null)
            {
                return NotFound();
            }

            return Ok(tbl_AreaDeImpresion);
        }

        // PUT: api/Tbl_AreaDeImpresion/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_AreaDeImpresion(int id, Tbl_AreaDeImpresion tbl_AreaDeImpresion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_AreaDeImpresion.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_AreaDeImpresion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_AreaDeImpresionExists(id))
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

        // POST: api/Tbl_AreaDeImpresion
        [ResponseType(typeof(Tbl_AreaDeImpresion))]
        public IHttpActionResult PostTbl_AreaDeImpresion(Tbl_AreaDeImpresion tbl_AreaDeImpresion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_AreaDeImpresion.Add(tbl_AreaDeImpresion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_AreaDeImpresion.ID }, tbl_AreaDeImpresion);
        }

        // DELETE: api/Tbl_AreaDeImpresion/5
        [ResponseType(typeof(Tbl_AreaDeImpresion))]
        public IHttpActionResult DeleteTbl_AreaDeImpresion(int id)
        {
            Tbl_AreaDeImpresion tbl_AreaDeImpresion = db.Tbl_AreaDeImpresion.Find(id);
            if (tbl_AreaDeImpresion == null)
            {
                return NotFound();
            }

            db.Tbl_AreaDeImpresion.Remove(tbl_AreaDeImpresion);
            db.SaveChanges();

            return Ok(tbl_AreaDeImpresion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_AreaDeImpresionExists(int id)
        {
            return db.Tbl_AreaDeImpresion.Count(e => e.ID == id) > 0;
        }
    }
}