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
    public class Tbl_ClientesController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Clientes
        public Tbl_ClientesController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_Clientes> GetTbl_Clientes()
        {
            return db.Tbl_Clientes;
        }

        // GET: api/Tbl_Clientes/5
        [ResponseType(typeof(Tbl_Clientes))]
        public IHttpActionResult GetTbl_Clientes(int id)
        {
            Tbl_Clientes tbl_Clientes = db.Tbl_Clientes.Find(id);
            if (tbl_Clientes == null)
            {
                return NotFound();
            }

            return Ok(tbl_Clientes);
        }

        // PUT: api/Tbl_Clientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Clientes(int id, Tbl_Clientes tbl_Clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Clientes.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Clientes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_ClientesExists(id))
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

        // POST: api/Tbl_Clientes
        [ResponseType(typeof(Tbl_Clientes))]
        public IHttpActionResult PostTbl_Clientes(Tbl_Clientes tbl_Clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Clientes.Add(tbl_Clientes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Clientes.ID }, tbl_Clientes);
        }

        // DELETE: api/Tbl_Clientes/5
        [ResponseType(typeof(Tbl_Clientes))]
        public IHttpActionResult DeleteTbl_Clientes(int id)
        {
            Tbl_Clientes tbl_Clientes = db.Tbl_Clientes.Find(id);
            if (tbl_Clientes == null)
            {
                return NotFound();
            }

            db.Tbl_Clientes.Remove(tbl_Clientes);
            db.SaveChanges();

            return Ok(tbl_Clientes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_ClientesExists(int id)
        {
            return db.Tbl_Clientes.Count(e => e.ID == id) > 0;
        }
    }
}