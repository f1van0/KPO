using System;
using System.Drawing;
using DL;
using OpenCvSharp;
using OpenCvSharp.Extensions;


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
        public OptionsVariable[] Options { get; set; }

        public BackgroundRemovalFilter()
        {
			Options = new OptionsVariable[2];
			Options[0] = new OptionsVariable(10, 1, 100, "Чувствительность заливки", VariableType.Double);
			Options[1] = new OptionsVariable(5, 1, 10, "Коэффициент размытия маски", VariableType.Int);
		}

		public Bitmap Apply(Bitmap sourceImage)
        {
			inputFloodFillTolerance = Options[0].Value / 1000;
			inputMaskBlurFactor = Options[1].Value % 2 == 1 ? Options[1].Value : ++Options[1].Value;

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
