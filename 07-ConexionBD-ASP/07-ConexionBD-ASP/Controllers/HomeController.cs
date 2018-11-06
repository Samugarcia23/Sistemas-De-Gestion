using _07_ConexionBD_ASP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _07_ConexionBD_ASP.Controllers
{
	public class HomeController : Controller
	{
		// GET: Home
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost, ActionName("Index")]
		public ActionResult IndexPost()
		{
			SqlConnection connection = new SqlConnection();
			try
			{
				connection.ConnectionString = "server=serverpersonasdamsg.database.windows.net;database=personasDB;uid=Prueba;pwd=123qweasd!;";
				connection.Open();
				ViewData["Estado"] = connection.State;
			}
			catch (SqlException) { ViewData["Estado"] = "Error al intentar conectarse con la BD"; }
			finally
			{
				connection.Close();
			}
			return View();
		}

		public ActionResult ListadoPersonas()
		{
			//Aqui va todo el ejercicio pero mas adelante conectaremos con otra clase
			SqlConnection conexion = new SqlConnection();
			SqlCommand sqlCommand = new SqlCommand();
			SqlDataReader lector;
			clsPersona oPersona;
			List<clsPersona> listado = new List<clsPersona>();
			conexion.ConnectionString = "server=serverpersonasdamsg.database.windows.net;database=personasDB;uid=Prueba;pwd=123qweasd!;";
			try
			{
				conexion.Open();
				sqlCommand.CommandText = "Select * From Personas";
				sqlCommand.Connection = conexion;
				lector = sqlCommand.ExecuteReader();
				if (lector.HasRows)
				{
					while (lector.Read())
					{
						oPersona = new clsPersona();
						oPersona.idPersona = (int)lector["idPersona"];
						oPersona.nombre = (string)lector["nombre"];
						oPersona.apellidos = (string)lector["apellidos"];
						oPersona.fechNacimiento = (DateTime)lector["fechNacimiento"];
						oPersona.direccion = (string)lector["direccion"];
						oPersona.telefono = (string)lector["telefono"];
						oPersona.idDepartamento = (int)lector["idDepartamento"];
						listado.Add(oPersona);
					}
				}
				lector.Close();
			}
			catch (SqlException) { ViewData["Estado"] = "Error al intentar conectarse con la BD"; }
			finally { conexion.Close(); }
			return View(listado);
		}
	}
}