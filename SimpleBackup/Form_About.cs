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
            InitializeLanguageuage();
            ChangeLanguageuage();
        }
        /// <summary>
        /// Loads the language content to the Language array.
        /// </summary>
        private void InitializeLanguageuage()
        {
            int _i = 0;
            Language[_i, 0] = "Über SimpleBackup";
            Language[_i, 1] = "SimpleBackup ist ein Open-Source Backup Tool.\nEs soll dazu dienen einfach und schnell simpel\nBackup zu erstellen, wobei auf \nkomplizierten \nund teils unnötigen \"Schnick Schnack\" \nverzichtet wird.";
            Language[_i, 2] = "Auf Updates prüfen";
            Language[_i, 3] = "Zurück";
            Language[_i, 4] = "von Hauke L. Stieler";

            _i = 1;
            Language[_i, 0] = "About SimpleBackup";
            Language[_i, 1] = "SimpleBackup is a open source backup tool.\nIt's intended to create quickly and easily a backup\nin which unnecessary paraphernalia is left off.";//"SimpleBackup ist ein Open-Source Backup Tool.\nEs soll dazu dienen einfach und schnell simple\nBackup zu erstellen, wobei auf \nomplizierten \nund teils unnötigen \"Schnick Schnack\" \nverzichtet wird.";
            Language[_i, 2] = "check for updates";
            Language[_i, 3] = "back";
            Language[_i, 4] = "by Hauke L. Stieler";
        }
        /// <summary>
        /// Changes the language to the current language of the MainForm.
        /// </summary>
        private void ChangeLanguageuage()
        {
            Text = Language[MainForm.SelectedLanguage, 0];
            Label_Author.Text = Language[MainForm.SelectedLanguage, 4];
            Label_Description.Text = Language[MainForm.SelectedLanguage, 1];
            Button_CheckForUpdates.Text = Language[MainForm.SelectedLanguage, 2];
            Button_Back.Text = Language[MainForm.SelectedLanguage, 3];
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
