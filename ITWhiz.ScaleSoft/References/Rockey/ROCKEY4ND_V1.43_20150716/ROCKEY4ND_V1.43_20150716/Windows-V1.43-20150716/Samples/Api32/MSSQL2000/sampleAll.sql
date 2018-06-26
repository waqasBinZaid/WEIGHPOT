--FUNCTION int xp_Rockey4ND(int func, ref int handle, ref Ulong  lp1, ref Ulong lp2, ref Uint p1 ,ref Uint p2, ref Uint p3,ref Uint  p4, ref string buffer) LIBRARY "xp_Rockey4ND.dll"
declare @RY_FIND 		smallint
declare @RY_FIND_NEXT 		smallint
declare @RY_OPEN 		smallint
declare @RY_CLOSE 		smallint
declare @RY_READ 		smallint
declare @RY_WRITE 		smallint
declare @RY_RANDOM		smallint
declare @RY_SEED 		smallint  
declare @RY_WRITE_USERID 	smallint
declare @RY_READ_USERID		smallint
declare @RY_SET_MOUDLE		smallint
declare @RY_CHECK_MOUDLE 	smallint
declare @RY_WRITE_ARITHMETIC 	smallint
declare @RY_CALCULATE1		smallint
declare @RY_CALCULATE2		smallint
declare @RY_CALCULATE3		smallint
declare @RY_DECREASE 		smallint
set @RY_FIND		=1
set @RY_FIND_NEXT	=2
set @RY_OPEN		=3
set @RY_CLOSE		=4
set @RY_READ		=5
set @RY_WRITE		=6
set @RY_RANDOM		=7
set @RY_SEED 		=8  
set @RY_WRITE_USERID 	=9
set @RY_READ_USERID	=10
set @RY_SET_MOUDLE	=11
set @RY_CHECK_MOUDLE 	=12
set @RY_WRITE_ARITHMETIC=13
set @RY_CALCULATE1	=14
set @RY_CALCULATE2	=15
set @RY_CALCULATE3	=16
set @RY_DECREASE 	=17

declare @func smallint
declare @handle smallint
declare @lp1 int
declare @lp2 int
declare @p1 smallint
declare @p2 smallint
declare @p3 smallint
declare @p4 smallint
declare @buffer varchar(1024)
declare @retcode smallint

/*Find Rockey*/
select @func=@RY_FIND
select @p1=0xc44c	
select @p2=0xc8f8
select @p3=0x0799	
select @p4=0xc43b
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Find error*/
	begin 
		/*RAISERROR('Find Error',1,1)*/
		print 'Find Error: '+cast(@retcode as char)
		return
	end
print 'Find Rockey: '+cast(@lp1 as char)

/*Open Rockey*/
select @func=@RY_OPEN
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Open error*/
	begin 
		print 'Open Error: '+cast(@retcode as char)
		return
	end
print 'Open Rockey successfully!'

/*Write Rockey*/
select @func=@RY_WRITE
select @buffer='Hello world!'
select @p1=10
select @p2=12
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Write error*/
	begin 
		print 'Write Error: '+cast(@retcode as char)
		return
	end
print 'Write data: '+@buffer

/*Read Rockey*/
select @func=@RY_READ
select @buffer=''
select @p1=10
select @p2=12
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Read error*/
	begin 
		print 'Read Error: '+cast(@retcode as char)
		return
	end
print 'Read Data: '+Left(@buffer,12)

/*Random*/
select @func=@RY_RANDOM
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Random error*/
	begin 
		print 'Random Error: '+cast(@retcode as char)
		return
	end
print 'Get Random: '+cast(@p1 as char)

/*Seed*/
select @func=@RY_SEED
select @lp2=0x12345678
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Seed error*/
	begin 
		print 'Seed Error: '+cast(@retcode as char)
		return
	end
print 'Get Seed: '+cast(@p1 as char)+cast(@p2 as char)+cast(@p3 as char)+cast(@p4 as char)

/*Write UID*/
select @func=@RY_WRITE_USERID
select @lp1=0x88888888
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Write UID error*/
	begin 
		print 'Write UID Error: '+cast(@retcode as char)
		return
	end
print 'Write UID: '+cast(@lp1 as char)

/*Read UID*/
select @func=@RY_READ_USERID

exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Read UID error*/
	begin 
		print 'Read UID Error: '+cast(@retcode as char)
		return
	end
print 'Read UID: '+cast(@lp1 as char)

/*Set Module*/
select @func=@RY_SET_MOUDLE
select @p1=7
select @p2=1
select @p3=1
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Set Module error*/
	begin 
		print 'Set Module Error: '+cast(@retcode as char)
		return
	end
print 'Set Module 7: '+cast(@p2 as char)+' Decreasement allowed!'

/*Check Module*/
select @func=@RY_CHECK_MOUDLE
select @p1=7
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Check Module error*/
	begin 
		print 'Check Module Error: '+cast(@retcode as char)
		return
	end
if @p2>0 
   begin 
      print 'Check Module 7: valid'
	if @p3>0
	   begin 
	      print 'Decreasement allowed!'
	   end
	else
	   begin
	      print 'Decreasement not allowed!'
	   end
   end 
else
   begin
      print 'Check Module 7: invalid'
   end 


/*Decrease Module*/
select @func=@RY_DECREASE
select @p1=7
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Set Module error*/
	begin 
		print 'Decrease Module Error: '+cast(@retcode as char)
		return
	end
print 'Decrease Module 7 successfully!'

/*Check Module*/
select @func=@RY_CHECK_MOUDLE
select @p1=7
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Check Module error*/
	begin 
		print 'Check Module Error: '+cast(@retcode as char)
		return
	end
if @p2>0 
   begin 
      print 'Check Module 7: valid'
	if @p3>0
	   begin 
	      print 'Decreasement allowed!'
	   end
	else
	   begin
	      print 'Decreasement not allowed!'
	   end
   end 
else
   begin
      print 'Check Module 7: invalid'
   end 

/*Write Arithmetic*/
select @func=@RY_WRITE_ARITHMETIC
select @p1=0
select @buffer='H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D'
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Write Arithmetic error*/
	begin 
		print 'Write Arithmetic Error: '+cast(@retcode as char)
		return
	end

print 'Write Arithmetic successfully!'

/*Calculate1*/

select @func=@RY_SET_MOUDLE
select @p1=7
select @p2=10
select @p3=0
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Set Module error*/
	begin 
		print 'Set Module Error: '+cast(@retcode as char)
		return
	end
print 'Set Module 7: '+cast(@p2 as char)+' Decreasement allowed!'

select @func=@RY_CALCULATE1
select @lp1=0
select @lp2=7
select @p1=5
select @p2=3
select @p3=1
select @p4=0xffff
print 'Calculate1 Input: p1=5, p2=3, p3=1, p4=0xffff'
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Calculate1 error*/
	begin 
		print 'Calculate1 Error: '+cast(@retcode as char)
		return
	end
print 'Result: '+cast(@p1 as char)+cast(@p2 as char)+cast(@p3 as char)+cast(@p4 as char)

/*Calculate2*/
select @func=@RY_CALCULATE2
select @lp1=0
select @lp2=0x12345678
select @p1=5
select @p2=3
select @p3=1
select @p4=0xffff
print 'Calculate2 Input: p1=5, p2=3, p3=1, p4=0xffff'
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /* Calculate2 error*/
	begin 
		print 'Calculate2 Error: '+cast(@retcode as char)
		return
	end
print 'Result: '+cast(@p1 as char)+cast(@p2 as char)+cast(@p3 as char)+cast(@p4 as char)

/*Calculate3*/
select @func=@RY_CALCULATE3
select @lp1=0
select @lp2=7
select @p1=5
select @p2=3
select @p3=1
select @p4=0xffff
print 'Calculate3 Input: p1=5, p2=3, p3=1, p4=0xffff'
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /* Calculate3 error*/
	begin 
		print 'Calculate3 Error: '+cast(@retcode as char)
		return
	end
print 'Result: '+cast(@p1 as char)+cast(@p2 as char)+cast(@p3 as char)+cast(@p4 as char)


/*Close Rockey*/
select @func=@RY_CLOSE
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Close Rockey error*/
	begin 
		print 'Close Rockey Error: '+cast(@retcode as char)
		return
	end
print 'Close Rockey successfully!'
