using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TP2.GaletteToxique
{
	public class Torta : List<List<Porcion>>
	{
		private int filas = 0;
		private int columnas = 0;

		public int Filas
		{
			get { return filas; }
		}

		public int Columnas
		{
			get { return columnas; }
		}

		/// <summary>
		/// Crea una torta nueva con todas las casillas llenas
		/// </summary>
		public Torta(int filas, int columnas)
			: base(filas)
		{
			this.filas = filas;
			this.columnas = columnas;

			// Creo las porciones y las pongo como llenas
			for (int i = 0; i < filas; ++i)
			{
				List<Porcion> fila = new List<Porcion>(columnas);
				for (int j = 0; j < columnas; ++j)
				{
					fila.Add(Porcion.Llena);
				}
				this.Add(fila);
			}
		}

		/// <summary>
		/// Crea una torta nueva con todas las casillas llenas excepto las pasadas como envenenadas
		/// </summary>
		public Torta(int filas, int columnas, List<Coordenada> envenenadas) : base(filas)
		{
			this.filas = filas;
			this.columnas = columnas;

			// Creo las porciones y las pongo como llenas
			for (int i = 0; i < filas; ++i)
			{
				List<Porcion> fila = new List<Porcion>(columnas);
				for (int j = 0; j < columnas; ++j)
				{
					fila.Add(Porcion.Llena);
				}
				this.Add(fila);
			}

			// Enveneno las correspondientes
			foreach (Coordenada coord in envenenadas)
			{
				this[coord.Fila][coord.Columna] = Porcion.Venenosa;
			}
		}

		public string ToString()
		{
			string salida = "";

			foreach (List<Porcion> fila in this)
			{
				foreach (Porcion porcion in fila)
				{
					salida += (porcion == Porcion.Llena ? "O" : (porcion == Porcion.Vacia ? "X" : "V"));
				}
				salida += Environment.NewLine;
			}

			return salida;
		}

	}
}
