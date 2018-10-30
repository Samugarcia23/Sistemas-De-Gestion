using _05_VistaAControlador_MVC.Models;
using _05_VistaAControlador_MVC.Models.ViewModels;
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
		/// <returns>Los datos de la persona a la vista Editar</returns>
        public ActionResult Editar()
        {
			//Declaracion de variables
			List<clsDepartamento> lista = new List<clsDepartamento>();
			clsPersonaEnListadoDepartamentos persona = new clsPersonaEnListadoDepartamentos(1, "Samuel", "Garcia Preciado", new DateTime(), "Calle Falsa", "9999999999", 1, lista);

			return View(persona);
        }


		/// <summary>
		/// Envio del usuario desde la vista al controlador con los datos modificados
		/// </summary>
		/// <param name="oPersona"></param>
		/// <returns>La vista PersonaModificada con los nuevos Datos</returns>
		[HttpPost]
		public ActionResult Editar(clsPersonaEnListadoDepartamentos persona)
		{
			//TODO Codigo para relacionar cada persona con su departamento
			return View("PersonaModificada", persona);
		}
	}
}