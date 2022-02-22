using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Runtime.InteropServices;

namespace ArrayConfigurator
{
    class Plugin
    {
        //Типы функций у плагина
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr ServiceTest(string str);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr ServiceFuncsType();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr ServiceInfoType([MarshalAs(UnmanagedType.AnsiBStr)] string str);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate int[] ValuesToArrayFuncType(int size, int minValue, int maxValue);


        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceCounter(out long lpPerformanceCount);

        [DllImport("Kernel32.dll")]
        private static extern bool QueryPerformanceFrequency(out long lpFrequency);

        [DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
        static extern int LoadLibrary(
            [MarshalAs(UnmanagedType.LPStr)] string lpLibFileName);

        [DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
        static extern IntPtr GetProcAddress(int hModule,
            [MarshalAs(UnmanagedType.LPStr)] string lpProcName);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
        static extern bool FreeLibrary(int hModule);

        public string Name;
        public List<PluginFunction> Funcs;

        public List<string> GetFuncsName(string strFuncs)
        {
            List<string> funcsName = new List<string>();
            string currentFunc = "";
            for (int i = 0; i < strFuncs.Length; i++)
            {
                if (strFuncs[i] == ' ')
                {
                    funcsName.Add(currentFunc);
                    currentFunc = "";
                    continue;
                }

                currentFunc += strFuncs[i];
            }

            if (currentFunc != "")
                funcsName.Add(currentFunc);

            return funcsName;
        }

        public List<string> GetFuncsName()
        {
            List<string> funcsNames = new List<string>();
            foreach (var func in Funcs) funcsNames.Add(func.Name);
            return funcsNames;
        }

        public Plugin VerifyPlugin(string fileName)
        {
            int pointerDll = LoadLibrary(fileName);
            Name = fileName;

            //Получение функций из dll
            ServiceFuncsType pluginFuncsProc = Marshal.GetDelegateForFunctionPointer<ServiceFuncsType>
                    (GetProcAddress(pointerDll, "GetPluginFunctions"));

            if (pluginFuncsProc == null)
                return null;
            string dllFuncs = Marshal.PtrToStringAnsi(pluginFuncsProc());
            if (dllFuncs == null)
                return null;

            string[] strFuncsNames = dllFuncs.Split(' ');

            //Цикл, в котором инициализируются данные по всем функциям
            Funcs = new List<PluginFunction>();
            foreach (string elem in strFuncsNames)
            {
                ServiceInfoType pluginTypesProc = Marshal.GetDelegateForFunctionPointer<ServiceInfoType>
                    (GetProcAddress(pointerDll, "GetPluginTypes"));
                ServiceInfoType pluginDescriptionsProc = Marshal.GetDelegateForFunctionPointer<ServiceInfoType>
                    (GetProcAddress(pointerDll, "GetPluginDescriptions"));
                ServiceInfoType pluginCFG = Marshal.GetDelegateForFunctionPointer<ServiceInfoType>
                    (GetProcAddress(pointerDll, "GetPluginCFG"));
                
                if (pluginTypesProc == null || pluginDescriptionsProc == null || pluginCFG == null)
                {
                    continue;
                }
            
                string type = Marshal.PtrToStringAnsi(pluginTypesProc(elem));
                string description = Marshal.PtrToStringAnsi(pluginDescriptionsProc(elem));
                string cfg = Marshal.PtrToStringAnsi(pluginCFG(elem));
            
                if (type == "Not found" || description == "Not found" || cfg == "Not found")
                {
                    continue;
                }
            
                PluginFunction func = new PluginFunction(elem, type, description, cfg);
                Funcs.Add(func);
            }
            
            //Проверка наличия функций
            if (Funcs.Count == 0)
                return null;
            else
                return this;
            return this;
        }
        /*
        public void ApplyFunction(string funcName, int size, int minValue, int maxValue)
        {
            int pointerDll = LoadLibrary(Name);
            ReceiveArrayFuncType func = Marshal.GetDelegateForFunctionPointer<ReceiveArrayFuncType>
                (GetProcAddress(pointerDll, funcName));

            int[] resultArray = func(size, minValue, maxValue);
        }
         */
    }
}
