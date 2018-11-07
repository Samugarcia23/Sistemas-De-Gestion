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
		/// <summary>
		/// Funcion que llama a BuscarPersonaPorID de la capa DAL y devuelve la persona a la capa UI
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public clsPersona BuscarPersonaPorID_BL(int id)
		{
			clsManejadoraPersona_DAL manejadora_DAL = new clsManejadoraPersona_DAL();
			clsPersona oPersona = new clsPersona();
			oPersona = manejadora_DAL.BuscarPersonaPorID_DAL(id);
			return oPersona;
		}
		/// <summary>
		///  Funcion que llama a BorrarPersonaPorID de la capa DAL y devuelve las filas alteradas a la capa UI
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public int BorrarPersonaPorID_BL(int id)
		{
			clsManejadoraPersona_DAL manejadora_DAL = new clsManejadoraPersona_DAL();
			int filas;
			filas = manejadora_DAL.BorrarPersonaPorID(id);
			return filas;
		}
		/// <summary>
		/// Funcion que llama a InsertarPersona de la capa DAL y devuelve la nueva persona alteradas a la capa UI
		/// </summary>
		/// <returns></returns>
		public int InsertarPersona_BL(clsPersona persona)
		{
			clsPersona oPersona = new clsPersona();
			clsManejadoraPersona_DAL manejadora_DAL = new clsManejadoraPersona_DAL();
			int filas;
			filas = manejadora_DAL.InsertarPersona_DAL(oPersona);
			return filas;
		}

		public clsPersona EditarPersonaPorID_BL(clsPersona persona)
		{
			clsPersona oPersona = new clsPersona();
			clsManejadoraPersona_DAL manejadora_DAL = new clsManejadoraPersona_DAL();
			//int filas;

			manejadora_DAL.EditarPersonaPorID_DAL(oPersona);
			return oPersona;
		}
	}
}
