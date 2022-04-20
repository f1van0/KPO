using System;
using System.Drawing;
using DL;

namespace BrightnessFilter
{
    public class BrightnessFilter : IFilterDynamicLibrary
    {
        public string Name => "Изменение яркости";

        private int i;
        public int I { get => i; set => i = value; }

        public Bitmap Apply(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            int k = 30;
            Color currentColor;
            for (int j = 0; j < resultImage.Height; j++)
            {
                for (int i = 0; i < resultImage.Width; i++)
                {
                    currentColor = sourceImage.GetPixel(i, j);
                    resultImage.SetPixel(i, j, Color.FromArgb(
                                   Clamp((currentColor.R + k), 0, 255),
                                   Clamp((currentColor.G + k), 0, 255),
                                   Clamp((currentColor.B + k), 0, 255)
                                   ));
                }
            }

            return resultImage;
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
