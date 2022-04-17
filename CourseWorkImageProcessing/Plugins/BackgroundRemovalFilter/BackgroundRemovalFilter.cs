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

		public Double InputFloodFillTolerance { get; set; }
		public Int32 InputMaskBlurFactor { get; set; }

		public Bitmap Apply(Bitmap sourceImage)
        {
			InputFloodFillTolerance = 0.01f;
			InputMaskBlurFactor = 5;

			Mat img = BitmapConverter.ToMat(sourceImage);

			var filter = new RemoveBackgroundOpenCvFilter
			{
				FloodFillTolerance = InputFloodFillTolerance,
				MaskBlurFactor = InputMaskBlurFactor
			};

			using (var result = filter.Apply(img))
			{
				Bitmap resultBitmap = BitmapConverter.ToBitmap(result);
				return resultBitmap;
			}
		}
    }
}
