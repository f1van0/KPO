using System;
using System.Drawing;
using System.Numerics;
using DL;

namespace ResizeFilter
{
    public class ResizeFilter : IFilterDynamicLibrary
    {
        public string Name => "Изменение области изображения";
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
            Options = new OptionsVariable[3];
            Options[0] = new OptionsVariable(400, 1, 10000, "Ширина", VariableType.Int);
            Options[1] = new OptionsVariable(250, 1, 10000, "Высота", VariableType.Int);
            Options[2] = new OptionsVariable(1, 0, 1, "Центрировать рамку", VariableType.Int);
        }


        public Bitmap Apply(Bitmap sourceImage)
        {
            int sourceWidth = sourceImage.Width;
            int sourceHeight = sourceImage.Height;

            _width = Options[0].Value;
            _height = Options[1].Value;

            Bitmap resultImage = new Bitmap(_width, _height);

            Vector2 center;

            if (Options[2].Value == 1)
                center = Centering(sourceImage);
            else
                center = new Vector2(sourceWidth / 2, sourceHeight / 2);

            Vector2 startPoint = new Vector2(center.X - _width / 2, center.Y - _height / 2);
            Vector2 currentPoint;
            Color currentColor;

            for (int j = 0; j < _height; j++)
            {
                for (int i = 0; i < _width; i++)
                {
                    currentPoint = new Vector2(startPoint.X + i, startPoint.Y + j);
                    if (currentPoint.X > 0 && currentPoint.X < sourceWidth && currentPoint.Y > 0 && currentPoint.Y < sourceHeight)
                    {
                        currentColor = sourceImage.GetPixel((int)currentPoint.X, (int)currentPoint.Y);
                    }
                    else
                    {
                        currentColor = Color.FromArgb(0, 0, 0, 0);
                    }

                    resultImage.SetPixel(i, j, currentColor);
                }
            }

            return resultImage;
        }

        //Центрирование (по идее, если будет масштабирование самого изображение, то центрировать не нужно будет)
        public Vector2 Centering(Bitmap sourceImage)
        {
            //Центр по горизонтали
            int centerX = 0;
            //Центр по вертикали
            int centerY = 0;


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

            return new Vector2(centerX, centerY);
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
