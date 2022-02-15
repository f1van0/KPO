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
		cout << "START: GetRangeValueFromVector\n";
		double minTime = 10000;
		double maxTime = -1;
		double totalTime = 0;

		for (int i = 0; i < iterations; i++)
		{
			QueryPerformanceFrequency(&FFrequence);
			QueryPerformanceCounter(&FBeginCount);
			result = GetRangeValueFromVector(array, arraySize);
			QueryPerformanceCounter(&FEndCount);
			double time = ((FEndCount.QuadPart - FBeginCount.QuadPart) / (double)FFrequence.QuadPart) * 1000;
			totalTime += time;
			if (minTime > time) minTime = time;
			if (maxTime < time) maxTime = time;
		}

		double avgTime = totalTime / iterations;

		cout << "Min: " << minTime << " ms.\n";
		cout << "Avg: " << avgTime << " ms.\n";
		cout << "Max: " << maxTime << " ms.\n";
	}
	else
	{
		cout << "ERROR: unable to find DLL function (" << func_name[0] << ")\n";
		return;
	}
		


	GetAverageValueFromVector = (VectorTypeSTD)GetProcAddress(hinstLib, "GetAverageValueFromVector");
	if (GetAverageValueFromVector != NULL) {
		cout << "START: GetAverageValueFromVector\n";
		double minTime = 10000;
		double maxTime = -1;
		double totalTime = 0;

		for (int i = 0; i < iterations; i++)
		{
			QueryPerformanceFrequency(&FFrequence);
			QueryPerformanceCounter(&FBeginCount);
			result = GetAverageValueFromVector(array, arraySize);
			QueryPerformanceCounter(&FEndCount);
			double time = ((FEndCount.QuadPart - FBeginCount.QuadPart) / (double)FFrequence.QuadPart) * 1000;
			totalTime += time;
			if (minTime > time) minTime = time;
			if (maxTime < time) maxTime = time;
		}

		double avgTime = totalTime / iterations;

		cout << "Min: " << minTime << " ms.\n";
		cout << "Avg: " << avgTime << " ms.\n";
		cout << "Max: " << maxTime << " ms.\n";
	}
	else
	{
		cout << "ERROR: unable to find DLL function (" << func_name[1] << ")\n";
		return;
	}


	GetAverageValueFromMatrix = (MatrixTypeSTD)GetProcAddress(hinstLib, "GetAverageValueFromMatrix");
	if (GetAverageValueFromMatrix != NULL) {
		cout << "START: GetAverageValueFromMatrix\n";
		double minTime = 10000;
		double maxTime = -1;
		double totalTime = 0;

		for (int i = 0; i < iterations; i++)
		{
			QueryPerformanceFrequency(&FFrequence);
			QueryPerformanceCounter(&FBeginCount);
			result = GetAverageValueFromMatrix(matrix, matrixSize);
			QueryPerformanceCounter(&FEndCount);
			double time = ((FEndCount.QuadPart - FBeginCount.QuadPart) / (double)FFrequence.QuadPart) * 1000;
			totalTime += time;
			if (minTime > time) minTime = time;
			if (maxTime < time) maxTime = time;
		}

		double avgTime = totalTime / iterations;

		cout << "Min: " << minTime << " ms.\n";
		cout << "Avg: " << avgTime << " ms.\n";
		cout << "Max: " << maxTime << " ms.\n";
	}
	else
	{
		cout << "ERROR: unable to find DLL function (" << func_name[2] << ")\n";
		return;
	}

	FreeLibrary(hinstLib);

}

int main()
{
	string path = "C:\\Users\\Redmi\\Documents\\KPO\\Lab1\\Build\\";
	string func_name1[3] = { "GetRangeValueFromVector","GetAverageValueFromVector","GetAverageValueFromMatrix" };

	ExecuteSTD_DLL("DllVisualCPP.dll", func_name1);
	ExecuteSTD_DLL("Dll_CPP_Builder.dll", func_name1);
	ExecuteSTD_DLL("Dll_Lazarus.dll", func_name1);

	int pause;
	cin >> pause;
	return 1;
}