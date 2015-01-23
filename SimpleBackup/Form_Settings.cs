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
using SchwabenCode.QuickIO;

namespace SimpleBackup
{
    public partial class Form_Settings : Form
    {
        int SelectedLanguage;
        Form_MainForm MainForm;
        public List<string> SettingReadings = new List<string>(); // saves read data

        // INITIALIZING STUFF
        /// <summary>
        /// Initializes the setting menu.
        /// </summary>
        /// <param name="_form">The reference to the main Form.</param>
        public Form_Settings(Form_MainForm _form)
        {
            SelectedLanguage = _form.SelectedLanguage;
            this.MainForm = _form;
            InitializeComponent();
            if (SelectedLanguage == 0) ChangeLanguage("Deutsch");
            else if (SelectedLanguage == 1) ChangeLanguage("English");
            SettingReadings = MainForm.SettingReadings.ToList<string>(); // not just copies the reference, but creates a new list
            foreach (string _str in SettingReadings)
            {
                if (_str == string.Empty) continue;
                string[] _t = _str.Split('?'); // Add only paths to the listbox
                ListBox_SavedSettings.Items.Add(_t[0] + "  ==>>  " + _t[1]);
            }
            TextBox_SourcePath.Text = MainForm.TextBox_SourcePath.Text;
            TextBox_DestinationPath.Text = MainForm.TextBox_DestinationPath.Text;
        }
        /// <summary>
        /// Changes the global language to _language.
        /// </summary>
        /// <param name="_language">New language.</param>
        private void ChangeLanguage(string _language)
        {
            MainForm.ChangeLanguage(_language);
            ChangeLanguage();
        }
        /// <summary>
        /// Changes the language to _language and reloads the label of every control.
        /// </summary>
        /// <param name="_language">The new language as string. Avalaible languages: "Deutsch" and "English".</param>
        private void ChangeLanguage()//string _language)
        {
            ComboBox_Language.Text = MainForm.LanguageList[MainForm.SelectedLanguage][0];
            //Label
            Label_ChooseLanguage.Text = MainForm.LanguageList[MainForm.SelectedLanguage][61];
            Label_ListOfSettings.Text = MainForm.LanguageList[MainForm.SelectedLanguage][65];
            // Button
            Button_Save.Text = MainForm.LanguageList[MainForm.SelectedLanguage][63];
            Button_Cancel.Text = MainForm.LanguageList[MainForm.SelectedLanguage][64];
            Button_DeleteSetting.Text = MainForm.LanguageList[MainForm.SelectedLanguage][67];
            Button_NewSetting.Text = MainForm.LanguageList[MainForm.SelectedLanguage][53];
            Button_ApplySetting.Text = MainForm.LanguageList[MainForm.SelectedLanguage][66];
            Button_ResetSettings.Text = MainForm.LanguageList[MainForm.SelectedLanguage][62];
            Button_CreateSettingsBackup.Text = MainForm.LanguageList[MainForm.SelectedLanguage][71];
            // tabs
            TabPage_SavedSettings.Text = MainForm.LanguageList[MainForm.SelectedLanguage][60]; // saved settings
            TabPage_Language.Text = MainForm.LanguageList[MainForm.SelectedLanguage][59]; // general settings
            //window
            this.Text = MainForm.LanguageList[MainForm.SelectedLanguage][70];
        }

        // EVENTS
        /// <summary>
        /// Closes the Form when the cancel-button has been pressed.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_Cancel_Click(object _sender, EventArgs _e)
        {
            this.Close();
        }
        /// <summary>
        /// Saves the current settings to the main form.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_Save_Click(object _sender, EventArgs _e)
        {
            MainForm.SelectedLanguage = SelectedLanguage;
            MainForm.SettingReadings = SettingReadings;
            MainForm.ReloadSettingsListBoxEntries(MainForm.ListBox_ListOfSettings, SettingReadings);

            if (ListBox_SavedSettings.SelectedIndex != -1)
            {
                string[] _t = SettingReadings[ListBox_SavedSettings.SelectedIndex].Split('?');
                TextBox_SourcePath.Text = _t[0];
                TextBox_DestinationPath.Text = _t[1];
                MainForm.RadioButton_OverwriteIfNewer.Checked = Convert.ToBoolean(_t[2]);
                MainForm.RadioButton_CopyAll.Checked = Convert.ToBoolean(_t[3]);
                MainForm.CheckBox_DeleteOldFiles.Checked = Convert.ToBoolean(_t[4]);
                SelectedLanguage = Convert.ToInt32(_t[5]);
                if (_t[5] == "0") ChangeLanguage("Deutsch");
                if (_t[5] == "1") ChangeLanguage("English");
                MainForm.CheckBox_ShutDown.Checked = Convert.ToBoolean(_t[6]);
            }

            Close();
        }

        // TAB1: GENERAL SETTINGS
        /// <summary>
        /// Changes the current language and sets it via ChangeLanguage().
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void ComboBox_Language_SelectedIndexChanged(object _sender, EventArgs _e)
        {
            if (ComboBox_Language.SelectedIndex == 1) ChangeLanguage("Deutsch");
            else if (ComboBox_Language.SelectedIndex == 0) ChangeLanguage("English");
        }
        /// <summary>
        /// Copies the current settings file (some.settings) to some.more... .settings.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_CreateSettingsBackup_Click(object _sender, EventArgs _e)
        {
            int _i;
            for (_i = 0; QuickIOFile.Exists("some.settings.backup" + _i.ToString()); _i++) { }
            QuickIOFile.Copy("some.settings", "some.settings.backup" + _i.ToString());

            // old version:
            //string str = "more.";
            //while (QuickIOFile.Exists("some." + str + "settings"))
            //{
            //    str += "more.";
            //}
            //QuickIOFile.Copy("some.settings", "some." + str + "settings");
        }
        /// <summary>
        /// Shows info message for the backup-button.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_CreateSettingsBackup_MouseHover(object _sender, EventArgs _e)
        {
            ToolTip_Info.Show(MainForm.LanguageList[MainForm.SelectedLanguage][69], Button_CreateSettingsBackup);
        }
        /// <summary>
        /// Resets the settings to the default values (language=english, no path-settings).
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_ResetSettings_Click(object _sender, EventArgs _e)
        {
            SelectedLanguage = 1;
            SettingReadings.Clear();
            ListBox_SavedSettings.Items.Clear();
            TextBox_SourcePath.Text = String.Empty;
            TextBox_DestinationPath.Text = String.Empty;
            MainForm.RadioButton_OverwriteIfNewer.Checked = true;
            MainForm.RadioButton_CopyAll.Checked = false;
            MainForm.CheckBox_DeleteOldFiles.Checked = false;
            SelectedLanguage = 1;
            ChangeLanguage("English");
            MainForm.CheckBox_ShutDown.Checked = false;
        }

        // TAB2: SAVED SETTINGS
        /// <summary>
        /// Shows a info tooltip for the "new" button.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_NewSetting_MouseHover(object _sender, EventArgs _e)
        {
            ToolTip_Info.Show(MainForm.LanguageList[MainForm.SelectedLanguage][68], Button_NewSetting);
        }
        /// <summary>
        /// Shows path in text boxes when user clicked on an entry in the list of settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SavedSettings_SelectedIndexChanged(object _sender, EventArgs _e) // when user choosed a list entry
        {
            if (ListBox_SavedSettings.SelectedIndex == -1
                || SettingReadings[ListBox_SavedSettings.SelectedIndex] == null
                || SettingReadings[ListBox_SavedSettings.SelectedIndex] == string.Empty) return; // if index is invalid, the entry is null or empty
            string[] _t = SettingReadings[ListBox_SavedSettings.SelectedIndex].Split('?');
            TextBox_SourcePath.Text = _t[0];
            TextBox_DestinationPath.Text = _t[1];
            SelectedLanguage = Convert.ToInt32(_t[5]);
            if (_t[5] == "0") ChangeLanguage("Deutsch");
            if (_t[5] == "1") ChangeLanguage("English");
        }
        /// <summary>
        /// Saves the settings to the MainForm.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_ApplySetting_Click(object _sender, EventArgs _e) // ok-button clicked
        {
            string[] _t = SettingReadings[ListBox_SavedSettings.SelectedIndex].Split('?');
            int _i = ListBox_SavedSettings.SelectedIndex;

            SettingReadings[ListBox_SavedSettings.SelectedIndex] = TextBox_SourcePath.Text + "?"
                 + TextBox_DestinationPath.Text + "?"
                 + MainForm.RadioButton_OverwriteIfNewer.Checked + "?"
                 + MainForm.RadioButton_CopyAll.Checked + "?"
                 + MainForm.CheckBox_DeleteOldFiles.Checked + "?"
                 + SelectedLanguage + "?"
                 + MainForm.CheckBox_ShutDown.Checked;
            ListBox_SavedSettings.SelectedIndex = _i;
        }
        /// <summary>
        /// Creates a new entry in the settings list.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_NewSetting_Click(object _sender, EventArgs _e) // new-button clicked
        {
            string _newEntry = TextBox_SourcePath.Text + "?"
                + TextBox_DestinationPath.Text + "?"
                + MainForm.RadioButton_OverwriteIfNewer.Checked + "?"
                + MainForm.RadioButton_CopyAll.Checked + "?"
                + MainForm.CheckBox_DeleteOldFiles.Checked + "?"
                + SelectedLanguage + "?"
                + MainForm.CheckBox_ShutDown.Checked;
            

            ListBox_SavedSettings.Items.Add(TextBox_SourcePath.Text + "  ==>>  " + TextBox_DestinationPath.Text);
            SettingReadings.Add(_newEntry);
            TextBox_DestinationPath.Text = String.Empty;
            TextBox_SourcePath.Text = String.Empty;
        }
        /// <summary>
        /// Deletes an entry from the list of settings.
        /// </summary>
        /// <param name="_sender"></param>
        /// <param name="_e"></param>
        private void Button_DeleteSetting_Click(object _sender, EventArgs _e) // delete-button clicked
        {
            if (ListBox_SavedSettings.SelectedItem == null) return;
            SettingReadings[ListBox_SavedSettings.SelectedIndex] = string.Empty;
            int _selectedIndex = ListBox_SavedSettings.SelectedIndex;
            ListBox_SavedSettings.Items.RemoveAt(_selectedIndex);
            TextBox_SourcePath.Text = String.Empty;
            TextBox_DestinationPath.Text = String.Empty;
        }
    }
}