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
 FmtStr(str,'cannot find ROCKEY1,error:%d ',[rt]);
   List.Items.Add(str);
    exit;
  end;
    List.Items.Add('find ROCKEY No.1');

  mHardID[0]:=lp1;
  mFun:=RY_OPEN;
 rt:= Rockey(mFun,mHand[0],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
 if rt<>0 then
 begin
 FmtStr(str,'ROCKEY1 is not open,error:%d ',[rt]);
   List.Items.Add(str);
    exit;
 end;
   List.Items.Add('open ROCKEY1 succeed');

   i:=1;
 mRockeyNumber:=i;
   while rt = 0 do
   begin
        mFun:=RY_FIND_NEXT;
        rt:= Rockey(mFun,mHand[i],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
        if rt<>0 then
           break;

          mHardID[i]:=lP1;
          FmtStr(str,'find ROCKEY No.%d',[i+1]);
          List.Items.Add(str);

          mFun:=RY_OPEN;
          rt:= Rockey(mFun,mHand[i],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
          if rt<>0 then
          begin
               FmtStr(str,'ROCKEY No. %d is not open',[i+1]);
               List.Items.Add(str);
               break;
          end;
      FmtStr(str,'open ROCKEY No. %d succeed',[i+1]);
      List.Items.Add(str);
      i:=i+1;
      mRockeyNumber:=i;
   end;
   mRockeyNumber:=i;
for num:=0 to mRockeyNumber-1 do
begin
  List.Items.Add('*******************************************');
  FmtStr(str,'start testing No. ROCKEY%d',[num+1]);
  List.Items.Add(str);
{writing}
  mFun:=RY_WRITE;
  for i:=0 to 10 do
      mBuf[i]:=31;
  mP1:=0;
  mP2:=11;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'writing ROCKEY, find error %d',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'writing ROCKEY succeed',[i+1]);
   List.Items.Add('writing ROCKEY succeed');
{reading}
  mFun:=RY_READ;
  for i:=0 to 10 do
      tmpBuf[i]:=0;
  mP1:=0;
  mP2:=11;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,tmpBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'reading ROCKEY, find error %d',[rt]);
        List.Items.Add(str);
        break;
   end
   else
   begin
      for i:=0 to 10 do
          if mBuf[i] <> tmpBuf[i] then
              break;
      if i = 11 then
         List.Items.Add('reading ROCKEY succeed')
      else
          List.Items.Add('reading succedd ROCKEY,but content is different with writing');
   end;
{ramdon}
  mFun:=RY_RANDOM;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'testing random, find error %d',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'random %d:',[mP1]);
   List.Items.Add(str);
{seed}
  mFun:=RY_SEED;
  lP2:=$12345678;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'tesing seed, find error %d',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'seed %x: returned value:%x,%x,%x,%x',[lP2,mP1,mP2,mP3,mP4]);
   List.Items.Add(str);
   rc[0] := mP1; rc[1] := mP2;
   rc[2] := mP3; rc[3] := mP4;
{writing UID}
  mFun:=RY_WRITE_USERID;
  lP1:=100;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'wiring UID,find error %d',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'writing UID%x',[lP1]);
   List.Items.Add(str);
{read UID}
  mFun:=RY_READ_USERID;
  lP1:=0;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'reading UID, find error %d',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'reading UID%x',[lP1]);
   List.Items.Add(str);
{set module}
  mFun:=RY_SET_MOUDLE;
  mP1:=7;
  mP2:=$2122;
  mP3:=1;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'setting moudle %x, find error %x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'setting moudle %x as %x, decrease-able',[mP1,mP2]);
   List.Items.Add(str);
{check module for the first time}
  mFun:=RY_CHECK_MOUDLE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'tesing moudle %x, find error %x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   if mP2 = 1 then
      if mP3 = 1 then
            FmtStr(str,'testing moudle %x,valid,decrease-able',[mP1])
      else
            FmtStr(str,'testing moudle %x,valid,non-decrease',[mP1])
   else
     if mP3 = 1 then
            FmtStr(str,'testing module %x,invalid,decrease-able',[mP1])
      else
            FmtStr(str,'testing module %x,invalid,non-decrease',[mP1]) ;
   List.Items.Add(str);

{decreasment}
 mFun:=RY_DECREASE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'testing module %x, find error %x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'module %x is 0X2121',[mP1]);
   List.Items.Add(str);


 {writing algorithm1}
  cstr:='H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=0;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'writing algorithm1, find error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('writing algorithm1 succeed');
{computation1}
  mFun:=RY_CALCULATE1;
  lP1 := 0; lP2 := 7;
  mP1 := 5; mP2 := 3;
  mP3 := 1; mP4 := $ffff;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'computation1 finds error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('computational input: p1=5, p2=3, p3=1, p4=0xffff');
  List.Items.Add('result: = ((5*23 + 3*17 + 0x2121) < 1) ^ 0xffff = BC71');
  FmtStr(str,'computational output: p1=%x, p2=%x, p3=%x, p4=%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);

{writing algorithm2}
  cstr:='A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=10;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'writing algorithm2,find error %x',[rt]);
        List.Items.Add(str);
        break;
   end;

  List.Items.Add('writing algorithm2 succeed');
{compuatioan2}
  mFun:=RY_CALCULATE2;
  lP1 := 10; lP2 := $12345678;
  mP1 := 1; mP2 := 2;
  mP3 := 3; mP4 := 4;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'computation2 finds error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('computional input: p1=1, p2=2, p3=3, p4=4');
  FmtStr(str,'result: %04x + %04x + %04x + %04x + 1 + 2 + 3 + 4 = %04x',[rc[0], rc[1], rc[2], rc[3], Word(rc[0]+rc[1]+rc[2]+rc[3]+10)]);
  List.Items.Add(str);
  FmtStr(str,'computional output: p1=%x, p2=%x, p3=%x, p4=%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);
{writing algorithm3}
  cstr:='A=E|E, B=F|F, C=G|G, D=H|H';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=17;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'writing algorithm3,find error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('writing algorithm3 succeed');
  {decrease}
 mFun:=RY_DECREASE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'decreasing module %x,find error %x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'decrease moudle %x as 0X2120',[mP1]);
   List.Items.Add(str);

{computation3}
  mFun:=RY_CALCULATE3;
  lP1 := 17; lP2 := 6;
  mP1 := 1; mP2 := 2;
  mP3 := 3; mP4 := 4;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'computation3 finds error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
  FmtStr(str,'moudle from 6 are: %x,%x,%x,%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);
  end;
  for num:=0 to mRockeyNumber-1 do
   rt:= Rockey(RY_CLOSE,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);


end;

procedure TMainForm.BitBtn1Click(Sender: TObject);
begin
     close()
end;

end.
