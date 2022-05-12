using System;
using System.Drawing;
using DL;

namespace ContrastFilter
{
    public class ContrastFilter : IImageFilterDynamicLibrary
    {
        public string Name => "Изменение контраста";

        public string Version => "1.0";

        public string Author => "Фролов Иван";

        public Settings Settings { get; set; }

        public string SettingsFileName => "ContrastFilter_Settings.json";

        public ContrastFilter()
        {
            SettingsVariable[] defaultSettings = new SettingsVariable[1];
            defaultSettings[0] = new SettingsVariable(0, -10, 10, "Коэффициент изменения контастности", VariableType.Int);
            Settings = new Settings(defaultSettings, SettingsFileName);
        }

        public Bitmap Apply(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Color currentColor;

            for (int j = 0; j < resultImage.Height; j++)
            {
                for (int i = 0; i < resultImage.Width; i++)
                {
                    currentColor = sourceImage.GetPixel(i, j);
                    resultImage.SetPixel(i, j, ContrastPoint(currentColor));
                }
            }

            return resultImage;
        }

        public Color ContrastPoint(Color currentColor)
        {
            int R;
            int G;
            int B;

            int N = (100 / Settings.SettingsVariables[0].Maximum) * Settings.SettingsVariables[0].Value; //кол-во процентов

            if (N >= 0)
            {
                if (N == 100) N = 99;
                R = (currentColor.R * 100 - 128 * N) / (100 - N);
                G = (currentColor.G * 100 - 128 * N) / (100 - N);
                B = (currentColor.B * 100 - 128 * N) / (100 - N);
            }
            else
            {
                R = (currentColor.R * (100 - (-N)) + 128 * (-N)) / 100;
                G = (currentColor.G * (100 - (-N)) + 128 * (-N)) / 100;
                B = (currentColor.B * (100 - (-N)) + 128 * (-N)) / 100;
            }

            //контролируем переполнение переменных
            if (R < 0) R = 0;
            if (R > 255) R = 255;
            if (G < 0) G = 0;
            if (G > 255) G = 255;
            if (B < 0) B = 0;
            if (B > 255) B = 255;

            Color newColor = Color.FromArgb(currentColor.A, R, G, B);

            return newColor;
        }
    }   
}
