// ---------------------------------------------------------------------------

#include <vcl.h>
#include <math.h>
#pragma hdrstop

#include "Unit1.h"
// ---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;

int arraySize = 100000;
int matrixSize = 650;
int iterations = 50;

double* GetArray(int size)
{
	double* newArray = new double[size];
	for (int i = 0; i < size; i++)
	{
		newArray[i] = size * std::pow((double)i + 1, 3 / 4) * std::cos((double)i) / std::atan((double)i + 1);
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

/*
void ExecuteSTD_DLL(std::string dll_name, std::string* func_name)
{
	int arraySize = 100000;
	int matrixSize = 650;
	int iterations = 50;

	double 	Ftime;
	ULONGLONG  FFrequence, FBeginCount,  FEndCount;

	std::wstring dll_load_name(dll_name.begin(), dll_name.end());

	VectorTypeSTD GetRangeValueFromVector, GetAverageValueFromVector;
	MatrixTypeSTD GetAverageValueFromMatrix;

	double result = 0;

	double* array = GetArray(arraySize);
	double** matrix = GetMatrix(matrixSize);

	Memo1->Lines->Clear();
	cout << dll_name << endl;

	HINSTANCE hinstLib = LoadLibrary(dll_load_name.c_str());
	if (hinstLib == NULL) {
		Memo1->Lines->Add("ERROR: unable to load DLL: " + dll_load_name.c_str());
		return;
	}

	Memo1->Lines->Add("library (" + dll_load_name.c_str() + ") loaded");

	GetRangeValueFromVector = (VectorTypeSTD)GetProcAddress(hinstLib, "GetRangeValueFromVector");
	if (GetRangeValueFromVector != NULL) {
		QueryPerformanceFrequency((LARGE_INTEGER*)&FFrequence);
		QueryPerformanceCounter((LARGE_INTEGER*)&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetRangeValueFromVector(array, arraySize);
		}
		QueryPerformanceCounter((LARGE_INTEGER*)&FEndCount);
		Ftime = ((FEndCount.QuadPart - FBeginCount.QuadPart) / (double)FFrequence.QuadPart) * 1000 / iterations;
		Memo1->Lines->Add(Ftime + " ms.\n");
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function ("+ func_name[0] +")\n");
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
		Memo1->Lines->Add(Ftime + " ms.\n");
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function ("+ func_name[1] +")\n");
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
		Memo1->Lines->Add(Ftime + " ms.\n");
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function ("+ func_name[2] +")\n");
		return;
	}

	FreeLibrary(hinstLib);
}

void ExecuteCDECL_DLL(std::string dll_name, std::string* func_name)
{
	int arraySize = 100000;
	int matrixSize = 650;
	int iterations = 50;

	double 	Ftime;
	ULONGLONG  FFrequence, FBeginCount,  FEndCount;

	std::wstring dll_load_name(dll_name.begin(), dll_name.end());

	VectorTypeCDECL GetRangeValueFromVector, GetAverageValueFromVector;
	MatrixTypeCDECL GetAverageValueFromMatrix;

	double result = 0;

	double* array = GetArray(arraySize);
	double** matrix = GetMatrix(matrixSize);

	Memo1->Lines->Clear();
	cout << dll_name << endl;

	HINSTANCE hinstLib = LoadLibrary(dll_load_name.c_str());
	if (hinstLib == NULL) {
		Memo1->Lines->Add("ERROR: unable to load DLL: " + dll_load_name.c_str());
		return;
	}

	Memo1->Lines->Add("library (" + dll_load_name.c_str() + ") loaded");

	GetRangeValueFromVector = (VectorTypeCDECL)GetProcAddress(hinstLib, "GetRangeValueFromVector");
	if (GetRangeValueFromVector != NULL) {
		QueryPerformanceFrequency((LARGE_INTEGER*)&FFrequence);
		QueryPerformanceCounter((LARGE_INTEGER*)&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetRangeValueFromVector(array, arraySize);
		}
		QueryPerformanceCounter((LARGE_INTEGER*)&FEndCount);
		Ftime = ((FEndCount.QuadPart - FBeginCount.QuadPart) / (double)FFrequence.QuadPart) * 1000 / iterations;
		Memo1->Lines->Add(Ftime + " ms.\n");
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function ("+ func_name[0] +")\n");
		return;
	}



	GetAverageValueFromVector = (VectorTypeCDECL)GetProcAddress(hinstLib, "GetAverageValueFromVector");
	if (GetAverageValueFromVector != NULL) {
		QueryPerformanceFrequency(&FFrequence);
		QueryPerformanceCounter(&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetAverageValueFromVector(array, arraySize);
		}
		QueryPerformanceCounter(&FEndCount);
		Ftime = ((FEndCount.QuadPart - FBeginCount.QuadPart) / (double)FFrequence.QuadPart) * 1000 / iterations;
		Memo1->Lines->Add(Ftime + " ms.\n");
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function ("+ func_name[1] +")\n");
		return;
	}


	GetAverageValueFromMatrix = (MatrixTypeCDECL)GetProcAddress(hinstLib, "GetAverageValueFromMatrix");
	if (GetAverageValueFromMatrix != NULL) {
		QueryPerformanceFrequency(&FFrequence);
		QueryPerformanceCounter(&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetAverageValueFromMatrix(matrix, matrixSize);
		}
		QueryPerformanceCounter(&FEndCount);
		Ftime = ((FEndCount.QuadPart - FBeginCount.QuadPart) / (double)FFrequence.QuadPart) * 1000 / iterations;
		Memo1->Lines->Add(Ftime + " ms.\n");
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function ("+ func_name[2] +")\n");
		return;
	}

	FreeLibrary(hinstLib);
}
 */


// ---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner) : TForm(Owner)
{
//	funcNames = new string[3];
//	funcNames[0] = "GetRangeValueFromVector";
//	funcNames[1] = "GetAverageValueFromVector";
//	funcNames[2] = "GetAverageValueFromMatrix";
}

// ---------------------------------------------------------------------------
void __fastcall TForm1::Button1Click(TObject *Sender)
{
	double 	Ftime;
	ULONGLONG  FFrequence, FBeginCount,  FEndCount;

	VectorTypeSTD GetRangeValueFromVector, GetAverageValueFromVector;
	MatrixTypeSTD GetAverageValueFromMatrix;

	double result = 0;

	double* array = GetArray(arraySize);
	double** matrix = GetMatrix(matrixSize);

	Memo1->Lines->Clear();

	HINSTANCE hinstLib = LoadLibrary("DllVisualCPP.dll");
	if (hinstLib == NULL) {
		Memo1->Lines->Add("ERROR: unable to load DLL: DllVisualCPP.dll");
		return;
	}

	Memo1->Lines->Add("library (DllVisualCPP.dll) loaded");

	GetRangeValueFromVector = (VectorTypeSTD)GetProcAddress(hinstLib, "GetRangeValueFromVector");
	if (GetRangeValueFromVector != NULL) {
		QueryPerformanceFrequency((LARGE_INTEGER*)&FFrequence);
		QueryPerformanceCounter((LARGE_INTEGER*)&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetRangeValueFromVector(array, arraySize);
		}
		QueryPerformanceCounter((LARGE_INTEGER*)&FEndCount);
		Ftime = ((FEndCount - FBeginCount) / (double)FFrequence) * 1000 / iterations;
		Memo1->Lines->Add(Ftime);
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function (GetRangeValueFromVector)\n");
		return;
	}



	GetAverageValueFromVector = (VectorTypeSTD)GetProcAddress(hinstLib, "GetAverageValueFromVector");
	if (GetAverageValueFromVector != NULL) {
		QueryPerformanceFrequency((LARGE_INTEGER*)&FFrequence);
		QueryPerformanceCounter((LARGE_INTEGER*)&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetAverageValueFromVector(array, arraySize);
		}
		QueryPerformanceCounter((LARGE_INTEGER*)&FEndCount);
		Ftime = ((FEndCount - FBeginCount) / (double)FFrequence) * 1000 / iterations;
		Memo1->Lines->Add(Ftime);
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function (GetAverageValueFromVector)\n");
		return;
	}


	GetAverageValueFromMatrix = (MatrixTypeSTD)GetProcAddress(hinstLib, "GetAverageValueFromMatrix");
	if (GetAverageValueFromMatrix != NULL) {
		QueryPerformanceFrequency((LARGE_INTEGER*)&FFrequence);
		QueryPerformanceCounter((LARGE_INTEGER*)&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetAverageValueFromMatrix(matrix, matrixSize);
		}
		QueryPerformanceCounter((LARGE_INTEGER*)&FEndCount);
		Ftime = ((FEndCount - FBeginCount) / (double)FFrequence) * 1000 / iterations;
		Memo1->Lines->Add(Ftime);
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function (GetAverageValueFromMatrix)\n");
		return;
	}

	FreeLibrary(hinstLib);
}

// ---------------------------------------------------------------------------
void __fastcall TForm1::Button2Click(TObject *Sender)
{
	double 	Ftime;
	ULONGLONG  FFrequence, FBeginCount,  FEndCount;

	VectorTypeSTD GetRangeValueFromVector, GetAverageValueFromVector;
	MatrixTypeSTD GetAverageValueFromMatrix;

	double result = 0;

	double* array = GetArray(arraySize);
	double** matrix = GetMatrix(matrixSize);

	Memo1->Lines->Clear();

	HINSTANCE hinstLib = LoadLibrary("Dll_CPP_Builder.dll");
	if (hinstLib == NULL) {
		Memo1->Lines->Add("ERROR: unable to load DLL: Dll_CPP_Builder.dll");
		return;
	}

	Memo1->Lines->Add("library (Dll_CPP_Builder.dll) loaded");

	GetRangeValueFromVector = (VectorTypeSTD)GetProcAddress(hinstLib, "GetRangeValueFromVector");
	if (GetRangeValueFromVector != NULL) {
		QueryPerformanceFrequency((LARGE_INTEGER*)&FFrequence);
		QueryPerformanceCounter((LARGE_INTEGER*)&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetRangeValueFromVector(array, arraySize);
		}
		QueryPerformanceCounter((LARGE_INTEGER*)&FEndCount);
		Ftime = ((FEndCount - FBeginCount) / (double)FFrequence) * 1000 / iterations;
		Memo1->Lines->Add(Ftime);
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function (GetRangeValueFromVector)\n");
		return;
	}



	GetAverageValueFromVector = (VectorTypeSTD)GetProcAddress(hinstLib, "GetAverageValueFromVector");
	if (GetAverageValueFromVector != NULL) {
		QueryPerformanceFrequency((LARGE_INTEGER*)&FFrequence);
		QueryPerformanceCounter((LARGE_INTEGER*)&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetAverageValueFromVector(array, arraySize);
		}
		QueryPerformanceCounter((LARGE_INTEGER*)&FEndCount);
		Ftime = ((FEndCount - FBeginCount) / (double)FFrequence) * 1000 / iterations;
		Memo1->Lines->Add(Ftime);
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function (GetAverageValueFromVector)\n");
		return;
	}


	GetAverageValueFromMatrix = (MatrixTypeSTD)GetProcAddress(hinstLib, "GetAverageValueFromMatrix");
	if (GetAverageValueFromMatrix != NULL) {
		QueryPerformanceFrequency((LARGE_INTEGER*)&FFrequence);
		QueryPerformanceCounter((LARGE_INTEGER*)&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetAverageValueFromMatrix(matrix, matrixSize);
		}
		QueryPerformanceCounter((LARGE_INTEGER*)&FEndCount);
		Ftime = ((FEndCount - FBeginCount) / (double)FFrequence) * 1000 / iterations;
		Memo1->Lines->Add(Ftime);
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function (GetAverageValueFromMatrix)\n");
		return;
	}

	FreeLibrary(hinstLib);
}
void __fastcall TForm1::Button3Click(TObject *Sender)
{
	double 	Ftime;
	ULONGLONG  FFrequence, FBeginCount,  FEndCount;

	VectorTypeSTD GetRangeValueFromVector, GetAverageValueFromVector;
	MatrixTypeSTD GetAverageValueFromMatrix;

	double result = 0;

	double* array = GetArray(arraySize);
	double** matrix = GetMatrix(matrixSize);

	Memo1->Lines->Clear();

	HINSTANCE hinstLib = LoadLibrary("Dll_Lazarus.dll");
	if (hinstLib == NULL) {
		Memo1->Lines->Add("ERROR: unable to load DLL: Dll_Lazarus.dll");
		return;
	}

	Memo1->Lines->Add("library (Dll_Lazarus.dll) loaded");

	GetRangeValueFromVector = (VectorTypeSTD)GetProcAddress(hinstLib, "GetRangeValueFromVector");
	if (GetRangeValueFromVector != NULL) {
		QueryPerformanceFrequency((LARGE_INTEGER*)&FFrequence);
		QueryPerformanceCounter((LARGE_INTEGER*)&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetRangeValueFromVector(array, arraySize);
		}
		QueryPerformanceCounter((LARGE_INTEGER*)&FEndCount);
		Ftime = ((FEndCount - FBeginCount) / (double)FFrequence) * 1000 / iterations;
		Memo1->Lines->Add(Ftime);
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function (GetRangeValueFromVector)\n");
		return;
	}



	GetAverageValueFromVector = (VectorTypeSTD)GetProcAddress(hinstLib, "GetAverageValueFromVector");
	if (GetAverageValueFromVector != NULL) {
		QueryPerformanceFrequency((LARGE_INTEGER*)&FFrequence);
		QueryPerformanceCounter((LARGE_INTEGER*)&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetAverageValueFromVector(array, arraySize);
		}
		QueryPerformanceCounter((LARGE_INTEGER*)&FEndCount);
		Ftime = ((FEndCount - FBeginCount) / (double)FFrequence) * 1000 / iterations;
		Memo1->Lines->Add(Ftime);
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function (GetAverageValueFromVector)\n");
		return;
	}


	GetAverageValueFromMatrix = (MatrixTypeSTD)GetProcAddress(hinstLib, "GetAverageValueFromMatrix");
	if (GetAverageValueFromMatrix != NULL) {
		QueryPerformanceFrequency((LARGE_INTEGER*)&FFrequence);
		QueryPerformanceCounter((LARGE_INTEGER*)&FBeginCount);
		for (int i = 0; i < iterations; i++)
		{
			result = GetAverageValueFromMatrix(matrix, matrixSize);
		}
		QueryPerformanceCounter((LARGE_INTEGER*)&FEndCount);
		Ftime = ((FEndCount - FBeginCount) / (double)FFrequence) * 1000 / iterations;
		Memo1->Lines->Add(Ftime);
	}
	else
	{
		Memo1->Lines->Add("ERROR: unable to find DLL function (GetAverageValueFromMatrix)\n");
		return;
	}

	FreeLibrary(hinstLib);
}


//---------------------------------------------------------------------------

