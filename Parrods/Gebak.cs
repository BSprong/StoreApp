using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrods
{
    class Gebak : Voeding
    {
        public Gebak(string naam, decimal prijs, DateTime houdbaarTot)
            : base(naam, prijs, houdbaarTot)
        { }
    }
}
