using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrods
{
    abstract class LuxeArtikel : Artikel
    {
        public int BlingFactor { get; set; }

        public LuxeArtikel(string naam, decimal prijs, int blingFactor)
            : base(naam, prijs)
        {
            BlingFactor = blingFactor;
        }

        public override string ToString()
        {
            return "Luxe: " + base.ToString() + " Blingfactor: " + BlingFactor; 
        }
    }
}
