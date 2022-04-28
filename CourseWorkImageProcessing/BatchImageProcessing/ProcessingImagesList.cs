using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchImageProcessing
{
    class ProcessingImagesList
    {
        private List<ImageDetails> _processedImages;

        public int CurrentStep;
        public bool IsProcessing;

        public Bitmap GetCurrentImage { get => _processedImages[CurrentStep].Image; }
        public Bitmap GetSourcetImage { get => _processedImages.Count > 0 ? _processedImages [CurrentStep].Image : new Bitmap(1, 1); }

        public ProcessingImagesList()
        {
            _processedImages = new List<ImageDetails>();
            CurrentStep = 0;
            IsProcessing = false;
        }

        public ProcessingImagesList(Bitmap sourceImage)
        {
            _processedImages = new List<ImageDetails>();
            ImageDetails sourceImageDetails = new ImageDetails("Исходное изображение", sourceImage);
            _processedImages.Add(sourceImageDetails);
            CurrentStep = 1;
            IsProcessing = false;
        }

        public void Add(string actionName, Bitmap image)
        {
            ImageDetails newImageDetails = new ImageDetails(actionName, image);
            _processedImages.Add(newImageDetails);
            CurrentStep++;
        }

        public void Reset()
        {
            if (_processedImages.Count > 0)
            {
                ImageDetails sourceImageDetails = GetSourcetImage;
            }
        }
    }
}
