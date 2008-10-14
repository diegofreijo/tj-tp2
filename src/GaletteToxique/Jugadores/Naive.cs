using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP2.GaletteToxique.Jugadores
{
    public class Naive : Jugador
    {
        public override bool Jugar(ref Torta torta)
        {
            //Creo una torta nueva para no modificar la que entra como parametro ya que sobre ella hay que devolver la jugada.
            Torta original = new Torta(torta.Filas, torta.Columnas);

            //Creo otra torta que ira conteniedo la mejor jugada, de esta se tomara el valor para retornar.
            Torta tortaRetornable = new Torta(torta.Filas, torta.Columnas);

            //Creo la lista que ira conteniendo el mejor resultado. El agregarle un cero es ad-hoc para no tener que verificar el vacio en TieneMasGanados
            List<int> listaNimeros = new List<int>();
            listaNimeros.Add(0);

            if (!torta.QuedaPorcionComible())
            {
                //No queda jugada por realizar, con lo cual el juego termino.
                return true;
            }
            else
            {
                //Pido el valor de todas las siguientes comidas posibles.
                for (int fila = 0; fila < (torta.Filas - 1); ++fila)
                {
                    for (int col = 0; col < (torta.Columnas - 1); ++col)
                    {
                        //Verifico que se pueda comer la porcion de 2x2, donde torta[fila][col] es la porcion de arriba a la izquierda.
                        if ((torta[fila][col] != Porcion.Venenosa && torta[fila][col + 1] != Porcion.Venenosa &&
                            torta[fila + 1][col] != Porcion.Venenosa && torta[fila + 1][col + 1] != Porcion.Venenosa) &&
                            (torta[fila][col] == Porcion.Llena || torta[fila][col + 1] == Porcion.Llena ||
                            torta[fila + 1][col] == Porcion.Llena || torta[fila + 1][col + 1] == Porcion.Llena))
                        {
                            //Restauro el valor de original usando a juego.Torta.
                            original.CopiarContenido(torta);

                            //Como las porciones y pido el valor de ese nuevo juego.
                            original[fila][col] = Porcion.Vacia;
                            original[fila][col + 1] = Porcion.Vacia;
                            original[fila + 1][col] = Porcion.Vacia;
                            original[fila + 1][col + 1] = Porcion.Vacia;

                            Juego juegoSigte = new Juego(original, 2);
                            List<int> nimerosJuegoSigte = new List<int>();
                            nimerosJuegoSigte = juegoSigte.CalcularValor();

                            //Se comporta como mayor o igual.
                            if (TieneMasGanados(nimerosJuegoSigte, listaNimeros))
                            {
                                listaNimeros = nimerosJuegoSigte;
                                tortaRetornable.CopiarContenido(original);
                            }
                        }
                    }
                }
                torta.CopiarContenido(tortaRetornable);
                return false;
            }
        }

        public override int Valorar(Torta torta)
        {
            List<int> listaNimeros = new List<int>();
            Juego juego = new Juego(torta, 1);

            listaNimeros = juego.CalcularValor();

            int acum = Mex(listaNimeros);

            return acum;
        }

        /// <summary>
        /// Aplica la Regla del Minimo Excluido (MEX) a la lista de nimeros que le entra como parametro.
        /// </summary>
        private int Mex(List<int> listaNimeros)
        {
            bool sonTodosIguales = true;
            int nroMex = 0;

            for (int j = 1; j < listaNimeros.Count; ++j)
            {
                sonTodosIguales = (sonTodosIguales && (listaNimeros[0] == listaNimeros[j]));
            }

            if (sonTodosIguales)
            {
                nroMex = listaNimeros[0];
            }
            else
            {
                while (true)
                {
                    if (!listaNimeros.Contains(nroMex))
                    {
                        break;
                    }
                    nroMex++;
                }
            }
            return nroMex;
        }

        private bool TieneMasGanados(List<int> p, List<int> q)
        {
            float unosP = 0;
            for (int i = 0; i < p.Count; ++i)
            {
                if (p[i] == 1)
                {
                    unosP++;
                }
            }
            
            float unosQ = 0;
            for (int j = 0; j < q.Count; ++j)
            {
                if (q[j] == 1)
                {
                    unosQ++;
                }
            }
            
            float proporcionP = (unosP/(float)p.Count);
            float proporcionQ = (unosQ/(float)q.Count);

            return (proporcionP >= proporcionQ);
        }

        private class Juego
        {
            private int turno;
            private Torta torta;

            public Juego(Torta torta, int turno)
            {
                this.torta = torta;
                this.turno = turno;
            }

            public Torta Torta
            { 
                get { return torta; }
            }

            public List<int> CalcularValor()
            {
                List<int> listaNimeros = new List<int>();

                //Si no queda una porcion que se pueda comer entonces el juego termino y se puede definir el valor (dependiendo de quien es el turno).
                //Si todavia quedan porciones comibles hay que seguir "bajando" hasta que esto no pase, al "bajar" hay que cambiar el turno.
                if (!this.torta.QuedaPorcionComible())
                {
                    //Si el turno es del Jugador 1 entonces el valor es 0, en caso contrario es * (notado con 1).
                    if (this.turno == 1)
                    {
                        listaNimeros.Add(0);
                    }
                    else
                    {
                        listaNimeros.Add(1);
                    }
                }
                else
                {
                    int turnoSigte;
                    turnoSigte = (this.turno == 1 ? 2 : 1);

                    Torta original = new Torta(this.torta.Filas, this.torta.Columnas);

                    //original.CopiarContenido(this.torta);

                    //Pido el valor de todas las siguientes comidas posibles.
                    for (int fila = 0; fila < (this.torta.Filas - 1); ++fila)
                    {
                        for (int col = 0; col < (this.torta.Columnas - 1); ++col)
                        {
                            //Verifico que se pueda comer la porcion de 2x2, donde torta[fila][col] es la porcion de arriba a la izquierda.
                            if ((this.torta[fila][col] != Porcion.Venenosa && this.torta[fila][col + 1] != Porcion.Venenosa &&
                                this.torta[fila + 1][col] != Porcion.Venenosa && this.torta[fila + 1][col + 1] != Porcion.Venenosa) &&
                                (this.torta[fila][col] == Porcion.Llena || this.torta[fila][col + 1] == Porcion.Llena ||
                                this.torta[fila + 1][col] == Porcion.Llena || this.torta[fila + 1][col + 1] == Porcion.Llena))
                            {
                                //Restauro el valor de original usando a this.torta.
                                original.CopiarContenido(this.torta);

                                //Como las porciones y pido el valor de ese nuevo juego.
                                original[fila][col] = Porcion.Vacia;
                                original[fila][col + 1] = Porcion.Vacia;
                                original[fila + 1][col] = Porcion.Vacia;
                                original[fila + 1][col + 1] = Porcion.Vacia;

                                Juego juegoSigte = new Juego(original, turnoSigte);

                                listaNimeros.AddRange(juegoSigte.CalcularValor());
                            }
                        }
                    }
                }
                return listaNimeros;
            }
        }
    }
}