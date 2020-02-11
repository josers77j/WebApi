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
    public class Tbl_EmpleadosController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Empleados
        public Tbl_EmpleadosController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_Empleados> GetTbl_Empleados()
        {
            return db.Tbl_Empleados;
        }

        // GET: api/Tbl_Empleados/5
        [ResponseType(typeof(Tbl_Empleados))]
        public IHttpActionResult GetTbl_Empleados(int id)
        {
            Tbl_Empleados tbl_Empleados = db.Tbl_Empleados.Find(id);
            if (tbl_Empleados == null)
            {
                return NotFound();
            }

            return Ok(tbl_Empleados);
        }

        // PUT: api/Tbl_Empleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Empleados(int id, Tbl_Empleados tbl_Empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Empleados.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Empleados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_EmpleadosExists(id))
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

        // POST: api/Tbl_Empleados
        [ResponseType(typeof(Tbl_Empleados))]
        public IHttpActionResult PostTbl_Empleados(Tbl_Empleados tbl_Empleados)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Empleados.Add(tbl_Empleados);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Empleados.ID }, tbl_Empleados);
        }

        // DELETE: api/Tbl_Empleados/5
        [ResponseType(typeof(Tbl_Empleados))]
        public IHttpActionResult DeleteTbl_Empleados(int id)
        {
            Tbl_Empleados tbl_Empleados = db.Tbl_Empleados.Find(id);
            if (tbl_Empleados == null)
            {
                return NotFound();
            }

            db.Tbl_Empleados.Remove(tbl_Empleados);
            db.SaveChanges();

            return Ok(tbl_Empleados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_EmpleadosExists(int id)
        {
            return db.Tbl_Empleados.Count(e => e.ID == id) > 0;
        }
    }
}