using Examen1Evaluacion_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen1Evaluacion_UI.ViewModels
{
	public class clsListadosPersonajes : clsPersonaje
	{
		/// <summary>
		/// Listados necesarios para la vista
		/// </summary>
		public List<clsPersonaje> listadoNombrePersonajes { get; set; }
		public clsPersonaje AtributosPersonajesPorId { get; set; }
		public int idPersonajeSeleccionado { get; set; }

		#region Constructor por defecto

		public clsListadosPersonajes()
		{

		}

		#endregion

		#region Constructor por parametros

		public clsListadosPersonajes(List<clsPersonaje> listadoNombres, clsPersonaje AtributosPorId)
		{
			this.listadoNombrePersonajes = listadoNombres;
			this.AtributosPersonajesPorId = AtributosPorId;
		}

		#endregion
	}
}