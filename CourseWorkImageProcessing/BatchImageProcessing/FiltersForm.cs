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
    public partial class FiltersForm : Form
    {
        public FiltersForm()
        {
            InitializeComponent();
        }

        private PluginLoader _pluginLoader;

        public FiltersForm(PluginLoader pluginLoader)
        {
            InitializeComponent();
            _pluginLoader = pluginLoader;
            ShowPlugins();
        }

        private void ShowPlugins()
        {
            FiltersRadioButtonList.Items.Clear();
            foreach(var plugin in _pluginLoader.ImageFiltersPlugins)
            {
                FiltersRadioButtonList.Items.Add(plugin, plugin.IsActive);
            }

            FiltersRadioButtonList.CheckOnClick = false;
        }

        private void FiltersForm_Load(object sender, EventArgs e)
        {

        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = FiltersRadioButtonList.SelectedIndex;
            if (selectedIndex <= 0)
                return;

            Exchange(selectedIndex, -1);
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = FiltersRadioButtonList.SelectedIndex;
            if (selectedIndex == -1 || selectedIndex >= FiltersRadioButtonList.Items.Count - 1)
                return;

            Exchange(selectedIndex, 1);
        }

        private void Exchange(int index, int direction)
        {
            object exchangedItem = FiltersRadioButtonList.Items[index];
            CheckState exchangedItemState = FiltersRadioButtonList.GetItemCheckState(index);
            FiltersRadioButtonList.Items[index] = FiltersRadioButtonList.Items[index + direction];
            FiltersRadioButtonList.SetItemCheckState(index, FiltersRadioButtonList.GetItemCheckState(index + direction));
            FiltersRadioButtonList.Items[index + direction] = exchangedItem;
            FiltersRadioButtonList.SetItemCheckState(index + direction, exchangedItemState);
            FiltersRadioButtonList.SelectedIndex += direction;
        }

        private void FiltersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pluginLoader.ImageFiltersPlugins.Clear();
            for (int i = 0; i < FiltersRadioButtonList.Items.Count; i++)
            {
                FilterPlugin plugin = (FilterPlugin)FiltersRadioButtonList.Items[i];
                plugin.IsActive = (FiltersRadioButtonList.GetItemCheckState(i) == CheckState.Checked);
                _pluginLoader.ImageFiltersPlugins.Add(plugin);
            }
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = FiltersRadioButtonList.SelectedIndex;
            if (selectedIndex == -1)
                return;

            FilterPlugin plugin = (FilterPlugin)FiltersRadioButtonList.Items[selectedIndex];
            FilterOptionsForm filterOptions = new FilterOptionsForm(plugin);
            
            if (filterOptions.ShowDialog() == DialogResult.OK)
                FiltersRadioButtonList.Items[selectedIndex] = filterOptions.Plugin;
        }
    }
}
