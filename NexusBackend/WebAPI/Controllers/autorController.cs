using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class autorController : ApiController
    {
        private librosEntities db = new librosEntities();

        // GET: api/autor
        public IQueryable<autor> Getautor()
        {
            return db.autor;
        }

        // GET: api/autor/5
        [ResponseType(typeof(autor))]
        public async Task<IHttpActionResult> Getautor(int id)
        {
            autor autor = await db.autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            return Ok(autor);
        }

        // PUT: api/autor/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putautor(int id, autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != autor.id)
            {
                return BadRequest();
            }

            db.Entry(autor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!autorExists(id))
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

        // POST: api/autor
        [ResponseType(typeof(autor))]
        [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> Postautor(autor autor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.autor.Add(autor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = autor.id }, autor);
        }

        // DELETE: api/autor/5
        [ResponseType(typeof(autor))]
        public async Task<IHttpActionResult> Deleteautor(int id)
        {
            autor autor = await db.autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }

            db.autor.Remove(autor);
            await db.SaveChangesAsync();

            return Ok(autor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool autorExists(int id)
        {
            return db.autor.Count(e => e.id == id) > 0;
        }
    }
}