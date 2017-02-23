using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrods
{
    abstract class Artikel : IComparable<Artikel>
    {
        public string Naam { get; set; }
        public decimal Prijs { get; set; }

        public Artikel(string naam, decimal prijs)
        {
            Naam = naam;
            Prijs = prijs;
        }

        public override string ToString()
        {
            return Naam + " " + Prijs.ToString("C");
        }

        public int CompareTo(Artikel other)
        {
            return Naam.CompareTo(other.Naam);
        }
    }
}
