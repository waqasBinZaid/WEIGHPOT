unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
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
  i:integer;

  function  Rockey(fun:Word; var Handle:Word;
                var lp1,lp2:LongWord;
                var P1,P2,P3,P4:Word;
                var buf:Byte):Word;
                stdcall;external 'Rockey4ND.dll';
implementation

{$R *.DFM}

procedure TForm1.Button1Click(Sender: TObject);
var
    i,num:Integer;
    str:string;
    mRockeyNumber:Word;
    tmpBuf:array[0..30] of Byte;
    cStr:array[0..100] of Char;
    RY_FIND,RY_FIND_NEXT,RY_OPEN,RY_CLOSE,RY_READ :Word;
    RY_WRITE,RY_RANDOM,RY_SEED,RY_WRITE_USERID:Word;
    RY_READ_USERID,RY_SET_MOUDLE,RY_CHECK_MOUDLE,RY_WRITE_ARITHMETIC:Word;
    RY_CALCULATE1,RY_CALCULATE2,RY_CALCULATE3,RY_DECREASE:Word;
begin
RY_FIND                        :=1 ;		{find rockey}
RY_FIND_NEXT		       :=2 ;		{find next rockey}
RY_OPEN                        :=3 ;		{open rockey}
RY_CLOSE                       :=4 ;		{Close rockey}
RY_READ                        :=5 ;		{Read rockey}
RY_WRITE                       :=6 ;		{Write rockey}
RY_RANDOM                      :=7 ;		{Generate random}
RY_SEED                        :=8 ;		{Generate seed code}
RY_WRITE_USERID		       :=9 ;		{Write user ID}
RY_READ_USERID		       :=10;		{Read User ID}
RY_SET_MOUDLE		       :=11;		{Set module word}
RY_CHECK_MOUDLE		       :=12;		{Check module status}
RY_WRITE_ARITHMETIC            :=13;		{Write arithmetic}
RY_CALCULATE1		       :=14;		{calculate 1 }
RY_CALCULATE2		       :=15;		{calculate 2 }
RY_CALCULATE3		       :=16;		{calculate 3 }
RY_DECREASE		       :=17;		{Decrease module cell}
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
        FmtStr(str,'not find ROCKEY1,error:%x ',[rt]);
        List.Items.Add(str);
        exit;
    end;
    List.Items.Add('Find the first ROCKEY');

    mHardID[0]:=lp1;
    mFun:=RY_OPEN;
    rt:= Rockey(mFun,mHand[0],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
    if rt<>0 then
    begin
        FmtStr(str,'not rind rockeyROCKEY1,error:%x ',[rt]);
        List.Items.Add(str);
        exit;
    end;
    //Rockey4ND's return type is 7,Rockey4's return type is
    // 1  ROCKEY4 Standard parallel type
    // 2  ROCKEY4+ Enganced parallel type
    // 3  ROCKEY4 Standard USB type
    // 4  ROCKEY4+ Enganced USB type
    // 5  ROCKEY4 Network parallel type
   // 6  ROCKEY4 NetWork USB type

   //the type of Rockey4ND,Rockey4 should be returned by lp2

    if(lP2=7) then
    List.Items.Add('Has opened ROCKEY1');



    i:=1;
    while rt = 0 do
    begin
        mFun:=RY_FIND_NEXT;
        rt:= Rockey(mFun,mHand[i],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
        if rt<>0 then
           break;

        mHardID[i]:=lP1;
        FmtStr(str,'Find  the %xth ROCKEY',[i+1]);
        List.Items.Add(str);

        mFun:=RY_OPEN;
        rt:= Rockey(mFun,mHand[i],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
        if rt<>0 then
        begin
            FmtStr(str,'not find ROCKEY%x',[i+1]);
            List.Items.Add(str);
            break;
        end;

        //identify type
        if(lP2=7) then
        FmtStr(str,'Has open ROCKEY%x',[i+1]);
        List.Items.Add(str);
        i:=i+1;
    end;
    mRockeyNumber:=i;
for num:=0 to mRockeyNumber-1 do
begin
  List.Items.Add('*******************************************');
  FmtStr(str,'Start to test the %xthROCKEY',[num+1]);
  List.Items.Add(str);
{write}
  mFun:=RY_WRITE;
  for i:=0 to 10 do
      mBuf[i]:=31;
  mP1:=498;
  mP2:=11;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Find error %x when write ROCKEY',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Write Rockey right',[i+1]);
   List.Items.Add('write ROCKEY right');
{resd}
  mFun:=RY_READ;
  for i:=0 to 10 do
      tmpBuf[i]:=0;
  mP1:=498;
  mP2:=11;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,tmpBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Find error %x when reading rockey',[rt]);
        List.Items.Add(str);
        break;
   end
   else
   begin
      for i:=0 to 10 do
          if mBuf[i] <> tmpBuf[i] then
              break;
      if i = 11 then
         List.Items.Add('read rockey right')
      else
          List.Items.Add('read rockey right, but not the same to the writen one');
   end;
{random}
  mFun:=RY_RANDOM;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Find error %x when checking random',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Random%x:',[mP1]);
   List.Items.Add(str);
{Seed code}
  mFun:=RY_SEED;
  lP2:=$12345678;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Find error %x when sending seed code',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'seed code %x:return value:%x,%x,%x,%x',[lP2,mP1,mP2,mP3,mP4]);
   List.Items.Add(str);
   rc[0] := mP1; rc[1] := mP2;
   rc[2] := mP3; rc[3] := mP4;
{Write user ID}
  mFun:=RY_WRITE_USERID;
  lP1:=100;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Find error %x while writing User id',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Write user ID%x',[lP1]);
   List.Items.Add(str);
{Read User ID}
  mFun:=RY_READ_USERID;
  lP1:=0;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Find error %x while reading user ID',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'read user ID%x',[lP1]);
   List.Items.Add(str);
{Set module}
  mFun:=RY_SET_MOUDLE;
  mP1:=7;
  mP2:=$2122;
  mP3:=1;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Find error %x when setting module',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Set module %x, to %x, can be decreased',[mP1,mP2]);
   List.Items.Add(str);
{check module firstly}
  mFun:=RY_CHECK_MOUDLE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'check module %x but has error %x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   if mP1 = 1 then
      if mP2 = 1 then
            FmtStr(str,'check module %x,availability, can be decreased',[mP1])
      else
            FmtStr(str,'check module %x,availability, can not be decreased',[mP1])
   else
     if mP2 = 1 then
            FmtStr(str,'check module %x, invalid, can be decreased',[mP1])
      else
            FmtStr(str,'check module %x, invalid, can be decreased',[mP1]) ;
   List.Items.Add(str);

{Decrease}
 mFun:=RY_DECREASE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'decrease module %x, but find error %x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'decrease module %x, to 0X2121',[mP1]);
   List.Items.Add(str);


 {Write arithmetic1}
  cstr:='H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=0;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Find error %x when writing arithmetic1',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('Write arithmetic1 right');
{calculate 1}
  mFun:=RY_CALCULATE1;
  lP1 := 0; lP2 := 7;
  mP1 := 5; mP2 := 3;
  mP3 := 1; mP4 := $ffff;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Find error %x when calculate 1',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('calculate and input : p1=5, p2=3, p3=1, p4=0xffff');
  List.Items.Add('result: = ((5*23 + 3*17 + 0x2121) < 1) ^ 0xffff = BC71');
  FmtStr(str,'calculate and output: p1=%x, p2=%x, p3=%x, p4=%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);

{write arithmetic2}
  cstr:='A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=10;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Find error %x when writing arithmetic2',[rt]);
        List.Items.Add(str);
        break;
   end;

  List.Items.Add('Write arithmetic2 right');
{calculate2}
  mFun:=RY_CALCULATE2;
  lP1 := 10; lP2 := $12345678;
  mP1 := 1; mP2 := 2;
  mP3 := 3; mP4 := 4;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Find error%x when calculating 2',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('calculate and input: p1=1, p2=2, p3=3, p4=4');
  FmtStr(str,'result: %04x + %04x + %04x + %04x + 1 + 2 + 3 + 4 = %04x',[rc[0], rc[1], rc[2], rc[3], Word(rc[0]+rc[1]+rc[2]+rc[3]+10)]);
  List.Items.Add(str);
  FmtStr(str,'calculte and output: p1=%x, p2=%x, p3=%x, p4=%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);
{write arithmetic3}
  cstr:='A=E|E, B=F|F, C=G|G, D=H|H';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= Byte(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=17;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'find error %x when writing arithmetic3',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('write arithmetic3 rightly');
  {decrease}
 mFun:=RY_DECREASE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Decrease module %x, but find error %x',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'Decrease module %x to 0X2120',[mP1]);
   List.Items.Add(str);

{calculate3}
  mFun:=RY_CALCULATE3;
  lP1 := 17; lP2 := 6;
  mP1 := 1; mP2 := 2;
  mP3 := 3; mP4 := 4;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'Find error %x when calculating 3',[rt]);
        List.Items.Add(str);
        break;
   end;
  FmtStr(str,'Read module word started from 6: %x,%x,%x,%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);
  end;


  for num:=0 to mRockeyNumber-1 do
  begin
  mHand[num]  :=10;
   rt:= Rockey(RY_CLOSE,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   begin
        List.Items.Add('close Rockey4ND');
        break;
   end;
   end;
  

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

