using _08_CRUDPersonas_DAL.Conexion;
using _08_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_CRUDPersonas_DAL.Manejadoras
{
	
	public class clsManejadoraPersona_DAL
	{
		#region Funciones Manejadoras
		/// <summary>
		///	Funcion que devuelve una sola persona, buscandola por su id 
		/// </summary>
		/// <param name="id"></param>
		/// <returns>clsPersona</returns>
		public clsPersona BuscarPersonaPorID_DAL (int id)
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

				/*	Forma 2:
				 *	Se puede hacer de ambas formas
				*/
				/*sqlCommand.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = oPersona.nombre;
				sqlCommand.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = oPersona.apellidos;
				sqlCommand.Parameters.Add("@fechaNac", System.Data.SqlDbType.DateTime).Value = oPersona.fechNacimiento;
				sqlCommand.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = oPersona.direccion;
				sqlCommand.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = oPersona.telefono;
				sqlCommand.Parameters.Add("@departamento", System.Data.SqlDbType.Int).Value = oPersona.idDepartamento;*/

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

		/// <summary>
		/// Metodo para borrar una persona pasandole su id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>filas</returns>
		public int BorrarPersonaPorID(int id)
		{
			clsPersona oPersona = new clsPersona();
			clsMyConnection miconexion = new clsMyConnection();
			SqlConnection sqlconnection = null;
			SqlCommand sqlCommand = new SqlCommand();
			int filas;

			try
			{
				//Obtener conexion abierta	
				sqlconnection = miconexion.getConnection();

				//Definimos los parametros del comando
				sqlCommand.CommandText = "DELETE FROM Personas WHERE idPersona=@id";

				/* 
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

				//Ejecutar la sentencia
				filas = sqlCommand.ExecuteNonQuery();

			}
			catch (SqlException e) { throw e; }
			finally
			{
				miconexion.closeConnection(ref sqlconnection);
			}
			return filas;
		}

		/// <summary>
		/// Metodo que devuelve un nuevo objeto persona, creado desde la vista
		/// </summary>
		/// <returns>clsPersona</returns>
		public int InsertarPersona_DAL(clsPersona oPersona)
		{
			clsMyConnection miconexion = new clsMyConnection();
			SqlConnection sqlconnection = null;
			SqlCommand sqlCommand = new SqlCommand();
			int filas;

			try
			{
				//Obtener conexion abierta	
				sqlconnection = miconexion.getConnection();

				//Sentencia SQL
				sqlCommand.CommandText = "INSERT INTO Personas(nombrePersona, apellidosPersona, fechaNacimiento, direccion, telefono, idDepartamento) " +
					"VALUES (@nombre, @apellidos, @fechaNac, @direccion, @telefono, @departamento)";

				//Definicion de parametros
				sqlCommand.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = oPersona.nombre;
				sqlCommand.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = oPersona.apellidos;
				sqlCommand.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = oPersona.fechNacimiento;
				sqlCommand.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = oPersona.direccion;
				sqlCommand.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = oPersona.telefono;
				sqlCommand.Parameters.Add("@departamento", System.Data.SqlDbType.Int).Value = oPersona.idDepartamento;

				//Añadimos la conexion al comando
				sqlCommand.Connection = sqlconnection;

				//Ejecutamos el comando
				filas = sqlCommand.ExecuteNonQuery();	
				
			}
			catch (SqlException e){ throw e; }
			finally
			{
				//Cerramos la conexion
				miconexion.closeConnection(ref sqlconnection);
			}
			return filas;
		}

		/// <summary>
		/// Editamos una persona pasando su id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>clsPersona editada</returns>
		public int EditarPersona_DAL(clsPersona persona)
		{
			clsMyConnection miconexion = new clsMyConnection();
			SqlConnection sqlconnection = null;
			SqlCommand sqlCommand = new SqlCommand();
			int filas;

			try
			{
				sqlconnection = miconexion.getConnection();

				sqlCommand.CommandText = "UPDATE Personas SET nombrePersona = @nombre, apellidosPersona = @apellidos, fechaNacimiento = @fechaNac, direccion = @direccion, telefono = @telefono, idDepartamento = @departamento WHERE idPersona = @id";

				sqlCommand.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.idPersona;
				sqlCommand.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.nombre;
				sqlCommand.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.apellidos;
				sqlCommand.Parameters.Add("@fechaNac", System.Data.SqlDbType.Date).Value = persona.fechNacimiento;
				sqlCommand.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.direccion;
				sqlCommand.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.telefono;
				sqlCommand.Parameters.Add("@departamento", System.Data.SqlDbType.Int).Value = persona.idDepartamento;

				sqlCommand.Connection = sqlconnection;

				filas = sqlCommand.ExecuteNonQuery();
			}
			catch (SqlException e)
			{
				throw e;
			}
			finally
			{
				miconexion.closeConnection(ref sqlconnection);
			}

			return filas;
		}
		#endregion
	}
}
