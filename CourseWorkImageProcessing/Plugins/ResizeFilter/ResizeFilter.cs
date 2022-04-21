using System;
using System.Drawing;
using DL;

namespace ResizeFilter
{
    public class ResizeFilter : IFilterDynamicLibrary
    {
        public string Name => "Изменение размера изображения";
        public string Version => "1.0";
        public string Author => "Фролов Иван";

        //Ширина
        private int _width;
        //Высота
        private int _height;

        public OptionsVariable[] Options { get; set; }

        public ResizeFilter()
        {
            Options = new OptionsVariable[2];
            Options[0] = new OptionsVariable(400, 1, 10000, "Ширина", VariableType.Int);
            Options[1] = new OptionsVariable(250, 1, 10000, "Высота", VariableType.Int);
        }


        public Bitmap Apply(Bitmap sourceImage)
        {
            _width = Options[0].Value;
            _height = Options[1].Value;

            Bitmap resultImage = new Bitmap(_width, _height);

            //for (int i = 0; i < )

            return resultImage;
        }
    }
}
