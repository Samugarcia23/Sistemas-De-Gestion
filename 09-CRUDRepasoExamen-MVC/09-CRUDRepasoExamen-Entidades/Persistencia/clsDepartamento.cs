using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _09_CRUDRepasoExamen_Entidades
{
	public class clsDepartamento
	{
		#region Constructor por Defecto
		public clsDepartamento()
		{
			this.nombreDepartamento = "";
			this.idDepartamento = 0;
		}
		#endregion
		#region Constructor por parametros
		public clsDepartamento(int id, String nombre)
		{
			this.idDepartamento = id;
			this.nombreDepartamento = nombre;
		}
		#endregion
		#region atributos_Departamento
		public int idDepartamento { get; set; }
		public String nombreDepartamento { get; set; }
		#endregion
	}
}