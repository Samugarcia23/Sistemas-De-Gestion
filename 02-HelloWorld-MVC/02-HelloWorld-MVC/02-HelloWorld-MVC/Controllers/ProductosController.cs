using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02_HelloWorld_MVC.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            return View();
        }

		/// <summary>
		/// Accion del controlador que devuelve la vista listado
		/// </summary>
		/// <returns></returns>

		public ActionResult listado()
		{
			return View();
		}
    }
}