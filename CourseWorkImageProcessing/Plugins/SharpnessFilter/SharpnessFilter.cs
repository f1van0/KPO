using System;
using System.Drawing;
using DL;

namespace SharpnessFilter
{
    public class SharpnessFilter : IFilterDynamicLibrary
    {
        public string Name => "Изменение резкости";
        public string Version => "1.2";
        public string Author => "Фролов Иван";

        private static int _size = 3;
        private float[,] _kernel;

        //Коэффициент резкости
        private int _sharpness;

        public OptionsVariable[] Options { get; set; }

        public SharpnessFilter()
        {
            Options = new OptionsVariable[0];
        }

        public Bitmap Apply(Bitmap sourceImage)
        {
            _sharpness = Options[0].Value;
            InitializeMatrix();
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int j = 0; j < resultImage.Height; j++)
            {
                for (int i = 0; i < resultImage.Width; i++)
                {
                    resultImage.SetPixel(i, j, CalculatePixel(i, j, sourceImage));
                }
            }

            return resultImage;
        }

        private void InitializeMatrix()
        {
            _kernel = new float[_size, _size];
            _kernel[0, 0] = 0;
            _kernel[0, 1] = -1;
            _kernel[0, 2] = 0;
            _kernel[1, 0] = -1;
            _kernel[1, 1] = 9;
            _kernel[1, 2] = -1;
            _kernel[2, 0] = 0;
            _kernel[2, 1] = -1;
            _kernel[2, 2] = 0;
        }
        private Color CalculatePixel(int x, int y, Bitmap sourceImage)
        {
            int radiusX = _kernel.GetLength(0) / 2;
            int radiusY = _kernel.GetLength(1) / 2;

            float resultR = 0;
            float resultG = 0;
            float resultB = 0;

            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);

                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighborColor.R * _kernel[k + radiusX, l + radiusY];
                    resultG += neighborColor.G * _kernel[k + radiusX, l + radiusY];
                    resultB += neighborColor.B * _kernel[k + radiusX, l + radiusY];
                }
            }

            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }

        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
    }
}
