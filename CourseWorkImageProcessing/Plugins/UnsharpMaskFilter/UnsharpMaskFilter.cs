using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using DL;

namespace UnsharpMaskFilter
{
    public class UnsharpMaskFilter : IFilterDynamicLibrary
    {
        public string Name => "Unsharp mask";

        public string Version => "1.1";

        public string Author => "Фролов Иван";

        public SettingsVariable[] Settings { get; set; }

        public string SettingsFileName => throw new NotImplementedException();

        Settings IFilterDynamicLibrary.Settings { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public UnsharpMaskFilter()
        {
            Settings = new SettingsVariable[2];
            Settings[0] = new SettingsVariable(4, 1, 20, "Значение сигмы", VariableType.Int);
            Settings[1] = new SettingsVariable(11, 1, 20, "Размер матрицы", VariableType.Int);
        }

        public Bitmap Apply(Bitmap sourceImage)
        {
            //KalikoImage image = new KalikoImage(sourceImage);
            //
            //// Create a thumbnail of 128x128 pixels
            //KalikoImage thumb = image.GetThumbnailImage(128, 128, ThumbnailMethod.Crop);
            //
            //// Apply unsharpen filter (radius = 1.4, amount = 32%, threshold = 0)
            //thumb.ApplyFilter(new Kaliko.ImageLibrary.Filters.UnsharpMaskFilter(1.4f, 0.32f, 0));
            //thumb.SaveBmp(sourceImage);
            //thumb.
            //
            //return new Bitmap();

            return sourceImage;
        }
    }
}
