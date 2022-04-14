using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
    public class librosController : ApiController
    {
        private librosEntities db = new librosEntities();

        // GET: api/libros
        public IQueryable<libro> Getlibro()
        {
            return db.libro;
        }

        // GET: api/libros/5
        [ResponseType(typeof(libro))]
        public async Task<IHttpActionResult> Getlibro(int id)
        {
            libro libro = await db.libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            return Ok(libro);
        }

        // PUT: api/libros/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putlibro(int id, libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != libro.id)
            {
                return BadRequest();
            }

            db.Entry(libro).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!libroExists(id))
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

        // POST: api/libros
        [ResponseType(typeof(libro))]
        [ValidateAntiForgeryToken]
        public async Task<IHttpActionResult> Postlibro(libro libro)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    db.libro.Add(libro);
                    await db.SaveChangesAsync();

                    return CreatedAtRoute("DefaultApi", new { id = libro.id }, libro);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (DbEntityValidationException dbEx)
            {

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
            return CreatedAtRoute("DefaultApi", new { id = libro.id }, libro);


        }

        // DELETE: api/libros/5
        [ResponseType(typeof(libro))]
        public async Task<IHttpActionResult> Deletelibro(int id)
        {
            libro libro = await db.libro.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            db.libro.Remove(libro);
            await db.SaveChangesAsync();

            return Ok(libro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool libroExists(int id)
        {
            return db.libro.Count(e => e.id == id) > 0;
        }
    }
}