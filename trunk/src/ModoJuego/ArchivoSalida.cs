using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TP2.GaletteToxique;

namespace TP2.ModoJuego
{
	class ArchivoSalida
	{
		public ArchivoSalida(string ruta, Torta torta, int num_jugador_oponente)
		{
			// Genero la salida
			string salida = torta.Filas + " " + torta.Columnas + " " + num_jugador_oponente + Environment.NewLine;
			salida += torta.ToString();

			// Escribo la salida
			File.WriteAllText(ruta, salida);
		}
	}
}
