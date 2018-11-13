using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CRUDRepasoExamen_Entidades
{
	public class clsPersonaConNombreDeDepartamento : clsPersona
	{
		#region constructor por defecto

		public clsPersonaConNombreDeDepartamento()
		{

		}

		#endregion

		#region constructor por parametros

		public clsPersonaConNombreDeDepartamento(int idPersona, String nombre, String apellidos, DateTime fechNacimiento, String direccion, String telefono, int idDepartamento, String nombreDepartamento)
		{
			this.idPersona = idPersona;
			this.nombre = nombre;
			this.apellidos = apellidos;
			this.fechNacimiento = fechNacimiento;
			this.direccion = direccion;
			this.telefono = telefono;
			this.idDepartamento = idDepartamento;
			this.nombreDepartamento = nombreDepartamento;
		}

		#endregion

		#region atributos y propiedades

		public String nombreDepartamento { get; set; }

		#endregion
	}
}
