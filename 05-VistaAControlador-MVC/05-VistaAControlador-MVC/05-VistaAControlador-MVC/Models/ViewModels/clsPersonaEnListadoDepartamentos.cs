using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05_VistaAControlador_MVC.Models.ViewModels
{
	public class clsPersonaEnListadoDepartamentos: clsPersona
	{
		public clsPersonaEnListadoDepartamentos():base()
		{

		}
		public clsPersonaEnListadoDepartamentos(int idPersona, String nombre, String apellidos, DateTime fechNacimiento,
			String direccion, String telefono, int idDepartamento, List<clsDepartamento> listado)
			: base(idPersona, nombre, apellidos, fechNacimiento, //base es super(), hay que llamarlo aqui y no dentro del cuerpo
			 direccion, telefono, idDepartamento)
		{
			this.listadoDepartamentos = listado;
			clsListadoDepartamentos list = new clsListadoDepartamentos();
			listadoDepartamentos = list.listadoDepartamentos();
		}

		public List<clsDepartamento> listadoDepartamentos { get; set; }

	}
}