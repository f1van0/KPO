//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H

//typedef double (__cdecl*FdoubleOps)(double, double);
//typedef int (__cdecl*FmasProc)(double*,int,double, double);
//typedef int (__cdecl*FmasProcX)(void*,int,int);

//typedef double (__stdcall*FdoubleOps2)(double, double);
//typedef int (__stdcall*FmasProc2)(double*,int,double, double);
//typedef int (__stdcall*FmasProcX2)(void*,int,int);

typedef double (__cdecl*VectorTypeCDECL)(double*, int);
typedef double (__cdecl*MatrixTypeCDECL)(double**, int);

typedef double (__stdcall*VectorTypeSTD)(double*, int);
typedef double (__stdcall*MatrixTypeSTD)(double**, int);

//---------------------------------------------------------------------------
#include <Classes.hpp>
#include <Controls.hpp>
#include <StdCtrls.hpp>
#include <Forms.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TMemo *Memo1;
	TButton *Button1;
	TButton *Button2;
	TButton *Button3;
	void __fastcall Button2Click(TObject *Sender);
	void __fastcall Button1Click(TObject *Sender);
	void __fastcall Button3Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
