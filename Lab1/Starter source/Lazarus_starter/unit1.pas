unit Unit1;

{$mode objfpc}{$H+}

interface

uses
  Classes, SysUtils, Forms, Controls, Graphics, Dialogs, StdCtrls, dynlibs, Math, Windows;

type
  FdoubleOps = function(a, b: double): double; cdecl;
  TDoubleArray = array[word] of double;
  PDoubleArray = ^TDoubleArray;
  T2dArray = array of array of double;
  P2dArray = ^T2dArray;

  FmasProc = function(mas: PDoubleArray; size: integer; a, b: double): integer; cdecl;
  fillmas2d = function(mas: T2dArray; H, W: integer): integer; cdecl;


  FdoubleOps2 = function(a, b: double): double; stdcall;
  FmasProc2 = function(mas: PDoubleArray; size: integer; a, b: double): integer; stdcall;
  fillmas2d2 = function(mas: T2dArray; H, W: integer): integer; stdcall;

  VectorTypeCDECL = function(mas: PDoubleArray; size: integer): double; cdecl;
  MatrixTypeCDECL = function(mas: P2dArray; size: integer): double; cdecl;

  VectorTypeSTD = function(mas: PDoubleArray; size: integer): double; stdcall;
  MatrixTypeSTD = function(mas: T2dArray; size: integer): double; stdcall;

// Константы с названием функций
const
  sizeArray: integer = 100000;
  sizeMatrix: integer = 650;
  iterations: integer = 50;
  func_name1: array [0..2] of string = ('GetRangeValueFromVector', 'GetAverageValueFromVector', 'GetAverageValueFromMatrix');
  func_name1_CBuilder_cdecl: array [0..5] of string =
    ('_Add', '_Subtract', '_Multiply', '_Divide',
    '_Fill_1D_Array', '_Fill_2D_Array');
  func_name1_CBuilder_stdcall: array [0..5] of string =
    ('Add', 'Subtract', 'Multiply', 'Divide',
    'Fill_1D_Array', 'Fill_2D_Array');


type

  { TForm1 }

  TForm1 = class(TForm)
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Memo1: TMemo;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure Memo1Change(Sender: TObject);
  private

  public
    procedure Dll_demo_work_cdecl(dll_name: string; f_list: array of string);
    procedure Dll_demo_work_stdcall(dll_name: string; f_list: array of string);
  end;

var
  Form1: TForm1;


implementation

{$R *.lfm}

{ TForm1 }

function GetArray(size: integer): PDoubleArray;
var
 i: integer;
 arr: array of double;
 begin
   SetLength(arr, sizeArray);
   for i:=0 to size-1 do
    begin
      arr[i] := Power(i + 1, 3 / 4) * cos(i) / arcTan(i + 1);
    end;
   result := @arr[0];
 end;

function GetMatrix(size: integer): T2dArray;
var
 i, j: integer;
 matrix: array of array of double;
 begin
   SetLength(matrix, size, size); // выделение памяти
   for j:=0 to size-1 do
    begin
      for i:=0 to size-1 do
       begin
         matrix[i][j] := Power(i + 1, 3 / 4) * cos(i) / arcTan(i + 1);
       end;
    end;
   result := @matrix[0];
 end;

procedure TForm1.Dll_demo_work_cdecl(dll_name: string; f_list: array of string);
var
  hLib: THandle;
  rez: double;
  sizeArray, sizeMatrix, iterations, i, y, x: integer;

  // простые методы
  fAdd, fSubtract, fMultiply, fDivide: FdoubleOps;
  // метод обработки  одномерного массива
  fillmas: FmasProc;
  // метод обработки двумерного массива
  fmas2d: fillmas2d;

  GetRangeValueFromVector: VectorTypeCDECL;
  GetAverageValueFromVector: VectorTypeCDECL;
  GetAverageValueFromMatrix: MatrixTypeCDECL;

  // переменные для массива
  arr: array of double;
  arrP: PDoubleArray;

  // переменные для двумерного массива
  matrix: array of array of double;
  matrixP: P2dArray;

begin

  hLib := 0;
  Memo1.Lines.Clear;
  if hLib = 0 then
    hLib := SafeLoadLibrary(dll_name);
  if hLib = 0 then
  begin
    Memo1.Lines.Add('ERROR: unable to load DLL: ' + dll_name);
    exit;
  end;
  Memo1.Lines.Add('Библиотека' + dll_name +
    ' Успешно загружена');

  /// Пример одномерный массив ////
  SetLength(arr, sizeArray); // выделение памяти
  Pointer(GetRangeValueFromVector) := GetProcAddress(hLib, PChar(f_list[0]));
  if (GetRangeValueFromVector <> nil) then
  begin
    arrP := @arr[0];;
    rez := GetRangeValueFromVector(arrP, sizeArray);
  end
  else
    Memo1.Lines.Add('Не удалось найти функцию ' + f_list[4]);

  /// Пример двумерный массив ////
  Memo1.Lines.Add('');
  Memo1.Lines.Add('Пример работы с двумерным массивом');
  SetLength(matrix, sizeMatrix, sizeMatrix); // выделение памяти
  Pointer(GetAverageValueFromMatrix) := GetProcAddress(hLib, PChar(f_list[2]));
  if (GetAverageValueFromMatrix <> nil) then
  begin
    matrixP := @matrix[0];
    rez := GetAverageValueFromMatrix(matrixP, sizeMatrix);
  end
  else
    Memo1.Lines.Add('Не удалось найти функцию ' + f_list[5]);

  if hLib <> 0 then
    FreeLibrary(hLib);
  hLib := 0;
end;


procedure TForm1.Dll_demo_work_stdcall(dll_name: string; f_list: array of string);
var
  hLib: THandle;
  rez, minTime, maxTime, totalTime, avgTime: double;
  i, y, x: integer;

  Ftime: extended;
  FFrequence: TLargeInteger;
  FBeginCount: TLargeInteger;
  FEndCount: TLargeInteger;

  GetRangeValueFromVector: VectorTypeSTD;
  GetAverageValueFromVector: VectorTypeSTD;
  GetAverageValueFromMatrix: MatrixTypeSTD;

  // переменные для массива
  arrP: PDoubleArray;

  // переменные для двумерного массива
  matrix: T2dArray;
  matrixP: P2dArray;

begin
  hLib := 0;
  Memo1.Lines.Clear;
  if hLib = 0 then
    hLib := SafeLoadLibrary(dll_name);
  if hLib = 0 then
  begin
    Memo1.Lines.Add('ERROR: unable to load DLL: ' + dll_name);
    exit;
  end;
  Memo1.Lines.Add('Библиотека ' + dll_name + ' Успешно загружена');

  Pointer(GetRangeValueFromVector) := GetProcAddress(hLib, PChar(f_list[0]));
  if (GetRangeValueFromVector <> nil) then
  begin
    Memo1.Lines.Add('START: '+f_list[0]);
    arrP := GetArray(sizeArray);
    minTime := 10000;
    maxTime := -1;
    totalTime := 0;
    for y:=0 to iterations-1 do
    begin
      QueryPerformanceFrequency(FFrequence);
      QueryPerformanceCounter(FBeginCount);
      rez := GetRangeValueFromVector(arrP, sizeArray);
      QueryPerformanceCounter(FEndCount);
      Ftime := ((FEndCount - FBeginCount) / FFrequence) * 1000;
      totalTime := totalTime + Ftime;
      if minTime > Ftime then minTime := Ftime;
      if maxTime < Ftime then maxTime := Ftime;
    end;

    avgTime := totalTime / iterations;

    Memo1.Lines.Add('Min: '+floattostr(minTime)+' ms.');
    Memo1.Lines.Add('Avg: '+floattostr(avgTime)+' ms.');
    Memo1.Lines.Add('Max: '+floattostr(maxTime)+' ms.');
  end
  else
    Memo1.Lines.Add('Не удалось найти функцию ' + f_list[0]);

  Pointer(GetAverageValueFromVector) := GetProcAddress(hLib, PChar(f_list[1]));
  if (GetAverageValueFromVector <> nil) then
  begin
    Memo1.Lines.Add('START: '+f_list[1]);
    arrP := GetArray(sizeArray);
    minTime := 10000;
    maxTime := -1;
    totalTime := 0;
    for y:=0 to iterations-1 do
    begin
      QueryPerformanceFrequency(FFrequence);
      QueryPerformanceCounter(FBeginCount);
      rez := GetAverageValueFromVector(arrP, sizeArray);
      QueryPerformanceCounter(FEndCount);
      Ftime := ((FEndCount - FBeginCount) / FFrequence) * 1000;
      totalTime := totalTime + Ftime;
      if minTime > Ftime then minTime := Ftime;
      if maxTime < Ftime then maxTime := Ftime;
    end;

    avgTime := totalTime / iterations;

    Memo1.Lines.Add('Min: '+floattostr(minTime)+' ms.');
    Memo1.Lines.Add('Avg: '+floattostr(avgTime)+' ms.');
    Memo1.Lines.Add('Max: '+floattostr(maxTime)+' ms.');
  end
  else
    Memo1.Lines.Add('Не удалось найти функцию ' + f_list[0]);

  Pointer(GetAverageValueFromMatrix) := GetProcAddress(hLib, PChar(f_list[2]));
  if (GetAverageValueFromMatrix <> nil) then
  begin
    Memo1.Lines.Add('START: '+f_list[2]);
    matrix := GetMatrix(sizeMatrix);
    minTime := 10000;
    maxTime := -1;
    totalTime := 0;
    for y:=0 to iterations-1 do
    begin
      QueryPerformanceFrequency(FFrequence);
      QueryPerformanceCounter(FBeginCount);
      rez := GetAverageValueFromMatrix(matrix, sizeMatrix);
      QueryPerformanceCounter(FEndCount);
      Ftime := ((FEndCount - FBeginCount) / FFrequence) * 1000;
      totalTime := totalTime + Ftime;
      if minTime > Ftime then minTime := Ftime;
      if maxTime < Ftime then maxTime := Ftime;
    end;

    avgTime := totalTime / iterations;

    Memo1.Lines.Add('Min: '+floattostr(minTime)+' ms.');
    Memo1.Lines.Add('Avg: '+floattostr(avgTime)+' ms.');
    Memo1.Lines.Add('Max: '+floattostr(maxTime)+' ms.');
  end
  else
    Memo1.Lines.Add('Не удалось найти функцию ' + f_list[2]);

  if hLib <> 0 then
    FreeLibrary(hLib);
  hLib := 0;
end;


procedure TForm1.Button1Click(Sender: TObject);
begin
  Dll_demo_work_stdcall('DllVisualCPP.dll', func_name1);
end;

procedure TForm1.Button2Click(Sender: TObject);
begin
  Dll_demo_work_stdcall('Dll_CPP_Builder.dll', func_name1);
end;

procedure TForm1.Button3Click(Sender: TObject);

begin
  Dll_demo_work_stdcall('Dll_Lazarus.dll', func_name1);
end;

procedure TForm1.FormCreate(Sender: TObject);
begin

end;

procedure TForm1.Memo1Change(Sender: TObject);
begin

end;

end.
