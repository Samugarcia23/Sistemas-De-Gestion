using _08_CRUDPersonas_Entidades;
using Clas08_CRUDPersonas_BL.Listado;
using Clas08_CRUDPersonas_BL.Manejadoras;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _08_CRUDPersonas_UI.Controllers
{
	public class PersonasController : Controller
	{
		// GET: Personas
		/// <summary>
		/// Funcion que retorna el listado a la Vista
		/// </summary>
		/// <returns>listado completo de personas</returns>
		public ActionResult ListadoCompleto()
		{
			clsListadoPersonas_BL manejadora = new clsListadoPersonas_BL();
			List<clsPersona> listado = new List<clsPersona>();
			try
			{
				listado = manejadora.listadoCompletoPersonas_BL();
			}
			catch (Exception e)
			{
				throw e;
			}
			return View(listado);
		}

		/*Borrar || Actualizar || Detalles || Editar --> todos tendran el actioresult normal y el HTTPOST menos detalles*/

		public ActionResult Delete(int id) //Parametro de ruta (ver el RouteConfig)
		{
			clsPersona oPersona = new clsPersona();
			clsManejadoraPersona_BL manejadora_BL = new clsManejadoraPersona_BL();
			try
			{
				oPersona = manejadora_BL.BuscarPersonaPorID_BL(id);
			}
			catch (Exception e)
			{
				ViewData["Error"] = "Error no controlado"; //El try catch es necesario tanto aqui como en la capa DAL, en la capa BL no seria necesario
			}
			return View(oPersona);
		}

		[HttpPost, ActionName("Delete")]
		public ActionResult DeletePost(int id)
		{
			int filas;
			clsManejadoraPersona_BL manejadora = new clsManejadoraPersona_BL();
			clsListadoPersonas_BL manejadora_lista = new clsListadoPersonas_BL();
			List<clsPersona> listado = new List<clsPersona>();
			try
			{
				filas = manejadora.BorrarPersonaPorID_BL(id);
				listado = manejadora_lista.listadoCompletoPersonas_BL();
				ViewData["Filas"] = $"Filas afectadas: {filas}";
			}
			catch (Exception)
			{
				ViewData["Error"] = "No se puede Borrar"; //El try catch es necesario tanto aqui como en la capa DAL, en la capa BL no seria necesario
			}
			return View("ListadoCompleto", listado);

			//persona que no tenga ID para el insert
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(clsPersona oPersona)
		{
			return View();
		}
	}
}