using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Mas adelante crearemos estas clases en otro proyecto distinto

namespace _05_VistaAControlador_MVC.Models
{
	public class clsPersona
	{
		#region Constructor por Defecto
		public clsPersona()
		{

		}
		#endregion
		#region Constructor por parametros
		public clsPersona(int idPersona, String nombre, String apellidos, DateTime fechNacimiento, String direccion, String telefono)
		{
			this.idPersona = idPersona;
			this.nombre = nombre;
			this.apellidos = apellidos;
			this.fechNacimiento = fechNacimiento;
			this.direccion = direccion;
			this.telefono = telefono;
		}
		#endregion
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