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
            if (exportNameTextBox.Text == "")
            {
                MessageBox.Show("Некорректно выбрано название для сохраняемых изображений");
            }
            else
            {
                string fileName;
                string exportName = exportNameTextBox.Text;
                int iter = 1;
                foreach(var item in _imageItems)
                {
                    fileName = exportName;
                    fileName = fileName.Replace("%Name%", item.GetImageName());
                    fileName = fileName.Replace("%Number%", iter.ToString());
                    fileName = fileName.Replace("%Date%", DateTime.Now.ToString());

                    item.Save(path, fileName);

                    iter++;
                }

                MessageBox.Show("Изображения успешно сохранены");
                Close();
            }
        }

        private void ChangeDirectoryButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog()== DialogResult.OK)
            {
                PathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void ExportImagesForm_Load(object sender, EventArgs e)
        {

        }

        private void imageNameButton_Click(object sender, EventArgs e)
        {
            exportNameTextBox.Text += "%Name%";
        }

        private void orderNumberButton_Click(object sender, EventArgs e)
        {
            exportNameTextBox.Text += "%Number%";
        }

        private void exportDateButton_Click(object sender, EventArgs e)
        {
            exportNameTextBox.Text += "%Date%";
        }
    }
}
