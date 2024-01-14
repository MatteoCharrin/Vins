using System.Drawing.Drawing2D;
using Logiciel_de_gestion_de_cave_a_vin.Models;

namespace Logiciel_de_gestion_de_cave_a_vin
{
    public partial class FormAccueil : Form
    {

     
        public FormAccueil()
        {
            InitializeComponent();
            GestionBouteille.ChargerListeView(lvBouteille);
            Utilitaire.ApplyBorderRadius(btnAjouter, 10);
            Utilitaire.ApplyBorderRadius(btnApogee, 10);


        }

        private void tbxRecherche_TextChanged(object sender, EventArgs e)
        {
            // R�cup�rer le texte de recherche
            string searchText = tbxRecherche.Text;

            using (MlmvinContext db = new MlmvinContext())
            {
                // Construction de la requ�te LINQ de mani�re dynamique
                var bouteilles = from bouteille in db.Bouteilles
                            join appelation in db.DescriptionBouteilleAppelations on bouteille.IdAppelation equals appelation.IdAppelation
                            join couleur in db.DescriptionBouteilleCouleurs on bouteille.IdCouleur equals couleur.IdCouleur
                            where
                                bouteille.NomCompletVin.Contains(searchText) ||
                                bouteille.Millesime.ToString().Contains(searchText) ||
                                appelation.Appelation.Contains(searchText) ||
                                couleur.CouleurVin.Contains(searchText)
                            //select bouteille;
                            select new
                            {
                                Bouteille = bouteille,
                                Appelation = appelation.Appelation,
                                Couleur = couleur.CouleurVin,
                                Millesime = bouteille.Millesime,
                              // ImagePath = // Ajoutez ici la logique pour obtenir le chemin de l'image associ�e � la bouteille
                            };
                            lvBouteille.Items.Clear();
                foreach (var bouteille in bouteilles)
                {
                    GestionBouteille.ChargerListeWithObject(lvBouteille, GestionBouteille.ChargerImage(), bouteille.Bouteille, bouteille.Appelation, bouteille.Couleur,
                        bouteille.Millesime);
                }

            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FormEdition frm = new FormEdition();
            frm.ShowDialog();
        }

        private void btnApogee_Click(object sender, EventArgs e)
        {
            lvBouteille.Items.Clear();
            using (MlmvinContext db = new MlmvinContext())
            {
                // Construction de la requ�te LINQ de mani�re dynamique
                var bouteilles = from bouteille in db.Bouteilles
                                 join appelation in db.DescriptionBouteilleAppelations on bouteille.IdAppelation equals appelation.IdAppelation
                                 join couleur in db.DescriptionBouteilleCouleurs on bouteille.IdCouleur equals couleur.IdCouleur
                                 select new
                                 {
                                     Bouteille = bouteille,
                                     GardeMini = bouteille.GardeConseilleDebut,
                                     GardeMaxi = bouteille.GardeConseilleFin,
                                     Appelation = appelation.Appelation,
                                     Couleur = couleur.CouleurVin,
                                     Millesime = bouteille.Millesime
                                 };
                foreach (var bouteille in bouteilles)
                {
                    GestionBouteille.ChargerListeWithObject(lvBouteille, GestionBouteille.ChargerImage(), bouteille.Bouteille, bouteille.Appelation, bouteille.Couleur,
                        bouteille.Millesime);
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}