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

		public static string path = "C:\\Users\\Redmi\\Documents\\KPO\\Lab1\\Build\\";
		static int iterations = 50;
		static int arraySize = 100000;
		static int matrixSize = 650;

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
				newArray[i] = Math.Pow(i + 1, 3 / 4) * Math.Cos(i) / Math.Atan(i + 1);
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

		void CalculateTimeVectorFunc(VectorType func)
        {
			long startTime, endTime, frequence;
			double minTime = 10000;
			double maxTime = -1;
			double totalTime = 0;
			double[] array = GetArray(arraySize);

			for (int i = 0; i < iterations; i++)
            {
				QueryPerformanceFrequency(out frequence);
				QueryPerformanceCounter(out startTime);
				double value = func(array, arraySize);
				QueryPerformanceCounter(out endTime);
				double time = (double)((endTime - startTime)) * 1000 / frequence;
				totalTime += time;
				if (minTime > time) minTime = time;
				if (maxTime < time) maxTime = time;
			}

			double avgTime = totalTime / iterations;

			Console.WriteLine("Min: " + minTime + " ms.");
			Console.WriteLine("Avg: " + avgTime + " ms.");
			Console.WriteLine("Max: " + maxTime + " ms.");
		}

		void CalculateTimeMatrixFunc(MatrixType func)
		{
			long startTime, endTime, frequence;
			double minTime = 10000;
			double maxTime = -1;
			double totalTime = 0;
			IntPtr[] matrix = GetMatrix(matrixSize);

			
			for (int i = 0; i < iterations; i++)
			{
				QueryPerformanceFrequency(out frequence);
				QueryPerformanceCounter(out startTime);
				double value = func(matrix, matrixSize);
				QueryPerformanceCounter(out endTime);
				double time = (double)((endTime - startTime)) * 1000 / frequence;
				totalTime += time;
				if (minTime > time) minTime = time;
				if (maxTime < time) maxTime = time;
			}

			double avgTime = totalTime / iterations;

			Console.WriteLine("Min: " + minTime + " ms.");
			Console.WriteLine("Avg: " + avgTime + " ms.");
			Console.WriteLine("Max: " + maxTime + " ms.");
		}

		void CallDllSTD(string dllName, string[] funcsName)
		{
			Console.WriteLine("Загрузка Dll: " + dllName);
			int pointerDll = LoadLibrary(dllName);
			if (pointerDll == 0)
            {
				Console.WriteLine("Dll не найден");
				return;
			}
			double time;

			VectorType func1 = TryGetVectorFuncFromDll(pointerDll, funcsName[0]);
			if (func1 == null)
            {
				Console.WriteLine($"Функция {funcsName[0]} не найдена");
				return;
			}
			CalculateTimeVectorFunc(func1);

			VectorType func2 = TryGetVectorFuncFromDll(pointerDll, funcsName[1]);
			if (func2 == null)
			{
				Console.WriteLine($"Функция {funcsName[1]} не найдена");
				return;
			}
			CalculateTimeVectorFunc(func2);

			MatrixType func3 = TryGetMatrixFuncFromDll(pointerDll, funcsName[2]);
			if (func3 == null)
			{
				Console.WriteLine($"Функция {funcsName[2]} не найдена");
				return;
			}
			CalculateTimeMatrixFunc(func3);

			FreeLibrary(pointerDll);
		}

		void CallDllCdecl(string dllName, string[] funcsName)
		{
			Console.WriteLine("Загрузка Dll: " + dllName);
			int pointerDll = LoadLibrary(dllName);
			if (pointerDll == 0)
			{
				Console.WriteLine("Dll не найден");
				return;
			}
			double time;

			VectorType func1 = TryGetVectorFuncFromDll(pointerDll, funcsName[0]);
			if (func1 == null)
			{
				Console.WriteLine($"Функция {funcsName[0]} не найдена");
				return;
			}
			CalculateTimeVectorFunc(func1);

			VectorType func2 = TryGetVectorFuncFromDll(pointerDll, funcsName[1]);
			if (func2 == null)
			{
				Console.WriteLine($"Функция {funcsName[1]} не найдена");
				return;
			}
			CalculateTimeVectorFunc(func2);

			MatrixType func3 = TryGetMatrixFuncFromDll(pointerDll, funcsName[2]);
			if (func3 == null)
			{
				Console.WriteLine($"Функция {funcsName[2]} не найдена");
				return;
			}
			CalculateTimeMatrixFunc(func3);

			FreeLibrary(pointerDll);
		}

		static void Main(string[] args)
        {
			string[] funcsName = { "GetRangeValueFromVector", "GetAverageValueFromVector", "GetAverageValueFromMatrix" };
			Program newProgram = new Program();

			newProgram.CallDllSTD("DllVisualCPP.dll", funcsName);
			newProgram.CallDllSTD("Dll_CPP_Builder.dll", funcsName);
			newProgram.CallDllSTD("Dll_Lazarus.dll", funcsName);
			Console.ReadKey();
		}
    }
}
