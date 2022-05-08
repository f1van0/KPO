using System;
using System.Collections.Generic;
using System.Drawing;
using DL;

namespace ScalingFilter
{
	public class ScalingFilter : IFilterDynamicLibrary
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

		public struct MultiColor
		{
			public List<Color> Colors;
		}

		public class MultiColorMatrix
		{
			public int Width;
			public int Height;
			private MultiColor[,] _colorMatrix;

			public MultiColorMatrix()
			{
				_colorMatrix = new MultiColor[0, 0];
			}

			public MultiColorMatrix(int width, int height)
			{
				Width = width;
				Height = height;
				_colorMatrix = new MultiColor[width, height];
			}

			public void AddColorTo(int x, int y, Color color)
            {
				if (x < 0 || x >= Width || y < 0 || y > Height)
					return;

				_colorMatrix[x, y].Colors.Add(color);
			}

			public Color GetAverageColor(int x, int y)
            {
				int avgA = 0, avgR = 0, avgB = 0, avgG = 0;

				if (x < 0 || x >= Width || y < 0 || y > Height)
					return Color.FromArgb(0, 0, 0, 0);
				
				foreach(var colorItem in _colorMatrix[x, y].Colors)
                {
					avgA += colorItem.A;
					avgR += colorItem.R;
					avgB += colorItem.B;
					avgG += colorItem.G;
				}

				int amount = _colorMatrix[x, y].Colors.Count;
				avgA /= amount;
				avgR /= amount;
				avgG /= amount;
				avgB /= amount;

				return Color.FromArgb(avgA, avgR, avgB, avgG);
			}
		}

		public Bitmap Apply(Bitmap sourceImage)
        {
			int i;
			int j;
			int l;
			int c;
			float t;
			float u;
			float tmp;
			float d1, d2, d3, d4;
			Color p1, p2, p3, p4; /* nearby pixels */
			int alpha, red, green, blue;

			int resultWidth = Settings.SettingsVariables[0].Value;
			int resultHeight = Settings.SettingsVariables[1].Value;
			Bitmap resultImage = new Bitmap(resultWidth, resultHeight);

			for (i = 0; i < resultHeight; i++)
			{
				for (j = 0; j < resultWidth; j++)
				{

					tmp = (float)(i) / (float)(resultHeight - 1) * (sourceImage.Height - 1);
					l = (int)Math.Floor(tmp);
					if (l < 0)
					{
						l = 0;
					}
					else
					{
						if (l >= sourceImage.Height - 1)
						{
							l = sourceImage.Height - 2;
						}
					}

					u = tmp - l;
					tmp = (float)(j) / (float)(resultWidth - 1) * (sourceImage.Width - 1);
					c = (int)Math.Floor(tmp);
					if (c < 0)
					{
						c = 0;
					}
					else
					{
						if (c >= sourceImage.Width - 1)
						{
							c = sourceImage.Width - 2;
						}
					}
					t = tmp - c;

					/* coefficients */
					d1 = (1 - t) * (1 - u);
					d2 = t * (1 - u);
					d3 = t * u;
					d4 = (1 - t) * u;

					/* nearby pixels: a[i][j] */
					p1 = sourceImage.GetPixel(c, l);
					p2 = sourceImage.GetPixel(c, l + 1);
					p3 = sourceImage.GetPixel(c + 1, l + 1);
					p4 = sourceImage.GetPixel(c + 1, l);

					/* color components */
					alpha = (int)(p1.A * d1 + p2.A * d2 + p3.A * d3 + p4.A * d4);
					red = (int)(p1.R * d1 + p2.R * d2 + p3.R * d3 + p4.R * d4);
					green = (int)(p1.G * d1 + p2.G * d2 + p3.G * d3 + p4.G * d4);
					blue = (int)(p1.B * d1 + p2.B * d2 + p3.B * d3 + p4.B * d4);
					Color newColor = Color.FromArgb(alpha, red, green, blue);

					/* new pixel R G B  */
					resultImage.SetPixel(j, i, newColor); // + (i * resultWidth) + j) = (red << 16) | (green << 8) | (blue);
				}
			}

			return resultImage;
		}
    }
}
