using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_MVC_Ejercicio1.Controllers
{
	public class clsCalcularFecha
	{
		public String obtenerFecha()
		{
			//DateTime hoy = DateTime.Now.ToLongDateString; // Or your date, as long as it is in DateTime format
			string hoyString = hoy.ToString("dd-MM-yyyy HH:mm:ss");
			return hoyString;
		}
		
	}
}