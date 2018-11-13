using _09_CRUDRepasoExamen_DAL.Listados;
using _09_CRUDRepasoExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CRUDRepasoExamen_BL.Listado
{
	/// <summary>
	/// Funcion que devuelve un listado completo instanciando el listado de la capa DAL
	/// Aqui se crearia la logica de negocio que se quiera usar (Ejemplo, mostrar solo las personas de un departamento)
	/// </summary>
	public class clsListadoPersonas_BL
	{
		public List<clsPersona> listadoCompletoPersonas_BL()
		{
			List<clsPersona> lista_BL = new List<clsPersona>();

			//instanciar un objeto de la clase clsListado_DAL
			clsListadoPersonasDepartamentos_DAL lista_DAL = new clsListadoPersonasDepartamentos_DAL();
			lista_BL = lista_DAL.listadoCompletoPersonas();

			return lista_BL;
		}

		public List<clsPersona> listadoPersonasDepartamentos(int idDepartamento)
		{
			clsListadoPersonasDepartamentos_DAL listado_DAL = new clsListadoPersonasDepartamentos_DAL();
			List<clsPersona> listado_BL = new List<clsPersona>();
			listado_BL = listado_DAL.listadoPersonasPorDepartamento(idDepartamento);

			return listado_BL;
		}
	}
}
