using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartidaTenisJMC_Services.Clases
{
    public class Partida
    {
        public Jugador jugador1 { get; set; }
        public Jugador jugador2 { get; set; }
        public bool jugadorPrincipal1 { get; set; }
        public int numSets { get; set; }
        public List<Set> sets { get; set; }
        public int[,] puntosSets { get; set; }

        public Partida(Jugador jugador1, Jugador jugador2, int numSets)
        {
            this.jugador1 = jugador1;
            this.jugador2=jugador2;
            this.numSets = numSets;
            this.sets = new List<Set>();
            this.jugadorPrincipal1 = true;
            for (int i = 1; i <= numSets; i++)
            {
                sets.Add(new Set(i));
            }
            this.puntosSets = new int[numSets, 2];
        }
}
}