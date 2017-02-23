using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrods
{
    abstract class Voeding : Artikel, IAanbiedbaar
    {
        public DateTime HoudbaarTot { get; set; }

        public Voeding(string naam, decimal prijs, DateTime houdbaarTot)
            : base(naam, prijs)
        {
            HoudbaarTot = houdbaarTot;
        }

        public override string ToString()
        {
            return "Voeding: " + base.ToString() + " Houdbaar tot: " + HoudbaarTot.ToShortDateString();
        }

        public decimal GeefPrijsMetKorting()
        {
            return (HoudbaarTot.Date == DateTime.Now.Date) ? Prijs * .65m : Prijs * .9m;
        }
    }
}
