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
    public class Tbl_ProductosController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Productos
        public Tbl_ProductosController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_Productos> GetTbl_Productos()
        {
            return db.Tbl_Productos;
        }

        // GET: api/Tbl_Productos/5
        [ResponseType(typeof(Tbl_Productos))]
        public IHttpActionResult GetTbl_Productos(int id)
        {
            Tbl_Productos tbl_Productos = db.Tbl_Productos.Find(id);
            if (tbl_Productos == null)
            {
                return NotFound();
            }

            return Ok(tbl_Productos);
        }

        // PUT: api/Tbl_Productos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Productos(int id, Tbl_Productos tbl_Productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Productos.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Productos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_ProductosExists(id))
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

        // POST: api/Tbl_Productos
        [ResponseType(typeof(Tbl_Productos))]
        public IHttpActionResult PostTbl_Productos(Tbl_Productos tbl_Productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Productos.Add(tbl_Productos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Productos.ID }, tbl_Productos);
        }

        // DELETE: api/Tbl_Productos/5
        [ResponseType(typeof(Tbl_Productos))]
        public IHttpActionResult DeleteTbl_Productos(int id)
        {
            Tbl_Productos tbl_Productos = db.Tbl_Productos.Find(id);
            if (tbl_Productos == null)
            {
                return NotFound();
            }

            db.Tbl_Productos.Remove(tbl_Productos);
            db.SaveChanges();

            return Ok(tbl_Productos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_ProductosExists(int id)
        {
            return db.Tbl_Productos.Count(e => e.ID == id) > 0;
        }
    }
}