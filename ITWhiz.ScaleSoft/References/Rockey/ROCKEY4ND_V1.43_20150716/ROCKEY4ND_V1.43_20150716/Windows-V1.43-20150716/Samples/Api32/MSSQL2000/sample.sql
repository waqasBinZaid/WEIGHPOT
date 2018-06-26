--FUNCTION int xp_Rockey4ND(int func, ref int handle, ref Ulong  lp1, ref Ulong lp2, ref Uint p1 ,ref Uint p2, ref Uint p3,ref Uint  p4, ref string buffer) LIBRARY "xp_Rockey4ND.dll"
declare @RY_FIND 		smallint
declare @RY_OPEN 		smallint
declare @RY_CLOSE 		smallint
declare @RY_READ 		smallint
declare @RY_WRITE 		smallint
declare @RY_SEED 		smallint  
declare @RY_CHECK_MOUDLE 	smallint
set @RY_FIND		=1
set @RY_OPEN		=3
set @RY_CLOSE		=4
set @RY_READ		=5
set @RY_WRITE		=6
set @RY_SEED 		=8  
set @RY_CHECK_MOUDLE 	=12

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

/*Close Rockey*/
select @func=@RY_CLOSE
exec @retcode=master..xp_Rockey4ND @func,@handle output,@lp1 output,@lp2 output,@p1 output,@p2 output,@p3 output,@p4 output,@buffer output
if @retcode>0 /*Close Rockey error*/
	begin 
		print 'Close Rockey Error: '+cast(@retcode as char)
		return
	end
print 'Close Rockey successfully!'
