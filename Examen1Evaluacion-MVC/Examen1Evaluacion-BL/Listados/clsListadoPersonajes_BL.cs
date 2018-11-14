using Examen1Evaluacion_DAL.Listados;
using Examen1Evaluacion_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1Evaluacion_BL.Listados
{
	public class clsListadoPersonajes_BL
	{
		/// <summary>
		/// Funcion que devuelve un listado con los nombres de los personajes, llamando a la funcion
		/// "ListadoNombresPersonajes" de la clase "listadoPersonajes" la capa DAL
		/// </summary>
		/// <returns></returns>
		public List<clsPersonaje> listadoNombresPersonajes()
		{
			clsListadoPersonajes_DAL listadoPersonajes_DAL = new clsListadoPersonajes_DAL();
			List <clsPersonaje> listadoPersonajes_BL = new List<clsPersonaje>();
			listadoPersonajes_BL = listadoPersonajes_DAL.ListadoNombresPersonajes();

			return listadoPersonajes_BL;
		}
	}
}
