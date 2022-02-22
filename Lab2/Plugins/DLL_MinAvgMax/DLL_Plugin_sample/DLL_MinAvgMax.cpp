// DLL_Plugin_sample.cpp: определяет экспортированные функции для приложения DLL.
//

#include "stdafx.h"
#include "PluginBase.h"
#include <omp.h>


// Простые интерфейсные функции Реализация
DLLEXPORT const char* GetPluginFunctions()
{
	return "GetSpecialValue";
}

DLLEXPORT const char* GetPluginDescriptions(char* str)
{
	if (strcmp(str, "GetSpecialValue") == 0) return "Finds the minimum, maximum, and arithmetic mean and returns the one that was selected";
	return "Not found";
}

DLLEXPORT const char* GetPluginCFG(char* str)
{
	if (strcmp(str, "GetSpecialValue") == 0) return "RadioButton;Return min value;MinValue;5;RadioButton;Return average value;AvgValue;5;RadioButton;Return max value;MaxValue;5";
	return "Label;Not found;ErrorLabel;0";
}

DLLEXPORT const char* GetPluginTypes(char* str)
{
	if (strcmp(str, "GetSpecialValue") == 0) return "ArrToVar";  // будет как список
	return "Not found";
}

DLLEXPORT const char* GetPluginName(char* str)
{
	if (strcmp(str, "GetSpecialValue") == 0) return "Special Value Returner";
	return "Not found";
}


// Непосредственное реализация методов
DLLEXPORT int GetSpecialValue(int* arr, int size, int flag)
{
	int minValue = arr[0];
	int maxValue = arr[0];
	int avgValue = 0;
	int totalValue = 0;
	for (int i = 0; i < size; i++)
	{
		if (minValue > arr[i])
			minValue = arr[i];
		if (maxValue < arr[i])
			maxValue = arr[i];
		totalValue += arr[i];
	}
	avgValue = totalValue / size;

	switch(flag)
	{
	case 0:
		return minValue;
	case 1:
		return avgValue;
	default:
		return maxValue;
	}
}