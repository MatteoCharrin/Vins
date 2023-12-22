namespace Logiciel_de_gestion_de_cave_a_vin
{
    partial class FormAccueil
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ilBouteille = new System.Windows.Forms.ImageList(this.components);
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnApogee = new System.Windows.Forms.Button();
            this.tbxRecherche = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvBouteille = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ilBouteille
            // 
            this.ilBouteille.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilBouteille.ImageSize = new System.Drawing.Size(16, 16);
            this.ilBouteille.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(635, 446);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(254, 91);
            this.btnAjouter.TabIndex = 2;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnApogee
            // 
            this.btnApogee.Location = new System.Drawing.Point(896, 446);
            this.btnApogee.Name = "btnApogee";
            this.btnApogee.Size = new System.Drawing.Size(254, 91);
            this.btnApogee.TabIndex = 3;
            this.btnApogee.Text = "Apogée";
            this.btnApogee.UseVisualStyleBackColor = true;
            this.btnApogee.Click += new System.EventHandler(this.btnApogee_Click);
            // 
            // tbxRecherche
            // 
            this.tbxRecherche.Location = new System.Drawing.Point(742, 125);
            this.tbxRecherche.Name = "tbxRecherche";
            this.tbxRecherche.Size = new System.Drawing.Size(408, 23);
            this.tbxRecherche.TabIndex = 4;
            this.tbxRecherche.TextChanged += new System.EventHandler(this.tbxRecherche_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gabriola", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(580, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 59);
            this.label1.TabIndex = 5;
            this.label1.Text = "Recherche : ";
            // 
            // lvBouteille
            // 
            this.lvBouteille.Location = new System.Drawing.Point(12, 102);
            this.lvBouteille.Name = "lvBouteille";
            this.lvBouteille.Size = new System.Drawing.Size(541, 435);
            this.lvBouteille.TabIndex = 6;
            this.lvBouteille.UseCompatibleStateImageBehavior = false;
            this.lvBouteille.SelectedIndexChanged += new System.EventHandler(this.lvBouteille_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Maroon;
            this.label2.Font = new System.Drawing.Font("Gabriola", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 65);
            this.label2.TabIndex = 7;
            this.label2.Text = "WineVault";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Maroon;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1160, 80);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 619);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvBouteille);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxRecherche);
            this.Controls.Add(this.btnApogee);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FormAccueil";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageList ilBouteille;
        private Button btnAjouter;
        private Button btnApogee;
        private TextBox tbxRecherche;
        private Label label1;
        private ListView lvBouteille;
        private Label label2;
        private PictureBox pictureBox1;
    }
}