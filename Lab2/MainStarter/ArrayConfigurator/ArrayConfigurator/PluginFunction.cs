using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr ValuesToArrayFuncType(int minValue, int maxValue, int size);

        [DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
        static extern int LoadLibrary(
            [MarshalAs(UnmanagedType.LPStr)] string lpLibFileName);

        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
        static extern IntPtr GetProcAddress(int hModule,
            [MarshalAs(UnmanagedType.LPStr)] string lpProcName);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
        static extern bool FreeLibrary(int hModule);

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

            if (controlElement[0] != "" && controlElement[1] != "" && controlElement[2] != "" && controlElement[3] != "")
                optionControls.AddRange(CreateControl(controlElement));

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
                        numUpDown.Minimum = -1000000;
                        numUpDown.Maximum = 1000000;
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

        public int[] ApplyFunction(string dllName, int[] array, FlowLayoutPanel panel)
        {
            int pointerDll = LoadLibrary(dllName);
            if (Type == FuncTypes.valuesToArray)
            {    
                ValuesToArrayFuncType func = Marshal.GetDelegateForFunctionPointer<ValuesToArrayFuncType>
                    (GetProcAddress(pointerDll, Name));

                int minValue = 0, maxValue = 0, size = 0;

                for (int i = 0; i < panel.Controls.Count; i++)
                {
                    if (panel.Controls[i] is NumericUpDown)
                    {
                        if (panel.Controls[i].Name == "MinValue")
                            minValue = (int)((NumericUpDown)panel.Controls[i]).Value;
                        else if (panel.Controls[i].Name == "MaxValue")
                            maxValue = (int)((NumericUpDown)panel.Controls[i]).Value;
                        else if (panel.Controls[i].Name == "Size")
                            size = (int)((NumericUpDown)panel.Controls[i]).Value;
                    }
                }

                IntPtr ptr = func(minValue, maxValue, size);
                // points to arr[1], which is first value
                int[] result = new int[size];
                Marshal.Copy(ptr, result, 0, size);
                FreeLibrary(pointerDll);
                return result;
            }

            FreeLibrary(pointerDll);
            return new int[0];
        }
    }
}
