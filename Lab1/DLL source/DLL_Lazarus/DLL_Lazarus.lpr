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

 function GetRangeValueFromVector(arr: PDoubleArray; size:integer): double; stdcall;
var
i:integer;
minValue, maxValue:double;
 begin
   minValue := arr^[0];
   maxValue := arr^[0];
   for i := 0 to size - 1 do
   begin
      if minValue > arr^[i] then
         minValue := arr^[i];

      if maxValue < arr^[i] then
         maxValue := arr^[i];
   end;
   result:= maxValue - minValue;
 end;

 function GetAverageValueFromVector(arr: PDoubleArray; size:integer): double; stdcall;
var
i:integer;
sum:double;
 begin
   sum:=0;
   for i := 0 to size - 1 do
   begin
    sum:= sum + arr^[i];
   end;
   result:=sum / size;
 end;

 function GetAverageValueFromMatrix(matrix:p2dArray; size:integer):double;  stdcall;
 var
 x,y:integer;
 sum:double;
 begin
   sum:=0;
   for y:=0 to size-1 do
   begin
     for x:=0 to size-1  do
     begin
       sum := sum + matrix^[y][x];
     end;
   result:=sum / (size * size);
   end;
 end;





{ Этот набор функций экспортируется }
 exports
   GetRangeValueFromVector,GetAverageValueFromVector,GetAverageValueFromMatrix;





begin
end.




