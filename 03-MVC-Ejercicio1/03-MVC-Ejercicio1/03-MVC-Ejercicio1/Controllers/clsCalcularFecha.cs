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
			String date = DateTime.Now.ToLongDateString(); // Or your date, as long as it is in DateTime format
			return date;
		}
		
	}
}