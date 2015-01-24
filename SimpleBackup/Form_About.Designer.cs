namespace SimpleBackup
{
    partial class Form_About
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_About));
            this.PictureBox_Logo = new System.Windows.Forms.PictureBox();
            this.Label_SimpleBackupTitle = new System.Windows.Forms.Label();
            this.Label_Description = new System.Windows.Forms.Label();
            this.Button_CheckForUpdates = new System.Windows.Forms.Button();
            this.Button_Back = new System.Windows.Forms.Button();
            this.Label_Author = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // PictureBox_Logo
            // 
            this.PictureBox_Logo.ErrorImage = null;
            this.PictureBox_Logo.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox_Logo.Image")));
            this.PictureBox_Logo.InitialImage = null;
            this.PictureBox_Logo.Location = new System.Drawing.Point(87, 13);
            this.PictureBox_Logo.Name = "PictureBox_Logo";
            this.PictureBox_Logo.Size = new System.Drawing.Size(150, 150);
            this.PictureBox_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox_Logo.TabIndex = 0;
            this.PictureBox_Logo.TabStop = false;
            // 
            // Label_SimpleBackupTitle
            // 
            this.Label_SimpleBackupTitle.AutoSize = true;
            this.Label_SimpleBackupTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_SimpleBackupTitle.Location = new System.Drawing.Point(40, 166);
            this.Label_SimpleBackupTitle.Name = "Label_SimpleBackupTitle";
            this.Label_SimpleBackupTitle.Size = new System.Drawing.Size(245, 26);
            this.Label_SimpleBackupTitle.TabIndex = 1;
            this.Label_SimpleBackupTitle.Text = "SimpleBackup " + ProductVersion;
            this.Label_SimpleBackupTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label_Description
            // 
            this.Label_Description.AutoSize = true;
            this.Label_Description.Location = new System.Drawing.Point(42, 215);
            this.Label_Description.Name = "Label_Description";
            this.Label_Description.Size = new System.Drawing.Size(238, 65);
            this.Label_Description.TabIndex = 2;
            this.Label_Description.Text = "SimpleBackup ist ein Open-Source Backup Tool.\r\nEs soll dazu dienen einfach und sc" +
                "hnell simple\r\nBackup zu erstellen, wobei auf komplizierten \r\nund teils unnötigen" +
                " \"Schnick Schnack\" \r\nverzichtet wird.";
            this.Label_Description.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Button_CheckForUpdates
            // 
            this.Button_CheckForUpdates.Location = new System.Drawing.Point(72, 287);
            this.Button_CheckForUpdates.Name = "Button_CheckForUpdates";
            this.Button_CheckForUpdates.Size = new System.Drawing.Size(180, 23);
            this.Button_CheckForUpdates.TabIndex = 3;
            this.Button_CheckForUpdates.Text = "Auf Updates prüfen";
            this.Button_CheckForUpdates.UseVisualStyleBackColor = true;
            this.Button_CheckForUpdates.Click += new System.EventHandler(this.Button_CheckForUpdates_Click);
            // 
            // Button_Back
            // 
            this.Button_Back.Location = new System.Drawing.Point(72, 317);
            this.Button_Back.Name = "Button_Back";
            this.Button_Back.Size = new System.Drawing.Size(180, 23);
            this.Button_Back.TabIndex = 4;
            this.Button_Back.Text = "Zurück";
            this.Button_Back.UseVisualStyleBackColor = true;
            this.Button_Back.Click += new System.EventHandler(this.Button_Back_Click);
            // 
            // Label_Author
            // 
            this.Label_Author.AutoSize = true;
            this.Label_Author.Location = new System.Drawing.Point(108, 192);
            this.Label_Author.Name = "Label_Author";
            this.Label_Author.Size = new System.Drawing.Size(104, 13);
            this.Label_Author.TabIndex = 5;
            this.Label_Author.Text = "von Hauke L. Stieler";
            // 
            // Form_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(334, 352);
            this.Controls.Add(this.Label_Author);
            this.Controls.Add(this.Button_Back);
            this.Controls.Add(this.Button_CheckForUpdates);
            this.Controls.Add(this.Label_Description);
            this.Controls.Add(this.Label_SimpleBackupTitle);
            this.Controls.Add(this.PictureBox_Logo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_About";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox_Logo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureBox_Logo;
        private System.Windows.Forms.Label Label_SimpleBackupTitle;
        private System.Windows.Forms.Label Label_Description;
        private System.Windows.Forms.Button Button_CheckForUpdates;
        private System.Windows.Forms.Button Button_Back;
        private System.Windows.Forms.Label Label_Author;
    }
}