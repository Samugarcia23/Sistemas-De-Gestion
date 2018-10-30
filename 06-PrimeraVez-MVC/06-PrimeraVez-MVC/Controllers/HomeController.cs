using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06_PrimeraVez_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(Boolean? esMiPrimeraVez = true)
        {
			if (esMiPrimeraVez == true)
			{
				ViewBag.texto = "Es tu primera vez aqui";
			} else { ViewBag.texto = "Has entrado mas de una vez"; }
            return View();
        }


    }
}