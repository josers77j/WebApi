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
    public class Tbl_UnionMesasController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_UnionMesas
        public Tbl_UnionMesasController()
        {
            db.Configuration.ProxyCreationEnabled = false;

        }
        public IQueryable<Tbl_UnionMesas> GetTbl_UnionMesas()
        {
            return db.Tbl_UnionMesas;
        }

        // GET: api/Tbl_UnionMesas/5
        [ResponseType(typeof(Tbl_UnionMesas))]
        public IHttpActionResult GetTbl_UnionMesas(int id)
        {
            Tbl_UnionMesas tbl_UnionMesas = db.Tbl_UnionMesas.Find(id);
            if (tbl_UnionMesas == null)
            {
                return NotFound();
            }

            return Ok(tbl_UnionMesas);
        }

        // PUT: api/Tbl_UnionMesas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_UnionMesas(int id, Tbl_UnionMesas tbl_UnionMesas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_UnionMesas.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_UnionMesas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_UnionMesasExists(id))
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

        // POST: api/Tbl_UnionMesas
        [ResponseType(typeof(Tbl_UnionMesas))]
        public IHttpActionResult PostTbl_UnionMesas(Tbl_UnionMesas tbl_UnionMesas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_UnionMesas.Add(tbl_UnionMesas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_UnionMesas.ID }, tbl_UnionMesas);
        }

        // DELETE: api/Tbl_UnionMesas/5
        [ResponseType(typeof(Tbl_UnionMesas))]
        public IHttpActionResult DeleteTbl_UnionMesas(int id)
        {
            Tbl_UnionMesas tbl_UnionMesas = db.Tbl_UnionMesas.Find(id);
            if (tbl_UnionMesas == null)
            {
                return NotFound();
            }

            db.Tbl_UnionMesas.Remove(tbl_UnionMesas);
            db.SaveChanges();

            return Ok(tbl_UnionMesas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_UnionMesasExists(int id)
        {
            return db.Tbl_UnionMesas.Count(e => e.ID == id) > 0;
        }
    }
}