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
    public partial class OptionsControl : UserControl
    {
        public OptionsControl()
        {
            InitializeComponent();
        }

        public OptionsControl(OptionsVariable optionsVariable)
        {
            InitializeComponent();
            VariableNameLabel.Text = optionsVariable.Name;
            NumericUpDown.Minimum = optionsVariable.Minimum;
            NumericUpDown.Maximum = optionsVariable.Maximum;
            NumericUpDown.Value = optionsVariable.Value;
        }

        public int GetValue()
        {
            return (int)NumericUpDown.Value;
        }

        private void OptionsControl_Load(object sender, EventArgs e)
        {

        }
    }
}
