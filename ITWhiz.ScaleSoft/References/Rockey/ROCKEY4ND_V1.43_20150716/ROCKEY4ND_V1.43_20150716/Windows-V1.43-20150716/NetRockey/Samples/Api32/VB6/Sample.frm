VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Sample"
   ClientHeight    =   3945
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   6045
   LinkTopic       =   "Form1"
   ScaleHeight     =   3945
   ScaleWidth      =   6045
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command2 
      Caption         =   "Quit"
      Height          =   375
      Left            =   3480
      TabIndex        =   2
      Top             =   3480
      Width           =   1215
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Test"
      Height          =   375
      Left            =   840
      TabIndex        =   1
      Top             =   3480
      Width           =   1215
   End
   Begin VB.ListBox List1 
      Height          =   3180
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   5775
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Sub ReportErr(lCode As Long)
    If lCode < 2000 Then
        List1.AddItem "Normal error,code " + Str(lCode)
    Else
        List1.AddItem "Net Error,code " + Str(lCode) + "Extend errcode" + Str(NrGetLastError())
    End If
End Sub

Function BufToStr(ByRef buf() As Byte) As String
    Dim sTemp As String
    Dim i As Long
    i = 0
    Do While True
        If buf(i) = 0 Then
            Exit Do
        End If
        sTemp = sTemp + Chr(buf(i))
        i = i + 1
    Loop
    BufToStr = sTemp
End Function

Private Sub Command1_Click()
    Dim hResult As Long
    Dim p1, p2, p3, p4 As Integer
    Dim lp1, lp2 As Long
    Dim handle As Integer
    Dim hID(16) As Long
    Dim buffer(512) As Byte
    Dim iRockey As Long
    Dim iModule As Long
    Dim dwMaxRockey As Long
    Dim sTemp As String
    Dim i As Integer
        
    'Find Net-Rockey,using DEMO password.
    'The high address space (500 ~ 999 )  can't be written in anything with Net-Rockey API ;
    List1.Clear
    
    List1.AddItem "****** Finding Net-Rockeys ..."
    p1 = &HC44C
    p2 = &HC8F8
    p3 = 0
    p4 = 0
    dwMaxRockey = 0
    hResult = NetRockey(RY_FIND, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
    
    If ERR_SUCCESS = hResult Then
        'lp1    ---- HardID of Founded Net-Rockey.
        'buffer ---- computer name of Net-Rockey insert in.
        List1.AddItem "Found, (" + Str(dwMaxRockey) + ") HID:" + Hex(lp1) + "@" + BufToStr(buffer)
        hID(dwMaxRockey) = lp1
        dwMaxRockey = dwMaxRockey + 1
    Else
        If hResult > 2000 Then
          List1.AddItem "net error"
        Else
          List1.AddItem "No net rockey found"
        End If
        
        Exit Sub
        
    End If
    
    'find other Net-Rockeys.
    Do While True
        hResult = NetRockey(RY_FIND_NEXT, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
        If (ERR_SUCCESS = hResult) Then
            List1.AddItem "Found, (" + Str(dwMaxRockey) + ") HID:" + Hex(lp1) + "@" + BufToStr(buffer)
            hID(dwMaxRockey) = lp1
            dwMaxRockey = dwMaxRockey + 1
        Else
            Exit Do
        End If
    Loop
    
    List1.AddItem ""
    
    'Open a module
    iRockey = 0
    iModule = 0
    List1.AddItem "****** Opening module ..." + Str(iModule) + " of " + Hex(hID(iRockey))
    lp1 = hID(iRockey)
    lp2 = iModule
    hResult = NetRockey(RY_OPEN, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
    If ERR_SUCCESS = hResult Then
        List1.AddItem "Opened,Handle:" + Str(handle)
    Else
        ReportErr (hResult)
        Exit Sub
    End If
    List1.AddItem ""
    
    'Read User Memory.
    List1.AddItem "****** Reading user memory ..."
    
    
    p1 = 0
    p2 = 24
    hResult = NetRockey(RY_READ, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
    If ERR_SUCCESS = hResult Then
        List1.AddItem "Succeed " + BufToStr(buffer)
    Else
        ReportErr (hResult)
        hResult = NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
        Exit Sub
    End If
    List1.AddItem ""
    
    
    'Random number test.
    List1.AddItem "****** Testing Random function..."
    sTemp = ""
    For i = 1 To 5
        hResult = NetRockey(RY_RANDOM, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
        If ERR_SUCCESS = hResult Then
            sTemp = sTemp + " " + Hex(p1)
        Else
            ReportErr (hResult)
            hResult = NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
            Exit Sub
        End If
    Next
    List1.AddItem sTemp
    List1.AddItem ""
        
    'Seed test.
    lp2 = &H3F025
    List1.AddItem "****** Seed test,seed is " + Hex(lp2)
    hResult = NetRockey(RY_SEED, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
    If (ERR_SUCCESS = hResult) Then
        List1.AddItem Hex(p1) + "  " + Hex(p2) + "  " + Hex(p3) + "  " + Hex(p4)
    Else
        ReportErr (hResult)
        hResult = NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
        Exit Sub
    End If
    List1.AddItem ""
    
    'Read User ID
    lp1 = 0
    List1.AddItem "****** Reading UserID..."
    hResult = NetRockey(RY_READ_USERID, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
    If (ERR_SUCCESS = hResult) Then
        List1.AddItem "Succeed,ID = " + Hex(lp1)
    Else
        ReportErr (hResult)
        hResult = NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
        Exit Sub
    End If
    List1.AddItem ""
    
    'Check the property of module 0
    p1 = 0
    List1.AddItem "****** Checking module 0..."
    hResult = NetRockey(RY_CHECK_MOUDLE, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
    If (ERR_SUCCESS = hResult) Then
        List1.AddItem "Succeed,validity:" + Str(p2) + " can decrease:" + Str(p3)
        
        '******************************************************************
        'if p3 then
        '    you can decrese this module by using below code
        '    p1 = 0
        '    list1.additem "****** Decrease module 0..."
        '    hResult = NetRockey(RY_DECREASE, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
        '    If (ERR_SUCCESS = hResult) Then
        '        list1.additem ("Decrease Succeed")
        '    End If
        'End If
        '******************************************************************
        
    Else
        ReportErr (hResult)
        hResult = NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
        Exit Sub
    End If
    List1.AddItem ""
    
    
    
    'Calculate 1
    lp1 = 0
    lp2 = 0
    p1 = 1
    p2 = 2
    p3 = 3
    p4 = 4
    List1.AddItem "****** Calculate 1 test,Startposition " + Str(lp1)
    hResult = NetRockey(RY_CALCULATE1, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
    If (ERR_SUCCESS = hResult) Then
        List1.AddItem "Succeed,p1=" + Str(p1) + ", " + "p2=" + Str(p2) + ", " + "p3=" + Str(p3) + ", " + "p4=" + Str(p4)
    Else
        ReportErr (hResult)
        hResult = NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))
        Exit Sub
    End If
    
    'you can do calculate 2,3 here.

    hResult = NetRockey(RY_CLOSE, handle, lp1, lp2, p1, p2, p3, p4, buffer(0))

End Sub

Private Sub Command2_Click()
Unload Me
End Sub


