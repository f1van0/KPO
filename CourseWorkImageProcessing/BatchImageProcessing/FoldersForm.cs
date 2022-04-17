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
    public partial class FoldersForm : Form
    {
        private PluginFoldersManager _pluginFoldersManager;

        public FoldersForm(PluginFoldersManager pluginFoldersManager)
        {
            InitializeComponent();
            _pluginFoldersManager = pluginFoldersManager;
            ShowFoldersList();
        }

        private void ShowFoldersList()
        {
            foldersList.Items.Clear();
            foldersList.Items.AddRange(_pluginFoldersManager.ActiveFolders.ToArray());
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                _pluginFoldersManager.AddFolder(folderBrowserDialog.SelectedPath);
                ShowFoldersList();
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            _pluginFoldersManager.RemoveFolder((string)foldersList.SelectedItem);
            ShowFoldersList();
        }

        private void FoldersForm_Load(object sender, EventArgs e)
        {

        }

        private void FoldersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
