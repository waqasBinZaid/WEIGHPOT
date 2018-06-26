VERSION 5.00
Object = "{3E0B4E75-EB6C-11D3-B6BF-0000E840043D}#1.0#0"; "ROCKEY~1.OCX"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   5520
   ClientLeft      =   2895
   ClientTop       =   1710
   ClientWidth     =   6285
   LinkTopic       =   "Form1"
   ScaleHeight     =   5520
   ScaleWidth      =   6285
   Begin FTROCKEYCONTROLLib.FtRockeyControl FtRockeyControl1 
      Height          =   375
      Left            =   360
      TabIndex        =   18
      Top             =   120
      Width           =   1095
      _Version        =   65536
      _ExtentX        =   1931
      _ExtentY        =   661
      _StockProps     =   0
   End
   Begin VB.CommandButton Close 
      Caption         =   "Close"
      Height          =   375
      Left            =   4680
      TabIndex        =   16
      Top             =   3960
      Width           =   1215
   End
   Begin VB.CommandButton Cal2 
      Caption         =   "Calculate2"
      Height          =   375
      Left            =   4680
      TabIndex        =   15
      Top             =   2920
      Width           =   1215
   End
   Begin VB.CommandButton Cal1 
      Caption         =   "Calculate 1"
      Height          =   375
      Left            =   4680
      TabIndex        =   14
      Top             =   2360
      Width           =   1215
   End
   Begin VB.CommandButton Cal3 
      Caption         =   "Calculate 3"
      Height          =   375
      Left            =   4680
      TabIndex        =   13
      Top             =   3480
      Width           =   1215
   End
   Begin VB.CommandButton CheckModule 
      Caption         =   "Check Module"
      Height          =   375
      Left            =   4680
      TabIndex        =   12
      Top             =   1800
      Width           =   1215
   End
   Begin VB.CommandButton SetModule 
      Caption         =   "SetModule"
      Height          =   375
      Left            =   4680
      TabIndex        =   11
      Top             =   1240
      Width           =   1215
   End
   Begin VB.CommandButton Seed 
      Caption         =   "Seed"
      Height          =   375
      Left            =   4680
      TabIndex        =   10
      Top             =   4560
      Width           =   1215
   End
   Begin VB.CommandButton UserId 
      Caption         =   "Write UserId"
      Height          =   375
      Left            =   4680
      TabIndex        =   9
      Top             =   5040
      Width           =   1215
   End
   Begin VB.CommandButton ReadUserId 
      Caption         =   "ReadUserId"
      Height          =   375
      Left            =   4680
      TabIndex        =   8
      Top             =   680
      Width           =   1215
   End
   Begin VB.CommandButton Random 
      Caption         =   "Random"
      Height          =   375
      Left            =   3120
      TabIndex        =   7
      Top             =   5040
      Width           =   1215
   End
   Begin VB.CommandButton Demo 
      Caption         =   "Demo"
      Height          =   375
      Left            =   4680
      TabIndex        =   6
      Top             =   120
      Width           =   1215
   End
   Begin VB.CommandButton Read 
      Caption         =   "Read"
      Height          =   375
      Left            =   3120
      TabIndex        =   5
      Top             =   4560
      Width           =   1215
   End
   Begin VB.CommandButton Write 
      Caption         =   "Write"
      Height          =   375
      Left            =   1680
      TabIndex        =   4
      Top             =   5040
      Width           =   1215
   End
   Begin VB.CommandButton FindNext 
      Caption         =   "FindNext"
      Height          =   375
      Left            =   1680
      TabIndex        =   3
      Top             =   4560
      Width           =   1215
   End
   Begin VB.ListBox List1 
      Height          =   3765
      Left            =   360
      TabIndex        =   2
      Top             =   480
      Width           =   3975
   End
   Begin VB.CommandButton Find 
      Caption         =   "Find"
      Height          =   375
      Left            =   120
      TabIndex        =   1
      Top             =   4560
      Width           =   1215
   End
   Begin VB.CommandButton Open 
      Caption         =   "Open"
      Height          =   375
      Left            =   120
      TabIndex        =   0
      Top             =   5040
      Width           =   1215
   End
   Begin VB.Label Label1 
      Caption         =   "Please Click Demo Button First"
      Height          =   255
      Left            =   1800
      TabIndex        =   17
      Top             =   120
      Width           =   2535
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Const RY_FIND = 1                              '找锁
Const RY_FIND_NEXT = 2                 '找下一锁
Const RY_OPEN = 3                              '打开锁
Const RY_CLOSE = 4                             '关闭锁
Const RY_READ = 5                              '读锁
Const RY_WRITE = 6                             '写锁
Const RY_RANDOM = 7                            '产生随机数
Const RY_SEED = 8                              '产生种子码
Const RY_WRITE_USERID = 9              '写用户 ID
Const RY_READ_USERID = 10              '读用户 ID
Const RY_SET_MOUDLE = 11               '设置模块字
Const RY_CHECK_MOUDLE = 12             '检查模块状态
Const RY_SET_MODULE = 11               '设置模块字
Const RY_CHECK_MODULE = 12             '检查模块状态
Const RY_WRITE_ARITHMETIC = 13                 '写算法
Const RY_CALCULATE1 = 14               '计算 1
Const RY_CALCULATE2 = 15               '计算 2
Const RY_CALCULATE3 = 16               '计算 3
Const RY_DECREASE = 17              '递减模块单元
Const cmd0 = "H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D"
Const cmd1 = "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H"
Const cmd2 = "A=E|E, B=F|F, C=G|G, D=H|H"

Public err As Integer

Public sd1 As Integer
Public sd2 As Integer
Public sd3 As Integer
Public sd4 As Integer

Private Sub Demo_Click()
    Find_Click
    Open_Click
    Write_Click
    Read_Click
    Random_Click
    Seed_Click
    UserId_Click
    ReadUserId_Click
    SetModule_Click
    CheckModule_Click
    Cal1_Click
    Cal2_Click
    Cal3_Click
    Close
End Sub

Private Sub Form_Load()
    FtRockeyControl1.P1 = &HC44C
    FtRockeyControl1.P2 = &HC8F8
    FtRockeyControl1.P3 = &H799
   FtRockeyControl1.P4 = &HC43B
End Sub

Private Sub Find_Click()
    FtRockeyControl1.P1 = &HC44C
    FtRockeyControl1.P2 = &HC8F8
    FtRockeyControl1.P3 = &H799
    FtRockeyControl1.P4 = &HC43B
    err = FtRockeyControl1.Rockey(RY_FIND)
    List1.AddItem "Find"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
    List1.AddItem "Find Rockey : " + Str(FtRockeyControl1.Lp1)
End Sub

Private Sub Open_Click()
    FtRockeyControl1.P1 = &HC44C
    FtRockeyControl1.P2 = &HC8F8
    FtRockeyControl1.P3 = &H799
    FtRockeyControl1.P4 = &HC43B
    err = FtRockeyControl1.Rockey(RY_OPEN)
    List1.AddItem "Open"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
End Sub

Private Sub FindNext_Click()
    err = FtRockeyControl1.Rockey(RY_FIND_NEXT)
    List1.AddItem "Find Next"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
End Sub

Private Sub Write_Click()
    FtRockeyControl1.P1 = 3
    FtRockeyControl1.P2 = 5
    FtRockeyControl1.Buffer = "Hello"
    err = FtRockeyControl1.Rockey(RY_WRITE)
    List1.AddItem "Write"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
End Sub

Private Sub Read_Click()
    FtRockeyControl1.P1 = 3
    FtRockeyControl1.P2 = 5
    err = FtRockeyControl1.Rockey(RY_READ)
    List1.AddItem "Read"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
    List1.AddItem FtRockeyControl1.Buffer
End Sub

Private Sub Random_Click()
    err = FtRockeyControl1.Rockey(RY_RANDOM)
    List1.AddItem "Random"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
    List1.AddItem FtRockeyControl1.P1
End Sub

Private Sub Seed_Click()
    FtRockeyControl1.Lp2 = &H12334578
    err = FtRockeyControl1.Rockey(RY_SEED)
    List1.AddItem "Seed"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
    List1.AddItem FtRockeyControl1.P1
    List1.AddItem FtRockeyControl1.P2
    List1.AddItem FtRockeyControl1.P3
    List1.AddItem FtRockeyControl1.P4
    sd1 = FtRockeyControl1.P1
    sd2 = FtRockeyControl1.P2
    sd3 = FtRockeyControl1.P3
    sd4 = FtRockeyControl1.P4
End Sub
Private Sub UserId_Click()
    FtRockeyControl1.Lp1 = &H88888888
    err = FtRockeyControl1.Rockey(RY_WRITE_USERID)
    List1.AddItem "Write UserId"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
    List1.AddItem FtRockeyControl1.Lp1
End Sub

Private Sub ReadUserId_Click()
    err = FtRockeyControl1.Rockey(RY_READ_USERID)
    List1.AddItem "Read UserId"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
    List1.AddItem FtRockeyControl1.Lp1
End Sub

Private Sub SetModule_Click()
    FtRockeyControl1.P1 = 7
    FtRockeyControl1.P2 = &H2121
    FtRockeyControl1.P3 = 0
    err = FtRockeyControl1.Rockey(RY_SET_MODULE)
    List1.AddItem "Set Module"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
    List1.AddItem FtRockeyControl1.P3
End Sub
Private Sub CheckModule_Click()
    FtRockeyControl1.P1 = 7
    err = FtRockeyControl1.Rockey(RY_CHECK_MODULE)
    List1.AddItem "Check Module"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
    List1.AddItem FtRockeyControl1.P2
    List1.AddItem FtRockeyControl1.P3
End Sub
Public Sub WriteArithmetic(cmd As String, idx As Integer)
    FtRockeyControl1.Buffer = cmd
    err = FtRockeyControl1.Rockey(RY_WRITE_ARITHMETIC)
    List1.AddItem "Write Arithmetic"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
    List1.AddItem "Write Arithmetic " + Str(idx)
End Sub
Public Sub ExecCalculate(idx As Integer)
    List1.AddItem "Calculate Input: p1=" + Str(FtRockeyControl1.P1) + " p2=" + Str(FtRockeyControl1.P2) + " p3=" + Str(FtRockeyControl1.P3) + " p4=" + Str(FtRockeyControl1.P4)
    err = FtRockeyControl1.Rockey(idx)
    List1.AddItem "Exec Calculate"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
    List1.AddItem "Exec Calculate " + Str(idx)
End Sub

Private Sub Cal1_Click()
    FtRockeyControl1.P1 = 0
    WriteArithmetic cmd0, 1
    
    FtRockeyControl1.Lp1 = 0
    FtRockeyControl1.Lp2 = 7
    FtRockeyControl1.P1 = 5
    FtRockeyControl1.P2 = 3
    FtRockeyControl1.P3 = 1
    FtRockeyControl1.P4 = &HFFFF
    ExecCalculate RY_CALCULATE1
    List1.AddItem "Result = 5*23 + 3*17 + 0x2121 < 1 ^ 0xffff = BC71"
    List1.AddItem "Calculate Output: p1=" + Str(FtRockeyControl1.P1) + " p2=" + Str(FtRockeyControl1.P2) + " p3=" + Str(FtRockeyControl1.P3) + " p4=" + Str(FtRockeyControl1.P4)
End Sub

Private Sub Cal2_Click()
    FtRockeyControl1.P1 = 10
    WriteArithmetic cmd1, 2
    
    FtRockeyControl1.Lp1 = 10
    FtRockeyControl1.Lp2 = &H12345678
    FtRockeyControl1.P1 = 1
    FtRockeyControl1.P2 = 2
    FtRockeyControl1.P3 = 3
    FtRockeyControl1.P4 = 4
    ExecCalculate RY_CALCULATE2
    List1.AddItem "Result =sd1 + sd2 + sd3 + sd4 + 1 + 2 + 3 + 4 = " + Str(1 + 2 + 3 + 4 + 10)
    List1.AddItem "Calculate Output: p1=" + Str(FtRockeyControl1.P1) + " p2=" + Str(FtRockeyControl1.P2) + " p3=" + Str(FtRockeyControl1.P3) + " p4=" + Str(FtRockeyControl1.P4)
End Sub

Private Sub Cal3_Click()
    FtRockeyControl1.P1 = 9
    FtRockeyControl1.P2 = 5
    FtRockeyControl1.P3 = 1
    err = FtRockeyControl1.Rockey(RY_SET_MODULE)
    List1.AddItem "Set Module 9"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
    
    FtRockeyControl1.P1 = 17
    WriteArithmetic cmd2, 3
    FtRockeyControl1.Lp1 = 17
    FtRockeyControl1.Lp2 = 6
    FtRockeyControl1.P1 = 1
    FtRockeyControl1.P2 = 2
    FtRockeyControl1.P3 = 3
    FtRockeyControl1.P4 = 4
    ExecCalculate (RY_CALCULATE3)
    List1.AddItem "Calculate Output: p1=" + Str(FtRockeyControl1.P1) + " p2=" + Str(FtRockeyControl1.P2) + " p3=" + Str(FtRockeyControl1.P3) + " p4=" + Str(FtRockeyControl1.P4)
    
    FtRockeyControl1.P1 = 9
    err = FtRockeyControl1.Rockey(RY_DECREASE)
    List1.AddItem "Decrease Module 9"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
    FtRockeyControl1.Lp1 = 17
    FtRockeyControl1.Lp2 = 6
    FtRockeyControl1.P1 = 1
    FtRockeyControl1.P2 = 2
    FtRockeyControl1.P3 = 3
    FtRockeyControl1.P4 = 4
    ExecCalculate (RY_CALCULATE3)
    List1.AddItem "Calculate Output: p1=" + Str(FtRockeyControl1.P1) + " p2=" + Str(FtRockeyControl1.P2) + " p3=" + Str(FtRockeyControl1.P3) + " p4=" + Str(FtRockeyControl1.P4)
End Sub

Private Sub Close_Click()
    err = FtRockeyControl1.Rockey(RY_CLOSE)
    List1.AddItem "Close"
    List1.AddItem FtRockeyControl1.ErrToStr(err)
End Sub
