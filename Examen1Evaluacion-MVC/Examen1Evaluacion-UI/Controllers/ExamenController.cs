using Examen1Evaluacion_BL.Listados;
using Examen1Evaluacion_BL.Manejadoras;
using Examen1Evaluacion_Entidades.Persistencia;
using Examen1Evaluacion_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Examen1Evaluacion_UI.Controllers
{
    public class ExamenController : Controller
    {
        // GET: Examen
		/// <summary>
		/// Funcion que devuelve el viewModel
		/// </summary>
		/// <param name="id"></param>
		/// <returns>miViewmodel</returns>
        public ActionResult Index()
        {
			clsListadosPersonajes miViewmodel = new clsListadosPersonajes();
			clsListadoPersonajes_BL listadoPersonajes_BL = new clsListadoPersonajes_BL();
			miViewmodel.listadoNombrePersonajes = listadoPersonajes_BL.listadoNombresPersonajes();

            return View(miViewmodel);
        }

		[HttpPost]
		public ActionResult Index(clsListadosPersonajes miViewmodel, string botonPulsado)
		{
			clsPersonaje oPersonaje = new clsPersonaje();
			clsManejadora_BL manejadora_BL = new clsManejadora_BL();
			if (botonPulsado.Equals("Editar"))
			{
				try
				{
					oPersonaje = manejadora_BL.AtributosPersonajePorId(miViewmodel.idPersonajeSeleccionado);
					miViewmodel.AtributosPersonajesPorId = oPersonaje;
				}
				catch (Exception)
				{
					ViewData["ErrorIndex"] = "Error";
				}
			}
			else
				if (botonPulsado.Equals("Guardar"))
				{

				}
			
			
			return View(miViewmodel);
		}
    }
}