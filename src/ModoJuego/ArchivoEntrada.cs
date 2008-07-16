using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using TP2.GaletteToxique;

namespace TP2.ModoJuego
{
	class ArchivoEntrada
	{
		private const int espera_consulta_archivo = 2000;

		private int filas, columnas, jugador_turno;
		private Torta torta = null;

		#region Properties
		public int Filas
		{
			get { return filas; }
			set { filas = value; }
		}

		public int Columnas
		{
			get { return columnas; }
			set { columnas = value; }
		}

		public int JugadorTurno
		{
			get { return jugador_turno; }
			set { jugador_turno = value; }
		}

		public Torta Torta
		{
			get { return torta; }
			set { torta = value; }
		}
		#endregion

		/// <summary>
		/// Levanta el archivo pasado
		/// </summary>
		public ArchivoEntrada(string ruta, int mi_numero_jugador)
		{
			jugador_turno = -1;
			
			// Voy consultando el archivo hasta que encuentre que es mi turno
			while (jugador_turno != mi_numero_jugador)
			{
				// Abro el archivo
				string[] lineas = File.ReadAllText(ruta).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

				// Levanto m, n, j
				string[] primer_linea = lineas[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
				filas = int.Parse(primer_linea[0]);
				columnas = int.Parse(primer_linea[1]);
				jugador_turno = int.Parse(primer_linea[2]);

				// Si era mi turno genero la torta. Si no, espero un poco para volver a consultar.
				if (jugador_turno == mi_numero_jugador)
				{
					// Genero la torta
					torta = new Torta(filas, columnas);
					for (int i = 0; i < filas; ++i)
					{
						char[] porciones = lineas[i + 1].ToCharArray();
						for (int j = 0; j < columnas; ++j)
						{
							torta[i][j] = (porciones[j] == 'V' ? Porcion.Venenosa : (porciones[j] == 'X' ? Porcion.Vacia : Porcion.Llena));
						}
					}
				}
				else
				{
					Thread.Sleep(espera_consulta_archivo);
				}
			}
		}
	}
}
