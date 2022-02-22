#include <math.h>
#include <iostream>
#include <string>

// Экспорт Функций
#define DLLEXPORT extern "C" __declspec(dllexport)

// Типы данных
#define uchar unsigned char 

// Выделение Глобальной памяти
#define AllocMEM_1D(size,type)	   (type*)GlobalAlloc(0, size*sizeof(type))
#define AllocMEM_1DP(size,type)	  (type**)GlobalAlloc(0, size*sizeof(type*))
#define AllocMEM_2DP(size,type)  (type***)GlobalAlloc(0, size*sizeof(type**)) 



// Простые интерфейсные функции
DLLEXPORT const char* GetPluginFunctions();
DLLEXPORT const char* GetPluginDescriptions(char* str);
DLLEXPORT const char* GetPluginName(char* str);
DLLEXPORT const char* GetPluginCFG(char* str);
DLLEXPORT const char* GetPluginTypes(char* str); // для определения типа например для встраивание в интерфейс
DLLEXPORT int GetSpecialValue(int* arr, int size, int flag);