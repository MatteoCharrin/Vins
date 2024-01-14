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
        private bool BouteilleEstSelect = false;
        public FormEdition()
        {
            InitializeComponent();
            Hide_Bouteille();
            Utilitaire.ApplyBorderRadius(btnAjout, 15);
            Utilitaire.ApplyBorderRadius(btnCave, 15);
            Utilitaire.ApplyBorderRadius(btnModifier, 15);
            Utilitaire.ApplyBorderRadius(btnSupprimer, 15);
            Utilitaire.ApplyBorderRadius(btnBouteille, 15);

        }
        public void Hide_Bouteille()
        {

            Control[] controlsToInvisible = {
                btnSupprimer, btnAjout, btnModifier, btnAjoutAppelation,
                tbxGardeDebut, tbxAjoutAppelation, tbxGardeFin, tbxMillesime, tbxNom,
                cbbAppelation, cbbCouleur, cbbEmplacemnt, cbbTiroire, cbbCave,
                label1, label2, label3, label4, label5, label6, label7, label_8, label8, tbxType, lbType
            };

            foreach (Control control in controlsToInvisible)
            {
                control.Visible = false;
            }
            BouteilleEstSelect = false;

        }
        public void Hide_Cave()
        {
            label3.Text = "Appelation :";
            label2.Text = "Garde Conseiller :";
            label7.Text = "Millésime :";
            tbxGardeDebut.Left = 659;
            tbxGardeFin.Left = 753;
            tbxMillesime.Left = 659;
            label7.Left = 524;
            tbxType.Visible = false;
            lbType.Visible = false;
        }
        public void Show_Cave()
        {
            btnSupprimer.Visible = true;
            btnAjout.Visible = true;
            btnModifier.Visible = true;
            label1.Visible = true;
            tbxNom.Visible = true;
            label3.Visible = true;
            cbbAppelation.Visible = true;
            btnAjoutAppelation.Visible = true;
            tbxAjoutAppelation.Visible = true;
            label3.Text = "Fabricant :";
            label2.Text = "Tiroire / NbEmplacement :";
            label2.Visible = true;
            tbxGardeFin.Visible = true;
            tbxGardeDebut.Left = 659 + 125;
            tbxGardeFin.Left = 753 + 125;
            tbxGardeDebut.Visible = true;
            tbxMillesime.Visible = true;
            tbxMillesime.Left = 659 + 125;

            label7.Visible = true;
            label7.Text = "Temperature °C :";
            label7.Left = 524 + 32;
            tbxType.Visible = true;
            lbType.Visible = true;


            // Vide avant d'ajouter des éléments
            GestionCave.AffichageCave(lvGeneral);

        }



        public void Show_Bouteille()
        {
            BouteilleEstSelect = true;
            Control[] controlsToVisible = {
                btnSupprimer, btnAjout, btnModifier, btnAjoutAppelation,
                tbxGardeDebut, tbxAjoutAppelation, tbxGardeFin, tbxMillesime, tbxNom,
                cbbAppelation, cbbCouleur, cbbEmplacemnt, cbbTiroire, cbbCave,
                label1, label2, label3, label4, label5, label6, label7, label_8, label8
            };

            foreach (Control control in controlsToVisible)
            {
                control.Visible = true;
            }
            // Vide avant d'ajouter des éléments
            lvGeneral.Items.Clear();
            GestionBouteille.ChargerListeView(lvGeneral);

        }


        private void btnCave_Click(object sender, EventArgs e)
        {
            Hide_Bouteille();
            Utilitaire.RemplireCombobox(cbbAppelation, "cbbFabricant");
            Show_Cave();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBouteille_Click(object sender, EventArgs e)
        {
            Hide_Cave();
            Show_Bouteille();
            Utilitaire.RemplireCombobox(cbbCouleur);
            Utilitaire.RemplireCombobox(cbbAppelation);
            Utilitaire.RemplireCombobox(cbbCave);
            Utilitaire.RemplireComboboxTiroirePlace(cbbCave, cbbTiroire, cbbEmplacemnt);
        }



        private void RemplireComboboxTiroir()
        {
            Cave CaveSelectione = (Cave)cbbCave.SelectedItem;
            int NumeroTiroir = cbbEmplacemnt.SelectedIndex;
            List<Bouteille> bouteilles;
            using (MlmvinContext context = new MlmvinContext())
            {
                bouteilles = context.Bouteilles.Where(o => o.IdCave == CaveSelectione.IdCave && o.NumeroTiroir == NumeroTiroir).ToList();
            }

            foreach (var bouteille in bouteilles)
            {
                cbbEmplacemnt.Items.Remove(bouteille.EmplacementBouteille);
            }

        }
        private void cbbCave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCave.SelectedIndex != -1)
            {
                if (cbbTiroire.Items.Count > 0)
                {
                    Utilitaire.RemplireComboboxTiroirePlace(cbbCave, cbbTiroire, cbbEmplacemnt);
                }
                else
                {
                    Utilitaire.RemplireComboboxTiroirePlace(cbbCave, cbbTiroire, cbbEmplacemnt, true);
                }

                RemplireComboboxTiroir();
            }
        }

        private void cbbTiroire_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTiroire.SelectedIndex != -1)
            {
                RemplireComboboxTiroir();
            }

        }

        private void btnAjoutAppelation_Click(object sender, EventArgs e)
        {
            string nomAppelation = tbxAjoutAppelation.Text;
            if (!string.IsNullOrWhiteSpace(nomAppelation))
            {
                AddAppelation(nomAppelation);
                tbxAjoutAppelation.Text = string.Empty;
                Utilitaire.RemplireCombobox(cbbAppelation);
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom d'appellation valide.");
            }
        }



        private void AddAppelation(string nomAppelation)
        {
            if (BouteilleEstSelect)
            {
                GestionBouteille.AddAppelation(nomAppelation);
            }
            else
            {
                GestionCave.AddAppelation(nomAppelation);
            }
        }




        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (BouteilleEstSelect)
            {
                GestionBouteille.Modifier(lvGeneral, tbxNom, tbxMillesime, tbxGardeDebut, tbxGardeFin, cbbAppelation, cbbCouleur);
            }
            else
            {
                GestionCave.Modifier(lvGeneral, tbxNom, tbxMillesime, tbxGardeDebut, tbxGardeFin, tbxType, cbbAppelation);
            }

        }



        private void lvGeneral_Click(object sender, EventArgs e)
        {
            if (BouteilleEstSelect)
            {
                GestionBouteille.Select(lvGeneral, tbxNom, tbxMillesime, tbxGardeDebut, tbxGardeFin, cbbAppelation, cbbCouleur, cbbCave, cbbTiroire, cbbEmplacemnt);
            }
            else
            {
                GestionCave.Select(lvGeneral, tbxNom, tbxMillesime, tbxGardeDebut, tbxGardeFin, tbxType, cbbAppelation);
            }

        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            if (BouteilleEstSelect)
            {
                GestionBouteille.AjouterBouteille(lvGeneral, tbxNom, tbxMillesime, tbxGardeDebut, tbxGardeFin, cbbAppelation, cbbCouleur, cbbEmplacemnt, cbbTiroire);
                GestionBouteille.ChargerListeView(lvGeneral);
            }
            else
            {
                GestionCave.AjouterCave(lvGeneral, tbxNom, tbxMillesime, tbxGardeDebut, tbxGardeFin, tbxType, cbbAppelation);
                GestionCave.AffichageCave(lvGeneral);
            }


        }



        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (BouteilleEstSelect)
            {
                GestionBouteille.Delete(lvGeneral);
            }
            else
            {
                GestionCave.Delete(lvGeneral);

            }

        }
    }
}
