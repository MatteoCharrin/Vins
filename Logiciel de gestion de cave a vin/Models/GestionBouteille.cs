using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel_de_gestion_de_cave_a_vin.Models
{
    class GestionBouteille
    {
        public static void ChargerListeWithObject(ListView ListeView, Dictionary<string, Image> cheminImageParCouleur,
            Bouteille Bouteille, string Appelation, string Couleur, DateTime Millesime)
        {

            ListViewItem item = new ListViewItem(Bouteille.NomCompletVin);
            item.SubItems.Add(Appelation);
            item.SubItems.Add(Couleur);
            item.SubItems.Add(Millesime.ToString("yyyy"));

            // Ajout des images pour chaque type de vin 
            if (cheminImageParCouleur.ContainsKey(Couleur))
            {
                // Créez un objet Image à partir du chemin d'image local
                Image image = cheminImageParCouleur[Couleur];

                // Ajoutez l'image à la liste d'images du ListView
                ListeView.LargeImageList.Images.Add(Bouteille.NomCompletVin, image);

                // Associez l'image à l'élément actuel
                item.ImageKey = Bouteille.NomCompletVin;
            }

            item.Tag = Bouteille;
            ListeView.Items.Add(item);

        }

        private static bool ConfirmerAjoutBouteille(ComboBox cbbEmplacemnt, ComboBox cbbTiroire)
        {
            // Vérifiez si cbbEmplacement et cbbTiroir sont sélectionnés
            if (cbbEmplacemnt.SelectedIndex == -1 || cbbTiroire.SelectedIndex == -1)
            {
                DialogResult confirmation =
                    MessageBox.Show(
                        "Les champs Emplacement et Tiroir ne sont pas saisis. Êtes-vous sûr de vouloir continuer ?",
                        "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Retournez true si l'utilisateur clique sur "Oui", sinon false
                return confirmation == DialogResult.Yes;
            }

            // Si les champs sont saisis, retournez true directement
            return true;
        }

        public static void AjouterBouteille(ListView listView, TextBox tbxNom, TextBox tbxMillesime,
            TextBox tbxGardeDebut, TextBox tbxGardeFin, ComboBox cbbAppelation, ComboBox cbbCouleur,
            ComboBox cbbEmplacemnt, ComboBox cbbTiroire)
        {
            string nomBouteille = tbxNom.Text;
            DateTime millesimeBouteille = new DateTime(int.Parse(tbxMillesime.Text), 1, 1);
            int Gardedebut = Int32.Parse(tbxGardeDebut.Text);
            int Gardefin = Int32.Parse(tbxGardeFin.Text);

            var selectedAppelation = cbbAppelation.SelectedItem as DescriptionBouteilleAppelation;
            int? IdAppelation = selectedAppelation?.IdAppelation;
            var selectedcouleur = cbbCouleur.SelectedItem as DescriptionBouteilleCouleur;
            int? IdCouleur = selectedcouleur?.IdCouleur;

            // Valider les champs avant d'ajouter une bouteille
            if (!Utilitaire.ValideSaisie(tbxNom, tbxMillesime, tbxGardeDebut, tbxGardeFin))
            {
                // Sortir de la méthode si la validation échoue
                return;
            }

            // Appeler la méthode de confirmation
            if (!ConfirmerAjoutBouteille(cbbEmplacemnt, cbbTiroire))
            {
                // L'utilisateur a annulé l'ajout
                return;
            }

            listView.Items.Clear();
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

                };

                // Ajouter la nouvelle bouteille au contexte
                context.Bouteilles.Add(nouvelleBouteille);

                // Sauvegarder les changements dans la base de données
                context.SaveChanges();

                MessageBox.Show("Nouvelle bouteille ajoutée avec succès !");
            }

        }

        public static Dictionary<string, Image> ChargerImage()
        {
            Dictionary<string, Image> cheminImageParCouleur = new Dictionary<string, Image>
            {
                { "Rouge", Image.FromFile(@"C:\Users\Sayo\Downloads\rouge.png") },
                { "Blanc", Image.FromFile(@"C:\Users\Sayo\Downloads\blanc.png") },
                { "Rosé", Image.FromFile(@"C:\Users\Sayo\Downloads\rose.png") }
            };
            return (cheminImageParCouleur);
        }

        public static void ChargerListeView(ListView ListeView)
        {
            Dictionary<string, Image> cheminImageParCouleur;
            cheminImageParCouleur = ChargerImage();
            ListeView.Items.Clear();
            using (MlmvinContext db = new MlmvinContext())
            {

                var bouteilles = from bouteille in db.Bouteilles
                    join appelation in db.DescriptionBouteilleAppelations on bouteille.IdAppelation equals appelation
                        .IdAppelation
                    join couleur in db.DescriptionBouteilleCouleurs on bouteille.IdCouleur equals couleur.IdCouleur
                    select new
                    {
                        Bouteille = bouteille,
                        Appelation = appelation.Appelation,
                        Couleur = couleur.CouleurVin,
                        Millesime = bouteille.Millesime
                    };
                ListeView.View = View.Tile;
                ListeView.TileSize = new Size(250, 100);

                ImageList imageList = new ImageList();
                imageList.ImageSize = new Size(64, 64);
                ListeView.LargeImageList = imageList;

                // Déclaration des colonnes
                ListeView.Columns.Add("Nom Complet Vin");
                ListeView.Columns.Add("Domain");
                ListeView.Columns.Add("Type vins");
                ListeView.Columns.Add("Millésime");


                // Boucle qui ajout les informations pour chaque bouteilles

                foreach (var bouteille in bouteilles)
                {
                    GestionBouteille.ChargerListeWithObject(ListeView, cheminImageParCouleur, bouteille.Bouteille, bouteille.Appelation,
                        bouteille.Couleur,
                        bouteille.Millesime);
                }
            }
        }

        public static void Modifier(ListView listView, TextBox tbxNom, TextBox tbxMillesime, TextBox tbxGardeDebut, TextBox tbxGardeFin, ComboBox cbbAppelation, ComboBox cbbCouleur)
        {
            // Récupérer l'ID de la bouteille à modifier, par exemple, à partir de la sélection dans une liste ou un autre contrôle
            Bouteille bouteilleSelect = (Bouteille)Utilitaire.RecupererIndexSelectionne(listView);
            int idBouteilleAModifier = bouteilleSelect.IdBouteille;

            // Valider les champs avant de modifier une bouteille
            if (!Utilitaire.ValideSaisie(tbxNom, tbxMillesime, tbxGardeDebut, tbxGardeFin))
            {
                // Sortir de la méthode si la validation échoue
                return;
            }



            using (MlmvinContext context = new MlmvinContext())
            {
                // Récupérer la bouteille existante à partir de la base de données
                Bouteille bouteilleAModifier = context.Bouteilles.Find(idBouteilleAModifier);

                if (bouteilleAModifier != null)
                {
                    // Mettre à jour les propriétés de la bouteille existante
                    bouteilleAModifier.NomCompletVin = tbxNom.Text;
                    bouteilleAModifier.Millesime = new DateTime(int.Parse(tbxMillesime.Text), 1, 1);
                    bouteilleAModifier.GardeConseilleDebut = Int32.Parse(tbxGardeDebut.Text);
                    bouteilleAModifier.GardeConseilleFin = Int32.Parse(tbxGardeFin.Text);

                    var selectedAppelation = cbbAppelation.SelectedItem as DescriptionBouteilleAppelation;
                    bouteilleAModifier.IdAppelation = selectedAppelation.IdAppelation;

                    var selectedCouleur = cbbCouleur.SelectedItem as DescriptionBouteilleCouleur;
                    bouteilleAModifier.IdCouleur = selectedCouleur.IdCouleur;

                    // Sauvegarder les changements dans la base de données
                    context.SaveChanges();

                    MessageBox.Show("Bouteille modifiée avec succès !");
                    GestionBouteille.ChargerListeView(listView);
                }
                else
                {
                    MessageBox.Show("Bouteille non trouvée dans la base de données.");
                }
            }
        }

        public static void AddAppelation(string nomAppelation)
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

        public static void Select(ListView listView, TextBox tbxNom, TextBox tbxMillesime, TextBox tbxGardeDebut, TextBox tbxGardeFin, ComboBox cbbAppelation, ComboBox cbbCouleur, ComboBox cbbCave, ComboBox cbbTiroire, ComboBox cbbEmplacemnt)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une bouteille à modifier.");
                return;
            }

            Bouteille bouteilleSelect = (Bouteille)Utilitaire.RecupererIndexSelectionne(listView);


            using (MlmvinContext db = new MlmvinContext())
            {
                Bouteille bouteille = db.Bouteilles.FirstOrDefault(b => b.IdBouteille == bouteilleSelect.IdBouteille);
                if (bouteille != null)
                {
                    // Charger les détails de la bouteille dans les contrôles pour modification
                    tbxNom.Text = bouteille.NomCompletVin;
                    tbxMillesime.Text = bouteille.Millesime.ToString("yyyy");
                    tbxGardeDebut.Text = bouteille.GardeConseilleDebut.ToString();
                    tbxGardeFin.Text = bouteille.GardeConseilleFin.ToString();

                    //Chargement de l'emplacement dans la cave
                    cbbCave.SelectedValue = bouteille.IdCave;

                    cbbTiroire.SelectedValue = bouteille.NumeroTiroir;
                    Utilitaire.RemplireComboboxTiroirePlace(cbbCave, cbbTiroire, cbbEmplacemnt);
                    cbbEmplacemnt.SelectedValue = bouteille.EmplacementBouteille;

                    // Sélectionnez l'appellation et la couleur correspondantes dans les ComboBoxes
                    cbbAppelation.SelectedValue = bouteille.IdAppelation;
                    cbbCouleur.SelectedValue = bouteille.IdCouleur;

                }
            }
        }

        public static void Delete(ListView listeView)
        {
            using (MlmvinContext context = new MlmvinContext())
            {
                // Récupérer la bouteille existante à partir de la base de données
                Bouteille bouteilleSelect = (Bouteille)Utilitaire.RecupererIndexSelectionne(listeView);

                if (bouteilleSelect != null)
                {
                    // Supprimer la bouteille du contexte
                    context.Bouteilles.Remove(bouteilleSelect);

                    // Sauvegarder les changements dans la base de données
                    context.SaveChanges();

                    MessageBox.Show("Bouteille supprimée avec succès !");
                }
                else
                {
                    MessageBox.Show("Bouteille non trouvée dans la base de données.");
                }
            }
            GestionBouteille.ChargerListeView(listeView);
        }
    }
}
