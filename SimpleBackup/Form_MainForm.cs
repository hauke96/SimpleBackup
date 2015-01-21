/** please read: code convention
 * ###############################
 * # ----- CODE CONVENTION ----- #
 * ###############################
 * 
 * 1 - VARIABLES
 * 2 - METHODS/FUNCTIONS, EVENTS
 * 3 - FORMS
 * 4 - COMMENTS
 * 
 * 1.) VARIABLES:
 *  general:
 *      - use capitol letters to seperate words: FilesInSourcePath
 *      - use underscore ( _ ) to make higher structure: e.g. Amount_FilesInSourcePath, Amount_ProcessedFiles, Amount_...
 *      - one variable per line (s. "comments"->"variables" for a reason ;) )
 *     
 *  instance variables (in class header):
 *      - NO underscore
 *      - first letter is a capitol one
 *      - readable (nothing like: PtrG_IO but SourcePath or Amount_FilesInSourcePath)
 *     
 *  local variables (in method/function) & parameter:
 *      - first character is a underscore: _variable
 *      - first letter is a small one: _myVariable
 *     
 * 2.) EVENT, METHOD AND FUNCTION NAMES:
 *  events:
 *      - begin with _event_...
 *      - rest of name is default (e.g.: _event_Button_SourcePath_Click )
 *      
 *  methods/functions - like "instance variables":
 *      - NO underscore
 *      - first letter is a capitol one
 *      - readable (nothing like: PtrG_IO but SourcePath or Amount_FilesInSourcePath)
 *      
 * 3.) FORM NAMES:
 *  - NO underscore
 *  - readable (e.g.: MainForm or AboutForm)
 *  - please don't use Form_MainForm, Form2, ... ;)
 *  
 * 4.) COMMENTS:
 *  variable comments:
 *      - right next variable
 *      - short description for sense of this variable
 *      
 *  method/functions, events:
 *      - 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using SchwabenCode.QuickIO;
using SchwabenCode.QuickIO.Transfer;

namespace SimpleBackup
{
    public partial class Form_MainForm : Form
    {
        public Boolean BackupIsRunning, // for buttons, notifications, etc.
            ResetAll = false, // to reset everything after error/finish
            CountingFiles = false, // to show the right text to Label_CurrentFile_FileName
            BackupAborded = false, // for the right output in ListBox_Notifications when a backup has been aborded
            PauseBackup = false; // interrupts the backup process
        public string SourcePath = "", // Path to the original/source data
            DestinationPath = "", // Path to the backup folder
            CurrentFile = ""; //for Label_CurrentFile_FileName to show the current path
        public int Amount_FilesInSourcePath, // Amount of files in the original folder ( SourcePath )
            Amount_ProcessedFiles, // amount of processed files
            SelectedLanguage = 1, // 1=English; 0=German/Deutsch
            CurrentFileInMBytes = 0, // size in mega-bytes (MBytes) of current file
            SelectedErrorMessage = -1, // the selected error message in the notification list
            ErrorMessageCounter = 0, // Amount of error messages for the list entry ( "ERROR(x): ... " ) ; imortant for SelectedErrorMessage
            SettingsList_SelectedIndex = -1; // saves the last selected index if ListBox_ListOfSettings
        public long Amount_BytesInSourcePath, // Amount of bytes in the original folder ( SourcePath )
            Amount_CopiedBytes; // for progressbar; Amount_CopiedBytes = copied amount of bytes
        public DateTime StartTime; // Time for elapsed and remaining time
        public TimeSpan PausedTime; // needed for pausing the timer in pause-mode; duration the process was paused
        public string[,] Language = new string[2, 53]; // Array with language strings
        public List<string> SettingReadings = new List<string>(), // saves read data
            ErrorMessages = new List<string>(); // List of detailed error messages to copy via the notification list

        
        public Form_MainForm()
        {
            InitializeComponent();
            InitializeLanguage();
            ChangeLanguage("English");
            StreamReader _reader = new StreamReader("some.settings");
            for (int _i = 0; _i < File.ReadAllLines("some.settings").Length; _i++)
            {
                string _str = _reader.ReadLine();
                if (_str == "")
                {
                    _i--;
                    continue;
                }
                if (_str == null) break;
                SettingReadings.Add(_str);
                string[] _t = SettingReadings[_i].Split('?');
                ToolStripMenuItem_Open.DropDownItems.Add(_t[0] + "  ==>>  " + _t[1]);
                ListBox_ListOfSettings.Items.Add(_t[0] + "  ==>>  " + _t[1]);
            }
            _reader.Close();
        }


        
        //Events



// BUTTONS:
        /// <summary>
        /// Shows dialog for choosing a source path.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void Button_SourcePath_Click(object _sender, EventArgs _e)
        {
            FolderDialog_Source.ShowDialog();
            TextBox_SourcePath.Text = FolderDialog_Source.SelectedPath;
            enableAfterInput();
        }
        /// <summary>
        /// Shows a dialog for choosing the destination path.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void Button_DestinationPath_Click(object _sender, EventArgs _e)
        {
            FolderDialog_Destination.ShowDialog();
            TextBox_DestinationPath.Text = FolderDialog_Destination.SelectedPath;
            enableAfterInput();
        }
        /// <summary>
        /// Triggers action after click on Start/Stop-Button
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void Button_StartStopBackup_Click(object _sender, EventArgs _e) 
        {
            if (BackupIsRunning && Button_StartStopBackup.Text != "OK")// Stop Backup
            {
                
                DialogResult ds = MessageBox.Show(Language[SelectedLanguage, 19], Language[SelectedLanguage, 20], MessageBoxButtons.YesNo);
                if (ds == System.Windows.Forms.DialogResult.Yes)
                {
                    Button_PauseResume.Enabled = false;
                    Button_StartStopBackup.Text = "OK";
                    BackupIsRunning = false;
                    BackgroundWorker_Backup.CancelAsync();
                    Amount_BytesInSourcePath = 0;
                    Amount_CopiedBytes = 0;
                }
                else
                {
                    return;
                }
            }
            else if (BackupIsRunning == false && Button_StartStopBackup.Text == "OK") // backup finished, return to start
            {
                // return to screen befor backup started
                Button_StartStopBackup.Text = Language[SelectedLanguage, 8];
                ListBox_Notifications.Items.Clear();
                ResetSimpleBackup();
            }
            else// Start Backup
            {
                
                Button_PauseResume.Enabled = true;
                StartTime = DateTime.Now;
                if (TextBox_SourcePath.Text[TextBox_SourcePath.Text.Length - 1] != '\\') TextBox_SourcePath.Text += "\\";
                if (TextBox_DestinationPath.Text[TextBox_DestinationPath.Text.Length - 1] != '\\') TextBox_DestinationPath.Text += "\\";
                Button_StartStopBackup.Text = Language[SelectedLanguage, 18];
                SourcePath = TextBox_SourcePath.Text;
                DestinationPath = TextBox_DestinationPath.Text;
                BackupIsRunning = true;
                Label_CurrentFile_FileName.Text = "";
                Label_ElapsedTimeData.Text = "00h:00m:00s";
                ListBox_Notifications.Items.Clear(); // Clears notification list
                ListBox_ListOfSettings.Enabled = false;
                Timer_FileProgressDisplay.Enabled = true;
                BackgroundWorker_Backup.WorkerSupportsCancellation = true;
                BackgroundWorker_Backup.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Pauses/resumes the backup job.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void Button_PauseResume_Click(object _sender, EventArgs _e)
        {
            if (PauseBackup) Button_PauseResume.Text = Language[SelectedLanguage, 48];
            else Button_PauseResume.Text = Language[SelectedLanguage, 49];
            PauseBackup = false == PauseBackup; // switches between true/false
        }
        /// <summary>
        /// Saves the current settings into a new list entry.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_AddEntry_Click(object _sender, EventArgs _e)
        {
            string _newEntry = TextBox_SourcePath.Text + "?"
                + TextBox_DestinationPath.Text + "?"
                + RadioButton_OverwriteIfNewer.Checked + "?"
                + RadioButton_CopyAll.Checked + "?"
                + CheckBox_DeleteOldFiles.Checked + "?"
                + SelectedLanguage + "?"
                + CheckBox_ShutDown.Checked;

            SettingReadings.Add(_newEntry);
            ReloadSettingsListBoxEntries(ListBox_ListOfSettings, SettingReadings);
        }
        /// <summary>
        /// Deletes current selected entry from list.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_DeleteEntry_Click(object _sender, EventArgs _e)
        {
            SettingReadings.RemoveAt(SettingsList_SelectedIndex);
            ListBox_ListOfSettings.Items.RemoveAt(SettingsList_SelectedIndex);
        }
        /// <summary>
        /// Saves changes of the current selected entry if the list.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_SaveEntry_Click(object _sender, EventArgs _e)
        {
            if (SettingsList_SelectedIndex == -1) return;
            string _modifiedEntry = TextBox_SourcePath.Text + "?"
                + TextBox_DestinationPath.Text + "?"
                + RadioButton_OverwriteIfNewer.Checked + "?"
                + RadioButton_CopyAll.Checked + "?"
                + CheckBox_DeleteOldFiles.Checked + "?"
                + SelectedLanguage + "?"
                + CheckBox_ShutDown.Checked;

            SettingReadings[SettingsList_SelectedIndex] = _modifiedEntry;
            ReloadSettingsListBoxEntries(ListBox_ListOfSettings, SettingReadings);
        }

// TIMER
        /// <summary>
        /// Updates the "x-files/y-files" label (Label_FileProgress) and the current file label (Label_CurrentFile_FileName)
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void Timer_FileProgressDisplay_Tick(object _sender, EventArgs _e)
        {
            if (CountingFiles)
            {
                Label_CurrentFile_FileName_setText(Language[SelectedLanguage, 21] + " (" + Amount_FilesInSourcePath + ")");
            }
            else if (CurrentFile != "")
            {
                Label_CurrentFile_FileName_setText(CurrentFile + " ( " + CurrentFileInMBytes.ToString() + " MB ) ");
                CurrentFile = "";
            }
            if (Amount_BytesInSourcePath <= 0) // can also be -1 for not counting the bytes in CountFiles()
            {
                Label_FileProgress_setText(Amount_ProcessedFiles.ToString() + " / " + Amount_FilesInSourcePath.ToString());
                SetProgressbar(Amount_ProcessedFiles, Amount_FilesInSourcePath);
            }
            else
            {
                Label_FileProgress_setText(Amount_ProcessedFiles.ToString() + " / " + Amount_FilesInSourcePath.ToString() + " ( " +
                    (int)(Amount_CopiedBytes / 1048576) + "MB / " + (int)(Amount_BytesInSourcePath / 1048576) + "MB )");
                SetProgressbar(Amount_CopiedBytes, Amount_BytesInSourcePath);
            }
            if (BackupIsRunning == false && Button_StartStopBackup.Text == "OK" && ListBox_ListOfSettings.Enabled == false) // backup finished but listbox not enabled
            {
                ListBox_ListOfSettings.Enabled = true;
            }
        }
        /// <summary>
        /// Updates the time-label (Label_ElapsedTimeData)
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void Timer_TimeProgressDisplay_Tick(object _sender, EventArgs _e) 
        {
            if (PauseBackup) return;
            if (ResetAll) ResetSimpleBackup();
            if (BackupIsRunning)
            {
                TimeSpan _ts = (DateTime.Now - StartTime - PausedTime);
                Label_ElapsedTimeData.Text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", _ts.Hours, _ts.Minutes, _ts.Seconds);
            }
            else
            {
                // Abfrage, wenn jemand etwas per hand eingiebt
                enableAfterInput();
            }
        }
// FORM
        /// <summary>
        /// Stops backup job and saves settings at MainForm close.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void Form_MainForm_FormClosing(object _sender, FormClosingEventArgs _e) 
        {
            if (BackupIsRunning)
            {
                DialogResult _ds = MessageBox.Show(Language[SelectedLanguage, 19], Language[SelectedLanguage, 20], MessageBoxButtons.YesNo);
                if (_ds == System.Windows.Forms.DialogResult.Yes)
                {
                    BackupIsRunning = false;
                    BackgroundWorker_Backup.CancelAsync();
                }
                else
                {
                    _e.Cancel = true;
                    return;
                }
            }
            StreamWriter _writer = new StreamWriter("some.settings");
            for (int _i = 0; _i < SettingReadings.Count; _i++)
            {
                _writer.WriteLine(SettingReadings[_i]);
            }
            _writer.Close();
            Application.Exit();
        }

// CHECKBOX
        /// <summary>
        /// Shows notification about the "delete old files"-checkbox
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void CheckBox_DeleteOldFiles_MouseHover(object _sender, EventArgs _e) 
        {
            ToolTip.Show(Language[SelectedLanguage, 17], CheckBox_DeleteOldFiles);
        }

//LISTBOX
        /// <summary>
        /// Shows context menu after right click on an error in the notification list
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ListBox_Notifications_MouseDown(object _sender, MouseEventArgs _e)
        {
            if (_e.Button == MouseButtons.Right && Button_StartStopBackup.Text == "OK" // right click and backup ended
                && ListBox_Notifications.IndexFromPoint(_e.X, _e.Y) != -1
                && ListBox_Notifications.Items[ListBox_Notifications.IndexFromPoint(_e.X, _e.Y)].ToString().Contains(Language[SelectedLanguage, 22])) // when entry is a error-entry
            {
                ListBox_Notifications.SelectedItem = ListBox_Notifications.Items[ListBox_Notifications.IndexFromPoint(_e.X, _e.Y)];
                ContextMenuStrip_ErrorMessage.Show(new Point(Form_MainForm.MousePosition.X, Form_MainForm.MousePosition.Y));

                // analyse the selected entry
                string _currentEntry = ListBox_Notifications.SelectedItem.ToString();
                string _splitEntry = _currentEntry.Split('(')[1]; // [0] = "ERROR" , [1] = "x): ..."
                _splitEntry = _splitEntry.Split(')')[0]; // [0] = "x", [1] = ": ..."
                SelectedErrorMessage = Convert.ToInt32(_splitEntry);
            }
        }
        /// <summary>
        /// When user clicked on an item from the list of settings.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ListBox_ListOfSettings_SelectedIndexChanged(object _sender, EventArgs _e)
        {
            if (ListBox_ListOfSettings.SelectedIndex != -1) SettingsList_SelectedIndex = ListBox_ListOfSettings.SelectedIndex; // saves valid index
            if (BackupIsRunning == false && Button_StartStopBackup.Text == "OK")
            {
                // return to screen befor backup started
                Button_StartStopBackup.Text = Language[SelectedLanguage, 8];
                ListBox_Notifications.Items.Clear();
                ResetSimpleBackup();
            }
            if (Button_StartStopBackup.Text == "OK") return; // return otherwise errors will occur because of the amount of entries
            if (ListBox_ListOfSettings.SelectedItem == null) return;

            // todo: options -> settings -> reset -> save -> klick on second entry in settings list -> error: ArgumentOutOfRangeException
            int _i = ListBox_ListOfSettings.SelectedIndex;
            string[] _t = SettingReadings[ListBox_ListOfSettings.SelectedIndex].Split('?');
            if (_t.Length == 7)
            {
                if (_t[0] != TextBox_SourcePath.Text ||
                    _t[1] != TextBox_DestinationPath.Text ||
                    Convert.ToBoolean(_t[2]) != RadioButton_OverwriteIfNewer.Checked ||
                    Convert.ToBoolean(_t[3]) != RadioButton_CopyAll.Checked ||
                    Convert.ToBoolean(_t[4]) != CheckBox_DeleteOldFiles.Checked ||
                    Convert.ToInt32(_t[5]) != SelectedLanguage || 
                    Convert.ToBoolean(_t[6]) != CheckBox_ShutDown.Checked) // preventing de-selecting of the entry
                {
                    TextBox_SourcePath.Text = _t[0]; 
                    TextBox_DestinationPath.Text = _t[1]; 
                    RadioButton_OverwriteIfNewer.Checked = Convert.ToBoolean(_t[2]); 
                    RadioButton_CopyAll.Checked = Convert.ToBoolean(_t[3]); 
                    CheckBox_DeleteOldFiles.Checked = Convert.ToBoolean(_t[4]); 
                    SelectedLanguage = Convert.ToInt32(_t[5]);
                    CheckBox_ShutDown.Checked = Convert.ToBoolean(_t[6]);

                    if (_t[5] == "0") ChangeLanguage("Deutsch");
                    if (_t[5] == "1") ChangeLanguage("English");

                    ListBox_ListOfSettings.SetSelected(_i, true);
                }
            }
        }
        /// <summary>
        /// Click on entry in settings list.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ListBox_ListOfSettings_MouseDown(object _sender, MouseEventArgs _e)
        {
            if (_e.Button == MouseButtons.Right && ListBox_ListOfSettings.IndexFromPoint(_e.X, _e.Y) != -1) // is right-click
            {
                ListBox_ListOfSettings.SelectedItem = ListBox_ListOfSettings.Items[ListBox_ListOfSettings.IndexFromPoint(_e.X, _e.Y)];
                ContextMenuStrip_Settings.Show(new Point(Form_MainForm.MousePosition.X, Form_MainForm.MousePosition.Y));
            }
        }

// CONTEXT MENU
        /// <summary>
        /// When item in the context menu of an error message has been clicked ("ERROR:..." -> click -> this will be executed)
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ContextMenuStrip_ErrorMessage_ItemClicked(object _sender, ToolStripItemClickedEventArgs _e)
        {
            if (ListBox_Notifications.SelectedItem.ToString().Contains(Language[SelectedLanguage, 22]) == false) return; // when entry is no error-entry
            if (_e.ClickedItem.Text == Language[SelectedLanguage, 34])
            {
                System.Diagnostics.Process.Start("https://sourceforge.net/p/simple-backup-tool/tickets/new/"); // Tickets on Sourceforge.net
            }
            if (_e.ClickedItem.Text == Language[SelectedLanguage, 35])
            {
                Clipboard.SetText(ErrorMessages[SelectedErrorMessage]);
            }
        }
        /// <summary>
        /// Called after doing a right-click on an entry in the listbox you get an entry to delete it.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void ContextMenuStrip_Settings_ItemClicked(object _sender, ToolStripItemClickedEventArgs _e)
        {
            if (_e.ClickedItem.Text == Language[SelectedLanguage, 26]) // if the entry is "delete"
            {
                SettingReadings.RemoveAt(ListBox_ListOfSettings.SelectedIndex);
                ListBox_ListOfSettings.Items.RemoveAt(ListBox_ListOfSettings.SelectedIndex);
            }
        }

// TOOL STRIP MENU ITEM
        /// <summary>
        /// When "Deutsch" under "options" -> "language" has been clicked
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Deutsch_Click(object _sender, EventArgs _e)
        {
            ChangeLanguage("Deutsch");
        }
        /// <summary>
        /// When "English" under "options" -> "language" has been clicked
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_English_Click(object _sender, EventArgs _e)
        {
            ChangeLanguage("English");
        }
        /// <summary>
        /// When the "report error" unter "ERROR:..." -> 'click' has been clicked.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_ReportError_Click(object _sender, EventArgs _e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/p/simple-backup-tool/tickets/new/"); // Tickets on Sourceforge.net
        }
        /// <summary>
        /// When option -> setting is clicked.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Settings_Click(object _sender, EventArgs _e)
        {
            //old version:
            //Form _f2 = new Form_Settings(this);
            //_f2.Show();
            (new Form_Settings(this)).Show();
        }
        /// <summary>
        /// Open the help file "help_**.html"
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_OpenHelpDialog_Click(object _sender, EventArgs _e)
        {
            try { 
                if (SelectedLanguage == 0) System.Diagnostics.Process.Start("help_de.html");
                if (SelectedLanguage == 1) System.Diagnostics.Process.Start("help_en.html");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
        /// <summary>
        /// Saves the current entry of the settings list to the SettingsRead-Array (will be saved on exit)
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_SaveEntryToSettings_Click(object _sender, EventArgs _e)
        {
            SettingReadings.Add(TextBox_SourcePath.Text + "?"
                + TextBox_DestinationPath.Text + "?"
                + RadioButton_OverwriteIfNewer.Checked + "?"
                + RadioButton_CopyAll.Checked + "?"
                + CheckBox_DeleteOldFiles.Checked + "?"
                + SelectedLanguage + "?"
                + CheckBox_ShutDown.Checked);
            ListBox_ListOfSettings.Items.Add(TextBox_SourcePath.Text + "  ==>>  " + TextBox_DestinationPath.Text);
        }
        /// <summary>
        /// Calls the exit-event of the MainForm after clicking file -> exit
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Exit_Click(object _sender, EventArgs _e)
        {
            Close();
        }
        /// <summary>
        /// Shows the "about" form
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_About_Click(object _sender, EventArgs _e)
        {
            (new Form_About(this)).Show();
        }
        /// <summary>
        /// Opens the browser with the project site on Sourceforge.net
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_ToSourceforge_Click(object _sender, EventArgs _e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/projects/simple-backup-tool/");
        }
        /// <summary>
        /// Opens the form to write a review on SimpleBackup
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_WriteReview_Click(object _sender, EventArgs _e)
        {
            System.Diagnostics.Process.Start("https://sourceforge.net/projects/simple-backup-tool/reviews/new");
        }
        /// <summary>
        /// Opens the "search for updates" dialog
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_SearchForUpdates_Click(object _sender, EventArgs _e)
        {
            Form_Updates _fu = new Form_Updates(this);
            _fu.Show();
            _fu.CheckForUpdates();
        }

// TEXTBOX
        /// <summary>
        /// When user enteres text into the source path text box.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void TextBox_SourcePath_TextChanged(object _sender, EventArgs _e)
        {
            if (ListBox_ListOfSettings.SelectedIndex != -1) ListBox_ListOfSettings.SelectedIndex = -1;
        }
        /// <summary>
        /// When user enteres text into the destination path text box.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void TextBox_DestinationPath_TextChanged(object _sender, EventArgs _e)
        {
            if (ListBox_ListOfSettings.SelectedIndex != -1) ListBox_ListOfSettings.SelectedIndex = -1;
        }

// LABEL
        /// <summary>
        /// Hover effect: Shows the whole filename of the current file (if the filename goes beyond the window border).
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void Label_CurrentFile_FileName_MouseHover(object _sender, EventArgs _e)
        {
            if (Label_CurrentFile_FileName.Size.Width + Label_CurrentFile_FileName.Left >= Form_MainForm.ActiveForm.Width)
            {
                ToolTip.Show(Label_CurrentFile_FileName.Text, Label_CurrentFile_FileName);
            }
        }



        //Buissenes logic




        /// <summary>
        /// Enables all radio- and check-boxes after any text is typed in.
        /// </summary>
        private void enableAfterInput()
        {
            if (TextBox_SourcePath.Text != "" && TextBox_DestinationPath.Text != "")
            {
                this.RadioButton_OverwriteIfNewer.Enabled = true;
                RadioButton_OverwriteIfNewer.Enabled = true;
                RadioButton_CopyAll.Enabled = true;
                Button_StartStopBackup.Enabled = true;
                CheckBox_DeleteOldFiles.Enabled = true;
            }
        }
        /// <summary>
        /// Resets all configs (radio-, check-boxes, text-boxes, ... ), but NOT the user config with all the paths!!
        /// </summary>
        private void ResetSimpleBackup()
        {
            BackupIsRunning = false;
            SourcePath = "";
            DestinationPath = "";
            RadioButton_OverwriteIfNewer.Enabled = false;
            RadioButton_CopyAll.Enabled = false;
            CheckBox_DeleteOldFiles.Enabled = false;
            Button_StartStopBackup.Text = Language[SelectedLanguage, 8];
            Button_StartStopBackup.Enabled = false;
            Amount_BytesInSourcePath = 0;
            Amount_FilesInSourcePath = 0;
            Amount_CopiedBytes = 0;
            Amount_ProcessedFiles = 0;
            Label_CurrentFile_FileName.Text = "-";
            Label_FileProgress.Text = "0/0";
            //Label_ElapsedTimeData.Text = "00h:00m:00s";
            Label_RemainingTimeData.Text = Language[SelectedLanguage, 15];
            ListBox_ListOfSettings.Enabled = true;
            ProgressBar.Value = 0;
            Timer_FileProgressDisplay.Enabled = false;
            ResetAll = false;
        }
        /// <summary>
        /// Initializes languages (fills the array with strings)
        /// </summary>
        private void InitializeLanguage()
        {
            //todo: put this into a file for user made translations, use format: [english-string]=[***-string] <- everybody would know what to translate ;)
            int _i = 0;
            #region Deutsch
            Language[_i, 0] = "Informationen:";
            Language[_i, 1] = "Fortschritt:";
            Language[_i, 2] = "Optionen";

            Language[_i, 3] = "Quellordner";
            Language[_i, 4] = "Zielordner";

            Language[_i, 5] = "Datei überschreiben, wenn neuer";
            Language[_i, 6] = "Alles kopieren";
            Language[_i, 7] = "Alte Dateien löschen";

            Language[_i, 8] = "Backup starten";
            Language[_i, 9] = "Meldungen:";
            Language[_i, 10] = "Vergangene Zeit:";
            Language[_i, 11] = "Momentane Datei:";
            Language[_i, 12] = "Anzahl Dateien:";
            Language[_i, 13] = "Datei";
            Language[_i, 14] = "Verbleibende Zeit:";
            Language[_i, 15] = "Wenn du anfangen würdest, könnte ich es dir berechnen ;)";

            Language[_i, 16] = "Sprache / language";
            Language[_i, 17] = "Wenn Daten im vorhandenen Backup existieren, \n" +
            "die im aktuellen Datenstand nicht vorhanden sind, \n" +
            "werden diese alten Dateien gelöscht.";
            Language[_i, 18] = "Backup stoppen";
            Language[_i, 19] = "Das Backup läuft noch!\nWirklich beenden?";
            Language[_i, 20] = "Beenden";
            Language[_i, 21] = "Ermittle Dateien ...";
            Language[_i, 22] = "FEHLER:";
            Language[_i, 23] = "Fertig";
            Language[_i, 24] = " Nicht präzise ( unterliegt dem Gesetz der großen Zahlen )";
            Language[_i, 25] = "Speichern";
            Language[_i, 26] = "Löschen";
            Language[_i, 27] = "Kopiere Dateien ...";
            Language[_i, 28] = "Lösche alte Dateien ...";
            Language[_i, 29] = "Dateien werden übersprungen ...";
            Language[_i, 30] = "Nach beenden herunterfahren";
            Language[_i, 31] = "Ermittle alte Dateien ...";
            Language[_i, 32] = " Dateien wurden ermittelt";
            Language[_i, 33] = "Backup erfolgreich fertig gestellt";
            Language[_i, 34] = "Fehler melden";
            Language[_i, 35] = "Kopieren";
            Language[_i, 36] = "Keine Dateien vorhanden";
            Language[_i, 37] = "Bitte melde den Fehler und sende dabei den Inhalt aus folgender Datei:\n";
            Language[_i, 38] = "Das Backup läuft noch!\nWirklich abbrechen?";
            Language[_i, 39] = "Dauer: ";
            Language[_i, 40] = "Backup abgebrochen";
            Language[_i, 41] = "Über SimpleBackup";
            Language[_i, 42] = "Öffnen";
            Language[_i, 43] = "Einstellungen";
            Language[_i, 44] = "Hilfe";
            Language[_i, 45] = "Zum Sourceforge Projekt";
            Language[_i, 46] = "Nach Updates suchen";
            Language[_i, 47] = "Bewertung schreiben";
            Language[_i, 48] = "Backup pausieren";
            Language[_i, 49] = "Backup fortsetzen";
            Language[_i, 50] = "FEHLER: Der Pfad von";
            Language[_i, 51] = "ist zu lang.";
            Language[_i, 52] = "Neu";
            #endregion

            #region English
            _i = 1;
            Language[_i, 0] = "Information:";
            Language[_i, 1] = "Progress:";
            Language[_i, 2] = "Options";

            Language[_i, 3] = "source folder";
            Language[_i, 4] = "destination folder";

            Language[_i, 5] = "overwrite file, if newer";
            Language[_i, 6] = "copy everything";
            Language[_i, 7] = "delete old files";

            Language[_i, 8] = "start backup";
            Language[_i, 9] = "Notification:";
            Language[_i, 10] = "elapsed time:";
            Language[_i, 11] = "current file:";
            Language[_i, 12] = "amount of files:";
            Language[_i, 13] = "file";
            Language[_i, 14] = "remaining time:";
            Language[_i, 15] = "If you'd start, I could calculate it ;)";

            Language[_i, 16] = "language";
            Language[_i, 17] = "If a file exists in the backup folder, \n" +
            "but not in the original folder, \n" +
            "it'll be deleted.";
            Language[_i, 18] = "stop backup";
            Language[_i, 19] = "The backup is still running!\nExit anyway?";
            Language[_i, 20] = "exit";
            Language[_i, 21] = "detecting files ...";
            Language[_i, 22] = "ERROR:";
            Language[_i, 23] = "finished";
            Language[_i, 24] = " not precise ( is subject to the law of large numbers )";
            Language[_i, 25] = "save";
            Language[_i, 26] = "delete";
            Language[_i, 27] = "copy files ...";
            Language[_i, 28] = "delete old files ...";
            Language[_i, 29] = "skipping files ...";
            Language[_i, 30] = "shutdown after finish";
            Language[_i, 31] = "detecting old files ...";
            Language[_i, 32] = " files has been detected";
            Language[_i, 33] = "backup successfully finished";
            Language[_i, 34] = "report error";
            Language[_i, 35] = "copy";
            Language[_i, 36] = "no file exists";
            Language[_i, 37] = "Please report the error and send the content of the following file:\n";
            Language[_i, 38] = "The backup is still running!\nAbord anyway??";
            Language[_i, 39] = "duration: ";
            Language[_i, 40] = "backup aborded";
            Language[_i, 41] = "about SimpleBackup";
            Language[_i, 42] = "open";
            Language[_i, 43] = "settings";
            Language[_i, 44] = "help";
            Language[_i, 45] = "to the Sourceforge projekt";
            Language[_i, 46] = "search for updates";
            Language[_i, 47] = "write review";
            Language[_i, 48] = "pause backup";
            Language[_i, 49] = "resume backup";
            Language[_i, 50] = "ERROR: The path";
            Language[_i, 51] = "is to long.";
            Language[_i, 52] = "new";
            #endregion
        }
        /// <summary>
        /// Changes the language to "Deutch" or "English".
        /// </summary>
        /// <param name="to">Desired language. E.g.: "English". Avalaible languages: "Deutsch", "English", more coming ... some day ...</param>
        private void ChangeLanguage(string to) 
        {
            switch (to)
            {
                case "Deutsch":
                    SelectedLanguage = 0;
                    ToolStripMenuItem_Deutsch.CheckState = CheckState.Checked;
                    ToolStripMenuItem_English.CheckState = CheckState.Unchecked;
                    break;
                case "English":
                    SelectedLanguage = 1;
                    ToolStripMenuItem_English.CheckState = CheckState.Checked;
                    ToolStripMenuItem_Deutsch.CheckState = CheckState.Unchecked;
                    break;
            }
            // BUttons
            if (BackupIsRunning) Button_StartStopBackup.Text = Language[SelectedLanguage, 18];
            else Button_StartStopBackup.Text = Language[SelectedLanguage, 8];
            if (PauseBackup) Button_PauseResume.Text = Language[SelectedLanguage, 49];
            else Button_PauseResume.Text = Language[SelectedLanguage, 48];
            Button_AddEntry.Text = Language[SelectedLanguage, 52];
            Button_SaveEntry.Text = Language[SelectedLanguage, 25];
            Button_DeleteEntry.Text = Language[SelectedLanguage, 26];
            // Radio-/Checkboxen
            RadioButton_OverwriteIfNewer.Text = Language[SelectedLanguage, 5];
            RadioButton_CopyAll.Text = Language[SelectedLanguage, 6];
            CheckBox_DeleteOldFiles.Text = Language[SelectedLanguage, 7];
            CheckBox_ShutDown.Text = Language[SelectedLanguage, 30];
            //Label
            Label_CurrentFile.Text = Language[SelectedLanguage, 11];
            Label_AmountFiles.Text = Language[SelectedLanguage, 12];
            Label_ElapsedTime.Text = Language[SelectedLanguage, 10];
            Label_RemainingTime.Text = Language[SelectedLanguage, 14];
            Label_Source.Text = Language[SelectedLanguage, 3];
            Label_Destination.Text = Language[SelectedLanguage, 4];
            if (BackupIsRunning) Label_RemainingTimeData.Text = "";
            else Label_RemainingTimeData.Text = Language[SelectedLanguage, 15];
            Label_Information.Text = Language[SelectedLanguage, 0];
            Label_Source.Text = Language[SelectedLanguage, 3];
            Label_Destination.Text = Language[SelectedLanguage, 4];
            Label_Progress.Text = Language[SelectedLanguage, 1];
            Label_Notifications.Text = Language[SelectedLanguage, 9];
            // Context menu
            ContextMenuStrip_ErrorMessage.Items.Clear();
            ContextMenuStrip_ErrorMessage.Items.Add(Language[SelectedLanguage, 34]);
            ContextMenuStrip_ErrorMessage.Items.Add(Language[SelectedLanguage, 35]);
            ContextMenuStrip_Settings.Items.Clear();
            ContextMenuStrip_Settings.Items.Add(Language[SelectedLanguage, 26]);
            // Menu items
            ToolStripMenuItem_File.Text = Language[SelectedLanguage, 13];
            ToolStripMenuItem_Open.Text = Language[SelectedLanguage, 42];
            ToolStripMenuItem_Save.Text = Language[SelectedLanguage, 25];
            ToolStripMenuItem_Exit.Text = Language[SelectedLanguage, 20];
            ToolStripMenuItem_Options.Text = Language[SelectedLanguage, 2];
            ToolStripMenuItem_Language.Text = Language[SelectedLanguage, 16];
            ToolStripMenuItem_Settings.Text = Language[SelectedLanguage, 43];
            ToolStripMenuItem_Help.Text = Language[SelectedLanguage, 44];
            ToolStripMenuItem_OpenHelpDialog.Text = Language[SelectedLanguage, 44];
            ToolStripMenuItem_ToSourceforge.Text = Language[SelectedLanguage, 45];
            ToolStripMenuItem_SearchForUpdates.Text = Language[SelectedLanguage, 46];
            ToolStripMenuItem_About.Text = Language[SelectedLanguage, 41];
            ToolStripMenuItem_ReportError.Text = Language[SelectedLanguage, 34];
            logToolStripMenuItem.Text = "Log " + Language[SelectedLanguage, 13];
            ToolStripMenuItem_SaveEntryToSettings.Text = Language[SelectedLanguage, 43];
            ToolStripMenuItem_WriteReview.Text = Language[SelectedLanguage, 47];
        }
        /// <summary>
        /// Sets the label that shows the name of the current file.
        /// </summary>
        /// <param name="text">Name of the file.</param>
        private void Label_CurrentFile_FileName_setText(string text)
        {
            Label_CurrentFile_FileName.Invoke((MethodInvoker)delegate { Label_CurrentFile_FileName.Text = text; });
        }
        /// <summary>
        /// Sets the label that shows the amount of files beeing processed.
        /// </summary>
        /// <param name="text">The text that should be shown. The best way: "[current_amount]/[total_amount]</param>
        private void Label_FileProgress_setText(string text)
        {
            Label_CurrentFile_FileName.Invoke((MethodInvoker)delegate { Label_FileProgress.Text = text; });
        }
        /// <summary>
        /// Sets the progressbar and the remaining time label to a specific value. For the progressbar it's: a/b*100
        /// </summary>
        /// <param name="a">numerator</param>
        /// <param name="b">denominator</param>
        private void SetProgressbar(long a, long b)
        {
            ProgressBar.Invoke((MethodInvoker)delegate
            {
                if (b > 0 && a >= 0)
                {
                    int _value = (int)((float)a / (float)b * 100);
                    if (_value > 100)_value = 100;
                    //else if (value < 0) value = 0;
                    ProgressBar.Value = _value;
                }
            });
            Label_RemainingTimeData.Invoke((MethodInvoker)delegate
            {
                if (Amount_CopiedBytes != 0 && PauseBackup == false)
                {
                    double _s = (DateTime.Now - StartTime - PausedTime).Hours * 3600;
                    _s += (DateTime.Now - StartTime - PausedTime).Minutes * 60;
                    _s += (DateTime.Now - StartTime - PausedTime).Seconds;
                    _s *= ((float)Amount_BytesInSourcePath / (float)Amount_CopiedBytes);
                    TimeSpan _ts = TimeSpan.FromSeconds(_s);
                    Label_RemainingTimeData.Text = string.Format("{0:D2}h:{1:D2}m:{2:D2}s", _ts.Hours, _ts.Minutes, _ts.Seconds)
                        + Language[SelectedLanguage, 24];
                }
            });
        }
        /// <summary>
        /// Adds an entry to the Notification box.
        /// </summary>
        /// <param name="entry">String/Message to add.</param>
        private void ListBox_Notifications_AddEntry(string entry)
        {
            ListBox_Notifications.Invoke((MethodInvoker)delegate { ListBox_Notifications.Items.Add(entry); });
        }
        /// <summary>
        /// Sets the text of the start/stop button
        /// </summary>
        /// <param name="text">New text of the button.</param>
        private void Button_StartStopBackup_setText(string text)
        {
            Button_StartStopBackup.Invoke((MethodInvoker)delegate { Button_StartStopBackup.Text = text; });
        }
        /// <summary>
        /// Reload all entries in the settings list box
        /// </summary>
        /// <param name="listbox">ListBox reference.</param>
        /// <param name="entries">List of new entries.</param>
        public void ReloadSettingsListBoxEntries(ListBox listbox, List<string> entries)
        {
            listbox.Items.Clear();
            foreach (string str in entries)
            {
                if (str == "") continue;
                string[] _t = str.Split('?');
                listbox.Items.Add(_t[0] + "  ==>>  " + _t[1]);
            }
        }
        /// <summary>
        /// Shows an error message on the notification list box.
        /// </summary>
        /// <param name="e">The error argument.</param>
        /// <param name="stopBackup">When the error is so fatal that the backup has to be canceled set this to "true".</param>
        public void ErrorOccured(ErrorEventArgs _e, Boolean stopBackup = true)
        {
            ListBox_Notifications.Items.Add(Language[SelectedLanguage, 22] + "(" + ErrorMessageCounter + ") " + _e.GetException().Message);
            string _date = DateTime.Now.ToString().Replace(":", ".");
            ListBox_Notifications.Items.Add(Language[SelectedLanguage, 37] + _date + ".log");

            string _temp_ErrorMessage = Language[SelectedLanguage, 22] + "(" + ErrorMessageCounter + ") " + _e.GetException().Message + "\n"
                + _e.GetException().StackTrace + "\n"
                + _e.GetException().Data + "\n"
                + _e.GetException().HelpLink + "\n"
                + _e.GetException().InnerException + "\n"
                + _e.GetException().TargetSite;

            ErrorMessages.Add(_temp_ErrorMessage);
            StreamWriter _writer = new StreamWriter(_date + ".log");
            _writer.Write(_temp_ErrorMessage);
            _writer.Close();
            ListBox_Notifications.Items.Add(Language[SelectedLanguage, 34]);
            BackupIsRunning = false;
        }



        /*
         * Backgroundworker stuff
         * */



        /// <summary>
        /// Sets everything to default values. This is the entry point for the backup job.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_Backup_DoWork(object _sender, DoWorkEventArgs _e)
        {
            BackupAborded = true; // when no return; is called it'll be set to false for a successfully completed backup
            Label_CurrentFile_FileName_setText(Language[SelectedLanguage, 21]);
            ListBox_Notifications_AddEntry(DateTime.Now + " : " + Language[SelectedLanguage, 21]); // Detecting files ...
            Amount_FilesInSourcePath = 0;
            CountingFiles = true;
            Amount_FilesInSourcePath = CountFiles(SourcePath, 0);
            if (BackupIsRunning == false) return;
            ListBox_Notifications_AddEntry(DateTime.Now + " : " + Amount_FilesInSourcePath + Language[SelectedLanguage, 32]); // x files has been detected
            CountingFiles = false;

            if (Amount_FilesInSourcePath != 0)
            {
                if (BackupIsRunning == false) return;
                ListBox_Notifications_AddEntry(DateTime.Now + " : " + Language[SelectedLanguage, 27]); // copy files ...
                BackupFiles(new QuickIODirectoryInfo(SourcePath), 0);
                if (BackupIsRunning == false) return;
                ListBox_Notifications_AddEntry(DateTime.Now + " : OK");
                if (CheckBox_DeleteOldFiles.Checked) // Delete old files
                {
                    // prepare cleanup
                    Amount_ProcessedFiles = 0;
                    Amount_CopiedBytes = 0;
                    Amount_BytesInSourcePath = -1; // CountFiles() won't count bytes
                    Amount_FilesInSourcePath = 0;
                    if (BackupIsRunning == false) return;
                    ListBox_Notifications_AddEntry(DateTime.Now + " : " + Language[SelectedLanguage, 31]); // detecting old files ...
                    CountingFiles = true;
                    Amount_FilesInSourcePath = CountFiles(DestinationPath, 0);
                    if (BackupIsRunning == false) return;
                    ListBox_Notifications_AddEntry(DateTime.Now + " : " + Amount_FilesInSourcePath + Language[SelectedLanguage, 32]); // x files has been detected
                    // start cleanup
                    CountingFiles = false;
                    if (BackupIsRunning == false) return;
                    ListBox_Notifications_AddEntry(DateTime.Now + " : " + Language[SelectedLanguage, 28]); // cleanup ...
                    Amount_BytesInSourcePath = 0; // MBs are not important for cleanup. Label will not show MBs anymore ( no MB/MB anymore )
                    Label_CurrentFile_FileName_setText("");
                    // cleanup
                    CleanUpBackup(new QuickIODirectoryInfo(DestinationPath), 0);
                    if (BackupIsRunning == false) return;
                    ListBox_Notifications_AddEntry(DateTime.Now + " : OK");
                }
                else
                {
                    ListBox_Notifications_AddEntry(DateTime.Now + " : " + Language[SelectedLanguage, 36]); // no file exists
                }
            }
            BackupAborded = false; // successfully completed
            if (CheckBox_ShutDown.Checked) System.Diagnostics.Process.Start("shutdown.exe", "-s -t 0");
        }
        /// <summary>
        /// When worker finished his work or aborded it.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="e"></param>
        private void BackgroundWorker_Backup_RunWorkerCompleted(object _sender, RunWorkerCompletedEventArgs _e)
        {
            Button_PauseResume.Enabled = false;
            BackupIsRunning = false;
            ListBox_ListOfSettings.Enabled = true;
            Label_CurrentFile_FileName_setText("");
            SetProgressbar(0, 1);
            Amount_FilesInSourcePath = 0;
            Amount_ProcessedFiles = 0;
            if (BackupAborded)
                ListBox_Notifications.Items.Add(Language[SelectedLanguage, 40]);
            else
                ListBox_Notifications.Items.Add(Language[SelectedLanguage, 33]);
            TimeSpan _ts = (DateTime.Now - StartTime - PausedTime);
            ListBox_Notifications_AddEntry(Language[SelectedLanguage, 39] + string.Format("{0:D2}h:{1:D2}m:{2:D2}s", _ts.Hours, _ts.Minutes, _ts.Seconds));
            if (_e.Error != null)
            {
                BeginInvoke((EventHandler)delegate { ErrorOccured(new ErrorEventArgs(_e.Error)); });
            }
            Button_StartStopBackup_setText("OK");
        }



        //Backup stuff



// STEP 1: COUNT FILES
        /// <summary>
        /// Count the amount of files recusively in the path "path".
        /// </summary>
        /// <param name="path">The path whose amount of files you want to know.</param>
        /// <param name="amount">The amount of bytes of this directory.</param>
        /// <returns></returns>
        private int CountFiles(string _path, int _amount)
        {
            if (BackupIsRunning == false) return _amount;
            int _dirLength = 0;
            QuickIODirectoryInfo _dInfo = new QuickIODirectoryInfo(_path);
            IEnumerable<QuickIODirectoryInfo> _directories = _dInfo.EnumerateDirectories(SearchOption.TopDirectoryOnly);
            _dirLength = _directories.Count();

            if (_dirLength != 0)
            {
                foreach (QuickIODirectoryInfo _dir in _directories)
                {
                    if (PauseBackup == false) Pause();
                    _amount = CountFiles(_dir.FullName, _amount); // goes deeper into folders
                    if (BackupIsRunning == false) return _amount;
                }
            }
            foreach (QuickIOFileInfo _file in _dInfo.EnumerateFiles()) // for every existing file in current folder ( without subfolders )
            {
                if (PauseBackup == false) Pause();
                if (Amount_BytesInSourcePath != -1) Amount_BytesInSourcePath += (int)_file.Bytes;
                Amount_FilesInSourcePath++;
                _amount++;
            }

            return _amount;
        }
        
// STEP 2: REAL BACKUP
        /// <summary>
        /// Actual backup routine. This will do all the work recursively, considering all the settings.
        /// </summary>
        /// <param name="dInfo">QuickIO.QuickIODirectoryInfo - Information about the directory.</param>
        /// <param name="amount">Counter of the amount of processed files.</param>
        /// <returns></returns>
        private int BackupFiles(QuickIODirectoryInfo _dInfo, int _amount) 
        {
            if (BackupIsRunning == false) return _amount;
            int _dirLength = 0;
            IEnumerable<QuickIODirectoryInfo> _directories = _dInfo.EnumerateDirectories(SearchOption.TopDirectoryOnly);
            _dirLength = _directories.Count();

            if (_dirLength != 0)
            {
                foreach (QuickIODirectoryInfo _dir in _directories)
                {
                    if (PauseBackup == false) Pause();
                    string str = DestinationPath + _dir.FullName.Replace(SourcePath, ""); // find name of Folder in the Destination path
                    if (QuickIO.DirectoryExists(str) == false)
                        QuickIO.CreateDirectory(str, true);
                    _amount = BackupFiles(new QuickIODirectoryInfo(_dir.FullName), _amount); // goes deeper into folders
                    if (BackupIsRunning == false) return _amount;
                }
            }
            foreach (QuickIOFileInfo _file in _dInfo.EnumerateFiles())
            {
                if (PauseBackup == false) Pause();
                string _str = DestinationPath + _file.FullName.Replace(SourcePath, "");
                if (_str.Length <= 260)
                {
                    DateTime _dt = File.GetLastWriteTime(_str);
                    DateTime _dt_old = File.GetLastWriteTime(_file.FullName);
                    if (QuickIO.FileExists(_str) == false || _dt != _dt_old)
                    {
                        if (RadioButton_OverwriteIfNewer.Checked || RadioButton_CopyAll.Checked)
                        {
                            CurrentFile = _file.FullName;
                            CurrentFileInMBytes = (int)(_file.Bytes / 1000000);
                            try
                            {
                                QuickIOFile.Copy(_file.FullName, _str, true);
                            }
                            catch (Exception _ex)
                            {
                                ListBox_Notifications_AddEntry(_ex.Message);
                            }
                        }
                    }
                    else
                    {
                        if (Label_CurrentFile_FileName.Text != "") Label_CurrentFile_FileName_setText(Language[SelectedLanguage, 29]);
                    }
                    Amount_CopiedBytes += (int)_file.Bytes;
                    _amount++;
                    Amount_ProcessedFiles++;
                }
                else
                {
                    ListBox_Notifications_AddEntry(Language[SelectedLanguage, 50] + " \"" + _file.Name + "\" " + Language[SelectedLanguage, 51]);
                }
            }
            return _amount;
        }
        
// STEP 3: CLEAN UP / DELETE OLD FILES
        /// <summary>
        /// Recurively deletes old files (provided the option for this is enabled)
        /// </summary>
        /// <param name="dInfo">QuickIO.QuickIODirectoryInfo - Information about the directory.</param>
        /// <param name="amount">Counter for info label.</param>
        /// <returns></returns>
        private int CleanUpBackup(QuickIODirectoryInfo _dInfo, int _amount) 
        {
            if (BackupIsRunning == false) return _amount;
            int _dirLength = 0;
            IEnumerable<QuickIODirectoryInfo> _directories = _dInfo.EnumerateDirectories(SearchOption.TopDirectoryOnly);
            _dirLength = _directories.Count();

            if (_dirLength != 0)
            {
                foreach (QuickIODirectoryInfo _dir in _directories)
                {
                    if (PauseBackup == false) Pause();
                    string _str = SourcePath + _dir.FullName.Replace(DestinationPath, "");
                    if (QuickIO.DirectoryExists(_str) == false)
                    {
                        CleanUpBackup(_dir, _amount);
                        if (BackupIsRunning == false) return _amount;
                        try
                        {
                            QuickIODirectory.Delete(_dir.FullName, true); // delete non existing folders
                        }
                        catch (Exception _ex)
                        {
                        } // no exception handling; the notification list would be crowded ;)
                    }
                    else
                    {
                        _amount = CleanUpBackup(new QuickIODirectoryInfo(_dir.FullName), _amount); // goes deeper into folders
                    }
                }
            }
            foreach (QuickIOFileInfo _file in _dInfo.EnumerateFiles()) // for every file in current folder ( without subfolders )
            {
                if (PauseBackup == false) Pause();
                string _str = SourcePath + _file.FullName.Replace(DestinationPath, "");
                _amount++;
                Amount_ProcessedFiles++;
                if (QuickIO.FileExists(_str) == false)
                {
                    Label_CurrentFile_FileName_setText(_file.FullName);
                    CurrentFile = _file.FullName;
                    try
                    {
                        QuickIO.DeleteFile(_file.FullName);
                    }
                    catch (Exception _ex)
                    {
                    } // no exception handling; the notification list would be crowded ;)
                }
                else
                {
                    if (Label_CurrentFile_FileName.Text != "") Label_CurrentFile_FileName_setText(Language[SelectedLanguage, 29]);
                }
            }
            return _amount;
        }
        
        /// <summary>
        /// Do-nothing-loop until "PauseBackup" is set to false by the main thread (not by the worker)
        /// </summary>
        private void Pause() // checks if PauseBackup is true or not. If it's true, the process will be paused
        {
            DateTime _dt = DateTime.Now;
            while (PauseBackup) { Thread.Sleep(10); } // waits until PauseBakcup is false; 10ms wait time for not killing the cpu ;)
            PausedTime += (DateTime.Now - _dt); // the difference to DateTime.Now must be equal to the sifference BEFOR pausing the process.
        }
    }
}