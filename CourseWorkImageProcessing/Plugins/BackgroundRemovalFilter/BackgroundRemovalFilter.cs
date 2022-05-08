using System;
using System.Drawing;
using DL;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Newtonsoft.Json;
using System.IO;

namespace BackgroundRemovalFilter
{
    public class BackgroundRemovalFilter : IFilterDynamicLibrary
    {
        public string Name => "Фильтр удаления фона";
		public string Version => "1.1";
		public string Author => "Фролов Иван";

		//Чувствительность заливки
		private double inputFloodFillTolerance { get; set; }
		//Коэффициент размытия маски
		private int inputMaskBlurFactor { get; set; }

        public Settings Settings { get; set; }

        public string SettingsFileName => "BackgroundRemovalFilter_Settings.json";

        public BackgroundRemovalFilter()
        {
			SettingsVariable[] defaultSttings = new SettingsVariable[2];
			defaultSttings[0] = new SettingsVariable(10, 1, 100, "Чувствительность заливки", VariableType.Double);
			defaultSttings[1] = new SettingsVariable(5, 1, 10, "Коэффициент размытия маски", VariableType.Int);
			Settings = new Settings(defaultSttings, SettingsFileName);
		}

		public Bitmap Apply(Bitmap sourceImage)
        {
			inputFloodFillTolerance = Settings.SettingsVariables[0].Value / 1000;
			inputMaskBlurFactor = Settings.SettingsVariables[1].Value % 2 == 1 ?
				Settings.SettingsVariables[1].Value : ++Settings.SettingsVariables[1].Value;

			Mat img = BitmapConverter.ToMat(sourceImage);

			var filter = new RemoveBackgroundOpenCvFilter
			{
				FloodFillTolerance = inputFloodFillTolerance,
				MaskBlurFactor = inputMaskBlurFactor
			};

			using (var result = filter.Apply(img))
			{
				Bitmap resultBitmap = BitmapConverter.ToBitmap(result);
				return resultBitmap;
			}
		}
    }
}
