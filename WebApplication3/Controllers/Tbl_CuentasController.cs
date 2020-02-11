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
    public class Tbl_CuentasController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Cuentas
        public Tbl_CuentasController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_Cuentas> GetTbl_Cuentas()
        {
            return db.Tbl_Cuentas;
        }

        // GET: api/Tbl_Cuentas/5
        [ResponseType(typeof(Tbl_Cuentas))]
        public IHttpActionResult GetTbl_Cuentas(int id)
        {
            Tbl_Cuentas tbl_Cuentas = db.Tbl_Cuentas.Find(id);
            if (tbl_Cuentas == null)
            {
                return NotFound();
            }

            return Ok(tbl_Cuentas);
        }

        // PUT: api/Tbl_Cuentas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Cuentas(int id, Tbl_Cuentas tbl_Cuentas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Cuentas.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Cuentas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_CuentasExists(id))
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

        // POST: api/Tbl_Cuentas
        [ResponseType(typeof(Tbl_Cuentas))]
        public IHttpActionResult PostTbl_Cuentas(Tbl_Cuentas tbl_Cuentas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Cuentas.Add(tbl_Cuentas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Cuentas.ID }, tbl_Cuentas);
        }

        // DELETE: api/Tbl_Cuentas/5
        [ResponseType(typeof(Tbl_Cuentas))]
        public IHttpActionResult DeleteTbl_Cuentas(int id)
        {
            Tbl_Cuentas tbl_Cuentas = db.Tbl_Cuentas.Find(id);
            if (tbl_Cuentas == null)
            {
                return NotFound();
            }

            db.Tbl_Cuentas.Remove(tbl_Cuentas);
            db.SaveChanges();

            return Ok(tbl_Cuentas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_CuentasExists(int id)
        {
            return db.Tbl_Cuentas.Count(e => e.ID == id) > 0;
        }
    }
}