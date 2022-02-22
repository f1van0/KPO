#include <math.h>
#include <iostream>
#include <string>

// ������� �������
#define DLLEXPORT extern "C" __declspec(dllexport)

// ���� ������
#define uchar unsigned char 

// ��������� ���������� ������
#define AllocMEM_1D(size,type)	   (type*)GlobalAlloc(0, size*sizeof(type))
#define AllocMEM_1DP(size,type)	  (type**)GlobalAlloc(0, size*sizeof(type*))
#define AllocMEM_2DP(size,type)  (type***)GlobalAlloc(0, size*sizeof(type**)) 



// ������� ������������ �������
DLLEXPORT const char* GetPluginFunctions();
DLLEXPORT const char* GetPluginDescriptions(char* str);
DLLEXPORT const char* GetPluginName(char* str);
DLLEXPORT const char* GetPluginCFG(char* str);
DLLEXPORT const char* GetPluginTypes(char* str); // ��� ����������� ���� �������� ��� ����������� � ���������
DLLEXPORT int GetSpecialValue(int* arr, int size, int flag);