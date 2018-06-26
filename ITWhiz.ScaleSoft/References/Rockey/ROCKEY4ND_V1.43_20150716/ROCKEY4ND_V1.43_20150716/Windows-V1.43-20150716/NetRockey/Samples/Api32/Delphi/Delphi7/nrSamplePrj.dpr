program nrSamplePrj;
{$APPTYPE CONSOLE}
uses
  SysUtils,
  NrClient in 'NrClient.pas';
var
	hResult : LongInt;
	p1, p2, p3, p4 : Word;
	lp1, lp2 : LongWord;
	handle : Word;
	hID : array[0..256] of LongWord;
	buffer:array[0..1024] of Byte;
	iRockey : LongInt;
	iModule : LongInt;
	dwMaxRockey : LongInt;
	i : Integer;
    sTemp:string;

procedure PrintLn(const strMsg: string);overload;
begin
    WriteLn(strMsg);
end;

procedure Print(const strMsg: string);overload;
begin
    Write(strMsg);
end;

procedure PrintLn(const Fmt: string; const Args: array of const);overload;
var
    strTemp:string;
begin
    strTemp := Format(Fmt, Args);
    WriteLn(strTemp);
end;

procedure Print(const Fmt: string; const Args: array of const);overload;
var
    strTemp:string;
begin
    strTemp := Format(Fmt, Args);
    Write(strTemp);
end;

function BufToStr(var buf:array of Byte):String;
var
    sTemp:String;
    i:LongInt;
begin
    i := 0;
    while true do
    begin
        if buf[i] = 0 then
            break;
        sTemp := sTemp + Chr(buf[i]);
        i := i + 1;
    end;
    BufToStr := sTemp;
end;

procedure ReportErr(lCode:LongInt);
var
    sMsg:string;
begin
    if lCode < 2000 then
        sMsg := Format('Normal error,code %d' ,[lCode])
    else
        sMsg := Format('Net Error,code %d Extend errcode %d' ,[lCode,NrGetLastError()]);
    PrintLn(sMsg);
end;

begin
    //Find Net-Rockey,using DEMO password.
    //Net-Rockey can't be write in anything when p3=p4=0;
    PrintLn('****** Finding Net-Rockeys ...');
    p1 := $C44C;
    p2 := $C8F8;
    p3 := 0;
    p4 := 0;
    dwMaxRockey := 0;
    hResult := NetRockey(RY_FIND, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);

    if ERR_SUCCESS = hResult then
        begin
            //lp1    ---- HardID of Founded Net-Rockey.
            //buffer ---- computer name of Net-Rockey insert in.
            PrintLn('Found, (%d) HID:%x @ %s',[dwMaxRockey,lp1,BufToStr(buffer)]);

            hID[dwMaxRockey] := lp1;
            dwMaxRockey := dwMaxRockey + 1;
        end
    else
        begin
            PrintLn('No net rockey found');
            Exit;
        end;

    while true do
    begin
        hResult := NetRockey(RY_FIND_NEXT, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
        If (ERR_SUCCESS = hResult) Then
        begin
            PrintLn('Found, (%d) HID:%x @ %s',[dwMaxRockey,lp1,BufToStr(buffer)]);
            hID[dwMaxRockey] := lp1;
            dwMaxRockey := dwMaxRockey + 1;
        end
        else
            break;
    end;
    PrintLn('');

    //Open a module
    iRockey := 0;
    iModule := 0;
    PrintLn('****** Opening module %d of %x ...',[iModule,hID[iRockey]]);
    lp1 := hID[iRockey];
    lp2 := iModule;
    hResult := NetRockey(RY_OPEN, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
    if ERR_SUCCESS = hResult then
    begin
        PrintLn('Opened,Handle:%d ',[handle]);
    end
    else
    begin
        ReportErr(hResult);
        Exit;
    end;
    PrintLn('');

    //Read User Memory.
    PrintLn('****** Reading user memory ...');

    p1 := 0;
    p2 := 24;
    hResult := NetRockey(RY_READ, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
    if ERR_SUCCESS = hResult then
    begin
        PrintLn('Succeed ' + BufToStr(buffer));
    end
    else
    begin
        ReportErr(hResult);
        NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
        Exit;
    end;
    PrintLn('');

    //Random number test.
    PrintLn('****** Testing Random function...');
    sTemp := '';
    for i := 1 to 5 do
    begin
        hResult := NetRockey(RY_RANDOM, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
        if ERR_SUCCESS = hResult then
            sTemp := sTemp + ' '+ IntToHex(p1,2)
        else
        begin
            ReportErr(hResult);
            NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
            Exit;
        end
    end;
    PrintLn(sTemp);
    PrintLn('');

    //Seed test.
    lp2 := $3F025;
    PrintLn('****** Seed test,seed is ' + IntToHex(lp2,4));
    hResult := NetRockey(RY_SEED, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
    if (ERR_SUCCESS = hResult) then
    begin
        PrintLn('%x %x %x %x',[p1,p2,p3,p4]);
    end
    else
    begin
        ReportErr(hResult);
        NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
        Exit;
    end;
    PrintLn('');

    //Read User ID
    lp1 := 0;
    PrintLn('****** Reading UserID...');
    hResult := NetRockey(RY_READ_USERID, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
    if (ERR_SUCCESS = hResult) then
    begin
        PrintLn('Succeed,ID = ' + IntToHex(lp1,4));
    end
    else
    begin
        ReportErr(hResult);
        Exit;
    end;
    PrintLn('');

    //Check the property of module 0
    p1 := 0;
    PrintLn('****** Checking module 0...');
    hResult := NetRockey(RY_CHECK_MOUDLE, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
    if (ERR_SUCCESS = hResult) then
    begin
        PrintLn('Succeed,validity:' + IntToStr(p2) + ' can decrease:' + IntToStr(p3));
        //******************************************************************
        //if p3 then
        //begin
        //    //you can decrese this module by using below code
        //    p1 := 0;
        //    PrintLn('****** Decrease module 0...');
        //    hResult := NetRockey(RY_DECREASE, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
        //    If (ERR_SUCCESS = hResult) Then
        //        PrintLn ("Decrease Succeed");
        //end
        //******************************************************************
    end
    else
    begin
        ReportErr(hResult);
        NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
        Exit;
    end;
    PrintLn('');

    //Calculate 1
    lp1 := 0;
    lp2 := 0;
    p1 := 1;
    p2 := 2;
    p3 := 3;
    p4 := 4;
    PrintLn('****** Calculate 1 test,Startposition ' + IntToStr(lp1));
    hResult := NetRockey(RY_CALCULATE1, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
    if (ERR_SUCCESS = hResult) then
    begin
        PrintLn('Succeed,p1=%d,p2=%d,p3=%d,p4=%d',[p1,p2,p3,p4]);
    end
    else
    begin
        ReportErr(hResult);
        NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);
        Exit;
    end;


    hResult := NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer[0]);

    PrintLn('Press Enter to continue');
    ReadLn;
end.