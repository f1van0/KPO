// dll_sample.cpp: определяет экспортированные функции для приложения DLL.
//

#include "stdafx.h"
#include "dll_contrast.h"


DLLEXPORT char* getInfo()
{
    return "Увеличение яркости";
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

/*
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
*/

/*
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
*/

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
