#include "stdafx.h"
#include "PluginBase.h"
#include <omp.h>


// ������� ������������ ������� ����������
DLLEXPORT const char* GetPluginFunctions()
{
	return "GetArray";
}

DLLEXPORT const char* GetPluginDescriptions(char* str)
{
	if (strcmp(str, "GetArray") == 0) return "Generates an array based on the passed values of the number of elements, minimum and maximum\nVersion: 1.0\nAuthor: Frolov Ivan BPI19-01\n";
	return "Not found";
}

DLLEXPORT const char* GetPluginCFG(char* str)
{
	if (strcmp(str, "GetArray") == 0) return "NumericUpDown;Enter minimum value;MinValue;6;NumericUpDown;Enter maximum value;MaxValue;6;NumericUpDown;Enter size of array;Size;0";
	return "Label;Not found;ErrorLabel;0";
}

DLLEXPORT const char* GetPluginTypes(char* str)
{
	if (strcmp(str, "GetArray") == 0) return "VarsToArr";  // ����� ��� ������
	return "Not found";
}

DLLEXPORT const char* GetPluginName(char* str)
{
	if (strcmp(str, "GetArray") == 0) return "Random Values Generator";
	return "Not found";
}


// ���������������� ���������� �������
DLLEXPORT int* GetArray(int minValue, int maxValue, int size)
{
	srand(std::time(nullptr));
	int* newArray = new int[size];
	for (int i = 0; i < size; i++)
	{
		if (maxValue - minValue == 0)
			maxValue++;

		newArray[i] = rand() % (maxValue - minValue) + minValue;
	}
	return  newArray;
}