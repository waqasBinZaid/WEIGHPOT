unit Main;

interface

uses
  SysUtils, Windows, Messages, Classes, Graphics, Controls,
  Forms, Dialogs, StdCtrls, Buttons, ExtCtrls, Menus,rockey4nd;

type
    TMainForm = class(TForm)
        List: TListBox;
        Button1: TButton;
        BitBtn1: TBitBtn;
        procedure WindowTile(Sender: TObject);
        procedure WindowCascade(Sender: TObject);
        procedure WindowArrange(Sender: TObject);
        procedure Button1Click(Sender: TObject);
        procedure BitBtn1Click(Sender: TObject);
    end;

var
  MainForm: TMainForm;
  mBuf:array[0..100] of Byte;
  mFun,mP1,mP2,mP3,mP4,rt:Word;
  lP1,lP2:LongWord;
  mHand:array[0..16] of Word;
  mHardID:array[0..16] of LongWord;
  rc:array[0..4] of Word;
implementation

{$R *.DFM}

procedure TMainForm.WindowTile(Sender: TObject);
begin
  Tile;
end;

procedure TMainForm.WindowCascade(Sender: TObject);
begin
  Cascade;
end;

procedure TMainForm.WindowArrange(Sender: TObject);
begin
  ArrangeIcons;
end;

procedure TMainForm.Button1Click(Sender: TObject);
var
    i,num:Integer;
    str:string;
    mRockeyNumber:Word;
    tmpBuf:array[0..30] of Byte;
    cStr:array[0..100] of Char;
begin
R4ND_Init();
    List.Items.Clear();
    mP1:=$c44c;
    mP2:=$c8f8;
    mP3:=$799;
    mP4:=$c43b;
    for i:=0 to 30 do
       mBuf[i]:=0;
    rt:=0;
    mFun:=1;
    rt:= Rockey(mFun,mHand[0],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
    if rt<>0 then
    begin
        FmtStr(str,'not find ROCKEY4ND,error:0x%x ',[rt]);
        List.Items.Add(str);
        exit;
    end;
    List.Items.Add('find first ROCKEY4ND');

    mHardID[0]:=lp1;
    mFun:=RY_OPEN;
    rt:= Rockey(mFun,mHand[0],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
    if rt<>0 then
    begin
        FmtStr(str,'not open ROCKEY4ND,error:0x%x ',[rt]);
        List.Items.Add(str);
        exit;
    end;
    List.Items.Add('open success ROCKEY4ND');

    i:=1;
    while rt = 0 do
    begin
        mFun:=RY_FIND_NEXT;
        rt:= Rockey(mFun,mHand[i],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
        if rt<>0 then
           break;

        mHardID[i]:=lP1;
        FmtStr(str,'find the 0x%xth ROCKEY4ND',[i+1]);
        List.Items.Add(str);

        mFun:=RY_OPEN;
        rt:= Rockey(mFun,mHand[i],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
        if rt<>0 then
        begin
            FmtStr(str,'not open the 0x%xth ROCKEY4ND',[i+1]);
            List.Items.Add(str);
            break;
        end;
        FmtStr(str,'open the 0x%xth ROCKEY4ND',[i+1]);
        List.Items.Add(str);
        i:=i+1;
    end;
    mRockeyNumber:=i;
for num:=0 to mRockeyNumber-1 do
begin
  List.Items.Add('*******************************************');
  FmtStr(str,'test the 0x%xth ROCKEY4ND',[num+1]);
  List.Items.Add(str);
{写}
  mFun:=RY_WRITE;
  for i:=0 to 10 do
      mBuf[i]:=31;
  mP1:=498;
  mP2:=11;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'write ROCKEY4ND fail:0x%x',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'write ROCKEY4ND success',[i+1]);
   List.Items.Add('write success ROCKEY4ND');
{读}
  mFun:=RY_READ;
  for i:=0 to 10 do
      tmpBuf[i]:=0;
  mP1:=498;
  mP2:=11;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,tmpBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'read ROCKEY4ND fail :0x%x',[rt]);
        List.Items.Add(str);
        break;
   end
   else
   begin
      for i:=0 to 10 do
          if mBuf[i] <> tmpBuf[i] then
              break;
      if i = 11 then
         List.Items.Add('read success ROCKEY4ND')
      else
          List.Items.Add('read success ROCKEY4ND,but is not different writed');
   end;
{随机数}
  mFun:=RY_RANDOM;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'test random fail:0x%x',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'random:0x%x:',[mP1]);
   List.Items.Add(str);
{种子码}
  mFun:=RY_SEED;
  lP2:=$12345678;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'send Seed code fail: 0x%x',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Seed code 0x%x:ret:0x%x,0x%x,0x%x,0x%x',[lP2,mP1,mP2,mP3,mP4]);
   List.Items.Add(str);
   rc[0] := mP1; rc[1] := mP2;
   rc[2] := mP3; rc[3] := mP4;
{写用户ID}
  mFun:=RY_WRITE_USERID;
  lP1:=100;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'write User faiol:0x%x',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'write user ID0x%x',[lP1]);
   List.Items.Add(str);
{读用户ID}
  mFun:=RY_READ_USERID;
  lP1:=0;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'read user id fail:0x%x',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'user ID:0x%x',[lP1]);
   List.Items.Add(str);
{设置模块}
  mFun:=RY_SET_MOUDLE;
  mP1:=7;
  mP2:=$2122;
  mP3:=1;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'set module 0x%x fail:0x%x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'set module 0x%x, value:0x%x',[mP1,mP2]);
   List.Items.Add(str);
{检测模块第一次}
  mFun:=RY_CHECK_MOUDLE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'test module 0x%x fail:0x%x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   if mP2 = 1 then
      if mP3 = 1 then
            FmtStr(str,'test module 0x%x,,Effective,Can be reduced',[mP1])
      else
            FmtStr(str,'test module 0x%x,Effective,Can not be reduced',[mP1])
   else
     if mP3 = 1 then
            FmtStr(str,'test module0x%x,Invalid,Can be reduced',[mP1])
      else
            FmtStr(str,'test module0x%x,Invalid,Can not be reduced',[mP1]) ;
   List.Items.Add(str);

{递减}
 mFun:=RY_DECREASE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'reduced module0x%xfail:0x%x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'reduced module0x%x,value:0X2121',[mP1]);
   List.Items.Add(str);


 {写算法1}
  cstr:='H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=0;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'write Algorithm1 fail:0x%x',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('write Algorithm1 success');
{计算一}
  mFun:=RY_CALCULATE1;
  lP1 := 0; lP2 := 7;
  mP1 := 5; mP2 := 3;
  mP3 := 1; mP4 := $ffff;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Algorithm1 fail:0x%x',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('Algorithm1 input: p1=5, p2=3, p3=1, p4=0xffff');
  List.Items.Add('result: = ((5*23 + 3*17 + 0x2121) < 1) ^ 0xffff = BC71');
  FmtStr(str,'Algorithm1 output: p1=0x%x, p2=0x%x, p3=0x%x, p4=0x%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);

{写算法2}
  cstr:='A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=10;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'write Algorithm2 fail:0x%x',[rt]);
        List.Items.Add(str);
        break;
   end;
  
  List.Items.Add('write Algorithm2 success');
{计算2}
  mFun:=RY_CALCULATE2;
  lP1 := 10; lP2 := $12345678;
  mP1 := 1; mP2 := 2;
  mP3 := 3; mP4 := 4;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Algorithm2 fail:0x%x',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('Algorithm2 input: p1=1, p2=2, p3=3, p4=4');
  FmtStr(str,'result: %04x + %04x + %04x + %04x + 1 + 2 + 3 + 4 = %04x',[rc[0], rc[1], rc[2], rc[3], Word(rc[0]+rc[1]+rc[2]+rc[3]+10)]);
  List.Items.Add(str);
  FmtStr(str,'Algorithm2 output: p1=0x%x, p2=0x%x, p3=0x%x, p4=0x%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);
{写算法3}
  cstr:='A=E|E, B=F|F, C=G|G, D=H|H';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=17;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'write Algorithm3 fail:0x%x',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('write Algorithm3 success');
  {递减}
 mFun:=RY_DECREASE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Decreasing module0x%xfail:0x%x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Decreasing module0x%x,value:0X2120',[mP1]);
   List.Items.Add(str);

{计算3}
  mFun:=RY_CALCULATE3;
  lP1 := 17; lP2 := 6;
  mP1 := 1; mP2 := 2;
  mP3 := 3; mP4 := 4;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Algorithm3 fail:0x%x',[rt]);
        List.Items.Add(str);
        break;
   end;
  FmtStr(str,'read from 6 module: 0x%x,0x%x,0x%x,0x%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);
  end;


  for num:=0 to mRockeyNumber-1 do
  begin

   rt:= Rockey(RY_CLOSE,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);

   List.Items.Add('close rockey4nd');

   end;
   R4ND_Finish();

end;

procedure TMainForm.BitBtn1Click(Sender: TObject);
begin
     close()
end;

end.
