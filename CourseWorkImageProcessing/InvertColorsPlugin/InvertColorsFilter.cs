using System;
using System.Drawing;
using DL;

namespace InvertColorsPlugin
{
    public class InvertColorsFilter : IFilterDynamicLibrary
    {
        public string Name => "Инвертирование цветов";

        public Bitmap Apply(Bitmap sourceImage)
        {
            Color invertedColor;
            Color sourceColor;

            for (int j = 0; j < sourceImage.Height; j++)
            {
                for (int i = 0; i < sourceImage.Width; i++)
                {
                    sourceColor = sourceImage.GetPixel(i, j);
                    invertedColor = Color.FromArgb(255, 255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
                    sourceImage.SetPixel(i, j, invertedColor);
                }
            }

            return sourceImage;
        }
    }
}
