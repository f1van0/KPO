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
        private Plugin activePlugin = null;
        private PluginFunction activeFunc = null;

        private List<Plugin> LoadPlugins()
        {
            List<Plugin> allPlugins = new List<Plugin>();
            string[] files = Directory.GetFiles("Plugins\\", "*.dll");

            foreach(var elem in files)
            {
                Plugin currentPlugin = new Plugin().VerifyPlugin(elem);
                if (currentPlugin != null)
                    allPlugins.Add(currentPlugin);
            }

            return allPlugins;
        }
        
        public Form1()
        {
            InitializeComponent();
            _plugins = LoadPlugins();
            CreateButtons();
        }

        public void CreateButtons()
        {
            foreach(var plugin in _plugins)
            {
                foreach(var func in plugin.Funcs)
                {
                    Button newButton = new Button();
                    newButton.Name = func.Name;
                    newButton.Text = func.Name;
                    newButton.Size = new Size(180, 40);
                    ModulePanel.Controls.Add(newButton);
                }
            }
        }

        public void SetActivePlugin(object sender, EventArgs e)
        {
            Button sendButton = (Button)sender;
            Plugin plugin = _plugins.Find
                (x => x.GetFuncsName().Contains(sendButton.Name));

            if (plugin != null)
            {
                activePlugin = plugin;
                PluginFunction func = plugin.Funcs.Find(x => x.Name.Contains(sendButton.Name));
                if (func != null)
                {
                    activeFunc = func;
                    BuildOptions(func.optionControls);
                }
            }
        }

        private void BuildOptions(List<Control> optionsControls)
        {
            foreach (var control in optionsControls)
            {
                OptionsPanel.Controls.Add(control);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (activePlugin != null && activeFunc != null)
            {
                //activePlugin.ApplyFunction(activeFunc.Name, ...);
            }
        }

        private void OptionsPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
