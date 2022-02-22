#include <math.h>
#include <iostream>

// Экспорт Функций
#define DLLEXPORT extern "C" __declspec(dllexport)

// Простые интерфейсные функции
DLLEXPORT const char* GetPluginFunctions();
DLLEXPORT const char* GetPluginDescriptions(char* str);
DLLEXPORT const char* GetPluginName(char* str);
DLLEXPORT const char* GetPluginCFG(char* str);
DLLEXPORT const char* GetPluginTypes(char* str); // для определения типа например для встраивание в интерфейс