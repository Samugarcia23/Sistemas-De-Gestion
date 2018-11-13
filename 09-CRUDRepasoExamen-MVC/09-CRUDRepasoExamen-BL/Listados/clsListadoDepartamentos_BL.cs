using _09_CRUDRepasoExamen_DAL.Listados;
using _09_CRUDRepasoExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CRUDRepasoExamen_BL.Listados
{
	public class clsListadoDepartamentos_BL
	{
		public List<clsDepartamento> listadoCompletoDepartamentos()
		{
			clsListadoDepartamentos_DAL lista_DAL = new clsListadoDepartamentos_DAL();
			List<clsDepartamento> lista_BL = new List<clsDepartamento>();
			lista_BL = lista_DAL.listadoDepartamentos();

			return lista_BL;
		}
	}
}
