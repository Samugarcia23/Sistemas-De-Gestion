using _05_VistaAControlador_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _05_VistaAControlador_MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

		/// <summary>
		/// Priimera Peticion de la vista Editar
		/// creamos un objeto de la clase persona y se lo enviamos a la vista
		/// </summary>
		/// <returns></returns>
        public ActionResult Editar()
        {
			//Declaracion de variables
			clsPersona oPersona = new clsPersona();

			//Creacion del objeto persona y adicion de las propiedades
			oPersona.nombre = "Samuel";
			oPersona.apellidos = "Garcia Preciado";
			oPersona.fechNacimiento = new DateTime(1997, 10, 29);
			oPersona.direccion = "Calle Falsa n/123";
			oPersona.telefono = "666666666";
			oPersona.idPersona = 01;

			return View(oPersona);
        }

		/// <summary>
		/// Envio del usuario desde la vista al controlador con los datos modificados
		/// </summary>
		/// <param name="oPersona"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Editar(clsPersona oPersona)
		{
			return View();
		}

		public ActionResult Mostrar()
		{
			return View();
		}
    }
}