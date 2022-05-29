using System;
using System.Collections.Generic;
using System.Drawing;
using DL;

namespace ScalingFilter
{
	public class ScalingFilter : IImageFilterDynamicLibrary
	{
		public string Name => "Масштабирование изображения";

		public string Version => "1.15";

		public string Author => "Фролов Иван";

		public Settings Settings { get; set; }

		public string SettingsFileName => "ScalingFilter_Settings.json";

		public ScalingFilter()
		{
			SettingsVariable[] defaultSettings = new SettingsVariable[2];
			defaultSettings[0] = new SettingsVariable(300, 1, 3000, "Ширина", VariableType.Int);
			defaultSettings[1] = new SettingsVariable(300, 1, 3000, "Высота", VariableType.Int);
			Settings = new Settings(defaultSettings, SettingsFileName);
		}

		public Bitmap Apply(Bitmap sourceImage)
        {
			int j;
			int i;
			int consideredYPotision;
			int consideredXPosition;
			float offsetX;
			float offsetY;
			float yPositionRelativeToSource;
			float xPositionRelativeToSource;
			float d1, d2, d3, d4;
			Color pixel1, pixel2, pixel3, pixel4;
			int alpha, red, green, blue;

			int resultWidth = Settings.SettingsVariables[0].Value;
			int resultHeight = Settings.SettingsVariables[1].Value;
			Bitmap resultImage = new Bitmap(resultWidth, resultHeight);

			for (j = 0; j < resultHeight; j++)
			{
				for (i = 0; i < resultWidth; i++)
				{
					yPositionRelativeToSource = (float)(j) / (float)(resultHeight - 1) * (sourceImage.Height - 1);
					consideredYPotision = (int)Math.Floor(yPositionRelativeToSource);
					if (consideredYPotision < 0)
					{
						consideredYPotision = 0;
					}
					else
					{
						if (consideredYPotision >= sourceImage.Height - 1)
						{
							consideredYPotision = sourceImage.Height - 2;
						}
					}

					offsetY = yPositionRelativeToSource - consideredYPotision;

					xPositionRelativeToSource = (float)(i) / (float)(resultWidth - 1) * (sourceImage.Width - 1);
					consideredXPosition = (int)Math.Floor(xPositionRelativeToSource);
					if (consideredXPosition < 0)
					{
						consideredXPosition = 0;
					}
					else
					{
						if (consideredXPosition >= sourceImage.Width - 1)
						{
							consideredXPosition = sourceImage.Width - 2;
						}
					}
					offsetX = xPositionRelativeToSource - consideredXPosition;

					//Высчитывание коэфициентов для каждого пикселя
					d1 = (1 - offsetX) * (1 - offsetY);
					d2 = offsetX * (1 - offsetY);
					d3 = offsetX * offsetY;
					d4 = (1 - offsetX) * offsetY;

					//соседние пиксели
					pixel1 = sourceImage.GetPixel(consideredXPosition, consideredYPotision);
					pixel2 = sourceImage.GetPixel(consideredXPosition, consideredYPotision + 1);
					pixel3 = sourceImage.GetPixel(consideredXPosition + 1, consideredYPotision + 1);
					pixel4 = sourceImage.GetPixel(consideredXPosition + 1, consideredYPotision);

					//Высчитывание коэфициентов R G B A для нового пикселя
					alpha = (int)(pixel1.A * d1 + pixel2.A * d2 + pixel3.A * d3 + pixel4.A * d4);
					red = (int)(pixel1.R * d1 + pixel2.R * d2 + pixel3.R * d3 + pixel4.R * d4);
					green = (int)(pixel1.G * d1 + pixel2.G * d2 + pixel3.G * d3 + pixel4.G * d4);
					blue = (int)(pixel1.B * d1 + pixel2.B * d2 + pixel3.B * d3 + pixel4.B * d4);
					Color newColor = Color.FromArgb(alpha, red, green, blue);

					//Вставка нового цвета пикселя в картинку
					resultImage.SetPixel(i, j, newColor);
				}
			}

			return resultImage;
		}
    }
}
