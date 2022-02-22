// DLL_Plugin_sample.cpp: определяет экспортированные функции для приложения DLL.
//

#include "stdafx.h"
#include "PluginBase.h"
#include <omp.h>


// Простые интерфейсные функции Реализация
DLLEXPORT const char* GetPluginFunctions()
{
	return "BubbleSort ShellSort";
}

DLLEXPORT const char* GetPluginDescriptions(char* str)
{
	if (strcmp(str, "BubbleSort") == 0) return "Sorts an array by the bubble algorithm";
	else if (strcmp(str, "ShellSort") == 0) return "Sorts an array by the Shell's algorithm";
	return "Not found";
}

DLLEXPORT const char* GetPluginCFG(char* str)
{
	if (strcmp(str, "BubbleSort") == 0) return "RadioButton;Sort Ascending;Ascending;5;RadioButton;Sort Descending;Descending;5";
	else if (strcmp(str, "ShellSort") == 0) return "RadioButton;Sort Ascending;Ascending;5;RadioButton;Sort Descending;Descending;5";
	return "Label;Not found;ErrorLabel;0";
}

DLLEXPORT const char* GetPluginTypes(char* str)
{
	if (strcmp(str, "BubbleSort") == 0) return "ArrToArr";
	else if (strcmp(str, "ShellSort") == 0) return "ArrToArr";
	return "Not found";
}

DLLEXPORT const char* GetPluginName(char* str)
{
	if (strcmp(str, "BubbleSort") == 0) return "BubbleSort";
	else if (strcmp(str, "ShellSort") == 0) return "ShellSort";
	return "Not found";
}


// Непосредственное реализация методов
DLLEXPORT int* BubbleSort(int* arr, int sign, int size)
{
	bool isSwapped = true;
	while (isSwapped)
	{
		for (int i = 0; i < 10; i++) {
			isSwapped = false;
			for (int j = 0; j < 10 - (i + 1); j++) {
				if (arr[j] * sign > arr[j + 1] * sign) {
					isSwapped = true;
					std::swap(arr[j], arr[j + 1]);
				}
			}
			if (!isSwapped) {
				break;
			}
		}
	}
	return  arr;
}

DLLEXPORT int* ShellSort(int* arr, int sign, int size)
{
	for (int gap = size / 2; gap > 0; gap /= 2) {
		for (int i = gap; i < size; i += 1) {
			int temp = arr[i];
			int j;
			
			for (j = i; j >= gap && arr[j - gap] * sign > temp * sign; j -= gap)
				arr[j] = arr[j - gap];

			arr[j] = temp;
		}
	}

	return arr;
}