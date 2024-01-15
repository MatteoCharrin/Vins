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
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCave = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTirroire = new System.Windows.Forms.Label();
            this.lblEmplacement = new System.Windows.Forms.Label();
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
            this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(195)))), ((int)(((byte)(76)))));
            this.btnAjouter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAjouter.FlatAppearance.BorderSize = 0;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.Font = new System.Drawing.Font("Gabriola", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(595, 484);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(254, 91);
            this.btnAjouter.TabIndex = 2;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnApogee
            // 
            this.btnApogee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(117)))), ((int)(((byte)(188)))));
            this.btnApogee.FlatAppearance.BorderSize = 0;
            this.btnApogee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApogee.Font = new System.Drawing.Font("Gabriola", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnApogee.ForeColor = System.Drawing.Color.White;
            this.btnApogee.Location = new System.Drawing.Point(881, 484);
            this.btnApogee.Name = "btnApogee";
            this.btnApogee.Size = new System.Drawing.Size(254, 91);
            this.btnApogee.TabIndex = 3;
            this.btnApogee.Text = "Apogée";
            this.btnApogee.UseVisualStyleBackColor = false;
            this.btnApogee.Click += new System.EventHandler(this.btnApogee_Click);
            // 
            // tbxRecherche
            // 
            this.tbxRecherche.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(29)))), ((int)(((byte)(36)))));
            this.tbxRecherche.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxRecherche.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbxRecherche.ForeColor = System.Drawing.Color.White;
            this.tbxRecherche.Location = new System.Drawing.Point(744, 151);
            this.tbxRecherche.Multiline = true;
            this.tbxRecherche.Name = "tbxRecherche";
            this.tbxRecherche.Size = new System.Drawing.Size(391, 36);
            this.tbxRecherche.TabIndex = 4;
            this.tbxRecherche.TextChanged += new System.EventHandler(this.tbxRecherche_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(23)))));
            this.label1.Font = new System.Drawing.Font("Gabriola", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(582, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 59);
            this.label1.TabIndex = 5;
            this.label1.Text = "Recherche : ";
            // 
            // lvBouteille
            // 
            this.lvBouteille.BackColor = System.Drawing.Color.White;
            this.lvBouteille.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvBouteille.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lvBouteille.ForeColor = System.Drawing.Color.Black;
            this.lvBouteille.Location = new System.Drawing.Point(14, 140);
            this.lvBouteille.Name = "lvBouteille";
            this.lvBouteille.Size = new System.Drawing.Size(541, 435);
            this.lvBouteille.TabIndex = 6;
            this.lvBouteille.UseCompatibleStateImageBehavior = false;
            this.lvBouteille.Click += new System.EventHandler(this.lvBouteille_Click);
            this.lvBouteille.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvBouteille_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Maroon;
            this.label2.Font = new System.Drawing.Font("Gabriola", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 65);
            this.label2.TabIndex = 7;
            this.label2.Text = "WineVault";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Maroon;
            this.pictureBox1.Location = new System.Drawing.Point(1, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1167, 80);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Maroon;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Gadugi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1120, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(39, 29);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(23)))));
            this.label4.Font = new System.Drawing.Font("Gabriola", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(595, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 59);
            this.label4.TabIndex = 11;
            this.label4.Text = "Emplacement : ";
            // 
            // lblCave
            // 
            this.lblCave.AutoSize = true;
            this.lblCave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(23)))));
            this.lblCave.Font = new System.Drawing.Font("Gabriola", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCave.ForeColor = System.Drawing.Color.White;
            this.lblCave.Location = new System.Drawing.Point(793, 244);
            this.lblCave.Name = "lblCave";
            this.lblCave.Size = new System.Drawing.Size(83, 59);
            this.lblCave.TabIndex = 12;
            this.lblCave.Text = "CAVE";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(23)))));
            this.label5.Font = new System.Drawing.Font("Gabriola", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(595, 331);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 59);
            this.label5.TabIndex = 13;
            this.label5.Text = "Tirroire : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(23)))));
            this.label6.Font = new System.Drawing.Font("Gabriola", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(793, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 59);
            this.label6.TabIndex = 14;
            this.label6.Text = "Emplacement : ";
            // 
            // lblTirroire
            // 
            this.lblTirroire.AutoSize = true;
            this.lblTirroire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(23)))));
            this.lblTirroire.Font = new System.Drawing.Font("Gabriola", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTirroire.ForeColor = System.Drawing.Color.White;
            this.lblTirroire.Location = new System.Drawing.Point(704, 331);
            this.lblTirroire.Name = "lblTirroire";
            this.lblTirroire.Size = new System.Drawing.Size(56, 59);
            this.lblTirroire.TabIndex = 15;
            this.lblTirroire.Text = "NB";
            // 
            // lblEmplacement
            // 
            this.lblEmplacement.AutoSize = true;
            this.lblEmplacement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(18)))), ((int)(((byte)(23)))));
            this.lblEmplacement.Font = new System.Drawing.Font("Gabriola", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmplacement.ForeColor = System.Drawing.Color.White;
            this.lblEmplacement.Location = new System.Drawing.Point(977, 331);
            this.lblEmplacement.Name = "lblEmplacement";
            this.lblEmplacement.Size = new System.Drawing.Size(56, 59);
            this.lblEmplacement.TabIndex = 16;
            this.lblEmplacement.Text = "NB";
            // 
            // FormAccueil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = global::Logiciel_de_gestion_de_cave_a_vin.Properties.Resources.noir;
            this.ClientSize = new System.Drawing.Size(1162, 665);
            this.Controls.Add(this.lblEmplacement);
            this.Controls.Add(this.lblTirroire);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblCave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvBouteille);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxRecherche);
            this.Controls.Add(this.btnApogee);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "FormAccueil";
            this.Text = "WineVault - Accueil";
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
        private Button btnClose;
        private Label label3;
        private Label label4;
        private Label lblCave;
        private Label label5;
        private Label label6;
        private Label lblTirroire;
        private Label lblEmplacement;
    }
}