using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

//Mas adelante crearemos estas clases en otro proyecto distinto

namespace _08_CRUDPersonas_Entidades
{
	public class clsPersona
	{
		#region Constructor por Defecto
		public clsPersona()
		{

		}
		#endregion
		#region Constructor por parametros
		public clsPersona(int idPersona, String nombre, String apellidos, DateTime fechNacimiento, String direccion, String telefono, int idDepartamento)
		{
			this.idPersona = idPersona;
			this.nombre = nombre;
			this.apellidos = apellidos;
			this.fechNacimiento = fechNacimiento;
			this.direccion = direccion;
			this.telefono = telefono;
			this.idDepartamento = idDepartamento;
		}
		#endregion

		#region atributos_Persona

		[HiddenInput(DisplayValue = false)]
		public int idPersona { get; set; }

		[Required]
		[Display(Name = "Nombre")]
		public String nombre { get; set; }

		[Required]
		[MaxLength(40)]
		[Display(Name = "Apellidos")]
		public String apellidos { get; set; }

		[DisplayFormat(DataFormatString = "{0:d}")]
		[Display(Name = "Fecha Nacimiento")]
		public DateTime fechNacimiento { get; set; }

		[MaxLength(200)]
		[Display(Name = "Direccion")]
		public String direccion { get; set; }

		[RegularExpression(@"[679]{1}[0-9]{8}$", ErrorMessage = "Please enter valid phone number")]
		[Display(Name = "Telefono")]
		public String telefono { get; set; }

		[HiddenInput(DisplayValue = false)]
		[Display(Name = "Departamento")]
		public int idDepartamento { get; set; }
		#endregion
	}
}