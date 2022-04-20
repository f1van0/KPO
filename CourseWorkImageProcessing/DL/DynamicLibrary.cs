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
        public int I { get; set; }

        public Bitmap Apply(Bitmap sourceImage);
    }
}
