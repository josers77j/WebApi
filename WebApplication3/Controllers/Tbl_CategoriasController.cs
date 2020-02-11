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
    public class Tbl_CategoriasController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Categorias
        public Tbl_CategoriasController()
        {
            db.Configuration.ProxyCreationEnabled = false;
        }
        public IQueryable<Tbl_Categorias> GetTbl_Categorias()
        {
            return db.Tbl_Categorias;
        }

        // GET: api/Tbl_Categorias/5
        [ResponseType(typeof(Tbl_Categorias))]
        public IHttpActionResult GetTbl_Categorias(int id)
        {
            Tbl_Categorias tbl_Categorias = db.Tbl_Categorias.Find(id);
            if (tbl_Categorias == null)
            {
                return NotFound();
            }

            return Ok(tbl_Categorias);
        }

        // PUT: api/Tbl_Categorias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Categorias(int id, Tbl_Categorias tbl_Categorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Categorias.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Categorias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_CategoriasExists(id))
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

        // POST: api/Tbl_Categorias
        [ResponseType(typeof(Tbl_Categorias))]
        public IHttpActionResult PostTbl_Categorias(Tbl_Categorias tbl_Categorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Categorias.Add(tbl_Categorias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Categorias.ID }, tbl_Categorias);
        }

        // DELETE: api/Tbl_Categorias/5
        [ResponseType(typeof(Tbl_Categorias))]
        public IHttpActionResult DeleteTbl_Categorias(int id)
        {
            Tbl_Categorias tbl_Categorias = db.Tbl_Categorias.Find(id);
            if (tbl_Categorias == null)
            {
                return NotFound();
            }

            db.Tbl_Categorias.Remove(tbl_Categorias);
            db.SaveChanges();

            return Ok(tbl_Categorias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_CategoriasExists(int id)
        {
            return db.Tbl_Categorias.Count(e => e.ID == id) > 0;
        }
    }
}