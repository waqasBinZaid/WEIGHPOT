#ifndef NRCLIENT__H
#define NRCLIENT__H

//Rockey Command
#define RY_FIND         1
#define RY_FIND_NEXT    2
#define RY_OPEN         3
#define RY_CLOSE        4
#define RY_READ         5
#define RY_WRITE        6
#define RY_RANDOM       7
#define RY_SEED         8
#define RY_WRITE_USERID 9
#define RY_READ_USERID  10
#define RY_SET_MODULE   11
#define RY_CHECK_MODULE 12
#define RY_WRITE_ARITHMETIC 13
#define RY_CALCULATE1   14
#define RY_CALCULATE2   15
#define RY_CALCULATE3   16
#define RY_DECREASE     17
#define RY_IDLE		10001

//Rockey Return code
#define ERR_SUCCESS             0
#define ERR_NO_PARALLEL_PORT    1
#define ERR_NO_DRIVER           2
#define ERR_NO_ROCKEY           3
#define ERR_INVALID_PASSWORD    4
#define ERR_INVALID_PASSWORD_OR_ID      5
#define ERR_SETID               6
#define ERR_INVALID_ADDR_OR_SIZE 7
#define ERR_UNKNOWN_COMMAND     8
#define ERR_NOTBELEVEL3         9
#define ERR_READ                10
#define ERR_WRITE               11
#define ERR_RANDOM              12
#define ERR_SEED                13
#define ERR_CALCULATE           14
#define ERR_NO_OPEN             15
#define ERR_OPEN_OVERFLOW       16
#define ERR_NOMORE              17
#define ERR_NEED_FIND           18
#define ERR_DECEREASE           19
#define ERR_AR_BADCOMMAND       20
#define ERR_AR_UNKNOWN_OPCODE   21
#define ERR_AR_WRONGBEGIN       22
#define ERR_AR_WRONG_END        23
#define ERR_AR_VALUEOVERFLOW    24
#define ERR_NET_NOTREGISTER     1001
#define ERR_NET_NETERROR        1002
#define ERR_NET_LOGIN           1003
#define ERR_NET_INVALIDHANDLE   1004
#define ERR_NET_BADHARDWARE	1005
#define	ERR_NET_REFUSE		1006
#define ERR_NET_BADSERVER	1007
#define ERR_INIT_SOCK           2001
#define ERR_NOSUCHPROTO         2002
#define ERR_UDPSOCKCREATE       2003
#define ERR_UDPSETBROADCAST     2004
#define ERR_UDPBINDFAILED       2005
#define ERR_SVRCALLBACKNULL     2006
#define ERR_TCPSOCKCREATE       2007
#define ERR_TCPBINDFAILED       2008
#define ERR_TCPLISTENFAILED     2009
#define ERR_NOSUCHSEACH         2010
#define ERR_UDPSEND             2011
#define ERR_UDPTIMEOUT          2012
#define ERR_UDPRECV             2013
#define ERR_TCPCONNECT          2014
#define ERR_TCPSENDTIMEOUT      2015
#define ERR_TCPSEND             2016
#define ERR_TCPRECVTIMEOUT      2017
#define ERR_TCPRECV             2018
#define ERR_IPXSOCKCREATE       2019
#define ERR_IPXSETBROADCAST     2020
#define ERR_IPXSEND             2021
#define ERR_IPXRECV             2022
#define ERR_IPXBIND             2023
#define ERR_NBSRESET            2024
#define ERR_NBSADDNAME          2025
#define ERR_NBSSEND             2026
#define ERR_NBSRECV             2027
#define ERR_NOT_FOUND_SERVER    2028
#define ERR_UNKNOWN             0xffff

unsigned int NetRockey(unsigned short function,unsigned short *handle,unsigned int *lp1,unsigned int*lp2,unsigned short *p1,unsigned short *p2,unsigned short*p3,unsigned short*p4,unsigned char*buffer);
unsigned int  SetIniPathName(unsigned char* iniName);
unsigned int  NrGetLastError();
unsigned int  NrGetVersion();
#endif


