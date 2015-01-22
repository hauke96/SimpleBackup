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

namespace SimpleBackup
{
    public partial class Form_About : Form
    {
        string[,] Language = new string[2, 5];
        Form_MainForm MainForm;

        /// <summary>
        /// Initializing stuff (language, MainForm)
        /// </summary>
        /// <param name="MainForm"></param>
        public Form_About(Form_MainForm MainForm)
        {
            this.MainForm = MainForm;
            InitializeComponent();
            ChangeLanguageuage();
        }
        /// <summary>
        /// Changes the language to the current language of the MainForm.
        /// </summary>
        private void ChangeLanguageuage()
        {
            Text = MainForm.LanguageList[MainForm.SelectedLanguage][54];
            Label_Description.Text = MainForm.LanguageList[MainForm.SelectedLanguage][55];
            Button_CheckForUpdates.Text = MainForm.LanguageList[MainForm.SelectedLanguage][56];
            Button_Back.Text = MainForm.LanguageList[MainForm.SelectedLanguage][57];
            Label_Author.Text = MainForm.LanguageList[MainForm.SelectedLanguage][58];
        }
        /// <summary>
        /// Shows the Form_Update Dialog after pressing this button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_CheckForUpdates_Click(object _sender, EventArgs _e) // "update"-button
        {
            Form_Updates _f4 = new Form_Updates(MainForm);
            _f4.Show();
            _f4.CheckForUpdates();
        }
        /// <summary>
        /// Closes this Form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Back_Click(object _sender, EventArgs _e) // "back"-button
        {
            Close();
        }
    }
}
