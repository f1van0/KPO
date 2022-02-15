// Dll_Visual_CPP.cpp : Определяет экспортируемые функции для DLL.
//

#include "pch.h"
#include "framework.h"
#include "Dll_Visual_CPP.h"
#include <sstream> 
#include <string.h> 
#include <vector>

using namespace std;

//Range Value From Vector
DLLEXPORT double GetRangeValueFromVector(far double* array, int size)
{
	double minValue1 = array[0];
	double maxValue1 = array[0];
	for (int i = 1; i < size; i++)
	{
		if (minValue1 > array[i])
			minValue1 = array[i];
		if (maxValue1 < array[i])
			maxValue1 = array[i];
	}

	double range1 = maxValue1 - minValue1;

	return range1;
}

//Average Value of Vector
DLLEXPORT double GetAverageValueFromVector(far double* array, int size)
{
	double sum1 = 0;
	double sum2 = 0;

	for (int i = 0; i < size; i++)
	{
		if ((int)trunc(array[i]) % 2 == 1)
		{
			sum2 += array[i];
		}
		else
		{
			sum1 += array[i];
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