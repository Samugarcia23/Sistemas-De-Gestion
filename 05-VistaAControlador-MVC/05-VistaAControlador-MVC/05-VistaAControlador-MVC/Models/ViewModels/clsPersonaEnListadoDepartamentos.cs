using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _05_VistaAControlador_MVC.Models.ViewModels
{
	public class clsPersonaEnListadoDepartamentos: clsPersona //Extends persona, para obtener todos sus datos
	{
		public clsPersonaEnListadoDepartamentos():base() //Super
		{

		}
		public clsPersonaEnListadoDepartamentos(int idPersona, String nombre, String apellidos, DateTime fechNacimiento,
			String direccion, String telefono, int idDepartamento, List<clsDepartamento> listado) //list es un tipo lista que contendra departamentos
			: base(idPersona, nombre, apellidos, fechNacimiento, //base es super(), hay que llamarlo aqui y no dentro del cuerpo (heredamos)
			 direccion, telefono, idDepartamento)
		{
			this.listadoDepartamentos = listado; //indicamos que el listado de departamentos es listado
			clsListadoDepartamentos list = new clsListadoDepartamentos();
			listadoDepartamentos = list.listadoDepartamentos();
		}

		public List<clsDepartamento> listadoDepartamentos { get; set; }

	}
}