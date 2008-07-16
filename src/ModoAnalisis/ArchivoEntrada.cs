using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TP2.GaletteToxique;

namespace TP2.ModoAnalisis
{
	class ArchivoEntrada
	{
		private int filas, columnas, cant_envenenadas;
		private List<Coordenada> envenenadas = null;

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

		public int CantEnvenenadas
		{
			get { return cant_envenenadas; }
			set { cant_envenenadas = value; }
		}

		public List<Coordenada> Envenenadas
		{
			get { return envenenadas; }
			set { envenenadas = value; }
		}
		#endregion
		
		/// <summary>
		/// Levanta el archivo pasado
		/// </summary>
		public ArchivoEntrada(string ruta)
		{
			// Abro el archivo
			string[] lineas = File.ReadAllText(ruta).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

			// Levanto m, n, k
			string[] primer_linea = lineas[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
			filas = int.Parse(primer_linea[0]);
			columnas = int.Parse(primer_linea[1]);
			cant_envenenadas = int.Parse(primer_linea[2]);

			// Levanto las envenenadas
			envenenadas = new List<Coordenada>(cant_envenenadas);
			for (int i = 1; i < cant_envenenadas + 1; ++i)
			{
				string[] linea = lineas[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
				envenenadas.Add(new Coordenada(int.Parse(linea[0]), int.Parse(linea[1])));
			}
		}
	}
}
