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
		public List<clsPersona> Get()
		{
			clsListadoPersonas_BL listadoPersonas_BL = new clsListadoPersonas_BL();
			return listadoPersonas_BL.listadoCompletoPersonas_BL();
		}

		public clsPersona Get (int id)
		{
			clsPersona oPersona = new clsPersona();
			clsManejadoraPersona_BL manejadoraPersona_BL = new clsManejadoraPersona_BL();
			oPersona = manejadoraPersona_BL.BuscarPersonaPorID_BL(id);
			return oPersona;
		}

		public bool Post([FromBody]clsPersona persona)
		{
			clsManejadoraPersona_BL manejadoraPersona_BL = new clsManejadoraPersona_BL();
			return manejadoraPersona_BL.InsertarPersona_BL(persona) == 1 ? true : false;
		}

		public bool Delete(int id)
		{
			clsManejadoraPersona_BL manejadoraPersona_BL = new clsManejadoraPersona_BL();
			return manejadoraPersona_BL.BorrarPersonaPorID_BL(id) == 1 ? true : false;
		}

		public bool Put([FromBody]clsPersona persona)
		{
			clsManejadoraPersona_BL manejadoraPersona_BL = new clsManejadoraPersona_BL();
			return manejadoraPersona_BL.EditarPersona_BL(persona) == 1 ? true : false;
		}
	}
}
