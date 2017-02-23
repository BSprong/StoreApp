using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrods
{
    class Jacht : LuxeArtikel
    {
        public Jacht(string naam, decimal prijs, int blingFactor)
            : base(naam, prijs, blingFactor)
        { }
    }
}
