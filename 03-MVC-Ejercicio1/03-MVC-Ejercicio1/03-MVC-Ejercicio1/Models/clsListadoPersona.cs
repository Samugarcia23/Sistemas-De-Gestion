using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _03_MVC_Ejercicio1.Models
{
	public class clsListadoPersona
	{
		 public List<clsPersona> listadoPersona()
		 {
			List <clsPersona> listado = new List<clsPersona>();
			listado.Add(new clsPersona(1, "Sam", "garcia preciado", new DateTime(1997, 10, 29), "calle 223", "5545656456"));
			listado.Add(new clsPersona(1, "Paco", "Cabesa Grande", new DateTime(1997, 10, 29), "calle 23", "55456999456"));
			listado.Add(new clsPersona(1, "Pepe", "Cordoba ", new DateTime(1997, 10, 29), "calle gr", "5545656456"));
			listado.Add(new clsPersona(1, "Yoquese", "Apellido", new DateTime(1997, 10, 29), "calle 22sdfas3", "554456456"));
			return listado;
		 }
	}
}