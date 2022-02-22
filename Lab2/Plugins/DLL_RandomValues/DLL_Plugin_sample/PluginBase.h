#include <math.h>
#include <iostream>
#include <string>

// ������� �������
#define DLLEXPORT extern "C" __declspec(dllexport)

// ������� ������������ �������
DLLEXPORT const char* GetPluginFunctions();
DLLEXPORT const char* GetPluginDescriptions(char* str);
DLLEXPORT const char* GetPluginName(char* str);
DLLEXPORT const char* GetPluginCFG(char* str);
DLLEXPORT const char* GetPluginTypes(char* str); // ��� ����������� ���� �������� ��� ����������� � ���������
DLLEXPORT int* GetArray(int minValue, int maxValue, int size);