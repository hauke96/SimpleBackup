namespace SimpleBackup
{
    partial class Form_Updates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Updates));
            this.ListBox_UpdateLog = new System.Windows.Forms.ListBox();
            this.Button_DownloadUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListBox_UpdateLog
            // 
            this.ListBox_UpdateLog.FormattingEnabled = true;
            this.ListBox_UpdateLog.Location = new System.Drawing.Point(13, 13);
            this.ListBox_UpdateLog.Name = "ListBox_UpdateLog";
            this.ListBox_UpdateLog.Size = new System.Drawing.Size(259, 56);
            this.ListBox_UpdateLog.TabIndex = 0;
            // 
            // Button_DownloadUpdate
            // 
            this.Button_DownloadUpdate.Location = new System.Drawing.Point(13, 76);
            this.Button_DownloadUpdate.Name = "Button_DownloadUpdate";
            this.Button_DownloadUpdate.Size = new System.Drawing.Size(259, 23);
            this.Button_DownloadUpdate.TabIndex = 1;
            this.Button_DownloadUpdate.Text = "Update runterladen";
            this.Button_DownloadUpdate.UseVisualStyleBackColor = true;
            this.Button_DownloadUpdate.Click += new System.EventHandler(this.Button_DownloadUpdate_Click);
            // 
            // Form_Updates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 110);
            this.Controls.Add(this.Button_DownloadUpdate);
            this.Controls.Add(this.ListBox_UpdateLog);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Updates";
            this.Text = "Form4";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListBox_UpdateLog;
        private System.Windows.Forms.Button Button_DownloadUpdate;
    }
}