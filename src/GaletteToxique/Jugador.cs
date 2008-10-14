using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.GaletteToxique
{
	public abstract class Jugador
	{
		public abstract bool Jugar(ref Torta torta);

		public abstract int Valorar(Torta torta);
    }
}
