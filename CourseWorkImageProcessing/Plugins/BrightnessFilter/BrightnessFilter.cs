using System.Drawing;
using System.IO;
using DL;
using Newtonsoft.Json;

namespace BrightnessFilter
{
    public class BrightnessFilter : IFilterDynamicLibrary
    {
        public string Name => "Изменение яркости";
        public string Version => "1.0";
        public string Author => "Фролов Иван";

        //Коэффициент изменения яркости
        private int _k;

        public Settings Settings { get; set; }

        public string SettingsFileName => "BrightnessFilter_Settings.json";

        public BrightnessFilter()
        {
            SettingsVariable[] defaultSettings = new SettingsVariable[1];
            defaultSettings[0] = new SettingsVariable(30, -100, 100, "Коэффициент изменения яркости", VariableType.Int);
            Settings = new Settings(defaultSettings, SettingsFileName);
        }

        public Bitmap Apply(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            _k = Settings.SettingsVariables[0].Value;

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
