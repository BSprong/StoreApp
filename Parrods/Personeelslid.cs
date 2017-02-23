using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrods
{
    class Personeelslid
    {
        public string Naam { get; set; }
        public int Leeftijd { get; set; }

        public Personeelslid(string naam, int leeftijd)
        {
            Naam = naam;
            Leeftijd = leeftijd;
        }

        public string GeefInfo()
        {
            return Naam + " " + Leeftijd;
        }
    }
}
