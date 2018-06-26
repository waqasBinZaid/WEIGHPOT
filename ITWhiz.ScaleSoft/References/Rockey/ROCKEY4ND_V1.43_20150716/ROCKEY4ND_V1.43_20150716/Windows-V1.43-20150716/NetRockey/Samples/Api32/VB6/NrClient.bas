Attribute VB_Name = "NrClient"
Option Explicit
Declare Function NetRockey Lib "Nrclient.DLL" (ByVal fcode As Integer, ByRef handle As Integer, ByRef lp1 As Long, ByRef lp2 As Long, ByRef p1 As Integer, ByRef p2 As Integer, ByRef p3 As Integer, ByRef p4 As Integer, ByRef buffer As Any) As Long
Declare Function SetIniPathName Lib "Nrclient.DLL" (ByVal path As String) As Long
Declare Function NrGetLastError Lib "Nrclient.DLL" () As Long
Declare Function NrGetVersion Lib "Nrclient.DLL" () As Long

'NetROCKEY functions
Global Const RY_FIND = 1                                                                        ' Find
Global Const RY_FIND_NEXT = 2                                                                   ' Find Next
Global Const RY_OPEN = 3                                                                        ' Open
Global Const RY_CLOSE = 4                                                                       ' Close
Global Const RY_READ = 5                                                                        ' Read
Global Const RY_WRITE = 6                                                                       ' Write
Global Const RY_RANDOM = 7                                                                      ' Generate Random
Global Const RY_SEED = 8                                                                        ' Seed
Global Const RY_READ_USERID = 10                                                        ' Read USER ID ZONE
Global Const RY_CHECK_MOUDLE = 12                                                       ' Chcek Module Attribute
Global Const RY_CALCULATE1 = 14                                                                 ' Calculate 1
Global Const RY_CALCULATE2 = 15                                                                 ' Calculate 2
Global Const RY_CALCULATE3 = 16                                                                 ' Calculate 3
Global Const RY_DECREASE = 17                                                                   ' Decrease




'Rockey Error Code
Global Const ERR_SUCCESS = 0                                                                    'Success
Global Const ERR_NO_PARALLEL_PORT = 1                                                   'No parallel port on the computer
Global Const ERR_NO_DRIVER = 2                                                                  'No driver installed
Global Const ERR_NO_ROCKEY = 3                                                                  'No ROCKEY4 dongle
Global Const ERR_INVALID_PASSWORD = 4                                                   'ROCKEY4 dongle found, but base password is incorrect
Global Const ERR_INVALID_PASSWORD_OR_ID = 5                                     'Wrong password or ROCKEY4 HID
Global Const ERR_SETID = 6                                                                      'Set ROCKEY4 HID wrong
Global Const ERR_INVALID_ADDR_OR_SIZE = 7                                       'Read/Write address is wrong
Global Const ERR_UNKNOWN_COMMAND = 8                                                    'No such command
Global Const ERR_NOTBELEVEL3 = 9                                                        'Inside error
Global Const ERR_READ = 10                                                                      'Read error
Global Const ERR_WRITE = 11                                                                     'Write error
Global Const ERR_RANDOM = 12                                                                    'Random error
Global Const ERR_SEED = 13                                                                      'Seed Code error
Global Const ERR_CALCULATE = 14                                                                 'Calculate error
Global Const ERR_NO_OPEN = 15                                                                   'Ry_Open must precede this operation
Global Const ERR_OPEN_OVERFLOW = 16                                                     'Too many open dongles (>16)
Global Const ERR_NOMORE = 17                                                                    'No more dongle
Global Const ERR_NEED_FIND = 18                                                                 'No Find before FindNext
Global Const ERR_DECREASE = 19                                                                  'Decrease error
Global Const ERR_AR_BADCOMMAND = 20                                                     'Arithmetic instruction error
Global Const ERR_AR_UNKNOWN_OPCODE = 21                                                 'Arithmetic operator error
Global Const ERR_AR_WRONGBEGIN = 22                                                     'A constant. cannot be in the first instruction
Global Const ERR_AR_WRONG_END = 23                                                      'A constant. cannot be in the last instruction
Global Const ERR_AR_VALUEOVERFLOW = 24                                                  'Const number > 63


Global Const ERR_NET_LOGINAGAIN = 1001                                          'A module can only be opened once by the same process.
Global Const ERR_NET_NETERROR = 1002                                            'Network error.
Global Const ERR_NET_LOGIN = 1003                                                       'Too many users are logged on.
Global Const ERR_NET_INVALIDHANDLE = 1004                                       'Invalid handle, this handle might have been closed.
Global Const ERR_NET_BADHARDWARE = 1005                                         'Defective hardware
Global Const ERR_NET_REFUSE = 1006                                              'Client dll modified, service refused request.
Global Const ERR_NET_BADSERVER = 1007                                           'Nrsvr.exe modified, service is invalid.





'Error code for network

Global Const ERR_INIT_SOCK = 2001                                                       'Error when initializing.
Global Const ERR_NOSUCHPROTO = 2002                                             'No such protocol.
Global Const ERR_UDPSOCKCREATE = 2003                                           'UDP error when creating socket.
Global Const ERR_UDPSETBROADCAST = 2004                                         'UDP error when setting broadcast.
Global Const ERR_UDPBINDFAILED = 2005                                           'UDP error when binding.
Global Const ERR_SVRCALLBACKNULL = 2006                                         'Server call back null.
Global Const ERR_TCPSOCKCREATE = 2007                                           'TCP error when creating socket.
Global Const ERR_TCPBINDFAILED = 2008                                           'TCP error when binding.
Global Const ERR_TCPLISTENFAILED = 2009                                         'TCP error when listening.
Global Const ERR_NOSUCHSEARCH = 2010                                            'No such search mode.
Global Const ERR_UDPSEND = 2012                                                         'UDP error when sending.
Global Const ERR_UDPTIMEOUT = 2013                                                      'UDP timeout error when waiting.
Global Const ERR_UDPRECV = 2014                                                         'UDP error when receiving.
Global Const ERR_TCPCONNECT = 2015                                                      'TCP error when connecting to server.
Global Const ERR_TCPSENDTIMEOUT = 2016                                          'TCP time out error when sending.
Global Const ERR_TCPSEND = 2017                                                         'TCP error when sending.
Global Const ERR_TCPRECVTIMEOUT = 2018                                          'TCP time out error when receiving.
Global Const ERR_TCPRECV = 2019                                                         'TCP error when receiving.
Global Const ERR_IPXSOCKCREATE = 2020                                           'IPX error when creating socket.
Global Const ERR_IPXSETBROADCAST = 2021                                         'IPX error when setting broadcast.
Global Const ERR_IPXSEND = 2022                                                         'IPX error when sending data.
Global Const ERR_IPXRECV = 2023                                                         'IPX error when receiving data.
Global Const ERR_IPXBIND = 2024                                                         'IPX error when binding.
Global Const ERR_NBSRESET = 2025                                                        'NetBIOS error when initializing.
Global Const ERR_NBSADDNAME = 2026                                                      'NetBIOS error when adding name.
Global Const ERR_NBSSEND = 2027                                                         'NetBIOS error when sending data.
Global Const ERR_NBSRECV = 2028                                                         'NetBIOS error when receiving data.
Global Const ERR_NO_CONNECTION = &H03000000 					'Connect to the NetService failed.' 


        
Global Const ERR_UNKNOWN = &HFFFF                                                       ' Unknown error
