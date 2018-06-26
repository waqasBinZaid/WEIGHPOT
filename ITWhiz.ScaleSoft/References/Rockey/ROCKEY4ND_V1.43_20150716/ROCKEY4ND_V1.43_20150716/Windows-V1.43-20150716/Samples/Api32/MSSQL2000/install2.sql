Declare @RPath varchar(255)
 select @RPath='d:\data'
 select @RPath='master..sp_addextendedproc '+'''xp_Rockey4ND'''+','''+@RPath+'\xp_rockey4ND.dll'''
 if exists (select name from master..sysobjects where upper(name)=upper('xp_Rockey4ND') and xtype='X')
     EXEC master..sp_dropextendedproc 'xp_Rockey4ND'
 exec ( @RPath)
