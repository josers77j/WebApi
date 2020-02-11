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
    public class Tbl_AreasController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Areas
        public Tbl_AreasController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_Areas> GetTbl_Areas()
        {
            return db.Tbl_Areas;
        }

        // GET: api/Tbl_Areas/5
        [ResponseType(typeof(Tbl_Areas))]
        public IHttpActionResult GetTbl_Areas(int id)
        {
            Tbl_Areas tbl_Areas = db.Tbl_Areas.Find(id);
            if (tbl_Areas == null)
            {
                return NotFound();
            }

            return Ok(tbl_Areas);
        }

        // PUT: api/Tbl_Areas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Areas(int id, Tbl_Areas tbl_Areas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Areas.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Areas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_AreasExists(id))
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

        // POST: api/Tbl_Areas
        [ResponseType(typeof(Tbl_Areas))]
        public IHttpActionResult PostTbl_Areas(Tbl_Areas tbl_Areas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Areas.Add(tbl_Areas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Areas.ID }, tbl_Areas);
        }

        // DELETE: api/Tbl_Areas/5
        [ResponseType(typeof(Tbl_Areas))]
        public IHttpActionResult DeleteTbl_Areas(int id)
        {
            Tbl_Areas tbl_Areas = db.Tbl_Areas.Find(id);
            if (tbl_Areas == null)
            {
                return NotFound();
            }

            db.Tbl_Areas.Remove(tbl_Areas);
            db.SaveChanges();

            return Ok(tbl_Areas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_AreasExists(int id)
        {
            return db.Tbl_Areas.Count(e => e.ID == id) > 0;
        }
    }
}