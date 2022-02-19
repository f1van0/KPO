using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayConfigurator
{
    public partial class Form1 : Form
    {
        private List<Plugin> _plugins;

        public List<Plugin> LoadPlugins()
        {
            List<Plugin> _allPlugins = new List<Plugin>();
            string[] files = Directory.GetFiles("*.dll");

            foreach(var elem in files)
            {
                Plugin.
            }

            return;
        }

        public Form1()
        {
            InitializeComponent();
            _plugins = LoadPlugins();
        }

        private void BuildOptions(string cfg)
        {
            //1. Тип элемента
            //2. Подпись (у NumericUpDown автоматически создается Label с подписью, а у RadioButton, как и у Label, записывается Text)
            //3. Название .Name элемента
            //4. Отсуп Margin в виде числа
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {

        }

        private void OptionsPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
