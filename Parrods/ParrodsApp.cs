using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parrods
{
    class ParrodsApp
    {
        private List<Personeelslid> personeel;
        private List<Artikel> artikelen;

        public ParrodsApp()
        {
            personeel = new List<Personeelslid>();
            artikelen = new List<Artikel>();
            VulMetDummieData();
        }

        public void VulMetDummieData()
        {
            artikelen.Add(new Sushi("Nigiri met tonijn", 3.2m, DateTime.Now));
            artikelen.Add(new Sushi("Maki met schol", 2.9m, DateTime.Now.AddDays(3)));

            artikelen.Add(new Gebak("Tompouce", 7.3m, DateTime.Now.AddDays(1)));
            artikelen.Add(new Gebak("Chocoladebol", 6.8m, DateTime.Now.AddDays(2)));

            artikelen.Add(new Limousine("Maybach", 780000.0m, 100));
            artikelen.Add(new Limousine("Rolls-Royce", 690000.0m, 80));

            artikelen.Add(new Jacht("Abacus", 1450600.0m, 90));
            artikelen.Add(new Jacht("Lagoon", 1250900.0m, 70));

            artikelen.Add(new Ruimtevaartuig("Space Shuttle", 891250900.0m));
            artikelen.Add(new Ruimtevaartuig("Ariane 5", 1221250900.0m));

            artikelen.Add(new Zeedier("Dolfijn", 512080.0m));
            artikelen.Add(new Zeedier("Walvis", 914000.0m));
        }

        public IReadOnlyList<Personeelslid> GeefAllePersoneelsleden()
        {
            
            return personeel.AsReadOnly();
        }

        public bool VoegPersoneelslidToe(string naam, int leeftijd)
        {
            foreach (Personeelslid personeelslid in personeel)
            {
                if (personeelslid.Naam == naam)
                {
                    return false;
                }
            }
            Personeelslid nieuwPersoneelslid = new Personeelslid(naam, leeftijd);
            personeel.Add(nieuwPersoneelslid);
            return true;
        }

        public bool VerwijderPersoneelslid(string naam)
        {
            foreach (Personeelslid personeelslid in personeel)
            {
                if (personeelslid.Naam == naam)
                {
                    personeel.Remove(personeelslid);
                    return true;
                }
            }
            return false;
        }

        public IReadOnlyList<Artikel> GeefAlleArtikelen(bool sorteerOpPrijs)
        {
            if (!sorteerOpPrijs)
            {
                artikelen.Sort();
            }
            else
            {
                artikelen.Sort(new ArtikelVergelijker());
            }
            return artikelen.AsReadOnly();
        }

        public void ExporteerArtikelen(string bestandsnaam)
        {
            using (FileStream stream = new FileStream(bestandsnaam, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    int counter = 0;
                    foreach (Artikel artikel in artikelen)
                    {
                        writer.Write(artikel.ToString() + ";");
                        counter++;
                        if (counter == 3)
                        {
                            writer.Write(Environment.NewLine);
                            counter = 0;
                        }
                    }
                }
            }
        }

        public IReadOnlyList<IAanbiedbaar> GeefAlleAanbiedingen()
        {
            List<IAanbiedbaar> aanbiedingen = new List<IAanbiedbaar>();
            foreach (Artikel artikel in artikelen)
            {
                if (artikel is IAanbiedbaar)
                {
                    aanbiedingen.Add(artikel as IAanbiedbaar);
                }
            }
            return aanbiedingen.AsReadOnly();
        }
    }
}
