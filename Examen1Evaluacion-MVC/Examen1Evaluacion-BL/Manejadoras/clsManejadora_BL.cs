using Examen1Evaluacion_DAL.Manejadoras;
using Examen1Evaluacion_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1Evaluacion_BL.Manejadoras
{
	public class clsManejadora_BL
	{
		/// <summary>
		/// Funcion que devuelve los atributos de un personaje segun su id, llamando a la funcion 
		/// "AtributosPersonajePorId" de la clase manejadora de la capa DAL
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public clsPersonaje AtributosPersonajePorId(int id)
		{
			clsPersonaje oPersonaje = new clsPersonaje();
			clsManejadora_DAL manejadora_DAL = new clsManejadora_DAL();
			oPersonaje = manejadora_DAL.AtributosPersonajePorId(id);

			return oPersonaje;
		}
	}
}
