unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls,rockey4nd;

type
  TForm1 = class(TForm)
    Button2: TButton;
    List: TListBox;
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;
  mBuf:array[0..100] of Byte;
  mFun,mP1,mP2,mP3,mP4,rt:Word;
  lP1,lP2:LongWord;
  mHand:array[0..16] of Word;
  mHardID:array[0..16] of LongWord;
  rc:array[0..4] of Word;

implementation

{$R *.DFM}

procedure TForm1.Button1Click(Sender: TObject);
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
        FmtStr(str,'Can not find ROCKEY1,error:%x ',[rt]);
        List.Items.Add(str);
        exit;
    end;
    List.Items.Add('Find the first ROCKEY');

    mHardID[0]:=lp1;
    mFun:=RY_OPEN;
    rt:= Rockey(mFun,mHand[0],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
    if rt<>0 then
    begin
        FmtStr(str,'Can not open ROCKEY1,error:%x ',[rt]);
        List.Items.Add(str);
        exit;
    end;
    List.Items.Add('Open ROCKEY1');

    i:=1;
    while rt = 0 do
    begin
        mFun:=RY_FIND_NEXT;
        rt:= Rockey(mFun,mHand[i],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
        if rt<>0 then
           break;

        mHardID[i]:=lP1;
        FmtStr(str,'Find the %xROCKEY',[i+1]);
        List.Items.Add(str);

        mFun:=RY_OPEN;
        rt:= Rockey(mFun,mHand[i],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
        if rt<>0 then
        begin
            FmtStr(str,'Can not open ROCKEY%x',[i+1]);
            List.Items.Add(str);
            break;
        end;
        FmtStr(str,'Open ROCKEY%x',[i+1]);
        List.Items.Add(str);
        i:=i+1;
    end;
    mRockeyNumber:=i;
for num:=0 to mRockeyNumber-1 do
begin
  List.Items.Add('*******************************************');
  FmtStr(str,'Begin to test the %xROCKEY',[num+1]);
  List.Items.Add(str);
{Write}
  mFun:=RY_WRITE;
  for i:=0 to 10 do
      mBuf[i]:=31;
  mP1:=498;
  mP2:=11;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Write ROCKEY Error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Write ROCKEY Success',[i+1]);
   List.Items.Add('Write ROCKEY Success');
{Read}
  mFun:=RY_READ;
  for i:=0 to 10 do
      tmpBuf[i]:=0;
  mP1:=498;
  mP2:=11;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,tmpBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Read ROCKEY Error',[rt]);
        List.Items.Add(str);
        break;
   end
   else
   begin
      for i:=0 to 10 do
          if mBuf[i] <> tmpBuf[i] then
              break;
      if i = 11 then
         List.Items.Add('Read ROCKEY Success')
      else
          List.Items.Add('Read ROCKEY Success,But have some differences from writed');
   end;
{Random}
  mFun:=RY_RANDOM;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Detect Random number Error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Random Number%x:',[mP1]);
   List.Items.Add(str);
{Seed}
  mFun:=RY_SEED;
  lP2:=$12345678;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Seed key Error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Seed%x:Return value:%x,%x,%x,%x',[lP2,mP1,mP2,mP3,mP4]);
   List.Items.Add(str);
   rc[0] := mP1; rc[1] := mP2;
   rc[2] := mP3; rc[3] := mP4;
{Write User ID}
  mFun:=RY_WRITE_USERID;
  lP1:=100;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Write User ID Error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Write USER ID%x',[lP1]);
   List.Items.Add(str);
{Read User ID}
  mFun:=RY_READ_USERID;
  lP1:=0;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Read User ID Error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'The User ID is %x',[lP1]);
   List.Items.Add(str);
{Set module}
  mFun:=RY_SET_MOUDLE;
  mP1:=7;
  mP2:=$2122;
  mP3:=1;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Set Module %x got error %x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Set module %x,value is %x,can be decrease',[mP1,mP2]);
   List.Items.Add(str);
{First check module}
  mFun:=RY_CHECK_MOUDLE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Check module %x error %x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   if mP2 = 1 then
      if mP3 = 1 then
            FmtStr(str,'Check module %x,valid,can be decrease',[mP1])
      else
            FmtStr(str,'Check module %x,invalid,can not be decrese',[mP1])
   else
     if mP3 = 1 then
            FmtStr(str,'Check module x,invalid,can not be decrese',[mP1])
      else
            FmtStr(str,'Check module %x,invalid,can not be decrese',[mP1]) ;
   List.Items.Add(str);

{Decrease}
 mFun:=RY_DECREASE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Decrese module %x error %x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Decrese module %x,is 0X2121',[mP1]);
   List.Items.Add(str);


 {Write Arithmetic 1}
  cstr:='H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=0;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Write Arithmetic 1 error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('Write Arithmetic 1 Success');
{Calculate 1}
  mFun:=RY_CALCULATE1;
  lP1 := 0; lP2 := 7;
  mP1 := 5; mP2 := 3;
  mP3 := 1; mP4 := $ffff;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Calculate Arithmetic 1 error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('Calculate input: p1=5, p2=3, p3=1, p4=0xffff');
  List.Items.Add('Result: = ((5*23 + 3*17 + 0x2121) < 1) ^ 0xffff = BC71');
  FmtStr(str,'Calculate output: p1=%x, p2=%x, p3=%x, p4=%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);

{Write Arithmetic 2}
  cstr:='A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=10;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Write Arithmetic 2 error %x',[rt]);
        List.Items.Add(str);
        break;
   end;

  List.Items.Add('Write Arithmetic 2 success');
{Calculate 2}
  mFun:=RY_CALCULATE2;
  lP1 := 10; lP2 := $12345678;
  mP1 := 1; mP2 := 2;
  mP3 := 3; mP4 := 4;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Calculate Arithmetic 2 error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('Calculate input: p1=1, p2=2, p3=3, p4=4');
  FmtStr(str,'Result: %04x + %04x + %04x + %04x + 1 + 2 + 3 + 4 = %04x',[rc[0], rc[1], rc[2], rc[3], Word(rc[0]+rc[1]+rc[2]+rc[3]+10)]);
  List.Items.Add(str);
  FmtStr(str,'Calculate output: p1=%x, p2=%x, p3=%x, p4=%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);
{Write Arithmetic 3}
  cstr:='A=E|E, B=F|F, C=G|G, D=H|H';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=17;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Write arithmetic 3 error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('Write arithmetic 3 success');
  {Decrease}
 mFun:=RY_DECREASE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Decrease module %x error %x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Decrese module %x,is 0X2120',[mP1]);
   List.Items.Add(str);

{Calcualte 3}
  mFun:=RY_CALCULATE3;
  lP1 := 17; lP2 := 6;
  mP1 := 1; mP2 := 2;
  mP3 := 3; mP4 := 4;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Calculate arithmetic 3 error %x',[rt]);
        List.Items.Add(str);
        break;
   end;
  FmtStr(str,'Read the module from 6: %x,%x,%x,%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);
  end;


  for num:=0 to mRockeyNumber-1 do
  begin
  mHand[num]  :=10;
   rt:= Rockey(RY_CLOSE,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   begin
        List.Items.Add('Close Rockey4ND');
        break;
   end;
   end;
   R4ND_Finish();

end;

//procedure TMainForm.BitBtn1Click(Sender: TObject);
//begin
 //    close()
//end;

procedure TForm1.Button2Click(Sender: TObject);
begin
close()
end;

end.

