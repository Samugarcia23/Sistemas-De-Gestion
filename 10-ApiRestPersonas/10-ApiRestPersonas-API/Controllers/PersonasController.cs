using __10_ApiRestPersonas_DAL.Manejadoras;
using __10_ApiRestPersonas_Entidades;
using _10_ApiRestPersonas_DAL.Listado;
using _10_ApiRestPersonas_DAL.Listados;
using _10_ApiRestPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _10_ApiRestPersonas_API.Controllers
{
    public class PersonasController : ApiController
    {
		/// <summary>
		/// Verbo get para peticiones de un listado completo de personas
		/// </summary>
		/// <returns>listado de personas</returns>
		public List<clsPersonaConNombreDeDepartamento> Get()
		{
			clsListadoPersonasConNombreDep_BL listadoPersonas_BL = new clsListadoPersonasConNombreDep_BL();
			return listadoPersonas_BL.listadoCompletoPersonasConNombreDep();
		}

		public clsPersona Get (int id)
		{
			clsPersona oPersona = new clsPersona();
			clsManejadoraPersona_BL manejadoraPersona_BL = new clsManejadoraPersona_BL();
			oPersona = manejadoraPersona_BL.BuscarPersonaPorID_BL(id);
			return oPersona;
		}
    }
}
