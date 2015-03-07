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
using System.Threading;
using System.Windows.Forms;

namespace SimpleBackup
{
    public partial class Form_Updates : Form
    {
        Form_MainForm MainForm;

        /// <summary>
        /// Initializes everything and sets the language.
        /// </summary>
        /// <param name="_MainForm"></param>
        public Form_Updates(Form_MainForm _MainForm)
        {
            InitializeComponent();
            this.MainForm = _MainForm;
            ChangeLanguage();
        }
        /// <summary>
        /// Changes the language to the current selected language given by the MainForm.
        /// </summary>
        private void ChangeLanguage()
        {
            Text = MainForm.LanguageList[MainForm.SelectedLanguage][79];
            Button_DownloadUpdate.Text = MainForm.LanguageList[MainForm.SelectedLanguage][78];
        }
        /// <summary>
        /// Click on the download-button. Opens a browser with the sourceforge-link to the new version.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_DownloadUpdate_Click(object _sender, EventArgs _e) // search/back button clicked
        {
            Thread _threadUpdate = new Thread(CheckForUpdates);
            _threadUpdate.Name = MainForm.LanguageList[MainForm.SelectedLanguage][78];
            _threadUpdate.Start();
            try
            {
                if (ProductVersion != ProductVersion)
                {
                    System.Diagnostics.Process.Start("https://sourceforge.net/projects/simple-backup-tool/files/latest/download?source=navbar"); // download newest        
                }
                else
                {
                    string.Format("CurrentVerison");
                    Close();
                }
            }
            catch (Exception _ex)
            {
                string.Format("Fehler: {0}", _ex);
                Close();
            }
            }

        /// <summary>
        /// Checks for a newer version of SimpleBackup by download a simple text-file with the latest version number in it.
        /// </summary>
        public void CheckForUpdates() // download file from webspace and checks if update is avalaible
        {
            try
            {
                System.Net.WebClient _wclient = new System.Net.WebClient();
                _wclient.Proxy = null;                
                string _str = _wclient.DownloadString("http://master.dl.sourceforge.net/project/simple-backup-tool/ver.txt");
                ListBox_UpdateLog.Items.Add(MainForm.LanguageList[MainForm.SelectedLanguage][72]);
                ListBox_UpdateLog.Items.Add(MainForm.LanguageList[MainForm.SelectedLanguage][73]);
                ListBox_UpdateLog.Items.Add(MainForm.LanguageList[MainForm.SelectedLanguage][74] + _str);
                _str = _str.Replace(".", "");
                if (Convert.ToInt32(_str) > Convert.ToInt32(ProductVersion.Replace(".", ""))) // newer version number withput "." is higher
                {
                    ListBox_UpdateLog.Items.Add(MainForm.LanguageList[MainForm.SelectedLanguage][75]); // update avalaible
                    Button_DownloadUpdate.Text = MainForm.LanguageList[MainForm.SelectedLanguage][77];
                }
                else
                {
                    ListBox_UpdateLog.Items.Add(MainForm.LanguageList[MainForm.SelectedLanguage][76]); // no update
                    Button_DownloadUpdate.Text = MainForm.LanguageList[MainForm.SelectedLanguage][78];
                }
            }
            catch (Exception _ex)
            {
                MainForm.ErrorOccured(new System.IO.ErrorEventArgs(_ex), false);
                Close();
            }
        }
    }
}
