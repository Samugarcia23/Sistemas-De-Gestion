using _08_CRUDPersonas_DAL.Listado;
using _08_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clas08_CRUDPersonas_BL.Listado
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
