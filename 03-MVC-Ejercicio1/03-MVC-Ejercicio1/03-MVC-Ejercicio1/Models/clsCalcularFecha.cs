using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_MVC_Ejercicio1.Controllers
{
	/// <summary>
	/// Clase la cual contiene el metodo obtenerFecha el cual retorna un String con la fecha completa
	/// </summary>
	public class clsCalcularFecha
	{
		public String obtenerFecha()
		{
			String date = DateTime.Now.ToLongDateString();
			return date;
		}
		
	}
}