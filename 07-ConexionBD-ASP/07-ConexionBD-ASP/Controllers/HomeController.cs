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
			
			return View();
		}
	}
}