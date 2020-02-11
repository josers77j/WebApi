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
    public class Tbl_UsuariosController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Usuarios
        public Tbl_UsuariosController()
        {
            db.Configuration.ProxyCreationEnabled = false;

        }
        public IQueryable<Tbl_Usuarios> GetTbl_Usuarios()
        {
            return db.Tbl_Usuarios;
        }

        // GET: api/Tbl_Usuarios/5
        [ResponseType(typeof(Tbl_Usuarios))]
        public IHttpActionResult GetTbl_Usuarios(int id)
        {
            Tbl_Usuarios tbl_Usuarios = db.Tbl_Usuarios.Find(id);
            if (tbl_Usuarios == null)
            {
                return NotFound();
            }

            return Ok(tbl_Usuarios);
        }

        // PUT: api/Tbl_Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Usuarios(int id, Tbl_Usuarios tbl_Usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Usuarios.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Usuarios).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_UsuariosExists(id))
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

        // POST: api/Tbl_Usuarios
        [ResponseType(typeof(Tbl_Usuarios))]
        public IHttpActionResult PostTbl_Usuarios(Tbl_Usuarios tbl_Usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Usuarios.Add(tbl_Usuarios);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Usuarios.ID }, tbl_Usuarios);
        }

        // DELETE: api/Tbl_Usuarios/5
        [ResponseType(typeof(Tbl_Usuarios))]
        public IHttpActionResult DeleteTbl_Usuarios(int id)
        {
            Tbl_Usuarios tbl_Usuarios = db.Tbl_Usuarios.Find(id);
            if (tbl_Usuarios == null)
            {
                return NotFound();
            }

            db.Tbl_Usuarios.Remove(tbl_Usuarios);
            db.SaveChanges();

            return Ok(tbl_Usuarios);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_UsuariosExists(int id)
        {
            return db.Tbl_Usuarios.Count(e => e.ID == id) > 0;
        }
    }
}