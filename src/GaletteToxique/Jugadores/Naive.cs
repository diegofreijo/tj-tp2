using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.GaletteToxique.Jugadores
{
	public class Naive : Jugador
	{
		public override void Jugar(ref Torta torta)
		{
			torta[0][0] = Porcion.Vacia;
			torta[0][1] = Porcion.Vacia;
		}

		public override int Valorar(Torta torta)
		{
			return 0;
		}
	}
}
