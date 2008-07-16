using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TP2.GaletteToxique;

namespace TP2.ModoAnalisis
{
	class ArchivoSalida
	{
		public ArchivoSalida(string ruta, int valor)
		{
			File.WriteAllText(ruta, valor.ToString());
		}
	}
}
