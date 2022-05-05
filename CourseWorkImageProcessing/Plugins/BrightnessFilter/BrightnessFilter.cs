using System.Drawing;
using DL;

namespace BrightnessFilter
{
    public class BrightnessFilter : IFilterDynamicLibrary
    {
        public string Name => "Изменение яркости";
        public string Version => "1.0";
        public string Author => "Фролов Иван";

        //Коэффициент изменения яркости
        private int _k;

        public OptionsVariable[] Options { get; set; }

        public BrightnessFilter()
        {
            Options = new OptionsVariable[1];
            Options[0] = new OptionsVariable(30, -100, 100, "Коэффициент изменения яркости", VariableType.Int);
        }



        public Bitmap Apply(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            _k = Options[0].Value;

            Color currentColor;
            for (int j = 0; j < resultImage.Height; j++)
            {
                for (int i = 0; i < resultImage.Width; i++)
                {
                    currentColor = sourceImage.GetPixel(i, j);
                    resultImage.SetPixel(i, j, Color.FromArgb(
                                   currentColor.A,
                                   Clamp((currentColor.R + _k), 0, 255),
                                   Clamp((currentColor.G + _k), 0, 255),
                                   Clamp((currentColor.B + _k), 0, 255)
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
