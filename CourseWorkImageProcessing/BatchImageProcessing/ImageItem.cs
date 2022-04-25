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
        private int _currentStep;

        //Stack<Bitmap>
        private List<Bitmap> _processedImages;
        private PluginLoader _pluginLoader;

        public delegate void SelectImageHandler(ImageItem imageItem);
        public event SelectImageHandler SelectImage;

        public delegate void UpdateSelectedImageHandler();
        public event UpdateSelectedImageHandler UpdateSelectedImage;

        public Bitmap GetCurrentImage {
            get
            {
                if (_processedImages != null && _processedImages.Count > 0)
                    return _processedImages[_currentStep];
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
            _currentStep++;
        }

        public Bitmap UndoStep()
        {
            _currentStep--;
            return _processedImages[_currentStep];
        }

        public Bitmap RedoStep()
        {
            _currentStep++;
            return _processedImages[_currentStep];
        }

        public void UpdateImage()
        {
            imagePictureBox.Image = GetCurrentImage;
            //UpdateSelectedImage.Invoke();
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
            SelectImage.Invoke(this);
        }

        public void ApplyFilters()
        {
            if (_pluginLoader.ImageFiltersPlugins.Count == 0)
                return;

            ResetImages();

            foreach (var plugin in _pluginLoader.ImageFiltersPlugins)
            {
                if (plugin.IsActive)
                    GetProcessedImage(plugin.Filter.Apply(GetCurrentImage));
            }

            UpdateImage();
        }

        public void ResetImages()
        {
            Bitmap sourceImage = GetSourceImage;
            _processedImages.Clear();
            _processedImages.Add(sourceImage);
            _currentStep = 0;
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
