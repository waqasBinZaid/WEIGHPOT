*:
*: Visual FoxPro Demonstration program for :
*:
*:        ROCKEY-IV
*:
*: Implemented for Visual FoxPro under Win32.
*:
*:

  clear
  
*: Declare the ROCKEY function located in the 32 bit DLL "Rockey4ND.dll" Rockey4ND_FoxPro
 
 declare short Rockey in Rockey4ND.dll integer service, integer @ handle, long @ lp1, long @ lp2, integer @ p1, integer @ p2, integer @ p3, integer @ p4, string @ buffer


*: Declare and clear all variables
*:// Advance command word
store 0xC44C to p1 
store 0xC8F8 to	p2 
store 0x0799 to	p3 
store 0xC43B to	p4 
store 0 to lp1
store 0 to lp2
store 0 to handle
store 0 to  retcode

store  1     to  RY_FIND             
store  2     to  RY_FIND_NEXT		
store  3     to  RY_OPEN             
store  4     to  RY_CLOSE            
store  5     to  RY_READ             
store  6     to  RY_WRITE            
store  7     to  RY_RANDOM           
store  8     to  RY_SEED             
store  9     to  RY_WRITE_USERID	
store  10     to  RY_READ_USERID	
store  11    to  RY_SET_MOUDLE		
store  12     to  RY_CHECK_MOUDLE	
store  13    to  RY_WRITE_ARITHMETIC 
store  14     to  RY_CALCULATE1		
store  15    to  RY_CALCULATE2		
store  16     to  RY_CALCULATE3		
store  17     to  RY_DECREASE		

*: Error code
store   0    to  ERR_SUCCESS		
store   1    to  ERR_NO_PARALLEL_PORT
store   2    to  ERR_NO_DRIVER				
store   3    to  ERR_NO_ROCKEY				
store   4    to  ERR_INVALID_PASSWORD	
store   5    to  ERR_INVALID_PASSWORD_OR_ID 
store   6    to  ERR_SETID			       
store   7    to  ERR_INVALID_ADDR_OR_SIZE	
store   8    to  ERR_UNKNOWN_COMMAND    
store   9    to  ERR_NOTBELEVEL3		
store   10    to  ERR_READ				
store   11    to  ERR_WRITE             
store   12    to  ERR_RANDOM            
store   13    to  ERR_SEED              
store   14    to  ERR_CALCULATE         
store   15    to  ERR_NO_OPEN			
store   16    to  ERR_OPEN_OVERFLOW     
store   17    to  ERR_NOMORE			
store   18    to  ERR_NEED_FIND			
store   19    to  ERR_DECREASE			
store   20    to  ERR_AR_BADCOMMAND		
store   21    to  ERR_AR_UNKNOWN_OPCODE	
store   22    to  ERR_AR_WRONGBEGIN		
store   23    to  ERR_AR_WRONG_END		
store   256    to  ERR_RECEIVE_NULL		
store   257    to  ERR_PRNPORT_BUSY		
*:
buffer = space(1024)

*//store "hello" to buffer

	retcode = rockey(RY_FIND, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4, @ buffer)
	if( retcode<>0)
		?"can't find ROCKEY!! error code=",retcode
	else
	 ?"find a ROCKEY"
	endif
	
retcode = rockey(RY_OPEN, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4,@ buffer)
	if (retcode<>0)
       ?"Can not open !",retcode
	else
		?"open ROCKEY succesed!!"
	endif

	p1 = 3
	p2 = 5
	buffer= "Hello"
	retcode = rockey(RY_WRITE, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4,@ buffer)
	if (retcode<>0)
		?"Can't write !",retcode
	else
		?"write hello succesed!!"
	endif

	p1 = 3
	p2 = 5
	buffer="                   "
	retcode = rockey(RY_READ, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4,@ buffer)
	if (retcode<>0)
	?"Can't read !",retcode
	else
		?"read succesed!!:",buffer
	endif
	retcode = rockey(RY_RANDOM, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4,@ buffer)
	if (retcode<>0)
		?"Can't random !",retcode
	else
		?"Random succesed!!:",p1
	endif
	lp2 = 12345678
	retcode = rockey(RY_SEED, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4,@ buffer)
	if (retcode<>0)
		?"Can't Seed !",retcode
	else
		?"seed succesed!!:",p1,p2,p3,p4
	endif
	rc0 = p1
	rc1 = p2
	rc2 = p3
	rc3 = p4
store  0xc44c to	p1 
store 0xc8f8 to	p2 
store 0x0799 to	p3 
store 0xc43b to	p4 

	lp1 =88888888
	retcode = rockey(RY_WRITE_USERID, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4,@ buffer)
	if (retcode<>0)
	if(retcode>100)
	?"write userid succesed!!:",lp1
	else
		?"Can't write userid !",retcode
	endif
	else
		?"write userid succesed!!:",lp1
	endif
	
	lp1 = 0
		retcode = rockey(RY_READ_USERID,@handle, @lp1, @lp2, @p1, @p2, @p3, @p4,@ buffer)
	if (retcode<>0)
	if(retcode>100)
	?"read userid succesed!!:",lp1
	else
		?"Can't read userid !",retcode
		endif
	else
		?"read userid succesed!!:",lp1
	endif
	
	p1 = 7
	p2 = 0x2121
	p3 = 0
	retcode = rockey(RY_SET_MOUDLE, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4,@ buffer)
	if (retcode<>0)
		?"Can't set module 7 !",retcode
	else
		?"Set Moudle 7: Pass = " , p2,"Decrease no allow"
	endif

	p1 = 7
	retcode = rockey(RY_CHECK_MOUDLE, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4,@ buffer)
	if (retcode<>0)
		?"Can't check module 7 !",retcode
	else
		?"Check Moudle 7: " 
		if (p2<>0) 
			?"Allow   "
		else 
			?"No Allow   "
		endif
		if (p3<>0) 
			?"Allow Decrease"
		else 
			?"Not Allow Decrease"
		endif
	endif

	p1 = 0
	buffer="H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D"
	retcode = rockey(RY_WRITE_ARITHMETIC, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4,@ buffer)
	if (retcode<>0)
		?"can't write arithmetic!!",retcode
	else
		?"write arthmetic1!!"
	endif


	lp1 = 0
	lp2 = 7
	p1 = 5
	p2 = 3
	p3 = 1
	p4 = 0xffff
	retcode = rockey(RY_CALCULATE1,  @handle, @lp1, @lp2, @p1, @p2, @p3, @p4,@ buffer)
	if (retcode<>0)
		?"can't calculate1",retcode
	else
		?"Calculate Input: p1=5, p2=3, p3=1, p4=65535"
		?"Result = (5*23 + 3*17 + 0x2121) < 1) ^ 65535 = 48241\n"
		?"Calculate Output: p1=",p1,"p2=",p2," p3=",p3," p4=",p4	
	endif

	p1 = 10 
	buffer="A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H"
	retcode = rockey(RY_WRITE_ARITHMETIC, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4,@ buffer)
	if (retcode<>0)
		?"can't Write Arithmetic 2",retcode
	else
		?"Write Arithmetic 2 successed!!"
	endif

	lp1 = 10 
	lp2 = 0x12345678 
	p1 = 1 
	p2 = 2 
	p3 = 3 
	p4 = 4 
	retcode = rockey(RY_CALCULATE2, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4, @buffer) 
	if (retcode<>0)
		?"can't calculate1",retcode
	else
		?"Calculate Input: p1=1, p2=2, p3=3, p4=4"
		?"Result = ",rc0,"+",rc1,"+",rc2,"+",rc3,"+ 1 + 2 + 3 + 4 =",rc0+rc1+rc2+rc3+10
		?"Calculate Output: p1=",p1,"p2=",p2," p3=",p3," p4=",p4	
	endif

*: Set Decrease
	p1 = 9 
	p2 = 0x5 
	p3 = 1 
	retcode = rockey(RY_SET_MOUDLE, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4, @buffer) 
	if (retcode<>0)
		?"can't set module",retcode
	else
		?"set module successed!"
	endif

	p1 = 17 
	buffer="A=E|E, B=F|F, C=G|G, D=H|H"
	retcode = rockey(RY_WRITE_ARITHMETIC, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4, @buffer) 
	if (retcode<>0)
		?"can't Write Arithmetic 3",retcode
	else
		?"Write Arithmetic 3\successed!"
	endif

	lp1 = 17 
	lp2 = 6 
	p1 = 1 
	p2 = 2 
	p3 = 3 
	p4 = 4 
	retcode = rockey(RY_CALCULATE3, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4, @buffer) 
	if (retcode<>0)
		?"calculate 3 error!:",retcode
	else
		?"Show Module from 6: p1=",p1," p2=",p2," p3=",p3," p4=", p4
	endif

*:/ Decrease
	p1 = 9 
	retcode = rockey(RY_DECREASE, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4, @buffer) 
	if (retcode<>0)
		?"Decrease module 9 error!:",retcode
	else
		?"Decrease module 9 successed!"
	endif

	lp1 = 17 
	lp2 = 6 
	p1 = 1 
	p2 = 2 
	p3 = 3 
	p4 = 4 
	retcode = rockey(RY_CALCULATE3, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4, @buffer) 
	if (retcode<>0)
		?"calculate3 error!:",retcode
	else	?
		?"Show Module from 6: p1=",p1," p2=",p2," p3=",p3," p4=", p4
	endif

	retcode = rockey(RY_CLOSE, @handle, @lp1, @lp2, @p1, @p2, @p3, @p4, @buffer) 
		if (retcode<>0)
			?"close ROCKEY error:",retcode
			else
			?"Close Rockey4 ND"
		endif	
	
 clear dlls
*inkey(1000)
return
