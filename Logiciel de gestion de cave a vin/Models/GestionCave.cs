using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel_de_gestion_de_cave_a_vin.Models
{
    class GestionCave
    {
        public static  void AffichageCave(ListView listView)
        {
            listView.Items.Clear();

            using (MlmvinContext db = new MlmvinContext())
            {
                var caves = db.Caves.ToList();
                listView.View = View.Tile;
                listView.TileSize = new Size(250, 50);

                // Déclaration des colonnes
                listView.Columns.Clear(); // Assurez-vous de nettoyer les colonnes précédentes
                listView.Columns.Add("Nom Cave");

                // Boucle qui ajout les informations pour chaque cave
                foreach (var cave in caves)
                {
                    ListViewItem item = new ListViewItem(cave.NomCave);
                    // Ajoutez d'autres propriétés de la cave si nécessaire

                    item.Tag = cave;
                    listView.Items.Add(item);
                }
            }
        }
        public static void AjouterCave(ListView lvGeneral, TextBox tbxNom, TextBox tbxMillesime, TextBox tbxGardeDebut,
            TextBox tbxGardeFin, TextBox tbxType, ComboBox cbbAppelation)
        {
            string nomCave = tbxNom.Text;
            decimal Temperature = decimal.Parse(tbxMillesime.Text);
            int NombreTiroire = int.Parse(tbxGardeDebut.Text);
            int BouteilleParTirroire = int.Parse(tbxGardeFin.Text);
            string type = tbxType.Text;

            var selectedFabricant = cbbAppelation.SelectedItem as Fabricant;
            int IdFabricant = selectedFabricant.IdFabricant;

            using (MlmvinContext context = new MlmvinContext())
            {
                // Créer une nouvelle instance de Bouteille
                Cave nouvCave = new Cave
                {
                    NomCave = nomCave,
                    Temperature = Temperature,
                    NombreTiroir = NombreTiroire,
                    BouteillesParTiroir = BouteilleParTirroire,
                    Type = type,
                    IdFabricant = IdFabricant

                };

                // Ajouter la nouvelle bouteille au contexte
                context.Caves.Add(nouvCave);

                // Sauvegarder les changements dans la base de données
                context.SaveChanges();

                MessageBox.Show("Nouvelle cave ajoutée avec succès !");
            }
        }

        public static void Modifier(ListView listView, TextBox tbxNom, TextBox tbxMillesime, TextBox tbxGardeDebut, TextBox tbxGardeFin, TextBox tbxType ,ComboBox cbbAppelation )
        {
            using (MlmvinContext context = new MlmvinContext())
            {
                Cave CaveSelect = (Cave)Utilitaire.RecupererIndexSelectionne(listView);
                Cave caveAModifier = context.Caves.Find(CaveSelect.IdCave);

                if (caveAModifier != null)
                {
                    // Mettre à jour les propriétés de la cave existante
                    caveAModifier.NomCave = tbxNom.Text;
                    caveAModifier.Temperature = decimal.Parse(tbxMillesime.Text);
                    caveAModifier.NombreTiroir = int.Parse(tbxGardeDebut.Text);
                    caveAModifier.BouteillesParTiroir = int.Parse(tbxGardeFin.Text);
                    caveAModifier.Type = tbxType.Text;

                    var selectedFabricant = cbbAppelation.SelectedItem as Fabricant;
                    caveAModifier.IdFabricant = selectedFabricant.IdFabricant;

                    // Sauvegarder les changements dans la base de données
                    context.SaveChanges();

                    MessageBox.Show("Cave modifiée avec succès !");
                    GestionCave.AffichageCave(listView);
                }
                else
                {
                    MessageBox.Show("Cave non trouvée dans la base de données.");
                }
            }
        }
        public static void AddAppelation(string nomAppelation)
        {
            using (MlmvinContext context = new MlmvinContext())
            {
                var appelationExistante = context.Fabricants
                    .FirstOrDefault(a => a.NomFabricant.ToLower() == nomAppelation.ToLower());

                if (appelationExistante == null)
                {
                    // Créer une nouvelle instance de DescriptionBouteilleAppelation
                    Fabricant nouvelleAppelation = new Fabricant()
                    {
                        NomFabricant = nomAppelation  // Assurez-vous que cette propriété correspond à votre modèle
                    };

                    // Ajouter la nouvelle appellation au contexte
                    context.Fabricants.Add(nouvelleAppelation);

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

        public static void Select(ListView listView, TextBox tbxNom, TextBox tbxMillesime, TextBox tbxGardeDebut, TextBox tbxGardeFin, TextBox tbxType, ComboBox cbbAppelation)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une cave à modifier.");
                return;
            }
            Cave CaveSelect = (Cave)Utilitaire.RecupererIndexSelectionne(listView);
            using (MlmvinContext db = new MlmvinContext())
            {
                Cave cave = db.Caves.FirstOrDefault(c => c.IdCave == CaveSelect.IdCave);
                if (cave != null)
                {
                    // Charger les détails de la bouteille dans les contrôles pour modification
                    tbxNom.Text = cave.NomCave;
                    tbxMillesime.Text = cave.Temperature.ToString();
                    tbxGardeDebut.Text = cave.NombreTiroir.ToString();
                    tbxGardeFin.Text = cave.BouteillesParTiroir.ToString();
                    tbxType.Text = cave.Type;
                    cbbAppelation.SelectedValue = cave.IdFabricant;
                }
            }
        }

        public static void Delete(ListView listView)
        {
            using (MlmvinContext context = new MlmvinContext())
            {
                Cave caveSelectionne = (Cave)Utilitaire.RecupererIndexSelectionne(listView);
                // Récupérer la cave existante à partir de la base de données
                Cave caveASupprimer = context.Caves.Find(caveSelectionne.IdCave);

                if (caveASupprimer != null)
                {
                    // Supprimer la cave du contexte
                    context.Caves.Remove(caveASupprimer);

                    // Sauvegarder les changements dans la base de données
                    context.SaveChanges();

                    MessageBox.Show("Cave supprimée avec succès !");
                }
                else
                {
                    MessageBox.Show("Cave non trouvée dans la base de données.");
                }
            }
        }

    }
}
