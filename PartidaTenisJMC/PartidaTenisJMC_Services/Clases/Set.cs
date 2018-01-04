using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartidaTenisJMC_Services.Clases
{
    public class Set
    {
        public int numSet { get; set; }
        public List<Jugada> jugadas { get; set; }

        public Set(int numSet)
        {
            this.numSet = numSet;
            this.jugadas = new List<Jugada>();
        }

    }
}
