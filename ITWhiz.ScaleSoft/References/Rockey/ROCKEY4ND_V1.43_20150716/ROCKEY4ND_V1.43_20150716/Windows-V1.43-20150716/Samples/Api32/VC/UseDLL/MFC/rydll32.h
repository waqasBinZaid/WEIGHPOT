#define  RY_FIND                        1
#define  RY_FIND_NEXT			2
#define  RY_OPEN                        3
#define  RY_CLOSE                       4
#define  RY_READ                        5
#define  RY_WRITE                       6
#define  RY_RANDOM                      7
#define  RY_SEED                        8
#define  RY_WRITE_USERID		9
#define  RY_READ_USERID			10
#define  RY_SET_MOUDLE			11
#define  RY_CHECK_MOUDLE		12
#define  RY_WRITE_ARITHMETIC            13
#define  RY_CALCULATE1			14
#define  RY_CALCULATE2			15
#define  RY_CALCULATE3			16
#define  RY_DECREASE			17

//Error code
#define  ERR_SUCCESS			0
#define  ERR_NO_PARALLEL_PORT		1
#define  ERR_NO_DRIVER			2
#define  ERR_NO_ROCKEY		3
#define  ERR_INVALID_PASSWORD		4
#define  ERR_INVALID_PASSWORD_OR_ID 	5
#define  ERR_SETID			6
#define  ERR_INVALID_ADDR_OR_SIZE	7
#define  ERR_UNKNOWN_COMMAND        	8
#define  ERR_NOTBELEVEL3		9
#define  ERR_READ			10
#define  ERR_WRITE                  	11
#define  ERR_RANDOM                 	12
#define  ERR_SEED                   	13
#define  ERR_CALCULATE              	14
#define  ERR_NO_OPEN			15
#define  ERR_OPEN_OVERFLOW          	16
#define  ERR_NOMORE			17
#define  ERR_NEED_FIND			18
#define  ERR_DECREASE			19

#define  ERR_AR_BADCOMMAND		20
#define  ERR_AR_UNKNOWN_OPCODE		21
#define  ERR_AR_WRONGBEGIN		22
#define  ERR_AR_WRONG_END		23
#define  ERR_AR_VALUEOVERFLOW		24
#define  ERR_UNKNOWN			0xffff

#define  ERR_RECEIVE_NULL		0x100
#define  ERR_PRNPORT_BUSY		0x101



*/
#ifdef __cplusplus
typedef WORD (CALLBACK *ROCKEY) (WORD, WORD*, DWORD*, DWORD*, WORD*, WORD*, WORD*, WORD*, BYTE*);
#else
WORD Rockey(WORD function, WORD* handle, DWORD* lp1,  DWORD* lp2, WORD* p1, WORD* p2, WORD* p3, WORD* p4, BYTE* buffer);
#endif
