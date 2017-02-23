using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrods
{
    class Zeedier : BijzonderArtikel, IAanbiedbaar
    {
        public Zeedier(string naam, decimal prijs)
            : base(naam, prijs)
        { }

        public decimal GeefPrijsMetKorting()
        {
            return Prijs * .5m;
        }
    }
}
