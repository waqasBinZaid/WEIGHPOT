VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   4860
   ClientLeft      =   60
   ClientTop       =   348
   ClientWidth     =   7152
   LinkTopic       =   "Form1"
   ScaleHeight     =   4860
   ScaleWidth      =   7152
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton TestBtn 
      Caption         =   "Test"
      Height          =   375
      Left            =   2640
      TabIndex        =   1
      Top             =   4440
      Width           =   1815
   End
   Begin VB.ListBox List1 
      Height          =   3888
      ItemData        =   "Form1.frx":0000
      Left            =   240
      List            =   "Form1.frx":0002
      TabIndex        =   0
      Top             =   120
      Width           =   6735
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub TestBtn_Click()

Dim handle(0 To 15) As Integer
Dim p1, p2, p3, p4, i, j, retcode As Integer
Dim lp1, lp2, v As Long
Dim buffer As String
Dim rc(0 To 3) As Integer
Dim curline As Integer

curline = 0

p1 = &HC44C
p2 = &HC8F8
p3 = &H799
p4 = &HC43B

retcode = Rockey(RY_FIND, handle(0), lp1, lp2, p1, p2, p3, p4, buffer)
If (retcode <> 0) Then
    List1.List(curline) = "Error Code:" & retcode
    Exit Sub
End If
List1.List(curline) = "Find Rock: " & Hex(lp1)
curline = curline + 1

retcode = Rockey(RY_OPEN, handle(0), lp1, lp2, p1, p2, p3, p4, buffer)
If (retcode <> 0) Then
    List1.List(curline) = "Error Code:" & retcode
    Exit Sub
End If

i = 1
Do While retcode = 0
    retcode = Rockey(RY_FIND_NEXT, handle(i), lp1, lp2, p1, p2, p3, p4, buffer)
    If retcode = ERR_NOMORE Then
    Exit Do
    End If
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
    Exit Sub
    End If
    
    retcode = Rockey(RY_OPEN, handle(i), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
    Exit Sub
    End If
    
    i = i + 1
    List1.List(curline) = "Find Rock: " & Hex(lp1)
    curline = curline + 1
Loop
    
For j = 0 To i - 1
    p1 = 498
    p2 = 6
    p3 = 1
    buffer = "Hello1"
    retcode = Rockey(RY_WRITE, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
    Exit Sub
    End If
    List1.List(curline) = "Write: Hello1"
    curline = curline + 1
    
    p1 = 498
    p2 = 6
    buffer = "                          "
    retcode = Rockey(RY_READ, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
    Exit Sub
    End If
    List1.List(curline) = "Read: " & buffer
    curline = curline + 1
    
    
    
    
    retcode = Rockey(RY_RANDOM, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
    Exit Sub
    End If
    List1.List(curline) = "Random:" & Hex(p1) & " " & Hex(p2) & " " & Hex(p3) & " " & Hex(p4)
    curline = curline + 1
    
    lp2 = &H12345678
    retcode = Rockey(RY_SEED, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
    Exit Sub
    End If
    List1.List(curline) = "Seed: " & Hex(p1) & " " & Hex(p2) & " " & Hex(p3) & " " & Hex(p4)
    curline = curline + 1
    rc(0) = p1
    rc(1) = p2
    rc(2) = p3
    rc(3) = p4
    
    lp1 = &H88888888
    retcode = Rockey(RY_WRITE_USERID, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
    Exit Sub
    End If
    List1.List(curline) = "Write User ID: " & Hex(lp1)
    curline = curline + 1
    
    lp1 = 0
    retcode = Rockey(RY_READ_USERID, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
    Exit Sub
    End If
    List1.List(curline) = "Read User ID: " & Hex(lp1)
    
    p1 = 7
    p2 = &H2121
    p3 = 0
    retcode = Rockey(RY_SET_MOUDLE, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
    Exit Sub
    End If
    List1.List(curline) = "Set Moudle 7: Pass = " & Hex(p2) & "  Decrease Not Allow"
    curline = curline + 1
    
    p1 = 7
    retcode = Rockey(RY_CHECK_MOUDLE, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
    Exit Sub
    End If
    List1.List(curline) = "Check Moudle 7: "
    If (p2 = 1) Then
        List1.List(curline) = List1.List(curline) + "Allow "
    Else
        List1.List(curline) = List1.List(curline) + "No Allow"
    End If
    If (p3 = 1) Then
        List1.List(curline) = List1.List(curline) + "   Allow Decrease"
    Else
            List1.List(curline) = List1.List(curline) + "   Not Allow Decrease"
    End If
    
    p1 = 0
    buffer = "H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D"
    retcode = Rockey(RY_WRITE_ARITHMETIC, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
        Exit Sub
    End If
    List1.List(curline) = "Write Arithmetic 1"
    curline = curline + 1
    
    lp1 = 0
    lp2 = 7
    p1 = 5
    p2 = 3
    p3 = 1
    p4 = &HFFFF
    retcode = Rockey(RY_CALCULATE1, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
        Exit Sub
    End If
    List1.List(curline) = "Calculate Input: p1=5, p2=3, p3=1, p4=&HFFFF"
    curline = curline + 1
    List1.List(curline) = "Result = ((5*23 + 3*17 + &2121) < 1) ^ FFFF = BC71"
    curline = curline + 1
    List1.List(curline) = "Calculate Output: p1=" & Hex(p1) & "  p2=" & Hex(p2) & "  p3= " & Hex(p3) & "  p4 =" & Hex(p4)
    curline = curline + 1
    
    p1 = 10
    buffer = "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H"
    retcode = Rockey(RY_WRITE_ARITHMETIC, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
        Exit Sub
    End If
    List1.List(curline) = "Write Arithmetic 2"
    curline = curline + 1
    
    lp1 = 10
    lp2 = &H12345678
    p1 = 1
    p2 = 2
    p3 = 3
    p4 = 4
    retcode = Rockey(RY_CALCULATE2, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
        Exit Sub
    End If
    List1.List(curline) = "Calculate Input: p1=1, p2=2, p3=3, p4=4"
    curline = curline + 1
    
    v = Cuint(rc(0)) + Cuint(rc(1)) + Cuint(rc(2)) + Cuint(rc(3)) + 10
    List1.List(curline) = "Result = " & Hex(rc(0)) & "+" & Hex(rc(1)) & "+" & Hex(rc(2)) & "+" & Hex(rc(3)) & "+ 1 + 2 + 3 + 4 = " & Hex(v Mod &H10000)
    curline = curline + 1
    List1.List(curline) = "Calculate Output: p1=" & Hex(p1) & "  p2=" & Hex(p2) & "  p3=" & Hex(p3) & "  p4=" & Hex(p4)
    curline = curline + 1
    
    p1 = 9
    p2 = 5
    p3 = 1
    retcode = Rockey(RY_SET_MOUDLE, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
        Exit Sub
    End If
    
    p1 = 17
    buffer = "A=E|E, B=F|F, C=G|G, D=H|H"
    retcode = Rockey(RY_WRITE_ARITHMETIC, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
        Exit Sub
    End If
    List1.List(curline) = "Write Arithmetic 3"
    curline = curline + 1

    lp1 = 17
    lp2 = 6
    p1 = 1
    p2 = 2
    p3 = 3
    p4 = 4
    retcode = Rockey(RY_CALCULATE3, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
        Exit Sub
    End If
    List1.List(curline) = "Show Module from 6: p1=" & Hex(p1) & "  p2=" & Hex(p2) & "  p3=" & Hex(p3) & "  p4=" & Hex(p4)
    curline = curline + 1

    p1 = 9
    retcode = Rockey(RY_DECREASE, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
        Exit Sub
    End If
    List1.List(curline) = "Decrease module 9"
    curline = curline + 1
    
    lp1 = 17
    lp2 = 6
    p1 = 1
    p2 = 2
    p3 = 3
    p4 = 4
    retcode = Rockey(RY_CALCULATE3, handle(j), lp1, lp2, p1, p2, p3, p4, buffer)
    If (retcode <> 0) Then
        List1.List(curline) = "Error Code:" & retcode
        Exit Sub
    End If
    List1.List(curline) = "Show Module from 6: p1=" & Hex(p1) & "  p2=" & Hex(p2) & "  p3=" & Hex(p3) & "  p4=" & Hex(p4)
    curline = curline + 1
Next j

End Sub
