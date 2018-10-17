using _03_MVC_Ejercicio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03_MVC_Ejercicio1.Controllers
{
    public class HomeController : Controller
    {
		/// <summary>
		/// Metodo del controlador el cual envia todos los datos requeridos a la vista, medianto una clase persona,
		/// un ViewBag con la fecha completa actual y un ViewData con un saludo segun la hora
		/// </summary>
		/// <returns></returns>
        // GET: Home
        public ActionResult Index()
        {
			//Declaracion de variables
			clsCalcularFecha fecha;
			fecha = new clsCalcularFecha();
			clsPersona oPersona = new clsPersona();

			//Envio por el viewBag de la fecha en formato largo
			ViewBag.Fecha = fecha.obtenerFecha();
			//Asignacion del saludo
			ViewData["Saludo"] = funSaludo();

			//Creamos un nuevo objeto persona y le asignamos propiedades
			oPersona.idPersona = 1;
			oPersona.nombre = "Samuel";
			oPersona.apellidos = "Garcia Preciado";
			oPersona.fechNacimiento = new DateTime(1997,10,29);
			oPersona.direccion = "Calle Falsa n/123";
			oPersona.telefono = "666666666";

			//Retornamos una vista Index enviandole como modelo un objeto de la clase persona
			return View(oPersona);
		}

		public ActionResult Listado()
		{
			clsListadoPersona lista = new clsListadoPersona();
			return View(lista);
		}

		/// <summary>
		/// Funcion para calcular la hora del dia
		/// </summary>
		/// <returns>String que cambia el contenido segun la hora</returns>
		String funSaludo()
		{
			//Declaracion de variables
			String saludo="";
			var hora = DateTime.Now.Hour;

			//Condicion para cuando la hora es de 7:00 a 13:00. Se pondra el mensaje 'Buenos Dias' 
			if (hora >= 7 && hora < 14)
			{
				saludo = "Buenos Dias";
			}
			else
			{
				//Condicion para cuando la hora es de 14:00 a 19:00. Se pondra el mensaje 'Buenas Tardes'
				if (hora >= 14 && hora < 20)
				{
					saludo = "Buenas Tardes";
				}
				else
				{
					//Condicion para cuando la hora es de 20:00 a 6:00. Se pondra el mensaje 'Buenas Noches'
					if (hora >= 20 && hora < 7)
					{
						saludo = "Buenas Noches";
					}
				}
			}
			return saludo;
		}
    }
}