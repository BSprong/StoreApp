using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrods
{
    class Sushi : Voeding
    {
        public Sushi(string naam, decimal prijs, DateTime houdbaarTot)
            : base(naam, prijs, houdbaarTot)
        { }
    }
}
