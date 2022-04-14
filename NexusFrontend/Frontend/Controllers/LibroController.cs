using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;

namespace Frontend.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        public ActionResult Index()
        {
            return View();
        }

        // GET: Libro/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Libro/Create
        
        
        public async Task<ActionResult> Create()
        {
            var http = new HttpClient();
            var json = await http.GetStringAsync("http://localhost:59000/api/autor");
            var autorList = JsonConvert.DeserializeObject<List<autor>>(json);
            return View(autorList);

        }

        // POST: Libro/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection formCollection)
        {         
            if(formCollection["titulo"]!= string.Empty && formCollection["fecha"] != string.Empty && formCollection["genero"] != string.Empty && formCollection["paginas"] != string.Empty && formCollection["id_autor"] != string.Empty)
            {
                string _titulo = formCollection["titulo"];
                string _fecha = formCollection["fecha"];
                string _genero = formCollection["genero"];
                string _paginas = formCollection["paginas"];
                string _autor = formCollection["id_autor"];
                int paginas = int.Parse(_paginas);
                int autor = int.Parse(_autor);

                var data = new libro
                {
                    titulo = _titulo,
                    fecha = Convert.ToDateTime(_fecha),
                    genero = _genero,
                    paginas = paginas,
                    id_autor = autor
                };
                var url = "http://localhost:59000/api/libros";
                var http = new HttpClient();

                using (var httpclient = new HttpClient())
                {
                    var respuesta = await httpclient.PostAsJsonAsync(url, data);

                }
                TempData["Success"] = "Libro Añadido!";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "Hubo un problema al guardar el libro :c";
                return RedirectToAction("Index", "Home");
            }
        }

        // GET: Libro/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Libro/Edit/5
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

        // GET: Libro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Libro/Delete/5
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
