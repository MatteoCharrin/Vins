using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logiciel_de_gestion_de_cave_a_vin.Models
{

    class Utilitaire
    {


        public static void ApplyBorderRadius(Control control, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Coins supérieurs gauche et droit
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Y, diameter, diameter, 270, 90);

            // Coin inférieur droit
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);

            // Coin inférieur gauche
            path.AddArc(bounds.X, bounds.Bottom - diameter, diameter, diameter, 90, 90);

            path.CloseFigure();

            control.Region = new Region(path);
        }





        public static void RemplireCombobox(ComboBox combobox, string autreTitre = "")
        {
            string databaseName = combobox.Name.Replace("cbb", "");
            if (autreTitre != "")
            {
                databaseName = autreTitre.Replace("cbb", "");
            }

            switch (databaseName)
            {
                case "Cave":
                    using (MlmvinContext context = new MlmvinContext())
                    {
                        var Caves = context.Caves.ToList();
                        combobox.DataSource = Caves;
                    }

                    combobox.DisplayMember = "NomCave";
                    combobox.ValueMember = "IdCave";

                    break;
                case "Couleur":
                    using (MlmvinContext context = new MlmvinContext())
                    {
                        var DescriptionBouteilleCouleurs = context.DescriptionBouteilleCouleurs.ToList();
                        combobox.DataSource = DescriptionBouteilleCouleurs;

                    }

                    combobox.DisplayMember = "CouleurVin";
                    combobox.ValueMember = "IdCouleur";
                    break;
                case "Appelation":
                    using (MlmvinContext context = new MlmvinContext())
                    {
                        var DescriptionBouteilleAppelations = context.DescriptionBouteilleAppelations.ToList();

                        combobox.DataSource = DescriptionBouteilleAppelations;
                    }

                    combobox.DisplayMember = "Appelation";
                    combobox.ValueMember = "IdAppelation";
                    break;
                case "Fabricant":
                    using (MlmvinContext context = new MlmvinContext())
                    {
                        var Fabricants = context.Fabricants.ToList();

                        combobox.DataSource = Fabricants;
                    }

                    combobox.DisplayMember = "NomFabricant";
                    combobox.ValueMember = "IdFabricant";
                    break;

            }

            combobox.SelectedIndex = 0;

        }

        public static bool ValideSaisie(TextBox tbxNom, TextBox tbxMillesime, TextBox tbxGardeDebut,
            TextBox tbxGardeFin) // Vérification Saisie 
        {
            string nomBouteille = tbxNom.Text;
            DateTime millesimeBouteille;
            int Gardedebut, Gardefin;

            // Validation du champ Nom
            if (string.IsNullOrWhiteSpace(nomBouteille))
            {
                MessageBox.Show("Veuillez entrer un nom de bouteille valide.");
                return false;
            }

            // Validation du champ Millesime
            if (DateTime.TryParseExact(tbxMillesime.Text, "YYYY", null, System.Globalization.DateTimeStyles.None,
                    out DateTime result))
            {
                MessageBox.Show("Veuillez entrer une date de millésime valide.");
                return false;
            }

            // Validation du champ Garde Début
            if (!int.TryParse(tbxGardeDebut.Text, out Gardedebut))
            {
                MessageBox.Show("Veuillez entrer un nombre valide pour la garde début.");
                return false;
            }

            // Validation du champ Garde Fin
            if (!int.TryParse(tbxGardeFin.Text, out Gardefin))
            {
                MessageBox.Show("Veuillez entrer un nombre valide pour la garde fin.");
                return false;
            }

            // Si toutes les validations passent, retournez true
            return true;
        }

        public static Object RecupererIndexSelectionne(ListView listView)
        {
            // Récupérer la bouteille sélectionnée
            ListViewItem selectedItem = listView.SelectedItems[0];
            Object ObjectSelect = (Object)selectedItem.Tag;
            return ObjectSelect;
        }
        public static void RemplireComboboxTiroirePlace(ComboBox cbbCave, ComboBox cbbTiroire, ComboBox cbbEmplacemnt, bool SelectTiroire = false)

        {
            Cave CaveSelectione = (Cave)cbbCave.SelectedItem;
            Cave Caves;
            using (MlmvinContext context = new MlmvinContext())
            {
                Caves = context.Caves.Where(o => o.IdCave == CaveSelectione.IdCave).Single();
            }


            if (!SelectTiroire)
            {
                cbbTiroire.Items.Clear();

                for (var i = 1; i < Caves.NombreTiroir + 1; i++)
                {
                    cbbTiroire.Items.Add(i);
                }
                cbbTiroire.SelectedIndex = 0;
            }
            cbbEmplacemnt.Items.Clear();
            for (var i = 1; i < Caves.BouteillesParTiroir + 1; i++)
            {
                cbbEmplacemnt.Items.Add(i);
            }

            cbbEmplacemnt.SelectedIndex = 0;


        }
    }
}
