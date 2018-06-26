Attribute VB_Name = "Module1"

Declare Function Rockey Lib "..\Rockey4ND.dll" (ByVal fcode As Integer, ByRef handle As Integer, ByRef lp1 As Long, ByRef lp2 As Long, ByRef p1 As Integer, ByRef p2 As Integer, ByRef p3 As Integer, ByRef p4 As Integer, ByVal buffer As Any) As Integer

Global Const RY_FIND = 1                                
Global Const RY_FIND_NEXT = 2                   
Global Const RY_OPEN = 3                             
Global Const RY_CLOSE = 4                         
Global Const RY_READ = 5                         
Global Const RY_WRITE = 6                           
Global Const RY_RANDOM = 7                        
Global Const RY_SEED = 8                              
Global Const RY_WRITE_USERID = 9           
Global Const RY_READ_USERID = 10           
Global Const RY_SET_MOUDLE = 11           
Global Const RY_CHECK_MOUDLE = 12     
Global Const RY_WRITE_ARITHMETIC = 13 
Global Const RY_CALCULATE1 = 14         
Global Const RY_CALCULATE2 = 15         
Global Const RY_CALCULATE3 = 16        
Global Const RY_DECREASE = 17           

' Error code
Global Const ERR_SUCCESS = 0                                  
Global Const ERR_NO_PARALLEL_PORT = 1             
Global Const ERR_NO_DRIVER = 2           
Global Const ERR_NO_ROCKEY = 3                       
Global Const ERR_INVALID_PASSWORD = 4              
Global Const ERR_INVALID_PASSWORD_OR_ID = 5        
Global Const ERR_SETID = 6                   
Global Const ERR_INVALID_ADDR_OR_SIZE = 7         
Global Const ERR_UNKNOWN_COMMAND = 8          
Global Const ERR_NOTBELEVEL3 = 9       
Global Const ERR_READ = 10            
Global Const ERR_WRITE = 11                       
Global Const ERR_RANDOM = 12                      
Global Const ERR_SEED = 13                       
Global Const ERR_CALCULATE = 14                  
Global Const ERR_NO_OPEN = 15                
Global Const ERR_OPEN_OVERFLOW = 16           
Global Const ERR_NOMORE = 17           
Global Const ERR_NEED_FIND = 18           
Global Const ERR_DECREASE = 19            

Global Const ERR_AR_BADCOMMAND = 20        
Global Const ERR_AR_UNKNOWN_OPCODE = 21        
Global Const ERR_AR_WRONGBEGIN = 22       
Global Const ERR_AR_WRONG_END = 23          
Global Const ERR_AR_VALUEOVERFLOW = 24          
Global Const ERR_UNKNOWN = &HFFFF               

Global Const ERR_RECEIVE_NULL = &H100         
Global Const ERR_PRNPORT_BUSY = &H101        

Public Function Cuint(ByVal v As Integer) As Long
Dim r As Long

If (v > 0) Then
r = v
Else
r = 65536 + v
End If
Cuint = r
End Function
