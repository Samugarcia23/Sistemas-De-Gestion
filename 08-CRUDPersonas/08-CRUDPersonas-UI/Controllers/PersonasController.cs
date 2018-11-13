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
		}

		public ActionResult Create()
		{
			return View();
		}

		/// <summary>
		/// Funcion que recibe a la nueva persona y la inserta
		/// </summary>
		/// <param name="oPersona"></param>
		/// <returns></returns>
		[HttpPost]
		public ActionResult Create(clsPersona oPersona)
		{
			clsManejadoraPersona_BL manejadora_BL = new clsManejadoraPersona_BL();
			clsListadoPersonas_BL manejadora_lista = new clsListadoPersonas_BL();
			List<clsPersona> listado = new List<clsPersona>();
			int filas;

			try
			{
				filas = manejadora_BL.InsertarPersona_BL(oPersona);
				listado = manejadora_lista.listadoCompletoPersonas_BL();
				ViewData["InsertFilas"] = $"Se ha/n insertado {filas} fila/s: {oPersona.nombre } {oPersona.apellidos}";
			}
			catch(Exception)
			{
				ViewData["InsertError"] = "Error, no se ha podido insertar";
			}
			return View("ListadoCompleto", listado);
		}

		/// <summary>
		/// Funcion que retorna a la vista Edit una persona por su id, la persona que se quiere editar
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult Edit(int id)
		{
			clsPersona oPersona = new clsPersona();
			clsManejadoraPersona_BL manejadora_BL = new clsManejadoraPersona_BL();
			//El try catch es necesario tanto aqui como en la capa DAL, en la capa BL no seria necesario
			try
			{
				oPersona = manejadora_BL.BuscarPersonaPorID_BL(id);
			}
			catch (Exception e)
			{
				ViewData["Error"] = "Error no controlado"; 
			}
			
			return View(oPersona);
		}

		/// <summary>
		/// Funcion que recibe a la persona editada y la actualiza
		/// </summary>
		/// <param name="oPersona"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost, ActionName("Edit")]
		public ActionResult EditarPost(clsPersona oPersona)
		{
			clsManejadoraPersona_BL manejadora_BL = new clsManejadoraPersona_BL();
			clsListadoPersonas_BL manejadora_lista = new clsListadoPersonas_BL();
			List<clsPersona> listado = new List<clsPersona>();
			int filas;

			try
			{
				filas = manejadora_BL.EditarPersona_BL(oPersona);
				listado = manejadora_lista.listadoCompletoPersonas_BL();
				ViewData["EditFilas"] = $"Filas editadas: {filas}";
			}
			catch (Exception) { ViewData["ErrorEditar"] = "Error, no se ha podido editar"; }

			return View("ListadoCompleto", listado);
		}

		/// <summary>
		/// Funcion que retorna a la vista Detalles una persona por su id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult Details(int id)
		{
			clsPersona oPersona = new clsPersona();
			clsManejadoraPersona_BL manejadora_BL = new clsManejadoraPersona_BL();
			try
			{
				oPersona = manejadora_BL.BuscarPersonaPorID_BL(id);
			}
			catch (Exception)
			{
				ViewData["ErrorDetail"] = "Error, no se ha podido cargar";
			}
			return View(oPersona);
		}

		public ActionResult ListadoCompletoPersonaNombreDep()
		{
			List<clsPersonaConNombreDeDepartamento> listaCompleta = new List<clsPersonaConNombreDeDepartamento>();
			clsListadoPersonasConNombreDep_BL listado_BL = new clsListadoPersonasConNombreDep_BL();
			listaCompleta = listado_BL.listadoCompletoPersonasConNombreDep();
			return View(listaCompleta);
		}
	}
}