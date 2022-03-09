// DLL_Contrast.cpp : Определяет экспортируемые функции для DLL.
//

#include "pch.h"
#include "framework.h"
#include "DLL_Grayscale.h"

DLLEXPORT const char* getInfo()
{
    return "Grayscale";
}

DLLEXPORT BYTE* filterFunct(BYTE* array, int length)
{
    int r = 0, g = 0, b = 0;
    for (int i = 1079; i < length; i++)
    {

        switch (i % 4)
        {
            //R
        case 0:
        {
            r = array[i];
            break;
        }
        case 1:
        {
            break;
        }
        //B
        case 2:
        {
            b = array[i];
            break;
        }
        //G
        default:
        {
            g = array[i];
            array[i] = 0.2126 * r + 0.7152 * g + 0.0722 * b;
            array[i - 1] = 0.2126 * r + 0.7152 * g + 0.0722 * b;
            array[i - 2] = 0.2126 * r + 0.7152 * g + 0.0722 * b;
            array[i - 3] = 0.2126 * r + 0.7152 * g + 0.0722 * b;

            break;
        }
        }
    }
    return array;
}
