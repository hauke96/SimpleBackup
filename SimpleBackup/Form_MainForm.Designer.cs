namespace SimpleBackup
{
    partial class Form_MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MainForm));
            this.FolderDialog_Source = new System.Windows.Forms.FolderBrowserDialog();
            this.FolderDialog_Destination = new System.Windows.Forms.FolderBrowserDialog();
            this.Timer_TimeProgressDisplay = new System.Windows.Forms.Timer(this.components);
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ListBox_Notifications = new System.Windows.Forms.ListBox();
            this.Timer_FileProgressDisplay = new System.Windows.Forms.Timer(this.components);
            this.ContextMenuStrip_ErrorMessage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BackgroundWorker_Backup = new System.ComponentModel.BackgroundWorker();
            this.MenuStrip_MainStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SaveEntryToSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Language = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Settings = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_OpenHelpDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ToSourceforge = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_WriteReview = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SearchForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ReportError = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckBox_ShutDown = new System.Windows.Forms.CheckBox();
            this.CheckBox_DeleteOldFiles = new System.Windows.Forms.CheckBox();
            this.RadioButton_CopyAll = new System.Windows.Forms.RadioButton();
            this.RadioButton_OverwriteIfNewer = new System.Windows.Forms.RadioButton();
            this.Button_DestinationPath = new System.Windows.Forms.Button();
            this.TextBox_DestinationPath = new System.Windows.Forms.TextBox();
            this.TextBox_SourcePath = new System.Windows.Forms.TextBox();
            this.Button_SourcePath = new System.Windows.Forms.Button();
            this.Label_Source = new System.Windows.Forms.Label();
            this.Label_Destination = new System.Windows.Forms.Label();
            this.ListBox_ListOfSettings = new System.Windows.Forms.ListBox();
            this.Label_Information = new System.Windows.Forms.Label();
            this.Label_RemainingTimeData = new System.Windows.Forms.Label();
            this.Label_ElapsedTimeData = new System.Windows.Forms.Label();
            this.Label_FileProgress = new System.Windows.Forms.Label();
            this.Label_CurrentFile_FileName = new System.Windows.Forms.Label();
            this.Label_RemainingTime = new System.Windows.Forms.Label();
            this.Label_ElapsedTime = new System.Windows.Forms.Label();
            this.Label_AmountFiles = new System.Windows.Forms.Label();
            this.Label_CurrentFile = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.Button_StartStopBackup = new System.Windows.Forms.Button();
            this.Label_Progress = new System.Windows.Forms.Label();
            this.Label_Notifications = new System.Windows.Forms.Label();
            this.Button_PauseResume = new System.Windows.Forms.Button();
            this.ContextMenuStrip_Settings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Button_AddEntry = new System.Windows.Forms.Button();
            this.Button_DeleteEntry = new System.Windows.Forms.Button();
            this.Button_SaveEntry = new System.Windows.Forms.Button();
            this.ContextMenuStrip_TrayContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Beenden_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Info = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuStrip_MainStrip.SuspendLayout();
            this.ContextMenuStrip_TrayContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer_TimeProgressDisplay
            // 
            this.Timer_TimeProgressDisplay.Enabled = true;
            this.Timer_TimeProgressDisplay.Interval = 250;
            this.Timer_TimeProgressDisplay.Tick += new System.EventHandler(this.Timer_TimeProgressDisplay_Tick);
            // 
            // ListBox_Notifications
            // 
            this.ListBox_Notifications.FormattingEnabled = true;
            this.ListBox_Notifications.HorizontalScrollbar = true;
            this.ListBox_Notifications.Location = new System.Drawing.Point(13, 499);
            this.ListBox_Notifications.Name = "ListBox_Notifications";
            this.ListBox_Notifications.Size = new System.Drawing.Size(577, 134);
            this.ListBox_Notifications.TabIndex = 5;
            this.ListBox_Notifications.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBox_Notifications_MouseDown);
            // 
            // Timer_FileProgressDisplay
            // 
            this.Timer_FileProgressDisplay.Interval = 50;
            this.Timer_FileProgressDisplay.Tick += new System.EventHandler(this.Timer_FileProgressDisplay_Tick);
            // 
            // ContextMenuStrip_ErrorMessage
            // 
            this.ContextMenuStrip_ErrorMessage.Name = "ContextMenuStrip_ErrorMessage";
            this.ContextMenuStrip_ErrorMessage.Size = new System.Drawing.Size(61, 4);
            this.ContextMenuStrip_ErrorMessage.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuStrip_ErrorMessage_ItemClicked);
            // 
            // BackgroundWorker_Backup
            // 
            this.BackgroundWorker_Backup.WorkerSupportsCancellation = true;
            this.BackgroundWorker_Backup.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker_Backup_DoWork);
            this.BackgroundWorker_Backup.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker_Backup_RunWorkerCompleted);
            // 
            // MenuStrip_MainStrip
            // 
            this.MenuStrip_MainStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_File,
            this.ToolStripMenuItem_Options,
            this.ToolStripMenuItem_Help,
            this.ToolStripMenuItem_ReportError});
            this.MenuStrip_MainStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip_MainStrip.Name = "MenuStrip_MainStrip";
            this.MenuStrip_MainStrip.Size = new System.Drawing.Size(602, 24);
            this.MenuStrip_MainStrip.TabIndex = 8;
            this.MenuStrip_MainStrip.Text = "MenuStrip_MainStrip";
            // 
            // ToolStripMenuItem_File
            // 
            this.ToolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Open,
            this.ToolStripMenuItem_Save,
            this.ToolStripMenuItem_Exit});
            this.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
            this.ToolStripMenuItem_File.Size = new System.Drawing.Size(46, 20);
            this.ToolStripMenuItem_File.Text = "Datei";
            // 
            // ToolStripMenuItem_Open
            // 
            this.ToolStripMenuItem_Open.Name = "ToolStripMenuItem_Open";
            this.ToolStripMenuItem_Open.Size = new System.Drawing.Size(126, 22);
            this.ToolStripMenuItem_Open.Text = "Öffnen";
            // 
            // ToolStripMenuItem_Save
            // 
            this.ToolStripMenuItem_Save.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logToolStripMenuItem,
            this.ToolStripMenuItem_SaveEntryToSettings});
            this.ToolStripMenuItem_Save.Name = "ToolStripMenuItem_Save";
            this.ToolStripMenuItem_Save.Size = new System.Drawing.Size(126, 22);
            this.ToolStripMenuItem_Save.Text = "Speichern";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.logToolStripMenuItem.Text = "Log";
            // 
            // ToolStripMenuItem_SaveEntryToSettings
            // 
            this.ToolStripMenuItem_SaveEntryToSettings.Name = "ToolStripMenuItem_SaveEntryToSettings";
            this.ToolStripMenuItem_SaveEntryToSettings.Size = new System.Drawing.Size(145, 22);
            this.ToolStripMenuItem_SaveEntryToSettings.Text = "Einstellungen";
            this.ToolStripMenuItem_SaveEntryToSettings.Click += new System.EventHandler(this.ToolStripMenuItem_SaveEntryToSettings_Click);
            // 
            // ToolStripMenuItem_Exit
            // 
            this.ToolStripMenuItem_Exit.Name = "ToolStripMenuItem_Exit";
            this.ToolStripMenuItem_Exit.Size = new System.Drawing.Size(126, 22);
            this.ToolStripMenuItem_Exit.Text = "Beenden";
            this.ToolStripMenuItem_Exit.Click += new System.EventHandler(this.ToolStripMenuItem_Exit_Click);
            // 
            // ToolStripMenuItem_Options
            // 
            this.ToolStripMenuItem_Options.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Language,
            this.ToolStripMenuItem_Settings});
            this.ToolStripMenuItem_Options.Name = "ToolStripMenuItem_Options";
            this.ToolStripMenuItem_Options.Size = new System.Drawing.Size(69, 20);
            this.ToolStripMenuItem_Options.Text = "Optionen";
            // 
            // ToolStripMenuItem_Language
            // 
            this.ToolStripMenuItem_Language.Name = "ToolStripMenuItem_Language";
            this.ToolStripMenuItem_Language.Size = new System.Drawing.Size(145, 22);
            this.ToolStripMenuItem_Language.Text = "Sprache";
            // 
            // ToolStripMenuItem_Settings
            // 
            this.ToolStripMenuItem_Settings.Name = "ToolStripMenuItem_Settings";
            this.ToolStripMenuItem_Settings.Size = new System.Drawing.Size(145, 22);
            this.ToolStripMenuItem_Settings.Text = "Einstellungen";
            this.ToolStripMenuItem_Settings.Click += new System.EventHandler(this.ToolStripMenuItem_Settings_Click);
            // 
            // ToolStripMenuItem_Help
            // 
            this.ToolStripMenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_OpenHelpDialog,
            this.ToolStripMenuItem_ToSourceforge,
            this.ToolStripMenuItem_WriteReview,
            this.ToolStripMenuItem_SearchForUpdates,
            this.ToolStripMenuItem_About});
            this.ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
            this.ToolStripMenuItem_Help.Size = new System.Drawing.Size(44, 20);
            this.ToolStripMenuItem_Help.Text = "Hilfe";
            // 
            // ToolStripMenuItem_OpenHelpDialog
            // 
            this.ToolStripMenuItem_OpenHelpDialog.Name = "ToolStripMenuItem_OpenHelpDialog";
            this.ToolStripMenuItem_OpenHelpDialog.Size = new System.Drawing.Size(206, 22);
            this.ToolStripMenuItem_OpenHelpDialog.Text = "Hilfe";
            this.ToolStripMenuItem_OpenHelpDialog.Click += new System.EventHandler(this.ToolStripMenuItem_OpenHelpDialog_Click);
            // 
            // ToolStripMenuItem_ToSourceforge
            // 
            this.ToolStripMenuItem_ToSourceforge.Name = "ToolStripMenuItem_ToSourceforge";
            this.ToolStripMenuItem_ToSourceforge.Size = new System.Drawing.Size(206, 22);
            this.ToolStripMenuItem_ToSourceforge.Text = "Zum Sourceforge Projekt";
            this.ToolStripMenuItem_ToSourceforge.Click += new System.EventHandler(this.ToolStripMenuItem_ToSourceforge_Click);
            // 
            // ToolStripMenuItem_WriteReview
            // 
            this.ToolStripMenuItem_WriteReview.Name = "ToolStripMenuItem_WriteReview";
            this.ToolStripMenuItem_WriteReview.Size = new System.Drawing.Size(206, 22);
            this.ToolStripMenuItem_WriteReview.Text = "Bewertung schreiben";
            this.ToolStripMenuItem_WriteReview.Click += new System.EventHandler(this.ToolStripMenuItem_WriteReview_Click);
            // 
            // ToolStripMenuItem_SearchForUpdates
            // 
            this.ToolStripMenuItem_SearchForUpdates.Name = "ToolStripMenuItem_SearchForUpdates";
            this.ToolStripMenuItem_SearchForUpdates.Size = new System.Drawing.Size(206, 22);
            this.ToolStripMenuItem_SearchForUpdates.Text = "Auf Updates prüfen";
            this.ToolStripMenuItem_SearchForUpdates.Click += new System.EventHandler(this.ToolStripMenuItem_SearchForUpdates_Click);
            // 
            // ToolStripMenuItem_About
            // 
            this.ToolStripMenuItem_About.Name = "ToolStripMenuItem_About";
            this.ToolStripMenuItem_About.Size = new System.Drawing.Size(206, 22);
            this.ToolStripMenuItem_About.Text = "Über SimpleBackup";
            this.ToolStripMenuItem_About.Click += new System.EventHandler(this.ToolStripMenuItem_About_Click);
            // 
            // ToolStripMenuItem_ReportError
            // 
            this.ToolStripMenuItem_ReportError.Name = "ToolStripMenuItem_ReportError";
            this.ToolStripMenuItem_ReportError.Size = new System.Drawing.Size(94, 20);
            this.ToolStripMenuItem_ReportError.Text = "Fehler melden";
            this.ToolStripMenuItem_ReportError.Click += new System.EventHandler(this.ToolStripMenuItem_ReportError_Click);
            // 
            // CheckBox_ShutDown
            // 
            this.CheckBox_ShutDown.AutoSize = true;
            this.CheckBox_ShutDown.Location = new System.Drawing.Point(249, 246);
            this.CheckBox_ShutDown.Name = "CheckBox_ShutDown";
            this.CheckBox_ShutDown.Size = new System.Drawing.Size(169, 17);
            this.CheckBox_ShutDown.TabIndex = 12;
            this.CheckBox_ShutDown.Text = "Nach beenden herunterfahren";
            this.CheckBox_ShutDown.UseVisualStyleBackColor = true;
            // 
            // CheckBox_DeleteOldFiles
            // 
            this.CheckBox_DeleteOldFiles.AutoSize = true;
            this.CheckBox_DeleteOldFiles.Checked = true;
            this.CheckBox_DeleteOldFiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBox_DeleteOldFiles.Location = new System.Drawing.Point(249, 223);
            this.CheckBox_DeleteOldFiles.Name = "CheckBox_DeleteOldFiles";
            this.CheckBox_DeleteOldFiles.Size = new System.Drawing.Size(124, 17);
            this.CheckBox_DeleteOldFiles.TabIndex = 11;
            this.CheckBox_DeleteOldFiles.Text = "Alte Dateien löschen";
            this.CheckBox_DeleteOldFiles.UseVisualStyleBackColor = true;
            this.CheckBox_DeleteOldFiles.MouseHover += new System.EventHandler(this.CheckBox_DeleteOldFiles_MouseHover);
            // 
            // RadioButton_CopyAll
            // 
            this.RadioButton_CopyAll.AutoSize = true;
            this.RadioButton_CopyAll.Location = new System.Drawing.Point(19, 246);
            this.RadioButton_CopyAll.Name = "RadioButton_CopyAll";
            this.RadioButton_CopyAll.Size = new System.Drawing.Size(91, 17);
            this.RadioButton_CopyAll.TabIndex = 10;
            this.RadioButton_CopyAll.Text = "Alles kopieren";
            this.RadioButton_CopyAll.UseVisualStyleBackColor = true;
            // 
            // RadioButton_OverwriteIfNewer
            // 
            this.RadioButton_OverwriteIfNewer.AutoSize = true;
            this.RadioButton_OverwriteIfNewer.Checked = true;
            this.RadioButton_OverwriteIfNewer.Location = new System.Drawing.Point(19, 223);
            this.RadioButton_OverwriteIfNewer.Name = "RadioButton_OverwriteIfNewer";
            this.RadioButton_OverwriteIfNewer.Size = new System.Drawing.Size(182, 17);
            this.RadioButton_OverwriteIfNewer.TabIndex = 9;
            this.RadioButton_OverwriteIfNewer.TabStop = true;
            this.RadioButton_OverwriteIfNewer.Text = "Datei überschreiben, wenn neuer";
            this.RadioButton_OverwriteIfNewer.UseVisualStyleBackColor = true;
            // 
            // Button_DestinationPath
            // 
            this.Button_DestinationPath.Location = new System.Drawing.Point(555, 196);
            this.Button_DestinationPath.Name = "Button_DestinationPath";
            this.Button_DestinationPath.Size = new System.Drawing.Size(35, 20);
            this.Button_DestinationPath.TabIndex = 14;
            this.Button_DestinationPath.Text = "...";
            this.Button_DestinationPath.UseVisualStyleBackColor = true;
            this.Button_DestinationPath.Click += new System.EventHandler(this.Button_DestinationPath_Click);
            // 
            // TextBox_DestinationPath
            // 
            this.TextBox_DestinationPath.Location = new System.Drawing.Point(101, 196);
            this.TextBox_DestinationPath.Name = "TextBox_DestinationPath";
            this.TextBox_DestinationPath.Size = new System.Drawing.Size(448, 20);
            this.TextBox_DestinationPath.TabIndex = 16;
            this.TextBox_DestinationPath.TextChanged += new System.EventHandler(this.TextBox_DestinationPath_TextChanged);
            this.TextBox_DestinationPath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_DestinationPath_KeyPress);
            // 
            // TextBox_SourcePath
            // 
            this.TextBox_SourcePath.Location = new System.Drawing.Point(101, 170);
            this.TextBox_SourcePath.Name = "TextBox_SourcePath";
            this.TextBox_SourcePath.Size = new System.Drawing.Size(448, 20);
            this.TextBox_SourcePath.TabIndex = 15;
            this.TextBox_SourcePath.TextChanged += new System.EventHandler(this.TextBox_SourcePath_TextChanged);
            this.TextBox_SourcePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_SourcePath_KeyPress);
            // 
            // Button_SourcePath
            // 
            this.Button_SourcePath.Location = new System.Drawing.Point(555, 170);
            this.Button_SourcePath.Name = "Button_SourcePath";
            this.Button_SourcePath.Size = new System.Drawing.Size(35, 20);
            this.Button_SourcePath.TabIndex = 13;
            this.Button_SourcePath.Text = "...";
            this.Button_SourcePath.UseVisualStyleBackColor = true;
            this.Button_SourcePath.Click += new System.EventHandler(this.Button_SourcePath_Click);
            // 
            // Label_Source
            // 
            this.Label_Source.AutoSize = true;
            this.Label_Source.Location = new System.Drawing.Point(13, 174);
            this.Label_Source.Name = "Label_Source";
            this.Label_Source.Size = new System.Drawing.Size(61, 13);
            this.Label_Source.TabIndex = 17;
            this.Label_Source.Text = "Quellordner";
            // 
            // Label_Destination
            // 
            this.Label_Destination.AutoSize = true;
            this.Label_Destination.Location = new System.Drawing.Point(13, 199);
            this.Label_Destination.Name = "Label_Destination";
            this.Label_Destination.Size = new System.Drawing.Size(54, 13);
            this.Label_Destination.TabIndex = 18;
            this.Label_Destination.Text = "Zielordner";
            // 
            // ListBox_ListOfSettings
            // 
            this.ListBox_ListOfSettings.FormattingEnabled = true;
            this.ListBox_ListOfSettings.Location = new System.Drawing.Point(12, 27);
            this.ListBox_ListOfSettings.Name = "ListBox_ListOfSettings";
            this.ListBox_ListOfSettings.Size = new System.Drawing.Size(577, 108);
            this.ListBox_ListOfSettings.TabIndex = 19;
            this.ListBox_ListOfSettings.SelectedIndexChanged += new System.EventHandler(this.ListBox_ListOfSettings_SelectedIndexChanged);
            this.ListBox_ListOfSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListBox_ListOfSettings_MouseDown);
            // 
            // Label_Information
            // 
            this.Label_Information.AutoSize = true;
            this.Label_Information.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Information.Location = new System.Drawing.Point(13, 318);
            this.Label_Information.Name = "Label_Information";
            this.Label_Information.Size = new System.Drawing.Size(74, 13);
            this.Label_Information.TabIndex = 30;
            this.Label_Information.Text = "Informationen:";
            // 
            // Label_RemainingTimeData
            // 
            this.Label_RemainingTimeData.AutoSize = true;
            this.Label_RemainingTimeData.Location = new System.Drawing.Point(144, 393);
            this.Label_RemainingTimeData.Name = "Label_RemainingTimeData";
            this.Label_RemainingTimeData.Size = new System.Drawing.Size(286, 13);
            this.Label_RemainingTimeData.TabIndex = 29;
            this.Label_RemainingTimeData.Text = "Wenn du anfangen würdest, könnte ich es dir berechnen ;)";
            // 
            // Label_ElapsedTimeData
            // 
            this.Label_ElapsedTimeData.AutoSize = true;
            this.Label_ElapsedTimeData.Location = new System.Drawing.Point(144, 376);
            this.Label_ElapsedTimeData.Name = "Label_ElapsedTimeData";
            this.Label_ElapsedTimeData.Size = new System.Drawing.Size(68, 13);
            this.Label_ElapsedTimeData.TabIndex = 28;
            this.Label_ElapsedTimeData.Text = "00h:00m:00s";
            // 
            // Label_FileProgress
            // 
            this.Label_FileProgress.AutoSize = true;
            this.Label_FileProgress.Location = new System.Drawing.Point(144, 359);
            this.Label_FileProgress.Name = "Label_FileProgress";
            this.Label_FileProgress.Size = new System.Drawing.Size(24, 13);
            this.Label_FileProgress.TabIndex = 27;
            this.Label_FileProgress.Text = "0/0";
            // 
            // Label_CurrentFile_FileName
            // 
            this.Label_CurrentFile_FileName.AutoSize = true;
            this.Label_CurrentFile_FileName.Location = new System.Drawing.Point(144, 342);
            this.Label_CurrentFile_FileName.Name = "Label_CurrentFile_FileName";
            this.Label_CurrentFile_FileName.Size = new System.Drawing.Size(10, 13);
            this.Label_CurrentFile_FileName.TabIndex = 26;
            this.Label_CurrentFile_FileName.Text = "-";
            this.Label_CurrentFile_FileName.MouseHover += new System.EventHandler(this.Label_CurrentFile_FileName_MouseHover);
            // 
            // Label_RemainingTime
            // 
            this.Label_RemainingTime.AutoSize = true;
            this.Label_RemainingTime.Location = new System.Drawing.Point(28, 393);
            this.Label_RemainingTime.Name = "Label_RemainingTime";
            this.Label_RemainingTime.Size = new System.Drawing.Size(93, 13);
            this.Label_RemainingTime.TabIndex = 24;
            this.Label_RemainingTime.Text = "Verbleibende Zeit:";
            // 
            // Label_ElapsedTime
            // 
            this.Label_ElapsedTime.AutoSize = true;
            this.Label_ElapsedTime.Location = new System.Drawing.Point(28, 376);
            this.Label_ElapsedTime.Name = "Label_ElapsedTime";
            this.Label_ElapsedTime.Size = new System.Drawing.Size(89, 13);
            this.Label_ElapsedTime.TabIndex = 23;
            this.Label_ElapsedTime.Text = "Vergangene Zeit:";
            // 
            // Label_AmountFiles
            // 
            this.Label_AmountFiles.AutoSize = true;
            this.Label_AmountFiles.Location = new System.Drawing.Point(28, 359);
            this.Label_AmountFiles.Name = "Label_AmountFiles";
            this.Label_AmountFiles.Size = new System.Drawing.Size(82, 13);
            this.Label_AmountFiles.TabIndex = 22;
            this.Label_AmountFiles.Text = "Anzahl Dateien:";
            // 
            // Label_CurrentFile
            // 
            this.Label_CurrentFile.AutoSize = true;
            this.Label_CurrentFile.Location = new System.Drawing.Point(28, 342);
            this.Label_CurrentFile.Name = "Label_CurrentFile";
            this.Label_CurrentFile.Size = new System.Drawing.Size(94, 13);
            this.Label_CurrentFile.TabIndex = 21;
            this.Label_CurrentFile.Text = "Momentane Datei:";
            // 
            // ProgressBar
            // 
            this.ProgressBar.BackColor = System.Drawing.SystemColors.Control;
            this.ProgressBar.Location = new System.Drawing.Point(13, 438);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(577, 26);
            this.ProgressBar.TabIndex = 20;
            // 
            // Button_StartStopBackup
            // 
            this.Button_StartStopBackup.Enabled = false;
            this.Button_StartStopBackup.Location = new System.Drawing.Point(16, 282);
            this.Button_StartStopBackup.Name = "Button_StartStopBackup";
            this.Button_StartStopBackup.Size = new System.Drawing.Size(284, 26);
            this.Button_StartStopBackup.TabIndex = 25;
            this.Button_StartStopBackup.Text = "Backup starten";
            this.Button_StartStopBackup.UseVisualStyleBackColor = true;
            this.Button_StartStopBackup.Click += new System.EventHandler(this.Button_StartStopBackup_Click);
            // 
            // Label_Progress
            // 
            this.Label_Progress.AutoSize = true;
            this.Label_Progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Progress.Location = new System.Drawing.Point(13, 415);
            this.Label_Progress.Name = "Label_Progress";
            this.Label_Progress.Size = new System.Drawing.Size(56, 13);
            this.Label_Progress.TabIndex = 31;
            this.Label_Progress.Text = "Fortschritt:";
            // 
            // Label_Notifications
            // 
            this.Label_Notifications.AutoSize = true;
            this.Label_Notifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Notifications.Location = new System.Drawing.Point(13, 476);
            this.Label_Notifications.Name = "Label_Notifications";
            this.Label_Notifications.Size = new System.Drawing.Size(63, 13);
            this.Label_Notifications.TabIndex = 32;
            this.Label_Notifications.Text = "Meldungen:";
            // 
            // Button_PauseResume
            // 
            this.Button_PauseResume.Enabled = false;
            this.Button_PauseResume.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Button_PauseResume.Location = new System.Drawing.Point(307, 282);
            this.Button_PauseResume.Name = "Button_PauseResume";
            this.Button_PauseResume.Size = new System.Drawing.Size(283, 26);
            this.Button_PauseResume.TabIndex = 33;
            this.Button_PauseResume.Text = "Backup pausieren";
            this.Button_PauseResume.UseVisualStyleBackColor = true;
            this.Button_PauseResume.Click += new System.EventHandler(this.Button_PauseResume_Click);
            // 
            // ContextMenuStrip_Settings
            // 
            this.ContextMenuStrip_Settings.Name = "ContextMenuStrip_Settings";
            this.ContextMenuStrip_Settings.Size = new System.Drawing.Size(61, 4);
            this.ContextMenuStrip_Settings.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.ContextMenuStrip_Settings_ItemClicked);
            // 
            // Button_AddEntry
            // 
            this.Button_AddEntry.Location = new System.Drawing.Point(12, 141);
            this.Button_AddEntry.Name = "Button_AddEntry";
            this.Button_AddEntry.Size = new System.Drawing.Size(75, 23);
            this.Button_AddEntry.TabIndex = 34;
            this.Button_AddEntry.Text = "Neu";
            this.Button_AddEntry.UseVisualStyleBackColor = true;
            this.Button_AddEntry.Click += new System.EventHandler(this.Button_AddEntry_Click);
            // 
            // Button_DeleteEntry
            // 
            this.Button_DeleteEntry.Location = new System.Drawing.Point(174, 141);
            this.Button_DeleteEntry.Name = "Button_DeleteEntry";
            this.Button_DeleteEntry.Size = new System.Drawing.Size(75, 23);
            this.Button_DeleteEntry.TabIndex = 36;
            this.Button_DeleteEntry.Text = "Löschen";
            this.Button_DeleteEntry.UseVisualStyleBackColor = true;
            this.Button_DeleteEntry.Click += new System.EventHandler(this.Button_DeleteEntry_Click);
            // 
            // Button_SaveEntry
            // 
            this.Button_SaveEntry.Location = new System.Drawing.Point(93, 141);
            this.Button_SaveEntry.Name = "Button_SaveEntry";
            this.Button_SaveEntry.Size = new System.Drawing.Size(75, 23);
            this.Button_SaveEntry.TabIndex = 37;
            this.Button_SaveEntry.Text = "Speichern";
            this.Button_SaveEntry.UseVisualStyleBackColor = true;
            this.Button_SaveEntry.Click += new System.EventHandler(this.Button_SaveEntry_Click);
            // 
            // ContextMenuStrip_TrayContext
            // 
            this.ContextMenuStrip_TrayContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Beenden_ToolStripMenuItem,
            this.ToolStripMenuItem_Info});
            this.ContextMenuStrip_TrayContext.Name = "ContextMenuStrip_TrayContext";
            this.ContextMenuStrip_TrayContext.Size = new System.Drawing.Size(121, 48);
            // 
            // Beenden_ToolStripMenuItem
            // 
            this.Beenden_ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("Beenden_ToolStripMenuItem.Image")));
            this.Beenden_ToolStripMenuItem.Name = "Beenden_ToolStripMenuItem";
            this.Beenden_ToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.Beenden_ToolStripMenuItem.Text = "Beenden";
            this.Beenden_ToolStripMenuItem.Click += new System.EventHandler(this.Exit_ToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_Info
            // 
            this.ToolStripMenuItem_Info.Name = "ToolStripMenuItem_Info";
            this.ToolStripMenuItem_Info.Size = new System.Drawing.Size(120, 22);
            this.ToolStripMenuItem_Info.Text = "Info";
            this.ToolStripMenuItem_Info.Click += new System.EventHandler(this.ToolStripMenuItem_Info_Click);
            // 
            // SystemTray
            // 
            this.SystemTray.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.SystemTray.BalloonTipText = "Ohne Schnick Schnack Backups erstellen";
            this.SystemTray.BalloonTipTitle = "SimpleBackup";
            this.SystemTray.ContextMenuStrip = this.ContextMenuStrip_TrayContext;
            this.SystemTray.Icon = ((System.Drawing.Icon)(resources.GetObject("SystemTray.Icon")));
            this.SystemTray.Text = "SimpleBackup";
            this.SystemTray.DoubleClick += new System.EventHandler(this.SystemTray_DoubleClick);
            // 
            // Form_MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 645);
            this.Controls.Add(this.Button_SaveEntry);
            this.Controls.Add(this.Button_DeleteEntry);
            this.Controls.Add(this.Button_AddEntry);
            this.Controls.Add(this.Button_PauseResume);
            this.Controls.Add(this.Label_Notifications);
            this.Controls.Add(this.Label_Progress);
            this.Controls.Add(this.Label_Information);
            this.Controls.Add(this.Label_RemainingTimeData);
            this.Controls.Add(this.Label_ElapsedTimeData);
            this.Controls.Add(this.Label_FileProgress);
            this.Controls.Add(this.Label_CurrentFile_FileName);
            this.Controls.Add(this.Label_RemainingTime);
            this.Controls.Add(this.Label_ElapsedTime);
            this.Controls.Add(this.Label_AmountFiles);
            this.Controls.Add(this.Label_CurrentFile);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.Button_StartStopBackup);
            this.Controls.Add(this.ListBox_ListOfSettings);
            this.Controls.Add(this.Label_Destination);
            this.Controls.Add(this.Label_Source);
            this.Controls.Add(this.Button_DestinationPath);
            this.Controls.Add(this.TextBox_DestinationPath);
            this.Controls.Add(this.TextBox_SourcePath);
            this.Controls.Add(this.Button_SourcePath);
            this.Controls.Add(this.CheckBox_ShutDown);
            this.Controls.Add(this.CheckBox_DeleteOldFiles);
            this.Controls.Add(this.RadioButton_CopyAll);
            this.Controls.Add(this.RadioButton_OverwriteIfNewer);
            this.Controls.Add(this.MenuStrip_MainStrip);
            this.Controls.Add(this.ListBox_Notifications);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_MainForm";
            //this.Text = "Simple Backup " + ProductVersion + " - made by Hauke Stieler"; // this is the correct code, line below may be incorrect
            this.Text = "Simple Backup " + ProductVersion + " - made by Hauke Stieler";
            this.SizeChanged += new System.EventHandler(this.Form_MainForm_SizeChanged);
            this.MenuStrip_MainStrip.ResumeLayout(false);
            this.MenuStrip_MainStrip.PerformLayout();
            this.ContextMenuStrip_TrayContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog FolderDialog_Source;
        private System.Windows.Forms.FolderBrowserDialog FolderDialog_Destination;
        private System.Windows.Forms.Timer Timer_TimeProgressDisplay;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.ListBox ListBox_Notifications;
        private System.Windows.Forms.Timer Timer_FileProgressDisplay;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_ErrorMessage;
        private System.ComponentModel.BackgroundWorker BackgroundWorker_Backup;
        private System.Windows.Forms.MenuStrip MenuStrip_MainStrip;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Open;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Save;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Exit;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Options;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Language;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Settings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_OpenHelpDialog;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ToSourceforge;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SearchForUpdates;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_About;
        public System.Windows.Forms.CheckBox CheckBox_ShutDown;
        public System.Windows.Forms.CheckBox CheckBox_DeleteOldFiles;
        public System.Windows.Forms.RadioButton RadioButton_CopyAll;
        public System.Windows.Forms.RadioButton RadioButton_OverwriteIfNewer;
        private System.Windows.Forms.Button Button_DestinationPath;
        public System.Windows.Forms.TextBox TextBox_DestinationPath;
        public System.Windows.Forms.TextBox TextBox_SourcePath;
        private System.Windows.Forms.Button Button_SourcePath;
        private System.Windows.Forms.Label Label_Source;
        private System.Windows.Forms.Label Label_Destination;
        private System.Windows.Forms.Label Label_Information;
        private System.Windows.Forms.Label Label_RemainingTimeData;
        private System.Windows.Forms.Label Label_ElapsedTimeData;
        private System.Windows.Forms.Label Label_FileProgress;
        private System.Windows.Forms.Label Label_CurrentFile_FileName;
        private System.Windows.Forms.Label Label_RemainingTime;
        private System.Windows.Forms.Label Label_ElapsedTime;
        private System.Windows.Forms.Label Label_AmountFiles;
        private System.Windows.Forms.Label Label_CurrentFile;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button Button_StartStopBackup;
        private System.Windows.Forms.Label Label_Progress;
        private System.Windows.Forms.Label Label_Notifications;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SaveEntryToSettings;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ReportError;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_WriteReview;
        private System.Windows.Forms.Button Button_PauseResume;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_Settings;
        public System.Windows.Forms.ListBox ListBox_ListOfSettings;
        private System.Windows.Forms.Button Button_AddEntry;
        private System.Windows.Forms.Button Button_DeleteEntry;
        private System.Windows.Forms.Button Button_SaveEntry;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip_TrayContext;
        private System.Windows.Forms.ToolStripMenuItem Beenden_ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon SystemTray;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Info;
    }
}

