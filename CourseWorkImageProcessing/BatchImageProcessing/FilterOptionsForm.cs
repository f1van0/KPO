using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatchImageProcessing
{
    public partial class FilterOptionsForm : Form
    {
        private FilterPlugin _plugin;

        public FilterOptionsForm(FilterPlugin plugin)
        {
            InitializeComponent();
            _plugin = plugin;
            ShowOptions();
        }

        private void ShowOptions()
        {
            FilterNameLabel.Text = "Название фильтра: " + _plugin.Filter.Name;
            FilterVersionLabel.Text = _plugin.Filter.I.ToString();
            //OptionsPanel.Controls.Clear();
            //OptionsPanel.Controls.AddRange(_plugin.Filter.GetOptions());
        }

        private void FilterOptionsForm_Load(object sender, EventArgs e)
        {

        }

        private void FilterOptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _plugin.Filter.I = (int)numericUpDown1.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
