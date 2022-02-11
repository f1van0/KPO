#pragma once
#include "pch.h"
#include <windows.h>
#include <iostream>

#define DLLEXPORT extern "C" __declspec(dllexport)

DLLEXPORT double GetRangeValueFromVector(far double* array, int size);
DLLEXPORT double GetAverageValueFromVector(far double* array, int size);
DLLEXPORT double GetAverageValueFromMatrix(far double** matrix, int size);
