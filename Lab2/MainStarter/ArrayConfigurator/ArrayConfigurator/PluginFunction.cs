using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayConfigurator
{
    public enum FuncTypes
    {
        valuesToArray = 0,
        arrayToValue,
        arrayToArray
    }

    class PluginFunction
    {
        public string Name;
        public FuncTypes Type;
        public string Description;
        public List<Control> options;

        public PluginFunction(string name, string type, string description, string cfg)
        {
            Name = name;
            Description = description;
            switch(type)
            {
                case "VarsToArr":
                    Type = FuncTypes.valuesToArray;
                    break;
                case "ArrToVar":
                    Type = FuncTypes.arrayToValue;
                    break;
                default:
                    Type = FuncTypes.arrayToArray;
                    break;
            }
            InitOptions(cfg);
        }

        public void InitOptions(string cfg)
        {
            int i = 0;
            string[] controlElement = new string[4];
            foreach (var elem in cfg)
            {
                if (elem == ';')
                {
                    if (i == 3)
                    {
                        //TODO: запарсить значения
                        Control ctrl = new Button(); ...

                        for (int j = 0; j < 4; j++)
                            controlElement[j] = "";

                        i = 0;
                    }
                    else
                        i++;
                    continue;
                }

                controlElement[i] += elem;
            }
        }
    }
}
