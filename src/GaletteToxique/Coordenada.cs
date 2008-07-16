using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.GaletteToxique
{
	public class Coordenada
	{
		private int fila = 0;
		private int columna = 0;

		public int Fila
		{
			get { return fila; }
			set { fila = value; }
		}
		
		public int Columna
		{
			get { return columna; }
			set { columna = value; }
		}

		public Coordenada(int fila, int columna)
		{
			this.fila = fila;
			this.columna = columna;
		}

	}
}
