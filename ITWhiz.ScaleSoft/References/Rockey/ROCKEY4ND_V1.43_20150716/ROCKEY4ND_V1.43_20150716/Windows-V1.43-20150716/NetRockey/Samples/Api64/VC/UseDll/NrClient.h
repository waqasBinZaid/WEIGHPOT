/********************************************************************
	created:	2002/04/04
	created:	4:4:2002   16:44
	filename: 	NrClient.h
	file path:	D:\myprogram\ftProj\RockeyNet\ClientLib
	file base:	NrClient
	file ext:	h
	author:		swordhui
	
	purpose:	header file for Nrclient.dll or NrCliLib.lib.
*********************************************************************/

#pragma once

#include "windows.h"


extern "C" 
{
	DWORD WINAPI	NetRockey(WORD function, WORD *handle, DWORD *lp1, 
							   DWORD *lp2, WORD *p1, WORD *p2, WORD *p3, 
							   WORD *p4, BYTE *buffer);

	DWORD WINAPI	SetIniPathName(LPCTSTR iniName);

	DWORD WINAPI	NrGetLastError();
	DWORD WINAPI	NrGetVersion();
}




//interfaces definition

typedef DWORD (WINAPI *NETROCKEY)(WORD function, WORD *handle, DWORD *lp1, 
									 DWORD *lp2, WORD *p1, WORD *p2, WORD *p3, 
									 WORD *p4, BYTE *buffer);

typedef DWORD (WINAPI *NRSETINIPNAME)(LPCTSTR iniName);

typedef DWORD (WINAPI *NRGETLASTERROR)();
typedef DWORD (WINAPI *NRGETVERSION)();



//NetRockey constants definition
#define  RY_FIND                        1		// find Rockey
#define  RY_FIND_NEXT					2		// find next Rockey
#define  RY_OPEN                        3		// open Rockey
#define  RY_CLOSE                       4		// close Rockey
#define  RY_READ                        5		// read Rockey
#define  RY_WRITE                       6		// write Rockey
#define  RY_RANDOM                      7		// generate random number
#define  RY_SEED                        8		// generate seed
#define  RY_READ_USERID					10		// read UID
#define  RY_CHECK_MOUDLE		        12		// check module status
#define  RY_CALCULATE1			        14		// calculate 1
#define  RY_CALCULATE2			        15		// calculate 2
#define  RY_CALCULATE3			        16		// calculate 3
#define  RY_DECREASE			        17		// decrease module
#define	 RY_IDLE						10001	// NetRockey Idle



//Rockey error code
#define  ERR_SUCCESS					0		// success
#define  ERR_NO_PARALLEL_PORT			1		// no parallel port found
#define  ERR_NO_DRIVER					2		// no driver found
#define  ERR_NO_ROCKEY					3		// no NetRockey4ND found
#define  ERR_INVALID_PASSWORD			4		// wrong basic password 
#define  ERR_INVALID_PASSWORD_OR_ID 	5		// wrong password or HID
#define  ERR_SETID						6       // set HID error
#define  ERR_INVALID_ADDR_OR_SIZE		7		// invalid address or size error
#define  ERR_UNKNOWN_COMMAND        	8		// unknown command
#define  ERR_NOTBELEVEL3				9		// internal error
#define  ERR_READ						10		// read data error
#define  ERR_WRITE                  	11		// write data error
#define  ERR_RANDOM                 	12		// random number error
#define  ERR_SEED                   	13		// seed error
#define  ERR_CALCULATE              	14		// calculate error
#define  ERR_NO_OPEN					15		// no Rockey opened 
#define  ERR_OPEN_OVERFLOW          	16		// open too many Rockey
#define  ERR_NOMORE						17		// no more Rockey
#define  ERR_NEED_FIND					18		// need to use Find before FindNext
#define  ERR_DECREASE					19		// decrease error

#define  ERR_AR_BADCOMMAND				20		// bad algorithm command
#define  ERR_AR_UNKNOWN_OPCODE			21		// unknown algorithm opcode
#define  ERR_AR_WRONGBEGIN				22		// first algorithm instruction contains constant
#define  ERR_AR_WRONG_END				23		// last algorithm instruction contains constant
#define  ERR_AR_VALUEOVERFLOW			24		// constant value > 63

#define  ERR_NET_LOGINAGAIN				1001	//Same module is opened twice in same process
#define  ERR_NET_NETERROR				1002	//Network transportation error
#define	 ERR_NET_LOGIN					1003	//number of login users is full 	
#define	 ERR_NET_INVALIDHANDLE			1004	//invalid handle
#define	 ERR_NET_BADHARDWARE			1005	//bad hardware
#define	 ERR_NET_REFUSE					1006	//client Dll has been modified
#define	 ERR_NET_BADSERVER				1007	//server program has been modified

//NetRockey error code
#define ERR_INIT_SOCK					2001	//Initialize Winsock error
#define ERR_NOSUCHPROTO					2002	//No service for the protocol
#define ERR_UDPSOCKCREATE				2003    //UDP create socket error
#define ERR_UDPSETBROADCAST				2004	//UDP set broadcast error
#define ERR_UDPBINDFAILED				2005	//UDP bind error
#define ERR_SVRCALLBACKNULL				2006	//Server's call back function is null
#define ERR_TCPSOCKCREATE				2007    //TCP create socket error
#define ERR_TCPBINDFAILED				2008	//TCP bind error
#define ERR_TCPLISTENFAILED				2009	//TCP listen error
#define ERR_NOSUCHSEARCH				2010	//Unsupported search method
#define ERR_UDPSEND						2012	//UDP send data error
#define ERR_UDPTIMEOUT					2013	//UDP send data timeout
#define ERR_UDPRECV						2014	//UDP receive data error
#define	ERR_TCPCONNECT					2015	//TCP connect server error
#define ERR_TCPSENDTIMEOUT				2016	//TCP send data timeout
#define	ERR_TCPSEND						2017	//TCP send data error
#define ERR_TCPRECVTIMEOUT				2018	//TCP receive data timeout
#define	ERR_TCPRECV						2019	//TCP receive data error
#define ERR_IPXSOCKCREATE				2020    //IPX create socket error
#define ERR_IPXSETBROADCAST				2021	//IPX set broadcast error
#define	ERR_IPXSEND						2022	//IPX send data error
#define	ERR_IPXRECV						2023	//IPX receive data error
#define ERR_IPXBIND						2024	//IPX bind port error
#define ERR_NBSRESET					2025	//NBS initialize channel error
#define ERR_NBSADDNAME					2026	//NBS add name error
#define ERR_NBSSEND						2027	//NBS send error
#define ERR_NBSRECV						2028	//NBS receive error
	
#define  ERR_UNKNOWN					0xffff	// unknown error
