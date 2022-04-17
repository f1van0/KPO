using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public interface IDynamicLibrary
    {
        public string Name { get; }
    }

    public interface IFilterDynamicLibrary
    {
        public string Name { get; }

        public Bitmap Apply(Bitmap sourceImage);
    }
}
