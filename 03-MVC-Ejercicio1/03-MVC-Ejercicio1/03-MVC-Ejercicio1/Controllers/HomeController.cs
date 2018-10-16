using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_MVC_Ejercicio1.Controllers
{
    public class HomeController : Controller
    {
		clsCalcularFecha fecha;

        // GET: Home
        public ActionResult Index()
        {
			fecha = new clsCalcularFecha(); 
			ViewData["Fecha"] = fecha.obtenerFecha();//Variable que devuelva el saludo segun la hora del dia

            return View();

		}
    }
}