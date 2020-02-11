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
    public class Tbl_RolesController : ApiController
    {
        private DB_A53C6D_lapiscinatestEntities db = new DB_A53C6D_lapiscinatestEntities();

        // GET: api/Tbl_Roles
        public Tbl_RolesController()
        {
            db.Configuration.ProxyCreationEnabled = false;

        }
        public IQueryable<Tbl_Roles> GetTbl_Roles()
        {
            return db.Tbl_Roles;
        }

        // GET: api/Tbl_Roles/5
        [ResponseType(typeof(Tbl_Roles))]
        public IHttpActionResult GetTbl_Roles(int id)
        {
            Tbl_Roles tbl_Roles = db.Tbl_Roles.Find(id);
            if (tbl_Roles == null)
            {
                return NotFound();
            }

            return Ok(tbl_Roles);
        }

        // PUT: api/Tbl_Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTbl_Roles(int id, Tbl_Roles tbl_Roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbl_Roles.ID)
            {
                return BadRequest();
            }

            db.Entry(tbl_Roles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tbl_RolesExists(id))
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

        // POST: api/Tbl_Roles
        [ResponseType(typeof(Tbl_Roles))]
        public IHttpActionResult PostTbl_Roles(Tbl_Roles tbl_Roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tbl_Roles.Add(tbl_Roles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tbl_Roles.ID }, tbl_Roles);
        }

        // DELETE: api/Tbl_Roles/5
        [ResponseType(typeof(Tbl_Roles))]
        public IHttpActionResult DeleteTbl_Roles(int id)
        {
            Tbl_Roles tbl_Roles = db.Tbl_Roles.Find(id);
            if (tbl_Roles == null)
            {
                return NotFound();
            }

            db.Tbl_Roles.Remove(tbl_Roles);
            db.SaveChanges();

            return Ok(tbl_Roles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tbl_RolesExists(int id)
        {
            return db.Tbl_Roles.Count(e => e.ID == id) > 0;
        }
    }
}