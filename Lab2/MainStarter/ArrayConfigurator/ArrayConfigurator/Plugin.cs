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
        public delegate string ServiceFuncsType();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate string ServiceInfoType(string str);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate double ReceiveArrayFuncType(int size, int minValue, int maxValue);


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

        string name;
        string description;
        List<PluginFunction> funcs;

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

        public Plugin VerifyPlugin(string fileName)
        {
            int pointerDll = LoadLibrary(fileName);

            //Получение функций из dll
            ServiceFuncsType plaginFuncsProc = Marshal.GetDelegateForFunctionPointer<ServiceFuncsType>
                (GetProcAddress(pointerDll, "GetPluginFunctions"));

            //TODO: перевод одной строки с функциями в список 

            if (plaginFuncsProc == null)
                return null;
            string dllFuncs = plaginFuncsProc();
            if (dllFuncs == null)
                return null;

            List<string> strFuncsNames = GetFuncsName(dllFuncs);

            //Цикл, в котором инициализируются данные по всем функциям
            funcs = new List<PluginFunction>();
            foreach (var elem in strFuncsNames)
            {
                ServiceInfoType pluginTypesProc = Marshal.GetDelegateForFunctionPointer<ServiceInfoType>
                    (GetProcAddress(pointerDll, "GetPluginTypes"));
                ServiceInfoType pluginDescriptionsProc = Marshal.GetDelegateForFunctionPointer<ServiceInfoType>
                    (GetProcAddress(pointerDll, "GetPluginDescriptions"));
                ServiceInfoType pluginCFG = Marshal.GetDelegateForFunctionPointer<ServiceInfoType>
                    (GetProcAddress(pointerDll, "GetPluginDescriptions"));
                
                if (pluginTypesProc == null || pluginDescriptionsProc == null || pluginCFG == null)
                {
                    continue;
                }

                string type = pluginTypesProc(elem);
                string description = pluginDescriptionsProc(elem);
                string cfg = pluginCFG(elem);

                if (type == null || description == null || cfg == null)
                {
                    continue;
                }

                PluginFunction func = new PluginFunction().VerifyFunc(elem, type, description, cfg);
                funcs.Add(func);
            }

            //Проверка наличия функций
            if (funcs.Count == 0)
                return null;
            else
                return this;
        }
    }
}
