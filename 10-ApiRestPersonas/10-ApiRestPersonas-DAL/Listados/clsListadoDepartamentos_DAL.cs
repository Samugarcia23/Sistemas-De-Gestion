
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _10_ApiRestPersonas_Entidades;
using __10_ApiRestPersonas_DAL.Conexion;

namespace _10_ApiRestPersonas_DAL.Listados
{
	public class clsListadoDepartamentos_DAL
	{
		public List<clsDepartamento> listadoDepartamentos()
		{
			List<clsDepartamento> listado = new List<clsDepartamento>();
			clsDepartamento oDepartamento;
			clsMyConnection miConexion = new clsMyConnection();
			SqlConnection sqlConnection = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			try
			{
				sqlConnection = miConexion.getConnection();
				comando.CommandText = "SELECT * FROM Departamentos";
				lector = comando.ExecuteReader();
				comando.Connection = sqlConnection;

				if (lector.HasRows)
				{
					while (lector.Read())
					{
						oDepartamento = new clsDepartamento();
						//Definir los atributos
						oDepartamento.idDepartamento = (int)lector["idDepartamento"];
						oDepartamento.nombreDepartamento = (string)lector["nombreDepartamento"];
						//Añadir persona a la vista
						listado.Add(oDepartamento);
					}
				}
			}
			catch (SqlException e) { throw e; }
			finally
			{
				miConexion.closeConnection(ref sqlConnection);
				lector.Close();
			}
			return listado;
		}
	}
}
