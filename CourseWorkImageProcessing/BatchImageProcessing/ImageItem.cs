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
        public event SelectImageHandler OnSelectImage;
        public event SelectImageHandler OnDeleteImage;

        public delegate void UpdateImageHandler();
        public event UpdateImageHandler OnProcessedImage;

        public bool IsProcessing;
        public FilterPlugin[] FilterPlugins;

        private int _appliedFiltersAmount;
        private string _imageResolution;
        private int _processingTime;

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

            _imageResolution = $"{sourceImage.Width}x{sourceImage.Height}";
            _appliedFiltersAmount = 0;
            _processingTime = 0;
            InsertImage(0, _fileName);
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
                OnProcessedImage?.Invoke();
                //processProgressBar.Visible = false;
            });
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            OnDeleteImage?.Invoke(this);
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
                OnSelectImage.Invoke(this);
        }

        public void ApplyFilters()
        {
            if (FilterPlugins.Length == 0)
                return;

            ResetImages();

            int processCompletedProcentes = 1;
            imagePictureBox?.Invoke((Action)delegate () {
                processProgressBar.Value = processCompletedProcentes;
            });
            DateTime startTime = DateTime.Now;
            for (int i = 0; i < FilterPlugins.Length; i++)
            {
                Bitmap filteredImage = FilterPlugins[i].Filter.Apply(ProcessedImages.GetResultImage.Image);
                AddProcessedImage(FilterPlugins[i].Filter.Name, filteredImage);

                processCompletedProcentes = (int)((float)(i + 1) / FilterPlugins.Length * 100);
                if (processCompletedProcentes > 100) processCompletedProcentes = 100;
                imagePictureBox?.Invoke((Action)delegate () { processProgressBar.Value = processCompletedProcentes; });
            }
            _processingTime = (int)(DateTime.Now - startTime).TotalMilliseconds;
            _appliedFiltersAmount = FilterPlugins.Length;

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

        //public void Save(string path)
        //{
        //    string savedName = path + '\\' + GetImageName() + ".jpg";
        //    ProcessedImages.GetCurrentImage.Image.Save(savedName);
        //}
        //
        //public void Save(string path, int number, bool isNameNeeded)
        //{
        //    string savedName = path + '\\' + number;
        //    if (isNameNeeded)
        //    {
        //        savedName += ' ' + GetImageName();
        //    }
        //    savedName += ".jpg";
        //    ProcessedImages.GetCurrentImage.Image.Save(savedName);
        //}

        public void Save(string path, string fileName)
        {
            ProcessedImages.GetCurrentImage.Image.Save(path + '\\' + fileName);
            Bitmap resultimage = ProcessedImages.GetCurrentImage.Image;
            _imageResolution = $"{resultimage.Width}x{resultimage.Height}";
            InsertImage(1, fileName);
        }

        //public void Save(string path, int number, string substring, bool isNameNeeded)
        //{
        //    string savedName = path + '\\' + substring + ' ' + number;
        //    if (isNameNeeded)
        //    {
        //        savedName += ' ' + GetImageName();
        //    }
        //    savedName += ".jpg";
        //    ProcessedImages.GetCurrentImage.Image.Save(savedName);
        //}

        public string GetImageName()
        {
            return _fileName.Split(".")[0];
        }

        public void InsertImage(int status, string fileName)
        {
            ImagesDB.Instance.Insert(new ImageRow(fileName, status, _imageResolution, _appliedFiltersAmount, _processingTime));
        }
    }
}
