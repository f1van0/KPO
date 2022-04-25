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
        private int _id;

        //Stack<Bitmap>
        private List<Bitmap> _processedImages;
        private PluginLoader _pluginLoader;

        public int CurrentStep;
        public int MaxSteps;
        public bool IsProcessing;

        public delegate void SelectImageHandler(ImageItem imageItem);
        public event SelectImageHandler SelectImage;

        public delegate void UpdateSelectedImageHandler();
        public event UpdateSelectedImageHandler UpdateSelectedImage;

        public Bitmap GetCurrentImage {
            get
            {
                if (_processedImages != null && _processedImages.Count > 0)
                    return _processedImages[CurrentStep];
                else
                    return new Bitmap(1, 1);
            }
        }
        public Bitmap GetSourceImage { get => _processedImages[0]; }

        public ImageItem()
        {
            InitializeComponent();
        }

        public ImageItem(string path, int id, PluginLoader pluginLoader)
        {
            InitializeComponent();
            _fileName = GetFileName(path);
            imageName.Text = $"[{_id}] {_fileName}";

            _id = id;

            _processedImages = new List<Bitmap>();
            Bitmap sourceImage = (Bitmap)Image.FromFile(path);
            _processedImages.Add(sourceImage);

            _pluginLoader = pluginLoader;

            imagePictureBox.Image = GetCurrentImage;
        }

        public void GetProcessedImage(Bitmap processedImage)
        {
            _processedImages.Add(processedImage);
            CurrentStep++;
        }

        public void UndoStep()
        {
            if (CurrentStep <= 0)
                return;

            CurrentStep--;
            UpdateImage();
        }

        public void RedoStep()
        {
            if (CurrentStep >= MaxSteps)
                return;
            
            CurrentStep++;
            UpdateImage();
        }

        public void UpdateImage()
        {
            imagePictureBox?.Invoke((Action)delegate () { imagePictureBox.Image = GetCurrentImage; });

            if (UpdateSelectedImage != null)
                UpdateSelectedImage.Invoke();

            IsProcessing = false;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            //_processedImages[_currentStep] = new Bitmap(1, 1);
            //UpdateSelectedImage.Invoke();
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

        public async Task ApplyFilters()
        {
            if (_pluginLoader.ImageFiltersPlugins.Count == 0)
                return;

            ResetImages();

            foreach (var plugin in _pluginLoader.ImageFiltersPlugins)
            {
                if (plugin.IsActive)
                    GetProcessedImage(plugin.Filter.Apply(GetCurrentImage));
            }

            MaxSteps = CurrentStep;

            UpdateImage();
            return;
        }

        public void ResetImages()
        {
            IsProcessing = true;
            Bitmap sourceImage = GetSourceImage;
            _processedImages.Clear();
            _processedImages.Add(sourceImage);
            CurrentStep = 0;
        }

        public void Save(string path)
        {
            GetCurrentImage.Save(path + '\\' + Name+ ".jpg");
        }

        public void Save(string path, string name)
        {
            GetCurrentImage.Save(path + '\\' + name + ".jpg");
        }
    }
}
