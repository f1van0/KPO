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

        public OptionsVariable[] Options { get; set; }

        public Bitmap Apply(Bitmap sourceImage);
    }
}
