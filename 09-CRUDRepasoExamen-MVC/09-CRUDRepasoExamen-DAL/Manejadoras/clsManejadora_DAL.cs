using _09_CRUDRepasoExamen_DAL.Conexiones;
using _09_CRUDRepasoExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CRUDRepasoExamen_DAL.Manejadoras
{
	public class clsManejadora_DAL
	{
		public clsPersona BuscarPersonaPorID_DAL(int id)
		{
			clsPersona oPersona = new clsPersona();
			clsMyConnection miconexion = new clsMyConnection();
			SqlConnection sqlconnection = null;
			SqlCommand sqlCommand = new SqlCommand();
			SqlDataReader lector = null;
			List<clsPersona> lista = new List<clsPersona>();

			try
			{
				//Obtener conexion abierta	
				sqlconnection = miconexion.getConnection();

				//Definimos los parametros del comando
				sqlCommand.CommandText = "SELECT * FROM Personas WHERE idPersona=@id";

				/* Forma 1:
				 * Definimos el parametro @id
				*/
				SqlParameter param;
				param = new SqlParameter();
				param.ParameterName = "@id";
				param.SqlDbType = System.Data.SqlDbType.Int;
				param.Value = id;

				sqlCommand.Parameters.Add(param);

				//Definir la conexion
				sqlCommand.Connection = sqlconnection;

				//Ejecutar la consulta
				lector = sqlCommand.ExecuteReader();

				//Comprobar si el lector tiene filas y en caso afirmativo, recorrer
				if (lector.HasRows)
				{
					lector.Read();
					//Definir los atributos
					oPersona.idPersona = (int)lector["idPersona"];
					oPersona.nombre = (string)lector["nombrePersona"];
					oPersona.apellidos = (string)lector["apellidosPersona"];
					oPersona.fechNacimiento = (DateTime)lector["fechaNacimiento"];
					oPersona.direccion = (string)lector["direccion"];
					oPersona.telefono = (string)lector["telefono"];
					oPersona.idDepartamento = (int)lector["idDepartamento"];
				}

			}
			catch (SqlException e) { throw e; }
			finally
			{
				miconexion.closeConnection(ref sqlconnection);
				if (lector != null)
					lector.Close();
			}
			return oPersona;
		}

		public int EditarPersona_DAL(clsPersonaConNombreDeDepartamento persona)
		{
			clsMyConnection miconexion = new clsMyConnection();
			SqlConnection sqlconnection = null;
			SqlCommand sqlCommand = new SqlCommand();
			int filas;

			sqlconnection = miconexion.getConnection();

			sqlCommand.CommandText = "UPDATE Personas SET telefono = @telefono where IDPersona = @id";

			sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.idPersona;
			sqlCommand.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;

			sqlCommand.Connection = sqlconnection;

			filas = sqlCommand.ExecuteNonQuery();
			miconexion.closeConnection(ref sqlconnection);

			return filas;
		}

		public clsPersonaConNombreDeDepartamento personaConNombreDeDepartamento (int id)
		{
			clsPersonaConNombreDeDepartamento oPersona = new clsPersonaConNombreDeDepartamento(); ;
			SqlConnection sqlConnection;
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector;
			clsMyConnection miConexion = new clsMyConnection();

			sqlConnection = miConexion.getConnection();

			comando.CommandText = "SELECT IDPersona, apellidosPersona, nombrePersona,fechaNacimiento,telefono,direccion, Personas.idDepartamento, nombreDepartamento FROM Personas INNER JOIN Departamentos ON Personas.IDDepartamento = Departamentos.IDDepartamento WHERE idPersona = @id";
			comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
			comando.Connection = sqlConnection;
			lector = comando.ExecuteReader();

			if (lector.HasRows)
			{
				while (lector.Read())
				{

					oPersona.idPersona = (int)lector["IDPersona"];
					oPersona.apellidos = (string)lector["apellidosPersona"];
					oPersona.nombre = (String)lector["nombrePersona"];
					oPersona.fechNacimiento = (DateTime)lector["fechaNacimiento"];
					oPersona.telefono = (String)lector["telefono"];
					oPersona.direccion = (string)lector["direccion"];
					oPersona.idDepartamento = (int)lector["idDepartamento"];
					oPersona.nombreDepartamento = (string)lector["nombreDepartamento"];

				}
			}

			miConexion.closeConnection(ref sqlConnection);
			lector.Close();

			return oPersona;
		}

	}
}
