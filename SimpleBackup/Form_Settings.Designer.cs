namespace SimpleBackup
{
    partial class Form_Settings
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Settings));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TabPage_Language = new System.Windows.Forms.TabPage();
            this.Button_CreateSettingsBackup = new System.Windows.Forms.Button();
            this.Button_ResetSettings = new System.Windows.Forms.Button();
            this.Label_ChooseLanguage = new System.Windows.Forms.Label();
            this.ComboBox_Language = new System.Windows.Forms.ComboBox();
            this.TabPage_SavedSettings = new System.Windows.Forms.TabPage();
            this.Button_ApplySetting = new System.Windows.Forms.Button();
            this.TextBox_DestinationPath = new System.Windows.Forms.TextBox();
            this.TextBox_SourcePath = new System.Windows.Forms.TextBox();
            this.Button_NewSetting = new System.Windows.Forms.Button();
            this.Label_ListOfSettings = new System.Windows.Forms.Label();
            this.Button_DeleteSetting = new System.Windows.Forms.Button();
            this.ListBox_SavedSettings = new System.Windows.Forms.ListBox();
            this.Button_Save = new System.Windows.Forms.Button();
            this.Button_Cancel = new System.Windows.Forms.Button();
            this.ToolTip_Info = new System.Windows.Forms.ToolTip(this.components);
            this.TabControl.SuspendLayout();
            this.TabPage_Language.SuspendLayout();
            this.TabPage_SavedSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.TabPage_Language);
            this.TabControl.Controls.Add(this.TabPage_SavedSettings);
            this.TabControl.Location = new System.Drawing.Point(13, 13);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(455, 248);
            this.TabControl.TabIndex = 0;
            // 
            // TabPage_Language
            // 
            this.TabPage_Language.Controls.Add(this.Button_CreateSettingsBackup);
            this.TabPage_Language.Controls.Add(this.Button_ResetSettings);
            this.TabPage_Language.Controls.Add(this.Label_ChooseLanguage);
            this.TabPage_Language.Controls.Add(this.ComboBox_Language);
            this.TabPage_Language.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Language.Name = "TabPage_Language";
            this.TabPage_Language.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Language.Size = new System.Drawing.Size(447, 222);
            this.TabPage_Language.TabIndex = 1;
            this.TabPage_Language.Text = "Sprache";
            this.TabPage_Language.UseVisualStyleBackColor = true;
            // 
            // Button_CreateSettingsBackup
            // 
            this.Button_CreateSettingsBackup.Location = new System.Drawing.Point(9, 164);
            this.Button_CreateSettingsBackup.Name = "Button_CreateSettingsBackup";
            this.Button_CreateSettingsBackup.Size = new System.Drawing.Size(225, 23);
            this.Button_CreateSettingsBackup.TabIndex = 3;
            this.Button_CreateSettingsBackup.Text = "Einstellungen sichern";
            this.Button_CreateSettingsBackup.UseVisualStyleBackColor = true;
            this.Button_CreateSettingsBackup.Click += new System.EventHandler(this.Button_CreateSettingsBackup_Click);
            this.Button_CreateSettingsBackup.MouseHover += new System.EventHandler(this.Button_CreateSettingsBackup_MouseHover);
            // 
            // Button_ResetSettings
            // 
            this.Button_ResetSettings.Location = new System.Drawing.Point(9, 193);
            this.Button_ResetSettings.Name = "Button_ResetSettings";
            this.Button_ResetSettings.Size = new System.Drawing.Size(225, 23);
            this.Button_ResetSettings.TabIndex = 2;
            this.Button_ResetSettings.Text = "Alles zurücksetzen";
            this.Button_ResetSettings.UseVisualStyleBackColor = true;
            this.Button_ResetSettings.Click += new System.EventHandler(this.Button_ResetSettings_Click);
            // 
            // Label_ChooseLanguage
            // 
            this.Label_ChooseLanguage.AutoSize = true;
            this.Label_ChooseLanguage.Location = new System.Drawing.Point(6, 9);
            this.Label_ChooseLanguage.Name = "Label_ChooseLanguage";
            this.Label_ChooseLanguage.Size = new System.Drawing.Size(87, 13);
            this.Label_ChooseLanguage.TabIndex = 1;
            this.Label_ChooseLanguage.Text = "Sprache wählen:";
            // 
            // ComboBox_Language
            // 
            this.ComboBox_Language.FormattingEnabled = true;
            this.ComboBox_Language.Items.AddRange(new object[] {
            "English",
            "Deutsch"});
            this.ComboBox_Language.Location = new System.Drawing.Point(121, 6);
            this.ComboBox_Language.Name = "ComboBox_Language";
            this.ComboBox_Language.Size = new System.Drawing.Size(135, 21);
            this.ComboBox_Language.TabIndex = 0;
            this.ComboBox_Language.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Language_SelectedIndexChanged);
            // 
            // TabPage_SavedSettings
            // 
            this.TabPage_SavedSettings.Controls.Add(this.Button_ApplySetting);
            this.TabPage_SavedSettings.Controls.Add(this.TextBox_DestinationPath);
            this.TabPage_SavedSettings.Controls.Add(this.TextBox_SourcePath);
            this.TabPage_SavedSettings.Controls.Add(this.Button_NewSetting);
            this.TabPage_SavedSettings.Controls.Add(this.Label_ListOfSettings);
            this.TabPage_SavedSettings.Controls.Add(this.Button_DeleteSetting);
            this.TabPage_SavedSettings.Controls.Add(this.ListBox_SavedSettings);
            this.TabPage_SavedSettings.Location = new System.Drawing.Point(4, 22);
            this.TabPage_SavedSettings.Name = "TabPage_SavedSettings";
            this.TabPage_SavedSettings.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_SavedSettings.Size = new System.Drawing.Size(447, 222);
            this.TabPage_SavedSettings.TabIndex = 2;
            this.TabPage_SavedSettings.Text = "Gespeicherte Einstellungen";
            this.TabPage_SavedSettings.UseVisualStyleBackColor = true;
            // 
            // Button_ApplySetting
            // 
            this.Button_ApplySetting.Location = new System.Drawing.Point(7, 193);
            this.Button_ApplySetting.Name = "Button_ApplySetting";
            this.Button_ApplySetting.Size = new System.Drawing.Size(75, 23);
            this.Button_ApplySetting.TabIndex = 6;
            this.Button_ApplySetting.Text = "OK";
            this.Button_ApplySetting.UseVisualStyleBackColor = true;
            this.Button_ApplySetting.Click += new System.EventHandler(this.Button_ApplySetting_Click);
            // 
            // TextBox_DestinationPath
            // 
            this.TextBox_DestinationPath.Location = new System.Drawing.Point(7, 159);
            this.TextBox_DestinationPath.Name = "TextBox_DestinationPath";
            this.TextBox_DestinationPath.Size = new System.Drawing.Size(432, 20);
            this.TextBox_DestinationPath.TabIndex = 5;
            // 
            // TextBox_SourcePath
            // 
            this.TextBox_SourcePath.Location = new System.Drawing.Point(7, 133);
            this.TextBox_SourcePath.Name = "TextBox_SourcePath";
            this.TextBox_SourcePath.Size = new System.Drawing.Size(432, 20);
            this.TextBox_SourcePath.TabIndex = 4;
            // 
            // Button_NewSetting
            // 
            this.Button_NewSetting.Location = new System.Drawing.Point(89, 193);
            this.Button_NewSetting.Name = "Button_NewSetting";
            this.Button_NewSetting.Size = new System.Drawing.Size(75, 23);
            this.Button_NewSetting.TabIndex = 3;
            this.Button_NewSetting.Text = "Neu";
            this.Button_NewSetting.UseVisualStyleBackColor = true;
            this.Button_NewSetting.Click += new System.EventHandler(this.Button_NewSetting_Click);
            this.Button_NewSetting.MouseHover += new System.EventHandler(this.Button_NewSetting_MouseHover);
            // 
            // Label_ListOfSettings
            // 
            this.Label_ListOfSettings.AutoSize = true;
            this.Label_ListOfSettings.Location = new System.Drawing.Point(6, 3);
            this.Label_ListOfSettings.Name = "Label_ListOfSettings";
            this.Label_ListOfSettings.Size = new System.Drawing.Size(190, 13);
            this.Label_ListOfSettings.TabIndex = 2;
            this.Label_ListOfSettings.Text = "Liste aller gespeicherten Einstellungen:";
            // 
            // Button_DeleteSetting
            // 
            this.Button_DeleteSetting.Location = new System.Drawing.Point(170, 193);
            this.Button_DeleteSetting.Name = "Button_DeleteSetting";
            this.Button_DeleteSetting.Size = new System.Drawing.Size(75, 23);
            this.Button_DeleteSetting.TabIndex = 1;
            this.Button_DeleteSetting.Text = "Löschen";
            this.Button_DeleteSetting.UseVisualStyleBackColor = true;
            this.Button_DeleteSetting.Click += new System.EventHandler(this.Button_DeleteSetting_Click);
            // 
            // ListBox_SavedSettings
            // 
            this.ListBox_SavedSettings.FormattingEnabled = true;
            this.ListBox_SavedSettings.Location = new System.Drawing.Point(7, 19);
            this.ListBox_SavedSettings.Name = "ListBox_SavedSettings";
            this.ListBox_SavedSettings.Size = new System.Drawing.Size(434, 108);
            this.ListBox_SavedSettings.TabIndex = 0;
            this.ListBox_SavedSettings.SelectedIndexChanged += new System.EventHandler(this.ListBox_SavedSettings_SelectedIndexChanged);
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(13, 267);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(100, 23);
            this.Button_Save.TabIndex = 1;
            this.Button_Save.Text = "Speichern";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Button_Cancel
            // 
            this.Button_Cancel.Location = new System.Drawing.Point(119, 267);
            this.Button_Cancel.Name = "Button_Cancel";
            this.Button_Cancel.Size = new System.Drawing.Size(100, 23);
            this.Button_Cancel.TabIndex = 2;
            this.Button_Cancel.Text = "Abbrechen";
            this.Button_Cancel.UseVisualStyleBackColor = true;
            this.Button_Cancel.Click += new System.EventHandler(this.Button_Cancel_Click);
            // 
            // Form_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 302);
            this.Controls.Add(this.Button_Cancel);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.TabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Form2";
            this.TabControl.ResumeLayout(false);
            this.TabPage_Language.ResumeLayout(false);
            this.TabPage_Language.PerformLayout();
            this.TabPage_SavedSettings.ResumeLayout(false);
            this.TabPage_SavedSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TabPage_Language;
        private System.Windows.Forms.Label Label_ChooseLanguage;
        private System.Windows.Forms.ComboBox ComboBox_Language;
        private System.Windows.Forms.TabPage TabPage_SavedSettings;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.Button Button_Cancel;
        private System.Windows.Forms.Button Button_ApplySetting;
        private System.Windows.Forms.TextBox TextBox_DestinationPath;
        private System.Windows.Forms.TextBox TextBox_SourcePath;
        private System.Windows.Forms.Button Button_NewSetting;
        private System.Windows.Forms.Label Label_ListOfSettings;
        private System.Windows.Forms.Button Button_DeleteSetting;
        private System.Windows.Forms.ListBox ListBox_SavedSettings;
        private System.Windows.Forms.Button Button_ResetSettings;
        private System.Windows.Forms.ToolTip ToolTip_Info;
        private System.Windows.Forms.Button Button_CreateSettingsBackup;
    }
}