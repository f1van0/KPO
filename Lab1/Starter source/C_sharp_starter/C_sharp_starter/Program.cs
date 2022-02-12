using System;
using System.Runtime.InteropServices;

namespace C_sharp_starter
{
    class Program
    {
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

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate double VectorType(double[] array, int size);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate double MatrixType(IntPtr[] matrix, int size);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void VoidVoid();

		public static string path = "C:\\Users\\vanya\\Source\\Repos\\KPO\\Lab1\\Build\\";

		VectorType TryGetVectorFuncFromDll(int pointerDll, string funcName)
		{
			IntPtr getProc = GetProcAddress(pointerDll, funcName);
			if ((int)getProc != 0)
			{
				return Marshal.GetDelegateForFunctionPointer<VectorType>(getProc);
			}
			else
			{
				return null;
			}
		}

		MatrixType TryGetMatrixFuncFromDll(int pointerDll, string funcName)
		{
			IntPtr getProc = GetProcAddress(pointerDll, funcName);
			if ((int)getProc != 0)
			{
				return Marshal.GetDelegateForFunctionPointer<MatrixType>(getProc);
			}
			else
			{
				return null;
			}
		}

		double[] GetArray(int size)
        {
			double[] newArray = new double[size];
			for (int i = 0; i < size; i++)
            {
				newArray[i] = size * Math.Pow(i + 1, 3 / 4) * Math.Cos(i) / Math.Atan(i + 1);
			}

			return newArray;
		}

		IntPtr[] GetMatrix(int size)
		{
			IntPtr[] newMatrix;

			unsafe
			{
				newMatrix = new IntPtr[size];
				for (int k = 0; k < size; k++)
				{
					double[] arr = GetArray(size);
					fixed (void* ptr = arr)
					{
						newMatrix[k] = new IntPtr(ptr);
					}
				}
			}

			return newMatrix;
		}

		double CalculateTimeVectorFunc(VectorType func, int size, int iterations)
        {
			long startTime, endTime, frequence;
			double minTime = double.MaxValue;
			double maxTime = -1;
			double sumTime = 0;
			double[] array = GetArray(size);

			QueryPerformanceFrequency(out frequence);
			QueryPerformanceCounter(out startTime);

			for (int i = 0; i < iterations; i++)
            {
				double value = func(array, size);
			}

			QueryPerformanceCounter(out endTime);
			double time = (double)((endTime - startTime)) * 1000 / frequence / iterations;

			Console.WriteLine("Длительность: " + time + " мс.");
			return time;
		}

		double CalculateTimeMatrixFunc(MatrixType func, int size, int iterations)
		{
			long startTime, endTime, frequence;
			double minTime = 100000;
			double maxTime = -1;
			double sumTime = 0;
			IntPtr[] matrix = GetMatrix(size);

			QueryPerformanceFrequency(out frequence);
			QueryPerformanceCounter(out startTime);

			for (int i = 0; i < iterations; i++)
			{
				double value = func(matrix, size);
			}

			QueryPerformanceCounter(out endTime);
			double time = (double)((endTime - startTime)) * 1000 / frequence / iterations;

			Console.WriteLine("Длительность: " + time + " мс.");
			return time;
		}

		void CallDllSTD(string dllName, string[] funcsName)
		{
			int pointerDll = LoadLibrary(path + dllName);
			double time;

			VectorType func1 = TryGetVectorFuncFromDll(pointerDll, funcsName[0]);
			time = CalculateTimeVectorFunc(func1, 100000, 30);

			VectorType func2 = TryGetVectorFuncFromDll(pointerDll, funcsName[1]);
			time = CalculateTimeVectorFunc(func2, 100000, 30);

			MatrixType func3 = TryGetMatrixFuncFromDll(pointerDll, funcsName[2]);
			time = CalculateTimeMatrixFunc(func3, 635, 30);

			FreeLibrary(pointerDll);
		}

		void CallDllCdecl(string dllName, string[] funcsName)
		{
			int pointerDll = LoadLibrary(path + dllName);
			double time;

			VectorType func1 = TryGetVectorFuncFromDll(pointerDll, funcsName[0]);
			time = CalculateTimeVectorFunc(func1, 100000, 30);

			VectorType func2 = TryGetVectorFuncFromDll(pointerDll, funcsName[1]);
			time = CalculateTimeVectorFunc(func2, 100000, 30);

			MatrixType func3 = TryGetMatrixFuncFromDll(pointerDll, funcsName[2]);
			time = CalculateTimeMatrixFunc(func3, 635, 30);

			FreeLibrary(pointerDll);
		}

		static void Main(string[] args)
        {
			string[] funcsName = { "GetRangeValueFromVector", "GetAverageValueFromVector", "GetAverageValueFromMatrix" };
			Program newProgram = new Program();

			//newProgram.CallDllSTD("DllVisualCPP.dll", funcsName);
			//newProgram.CallDllSTD("Dll_CPP_Builder.dll", funcsName);
			newProgram.CallDllSTD("Dll_Lazarus.dll", funcsName);
			Console.ReadKey();
		}
    }
}
