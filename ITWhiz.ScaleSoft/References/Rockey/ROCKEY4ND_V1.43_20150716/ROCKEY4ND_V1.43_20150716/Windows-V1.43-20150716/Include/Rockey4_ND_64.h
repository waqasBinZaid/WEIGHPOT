// function definition
#ifndef _ROCKEY4_ND_64_
#define _ROCKEY4_ND_64_
/*(1) Find Dongle
    Input:
    function = 1
    *p1 = pass1
    *p2 = pass2
    *p3 = pass3
    *p4 = pass4
    Return:
    *lp1 = Rockey4ND HID
    return 0 = Success, else is error code

(2) Find Next Dongle
    Input:
    function = 2
    *p1 = pass1
    *p2 = pass2
    *p3 = pass3
    *p4 = pass4
    Return:
    *lp1 = Rockey4ND HID
    return 0 = Success, else is error code

(3) Open Dongle
    Input:
    function = 3
    *p1 = pass1
    *p2 = pass2
    *p3 = pass3
    *p4 = pass4
    *lp1 = Rockey4ND HID
    Return:
    *handle = Opened dongle handle
    return 0 = Success, else is error code

(4) Close Dongle
    Input:
    function = 4
    *handle = dongle handle
    Return:
    return 0 = Success, else is error code

(5) Read Dongle
    Input:
    function = 5
    *handle = dongle handle
    *p1 = pos
    *p2 = length
    buffer = pointer of buffer
    Return:
    Fill buffer with read contents
    return 0 = Success, else is error code

(6) Write Dongle
    Input:
    function = 6
    *handle = dongle handle
    *p1 = pos
    *p2 = length
    buffer = pointer of buffer
    Return:
    return 0 = Success, else is error code

(7) Generate Random Number
    Input:
    function = 7
    *handle = dongle handle
    Return:
    *p1 = random number
    return 0 = Success, else is error code
    
(8) Generate Seed Code
    Input:
    function = 8
    *handle = dongle handle
    *lp2 = seed code
    Return:
    *p1 = seed return code 1
    *p2 = seed return code 2
    *p3 = seed return code 3
    *p4 = seed return code 4
    return 0 = Success, else is error code

(9) Write User ID [*]
    Input:
    function = 9
    *handle = dongle handle
    *lp1 = User ID
    Return:
    return 0 = Success, else is error code

(10) Read User ID
     Input:
     function = 10
     *handle = dongle handle
     Return:
     *lp1 = User ID
     return 0 = Success, else is error code

(11) Set Module [*]
     Input:
     function = 11
     *handle = dongle handle
     *p1 = module number
     *p2 = module content
     *p3 = set whether allow decrease (1 = allow, 0 = no allow)
     Return:
     return 0 = Success, else is error code

(12) Check Module
     Input:
     function = 12
     *handle = dongle handle
     *p1 = module number
     Return:
     *p2 = 1 means the module is valid, 0 means the module is invalid
     *p3 = 1 means the module can't decrease, 0 means the module can decrease
     return 0 = Success, else is error code

(13) Write Arithmetic [*]
     Input:
     function = 13
     *handle = dongle handle
     *p1 = pos
     buffer = arithmetic instruction string
     Return:
     return 0 = Success, else is error code
     
(14) Calculate 1 (Hide Unit Init Content = HID high 16bit, HID low 16bit, module content, random number)
     Input:
     function = 14
     *handle = dongle handle
     *lp1 = calculate begin pos
     *lp2 = module number
     *p1 = input value 1
     *p2 = input value 2
     *p3 = input value 3
     *p4 = input value 4
     Return:
     *p1 = return code 1
     *p2 = return code 2
     *p3 = return code 3
     *p4 = return code 4
     return 0 = Success, else is error code

(15) Calculate 2 (Hide Unit Init Content = seed return code 1, seed return code 2, seed return code 3, seed return code 4)
     Input:
     function = 15
     *handle = dongle handle
     *lp1 = calculate begin pos
     *lp2 = seed code
     *p1 = input value 1
     *p2 = input value 2
     *p3 = input value 3
     *p4 = input value 4
     Return:
     *p1 = return code 1
     *p2 = return code 2
     *p3 = return code 3
     *p4 = return code 4
     return 0 = Success, else is error code

(16) Calculate 3 (Hide Unit Init Content = module content, module+1 content, module+2 content, module+3 content)
     Input:
     function = 16
     *handle = dongle handle
     *lp1 = calculate begin pos
     *lp2 = module begin pos
     *p1 = input value 1
     *p2 = input value 2
     *p3 = input value 3
     *p4 = input value 4
     Return:
     *p1 = return code 1
     *p2 = return code 2
     *p3 = return code 3
     *p4 = return code 4
     return 0 = Success, else is error code

(17) Decrease Module Unit
     Input:
     function = 17
     *handle = dongle handle
     *p1 = module number
     Return:
     return 0 = Success, else is error code
*/

#define  RY_FIND                1       // Find Dongle
#define  RY_FIND_NEXT           2       // Find Next Dongle
#define  RY_OPEN                3       // Open Dongle
#define  RY_CLOSE               4       // Close Dongle
#define  RY_READ                5       // Read Dongle
#define  RY_WRITE               6       // Write Dongle
#define  RY_RANDOM              7       // Generate Random Number
#define  RY_SEED                8       // Generate Seed Code
#define  RY_WRITE_USERID        9       // Write User ID
#define  RY_READ_USERID         10      // Read User ID
#define  RY_SET_MOUDLE          11      // Set Module
#define  RY_CHECK_MOUDLE        12      // Check Module
#define  RY_WRITE_ARITHMETIC    13      // Write Arithmetic
#define  RY_CALCULATE1          14      // Calculate 1
#define  RY_CALCULATE2          15      // Calculate 2
#define  RY_CALCULATE3          16      // Calculate 3
#define  RY_DECREASE            17      // Decrease Module Unit
#define  RY_CALLNET             18      // NetRockey4ND arithmetic

// error code
#define  ERR_SUCCESS                    0       // Success
#define  ERR_NO_ROCKEY                  3       // No Rockey4ND dongle
#define  ERR_INVALID_PASSWORD           4       // Found Rockey4ND dongle, but base password is wrong
#define  ERR_INVALID_PASSWORD_OR_ID     5       // Wrong password or Rockey4ND HID
#define  ERR_SETID                      6               // Set Rockey4ND HID wrong
#define  ERR_INVALID_ADDR_OR_SIZE       7       // Read/Write address is wrong
#define  ERR_UNKNOWN_COMMAND            8       // No such command
#define  ERR_NOTBELEVEL3                9       // Inside error
#define  ERR_READ                       10      // Read error
#define  ERR_WRITE                      11      // Write error
#define  ERR_RANDOM                     12      // Random error
#define  ERR_SEED                       13      // Seed Code error
#define  ERR_CALCULATE                  14      // Calculate error
#define  ERR_NO_OPEN                    15      // No open dongle before operate dongle
#define  ERR_OPEN_OVERFLOW              16      // Too more open dongle(>16)
#define  ERR_NOMORE                     17      // No more dongle
#define  ERR_NEED_FIND                  18      // No Find before FindNext
#define  ERR_DECREASE                   19      // Decrease error
#define  ERR_AR_BADCOMMAND              20      // Arithmetic instruction error
#define  ERR_AR_UNKNOWN_OPCODE          21      // Arithmetic operator error
#define  ERR_AR_WRONGBEGIN              22      // Const number can't use on first arithmetic instruction
#define  ERR_AR_WRONG_END               23      // Const number can't use on last arithmetic instruction
#define  ERR_AR_VALUEOVERFLOW           24      // Const number > 63
#define ERR_TOOMUCHTHREAD               25      // Too many ( > 100) threads open the dongle in the single process
#define  ERR_RECEIVE_NULL               0x100   // Receive null
#define  ERR_UNKNOWN_SYSTEM             0x102   // Unknown operate system
#define  ERR_UNKNOWN                    0xffff  // Unknown error


EXTERN_C __declspec(dllexport) WORD WINAPI Rockey(WORD function, WORD* handle, DWORD* lp1,  DWORD* lp2, WORD* p1, WORD* p2, WORD* p3, WORD* p4, BYTE* buffer);

#endif
