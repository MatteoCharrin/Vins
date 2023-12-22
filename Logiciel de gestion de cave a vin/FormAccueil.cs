using Logiciel_de_gestion_de_cave_a_vin.Models;

namespace Logiciel_de_gestion_de_cave_a_vin
{
    public partial class FormAccueil : Form
    {

        Dictionary<string, Image> cheminImageParCouleur = new Dictionary<string, Image>
                {
                    { "Rouge", Image.FromFile(@"C:\Users\Sayo\Downloads\rouge.png") },
                    { "Blanc", Image.FromFile(@"C:\Users\Sayo\Downloads\blanc.png")},
                    { "Rosé", Image.FromFile(@"C:\Users\Sayo\Downloads\rose.png") }
                };
        public FormAccueil()
        {
            InitializeComponent();

            // Ajoute les bouteilles dans la lbxBouteille
            using (MlmvinContext db = new MlmvinContext())
            {
                
                var  bouteilles = from bouteille in db.Bouteilles
                                             join appelation in db.DescriptionBouteilleAppelations on bouteille.IdAppelation equals appelation.IdAppelation
                                             join couleur in db.DescriptionBouteilleCouleurs on bouteille.IdCouleur equals couleur.IdCouleur
                                             select new
                                             {
                                                 Bouteille = bouteille,
                                                 Appelation = appelation.Appelation,
                                                 Couleur = couleur.CouleurVin,
                                                 Millesime = bouteille.Millesime
                                             };
                lvBouteille.View = View.Tile;
                lvBouteille.TileSize = new Size(250, 70);

                ImageList imageList = new ImageList();
                imageList.ImageSize = new Size(64, 64);
                lvBouteille.LargeImageList = imageList;

                // Déclaration des colonnes
                lvBouteille.Columns.Add("Nom Complet Vin");
                lvBouteille.Columns.Add("Domain");
                lvBouteille.Columns.Add("Type vins");
                lvBouteille.Columns.Add("Millésime");


                // Boucle qui ajout les informations pour chaque bouteilles
                foreach (var bouteille in bouteilles)
                {
                      ListViewItem item = new ListViewItem(bouteille.Bouteille.NomCompletVin);
                      item.SubItems.Add(bouteille.Appelation);
                      item.SubItems.Add(bouteille.Couleur);
                      item.SubItems.Add(bouteille.Millesime.ToString("yyyy"));

                    // Ajout des images pour chaque type de vin 
                    if (cheminImageParCouleur.ContainsKey(bouteille.Couleur))
                    {
                        // Créez un objet Image à partir du chemin d'image local
                        Image image = cheminImageParCouleur[bouteille.Couleur];

                        // Ajoutez l'image à la liste d'images du ListView
                        lvBouteille.LargeImageList.Images.Add(bouteille.Bouteille.NomCompletVin, image);

                        // Associez l'image à l'élément actuel
                        item.ImageKey = bouteille.Bouteille.NomCompletVin;
                    }
                    lvBouteille.Items.Add(item);
                }
            }
        }

        private void lbxBouteille_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbxRecherche_TextChanged(object sender, EventArgs e)
        {
            // Récupérer le texte de recherche
            string searchText = tbxRecherche.Text;

            using (MlmvinContext db = new MlmvinContext())
            {
                // Construction de la requête LINQ de manière dynamique
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
                              // ImagePath = // Ajoutez ici la logique pour obtenir le chemin de l'image associée à la bouteille
                            };
                            lvBouteille.Items.Clear();
                            foreach (var bouteille in bouteilles)
                            {
                                ListViewItem item = new ListViewItem(bouteille.Bouteille.NomCompletVin);
                                item.SubItems.Add(bouteille.Appelation);
                                item.SubItems.Add(bouteille.Couleur);
                                item.SubItems.Add(bouteille.Millesime.ToString("yyyy"));
                                // Ajout des images pour chaque type de vin 
                                if (cheminImageParCouleur.ContainsKey(bouteille.Couleur))
                                {
                                    // Créez un objet Image à partir du chemin d'image local
                                    Image image = cheminImageParCouleur[bouteille.Couleur];

                                    // Ajoutez l'image à la liste d'images du ListView
                                    lvBouteille.LargeImageList.Images.Add(bouteille.Bouteille.NomCompletVin, image);

                                    // Associez l'image à l'élément actuel
                                    item.ImageKey = bouteille.Bouteille.NomCompletVin;
                                }
                            lvBouteille.Items.Add(item);
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
                // Construction de la requête LINQ de manière dynamique
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
                    int dateDebut = Int32.Parse(bouteille.Millesime.ToString("yyyy")) + bouteille.GardeMini;
                    int dateLimite = Int32.Parse(bouteille.Millesime.ToString("yyyy")) + bouteille.GardeMaxi;
                    int dateAjourdhui = Int32.Parse(DateTime.Now.ToString("yyyy"));

                    if (dateDebut <= dateAjourdhui && dateAjourdhui <= dateLimite)
                    {
                        ListViewItem item = new ListViewItem(bouteille.Bouteille.NomCompletVin);
                        item.SubItems.Add(bouteille.Appelation);
                        item.SubItems.Add(bouteille.Couleur);
                        item.SubItems.Add(bouteille.Millesime.ToString("yyyy"));

                        // Ajout des images pour chaque type de vin 
                    if (cheminImageParCouleur.ContainsKey(bouteille.Couleur))
                    {
                        // Créez un objet Image à partir du chemin d'image local
                        Image image = cheminImageParCouleur[bouteille.Couleur];

                        // Ajoutez l'image à la liste d'images du ListView
                        lvBouteille.LargeImageList.Images.Add(bouteille.Bouteille.NomCompletVin, image);

                        // Associez l'image à l'élément actuel
                        item.ImageKey = bouteille.Bouteille.NomCompletVin;
                    }
                    lvBouteille.Items.Add(item);
                    }
                }

            }
        }

        private void lvBouteille_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}