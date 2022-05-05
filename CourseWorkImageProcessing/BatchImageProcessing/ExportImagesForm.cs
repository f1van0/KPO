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

namespace BatchImageProcessing
{
    public partial class ExportImagesForm : Form
    {
        private ImageItem[] _imageItems;

        public ExportImagesForm()
        {
            InitializeComponent();
        }

        public ExportImagesForm(ImageItem[] imageItems)
        {
            InitializeComponent();
            PathTextBox.Text = Directory.GetCurrentDirectory();
            _imageItems = imageItems;
            amountOfExportingImagesLabel.Text = $"Количество выгружаемых изображений: {_imageItems.Length}";
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            string path = PathTextBox.Text;
            if (radioButton1.Checked)
            {
                foreach(var item in _imageItems)
                    item.Save(path);
            }
            else if (radioButton2.Checked)
            {
                int iter = 1;
                foreach (var item in _imageItems)
                {
                    item.Save(path, iter, false);
                    iter++;
                }
            }
            else if (radioButton3.Checked)
            {
                int iter = 1;
                foreach (var item in _imageItems)
                {
                    item.Save(path, iter, true);
                    iter++;
                }
            }
            else if (radioButton4.Checked)
            {
                foreach (var item in _imageItems)
                {
                    item.Save(path, substringTextBox.Text);
                }
            }
            else if (radioButton5.Checked)
            {
                int iter = 1;
                foreach (var item in _imageItems)
                {
                    item.Save(path, iter, substringTextBox.Text, false);
                    iter++;
                }
            }
            else if (radioButton6.Checked)
            {
                int iter = 1;
                foreach (var item in _imageItems)
                {
                    item.Save(path, iter, substringTextBox.Text, true);
                    iter++;
                }
            }

            Close();
        }

        private void ChangeDirectoryButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog()== DialogResult.OK)
            {
                PathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
