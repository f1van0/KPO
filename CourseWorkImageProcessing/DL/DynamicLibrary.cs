using System.Drawing;

namespace DL
{
    public interface IDynamicLibrary
    {
        public string Name { get; }
    }

    public interface IFilterDynamicLibrary
    {
        public string Name { get; }
        public string Version { get; }
        public string Author { get; }
        public string SettingsFileName { get; }

        public Settings Settings { get; set; }

        public Bitmap Apply(Bitmap sourceImage);
    }
}
