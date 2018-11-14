using Examen1Evaluacion_DAL.Conexiones;
using Examen1Evaluacion_Entidades.Persistencia;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen1Evaluacion_DAL.Manejadoras
{
	public class clsManejadora_DAL
	{
		/// <summary>
		/// Metodo que devolvera los atributos de un personaje segun su id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>clsPersonaje</returns>
		public clsPersonaje AtributosPersonajePorId(int id)
		{
			//Declaraciones
			clsPersonaje oPersonaje = new clsPersonaje();
			clsMyConnection miConexion = new clsMyConnection();
			SqlConnection sqlConnection = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			//Abrimos una nueva conexion
			sqlConnection = miConexion.getConnection();

			//Creamos una nueva sentencia a traves del CommandText
			comando.CommandText = "SELECT nombre, idPersonaje, alias, vida, regeneracion, danno, armadura, velAtaque," +
				" resistencia, velMovimiento, idCategoria FROM Personajes WHERE idPersonaje = @idPer";
			//Asignamos la conexion al comando
			comando.Connection = sqlConnection;
			//Asignamos el parametro del comando
			comando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
			//Asignamos el lector al comando
			lector = comando.ExecuteReader();

			if (lector.HasRows)
			{
				while (lector.Read())
				{

					oPersonaje.nombre = (string)lector["nombre"];
					oPersonaje.idPersonaje = (int)lector["idPersonaje"];
					oPersonaje.alias = (string)lector["alias"];
					oPersonaje.vida = (float)lector["vida"];
					oPersonaje.regeneracion = (float)lector["regeneracion"];
					oPersonaje.danno = (float)lector["danno"];
					oPersonaje.armadura = (float)lector["armadura"];
					oPersonaje.velAtaque = (float)lector["velAtaque"];
					oPersonaje.resistencia = (float)lector["resistencia"];
					oPersonaje.velMovimiento = (float)lector["velMovimiento"];
					oPersonaje.idCategoria = (int)lector["idCategoria"];
				}
			}

			lector.Close();
			miConexion.closeConnection(ref sqlConnection);

			return oPersonaje;
		}
	}
}
