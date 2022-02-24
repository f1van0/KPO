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

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr ArrayToArrayFuncType(int[] arr, int sign, int size);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int ArrayToValueFuncType(int[] arr, int size, int flag);


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
            Label description = new Label();
            description.Text = Description;
            description.AutoSize = true;
            description.Margin = new Padding(10, 10, 0, 20);
            optionControls.Add(description);
            string[] controlElement = new string[4];
            string[] elementsDescr = cfg.Split(';');
            bool isFirst = true;
            for (int i = 0; i < elementsDescr.Length; i++)
            {
                if (i % 4 == 0 && i != 0)
                {
                    optionControls.AddRange(CreateControl(controlElement, isFirst));
                    isFirst = false;
                    for (int j = 0; j < 4; j++)
                        controlElement[j] = "";
                }
                controlElement[i % 4] = elementsDescr[i];
            }

            if (controlElement[0] != "" && controlElement[1] != "" && controlElement[2] != "" && controlElement[3] != "")
                optionControls.AddRange(CreateControl(controlElement, isFirst));

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

        IEnumerable<Control> CreateControl(string[] controlDescription, bool isFirst)
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

                        if (controlDescription[2] == "Size")
                            numUpDown.Minimum = 1;
                        else
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
                        Control[] newControls = new Control[1];
                        RadioButton newRadioButton = new RadioButton();
                        newRadioButton.Text = controlDescription[1];
                        newRadioButton.Name = controlDescription[2];

                        if (isFirst)
                            newRadioButton.Checked = true;

                        int bottomMargin;
                        if (int.TryParse(controlDescription[3], out bottomMargin))
                            newRadioButton.Margin = new Padding(0, 0, 0, bottomMargin);
                        
                        newControls[0] = newRadioButton;
                        return newControls;
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
            int[] result;
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
                result = new int[size];
                Marshal.Copy(ptr, result, 0, size);
            }
            else if (Type == FuncTypes.arrayToArray)
            {
                ArrayToArrayFuncType func = Marshal.GetDelegateForFunctionPointer<ArrayToArrayFuncType>
                    (GetProcAddress(pointerDll, Name));

                int sign = 1;

                for (int i = 0; i < panel.Controls.Count; i++)
                {
                    if (panel.Controls[i] is RadioButton)
                    {
                        RadioButton radioBtn = (RadioButton)panel.Controls[i];
                        if (radioBtn.Name == "Ascending" && radioBtn.Checked)
                            sign = 1;
                        else if (radioBtn.Name == "Descending" && radioBtn.Checked)
                            sign = -1;
                    }
                }

                IntPtr ptr = func(array, sign, array.Length);
                // points to arr[1], which is first value
                result = new int[array.Length];
                Marshal.Copy(ptr, result, 0, array.Length);
            }
            else
            {
                ArrayToValueFuncType func = Marshal.GetDelegateForFunctionPointer<ArrayToValueFuncType>
                    (GetProcAddress(pointerDll, Name));

                int flag = 0;

                for (int i = 0; i < panel.Controls.Count; i++)
                {
                    if (panel.Controls[i] is RadioButton)
                    {
                        RadioButton radioBtn = (RadioButton)panel.Controls[i];
                        if (radioBtn.Name == "MinValue" && radioBtn.Checked)
                            flag = 0;
                        else if (radioBtn.Name == "AvgValue" && radioBtn.Checked)
                            flag = 1;
                        else if (radioBtn.Name == "MaxValue" && radioBtn.Checked)
                            flag = 2;
                    }
                }

                int resultInt = func(array, array.Length, flag);
                // points to arr[1], which is first value
                result = new int[1];
                result[0] = resultInt;
            }

            FreeLibrary(pointerDll);
            return result;
        }
    }
}
