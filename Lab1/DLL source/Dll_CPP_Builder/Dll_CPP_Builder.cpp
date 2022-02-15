//---------------------------------------------------------------------------

#include <windows.h>
#include <math.h>
//---------------------------------------------------------------------------
//   Important note about DLL memory management when your DLL uses the
//   static version of the RunTime Library:
//
//   If your DLL exports any functions that pass String objects (or structs/
//   classes containing nested Strings) as parameter or function results,
//   you will need to add the library MEMMGR.LIB to both the DLL project and
//   any other projects that use the DLL.  You will also need to use MEMMGR.LIB
//   if any other projects which use the DLL will be performing new or delete
//   operations on any non-TObject-derived classes which are exported from the
//   DLL. Adding MEMMGR.LIB to your project will change the DLL and its calling
//   EXE's to use the BORLNDMM.DLL as their memory manager.  In these cases,
//   the file BORLNDMM.DLL should be deployed along with your DLL.
//
//   To avoid using BORLNDMM.DLL, pass string information using "char *" or
//   ShortString parameters.
//
//   If your DLL uses the dynamic version of the RTL, you do not need to
//   explicitly add MEMMGR.LIB as this will be done implicitly for you
//---------------------------------------------------------------------------

#pragma argsused

#define DLLEXPORT extern "C" __declspec(dllexport)  __stdcall

DLLEXPORT double GetRangeValueFromVector(far double*arr, int size);
DLLEXPORT double GetAverageValueFromVector(far double*arr, int size);
DLLEXPORT double GetAverageValueFromMatrix(far double** matrix, int size);

#pragma argsused

BOOL WINAPI DllMain(HINSTANCE hinstDLL, DWORD fwdreason, LPVOID lpvReserved)
{
	return 1;
}

DLLEXPORT double GetRangeValueFromVector(far double* arr, int size)
{
	double minValue = arr[0];
	double maxValue = arr[0];
	for (int i = 1; i < size; i++)
	{
		if (minValue > arr[i])
			minValue = arr[i];
		if (maxValue < arr[i])
			maxValue = arr[i];
	}

	double range = maxValue - minValue;

	return range;
}

//Average Value of Vector
DLLEXPORT double GetAverageValueFromVector(far double* arr, int size)
{
	double sum1 = 0;
	double sum2 = 0;

	for (int i = 0; i < size; i++)
	{
		if ((int)(arr[i]) % 2 == 1)
		{
			sum2 += arr[i];
		}
		else
		{
			sum1 += arr[i];
		}
	}

	return (sum1 + sum2) / size;
}

//Average Value of Matrix
DLLEXPORT double GetAverageValueFromMatrix(far double** matrix, int size)
{
	double sum = 0;

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			sum += matrix[j][i];
		}
	}

	double averageValue = sum / (size * size);
	sum = 0;

	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			if (matrix[j][i] > averageValue || i == j)
			{
				sum += matrix[j][i];
			}
		}
	}

	return sum;
}



//---------------------------------------------------------------------------
