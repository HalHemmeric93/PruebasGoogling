using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartidaTenisJMC_Services.Clases
{
    public class Jugada
    {
        public int numeroJugada { get; set; }
        public int puntosJugadaJugador1 { get; set; }
        public int puntosJugadaJugador2 { get; set; }
        public Jugada(int numeroJugada)
        {
            this.numeroJugada = numeroJugada;
            this.puntosJugadaJugador1 = 0;
            this.puntosJugadaJugador2 = 0;
        }
    }
}
