using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrods
{
    class ArtikelVergelijker : IComparer<Artikel>
    {
        public int Compare(Artikel x, Artikel y)
        {
            return x.Prijs.CompareTo(y.Prijs);
        }
    }
}
