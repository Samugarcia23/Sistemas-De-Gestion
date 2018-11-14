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
        public ActionResult Index(int id = 0)
        {
			clsListadosPersonajes miViewmodel = new clsListadosPersonajes();
			clsPersonaje oPersonaje = new clsPersonaje();
			List<clsPersonaje> listadoNombres = new List<clsPersonaje>();
			clsListadoPersonajes_BL listadoPersonajes_BL = new clsListadoPersonajes_BL();
			clsManejadora_BL manejadora_BL = new clsManejadora_BL();
			
			try
			{
				if (id == 0)
				{
					listadoNombres = listadoPersonajes_BL.listadoNombresPersonajes();
					miViewmodel.listadoNombrePersonajes = listadoNombres;
					miViewmodel.AtributosPersonajesPorId = oPersonaje;
				}
				else
				{
					listadoNombres = listadoPersonajes_BL.listadoNombresPersonajes();
					oPersonaje = manejadora_BL.AtributosPersonajePorId(miViewmodel.idPersonajeSeleccionado);
					miViewmodel.listadoNombrePersonajes = listadoNombres;
					miViewmodel.idPersonajeSeleccionado = id;
					miViewmodel.AtributosPersonajesPorId = oPersonaje;
				}
			}
			catch (Exception)
			{
				ViewData["ErrorIndex"] = "Error";
			}
            return View(miViewmodel);
        }

		[HttpPost]
		public ActionResult Index(clsListadosPersonajes miViewmodel)
		{
			clsPersonaje oPersonaje = new clsPersonaje();
			clsManejadora_BL manejadora_BL = new clsManejadora_BL();
			try
			{
				oPersonaje = manejadora_BL.AtributosPersonajePorId(miViewmodel.idPersonajeSeleccionado);
				miViewmodel.AtributosPersonajesPorId = oPersonaje;
			}
			catch (Exception)
			{
				ViewData["ErrorIndex"] = "Error";
			}
			return View(miViewmodel);
		}
    }
}