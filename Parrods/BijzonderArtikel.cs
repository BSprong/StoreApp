using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrods
{
    abstract class BijzonderArtikel : Artikel
    {
        public BijzonderArtikel(string naam, decimal prijs) 
            : base(naam, prijs) 
        { }

        public override string ToString()
        {
            return "Bijzonder: " + base.ToString();
        }
    }
}
