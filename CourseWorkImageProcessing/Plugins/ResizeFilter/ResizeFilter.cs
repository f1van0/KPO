using System;
using System.Drawing;
using DL;

namespace ResizeFilter
{
    public class ResizeFilter : IFilterDynamicLibrary
    {
        public string Name => "Изменение размера изображения";
        public string Version => "1.0";
        public string Author => "Фролов Иван";

        //Ширина
        private int _width;
        //Высота
        private int _height;

        public bool isCenteringX;
        public bool isCenteringY;
        public bool isScalingImage;

        public OptionsVariable[] Options { get; set; }

        public ResizeFilter()
        {
            Options = new OptionsVariable[2];
            Options[0] = new OptionsVariable(400, 1, 10000, "Ширина", VariableType.Int);
            Options[1] = new OptionsVariable(250, 1, 10000, "Высота", VariableType.Int);
        }


        public Bitmap Apply(Bitmap sourceImage)
        {
            _width = Options[0].Value;
            _height = Options[1].Value;

            Bitmap resultImage = new Bitmap(_width, _height);

            //for (int i = 0; i < )

            return resultImage;
        }

        //Центрирование (по идее, если будет масштабирование самого изображение, то центрировать не нужно будет)
        public void Centering(Bitmap sourceImage, out int centerX, out int centerY)
        {
            //Центр по горизонтали
            centerX = 0;
            //Центр по вертикали
            centerY = 0;


            int sumX = 0, sumY = 0, sum = 0;
            Color currentColor;

            for (int j = 0; j < sourceImage.Height; j++)
            {
                for (int i = 0; i < sourceImage.Width; i++)
                {
                    currentColor = sourceImage.GetPixel(i, j);
                    if (currentColor != Color.White && currentColor.A != 0)
                    {
                        sumX += i;
                        sumY += j;
                        sum++;
                    }
                }
            }

            centerX = sumX / sum;
            centerY = sumY / sum;
        }

        //Масштабирование картинки
        public Bitmap ScaleImage(Bitmap sourceImage)
        {
            //Метод ближайшего соседа
            return sourceImage;
        }

        //Масштабирование холста
    }
}
