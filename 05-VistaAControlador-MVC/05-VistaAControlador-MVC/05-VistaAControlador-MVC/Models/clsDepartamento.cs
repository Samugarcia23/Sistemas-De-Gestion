using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05_VistaAControlador_MVC.Models
{
	public class clsDepartamento
	{
		#region Constructor por Defecto
		public clsDepartamento()
		{

		}
		#endregion
		#region Constructor por parametros
		public clsDepartamento(int idDepartamento, String nombreDepartamento)
		{
			this.idDepartamento = idDepartamento;
			this.nombreDepartamento = nombreDepartamento;
		}
		#endregion
		#region atributos_Departamento
		public int idDepartamento { get; set; }
		public String nombreDepartamento { get; set; }
		#endregion
	}
}