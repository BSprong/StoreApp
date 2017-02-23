using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrods
{
    class Limousine : LuxeArtikel, IAanbiedbaar
    {
        public Limousine(string naam, decimal prijs, int blingFactor)
            : base(naam, prijs, blingFactor)
        { }

        public decimal GeefPrijsMetKorting()
        {
            return (BlingFactor < 90) ? Prijs * .8m : Prijs * .9m;
        }
    }
}
