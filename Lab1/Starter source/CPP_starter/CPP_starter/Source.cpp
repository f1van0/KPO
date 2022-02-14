// dll_usage_demo.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <Windows.h>
#include <iostream>



using namespace std;

typedef double (__stdcall* VectorTypeSTD)(double*, int);
typedef double (__stdcall* MatrixTypeSTD)(double**, int);

typedef double (*VectorTypeCDECL)(double*, int);
typedef double (*MatrixTypeCDECL)(double**, int);

double* GetArray(int size)
{
	double* newArray = new double[size];
	for (int i = 0; i < size; i++)
	{
		newArray[i] = size * pow(i + 1, 3 / 4) * cos(i) / atan(i + 1);
	}

	return newArray;
}

double** GetMatrix(int size)
{
	double** newMatrix;

	newMatrix = new double*[size];
	for (int k = 0; k < size; k++)
	{
		newMatrix[k] = GetArray(size);
	}

	return newMatrix;
}

void ExecuteSTD_DLL(string dll_name, string func_name[3])
{
	int arraySize = 100000;
	int matrixSize = 650;
	int iterations = 50; 

	double 	Ftime;
	LARGE_INTEGER FFrequence, FBeginCount, FEndCount;

	std::wstring dll_load_name(dll_name.begin(), dll_name.end());

	VectorTypeSTD GetRangeValueFromVector, GetAverageValueFromVector;
	MatrixTypeSTD GetAverageValueFromMatrix;

	double result = 0;

	double* array = GetArray(arraySize);
	double** matrix = GetMatrix(matrixSize);

	cout << dll_name << endl;

	HINSTANCE hinstLib = LoadLibrary(dll_load_name.c_str());
	if (hinstLib == NULL) {
		cout << "ERROR: unable to load DLL: " << dll_name << endl;
		return;
	}

	cout << "library (" << dll_name << ") loaded\n";

	GetRangeValueFromVector = (VectorTypeSTD)GetProcAddress(hinstLib, "GetRangeValueFromVector");
	if (GetRangeValueFromVector != NULL) {
		QueryPerformanceFrequency(&FFrequence);
		QueryPerformanceCounter(&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetRangeValueFromVector(array, arraySize);
		}
		QueryPerformanceCounter(&FEndCount);
		Ftime = ((FEndCount.QuadPart - FBeginCount.QuadPart) / (double)FFrequence.QuadPart) * 1000 / iterations;
		cout << Ftime << " ms." << endl;
	}
	else
	{
		cout << "ERROR: unable to find DLL function (" << func_name[0] << ")\n";
		return;
	}
		


	GetAverageValueFromVector = (VectorTypeSTD)GetProcAddress(hinstLib, "GetAverageValueFromVector");
	if (GetAverageValueFromVector != NULL) {
		QueryPerformanceFrequency(&FFrequence);
		QueryPerformanceCounter(&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetAverageValueFromVector(array, arraySize);
		}
		QueryPerformanceCounter(&FEndCount);
		Ftime = ((FEndCount.QuadPart - FBeginCount.QuadPart) / (double)FFrequence.QuadPart) * 1000 / iterations;
		cout << Ftime << " ms." << endl;
	}
	else
	{
		cout << "ERROR: unable to find DLL function (" << func_name[1] << ")\n";
		return;
	}


	GetAverageValueFromMatrix = (MatrixTypeSTD)GetProcAddress(hinstLib, "GetAverageValueFromMatrix");
	if (GetAverageValueFromMatrix != NULL) {
		QueryPerformanceFrequency(&FFrequence);
		QueryPerformanceCounter(&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetAverageValueFromMatrix(matrix, matrixSize);
		}
		QueryPerformanceCounter(&FEndCount);
		Ftime = ((FEndCount.QuadPart - FBeginCount.QuadPart) / (double)FFrequence.QuadPart) * 1000 / iterations;
		cout << Ftime << " ms." << endl;
	}
	else
	{
		cout << "ERROR: unable to find DLL function (" << func_name[2] << ")\n";
		return;
	}

	FreeLibrary(hinstLib);

}
/*
void Dll_demo_work_stdcall(string dll_name, string func_name[5])
{

	std::wstring dll_load_name(dll_name.begin(), dll_name.end());

	FdoubleOps2 Add, Subtract, Multiply, Divide;
	FmasProc2 FillMas;
	Fmas2Proc2 fill2darr;

	double a = 6, b = 7, result = 0, * mas;
	int size = 10;
	mas = new double[size];
	int Hs = 5, Ws = 5;
	double** mas2;
	mas2 = new double* [Hs];
	for (int i = 0; i < Hs; i++)
		mas2[i] = new double[Ws];

	cout << dll_name << endl;

	HINSTANCE hinstLib = LoadLibrary(dll_load_name.c_str());
	if (hinstLib == NULL) {
		cout << "ERROR: unable to load DLL: " << dll_name << endl;
		return;
	}


	cout << "library (" << dll_name << ") loaded\n";
	cout << "a=" << a << "\nb=" << b << endl;

	Add = (FdoubleOps2)GetProcAddress(hinstLib, func_name[0].c_str());
	if (Add != NULL) {
		result = Add(a, b);
		cout << "a+b =: " << result << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[0] << ")\n";


	Subtract = (FdoubleOps2)GetProcAddress(hinstLib, func_name[1].c_str());
	if (Subtract != NULL) {
		result = Subtract(a, b);
		cout << "a-b =: " << result << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[1] << ")\n";


	Multiply = (FdoubleOps2)GetProcAddress(hinstLib, func_name[2].c_str());
	if (Multiply != NULL) {
		result = Multiply(a, b);
		cout << "a*b =: " << result << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[2] << ")\n";


	Divide = (FdoubleOps2)GetProcAddress(hinstLib, func_name[3].c_str());
	if (Divide != NULL) {
		result = Divide(a, b);
		cout << "a/b =: " << result << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[3] << ")\n";



	FillMas = (FmasProc2)GetProcAddress(hinstLib, func_name[4].c_str());
	if (FillMas != NULL) {
		FillMas(mas, size, a, b);
		for (int i = 0; i < size; i++)
			cout << "mas[" << i << "]=" << mas[i] << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[4] << ")\n";

	fill2darr = (Fmas2Proc2)GetProcAddress(hinstLib, func_name[5].c_str());
	if (fill2darr != NULL) {
		fill2darr(mas2, Hs, Ws);
		for (int y = 0; y < Hs; y++)
		{
			for (int x = 0; x < Ws; x++)
				cout << "mas2[" << y << "][" << x << "]=" << mas2[y][x] << endl;
		}
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[5] << ")\n";


	FreeLibrary(hinstLib);

}
*/


int main()
{
	string path = "C:\\Users\\vanya\\Source\\Repos\\KPO\\Lab1\\Build\\";
	string func_name1[3] = { "GetRangeValueFromVector","GetAverageValueFromVector","GetAverageValueFromMatrix" };

	ExecuteSTD_DLL(path + "DllVisualCPP.dll", func_name1);
	ExecuteSTD_DLL(path + "Dll_CPP_Builder.dll", func_name1);
	ExecuteSTD_DLL(path + "Dll_Lazarus.dll", func_name1);

	int pause;
	cin >> pause;
	return 1;
}

// Запуск программы: CTRL+F5 или меню "Отладка" > "Запуск без отладки"
// Отладка программы: F5 или меню "Отладка" > "Запустить отладку"

// Советы по началу работы 
//   1. В окне обозревателя решений можно добавлять файлы и управлять ими.
//   2. В окне Team Explorer можно подключиться к системе управления версиями.
//   3. В окне "Выходные данные" можно просматривать выходные данные сборки и другие сообщения.
//   4. В окне "Список ошибок" можно просматривать ошибки.
//   5. Последовательно выберите пункты меню "Проект" > "Добавить новый элемент", чтобы создать файлы кода, или "Проект" > "Добавить существующий элемент", чтобы добавить в проект существующие файлы кода.
//   6. Чтобы снова открыть этот проект позже, выберите пункты меню "Файл" > "Открыть" > "Проект" и выберите SLN-файл.


/*
// dll_usage_demo.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <Windows.h>
#include <iostream>



using namespace std;

typedef double (*VectorType)(double*, int);
typedef int (*MatrixType)(double**, int);


string path = "C:\\Users\\vanya\\Source\\Repos\\KPO\\Lab1\\Build\\";

		VectorType TryGetVectorFuncFromDll(HINSTANCE hinstLib, LPCSTR funcName)
		{
			VectorType vectorFunc = (VectorType)GetProcAddress(hinstLib, funcName);
			if (vectorFunc != NULL)
			{
				return vectorFunc;
			}
			else
			{
				return nullptr;
			}
		}

		MatrixType TryGetMatrixFuncFromDll(HINSTANCE hinstLib, LPCSTR funcName)
		{
			MatrixType matrixFunc = (MatrixType)GetProcAddress(hinstLib, funcName);
			if (matrixFunc != NULL)
			{
				return matrixFunc;
			}
			else
			{
				return nullptr;
			}
		}

		double* GetArray(int size)
		{
			double* newArray = new double[size];
			for (int i = 0; i < size; i++)
			{
				newArray[i] = size * pow(i + 1, 3 / 4) * cos(i) / atan(i + 1);
			}

			return newArray;
		}

		double** GetMatrix(int size)
		{
			double** newMatrix = new double*[size];

			for (int i = 0; i < size; i++)
			{
				newMatrix[i] = new double[size];
				for (int j = 0; j < size; j++)
				{
					newMatrix[j][i] = size * (pow(j + 1, 3 / 4) * cos(j) / atan(j + 1)) * (size * pow(i + 1, 3 / 4) * cos(i) / atan(i + 1));
				}
			}

			return newMatrix;
		}

		double CalculateTimeVectorFunc(VectorType func, int size, int iterations)
		{
			long startTime, endTime, frequence;
			double minTime = 100000;
			double maxTime = -1;
			double sumTime = 0;
			double* array = GetArray(size);

			for (int i = 0; i < iterations; i++)
			{
				QueryPerformanceFrequency(out frequence);
				QueryPerformanceCounter(out startTime);
				double value = func(array, size);
				QueryPerformanceCounter(out endTime);
				double time = (double)((endTime - startTime)) * 1000 / frequence;
				sumTime += time;
				if (minTime > time) minTime = time;
				if (maxTime < time) maxTime = time;
			}

			double avgTime = sumTime / iterations;
			cout << "Длительность: " << avgTime << " мс.";
			return avgTime;
		}

		double CalculateTimeMatrixFunc(MatrixType func, int size, int iterations)
		{
			long startTime, endTime, frequence;
			double minTime = 100000;
			double maxTime = -1;
			double sumTime = 0;
			double** matrix = GetMatrix(size);

			for (int i = 0; i < iterations; i++)
			{
				QueryPerformanceFrequency(out frequence);
				QueryPerformanceCounter(out startTime);
				double value = func(matrix, size);
				QueryPerformanceCounter(out endTime);
				double time = (double)((endTime - startTime)) * 1000 / frequence;
				sumTime += time;
				if (minTime > time) minTime = time;
				if (maxTime < time) maxTime = time;
			}

			double avgTime = sumTime / iterations;
			cout << "Длительность: " << avgTime << " мс.";
			return avgTime;
		}

		void CallDll(string dllName, string funcName1, string funcName2, string funcName3)
		{
			HINSTANCE hinstLib = LoadLibrary(dllName.c_str());
			double time;

			VectorType func1 = TryGetVectorFuncFromDll(hinstLib, funcName1);
			time = CalculateTimeVectorFunc(func1, 100000, 30);

			VectorType func2 = TryGetVectorFuncFromDll(hinstLib, funcName2);
			time = CalculateTimeVectorFunc(func2, 100000, 30);

			MatrixType func3 = TryGetMatrixFuncFromDll(hinstLib, funcName3);
			time = CalculateTimeMatrixFunc(func3, 635, 30);

			FreeLibrary(hinstLib);
		}

		static void Main(string[] args)
		{
			Program newProgram = new Program();
			newProgram.CallDll(path + "DllVisualCPP.dll", "GetRangeValueFromVector", "GetAverageValueFromVector", "GetAverageValueFromMatrix");
			Console.ReadKey();
		}


void Dll_demo_work_cdecl(string dll_name, string func_name[5])
{

	std::wstring dll_load_name(dll_name.begin(), dll_name.end());

	FdoubleOps Add, Subtract, Multiply, Divide;
	FmasProc FillMas;
	Fmas2Proc fill2darr;

	double a = 6, b = 7, result = 0, * mas;
	int size = 10;
	mas = new double[size];
	int Hs = 5, Ws = 5;
	double** mas2;
	mas2 = new double* [Hs];
	for (int i = 0; i < Hs; i++)
		mas2[i] = new double[Ws];

	cout << dll_name << endl;

	HINSTANCE hinstLib = LoadLibrary(dll_load_name.c_str());
	if (hinstLib == NULL) {
		cout << "ERROR: unable to load DLL: " << dll_name << endl;
		return;

	}


	cout << "library (" << dll_name << ") loaded\n";
	cout << "a=" << a << "\nb=" << b << endl;

	Add = (FdoubleOps)GetProcAddress(hinstLib, func_name[0].c_str());
	if (Add != NULL) {
		result = Add(a, b);
		cout << "a+b =: " << result << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[0] << ")\n";


	Subtract = (FdoubleOps)GetProcAddress(hinstLib, func_name[1].c_str());
	if (Subtract != NULL) {
		result = Subtract(a, b);
		cout << "a-b =: " << result << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[1] << ")\n";


	Multiply = (FdoubleOps)GetProcAddress(hinstLib, func_name[2].c_str());
	if (Multiply != NULL) {
		result = Multiply(a, b);
		cout << "a*b =: " << result << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[2] << ")\n";


	Divide = (FdoubleOps)GetProcAddress(hinstLib, func_name[3].c_str());
	if (Divide != NULL) {
		result = Divide(a, b);
		cout << "a/b =: " << result << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[3] << ")\n";



	FillMas = (FmasProc)GetProcAddress(hinstLib, func_name[4].c_str());
	if (FillMas != NULL) {
		FillMas(mas, size, a, b);
		for (int i = 0; i < size; i++)
			cout << "mas[" << i << "]=" << mas[i] << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[4] << ")\n";

	fill2darr = (Fmas2Proc)GetProcAddress(hinstLib, func_name[5].c_str());
	if (fill2darr != NULL) {
		fill2darr(mas2, Hs, Ws);
		for (int y = 0; y < Hs; y++)
		{
			for (int x = 0; x < Ws; x++)
				cout << "mas2[" << y << "][" << x << "]=" << mas2[y][x] << endl;
		}
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[5] << ")\n";


	FreeLibrary(hinstLib);

}

void Dll_demo_work_stdcall(string dll_name, string func_name[5])
{

	std::wstring dll_load_name(dll_name.begin(), dll_name.end());

	FdoubleOps2 Add, Subtract, Multiply, Divide;
	FmasProc2 FillMas;
	Fmas2Proc2 fill2darr;

	double a = 6, b = 7, result = 0, * mas;
	int size = 10;
	mas = new double[size];
	int Hs = 5, Ws = 5;
	double** mas2;
	mas2 = new double* [Hs];
	for (int i = 0; i < Hs; i++)
		mas2[i] = new double[Ws];

	cout << dll_name << endl;

	HINSTANCE hinstLib = LoadLibrary(dll_load_name.c_str());
	if (hinstLib == NULL) {
		cout << "ERROR: unable to load DLL: " << dll_name << endl;
		return;

	}


	cout << "library (" << dll_name << ") loaded\n";
	cout << "a=" << a << "\nb=" << b << endl;

	Add = (FdoubleOps2)GetProcAddress(hinstLib, func_name[0].c_str());
	if (Add != NULL) {
		result = Add(a, b);
		cout << "a+b =: " << result << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[0] << ")\n";


	Subtract = (FdoubleOps2)GetProcAddress(hinstLib, func_name[1].c_str());
	if (Subtract != NULL) {
		result = Subtract(a, b);
		cout << "a-b =: " << result << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[1] << ")\n";


	Multiply = (FdoubleOps2)GetProcAddress(hinstLib, func_name[2].c_str());
	if (Multiply != NULL) {
		result = Multiply(a, b);
		cout << "a*b =: " << result << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[2] << ")\n";


	Divide = (FdoubleOps2)GetProcAddress(hinstLib, func_name[3].c_str());
	if (Divide != NULL) {
		result = Divide(a, b);
		cout << "a/b =: " << result << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[3] << ")\n";



	FillMas = (FmasProc2)GetProcAddress(hinstLib, func_name[4].c_str());
	if (FillMas != NULL) {
		FillMas(mas, size, a, b);
		for (int i = 0; i < size; i++)
			cout << "mas[" << i << "]=" << mas[i] << endl;
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[4] << ")\n";

	fill2darr = (Fmas2Proc2)GetProcAddress(hinstLib, func_name[5].c_str());
	if (fill2darr != NULL) {
		fill2darr(mas2, Hs, Ws);
		for (int y = 0; y < Hs; y++)
		{
			for (int x = 0; x < Ws; x++)
				cout << "mas2[" << y << "][" << x << "]=" << mas2[y][x] << endl;
		}
	}
	else
		cout << "ERROR: unable to find DLL function (" << func_name[5] << ")\n";


	FreeLibrary(hinstLib);

}


int main()
{
	string func_name1[6] = { "Add","Subtract","Multiply","Divide","Fill_1D_Array", "Fill_2D_Array" };
	string func_name1_CBuilder_cdecl[6] = { "_Add","_Subtract","_Multiply","_Divide","_Fill_1D_Array", "_Fill_2D_Array" };
	string func_name1_CBuilder_stdcall[6] = { "Add","Subtract","Multiply","Divide","Fill_1D_Array", "Fill_2D_Array" };
	string func_name2[6] = { "Add","Subtract","Multiply","Divide","Fill_1D_Array", "Fill_2D_Array_v2" };

	cout << "!! Demonstration of C++ VisualStudio dll" << endl;
	Dll_demo_work_cdecl("dll_sample.dll", func_name1);

	cout << endl << endl << "!! Demonstration of Delphi dll" << endl << endl;
	Dll_demo_work_cdecl("dll_sample_D.dll", func_name1);

	cout << endl << endl << "!! Demonstration of Lazarus dll" << endl << endl;
	Dll_demo_work_cdecl("dll_sample_L.dll", func_name1);


	cout << endl << endl << "!! Demonstration of C++ Builder cdecl dll" << endl << endl;
	Dll_demo_work_cdecl("dll_sample_CB_cdecl.dll", func_name1_CBuilder_cdecl);

	cout << endl << endl << "!! Demonstration of C++ Builder stdcall dll" << endl << endl;
	Dll_demo_work_stdcall("dll_sample_CB_stdcall.dll", func_name1_CBuilder_stdcall);

	return 1;
}
*/