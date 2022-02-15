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
sum1, sum2:double;
 begin
   sum1:=0;
   sum2:=0;
   for i := 0 to size - 1 do
   begin
    if (trunc(arr^[i]) mod 2 = 0) then
       sum2:= sum2 + arr^[i]
    else
       sum1:= sum1 + arr^[i];
   end;
   result:=(sum1 + sum2) / size;
 end;

 function GetAverageValueFromMatrix(matrix:p2dArray; size:integer):double;  stdcall;
 var
 x,y:integer;
 sum, avgValue:double;
 begin
   sum:=0;
   for y:=0 to size-1 do
   begin
     for x:=0 to size-1  do
     begin
       sum := sum + matrix^[y][x];
     end;
   end;
   avgValue:=sum / (size * size);

   sum:=0;
   for y:=0 to size-1 do
   begin
     for x:=0 to size-1  do
     begin
       if (matrix^[y][x] > avgValue) or (x = y) then
         sum := sum + matrix^[y][x];
     end;
   end;

   result := sum
 end;





{ Этот набор функций экспортируется }
 exports
   GetRangeValueFromVector,GetAverageValueFromVector,GetAverageValueFromMatrix;





begin
end.




