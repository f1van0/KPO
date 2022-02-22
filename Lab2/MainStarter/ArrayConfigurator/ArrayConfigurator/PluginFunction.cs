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
        public List<Control> optionControls;

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
            optionControls = new List<Control>();
            string[] controlElement = new string[4];
            string[] elementsDescr = cfg.Split(';');

            for (int i = 0; i < elementsDescr.Length; i++)
            {
                if (i % 4 == 0 && i != 0)
                {
                    optionControls.AddRange(CreateControl(controlElement));

                    for (int j = 0; j < 4; j++)
                        controlElement[j] = "";
                }
                controlElement[i % 4] = elementsDescr[i];
            }
            //1. Тип элемента
            //2. Подпись (у NumericUpDown автоматически создается Label с подписью, а у RadioButton, как и у Label, записывается Text)
            //3. Название .Name элемента
            //4. Отсуп Margin в виде числа
            //foreach (var elem in cfg)
            //{
            //    if (elem == ';')
            //    {
            //        if (i == 3)
            //        {
            //            optionControls.AddRange(CreateControl(controlElement));
            //
            //            for (int j = 0; j < 4; j++)
            //                controlElement[j] = "";
            //
            //            i = 0;
            //        }
            //        else
            //            i++;
            //        continue;
            //    }
            //
            //    controlElement[i] += elem;
            //}
        }

        IEnumerable<Control> CreateControl(string[] controlDescription)
        {
            switch (controlDescription[0])
            {
                case "NumericUpDown":
                    {
                        Control[] newControls = new Control[2];

                        Label label = new Label();
                        label.Text = controlDescription[1];
                        newControls[0] = label;

                        NumericUpDown numUpDown = new NumericUpDown();
                        numUpDown.Name = controlDescription[2];
                        int bottomMargin;
                        if (int.TryParse(controlDescription[3], out bottomMargin))
                            numUpDown.Margin = new Padding(0, 0, 0, bottomMargin);
                        newControls[1] = numUpDown;

                        return newControls;
                    }
                case "RadioButton":
                    {
                        RadioButton[] radioButton = new RadioButton[1];
                        radioButton[0].Text = controlDescription[1];
                        radioButton[0].Name = controlDescription[2];
                        int bottomMargin;
                        if (int.TryParse(controlDescription[3], out bottomMargin))
                            radioButton[0].Margin = new Padding(0, 0, 0, bottomMargin);

                        return radioButton;
                    }
                default:
                    {
                        Label[] label = new Label[1];
                        label[0].Text = controlDescription[1];
                        label[0].Name = controlDescription[2];
                        int bottomMargin;
                        if (int.TryParse(controlDescription[3], out bottomMargin))
                            label[0].Margin = new Padding(0, 0, 0, bottomMargin);

                        return label;
                    }
            }
        }
    }
}
