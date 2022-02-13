object Form1: TForm1
  Left = 0
  Top = 0
  Caption = 'Form1'
  ClientHeight = 350
  ClientWidth = 494
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Memo1: TMemo
    Left = 16
    Top = 24
    Width = 321
    Height = 313
    Lines.Strings = (
      'Memo1')
    ScrollBars = ssVertical
    TabOrder = 0
  end
  object Button1: TButton
    Left = 352
    Top = 22
    Width = 134
    Height = 25
    Caption = 'Visual Studio C++ DLL'
    TabOrder = 1
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 352
    Top = 53
    Width = 134
    Height = 25
    Caption = 'C++ Builder DLL'
    TabOrder = 2
    OnClick = Button2Click
  end
  object Button3: TButton
    Left = 352
    Top = 84
    Width = 134
    Height = 25
    Caption = 'Lazarus DLL'
    TabOrder = 3
    OnClick = Button3Click
  end
end
