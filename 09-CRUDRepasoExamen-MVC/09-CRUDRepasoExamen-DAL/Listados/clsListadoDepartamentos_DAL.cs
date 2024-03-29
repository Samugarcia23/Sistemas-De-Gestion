﻿using _09_CRUDRepasoExamen_DAL.Conexiones;
using _09_CRUDRepasoExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CRUDRepasoExamen_DAL.Listados
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
				comando.Connection = sqlConnection;
				lector = comando.ExecuteReader();

				if (lector.HasRows)
				{
					while (lector.Read())
					{
						oDepartamento = new clsDepartamento();	
						oDepartamento.idDepartamento = (int)lector["idDepartamento"];
						oDepartamento.nombreDepartamento = (string)lector["nombreDepartamento"];
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
