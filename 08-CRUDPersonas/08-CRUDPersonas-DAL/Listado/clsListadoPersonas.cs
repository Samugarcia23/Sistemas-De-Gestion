using _08_CRUDPersonas_DAL.Conexion;
using _08_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CRUDPersonas_DAL.Listado
{
	public class clsListadoPersonas
	{
		public List<clsPersona> listadoCompletoPersonas()
		{
			clsMyConnection miconexion = new clsMyConnection();
			SqlConnection sqlconnection = miconexion.getConnection();
			SqlCommand sqlCommand = new SqlCommand();
			SqlDataReader lector;
			clsPersona oPersona;
			List <clsPersona> lista = new List<clsPersona>();
			string error = "";
			try
			{
				sqlCommand.CommandText = "Select * From Personas";
				sqlCommand.Connection = sqlconnection;
				lector = sqlCommand.ExecuteReader();
				if (lector.HasRows)
				{
					while (lector.Read())
					{
						oPersona = new clsPersona();
						oPersona.idPersona = (int)lector["idPersona"];
						oPersona.nombre = (string)lector["nombrePersona"];
						oPersona.apellidos = (string)lector["apellidosPersona"];
						oPersona.fechNacimiento = (DateTime)lector["fechaNacimiento"];
						oPersona.direccion = (string)lector["direccion"];
						oPersona.telefono = (string)lector["telefono"];
						oPersona.idDepartamento = (int)lector["idDepartamento"];
						lista.Add(oPersona);
					}
				}
				lector.Close();
			}
			catch (SqlException) { error = "Error al intentar conectarse con la BD"; }
			finally { miconexion.closeConnection(ref sqlconnection); }

			return lista;
		}
	}
}
