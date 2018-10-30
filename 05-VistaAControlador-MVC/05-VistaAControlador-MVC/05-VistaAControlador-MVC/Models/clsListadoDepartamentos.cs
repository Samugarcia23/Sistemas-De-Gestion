using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05_VistaAControlador_MVC.Models
{
	//Hay que crearlo en una carpeta llamada DAL(Acceso de datos)
	public class clsListadoDepartamentos
	{
		public List<clsDepartamento> listadoDepartamentos()
		{
			List<clsDepartamento> listado = new List<clsDepartamento>();
			listado.Add(new clsDepartamento(1, "Informatica"));
			listado.Add(new clsDepartamento(2, "Ciencias"));
			listado.Add(new clsDepartamento(3, "Historia"));
			listado.Add(new clsDepartamento(4, "Lengua"));
			return listado;
		}
	}
}