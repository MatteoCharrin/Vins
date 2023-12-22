using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logiciel_de_gestion_de_cave_a_vin.Models;
namespace Logiciel_de_gestion_de_cave_a_vin
{
    public partial class FormEdition : Form
    {
        public FormEdition()
        {
            InitializeComponent();
            Hide_Bouteille();
        }
        public void Hide_Bouteille()
        {
            btnSupprimer.Visible = false;
            btnAjout.Visible = false;
            btnModifier.Visible = false;
            btnAjoutAppelation.Visible = false;
            tbxGardeDebut.Visible = false;
            tbxAjoutAppelation.Visible = false;
            tbxGardeFin.Visible = false;
            tbxMillesime.Visible = false;
            tbxNom.Visible = false;
            cbbAppelation.Visible = false;
            cbbCouleur.Visible = false;
            cbbEmplacemnt.Visible = false;
            cbbTiroire.Visible = false;
            cbbCave.Visible = false;

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label_8.Visible = false;
            label8.Visible = false;



        }
        public void Hide_Cave()
        {

        }
        public void Show_Cave()
        {
            btnSupprimer.Visible = true;
            btnAjout.Visible = true;
            btnModifier.Visible = true;
            label1.Visible = true;
            tbxNom.Visible = true;
        }

        public void Show_Bouteille()
        {
            btnSupprimer.Visible = true;
            btnAjout.Visible = true;
            btnModifier.Visible = true;
            btnAjoutAppelation.Visible = true;
            tbxGardeDebut.Visible = true;
            tbxAjoutAppelation.Visible = true;
            tbxGardeFin.Visible = true;
            tbxMillesime.Visible = true;
            tbxNom.Visible = true;
            cbbAppelation.Visible = true;
            cbbCouleur.Visible = true;
            cbbEmplacemnt.Visible = true;
            cbbTiroire.Visible = true;
            cbbCave.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label_8.Visible = true;
            label8.Visible = true;

            using (MlmvinContext db = new MlmvinContext())
            {
                var bouteilles = from bouteille in db.Bouteilles
                                 join appelation in db.DescriptionBouteilleAppelations on bouteille.IdAppelation equals appelation.IdAppelation
                                 join couleur in db.DescriptionBouteilleCouleurs on bouteille.IdCouleur equals couleur.IdCouleur
                                 select new
                                 {
                                     Bouteille = bouteille,
                                     Appelation = appelation.Appelation,
                                     Couleur = couleur.CouleurVin,
                                     Millesime = bouteille.Millesime
                                 };
                lvGeneral.View = View.Tile;
                lvGeneral.TileSize = new Size(250, 70);

                // Déclaration des colonnes
                lvGeneral.Columns.Add("Nom Complet Vin");
                lvGeneral.Columns.Add("Domain");
                lvGeneral.Columns.Add("Type vins");
                lvGeneral.Columns.Add("Millésime");

                // Boucle qui ajout les informations pour chaque bouteilles
                foreach (var bouteille in bouteilles)
                {
                    ListViewItem item = new ListViewItem(bouteille.Bouteille.NomCompletVin);
                    item.SubItems.Add(bouteille.Appelation);
                    item.SubItems.Add(bouteille.Couleur);
                    item.SubItems.Add(bouteille.Millesime.ToString("yyyy"));
                    lvGeneral.Items.Add(item);
                }
            }
        }

        private void btnCave_Click(object sender, EventArgs e)
        {
            Hide_Bouteille();
            Show_Cave();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide_Cave();
            RemplireComboboxCouleur();
            RemplireComboboxAppelation();
            Show_Bouteille();
            RemplireComboboxCave();

        }

        private void RemplireComboboxCouleur()
        {
            using (MlmvinContext context = new MlmvinContext())
            {
                var DescriptionBouteilleCouleurs = context.DescriptionBouteilleCouleurs.ToList();
                cbbCouleur.DataSource = DescriptionBouteilleCouleurs;
            }
            cbbCouleur.DisplayMember = "CouleurVin";
            cbbCouleur.ValueMember = "IdCouleur";
        }

        private void RemplireComboboxCave()
        {
            using (MlmvinContext context = new MlmvinContext())
            {
                var Caves = context.Caves.ToList();
                cbbCave.DataSource = Caves;
            }
            cbbCave.DisplayMember = "NomCaves";
            cbbCave.ValueMember = "IdCave";
        }
        private void RemplireComboboxTiroirePlace()
        {
            using (MlmvinContext context = new MlmvinContext())
            {
                Cave CaveSelectione = (Cave)cbbCave.SelectedItem;
                Cave Caves = context.Caves.Where(o => o.IdCave == CaveSelectione.IdCave).Single();
                cbbEmplacemnt.Items.Clear();
                cbbTiroire.Items.Clear();
                for (int i = 1; i < Caves.NombreTiroir+1; i++)
                {
                    cbbEmplacemnt.Items.Add(i);
                }
                for (int i = 1; i < Caves.BouteillesParTiroir + 1; i++)
                {

                    cbbTiroire.Items.Add(i);
                }
            }
            
        }


        private void RemplireComboboxAppelation()
        {
            using (MlmvinContext context = new MlmvinContext())
            {
                var DescriptionBouteilleAppelations = context.DescriptionBouteilleAppelations.ToList();


                cbbAppelation.DataSource = null;

                cbbAppelation.DataSource = DescriptionBouteilleAppelations;
                cbbAppelation.DisplayMember = "Appelation";
                cbbAppelation.ValueMember = "IdAppelation";
            }
        }

        private void AddAppelation(string nomAppelation)
        {
            using (MlmvinContext context = new MlmvinContext())
            {
                var appelationExistante = context.DescriptionBouteilleAppelations
               .FirstOrDefault(a => a.Appelation.ToLower() == nomAppelation.ToLower());

                if (appelationExistante == null)
                {
                    // Créer une nouvelle instance de DescriptionBouteilleAppelation
                    DescriptionBouteilleAppelation nouvelleAppelation = new DescriptionBouteilleAppelation
                    {
                        Appelation = nomAppelation  // Assurez-vous que cette propriété correspond à votre modèle
                    };

                    // Ajouter la nouvelle appellation au contexte
                    context.DescriptionBouteilleAppelations.Add(nouvelleAppelation);

                    // Sauvegarder les changements dans la base de données
                    context.SaveChanges();

                    MessageBox.Show("Nouvelle appellation ajoutée avec succès !");
                }
                else
                {
                    MessageBox.Show("Cette appellation existe déjà.");
                }
            }
        }

        private void btnAjoutAppelation_Click(object sender, EventArgs e)
        {
            string nomAppelation = tbxAjoutAppelation.Text;
            if (!string.IsNullOrWhiteSpace(nomAppelation))
            {
                AddAppelation(nomAppelation);
                tbxAjoutAppelation.Text = string.Empty;
                RemplireComboboxAppelation();
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom d'appellation valide.");
            }
        }

        private void AjouterBouteille()
        {
            string nomBouteille = tbxNom.Text;
            DateTime millesimeBouteille;
            DateTime.TryParse(tbxMillesime.Text, out millesimeBouteille);
            int Gardedebut = Int32.Parse(tbxGardeDebut.Text);
            int Gardefin = Int32.Parse(tbxGardeFin.Text);
            var selectedAppelation = cbbAppelation.SelectedItem as DescriptionBouteilleAppelation;
            int? IdAppelation = selectedAppelation?.IdAppelation;
            var selectedcouleur = cbbCouleur.SelectedItem as DescriptionBouteilleCouleur;
            int? IdCouleur = selectedcouleur?.IdCouleur;


            if (IdCouleur == null)
            {
                MessageBox.Show("Veuillez sélectionner une couleur pour le vin .");
                return;
            }
            if (IdAppelation == null)
            {
                MessageBox.Show("Veuillez sélectionner une appellation.");
                return;
            }



            using (MlmvinContext context = new MlmvinContext())
            {
                // Créer une nouvelle instance de Bouteille
                Bouteille nouvelleBouteille = new Bouteille
                {
                    NomCompletVin = nomBouteille,
                    Millesime = millesimeBouteille,
                    GardeConseilleDebut = Gardedebut,
                    GardeConseilleFin = Gardefin,
                    IdAppelation = IdAppelation.Value,
                    IdCave = 1,
                    IdCouleur = IdCouleur.Value,

                    // ... initialisez les autres propriétés au besoin ...
                };

                // Ajouter la nouvelle bouteille au contexte
                context.Bouteilles.Add(nouvelleBouteille);

                // Sauvegarder les changements dans la base de données
                context.SaveChanges();

                MessageBox.Show("Nouvelle bouteille ajoutée avec succès !");
            }
        }


        public void showbouteilleinbox()
        {
            using (MlmvinContext db = new MlmvinContext())
            {
                var bouteilles = from bouteille in db.Bouteilles
                                 join appelation in db.DescriptionBouteilleAppelations on bouteille.IdAppelation equals appelation.IdAppelation
                                 join couleur in db.DescriptionBouteilleCouleurs on bouteille.IdCouleur equals couleur.IdCouleur
                                 select new
                                 {
                                     Bouteille = bouteille,
                                     Appelation = appelation.Appelation,
                                     Couleur = couleur.CouleurVin
                                 };
                lvGeneral.View = View.Tile;
                lvGeneral.TileSize = new Size(250, 50);

                // Déclaration des colonnes
                lvGeneral.Columns.Add("Nom Complet Vin");
                lvGeneral.Columns.Add("Domain");
                lvGeneral.Columns.Add("Type vins");
                // Boucle qui ajout les informations pour chaque bouteilles
                foreach (var bouteille in bouteilles)
                {
                    ListViewItem item = new ListViewItem(bouteille.Bouteille.NomCompletVin);
                    item.SubItems.Add(bouteille.Appelation);
                    item.SubItems.Add(bouteille.Couleur);
                    lvGeneral.Items.Add(item);
                }
            }
        }

        private void FormEdition_Load(object sender, EventArgs e)
        {

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (lvGeneral.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une bouteille à modifier.");
                return;
            }

            // Récupérer l'ID de la bouteille sélectionnée
            int bouteilleId = Convert.ToInt32(lvGeneral.SelectedItems[0].Tag);

            using (MlmvinContext db = new MlmvinContext())
            {
                var bouteille = db.Bouteilles.FirstOrDefault(b => b.IdBouteille == bouteilleId);
                if (bouteille != null)
                {
                    // Charger les détails de la bouteille dans les contrôles pour modification
                    tbxNom.Text = bouteille.NomCompletVin;
                    tbxMillesime.Text = bouteille.Millesime.ToString();
                    tbxGardeDebut.Text = bouteille.GardeConseilleDebut.ToString();
                    tbxGardeFin.Text = bouteille.GardeConseilleFin.ToString();

                    // Sélectionnez l'appellation et la couleur correspondantes dans les ComboBoxes
                    cbbAppelation.SelectedValue = bouteille.IdAppelation;
                    cbbCouleur.SelectedValue = bouteille.IdCouleur;

                    // Stocker l'ID de la bouteille en cours de modification pour une utilisation ultérieure lors de la sauvegarde
                    btnModifier.Tag = bouteilleId;
                }
            }
        }

        private void cbbCave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCave.SelectedIndex != -1)
            {
                RemplireComboboxTiroirePlace();
            }
            
        }

        private void btnAjout_Click_1(object sender, EventArgs e)
        {
            AjouterBouteille();
            showbouteilleinbox();
        }
    }
}



