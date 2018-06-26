object Form1: TForm1
  Left = 192
  Top = 112
  Width = 696
  Height = 480
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Button1: TButton
    Left = 24
    Top = 384
    Width = 129
    Height = 41
    Caption = 'Test'
    TabOrder = 0
    OnClick = Button1Click
  end
  object Button2: TButton
    Left = 544
    Top = 384
    Width = 121
    Height = 41
    Caption = 'Exit'
    TabOrder = 1
    OnClick = Button2Click
  end
  object List: TListBox
    Left = 8
    Top = 8
    Width = 665
    Height = 369
    ItemHeight = 13
    TabOrder = 2
  end
end
