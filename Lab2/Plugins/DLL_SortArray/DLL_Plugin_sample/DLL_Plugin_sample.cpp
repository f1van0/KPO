// DLL_Plugin_sample.cpp: ���������� ���������������� ������� ��� ���������� DLL.
//

#include "stdafx.h"
#include "PluginBase.h"
#include <omp.h>


// ������� ������������ ������� ����������

DLLEXPORT const char* PluginFunctions()
{
	return "Brightes_Correction Message";
}

DLLEXPORT const char* PluginDescriptions(char * str)
{
	if (strcmp(str, "Brightes_Correction") == 0) return "Brightness correction in YUV mode";
	if (strcmp(str, "Message") == 0) return "some sample message";
	return "Not found";
}

DLLEXPORT const char* PluginCFG(char * str)
{
	if (strcmp(str, "Brightes_Correction") == 0) return "Label;L1;10;10;Brightness change!TrackBar;INPUT_1;10;30;150;0;510;255;255;1!Label;LBINPUT_1;170;40;0!1";
	if (strcmp(str, "Message") == 0) return "";
	return "Label;L1;10;10;Not found!0";
}

DLLEXPORT const char* GetPluginType(char * str)
{
	if (strcmp(str, "Brightes_Correction") == 0) return "IMG2IMG";  // ����� ��� ������
	if (strcmp(str, "Message") == 0) return "MSGBox";  // ����� ������������ � ����
	return "Not found";
}

DLLEXPORT const char* PluginLabName(char * str)
{
	if (strcmp(str, "Brightes_Correction") == 0) return "��������� �������";
	if (strcmp(str, "Message") == 0) return "�������� ���������";
	return "Not found";
}

/// �������� �������������� �������
DLLEXPORT double Brightes_Correction(unsigned char *InIMG, unsigned char *OutIMG, const int Width, const int Heigth, char * str);
DLLEXPORT const char* Message();


// ���������������� ���������� �������

const char* Message()
{
	return "�������� ��������� ��� ������ �� ����� 1";
}

double Brightes_Correction(unsigned char *InIMG, unsigned char *OutIMG, const int Width, const int Heigth, char * str)
{
	double BLUT[256];
	int offset = 0, mode = 1;
	double time_s = omp_get_wtime();
	sscanf_s(str, "%d", &offset);

#pragma omp parallel for
	for (int i = 0; i<256; i++)
	{
		BLUT[i] = i + offset;
	}

	unsigned char r, g, b;
	double Yy, u, v;
	int rowSize = Width * 4;

	for (int dy = 0; dy<Heigth; dy++)
	{
		int y = dy*rowSize;
		for (int kx = 0; kx<Width; kx++)
		{
			int pos = kx * 4 + y;
			b = InIMG[pos];
			g = InIMG[pos + 1];
			r = InIMG[pos + 2];
			RGBToYUV(r, g, b, Yy, u, v);
			Yy = BLUT[int(Yy)];
			YUVToRGB(Yy, u, v, r, g, b);
			OutIMG[pos] = b;
			OutIMG[pos + 1] = g;
			OutIMG[pos + 2] = r;
		}
	}

	return  omp_get_wtime() - time_s;
}