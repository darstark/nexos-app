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
    public class HomeController : Controller
    {
        
        public async Task<ActionResult> Index()
        {
            
            var http = new HttpClient();
            var json = await http.GetStringAsync("http://localhost:59000/api/libros");
            var librosList = JsonConvert.DeserializeObject<List<libro>>(json);
            return View(librosList);
        }
        
        public async Task<ActionResult> Registrar(FormCollection formCollection)
        {
            //var http = new HttpClient();
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
                fecha =  Convert.ToDateTime(_fecha),
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
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}