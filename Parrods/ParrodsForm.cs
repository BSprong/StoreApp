using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parrods
{
    public partial class ParrodsForm : Form
    {
        private ParrodsApp app;

        public ParrodsForm()
        {
            InitializeComponent();
            app = new ParrodsApp();
            VerversLijsten();
        }

        private void pnlLogo_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnVoegPersoneelslidToe_Click(object sender, EventArgs e)
        {
            
            string naam = txtNaamVoegPersoneelslidToe.Text;
            if (string.IsNullOrEmpty(naam))
            {
                MessageBox.Show("Je dient een naam in te voeren.");
                return;
            }

            int leeftijd = 0;
            if (!int.TryParse(txtLeeftijdVoegPersoneelslidToe.Text, out leeftijd))
            {
                MessageBox.Show("Je dient een leeftijd in te voeren.");
                return;
            }

            if (leeftijd <= 0)
            {
                MessageBox.Show("Leeftijd dient een positief getal te zijn.");
                return;
            }

            bool resultaat = app.VoegPersoneelslidToe(naam, leeftijd);
            if (resultaat)
            {
                txtNaamVoegPersoneelslidToe.Clear();
                txtLeeftijdVoegPersoneelslidToe.Clear();
                VerversLijsten();
                MessageBox.Show("Het toevoegen is gelukt.");
            }
            else
            {
                MessageBox.Show("Het toevoegen is niet gelukt, er is al een personeelslid met die naam.");
            }
        }

        private void VerversLijsten()
        {
            lbPersoneel.Items.Clear();
            foreach (Personeelslid personeelslid in app.GeefAllePersoneelsleden())
            {
                lbPersoneel.Items.Add(personeelslid.GeefInfo());
            }
        }

        private void btnVerwijderPersoneelslid_Click(object sender, EventArgs e)
        {
            
            string naam = txtNaamVerwijderPersoneelslid.Text;
            if (string.IsNullOrEmpty(naam))
            {
                MessageBox.Show("Je dient een naam in te voeren.");
                return;
            }

            bool resultaat = app.VerwijderPersoneelslid(naam);
            if (resultaat)
            {
                txtNaamVerwijderPersoneelslid.Clear();
                VerversLijsten();
                MessageBox.Show("Het verwijderen is gelukt.");
            }
            else
            {
                MessageBox.Show("Het verwijderen is niet gelukt, er is geen personeelslid met die naam.");
            }
        }

        private void btnAlleArtikelen_Click(object sender, EventArgs e)
        {
            lbArtikelen.Items.Clear();
            foreach(Artikel artikel in app.GeefAlleArtikelen(false))
            {
                lbArtikelen.Items.Add(artikel.ToString());
            }
        }

        private void btnGeefAlleArtikelenGesorteerd_Click(object sender, EventArgs e)
        {
            lbArtikelen.Items.Clear();
            foreach (Artikel artikel in app.GeefAlleArtikelen(true))
            {
                lbArtikelen.Items.Add(artikel.ToString());
            }
        }

        private void btnExporteerNaarTekstbestand_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    app.ExporteerArtikelen(dialog.FileName);
                }
            }
        }

        private void btnGeefAanbiedingen_Click(object sender, EventArgs e)
        {
            lbAanbiedingen.Items.Clear();
            decimal totaalPrijs = 0;
            foreach (IAanbiedbaar aanbieding in app.GeefAlleAanbiedingen())
            {
                decimal prijs = aanbieding.GeefPrijsMetKorting();
                totaalPrijs += prijs;
                Artikel artikel = aanbieding as Artikel;
                string tekst = artikel.Naam + " " + prijs.ToString("C");
                lbAanbiedingen.Items.Add(tekst);
            }
            lblTotaalprijs.Text = totaalPrijs.ToString("C");
        }
    }
}
