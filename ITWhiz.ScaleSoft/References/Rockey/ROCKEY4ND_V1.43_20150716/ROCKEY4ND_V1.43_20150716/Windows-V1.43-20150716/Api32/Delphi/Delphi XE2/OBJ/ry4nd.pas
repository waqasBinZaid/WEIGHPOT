unit ry4nd;

interface

uses
  Windows, SysUtils, Classes;

const
DIGCF_DEFAULT           = $00000001;
DIGCF_PRESENT           = $00000002;
DIGCF_ALLCLASSES        = $00000004;
DIGCF_PROFILE           = $00000008;
DIGCF_DEVICEINTERFACE   = $00000010;
DIGCF_INTERFACEDEVICE   = $00000010;

{CPU ���}
VENDR_ISP  :Byte = $80;	{system upgrade software}
CTLREAD_F  :Byte = $81;
CTLWRIT_F  :Byte = $82;
CTLREAD_R  :Byte = $83;
CTLWRIT_R  :Byte = $84;
CHANG_KEY  :Byte = $85;
CLEAR_KEY  :Byte = $86;
DEVLP_UID  :Byte = $87;	{develp vendor command}
CHALLENGE  :Byte = $88;	{request random number}
VENDOR_CHK :Byte = $8A;	{vendor check}
CLR_UID	   :Byte = $89;	{clear UID}

{����״̬�뺬��}
V_SUCCESS  :Byte = $00;	{�ɹ���������}
V_VERIFY   :Byte = $01;	{�����֤����}
V_CERTIFY  :Byte = $02;	{UID����}
V_INDEX	   :Byte = $04;	{��������}
V_PROTECT  :Byte = $08;	{�豸д���������̴���}

ROCKEY2_VendorID    :Word = $096e;
ROCKEY2_ProductID   :Word = $0006;
MAX_USER_MEMORY :Word = 500;
MAX_MODULE_NUM :Word = 64;
MAX_MATHMETIC_NUM:Word  = 128;
MAX_THREAD:integer = 100;

R4ND_CHECKPASSWORD_C	:integer =	integer($01);
R4ND_READDATA_C		 :integer =	integer($02);
R4ND_WRITEDATA_C		:integer =	integer($03);
R4ND_READRANDOM_C	 :integer =		integer($04);
R4ND_WRITEMODULE_C	 :integer =	integer($05);
R4ND_SEEDCODE_C		 :integer =	integer($06);
R4ND_WRITEARITH_C		:integer =	integer($07);
R4ND_DECREASE_C			:integer =integer($08);
R4ND_COMPULTE_C		:integer =	integer($09);
R4ND_TURNOFF_C		 :integer =	integer($0A);
R4ND_READ_USERID_C	 :integer =	integer($0B);
R4ND_WRITE_USERID_C	 :integer =	integer($0C);
R4ND_CHECKMOD_C       :integer =	integer($0D);
R4ND_SETPASSWORD_C     :integer =   integer($81);
R4ND_AGENTBURN_C        :integer =  integer($8D);

 //������
R4ND_GETTYPE_C	     :integer =	integer($0E);
R4ND_READFAST_C	      :integer = integer($0F);
R4ND_WRITEFAST_C       :integer = integer($10);

// ����״̬�뺬��
 RIGHT_TOKEN           :integer =  integer($5A);     //  right
 ERROR_ERASE           :integer =  integer($61);     // return error: don't Erase clean
 ERROR_PROGRAM        :integer =   integer($62);     // return error: program error
 ERROR_INDEX			  :integer =  integer($63);     // return error: block index
 ERROR_PASSWORD		 :integer =	 integer($64 );	 // check password error
 ERROR_NOTAUTHORITY	 :integer =	integer($65);	 // it have not authority
 ERROR_UNKNOWN        :integer =   integer($6E);     // unknown error

// �����豸�򿪵�״̬
 PASS_ANYONE        :integer =     integer($00);     // ����״̬
 PASS_USERPIN      :integer =      integer($01);     // ��ͨ�û�״̬
 PASS_SOPIN        :integer =      integer($02);     // �����û�״̬
 PASS_LOCK1			:integer =	integer($40);     // ����״̬
 PASS_LOCK2		:integer =		integer($80);     // ����״̬

// ������� ===========================================================
// �ɹ���û�д���
//2005.11.24�޸�
 ERR_SUCCESS								    :integer = integer(0);

// û���ҵ�����Ҫ����豸(��������)
 R4NDERR_NO_SUCH_DEVICE							:integer = integer($A0100001);
// �ڵ��ô˹���ǰ��Ҫ�ȵ��� RY2_Open ���豸(��������)
 R4NDERR_NOT_OPENED_DEVICE						:integer = integer($A0100002);
// ������ UID ����(��������)
 R4NDERR_WRONG_UID								:integer = integer($A0100003);
// ��д���������Ŀ���������(��������)
 R4NDERR_WRONG_INDEX								:integer = integer($A0100004);
// ���� GenUID ���ܵ�ʱ�򣬸����� seed �ַ������ȳ����� 64 ���ֽ�(��������)
 R4NDERR_TOO_LONG_SEED							:integer = integer($A0100005);
// ��ͼ��д�Ѿ�д������Ӳ��(��������)
 R4NDERR_WRITE_PROTECT							:integer = integer($A0100006);
// ���豸��(Windows ����)
 R4NDERR_OPEN_DEVICE								:integer = integer($A0100007);
// ����¼��(Windows ����)
 R4NDERR_READ_REPORT								:integer = integer($A0100008);
// д��¼��(Windows ����)
 R4NDERR_WRITE_REPORT							:integer = integer($A0100009);
// �ڲ�����(Windows ����)
 R4NDERR_SETUP_DI_GET_DEVICE_INTERFACE_DETAIL	:integer = integer($A010000A);
// �ڲ�����(Windows ����)
 R4NDERR_GET_ATTRIBUTES							:integer = integer($A010000B);
// �ڲ�����(Windows ����)
 R4NDERR_GET_PREPARSED_DATA						:integer = integer($A010000C);
// �ڲ�����(Windows ����)
 R4NDERR_GETCAPS									:integer = integer($A010000D);
// �ڲ�����(Windows ����)
 R4NDERR_FREE_PREPARSED_DATA						:integer = integer($A010000E);
// �ڲ�����(Windows ����)
 R4NDERR_FLUSH_QUEUE								:integer = integer($A010000F);
// �ڲ�����(Windows ����)
 R4NDERR_SETUP_DI_CLASS_DEVS						:integer = integer($A0100010);
// �ڲ�����(Windows ����)
 R4NDERR_GET_SERIAL								:integer = integer($A0100011);
 // �ڲ�����(Windows ����)
 R4NDERR_GET_PRODUCT_STRING						:integer = integer($A0100012);
// �ڲ�����
 R4NDERR_TOO_LONG_DEVICE_DETAIL					:integer = integer($A0100013);
 // δ֪���豸(Ӳ������)
 R4NDERR_UNKNOWN_DEVICE                          :integer = integer($A0100020);
// ������֤����(Ӳ������)
 R4NDERR_VERIFY                                  :integer = integer($A0100021);
 R4NDERR_INDEX									:integer = integer($A0100004);
 R4NDERR_ERASE									:integer = integer($A0100022);

//У��������
 R4NDERR_PASSWORD								:integer = integer($A0100023);
// δ֪����(Ӳ������)
 R4NDERR_UNKNOWN_ERROR							:integer = integer($A010FFFF);

RY_FIND                        =1 ;		{����}
RY_FIND_NEXT		       =2 ;		{����һ��}
RY_OPEN                        =3 ;		{����}
RY_CLOSE                       =4 ;		{�ر���}
RY_READ                        =5 ;		{����}
RY_WRITE                       =6 ;		{д��}
RY_RANDOM                      =7 ;		{��������� }
RY_SEED                        =8 ;		{���������� }
RY_WRITE_USERID		       =9 ;		{д�û� ID  }
RY_READ_USERID		       =10;		{���û� ID  }
RY_SET_MOUDLE		       =11;		{����ģ���� }
RY_CHECK_MOUDLE		       =12;		{���ģ��״̬}
RY_WRITE_ARITHMETIC            =13;		{д�㷨 }
RY_CALCULATE1		       =14;		{���� 1 }
RY_CALCULATE2		       =15;		{���� 2 }
RY_CALCULATE3		       =16;		{���� 3 }
RY_DECREASE		       =17;		{�ݼ�ģ�鵥Ԫ }
{������}
R4NDERR_NO_PARALLEL_PORT		=1;		{�˻�û�в��� }
R4NDERR_NO_DRIVER			=2;		{û��װ��������}
R4NDERR_NO_ROCKEY	                =3;		{������û�� Rockey ��}
R4NDERR_INVALID_PASSWORD		=4;		{�������� Rockey ��, ����������(pass1, pass2)��}
R4NDERR_INVALID_PASSWORD_OR_ID 	=5;		{����������Ӳ�� ID }
R4NDERR_SETID			=6;               {����Ӳ�� ID �� }
R4NDERR_INVALID_ADDR_OR_SIZE	=7;		{��д��ַ�򳤶����� }
R4NDERR_UNKNOWN_COMMAND        	=8;		{û�д�����}
R4NDERR_NOTBELEVEL3		        =9;		{�ڲ����� }
R4NDERR_READ			=10;		{�����ݴ� }
R4NDERR_WRITE                  	=11;		{д���ݴ� }
R4NDERR_RANDOM                 	=12;		{������� }
R4NDERR_SEED                   	=13;		{������� }
R4NDERR_CALCULATE              	=14;		{�����   }
R4NDERR_NO_OPEN			=15;		{�ڲ���ǰû�д���  }
R4NDERR_OPEN_OVERFLOW          	=16;		{�򿪵���̫��(>16)   }
R4NDERR_NOMORE			=17;		{�Ҳ����������      }
R4NDERR_NEED_FIND			=18;		{û�� Find ֱ������ FindNext }
R4NDERR_DECREASE			=19;		{�ݼ���          }
R4NDERR_AR_BADCOMMAND		=20;		{�㷨ָ���      }
R4NDERR_AR_UNKNOWN_OPCODE		=21;		{�㷨�������    }
R4NDERR_AR_WRONGBEGIN		=22;		{�㷨��һ��ָ��г���}
R4NDERR_AR_WRONG_END		=23;		{�㷨���һ��ָ��г���}
R4NDERR_AR_VALUEOVERFLOW		=24;		{�㷨�г���ֵ > 63  }
R4NDERR_TOOMUCHTHREAD	 = 25; //�㷨�г���ֵ > 63
R4NDERR_UNKNOWN			=65535;		{δ֪����     }
R4NDERR_RECEIVE_NULL		=256;		{���ղ���     }
R4NDERR_PRNPORT_BUSY		=257;		{��ӡ��æ     }

type
    PWord = ^Word;
    PLongword = ^Longword;
    PHIDP_PREPARSED_DATA = ^Byte;
    PPHIDP_PREPARSED_DATA = ^PHIDP_PREPARSED_DATA;
    PCSTR = ^AnsiChar;
    PByte = ^Byte;
    psize_t = ^size_t;
    size_t = Cardinal;

    GUID = record
        Data1:Longword;
        Data2:Word;
        Data3:Word;
        Data4: array [0..7] of Byte;
    end;

    Array128 =  array[0..127]of WORD;
    pArray128 = ^Array128;

    LPGUID = ^GUID;

    LPTDateTime = ^TDateTime;

     _FILE=record
      curp:^Byte;
      buffer:^Byte;
      level:integer;
      bsize:integer;
      istemp:Word;
      flags:Word;
      hold:Word;
      fd:shortint;
      token:byte;
    end;
    P_FILE=^_FILE;

    HIDP_CAPS = record
        Usage:Word;
        UsagePage:Word;
        InputReportByteLength:Word;
        OutputReportByteLength:Word;
        FeatureReportByteLength:Word;
        Reserved: array [0..16] of Word;
        NumberLinkCollectionNodes:Word;
        NumberInputButtonCaps:Word;
        NumberInputValueCaps:Word;
        NumberInputDataIndices:Word;
        NumberOutputButtonCaps:Word;
        NumberOutputValueCaps:Word;
        NumberOutputDataIndices:Word;
        NumberFeatureButtonCaps:Word;
        NumberFeatureValueCaps:Word;
        NumberFeatureDataIndices:Word;
    end;

    PHIDP_CAPS = ^HIDP_CAPS;

    HIDD_ATTRIBUTES = record
        Size:Longword;
        VendorID:Word;
        ProductID:Word;
        VersionNumber:Word;
    end;

    PHIDD_ATTRIBUTES = ^HIDD_ATTRIBUTES;

    SP_DEVICE_INTERFACE_DATA = record
        cbSize:Longword;
        InterfaceClassGuid:GUID;
        Flags:Longword;
        Reserved:Longword;
    end;

    PSP_DEVICE_INTERFACE_DATA = ^SP_DEVICE_INTERFACE_DATA;

    SP_DEVICE_INTERFACE_DETAIL_DATA_A = record
        cbSize:Longword;
        DevicePath: array [0..4096] of AnsiChar;
    end;

    PSP_DEVICE_INTERFACE_DETAIL_DATA_A = ^SP_DEVICE_INTERFACE_DETAIL_DATA_A;
    PSP_DEVICE_INTERFACE_DETAIL_DATA = ^SP_DEVICE_INTERFACE_DETAIL_DATA_A;

    SP_DEVINFO_DATA = record
        cbSize:Longword;
        ClassGuid:GUID;
        DevInst:Longword;
        Reserved:Longword;
    end;

    PSP_DEVINFO_DATA = ^SP_DEVINFO_DATA;

    { ===============================================================}

  	Feature_Report = packed record
        id: Byte;
        command: array[0..4] of Byte;
        data: array[0..17] of Byte;
        CrcData: Byte;
  	end;

    PFeature_Report = ^Feature_Report;

    Device_Descript = record
        device_path: array[0..255] of AnsiChar;
        device_handle: THandle;
        uid: Longword;
        hid: Longword;
        hver: Word;
        mutex: THandle;
    end;

  {$EXTERNALSYM HidD_FreePreparsedData}
  function HidD_FreePreparsedData (PreparsedData:PHIDP_PREPARSED_DATA):Boolean;cdecl;
  {$EXTERNALSYM HidP_GetCaps}
  function HidP_GetCaps (PreparsedData:PHIDP_PREPARSED_DATA; Capabilities:PHIDP_CAPS):Longint;cdecl;
  {$EXTERNALSYM HidD_GetPreparsedData}
  function HidD_GetPreparsedData (HidDeviceObject:THandle; PreparsedData:PPHIDP_PREPARSED_DATA):Boolean;cdecl;
  {$EXTERNALSYM HidD_SetFeature}
  function HidD_SetFeature (HidDeviceObject:THandle; ReportBuffer:pointer; ReportBufferLength:Longword):Boolean;cdecl;
  {$EXTERNALSYM HidD_GetFeature}
  function HidD_GetFeature (HidDeviceObject:THandle; ReportBuffer:pointer; ReportBufferLength:Longword):Boolean;cdecl;
  {$EXTERNALSYM HidD_FlushQueue}
  function HidD_FlushQueue (HidDeviceObject:THandle):Boolean;cdecl;
  {$EXTERNALSYM HidD_GetSerialNumberString}
  function HidD_GetSerialNumberString(HidDeviceObject:THandle; Buffer:PAnsiChar; BufferLength:Longword):Boolean;cdecl;
  {$EXTERNALSYM HidD_GetProductString}
  function HidD_GetProductString(HidDeviceObject:THandle; Buffer:PAnsiChar; BufferLength:Longword):Boolean;cdecl;
  {$EXTERNALSYM HidD_GetAttributes}
  function HidD_GetAttributes (HidDeviceObject:THandle; Attributes:PHIDD_ATTRIBUTES):Boolean;cdecl;
  {$EXTERNALSYM HidD_GetHidGuid}
  function HidD_GetHidGuid ( HidGuid:LPGUID ):integer;cdecl;
  {$EXTERNALSYM HidD_GetManufacturerString}
  function HidD_GetManufacturerString(HidDeviceObject:THANDLE;Buffer:PAnsiChar; BufferLength:ULONG):Boolean;cdecl;

  {$EXTERNALSYM SetupDiDestroyDeviceInfoList}
  function SetupDiDestroyDeviceInfoList (DeviceInfoSet:THandle):Boolean;cdecl;
  {$EXTERNALSYM SetupDiGetDeviceInterfaceDetailA}
  function SetupDiGetDeviceInterfaceDetailA (DeviceInfoSet:THandle; DeviceInterfaceData:PSP_DEVICE_INTERFACE_DATA; DeviceInterfaceDetailData:PSP_DEVICE_INTERFACE_DETAIL_DATA_A; DeviceInterfaceDetailDataSize:Longword; RequiredSize:PLongword; DeviceInfoData:PSP_DEVINFO_DATA):Boolean;cdecl;
  {$EXTERNALSYM SetupDiEnumDeviceInterfaces}
  function SetupDiEnumDeviceInterfaces (DeviceInfoSet:THandle; DeviceInfoData:PSP_DEVINFO_DATA; InterfaceClassGuid:LPGUID; MemberIndex:Longword; DeviceInterfaceData:PSP_DEVICE_INTERFACE_DATA):Boolean;cdecl;
  {$EXTERNALSYM SetupDiGetClassDevsA}
  function SetupDiGetClassDevsA (ClassGuid:LPGUID; Enumerator:PCSTR; hwndParent:HWND; Flags:Longword):THandle;cdecl;


  {$EXTERNALSYM _memset}
  function _memset(s: Pointer; c: Integer; n: size_t): Pointer; cdecl;
  {$EXTERNALSYM _memcpy}
  function _memcpy(s1: Pointer; const s2: Pointer; n: size_t): Pointer; cdecl;
  {$EXTERNALSYM _memcmp}
  function _memcmp(s1: Pointer; const s2: Pointer; n: size_t): Integer; cdecl;
  {$EXTERNALSYM _strcpy}
  function _strcpy(s1: PAnsiChar; const s2: PAnsiChar): PAnsiChar; cdecl;
  {$EXTERNALSYM _strlen}
  function _strlen(const s: PAnsiChar): size_t; cdecl;
  {$EXTERNALSYM _strrchr}
  function _strrchr(const s: PAnsiChar; c : integer): PAnsiChar; cdecl;

  {$EXTERNALSYM _strcmp}
  function _strcmp(const s1, s2: PAnsiChar): Integer; cdecl;
  {$EXTERNALSYM _strncmp}
  function _strncmp(const s1, s2: PAnsiChar; n: size_t): Integer; cdecl;
  {$EXTERNALSYM _strncpy}
  function _strncpy(s1: PAnsiChar; const s2: PAnsiChar; n: size_t): PAnsiChar; cdecl;
  {$EXTERNALSYM _sscanf}
  function _sscanf(const s, format: PAnsiChar): Integer; cdecl; varargs;
  {$EXTERNALSYM _sprintf}
  function _sprintf(s: PAnsiChar; const format: PAnsiChar): Integer; cdecl; varargs;

  {$EXTERNALSYM _malloc}
  function _malloc(size : size_t): Pointer; cdecl;
  {$EXTERNALSYM _free}
  procedure _free(memblock : Pointer); cdecl;
  {$EXTERNALSYM _access}
  function _access(path : PAnsiChar; mode : Integer): Integer; cdecl;

  {$EXTERNALSYM _strcat}
  function _strcat(s1: PAnsiChar; const s2: PAnsiChar): PAnsiChar; cdecl;
  {$EXTERNALSYM __splitpath}
  procedure __splitpath(const path: PAnsiChar; drive,dir,fname,ext: PAnsiChar); cdecl;
  {$EXTERNALSYM __makepath}
  procedure __makepath(path: PAnsiChar; const drive,dir,fname,ext: PAnsiChar); cdecl;

  {$EXTERNALSYM _fopen}
  function _fopen(const filename,mode: PAnsiChar): _FILE; cdecl;
  {$EXTERNALSYM _fseek}
  function _fseek(stream : _FILE; offset : longint; origin : Integer): Integer; cdecl;
  {$EXTERNALSYM _ftell}
  function _ftell(stream : _FILE): longint; cdecl;
  {$EXTERNALSYM _fread}
  function _fread(buffer : PByte; size,count : size_t; stream : _FILE): size_t; cdecl;
  {$EXTERNALSYM _fclose}
  function _fclose(stream : _FILE): Integer; cdecl;
  {$EXTERNALSYM _srand}
  procedure _srand(seed : Cardinal);cdecl;
  {$EXTERNALSYM _time}
  function _time(timer : LPTDateTime) : TDateTime;cdecl;
  {$EXTERNALSYM _itoa}
  function _itoa(value : Integer; str : PAnsiChar ; radix : Integer) : PAnsiChar;cdecl;
  {$EXTERNALSYM _rand}
  function _rand() : Integer; cdecl;

  {$EXTERNALSYM Rockey}
  function  Rockey( fun: Word ;var Handle:Word;var lp1,lp2:LongWord;
           var P1,P2,P3,P4:Word;var buf:Byte):Word;stdcall;
  {$EXTERNALSYM R4ND_Init}
   procedure  R4ND_Init();stdcall;



var
    hHid:THandle = 0;
    hSetupApi:THandle = 0;
    R4NDnum:Longword = 0;
    R4NDlist:array [0..31] of Device_Descript;
    wCurrentFindID:WORD = $8000;
    g_buf:Array[0..255] of PAnsiChar;

    g_dwThreadId :array [0..31,0..100]  of DWORD;
    
implementation
const
msvcrtdll       = 'msvcrt.dll';
hiddll          = 'HID.DLL';
setupapidll     = 'SETUPAPI.DLL';

{$LINK 'Rockey4ND.obj'} //�����ⲿOBJ�ļ�
function Rockey;external;
procedure R4ND_Init;external;


//hid function
function HidD_FreePreparsedData ; external hiddll name 'HidD_FreePreparsedData' ;
function HidP_GetCaps; external hiddll name 'HidP_GetCaps' ;
function HidD_GetPreparsedData ; external hiddll name 'HidD_GetPreparsedData' ;
function HidD_SetFeature ; external hiddll name 'HidD_SetFeature' ;
function HidD_GetFeature ; external hiddll name 'HidD_GetFeature' ;
function HidD_FlushQueue ; external hiddll name 'HidD_FlushQueue';
function HidD_GetSerialNumberString; external hiddll name 'HidD_GetSerialNumberString';
function HidD_GetProductString; external hiddll name 'HidD_GetProductString';
function HidD_GetAttributes ; external hiddll name 'HidD_GetAttributes';
function HidD_GetHidGuid ; external hiddll name 'HidD_GetHidGuid';
function HidD_GetManufacturerString; external hiddll name 'HidD_GetManufacturerString';

//setupapi function
function SetupDiDestroyDeviceInfoList ; external setupapidll name 'SetupDiDestroyDeviceInfoList';
function SetupDiGetDeviceInterfaceDetailA ; external setupapidll name 'SetupDiGetDeviceInterfaceDetailA';
function SetupDiEnumDeviceInterfaces ;external setupapidll name 'SetupDiEnumDeviceInterfaces' ;
function SetupDiGetClassDevsA ; external setupapidll name 'SetupDiGetClassDevsA';

//msvcrt function
function _memset; external msvcrtdll name 'memset';
function _memcpy; external msvcrtdll name 'memcpy';
function _memcmp; external msvcrtdll name 'memcmp';
function _strcpy; external msvcrtdll name 'strcpy';
function _strrchr; external msvcrtdll name 'strrchr';
function _strlen; external msvcrtdll name 'strlen';
function _strcmp; external msvcrtdll name 'strcmp';
function _strncmp; external msvcrtdll name 'strncmp';
function _strncpy; external msvcrtdll name 'strncpy';
function _sscanf; external msvcrtdll name 'sscanf';
function _sprintf; external msvcrtdll name 'sprintf';
function _malloc; external msvcrtdll name 'malloc';
procedure _free; external msvcrtdll name 'free';
function _access; external msvcrtdll name '_access';
function _strcat; external msvcrtdll name 'strcat';
procedure __splitpath;external msvcrtdll name '_splitpath';
procedure __makepath;external msvcrtdll name '_makepath';
function _fopen; external msvcrtdll name 'fopen';
function _fseek; external msvcrtdll name 'fseek';
function _ftell; external msvcrtdll name 'ftell';
function _fread; external msvcrtdll name 'fread';
function _fclose; external msvcrtdll name 'fclose';
procedure _srand; external msvcrtdll name 'srand';
function _time; external msvcrtdll name 'time';
function _itoa; external msvcrtdll name '_itoa';
function _rand; external msvcrtdll name 'rand';

end.

