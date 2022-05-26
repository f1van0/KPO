using System.Drawing;

namespace DL
{
    public interface IDynamicLibrary
    {
        public string Name { get; }
        public string Version { get; }
        public string Author { get; }
    }

    public interface ICustomizableDynamicLibrary : IDynamicLibrary
    {
        public string SettingsFileName { get; }
        public Settings Settings { get; set; }
    }

    public interface IImageFilterDynamicLibrary : ICustomizableDynamicLibrary
    {
        public Bitmap Apply(Bitmap sourceImage);
    }
}
