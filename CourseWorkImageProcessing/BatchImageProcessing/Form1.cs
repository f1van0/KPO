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

        private int _currentStep;
        private int _maxSteps;

        public Form1()
        {
            InitializeComponent();
            _foldersManager = new PluginFoldersManager();
            _pluginLoader = new PluginLoader(_foldersManager);
            UpdateUndoRedoButtons();
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
            foreach (var item in uploadImagesList.Controls)
            {
                ((ImageItem)item).UpdateSelectedImage -= UpdateSelected;
            }

            _selectedImageItem = imageItem;
            pictureBox1.Image = _selectedImageItem.GetCurrentImage;
            imageItem.UpdateSelectedImage += UpdateSelected;
        }

        public void UpdateSelected()
        {
            _maxSteps = _selectedImageItem.MaxSteps;
            _currentStep = _maxSteps;
            pictureBox1.Image = _selectedImageItem.GetCurrentImage;
            UpdateUndoRedoButtons();
        }

        private void ProcessImagesButton_Click(object sender, EventArgs e)
        {
            foreach(var item in uploadImagesList.Controls)
            {
                Task.Factory.StartNew(((ImageItem)item).ApplyFilters);
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

        private void UpdateUndoRedoButtons()
        {
            UpdateAvailabilityOfUndoButton();
            UpdateAvailabilityOfRedoButton();
        }

        private void UpdateAvailabilityOfUndoButton()
        {
            if (_currentStep <= 0)
                SetUndoAvailability(false);
            else if (_currentStep <= _maxSteps)
                SetUndoAvailability(true);
        }

        private void UpdateAvailabilityOfRedoButton()
        {
            if (_currentStep >= _maxSteps)
                SetRedoAvailability(false);
            else
                SetRedoAvailability(true);
        }

        private void SetUndoAvailability(bool isAvailable)
        {
            отменитьДействиеToolStripMenuItem.Enabled = isAvailable;
            UndoButton.Enabled = isAvailable;
        }

        private void SetRedoAvailability(bool isAvailable)
        {
            повторитьДействиеToolStripMenuItem.Enabled = isAvailable;
            RedoButton.Enabled = isAvailable;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            foreach (var item in uploadImagesList.Controls)
            {
                ((ImageItem)item).UndoStep();
            }
            _currentStep--;

            UpdateUndoRedoButtons();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            foreach (var item in uploadImagesList.Controls)
            {
                ((ImageItem)item).RedoStep();
            }
            _currentStep++;

            UpdateUndoRedoButtons();
        }
    }
}
