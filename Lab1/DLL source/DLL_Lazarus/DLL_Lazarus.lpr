library DLL_Lazarus;

{$mode objfpc}{$H+}

uses
  Classes
  { you can add units after this };

type
TDoubleArray = array[Word] of Double;
PDoubleArray = ^TDoubleArray;


type
  T2dArray = array of array of double;
  t2dArrayP =  array[Word] of array of Double;
  p2dArray = ^t2dArrayP;

 function GetRangeValueFromVector(arr: TDoubleArray; size:integer): double; cdecl;
var
i:integer;
minValue, maxValue:double;
 begin
 minValue:=-10000000;
 maxValue:=10000000;
 for i := 0 to size - 1 do
  begin
   if (minValue > arr[i]) then minValue := arr[i];
   if (maxValue < arr[i]) then maxValue := arr[i];
  end;
  result:=maxValue-minvalue;
 end;

 function GetAverageValueFromVector(arr: TDoubleArray; size:integer): double; cdecl;
var
i:integer;
sum:double;
 begin
 sum:=0;
 for i := 0 to size - 1 do
  begin
   sum:= sum + arr[i];
  end;
  result:=sum;
 end;

 function GetAverageValueFromMatrix(matrix:T2dArray; size:integer):double;  cdecl;
 var
 x,y:integer;
 sum:double;
 begin
 sum:=0;
for y:=0 to size-1 do
  for x:=0 to size-1  do
  begin
  sum := sum + matrix[y][x];
  end;
  result:=sum / (size * size);
 end;






{ Этот набор функций экспортируется }
 exports
   GetRangeValueFromVector,GetAverageValueFromVector,GetAverageValueFromMatrix;





begin
end.




