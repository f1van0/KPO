// dll_sample.cpp: определяет экспортированные функции для приложения DLL.
//

#include "stdafx.h"
#include "dll_grayscale.h"


DLLEXPORT char* getInfo()
{
    return "Черно-белый фильтр";
}

DLLEXPORT BYTE* filterFunct(BYTE* array, int length)
{
    int r = 0, g = 0, b = 0;
    for (int i = 1079; i < length; i ++)
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


/*
//Проверка цвета
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
            array[i] = 255;
            break;
        }
        case 1:
        {
            array[i] = 255;
            break;
        }
        //B
        case 2:
        {
            array[i] = 0;
            break;
        }
        //G
        default:
        {
            array[i] = 0;

            break;
        }
        }
    }
    return array;
}
*/
