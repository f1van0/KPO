using System;
using System.Drawing;
using DL;

namespace MedianFilter
{
    public class MedianFilter : IImageFilterDynamicLibrary
    {
        public string Name => "Медианный фильтр";
        public string Version => "1.0";
        public string Author => "Фролов Иван";

        //Радиус
        private int _radius;

        public Settings Settings { get; set; }

        public string SettingsFileName => "MedianFilter_Settings.json";

        public MedianFilter()
        {
            SettingsVariable[] defaultSettings = new SettingsVariable[1];
            defaultSettings[0] = new SettingsVariable(4, 1, 10, "Радиус", VariableType.Int);
            Settings = new Settings(defaultSettings, SettingsFileName);
        }

        public Bitmap Apply(Bitmap sourceImage)
        {
            _radius = Settings.SettingsVariables[0].Value;
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            for (int j = 0; j < resultImage.Height; j++)
            {
                for (int i = 0; i < resultImage.Width; i++)
                {
                    resultImage.SetPixel(i, j, GetMedianPixelColor(i, j, sourceImage));
                }
            }

            return resultImage;
        }

        public Color GetMedianPixelColor(int x, int y, Bitmap currentSourceImageColor)
        {
            Color sourceColor = currentSourceImageColor.GetPixel(x, y);
            if (x < _radius || y < _radius)
            {
                return Color.FromArgb(sourceColor.A, sourceColor.R, sourceColor.G, sourceColor.B);
            }

            int cR_, cB_, cG_;      // Выходные цвета
            int k = 1;              // Счётчик для цикла
            int rad = _radius;       // 1 = 3*3, 2 = 5*5, 3 = 7*7, 4 = 9*9        
            int size = (2 * rad + 1) * (2 * rad + 1); // Размер матрицы

            int[] cR = new int[size + 1];
            int[] cB = new int[size + 1];
            int[] cG = new int[size + 1];

            for (int i = x - rad; i < x + rad + 1; i++)
            {
                for (int j = y - rad; j < y + rad + 1; j++)
                {
                    if (k < size + 1)
                    {
                        if (i < currentSourceImageColor.Width && j < currentSourceImageColor.Height)
                        {
                            Color c = currentSourceImageColor.GetPixel(i, j);
                            cR[k] = Convert.ToInt32(c.R);
                            cG[k] = Convert.ToInt32(c.G);
                            cB[k] = Convert.ToInt32(c.B);
                            k++;
                        }
                    }
                }
            }

            quicksort(cR, 0, size - 1);
            quicksort(cG, 0, size - 1);
            quicksort(cB, 0, size - 1);

            int center = (size / 2) + 1;    // Центр

            cR_ = cR[center];
            cG_ = cG[center];
            cB_ = cB[center];

            return Color.FromArgb(sourceColor.A, cR_, cG_, cB_);
        }

        private void quicksort(int[] a, int p, int r)
        {
            if (p < r)
            {
                int q = partition(a, p, r);
                quicksort(a, p, q - 1);
                quicksort(a, q + 1, r);
            }
        }

        private int partition(int[] a, int p, int r)
        {
            int x = a[r];
            int i = p - 1;
            int tmp;
            for (int j = p; j < r; j++)
            {

                if (a[j] <= x)
                {
                    i++;
                    tmp = a[i];
                    a[i] = a[j];
                    a[j] = tmp;

                }
            }
            tmp = a[r];
            a[r] = a[i + 1];
            a[i + 1] = tmp;
            return (i + 1);
        }
    }
}
