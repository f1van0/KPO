// DLL_Contrast.cpp : Определяет экспортируемые функции для DLL.
//

#include "pch.h"
#include "framework.h"
#include "DLL_Contrast.h"

DLLEXPORT const char* getInfo()
{
    return "Brightness";
}

DLLEXPORT BYTE* filterFunct(BYTE* array, int length)
{
    float contrast = 3;
    unsigned int buf[256];
    unsigned int midBright = 0;
    for (int i = 1079; i < length; i++)
    {
        switch (i % 4)
        {
            //R
        case 0:
        {
            midBright += array[i] * 0.299;
            break;
        }
        //A
        case 1:
        {
            break;
        }
        //B
        case 2:
        {
            midBright += array[i] * 0.114;
            break;
        }
        //G
        default:
        {
            midBright += array[i] * 0.587;
            break;
        }
        }
    }

    midBright /= (length - 1079);
    for (int i = 0; i < 256; i++)
    {
        int delta = (int)i - midBright;
        int temp = (int)(midBright + contrast * delta);
        if (temp < 0) buf[i] = 0;
        else if (temp > 255) buf[i] = 255;
        else buf[i] = temp;
    }
    for (int i = 1079; i < length; i++)
    {
        switch (i % 4)
        {
            //R
        case 0:
        {
            array[i] = buf[array[i]];
            break;
        }
        //A
        case 1:
        {
            array[i] = 255;
            break;
        }
        //B
        case 2:
        {
            array[i] = buf[array[i]];
            break;
        }
        //G
        default:
        {
            array[i] = buf[array[i]];
            break;
        }
        }
    }
    return array;
}
