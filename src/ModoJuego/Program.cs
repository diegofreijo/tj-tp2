using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TP2.GaletteToxique;
using TP2.GaletteToxique.Jugadores;

namespace TP2.ModoJuego
{
	class Program
	{
		private const string ruta_archivos = "..\\..\\..\\..\\modo_juego";
		private const string archivo = "GT.txt";

		static void Main(string[] args)
		{
			// Me fijo mi numero de jugador y el del oponente
			int mi_numero = int.Parse(args[0]);
			int oponente_numero = int.Parse(args[1]);

			// Seteo al jugador
			Jugador jugador = new Naive();

            // Comienzo el juego
			bool termino = false;
			while (!termino)
			{
				// Leo la entrada
				ArchivoEntrada entrada = new ArchivoEntrada(ruta_archivos + "\\" + archivo, mi_numero);

				// Recupero la torta
				Torta torta = entrada.Torta;

				#region Log
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("Nueva torta");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine(torta.ToString());
				#endregion

				// Hago que el jugador juege
				termino = jugador.Jugar(ref torta);

				#region Log
				Console.ForegroundColor = ConsoleColor.DarkMagenta;
				Console.WriteLine("Torta comida");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine(torta.ToString());
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("=================");
                Console.ForegroundColor = ConsoleColor.White;
				#endregion

				// Guardo la jugada
				ArchivoSalida salida = new ArchivoSalida(ruta_archivos + "\\" + archivo, torta, oponente_numero);
            }
            #region LogFinal
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("***********************************");
            Console.WriteLine("No queda jugada posible :(");
            Console.WriteLine("***********************************");
            Console.ForegroundColor = ConsoleColor.White;
            #endregion
        }
	}
}
