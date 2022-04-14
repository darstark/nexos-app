using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace Frontend.Controllers
{
    public class AutorController : Controller
    {
        // GET: Autor
        public ActionResult Index()
        {
            return View();
        }

        // GET: Autor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Autor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection formCollection)
        {
            if (formCollection["nombre"] != string.Empty && formCollection["fecha_nacimiento"] != string.Empty && formCollection["ciudad_procedencia"] != string.Empty && formCollection["correo"] != string.Empty)
            {
                string nombre = formCollection["nombre"];
                string fecha_nacimiento = formCollection["fecha_nacimiento"];
                string ciudad_procedencia = formCollection["ciudad_procedencia"];
                string correo = formCollection["correo"];

                var data = new autor
                {
                    nombre = nombre,
                    fecha_nacimiento = Convert.ToDateTime(fecha_nacimiento),
                    ciudad_procedencia = ciudad_procedencia,
                    correo = correo

                };
                var url = "http://localhost:59000/api/autor";
                var http = new HttpClient();

                using (var httpclient = new HttpClient())
                {
                    var respuesta = await httpclient.PostAsJsonAsync(url, data);

                }
                TempData["Success"] = "Autor Añadido!";
                return RedirectToAction("Index", "Home");
                
            }
            else
            {
                TempData["Error"] = "Hubo un problema al guardar el autor :c";
                return RedirectToAction("Index", "Home");
            }
            
        }

        // GET: Autor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Autor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Autor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Autor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
