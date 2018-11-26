using _10_ApiRestPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using __10_ApiRestPersonas_Entidades;
using __10_ApiRestPersonas_DAL.Listados;

namespace _10_ApiRestPersonas_DAL.Listados
{
	public class clsListadoPersonasConNombreDep_BL
	{
		public List<clsPersonaConNombreDeDepartamento> listadoCompletoPersonasConNombreDep()
		{
			clsListadoPersonasConNombreDep_DAL lista_DAL = new clsListadoPersonasConNombreDep_DAL();
			List<clsPersonaConNombreDeDepartamento> lista_BL = new List<clsPersonaConNombreDeDepartamento>();
			lista_BL = lista_DAL.listadoCompletoPersonasConNombreDept();

			return lista_BL;
		}
	}
}
