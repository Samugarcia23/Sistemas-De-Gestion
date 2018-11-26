using _10_ApiRestPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace __10_ApiRestPersonas_Entidades
{
	public class clsPersonaConNombreDeDepartamento : clsPersona
	{
		#region constructor por defecto

		public clsPersonaConNombreDeDepartamento()
		{

		}

		#endregion

		#region constructor por parametros

		public clsPersonaConNombreDeDepartamento(int nIdPersona, String nNombre, String nApellido, DateTime nFechaNacimiento, String nDireccion, String nTelefono, int nIdDepartamento, String nNombreDepartamento)
		{
			this.idPersona = nIdPersona;
			this.nombre = nombre;
			this.apellidos = nApellido;
			this.fechNacimiento = nFechaNacimiento;
			this.direccion = nDireccion;
			this.telefono = nTelefono;
			this.idDepartamento = nIdDepartamento;
			this.nombreDepartamento = nNombreDepartamento;
		}

		#endregion

		#region atributos y propiedades

		public String nombreDepartamento { get; set; }

		#endregion
	}
}
