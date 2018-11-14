using Examen1Evaluacion_BL.Listados;
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
		/// 
		clsListadoPersonajes_BL listadoPersonajes_BL = new clsListadoPersonajes_BL();
		public List<clsPersonaje> listadoNombrePersonajes { get; set; }
		public List<clsCategoria> listadoCategorias { get; set; }
		public clsPersonaje AtributosPersonajesPorId { get; set; }
		public int idPersonajeSeleccionado { get; set; }
		public string rutaImagen;

		#region Constructor por defecto

		public clsListadosPersonajes()
		{
			listadoNombrePersonajes = listadoPersonajes_BL.listadoNombresPersonajes();
			idPersonajeSeleccionado = 0;
			rutaImagen = "";
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