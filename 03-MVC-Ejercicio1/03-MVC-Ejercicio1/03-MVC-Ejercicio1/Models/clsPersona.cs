using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_MVC_Ejercicio1.Models
{
	public class clsPersona
	{
		#region atributos_Persona
		public int idPersona { get; set; }
		public String nombre { get; set; }
		public String apellidos { get; set; }
		public DateTime fechNacimiento { get; set; }
		public String direccion { get; set; }
		public String telefono { get; set; }
		#endregion
	}
}