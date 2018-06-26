<%@ Language=VBScript %>
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
	</HEAD>
	<body>
		<%
Const RY_FIND = 1
Const RY_OPEN = 3
Const RY_READ = 5
Const RY_WRITE = 6
Const RY_RANDOM = 7
Const RY_SEED = 8
Const RY_WRITE_USERID = 9
Const RY_READ_USERID = 10
Const RY_SET_MOUDLE = 11
Const RY_CHECK_MOUDLE = 12
Const RY_WRITE_ARITHMETIC = 13
Const RY_CALCULATE1	= 14
Const RY_CLOSE = 4
Const pp1 = 50252
Const pp2 = 51448
Const pp3 = 1945
Const pp4 = 50235

Dim retcode
Dim str
Dim Rockey4ND
Dim random

Set Rockey4ND=Server.CreateObject("Com.CRockey4ND")

Rockey4ND.p1=pp1
Rockey4ND.p2=pp2
Rockey4ND.p3=pp3
Rockey4ND.p4=pp4

'Find Rockey
retcode=Rockey4ND.RockeyCM(RY_FIND)

 If Not (retcode = 0) Then
    response.write "Find Rockey failed:" & retcode & "<br/>"
    else
    response.write "Find Rockey successed" & "<br/>"
    End If
    
'Open Rockey
retcode=Rockey4ND.RockeyCM(RY_OPEN)

 If Not (retcode = 0) Then
    response.write "Open rokcey failed:" & retcode &"<br/>"
    else
    response.write "Open Rockey successed" & "<br/>"
    End If
    
'Write Rockey
Rockey4ND.p1=3
Rockey4ND.p2=5
str="Hello"
Rockey4ND.buffer=str

retcode=Rockey4ND.RockeyCM(RY_WRITE)
 If Not (retcode = 0) Then
    response.write "Write Rockey failed:" & retcode &"<br/>"
    else
    response.write "Write Rockey successed" & "<br/>"
    End If
    
'Read Rockey
Rockey4ND.p1=3
Rockey4ND.p2=5

retcode=Rockey4ND.RockeyCM(RY_READ)
str=Rockey4ND.buffer
 If Not (retcode = 0) Then
    response.write "Read Rockey failed:" & retcode &"<br/>"
    else
    response.write "Read Rockey successed:" & str &"<br/>"
    End If
    
'Generate random
retcode=Rockey4ND.RockeyCM(RY_RANDOM)
random=Rockey4ND.p1
 If Not (retcode = 0) Then
    response.write "Generate random failed:" & retcode &"<br/>"
    else
    response.write "Generate random failed:" & random &"<br/>"
    End If
    
'Generate seed code
Rockey4ND.lp2=12345678
retcode=Rockey4ND.RockeyCM(RY_SEED)
 If Not (retcode = 0) Then
    response.write "Generate seed code failed:" & retcode &"<br/>"
    else
    response.write "Generate seed code successed:" & Rockey4ND.p1 & "-" & Rockey4ND.p2 & "-" & Rockey4ND.p3 & "-" & Rockey4ND.p4 &"<br/>"
    End If
    
'Write UserID
Rockey4ND.lp1=88888888
retcode=Rockey4ND.RockeyCM(RY_WRITE_USERID)
 If Not (retcode = 0) Then
    response.write "Write UserID failed:" & retcode &"<br/>"
    else
    response.write "Write UserID successed" &"<br/>"
    End If
    
'Read UserID
  Rockey4ND.lp1=0
  retcode=Rockey4ND.RockeyCM(RY_READ_USERID)
  If Not (retcode = 0) Then
    response.write "Read UserID failed:" & retcode &"<br/>"
    else
    response.write "Read UserID successed:" & Rockey4ND.lp1 & "<br/>"
    End If  
    
'Set module
  Rockey4ND.p1=7
  Rockey4ND.p2=8481
  Rockey4ND.p3=0
  retcode=Rockey4ND.RockeyCM(RY_SET_MOUDLE)
  If Not (retcode = 0) Then
  response.write "Set module failed:" & retcode &"<br/>"
  else
  response.write "Set module successed:SET MODULE 7 0x2121" & "<br/>"
  End If  
 
    
'Check module
  Rockey4ND.p1=7
  retcode=Rockey4ND.RockeyCM(RY_CHECK_MOUDLE)
  If Not (retcode = 0) Then
  response.write "Check module failed:" & retcode &"<br/>"
  else
  If (Rockey4ND.p2>0) then
  response.write "Check module successed,P2 is Allow" & "<br/>"
  End If
  End If
  

'Write arithmetic
Rockey4ND.p1=0
str = "A=B+C"
Rockey4ND.buffer=str
retcode=Rockey4ND.RockeyCM(RY_WRITE_ARITHMETIC)
 If Not (retcode = 0) Then
    response.write "Write arithmetic failed:" & retcode &"<br/>"
    else
    response.write "Write arithmatic successed:A=B+C" &"<br/>"
    End If
 
'Calculate
Rockey4ND.lp1=0
Rockey4ND.lp2=0
Rockey4ND.p1=1
Rockey4ND.p2=2
Rockey4ND.p3=3
retcode=Rockey4ND.RockeyCM(RY_CALCULATE1)
 If Not (retcode = 0) Then
    response.write "Calculate arithmetic failed:" & retcode &"<br/>"
    else
    response.write "Calculate arithmetic successed(A=B+C,A=1,B=2,C=3),Result:A=" & Rockey4ND.p1 & "<br/>"
    End If
    
'Close Rockey
  retcode=Rockey4ND.RockeyCM(RY_CLOSE)
   If Not (retcode = 0) Then
    response.write "Close Rockey failed:" & retcode &"<br/>"
    else
    response.write "Close Rockey successed" & "<br/>"
    End If
%>
	</body>
</HTML>








