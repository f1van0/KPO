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
            OptionsPanel.Controls.Clear();
            OptionsVariable[] optionsVariables = Plugin.Filter.Options;
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
            for (int i = 0; i < Plugin.Filter.Options.Length; i++)
            {
                Plugin.Filter.Options[i].Value = ((OptionsControl)OptionsPanel.Controls[i]).GetValue();
            }

            DialogResult = DialogResult.OK;
        }
    }
}
