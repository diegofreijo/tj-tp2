using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.GaletteToxique;
using TP2.GaletteToxique.Jugadores;

namespace TP2.ModoAnalisis
{
	class Program
	{
		private const string ruta_archivos = "..\\..\\..\\..\\modo_analisis";
		private const string archivo_entrada = "GT.in";
		private const string archivo_salida = "GT.out";
		
		static void Main(string[] args)
		{
			// Seteo el jugador
			Jugador jugador = new Naive();

			// Leo la entrada
			ArchivoEntrada entrada = new ArchivoEntrada(ruta_archivos + "\\" + archivo_entrada);
			
			// Genero la torta
			Torta torta = new Torta(entrada.Filas, entrada.Columnas, entrada.Envenenadas);
	
			// Hago que el jugador juege
			int valor = jugador.Valorar(torta);

			// Guardo la jugada
			ArchivoSalida salida = new ArchivoSalida(ruta_archivos + "\\" + archivo_salida, valor);
		}
	}
}
