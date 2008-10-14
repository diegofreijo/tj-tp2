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
		public Torta(int filas, int columnas) : base(filas)
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

        public override string ToString()
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

        public bool QuedaPorcionComible()
        {
            for (int fila = 0; fila < (this.Filas - 1); ++fila)
            {
                for (int col = 0; col < (this.Columnas - 1); ++col)
                {
                    //Verifico que sea comestible el bocado de 2x2, donde torta[fila][col] es la porcion de arriba a la izquierda.
                    if ((this[fila][col] != Porcion.Venenosa && this[fila][col + 1] != Porcion.Venenosa &&
                        this[fila + 1][col] != Porcion.Venenosa && this[fila + 1][col + 1] != Porcion.Venenosa) &&
                        (this[fila][col] == Porcion.Llena || this[fila][col + 1] == Porcion.Llena ||
                        this[fila + 1][col] == Porcion.Llena || this[fila + 1][col + 1] == Porcion.Llena))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        internal void CopiarContenido(Torta torta)
        {
            for (int i = 0; i < this.filas; ++i)
            {
                for (int j = 0; j < this.columnas; ++j)
                {
                    this[i][j] = torta[i][j];
                }
            }
        }
    }
}
