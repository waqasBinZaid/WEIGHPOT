!
!   Rockey IV Fortran PowerStation 4.0 Sample
!
!MS$FREEFORM

INTERFACE
INTEGER(2) FUNCTION Rockey (fcode, handle, lp1, lp2, p1, p2, p3, p4, buffer)

!MS$ATTRIBUTES C, ALIAS : '_Rockey' :: Rockey
INTEGER(2) fcode
INTEGER(4) handle
INTEGER(4) lp1, lp2
INTEGER(4) p1, p2, p3, p4
INTEGER(4) buffer
END FUNCTION Rockey
END INTERFACE

! program testrockey

parameter (RY_FIND				= 1)	
parameter (RY_FIND_NEXT			= 2)	
parameter (RY_OPEN				= 3)	
parameter (RY_CLOSE				= 4)	
parameter (RY_READ				= 5)	
parameter (RY_WRITE				= 6)	
parameter (RY_RANDOM			= 7)	
parameter (RY_SEED				= 8)	
parameter (RY_WRITE_USERID		= 9)	
parameter (RY_READ_USERID		= 10)	
parameter (RY_SET_MOUDLE		= 11)	
parameter (RY_CHECK_MOUDLE		= 12)	
parameter (RY_WRITE_ARITHMETIC	= 13)	
parameter (RY_CALCULATE1		= 14)	
parameter (RY_CALCULATE2		= 15)	
parameter (RY_CALCULATE3		= 16)	
parameter (RY_DECREASE			= 17)	


parameter (ERR_SUCCESS					= 0)	
parameter (ERR_NO_PARALLEL_PORT			= 1)		
parameter (ERR_NO_DRIVER				= 2)	
parameter (ERR_NO_ROCKEY				= 3)	
parameter (ERR_INVALID_PASSWORD			= 4)	
parameter (ERR_INVALID_PASSWORD_OR_ID	= 5)	
parameter (ERR_SETID					= 6)	
parameter (ERR_INVALID_ADDR_OR_SIZE		= 7)
parameter (ERR_UNKNOWN_COMMAND			= 8)	
parameter (ERR_NOTBELEVEL3				= 9)
parameter (ERR_READ						= 10)		
parameter (ERR_WRITE					= 11)		
parameter (ERR_RANDOM					= 12)		
parameter (ERR_SEED						= 13)		
parameter (ERR_CALCULATE				= 14)	
parameter (ERR_NO_OPEN					= 15)	
parameter (ERR_OPEN_OVERFLOW			= 16)		
parameter (ERR_NOMORE					= 17)		
parameter (ERR_NEED_FIND				= 18)	
parameter (ERR_DECREASE					= 19)	
parameter (ERR_AR_BADCOMMAND			= 20)	
parameter (ERR_AR_UNKNOWN_OPCODE		= 21)	
parameter (ERR_AR_WRONGBEGIN			= 22)		
parameter (ERR_AR_WRONG_END				= 23)		
parameter (ERR_AR_VALUEOVERFLOW			= 24)	
parameter (ERR_UNKNOWN					= 16#ffff)	

parameter  (ERR_RECEIVE_NULL			= 16#100)	
parameter  (ERR_PRNPORT_BUSY			= 16#101)


INTEGER(2)		handle(16)
INTEGER(2)		p1, p2, p3, p4, retcode
INTEGER(4)		lp1, lp2
INTEGER(2)		rc(4)
INTEGER(2)		i, j
CHARACTER(256)  buf


p1 = 16#c44c
p2 = 16#c8f8
p3 = 16#0799
p4 = 16#c43b

retcode = Rockey(RY_FIND, LOC(handle(1)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
if (retcode .NE. 0) then
	write (*, '(A, I4)') ' Find Error Code: ', retcode
	stop
endif

write(*, '(A, Z8.8)') ' Find Rockey: ', lp1


retcode = Rockey(RY_OPEN, LOC(handle(1)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
if (retcode .NE. 0) then
	write (*, '(A, I4)') ' Open Error Code: ', retcode
	stop
endif
     	
i = 1
!DO WHILE (retcode .EQ. 0)
    !exit
!	retcode = Rockey(RY_FIND_NEXT, LOC(handle(i)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
!	if (retcode .EQ. ERR_NOMORE) then
!		exit
!	endif
!	write(*, '(A, Z8.8)') ' Find Rockey: ', lp1
!END DO

write(*, *) ' count :'	, i

    j=1
   
	p1=1
	p2=256
	p3=1
	p4=0
	buf = 'w'C
	
    write(*, *) 'Write: w' , j
	
	retcode = Rockey(RY_WRITE, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
      if (retcode .NE. 0) then
		write (*, '(A, I4)') 'Write Error Code: ', retcode
		stop
	endif

	write(*, *) 'Write: w'

	p1 = 1
	p2 = 256
	!buf =char(255)
 
	retcode = Rockey(RY_READ, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif
     
	write(*, '(A, A10)') ' Read: ', buf

	retcode = Rockey(RY_RANDOM, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif

	write(*, '(A, Z4.4)') ' Random: ', p1
		
	lp2 = 16#12345678
	retcode = Rockey(RY_SEED, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif

	write(*, '(A, Z4.4, 1X, Z4.4, 1X, Z4.4, 1X, Z4.4)') ' Seed: ', p1, p2, p3, p4
	rc(0) = p1
	rc(1) = p2
	rc(2) = p3
	rc(3) = p4

	lp1 = 16#88888888

	retcode = Rockey(RY_WRITE_USERID, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif

	write(*, '(A, Z8.8)') ' Write User ID: ', lp1

	lp1 = 0
	retcode = Rockey(RY_READ_USERID, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif

	write(*, '(A, Z8.8)') ' Read User ID: ', lp1

	p1 = 7
	p2 = 16#2121
	p3 = 0
	retcode = Rockey(RY_SET_MOUDLE, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif

	write(*, '(A, Z4.4, A)') ' Set Moudle 7: Pass = ', p2, ' Decrease no Allow'

	p1 = 7
	retcode = Rockey(RY_CHECK_MOUDLE, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif

	write(*, '(A\)') ' Check Module 7: '
	if (p2 .NE. 0) then
		write(*, '(A\)') ' Allow  '
	else
		write(*, '(A\)') ' No Allow  '
	endif
	if (p3 .NE. 0) then
		write(*, '(A)') 'Allow Decrease'
	else				  
		write(*, '(A)') 'Not Allow Decrease'
	endif

	p1 = 0
	buf = 'H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D'C
	retcode = Rockey(RY_WRITE_ARITHMETIC, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif
	write(*, *) 'Write Arithmetic 1'

	lp1 = 0
	lp2 = 7
	p1 = 5
	p2 = 3
	p3 = 1
	p4 = 16#ffff
	retcode = Rockey(RY_CALCULATE1, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif
	write(*, *) 'Calculate In Input: p1=5, p2=3, p3=1, p4=ffff'
	write(*, *) 'Result = ((5*23 + 3*17 + 16#2121) < 1) ^ 16#ffff = 16#BC71'
	write(*, '(A, Z4.4, A, Z4.4, A, Z4.4, A, Z4.4)') 'Calculate Output: p1=', p1, ', p2=', p2, ', p3=', p3, ', p4=', p4

	p1 = 10
	buf = 'A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H'C
	retcode = Rockey(RY_WRITE_ARITHMETIC, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif
	write(*, *) 'Write Arithmetic 2'

	lp1 = 10
	lp2 = 16#12345678
	p1 = 1
	p2 = 2
	p3 = 3
	p4 = 4
	retcode = Rockey(RY_CALCULATE2, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif
	write(*, *) 'Calculate In Input: p1=1, p2=2, p3=3, p4=4'
	write(*, '(A, Z4.4, A, Z4.4, A, Z4.4, A, Z4.4, A, Z4.4)') 'Result = ', rc(0), ' + ', rc(1), ' + ', rc(2), ' + ', rc(3), ' + 1 + 2 + 3 + 4 = ', rc(0) + rc(1) + rc(2) + rc(3) + 10
	write(*, '(A, Z4.4, A, Z4.4, A, Z4.4, A, Z4.4)') 'Calculate Output: p1=', p1, ', p2=', p2, ', p3=', p3, ', p4=', p4

	p1 = 9
	p2 = 5
	p3 = 1
	retcode = Rockey(RY_SET_MOUDLE, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif

	p1 = 17
	buf = 'A=E|E, B=F|F, C=G|G, D=H|H'C
	retcode = Rockey(RY_WRITE_ARITHMETIC, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif
	write(*, *) 'Write Arithmetic 3'

	lp1 = 17
	lp2 = 6
	p1 = 1
	p2 = 2
	p3 = 3
	p4 = 4
	retcode = Rockey(RY_CALCULATE3, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif
	write(*, '(A, Z4.4, A, Z4.4, A, Z4.4, A, Z4.4)') 'Show Module from 6: p1=', p1, ', p2=', p2, ', p3=', p3, ', p4=', p4
	
	p1 = 9
	retcode = Rockey(RY_DECREASE, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif

	write(*, *) 'Decrease module 9'

	lp1 = 17
	lp2 = 6
	p1 = 1
	p2 = 2
	p3 = 3
	p4 = 4
	retcode = Rockey(RY_CALCULATE3, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif
	write(*, '(A, Z4.4, A, Z4.4, A, Z4.4, A, Z4.4)') 'Show Module from 6: p1=', p1, ', p2=', p2, ', p3=', p3, ', p4=', p4

	retcode = Rockey(RY_CLOSE, LOC(handle(j)), LOC(lp1), LOC(lp2), LOC(p1), LOC(p2), LOC(p3), LOC(p4), LOC(buf))
	if (retcode .NE. 0) then
		write (*, '(A, I4)') ' Error Code: ', retcode
		stop
	endif


end
