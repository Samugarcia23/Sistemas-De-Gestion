using _09_CRUDRepasoExamen_DAL.Manejadoras;
using _09_CRUDRepasoExamen_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CRUDRepasoExamen_BL.Manejadoras
{
	public class clsManejadora_BL
	{
		public clsPersona buscarPersonaPoID(int id)
		{
			clsPersona oPersona = new clsPersona();
			clsManejadora_DAL clsManejadora_DAL = new clsManejadora_DAL();
			oPersona = clsManejadora_DAL.BuscarPersonaPorID_DAL(id);

			return oPersona;
		}

		public int editarPersona_BL(clsPersonaConNombreDeDepartamento oPersona)
		{
			int filas;
			clsManejadora_DAL manejadora_DAL = new clsManejadora_DAL();
			filas = manejadora_DAL.EditarPersona_DAL(oPersona);

			return filas;
		}

		public clsPersonaConNombreDeDepartamento personaNombreDep_BL(int id)
		{
			clsManejadora_DAL manejadora_DAL = new clsManejadora_DAL();
			clsPersonaConNombreDeDepartamento persona = new clsPersonaConNombreDeDepartamento();
			persona = manejadora_DAL.personaConNombreDeDepartamento(id);

			return persona;
		}

	}
}
