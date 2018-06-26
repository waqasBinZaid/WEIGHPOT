unit NrClient;
interface
uses
  Windows;
const
//NetRockey常量定义
 RY_FIND			            =       1		;    // Find
 RY_FIND_NEXT					=		2		;    // Find Next
 RY_OPEN			            =       3		;    // Open
 RY_CLOSE			            =       4		;    // Close
 RY_READ			            =       5		;    // Read
 RY_WRITE			            =       6		;    // Write
 RY_RANDOM			            =       7		;    // Generate Random
 RY_SEED			            =       8		;    // Seed
 RY_READ_USERID					=		10		;    // Read USER ID ZONE
 RY_CHECK_MOUDLE		    	=	    12		;    // Chcek Module Attribute
 RY_CALCULATE1			    	=	    14		;    // Calculate 1
 RY_CALCULATE2			    	=	    15		;    // Calculate 2
 RY_CALCULATE3			    	=	    16		;    // Calculate 3
 RY_DECREASE			    	=	    17		;    // Decrease 
 RY_IDLE	        			=		10001	;    



//Rockey错误代码
 ERR_SUCCESS			        =		0		;    //Success 
 ERR_NO_PARALLEL_PORT		    =	    1		;    //No parallel port on the computer 
 ERR_NO_DRIVER			        =		2		;    //No driver installed 
 ERR_NO_ROCKEY			        =		3		;    //No ROCKEY4 dongle 
 ERR_INVALID_PASSWORD		    =	    4		;    //ROCKEY4 dongle found, but base password is incorrect
 ERR_INVALID_PASSWORD_OR_ID 	=       5		;    //Wrong password or ROCKEY4 HID
 ERR_SETID			            =		6       ;    //Set ROCKEY4 HID wrong
 ERR_INVALID_ADDR_OR_SIZE	    =	    7		;    //Read/Write address is wrong
 ERR_UNKNOWN_COMMAND        	=       8		;    //No such command
 ERR_NOTBELEVEL3		        =		9		;    //Inside error
 ERR_READ			            =		10		;    //Read error
 ERR_WRITE                  	=       11		;    //Write error
 ERR_RANDOM                 	=       12		;    //Random error
 ERR_SEED                   	=       13		;    //Seed Code error
 ERR_CALCULATE              	=       14		;    //Calculate error
 ERR_NO_OPEN			        =		15		;    //Ry_Open must precede this operation
 ERR_OPEN_OVERFLOW          	=       16		;    //Too many open dongles (>16)
 ERR_NOMORE						=		17		;    //No more dongle
 ERR_NEED_FIND			        =		18		;    //No Find before FindNext
 ERR_DECREASE			        =		19		;    //Decrease error

 ERR_AR_BADCOMMAND		        =		20		;    //Arithmetic instruction error
 ERR_AR_UNKNOWN_OPCODE		    =	    21		;    //Arithmetic operator error
 ERR_AR_WRONGBEGIN		        =		22		;    //A constant. cannot be in the first instruction
 ERR_AR_WRONG_END		        =		23		;    //A constant. cannot be in the last instruction 
 ERR_AR_VALUEOVERFLOW	    	=	    24		;    //Const number > 63

 ERR_NET_LOGINAGAIN				=	    1001	;    //A module can only be opened once by the same process.
 ERR_NET_NETERROR		        =		1002	;    //Network error.
 ERR_NET_LOGIN		            =		1003	;    //Too many users are logged on.
 ERR_NET_INVALIDHANDLE	        =		1004	;    //Invalid handle, this handle might have been closed.
 ERR_NET_BADHARDWARE	        =		1005	;    //Defective hardware 
 ERR_NET_REFUSE	        		=		1006	;    //Client dll modified, service refused request.
 ERR_NET_BADSERVER	            =		1007	;    //Nrsvr.exe modified, service is invalid.

//网络错误代码
 ERR_INIT_SOCK			        =		2001	;    //Error when initializing.
 ERR_NOSUCHPROTO		        =		2002	;    //No such protocol.
 ERR_UDPSOCKCREATE		        =		2003    ;    //UDP error when creating socket.
 ERR_UDPSETBROADCAST		    =		2004	;    //UDP error when setting broadcast.
 ERR_UDPBINDFAILED		        =		2005	;    //UDP error when binding.
 ERR_SVRCALLBACKNULL		    =		2006	;    //Server call back null.
 ERR_TCPSOCKCREATE		        =		2007    ;    //TCP error when creating socket.
 ERR_TCPBINDFAILED		        =		2008	;    //TCP error when binding.
 ERR_TCPLISTENFAILED		    =		2009	;    //TCP error when listening.
 ERR_NOSUCHSEARCH		        =		2010	;    //No such search mode.
 ERR_UDPSEND			        =		2012	;    //UDP error when sending.
 ERR_UDPTIMEOUT			        =		2013	;    //UDP timeout error when waiting.
 ERR_UDPRECV			        =		2014	;    //UDP error when receiving.
 ERR_TCPCONNECT		            =		2015	;    //TCP error when connecting to server.
 ERR_TCPSENDTIMEOUT		        =		2016	;    //TCP time out error when sending.
 ERR_TCPSEND		            =		2017	;    //TCP error when sending.
 ERR_TCPRECVTIMEOUT		        =		2018	;    //TCP time out error when receiving.
 ERR_TCPRECV		            =		2019	;    //TCP error when receiving.
 ERR_IPXSOCKCREATE		        =		2020    ;    //IPX error when creating socket.
 ERR_IPXSETBROADCAST		    =		2021	;    //IPX error when setting broadcast.
 ERR_IPXSEND		            =		2022	;    //IPX error when sending data. 
 ERR_IPXRECV		            =		2023	;    //IPX error when receiving data.
 ERR_IPXBIND			        =		2024	;    //IPX error when binding.
 ERR_NBSRESET			        =		2025	;    //NetBIOS error when initializing.
 ERR_NBSADDNAME			        =		2026	;    //NetBIOS error when adding name.
 ERR_NBSSEND			        =		2027	;    //NetBIOS error when sending data.
 ERR_NBSRECV			        =		2028	;    //NetBIOS error when receiving data.

 ERR_UNKNOWN			        =		$ffff	;    // Unknown error 

function  NetRockey(fun:Word; var Handle:Word;
                var lp1,lp2:LongWord;
                var P1,P2,P3,P4:Word;
                var buf:Byte):Word;
                stdcall;external 'nrClient.dll';
function SetIniPathName(path:String):LongWord;
                stdcall;external 'nrClient.dll';
function NrGetLastError():LongWord;
                stdcall;external 'nrClient.dll';
function NrGetVersion():LongWord;
                stdcall;external 'nrClient.dll';
implementation
end.
