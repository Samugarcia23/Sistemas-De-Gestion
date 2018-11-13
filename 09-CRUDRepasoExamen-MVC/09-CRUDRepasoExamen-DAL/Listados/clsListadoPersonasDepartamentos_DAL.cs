using _09_CRUDRepasoExamen_DAL.Conexiones;
using _09_CRUDRepasoExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CRUDRepasoExamen_DAL.Listados
{
	public class clsListadoPersonasDepartamentos_DAL
	{
		/// <summary>
		/// Funcion que devuelve un List de objetos personas
		/// Devolvera una lista vacia si ha habido un error o no se ha podido establecer conexion
		/// </summary>
		/// <returns>Lista de personas</returns>
		public List<clsPersona> listadoCompletoPersonas()
		{
			clsMyConnection miconexion = new clsMyConnection();
			SqlConnection sqlconnection = null;
			SqlCommand sqlCommand = new SqlCommand();
			SqlDataReader lector = null;
			clsPersona oPersona;
			List <clsPersona> lista = new List<clsPersona>();

			try
			{
				//Obtener conexion abierta	
				sqlconnection = miconexion.getConnection();

				//Definimos los parametros del comando
				sqlCommand.CommandText = "SELECT * FROM Personas";
				//Definir la conexion
				sqlCommand.Connection = sqlconnection;

				//Ejecutar la consulta
				lector = sqlCommand.ExecuteReader();
				//Comprobar si el lector tiene filas y en caso afirmativo, recorrer
				if (lector.HasRows)
				{
					while (lector.Read())
					{
						oPersona = new clsPersona();
						//Definir los atributos
						oPersona.idPersona = (int)lector["idPersona"];
						oPersona.nombre = (string)lector["nombrePersona"];
						oPersona.apellidos = (string)lector["apellidosPersona"];
						oPersona.fechNacimiento = (DateTime)lector["fechaNacimiento"];
						oPersona.direccion = (string)lector["direccion"];
						oPersona.telefono = (string)lector["telefono"];
						oPersona.idDepartamento = (int)lector["idDepartamento"];
						//Añadir persona a la vista
						lista.Add(oPersona);
					}
				}
				
			}
			catch (SqlException e) { throw e; }
			finally
			{
				miconexion.closeConnection(ref sqlconnection);
				if (lector!=null)
					lector.Close();
			}

			return lista;
		}
	}
}
