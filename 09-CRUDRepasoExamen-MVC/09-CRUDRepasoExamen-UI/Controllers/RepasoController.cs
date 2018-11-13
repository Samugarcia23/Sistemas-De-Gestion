using _09_CRUDRepasoExamen_BL.Listado;
using _09_CRUDRepasoExamen_BL.Listados;
using _09_CRUDRepasoExamen_BL.Manejadoras;
using _09_CRUDRepasoExamen_Entidades;
using _09_CRUDRepasoExamen_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _09_CRUDRepasoExamen_UI.Controllers
{
    public class RepasoController : Controller
    {
        // GET: Repaso
        public ActionResult Index(int id = 0)
        {
			clsListadoPersonasDepartamento miViewmodel = new clsListadoPersonasDepartamento();
			List<clsPersona> listaPersonas = new List<clsPersona>();
			List<clsDepartamento> listaDepartamentos = new List<clsDepartamento>();
			clsListadoPersonas_BL listadoPersonas_BL = new clsListadoPersonas_BL();
			clsListadoDepartamentos_BL listadoDepartamentos_BL = new clsListadoDepartamentos_BL();

			try
			{
				if (id == 0)
				{

					listaDepartamentos = listadoDepartamentos_BL.listadoCompletoDepartamentos();
					miViewmodel.listaDepartamento = listaDepartamentos;
					miViewmodel.listaPersonasPorDepartamento = listaPersonas;
					
				} else
				{
					listaDepartamentos = listadoDepartamentos_BL.listadoCompletoDepartamentos();
					miViewmodel.listaDepartamento = listaDepartamentos;
					miViewmodel.idDepartamentoSeleccionado = id;
					miViewmodel.listaPersonasPorDepartamento = listadoPersonas_BL.listadoPersonasDepartamentos(miViewmodel.idDepartamentoSeleccionado);
				}
			}catch (Exception)
			{
				ViewData["IndexError"] = "Error";
			}

            return View(miViewmodel);
        }

		[HttpPost]
		public ActionResult Index(clsListadoPersonasDepartamento miViewmodel)
		{
			clsListadoPersonas_BL listadoPersonas_BL = new clsListadoPersonas_BL();
			clsListadoDepartamentos_BL listadoDepartamentos_BL = new clsListadoDepartamentos_BL();
			try
			{
				miViewmodel.listaPersonasPorDepartamento = listadoPersonas_BL.listadoPersonasDepartamentos(miViewmodel.idDepartamentoSeleccionado);
				miViewmodel.listaDepartamento = listadoDepartamentos_BL.listadoCompletoDepartamentos();
			}
			catch (Exception)
			{
				ViewData["IndexError"] = "Error";
			}
			return View(miViewmodel);
		}

		public ActionResult Edit(int id)
		{
			clsPersonaConNombreDeDepartamento oPersona = new clsPersonaConNombreDeDepartamento();
			clsManejadora_BL manejadora_BL = new clsManejadora_BL();
			try
			{
				oPersona = manejadora_BL.personaNombreDep_BL(id);
			}
			catch (Exception)
			{
				ViewData["EditError"] = "Error";
			}
			return View(oPersona);
		}

		[HttpPost]
		public ActionResult Edit(clsPersonaConNombreDeDepartamento oPersona)
		{
			clsManejadora_BL manejadora_BL = new clsManejadora_BL();
			int filas;

			try
			{
				filas = manejadora_BL.editarPersona_BL(oPersona);
				ViewData["EditCorrecto"] = $"Se ha actualizado {filas} fila correctamente";
			}
			catch (Exception)
			{
				ViewData["EditPostError"] = "Error";
			}
			return View(oPersona);
		}
    }
}