using _09_CRUDRepasoExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _09_CRUDRepasoExamen_UI.ViewModels
{
	public class clsListadoPersonasDepartamento
	{
		public List<clsPersona> listaPersonasPorDepartamento { get; set; }
		public List<clsDepartamento> listaDepartamento { get; set; }
		public int idDepartamentoSeleccionado { get; set; }

		public clsListadoPersonasDepartamento()
		{

		}

		public clsListadoPersonasDepartamento (List<clsPersona> listPersonasDep, List<clsDepartamento> listDep)
		{
			this.listaPersonasPorDepartamento = listPersonasDep;
			this.listaDepartamento = listDep;
		}
	}
}