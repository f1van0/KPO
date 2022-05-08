using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DL;

namespace BatchImageProcessing
{
    public partial class FilterOptionsForm : Form
    {
        public FilterPlugin Plugin { get; set; }

        public FilterOptionsForm(FilterPlugin plugin)
        {
            InitializeComponent();
            Plugin = plugin;
            ShowOptions();
        }

        private void ShowOptions()
        {
            FilterNameLabel.Text = "Название фильтра: " + Plugin.Filter.Name;
            VersionLabel.Text = "Версия: " + Plugin.Filter.Version;
            AuthorLabel.Text = "Автор: " + Plugin.Filter.Author;

            ShowSettings();
        }

        private void ShowSettings()
        {
            OptionsPanel.Controls.Clear();
            SettingsVariable[] optionsVariables = Plugin.Filter.Settings.SettingsVariables;
            OptionsControl[] optionsControls = new OptionsControl[optionsVariables.Length];
            for (int i = 0; i < optionsVariables.Length; i++)
            {
                optionsControls[i] = new OptionsControl(optionsVariables[i]);
                OptionsPanel.Controls.Add(optionsControls[i]);
            }
        }

        private void FilterOptionsForm_Load(object sender, EventArgs e)
        {

        }

        private void FilterOptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            int[] newValues = new int[OptionsPanel.Controls.Count];
            for (int i = 0; i < OptionsPanel.Controls.Count; i++)
            {
                newValues[i] = ((OptionsControl)OptionsPanel.Controls[i]).GetValue();
            }
            Plugin.Filter.Settings.UpdateSettings(newValues);

            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Plugin.Filter.Settings.ResetToDefault();
            ShowSettings();
        }
    }
}
