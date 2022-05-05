using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchImageProcessing
{
    public class ProcessingImagesList
    {
        private List<ImageDetails> _processedImages;

        public int CurrentStep;
        public bool IsProcessing;

        public ImageDetails GetCurrentImage { get => _processedImages[CurrentStep]; }
        public ImageDetails GetNextImage { get => _processedImages[CurrentStep + 1]; }
        public ImageDetails GetSourceImage { get => _processedImages.Count > 0 ? _processedImages[0] : null; }
        public ImageDetails GetResultImage { get => _processedImages.Count > 0 ? _processedImages[_processedImages.Count - 1] : null; }

        public ProcessingImagesList()
        {
            _processedImages = new List<ImageDetails>();
            CurrentStep = -1;
            IsProcessing = false;
        }

        public ProcessingImagesList(Bitmap sourceImage)
        {
            _processedImages = new List<ImageDetails>();
            ImageDetails sourceImageDetails = new ImageDetails("Исходное изображение", sourceImage);
            _processedImages.Add(sourceImageDetails);
            CurrentStep = 0;
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
                ImageDetails sourceImageDetails = GetSourceImage;
                _processedImages.Clear();
                _processedImages.Add(sourceImageDetails);
            }
        }

        public ImageDetails GetImageInStep(int step)
        {
            if (_processedImages.Count <= 0)
                return null;

            CurrentStep = step;

            if (_processedImages.Count < CurrentStep)
                return GetResultImage;
            else
                return GetCurrentImage;
        }
    }
}
