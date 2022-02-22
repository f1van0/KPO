using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayConfigurator
{
    public partial class Form1 : Form
    {
        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);


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
                    newButton.Size = new Size(100, 30);
                    newButton.Click += SetActivePlugin;
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
                    OptionsPanel.Controls.Clear();
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
            long startTime, endTime, frequence;

            if (activePlugin != null && activeFunc != null)
            {
                int[] arr = ConvertText.ConvertTextToIntArray(ArrayTextBox.Text);

                QueryPerformanceFrequency(out frequence);
                QueryPerformanceCounter(out startTime);
                int[] result = activeFunc.ApplyFunction(activePlugin.Name, arr, OptionsPanel);
                QueryPerformanceCounter(out endTime);
                double time = (double)((endTime - startTime)) * 1000 / frequence;

                ArrayTextBox.Text = ConvertText.ConvertIntArrayToText(result);

                TimeLabel.Text = $"Duration time: {time} ms";
            }
        }

        private void OptionsPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }
    }
}
