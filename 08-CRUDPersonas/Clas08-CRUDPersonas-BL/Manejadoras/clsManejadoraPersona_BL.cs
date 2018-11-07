using _08_CRUDPersonas_DAL.Manejadoras;
using _08_CRUDPersonas_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clas08_CRUDPersonas_BL.Manejadoras
{
	public class clsManejadoraPersona_BL
	{
		public clsPersona BuscarPersonaPorID_BL(int id)
		{
			clsManejadoraPersona_DAL manejadora_DAL = new clsManejadoraPersona_DAL();
			clsPersona oPersona = new clsPersona();
			oPersona = manejadora_DAL.BuscarPersonaPorID_DAL(id);
			return oPersona;
		}

		public int BorrarPersonaPorID_BL(int id)
		{
			clsManejadoraPersona_DAL manejadora_DAL = new clsManejadoraPersona_DAL();
			int filas;
			filas = manejadora_DAL.BorrarPersonaPorID(id);
			return filas;
		}
	}
}
