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
    public class Tbl_MesasController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Mesas
        public Tbl_MesasController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_Mesas> GetTbl_Mesas()
        {
            return db.Tbl_Mesas;
        }

        // GET: api/Tbl_Mesas/5
        [ResponseType(typeof(Tbl_Mesas))]
        public IHttpActionResult GetTbl_Mesas(int id)
        {
            Tbl_Mesas tbl_Mesas = db.Tbl_Mesas.Find(id);
            if (tbl_Mesas == null)
            {
                return NotFound();
            }

            return Ok(tbl_Mesas);
        }

        // PUT: api/Tbl_Mesas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Mesas(int id, Tbl_Mesas tbl_Mesas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Mesas.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Mesas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_MesasExists(id))
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

        // POST: api/Tbl_Mesas
        [ResponseType(typeof(Tbl_Mesas))]
        public IHttpActionResult PostTbl_Mesas(Tbl_Mesas tbl_Mesas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Mesas.Add(tbl_Mesas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Mesas.ID }, tbl_Mesas);
        }

        // DELETE: api/Tbl_Mesas/5
        [ResponseType(typeof(Tbl_Mesas))]
        public IHttpActionResult DeleteTbl_Mesas(int id)
        {
            Tbl_Mesas tbl_Mesas = db.Tbl_Mesas.Find(id);
            if (tbl_Mesas == null)
            {
                return NotFound();
            }

            db.Tbl_Mesas.Remove(tbl_Mesas);
            db.SaveChanges();

            return Ok(tbl_Mesas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_MesasExists(int id)
        {
            return db.Tbl_Mesas.Count(e => e.ID == id) > 0;
        }
    }
}