unit Main;

interface

uses
  SysUtils, Windows, Messages, Classes, Graphics, Controls,
  Forms, Dialogs, StdCtrls, Buttons, ExtCtrls, Menus,rockey4nd;

type
    TMainForm = class(TForm)
        List: TListBox;
        Button1: TButton;
        procedure WindowTile(Sender: TObject);
        procedure WindowCascade(Sender: TObject);
        procedure WindowArrange(Sender: TObject);
        procedure Button1Click(Sender: TObject);
        procedure BitBtn1Click(Sender: TObject);
    end;

var
  MainForm: TMainForm;
  mBuf:array[0..1024] of BYTE;
  mFun,mP1,mP2,mP3,mP4,rt:WORD;
  lP1,lP2:DWORD;
  mHand:array[0..16] of WORD;
  mHardID:array[0..16] of DWORD;
  rc:array[0..4] of WORD;
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
    mRockeyNumber:WORD;
    tmpBuf:array[0..30] of BYTE;
    cStr:array[0..100] of AnsiChar;
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
        FmtStr(str,'没找到ROCKEY1,error:%d ',[rt]);
        List.Items.Add(str);
        exit;
    end;
    List.Items.Add('找到第1个ROCKEY');

    mHardID[0]:=lp1;
    mFun:=RY_OPEN;
    rt:= Rockey(mFun,mHand[0],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
    if rt<>0 then
    begin
        FmtStr(str,'没打开ROCKEY1,error:%d ',[rt]);
        List.Items.Add(str);
        exit;
    end;
    List.Items.Add('已打开ROCKEY1');

    i:=1;
    while rt = 0 do
    begin
        mFun:=RY_FIND_NEXT;
        rt:= Rockey(mFun,mHand[i],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
        if rt<>0 then
           break;

        mHardID[i]:=lP1;
        FmtStr(str,'找到第%d个ROCKEY',[i+1]);
        List.Items.Add(str);

        mFun:=RY_OPEN;
        rt:= Rockey(mFun,mHand[i],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
        if rt<>0 then
        begin
            FmtStr(str,'没打开ROCKEY%d',[i+1]);
            List.Items.Add(str);
            break;
        end;
        FmtStr(str,'已打开ROCKEY%d',[i+1]);
        List.Items.Add(str);
        i:=i+1;
    end;
    mRockeyNumber:=i;
for num:=0 to mRockeyNumber-1 do
begin
  List.Items.Add('*******************************************');
  FmtStr(str,'开始测试第%d个ROCKEY',[num+1]);
  List.Items.Add(str);
{写}
  mFun:=RY_WRITE;
  for i:=0 to 30 do
      mBuf[i]:=i;
  mP1:=0;
  mP2:=30;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'写ROCKEY时发现%d号错',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'写ROCKEY正确',[i+1]);
   List.Items.Add('正确写入ROCKEY');
{读}
  mFun:=RY_READ;
  for i:=0 to 30 do
      tmpBuf[i]:=0;
  mP1:=0;
  mP2:=30;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,tmpBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'读ROCKEY时发现%d号错',[rt]);
        List.Items.Add(str);
        break;
   end
   else
   begin
      for i:=0 to 29 do
          if mBuf[i] <> tmpBuf[i] then
              break;
      if i = 30 then
         List.Items.Add('正确读出ROCKEY')
      else
          List.Items.Add('正确读出ROCKEY,但与写入的不同');
   end;
{随机码}
  mFun:=RY_RANDOM;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'检测随机码时发现%d号错',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'随机码%d:',[mP1]);
   List.Items.Add(str);
{种子码}
  mFun:=RY_SEED;
  lP2:=$12345678;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'发送种子码时发现%d号错',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'种子码%x:返回值:%x,%x,%x,%x',[lP2,mP1,mP2,mP3,mP4]);
   List.Items.Add(str);
   rc[0] := mP1; rc[1] := mP2;
   rc[2] := mP3; rc[3] := mP4;
{写用户ID}
  mFun:=RY_WRITE_USERID;
  lP1:=100;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'写用户ID时发现%d号错',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'写用户ID%x',[lP1]);
   List.Items.Add(str);
{读用户ID}
  mFun:=RY_READ_USERID;
  lP1:=0;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'读用户ID时发现%d号错',[rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'读出用户ID%x',[lP1]);
   List.Items.Add(str);
{设置模块}
  mFun:=RY_SET_MOUDLE;
  mP1:=7;
  mP2:=$2122;
  mP3:=1;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'设置模块%x时发现%x号错',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'设置模块%x,为%x,可递减',[mP1,mP2]);
   List.Items.Add(str);
{检测模块第一次}
  mFun:=RY_CHECK_MOUDLE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'检测模块%x时发现%x号错',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   if mP2 = 1 then
      if mP3 = 1 then
            FmtStr(str,'检测模块%x,有效,可递减',[mP1])
      else
            FmtStr(str,'检测模块%x,有效,不可递减',[mP1])
   else
     if mP3 = 1 then
            FmtStr(str,'检测模块%x,无效,可递减',[mP1])
      else
            FmtStr(str,'检测模块%x,无效,不可递减',[mP1]) ;
   List.Items.Add(str);

{递减}
 mFun:=RY_DECREASE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'递减模块%x时发现%x号错',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'递减模块%x,为0X2121',[mP1]);
   List.Items.Add(str);


 {写算法1}
  cstr:='H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= BYTE(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=0;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'写算法1时发现%x号错',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('正确写入算法1');
{计算一}
  mFun:=RY_CALCULATE1;
  lP1 := 0; lP2 := 7;
  mP1 := 5; mP2 := 3;
  mP3 := 1; mP4 := $ffff;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'计算1时发现%x号错',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('计算输入: p1=5, p2=3, p3=1, p4=0xffff');
  List.Items.Add('结果: = ((5*23 + 3*17 + 0x2121) < 1) ^ 0xffff = BC71');
  FmtStr(str,'计算输出: p1=%x, p2=%x, p3=%x, p4=%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);

{写算法2}
  cstr:='A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= BYTE(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=10;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'写算法2时发现%x号错',[rt]);
        List.Items.Add(str);
        break;
   end;
  
  List.Items.Add('正确写入算法2');
{计算2}
  mFun:=RY_CALCULATE2;
  lP1 := 10; lP2 := $12345678;
  mP1 := 1; mP2 := 2;
  mP3 := 3; mP4 := 4;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'计算2时发现%x号错',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('计算输入: p1=1, p2=2, p3=3, p4=4');
  FmtStr(str,'结果: %04x + %04x + %04x + %04x + 1 + 2 + 3 + 4 = %04x',[rc[0], rc[1], rc[2], rc[3], WORD(rc[0]+rc[1]+rc[2]+rc[3]+10)]);
  List.Items.Add(str);
  FmtStr(str,'计算输出: p1=%x, p2=%x, p3=%x, p4=%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);
{写算法3}
  cstr:='A=E|E, B=F|F, C=G|G, D=H|H';
  for i:=0 to strlen(cstr) do
      mBuf[i]:= BYTE(cstr[i]);
  mBuf[i]:=0;
  mFun:=RY_WRITE_ARITHMETIC;
  mP1:=17;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'写算法3时发现%x号错',[rt]);
        List.Items.Add(str);
        break;
   end;
  List.Items.Add('正确写入算法3');
  {递减}
 mFun:=RY_DECREASE;
  mP1:=7;
   rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'递减模块%x时发现%x号错',[mP1,rt]);
        List.Items.Add(str);
        break;
   end;
   FmtStr(str,'递减模块%x,为0X2120',[mP1]);
   List.Items.Add(str);

{计算3}
  mFun:=RY_CALCULATE3;
  lP1 := 17; lP2 := 6;
  mP1 := 1; mP2 := 2;
  mP3 := 3; mP4 := 4;
  rt:= Rockey(mFun,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
   if rt<>0 then
   begin
        FmtStr(str,'计算3时发现%x号错',[rt]);
        List.Items.Add(str);
        break;
   end;
  FmtStr(str,'读出从6开始的模块字: %x,%x,%x,%x',[mP1,mP2,mP3,mP4]);
  List.Items.Add(str);
  end;
  for num:=0 to mRockeyNumber-1 do
  begin
    rt:= Rockey(RY_CLOSE,mHand[num],lP1,lP2,mP1,mP2,mP3,mP4,mBuf[0]);
    FmtStr(str,'关闭Rockey4nd: %x',[rt]);
    List.Items.Add(str);
   end;
   R4ND_Finish();

end;

procedure TMainForm.BitBtn1Click(Sender: TObject);
begin
     close()
end;

end.
