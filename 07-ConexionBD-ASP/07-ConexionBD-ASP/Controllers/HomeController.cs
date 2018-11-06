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
			//Creamos una nueva conexion
			SqlConnection conexion = new SqlConnection();
			//Creamos un nuevo comando sql (SQL STATEMENTS)
			SqlCommand sqlCommand = new SqlCommand();
			//Creamos un nuevo lector
			SqlDataReader lector;

			//Creamos un nuevo objeto persona y un objeto lista de personas
			clsPersona oPersona;
			List<clsPersona> listado = new List<clsPersona>();
			//Nos conectamos a la BD de Azure
			conexion.ConnectionString = "server=serverpersonasdamsg.database.windows.net;database=personasDB;uid=Prueba;pwd=123qweasd!;";
			try
			{
				//Abrimos la conexion
				conexion.Open();
				//Creamos nuestro comando select
				sqlCommand.CommandText = "Select * From Personas";
				//Asignamos al SQLCommand nuestra conexion SQL
				sqlCommand.Connection = conexion;
				//Leemos el comando con el SQLDataReader
				lector = sqlCommand.ExecuteReader();
				//Si hay filas...
				if (lector.HasRows)
				{
					//Mientras que el lector pueda leer...
					while (lector.Read())
					{
						//Creamos una nueva persona por cada fila, la cual tendra los datos de nuestra tabla Personas de la BD
						oPersona = new clsPersona();
						oPersona.idPersona = (int)lector["idPersona"]; //Nombre de los campos de la tabla en la BD
						oPersona.nombre = (string)lector["nombrePersona"];
						oPersona.apellidos = (string)lector["apellidosPersona"];
						oPersona.fechNacimiento = (DateTime)lector["fechaNacimiento"];
						oPersona.direccion = (string)lector["direccion"];
						oPersona.telefono = (string)lector["telefono"];
						oPersona.idDepartamento = (int)lector["idDepartamento"];
						//Añadimos cada persona al listado de personas
						listado.Add(oPersona);
					}
				}
				//Cerramos el lector cuando no tenga mas filas por leer
				lector.Close();
				ViewData["Estado"] = conexion.State;
			}
			catch (SqlException) { ViewData["Estado"] = "Error al intentar conectarse con la BD"; }
			//Cerramos la conexion SQL
			finally { conexion.Close(); }
			//Retornamos el listado a la vista ListadoPersonas
			return View(listado);
		}
	}
}