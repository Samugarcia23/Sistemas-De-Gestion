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
	public class clsListadoPersonasConNombreDep_DAL
	{
		public List<clsPersonaConNombreDeDepartamento> listadoCompletoPersonasConNombreDept()
		{

			clsPersonaConNombreDeDepartamento oPersona;
			SqlConnection sqlConnection;
			List<clsPersonaConNombreDeDepartamento> ret = new List<clsPersonaConNombreDeDepartamento>();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector;
			clsMyConnection miConexion = new clsMyConnection();

			sqlConnection = miConexion.getConnection();
			comando.CommandText = "SELECT IDPersona,nombrePersona, apellidosPersona,fechaNacimiento,telefono,direccion, Departamentos.idDepartamento, nombreDepartamento FROM Personas INNER JOIN Departamentos ON Personas.IDDepartamento = Departamentos.IDDepartamento";
			comando.Connection = sqlConnection;
			lector = comando.ExecuteReader();

			if (lector.HasRows)
			{
				while (lector.Read())
				{

					oPersona = new clsPersonaConNombreDeDepartamento();
					oPersona.idPersona = (int)lector["IDPersona"];
					oPersona.nombre = (String)lector["nombrePersona"];
					oPersona.apellidos = (string)lector["apellidosPersona"];
					oPersona.fechNacimiento = (DateTime)lector["fechaNacimiento"];
					oPersona.telefono = (String)lector["telefono"];
					oPersona.direccion = (string)lector["direccion"];
					oPersona.idDepartamento = (int)lector["idDepartamento"];
					oPersona.nombreDepartamento = (string)lector["nombreDepartamento"];
					ret.Add(oPersona);

				}
			}

			lector.Close();
			miConexion.closeConnection(ref sqlConnection);

			return ret;

		}
	}
}
