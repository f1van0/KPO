using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DL;

namespace BatchImageProcessing
{
    public partial class ImageItem : UserControl
    {
        private string _fileName;

        public ProcessingImagesList ProcessedImages { get; private set; }

        public delegate void SelectImageHandler(ImageItem imageItem);
        public event SelectImageHandler SelectImage;

        public delegate void UpdateImageHandler();
        public event UpdateImageHandler ProcessedImage;

        public bool IsProcessing;
        public FilterPlugin[] FilterPlugins;

        public ImageItem()
        {
            InitializeComponent();
        }

        public ImageItem(string path)
        {
            InitializeComponent();

            _fileName = GetFileName(path);
            imageName.Text = _fileName;

            Bitmap sourceImage = (Bitmap)Image.FromFile(path);
            ProcessedImages = new ProcessingImagesList(sourceImage);

            imagePictureBox.Image = sourceImage;
            IsProcessing = false;
        }

        public void AddProcessedImage(string filterName, Bitmap processedImage)
        {
            ProcessedImages.Add(filterName, processedImage);
        }

        public void UpdateImage()
        {
            imagePictureBox?.Invoke((Action)delegate () {
                imagePictureBox.Image = new Bitmap(1, 1);
                IsProcessing = false;
                ProcessedImage?.Invoke();
                //processProgressBar.Visible = false;
            });
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private string GetFileName(string path)
        {
            string fileName = "";
            int startNamePosition = path.LastIndexOf('\\') + 1;
            for (int i = startNamePosition; i < path.Length; i++)
            {
                fileName += path[i];
            }

            return fileName;
        }

        private void imagePictureBox_Click(object sender, EventArgs e)
        {
            if (!IsProcessing)
                SelectImage.Invoke(this);
        }

        public void ApplyFilters()
        {
            if (FilterPlugins.Length == 0)
                return;

            ResetImages();

            int processCompletedProcentes = 1;
            imagePictureBox?.Invoke((Action)delegate () {
                //processProgressBar.Visible = true;
                processProgressBar.Value = processCompletedProcentes;
            });
            for (int i = 0; i < FilterPlugins.Length; i++)
            {
                Bitmap filteredImage = FilterPlugins[i].Filter.Apply(ProcessedImages.GetResultImage.Image);
                AddProcessedImage(FilterPlugins[i].Filter.Name, filteredImage);

                processCompletedProcentes = (int)((float)(i + 1) / FilterPlugins.Length * 100);
                if (processCompletedProcentes > 100) processCompletedProcentes = 100;
                imagePictureBox?.Invoke((Action)delegate () { processProgressBar.Value = processCompletedProcentes; });
            }
            //imagePictureBox?.Invoke((Action)delegate () { processProgressBar.Value = 100; });

            UpdateImage();
        }

        public void ResetImages()
        {
            IsProcessing = true;
            ProcessedImages.Reset();
        }

        public void SetImageInStep(int step)
        {
            imagePictureBox?.Invoke((Action)delegate () {
                imagePictureBox.Image = ProcessedImages.GetImageInStep(step).Image;
            });
        }

        public void Save(string path)
        {
            ProcessedImages.GetCurrentImage.Image.Save(path + '\\' + Name+ ".jpg");
        }

        public void Save(string path, string name)
        {
            ProcessedImages.GetCurrentImage.Image.Save(path + '\\' + name + ".jpg");
        }
    }
}
