using System;
using System.Runtime.InteropServices;

namespace Lab3_KPO
{
    class Filter
    {
		[DllImport("kernel32.dll", EntryPoint = "LoadLibrary")]
		static extern int LoadLibrary(
			[MarshalAs(UnmanagedType.LPStr)] string lpLibFileName);

		[DllImport("kernel32.dll", EntryPoint = "GetProcAddress")]
		static extern IntPtr GetProcAddress(int hModule,
			[MarshalAs(UnmanagedType.LPStr)] string lpProcName);

		[DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
		static extern bool FreeLibrary(int hModule);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr FilterFunctDLL(byte[] array, int lenth);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate byte[] FilterFunc(byte[] array, int lenth);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate IntPtr DllGetString();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		delegate int Calc();

		string dllPath;
		public string Name { get; private set; }

		public FilterFunc filterFunc;
		public Filter(string name, FilterFunc filterFunct)
		{
			Name = name;
			filterFunc = filterFunct;
		}
		public Filter(string dllPath)
		{
			this.dllPath = dllPath;
			int pDll = LoadLibrary(dllPath);
			IntPtr getProc;
			if (pDll != 0)
			{
				getProc = GetProcAddress(pDll, "getInfo");
				if ((int)getProc != 0)
				{
					DllGetString GetFuncName = (DllGetString)Marshal.GetDelegateForFunctionPointer(getProc, typeof(DllGetString));
					var tmpResult = Marshal.PtrToStringAnsi(GetFuncName());
					if (tmpResult != "" && tmpResult != null)
					{
						Name = tmpResult;
						getProc = GetProcAddress(pDll, "filterFunct");
						if ((int)getProc != 0)
						{

							filterFunc = (byte[] array, int Length) => {
								var funct = (FilterFunctDLL)Marshal.GetDelegateForFunctionPointer(getProc, typeof(FilterFunctDLL));
								byte[] tmpByte = new byte[array.Length];
								Marshal.Copy(funct(array, array.Length), tmpByte, 0, array.Length);
								return tmpByte;
							};
						}
					}
				}
			}
		}
	}
}
