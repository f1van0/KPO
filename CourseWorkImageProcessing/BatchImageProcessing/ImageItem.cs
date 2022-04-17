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

        private List<IFilterDynamicLibrary> _plugins;

        public delegate void SelectImageHandler(ImageItem imageItem);
        public event SelectImageHandler OnSelectImage;

        public Bitmap GetCurrentImage { get => _processedImages[_currentStep]; }
        public Bitmap GetSourceImage { get => _processedImages[0]; }

        public ImageItem()
        {
            InitializeComponent();
        }

        public ImageItem(string path, int id, List<IFilterDynamicLibrary> plugins)
        {
            InitializeComponent();
            _fileName = GetFileName(path);
            imageName.Text = $"[{_id}] {_fileName}";

            _id = id;

            _processedImages = new List<Bitmap>();
            Bitmap sourceImage = (Bitmap)Image.FromFile(path);
            _processedImages.Add(sourceImage);

            _plugins = plugins;

            UpdateImage();
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
            OnSelectImage.Invoke(this);
        }

        public void ApplyFilters()
        {
            if (_plugins.Count == 0)
                return;

            foreach (var plugin in _plugins)
            {
                _processedImages.Add(plugin.Apply(GetCurrentImage));
                _currentStep++;
            }

            UpdateImage();
        }
    }
}
