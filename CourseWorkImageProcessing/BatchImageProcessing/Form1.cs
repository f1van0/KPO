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
        private List<ImageItem> _imageItems;

        private Task _processingTask;

        private int _currentStep;
        private int _maxSteps;

        private int _processedImagesCounter;

        public Form1()
        {
            InitializeComponent();
            _imageItems = new List<ImageItem>();
            _foldersManager = new PluginFoldersManager();
            _pluginLoader = new PluginLoader(_foldersManager);
            ResetStep();
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
                    ImageItem newImageItem = new ImageItem(selectedImages[i]);
                    newImageItem.SelectImage += ImageSelected;
                    newImageItem.ProcessedImage += ImageProcessed;
                    imagesList.Controls.Add(newImageItem);
                }

                if (imagesList.Controls.Count > 0)
                {
                    ImageSelected((ImageItem)imagesList.Controls[0]);
                }

                numberOfUploadedImagesLabel.Text = "Загружено изображений: " + imagesList.Controls.Count;
                processedImagesCounterLabel.Text = $"Обработано изображений 0/{imagesList.Controls.Count}";
            }
        }

        public void ImageSelected(ImageItem imageItem)
        {
            _selectedImageItem = imageItem;
            pictureBox1.Image = imageItem.ProcessedImages.GetImageInStep(_currentStep).Image;
        }

        public void ImageProcessed()
        {
            _processedImagesCounter++;
            processedImagesCounterLabel.Text = $"Обработано изображений {_processedImagesCounter}/{imagesList.Controls.Count}";
            if (_processedImagesCounter == imagesList.Controls.Count)
                FinishProcess();
        }

        private async void ProcessImagesButton_Click(object sender, EventArgs e)
        {
            numberOfUploadedImagesLabel.Text = "Загружено изображений: " + imagesList.Controls.Count;
            _processedImagesCounter = 0;
            ProcessImagesButton.Enabled = false;
            ResetStep();
            FilterPlugin[] activeFilters = _pluginLoader.GetActiveFilters();
            _maxSteps = activeFilters.Length;
            ParallelFilteringItems.ImageItems = GetImageItems();
            ParallelFilteringItems.Filters = activeFilters;
            _processingTask = Task.Factory.StartNew(ParallelFilteringItems.ProcessImages, TaskCreationOptions.LongRunning);
        }

        private void FinishProcess()
        {
            ParallelFilteringItems.IsCompleted();
            _currentStep = _maxSteps;
            ProcessImagesButton.Enabled = true;
            UpdateStep();
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
            ImageItem[] imageItems = new ImageItem[imagesList.Controls.Count];
            for (int i = 0; i < imagesList.Controls.Count; i++)
            {
                imageItems[i] = (ImageItem)imagesList.Controls[i];
            }
            ExportImagesForm exportImagesForm = new ExportImagesForm(imageItems);
            exportImagesForm.ShowDialog();
        }

        private void UpdateStep()
        {
            pictureBox1.Image = _selectedImageItem.ProcessedImages.GetImageInStep(_currentStep).Image;
            SetStep();
            UpdateAvailabilityOfUndoButton();
            UpdateAvailabilityOfRedoButton();
        }

        private void ResetStep()
        {
            _currentStep = 0;
            //SetStep();
            SetUndoAvailability(false);
            SetRedoAvailability(false);
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
            _currentStep--;
            UpdateStep();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            _currentStep++;
            UpdateStep();
        }

        private void SetStep()
        {
            var imageItems = GetImageItems();
            foreach (var item in imageItems)
            {
                item.SetImageInStep(_currentStep);
            }
        }

        private ImageItem[] GetImageItems()
        {
            ImageItem[] imageItems = new ImageItem[imagesList.Controls.Count];

            for (int i = 0; i < imagesList.Controls.Count; i++)
            {
                imageItems[i] = (ImageItem)imagesList.Controls[i];
            }

            return imageItems;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
