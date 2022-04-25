using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DL;

namespace BatchImageProcessing
{
    public partial class Form1 : Form
    {
        private PluginFoldersManager _foldersManager;
        private PluginLoader _pluginLoader;
        private ImageItem _selectedImageItem;

        public Form1()
        {
            InitializeComponent();
            _foldersManager = new PluginFoldersManager();
            _pluginLoader = new PluginLoader(_foldersManager);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void UploadImagesButton_Click(object sender, EventArgs e)
        {
            UploadImages();
        }

        private void отрытьИзображенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadImages();
        }

        public void UploadImages()
        {
            openImagesDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            openImagesDialog.InitialDirectory = Directory.GetCurrentDirectory();
            openImagesDialog.Title = "Выберите изображежния для загрузки";
            openImagesDialog.Multiselect = true;

            if (openImagesDialog.ShowDialog() == DialogResult.OK)
            {
                UploadImagesButton.Hide();
                string[] selectedImages = openImagesDialog.FileNames;
                for (int i = 0; i < selectedImages.Length; i++)
                {
                    ImageItem newImageItem = new ImageItem(selectedImages[i], i, _pluginLoader);
                    newImageItem.SelectImage += ImageSelected;
                    uploadImagesList.Controls.Add(newImageItem);
                }

                if (uploadImagesList.Controls.Count > 0)
                {
                    ImageSelected((ImageItem)uploadImagesList.Controls[0]);
                }

                numberOfUploadedImagesLabel.Text = "Загружено изображений: " + uploadImagesList.Controls.Count;
            }
        }

        public void ImageSelected(ImageItem imageItem)
        {
            _selectedImageItem = imageItem;
            pictureBox1.Image = _selectedImageItem.GetCurrentImage;
            imageItem.UpdateSelectedImage += UpdateSelected;
        }

        public void UpdateSelected()
        {
            pictureBox1.Image = _selectedImageItem.GetCurrentImage;
        }

        private void ProcessImagesButton_Click(object sender, EventArgs e)
        {
            foreach(var item in uploadImagesList.Controls)
            {
                ((ImageItem)item).ApplyFilters();
            }
        }

        private void ФильрыStripMenuItem_Click(object sender, EventArgs e)
        {
            FiltersForm filtersForm = new FiltersForm(_pluginLoader);
            filtersForm.ShowDialog();
        }

        private void ПапкиСПлагаминамиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FoldersForm foldersForm = new FoldersForm(_foldersManager);
            if (foldersForm.ShowDialog() == DialogResult.OK)
            {
                _pluginLoader.LoadPlugins();
            }
        }

        private void сохранитьИзображенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImageItem[] imageItems = new ImageItem[uploadImagesList.Controls.Count];
            for (int i = 0; i < uploadImagesList.Controls.Count; i++)
            {
                imageItems[i] = (ImageItem)uploadImagesList.Controls[i];
            }
            ExportImagesForm exportImagesForm = new ExportImagesForm(imageItems);
            exportImagesForm.ShowDialog();
        }
    }
}
