.386
		.model flat, stdcall
		option casemap :none   ; case sensitive

include		windows.inc
include         user32.inc
include         Rockey4ND.inc
include		kernel32.inc
includelib	kernel32.lib
includelib      user32.lib

RockeyAS PROTO rcode:DWORD
 
.data

RockeyDll db "Rockey4ND.dll",0
szRockeyFun db 'Rockey',0
szFmt1 db '%d',0
szFmt2 db '%s',0
szFmt3 db '%d-%d-%d-%d',0
szFmt4 db '%d-%d',0
szSuccess db 'Operation successed',0
szFail db 'Operation failed',0
szSuccess1 db 'Find Rockey successed',0
szFail1 db    'Find Rockey failed',0
szSuccess2   db 'Open Rockey successed',0
szFail2     db 'Open Rockey failed',0
szSuccess3   db 'Write hello to Rockey successed',0
szFail3    db 'Write hello to Rockey failed',0
szSuccess4    db 'Read Rockey:',0,0,0,0,0,0,0
szFail4    db 'Read Rockey failed',0
szSuccess5    db 'Create random:',0
szFail5    db 'Create random failed',0
szSuccess6    db 'Generate seed code:',0
szFail6    db 'Generate seed code failed',0
szSuccess7    db 'Write USER ID:',0
szFail7    db 'Write USER ID failed',0
szSuccess8    db 'Read USER ID:',0
szFail8   db 'Read USER ID failed',0
szFail9   db 'Set module failed',0
szFail10   db 'Read module failed',0
szSuccess11  db 'Write arithmetic successed',0
szFail11  db 'Write arithmetic failed',0
szSuccess12  db 'Calculate arithmetic result:',0
szFail12  db 'Calculate arithmetic failed',0
szSuccess13  db 'All opertion is successed,rockey will be closed.',0
sz1 db 'Set Moudle 7: Value =',0
sz2 db 'Check Moudle 7:',0
Rockey dd 0
handle  dd 0
lp1     dd 0
lp2     dd 0
p1      dw 0c44ch
p2      dw 0c8f8h
p3      dw 00799h
p4      dw 0c43bh
buffer  db 1024 dup(0)
tmpbuffer db 60 dup(0)
tmpbuffer1 db 120 dup(0)
retcode dw 0
rc      dw 4 dup(0)
cmd     db "H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D", 0
info1   db "Hello"



.code

start:


;Get the Rockey function address
invoke 	LoadLibrary,offset RockeyDll

xor edx,edx
mov handle,edx
mov ebx,eax

.if ebx
	invoke GetProcAddress,ebx,offset szRockeyFun
	mov Rockey,eax	
.else
	invoke ExitProcess,1	
.endif	

;Find Rockey
invoke RockeyAS,RY_FIND
    .IF (ax == 0)
        invoke MessageBox,NULL,addr szSuccess1,addr szSuccess,MB_OK
    .else
        invoke MessageBox,NULL,addr szFail1,addr szFail,MB_OK
        invoke ExitProcess,1
    .ENDIF
    
;Open Rockey
invoke RockeyAS,RY_OPEN
    .if (ax ==0)
    	invoke MessageBox,NULL,addr szSuccess2,addr szSuccess,MB_OK
    .else
    	invoke MessageBox,NULL,addr szFail2,addr szFail,MB_OK
    	invoke ExitProcess,1
    .endif
 
;Write Rockey
mov p1, 4
mov p2, 5
invoke lstrcpy, ADDR buffer, ADDR info1
invoke RockeyAS, RY_WRITE
    .if (ax ==0)
    	invoke MessageBox,NULL,addr szSuccess3,addr szSuccess,MB_OK
    .else
    	invoke MessageBox,NULL,addr szFail3,addr szFail,MB_OK
    	invoke ExitProcess,1
.ENDIF


;Read
mov p1, 4
mov p2, 5
invoke RtlZeroMemory,ADDR buffer, 64
invoke RockeyAS, RY_READ
    .if (ax ==0)
    	invoke MessageBox,NULL,addr buffer,addr szSuccess,MB_OK
    .else
    	invoke MessageBox,NULL,addr szFail4,addr szFail,MB_OK
    	invoke ExitProcess,1
.ENDIF


;random
invoke RockeyAS, RY_RANDOM
    .if (ax ==0)
        invoke wsprintf,addr tmpbuffer1,addr szFmt2,addr szSuccess5 
        invoke wsprintf,addr tmpbuffer,addr szFmt1,addr p1
        invoke lstrcat,addr tmpbuffer1,addr tmpbuffer
    	invoke MessageBox,NULL,addr tmpbuffer1,addr szSuccess,MB_OK
    .else
    	invoke MessageBox,NULL,addr szFail5,addr szFail,MB_OK
    	invoke ExitProcess,1
.ENDIF


;Seed code
 mov lp2, 12345678h
 invoke RockeyAS, RY_RANDOM
    .if (ax ==0)
        invoke wsprintf,addr tmpbuffer1,addr szFmt2,addr szSuccess6 
        invoke wsprintf,addr tmpbuffer,addr szFmt3,addr p1,addr p2,addr p3,addr p4
        invoke lstrcat,addr tmpbuffer1,addr tmpbuffer
    	invoke MessageBox,NULL,addr tmpbuffer1,addr szSuccess,MB_OK
    .else
    	invoke MessageBox,NULL,addr szFail6,addr szFail,MB_OK
    	invoke ExitProcess,1
.ENDIF


;Write USER ID
mov lp1, 088888888h
invoke RockeyAS, RY_WRITE_USERID
.if (ax ==0)
        invoke wsprintf,addr tmpbuffer1,addr szFmt2,addr szSuccess7 
        invoke wsprintf,addr tmpbuffer,addr szFmt1,addr lp1
        invoke lstrcat,addr tmpbuffer1,addr tmpbuffer
    	invoke MessageBox,NULL,addr tmpbuffer1,addr szSuccess,MB_OK
    .else
    	invoke MessageBox,NULL,addr szFail7,addr szFail,MB_OK
    	invoke ExitProcess,1
.ENDIF


;Read USER ID
xor eax, eax
mov lp1, eax
invoke RockeyAS, RY_READ_USERID
.if (ax ==0)
        invoke wsprintf,addr tmpbuffer1,addr szFmt2,addr szSuccess8 
        invoke wsprintf,addr tmpbuffer,addr szFmt1,addr lp1
        invoke lstrcat,addr tmpbuffer1,addr tmpbuffer
    	invoke MessageBox,NULL,addr tmpbuffer1,addr szSuccess,MB_OK
    .else
    	invoke MessageBox,NULL,addr szFail8,addr szFail,MB_OK
    	invoke ExitProcess,1
.ENDIF


;Set module
mov p1, 7
mov p2, 2121h
mov p3, 0
invoke RockeyAS, RY_SET_MOUDLE
.IF (ax == 0)
        invoke wsprintf,addr tmpbuffer1,addr szFmt2,addr sz1
        invoke wsprintf,addr tmpbuffer,addr szFmt1,addr p2
        invoke lstrcat,addr tmpbuffer1,addr tmpbuffer
    	invoke MessageBox,NULL,addr tmpbuffer1,addr szSuccess,MB_OK
    .else
    	invoke MessageBox,NULL,addr szFail9,addr szFail,MB_OK
    	invoke ExitProcess,1
.ENDIF


;Check module
mov p1, 7
invoke RockeyAS, RY_CHECK_MOUDLE
.IF(ax==0)
        invoke wsprintf,addr tmpbuffer1,addr szFmt2,addr sz2
        invoke wsprintf,addr tmpbuffer,addr szFmt4,addr p2,addr p3
        invoke lstrcat,addr tmpbuffer1,addr tmpbuffer
    	invoke MessageBox,NULL,addr tmpbuffer1,addr szSuccess,MB_OK
    .else
    	invoke MessageBox,NULL,addr szFail10,addr szFail,MB_OK
    	invoke ExitProcess,1
.ENDIF


;Write arithmetic
mov p1, 0
invoke lstrcpy, ADDR buffer, ADDR cmd
invoke RockeyAS, RY_WRITE_ARITHMETIC
.IF(ax==0)
    	invoke MessageBox,NULL,addr szSuccess11,addr szSuccess,MB_OK
    .else
    	invoke MessageBox,NULL,addr szFail11,addr szFail,MB_OK
    	invoke ExitProcess,1
.ENDIF



;;To calculate arithmetic
mov lp1, 0
mov lp2, 7
mov p1, 5
mov p2, 3
mov p3, 1
mov p4, 0ffffh
invoke RockeyAS, RY_CALCULATE1
.IF(ax==0)
        invoke wsprintf,addr tmpbuffer1,addr szFmt2,addr szSuccess12
        invoke wsprintf,addr tmpbuffer,addr szFmt3,addr byte ptr p1,addr byte ptr p2,addr byte ptr p3,addr byte ptr p4
        invoke lstrcat,addr tmpbuffer1,addr tmpbuffer
    	invoke MessageBox,NULL,addr tmpbuffer1,addr szSuccess,MB_OK
    .else
    	invoke MessageBox,NULL,addr szFail12,addr szFail,MB_OK
    	invoke ExitProcess,1
.ENDIF


;Operation completed and closed
invoke RockeyAS, RY_CLOSE
invoke MessageBox,NULL,addr szSuccess13,addr szSuccess,MB_OK      
invoke ExitProcess,1



;Packing Rockey fuction
RockeyAS proc stdcall USES ebx,rcode:DWORD

push offset buffer
push offset p4
push offset p3
push offset p2
push offset p1
push offset lp2
push offset lp1
push offset handle
mov ebx,rcode
push ebx
call Rockey

ret

RockeyAS endp


end	start

