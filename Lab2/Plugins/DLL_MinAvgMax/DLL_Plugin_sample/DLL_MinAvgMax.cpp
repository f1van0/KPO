// DLL_Plugin_sample.cpp: определяет экспортированные функции для приложения DLL.
//

#include "stdafx.h"
#include "PluginBase.h"
#include <omp.h>


// Простые интерфейсные функции Реализация
DLLEXPORT const char* GetPluginFunctions()
{
	return "GetArray";
}

DLLEXPORT const char* GetPluginDescriptions(char* str)
{
	if (strcmp(str, "GetArray") == 0) return "Generates an array based on the passed values of the number of elements, minimum and maximum";
	return "Not found";
}

DLLEXPORT const char* GetPluginCFG(char* str)
{
	if (strcmp(str, "GetArray") == 0) return "NumericUpDown;Enter minimum value;MinValue;6;NumericUpDown;Enter maximum value;MaxValue;6;NumericUpDown;Enter size of array;Size;0";
	return "Label;Not found;ErrorLabel;0";
}

DLLEXPORT const char* GetPluginTypes(char* str)
{
	if (strcmp(str, "GetArray") == 0) return "VarsToArr";  // будет как список
	return "Not found";
}

DLLEXPORT const char* GetPluginName(char* str)
{
	if (strcmp(str, "GetArray") == 0) return "Random Values Generator";
	return "Not found";
}


// Непосредственное реализация методов
DLLEXPORT int* GetArray(int size, int minValue, int maxValue)
{
	int* newArray = new int[size];
	for (int i = 0; i < size; i++)
	{
		newArray[i] = rand() % (maxValue - minValue) + minValue;
	}
	return  newArray;
}