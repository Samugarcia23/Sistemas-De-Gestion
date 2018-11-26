using _10_ApiRestPersonas_DAL.Listados;
using _10_ApiRestPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_ApiRestPersonas_DAL.Listado
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
			clsListadoPersonas_DAL lista_DAL = new clsListadoPersonas_DAL();
			lista_BL = lista_DAL.listadoCompletoPersonas();

			return lista_BL;
		}
	}
}
