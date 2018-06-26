Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnSeed As System.Windows.Forms.Button
    Friend WithEvents btnRandom As System.Windows.Forms.Button
    Friend WithEvents btnWriteArith As System.Windows.Forms.Button
    Friend WithEvents btnCalc3 As System.Windows.Forms.Button
    Friend WithEvents btnCalc2 As System.Windows.Forms.Button
    Friend WithEvents btnReadUserID As System.Windows.Forms.Button
    Friend WithEvents btnReadModule As System.Windows.Forms.Button
    Friend WithEvents btnWriteUserID As System.Windows.Forms.Button
    Friend WithEvents btnWriteModule As System.Windows.Forms.Button
    Friend WithEvents btnCalc1 As System.Windows.Forms.Button
    Friend WithEvents btnDecModule As System.Windows.Forms.Button
    Friend WithEvents btnReadMomory As System.Windows.Forms.Button
    Friend WithEvents btnWriteMemory As System.Windows.Forms.Button
    Friend WithEvents btnCloseAll As System.Windows.Forms.Button
    Friend WithEvents btnOpenAll As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnSeed = New System.Windows.Forms.Button
        Me.btnRandom = New System.Windows.Forms.Button
        Me.btnWriteArith = New System.Windows.Forms.Button
        Me.btnCalc3 = New System.Windows.Forms.Button
        Me.btnCalc2 = New System.Windows.Forms.Button
        Me.btnReadUserID = New System.Windows.Forms.Button
        Me.btnReadModule = New System.Windows.Forms.Button
        Me.btnWriteUserID = New System.Windows.Forms.Button
        Me.btnWriteModule = New System.Windows.Forms.Button
        Me.btnCalc1 = New System.Windows.Forms.Button
        Me.btnDecModule = New System.Windows.Forms.Button
        Me.btnReadMomory = New System.Windows.Forms.Button
        Me.btnWriteMemory = New System.Windows.Forms.Button
        Me.btnCloseAll = New System.Windows.Forms.Button
        Me.btnOpenAll = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(22, 68)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(406, 82)
        Me.TextBox1.TabIndex = 39
        Me.TextBox1.Text = "TextBox1"
        Me.TextBox1.WordWrap = False
        '
        'btnSeed
        '
        Me.btnSeed.Location = New System.Drawing.Point(128, 314)
        Me.btnSeed.Name = "btnSeed"
        Me.btnSeed.Size = New System.Drawing.Size(94, 21)
        Me.btnSeed.TabIndex = 38
        Me.btnSeed.Text = "Transform Number"
        '
        'btnRandom
        '
        Me.btnRandom.Location = New System.Drawing.Point(22, 314)
        Me.btnRandom.Name = "btnRandom"
        Me.btnRandom.Size = New System.Drawing.Size(93, 21)
        Me.btnRandom.TabIndex = 37
        Me.btnRandom.Text = "Random Number"
        '
        'btnWriteArith
        '
        Me.btnWriteArith.Location = New System.Drawing.Point(22, 276)
        Me.btnWriteArith.Name = "btnWriteArith"
        Me.btnWriteArith.Size = New System.Drawing.Size(93, 22)
        Me.btnWriteArith.TabIndex = 36
        Me.btnWriteArith.Text = "Write Arithmetic"
        '
        'btnCalc3
        '
        Me.btnCalc3.Location = New System.Drawing.Point(342, 276)
        Me.btnCalc3.Name = "btnCalc3"
        Me.btnCalc3.Size = New System.Drawing.Size(93, 22)
        Me.btnCalc3.TabIndex = 35
        Me.btnCalc3.Text = "Calculate3"
        '
        'btnCalc2
        '
        Me.btnCalc2.Location = New System.Drawing.Point(235, 276)
        Me.btnCalc2.Name = "btnCalc2"
        Me.btnCalc2.Size = New System.Drawing.Size(93, 22)
        Me.btnCalc2.TabIndex = 34
        Me.btnCalc2.Text = "Calculate2"
        '
        'btnReadUserID
        '
        Me.btnReadUserID.Location = New System.Drawing.Point(128, 239)
        Me.btnReadUserID.Name = "btnReadUserID"
        Me.btnReadUserID.Size = New System.Drawing.Size(94, 22)
        Me.btnReadUserID.TabIndex = 33
        Me.btnReadUserID.Text = "Read UserID"
        '
        'btnReadModule
        '
        Me.btnReadModule.Location = New System.Drawing.Point(128, 202)
        Me.btnReadModule.Name = "btnReadModule"
        Me.btnReadModule.Size = New System.Drawing.Size(94, 21)
        Me.btnReadModule.TabIndex = 32
        Me.btnReadModule.Text = "Read Module"
        '
        'btnWriteUserID
        '
        Me.btnWriteUserID.Location = New System.Drawing.Point(22, 239)
        Me.btnWriteUserID.Name = "btnWriteUserID"
        Me.btnWriteUserID.Size = New System.Drawing.Size(93, 22)
        Me.btnWriteUserID.TabIndex = 31
        Me.btnWriteUserID.Text = "Write UserID"
        '
        'btnWriteModule
        '
        Me.btnWriteModule.Location = New System.Drawing.Point(22, 202)
        Me.btnWriteModule.Name = "btnWriteModule"
        Me.btnWriteModule.Size = New System.Drawing.Size(93, 21)
        Me.btnWriteModule.TabIndex = 30
        Me.btnWriteModule.Text = "Write Module"
        '
        'btnCalc1
        '
        Me.btnCalc1.Location = New System.Drawing.Point(128, 276)
        Me.btnCalc1.Name = "btnCalc1"
        Me.btnCalc1.Size = New System.Drawing.Size(94, 22)
        Me.btnCalc1.TabIndex = 29
        Me.btnCalc1.Text = "Calculate1"
        '
        'btnDecModule
        '
        Me.btnDecModule.Location = New System.Drawing.Point(235, 202)
        Me.btnDecModule.Name = "btnDecModule"
        Me.btnDecModule.Size = New System.Drawing.Size(93, 21)
        Me.btnDecModule.TabIndex = 28
        Me.btnDecModule.Text = "Decrease Module"
        '
        'btnReadMomory
        '
        Me.btnReadMomory.Location = New System.Drawing.Point(128, 165)
        Me.btnReadMomory.Name = "btnReadMomory"
        Me.btnReadMomory.Size = New System.Drawing.Size(94, 21)
        Me.btnReadMomory.TabIndex = 27
        Me.btnReadMomory.Text = "Read Memory"
        '
        'btnWriteMemory
        '
        Me.btnWriteMemory.Location = New System.Drawing.Point(22, 165)
        Me.btnWriteMemory.Name = "btnWriteMemory"
        Me.btnWriteMemory.Size = New System.Drawing.Size(93, 21)
        Me.btnWriteMemory.TabIndex = 26
        Me.btnWriteMemory.Text = "Write Memory"
        '
        'btnCloseAll
        '
        Me.btnCloseAll.Location = New System.Drawing.Point(235, 31)
        Me.btnCloseAll.Name = "btnCloseAll"
        Me.btnCloseAll.Size = New System.Drawing.Size(193, 22)
        Me.btnCloseAll.TabIndex = 25
        Me.btnCloseAll.Text = "Close All Rockey4ND Dongles"
        '
        'btnOpenAll
        '
        Me.btnOpenAll.Location = New System.Drawing.Point(22, 31)
        Me.btnOpenAll.Name = "btnOpenAll"
        Me.btnOpenAll.Size = New System.Drawing.Size(200, 22)
        Me.btnOpenAll.TabIndex = 24
        Me.btnOpenAll.Text = "Open All Rockey4ND Dongles"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(456, 366)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnSeed)
        Me.Controls.Add(Me.btnRandom)
        Me.Controls.Add(Me.btnWriteArith)
        Me.Controls.Add(Me.btnCalc3)
        Me.Controls.Add(Me.btnCalc2)
        Me.Controls.Add(Me.btnReadUserID)
        Me.Controls.Add(Me.btnReadModule)
        Me.Controls.Add(Me.btnWriteUserID)
        Me.Controls.Add(Me.btnWriteModule)
        Me.Controls.Add(Me.btnCalc1)
        Me.Controls.Add(Me.btnDecModule)
        Me.Controls.Add(Me.btnReadMomory)
        Me.Controls.Add(Me.btnWriteMemory)
        Me.Controls.Add(Me.btnCloseAll)
        Me.Controls.Add(Me.btnOpenAll)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Const RY_FIND = 1
    Const RY_FIND_NEXT = 2
    Const RY_OPEN = 3
    Const RY_CLOSE = 4
    Const RY_READ = 5
    Const RY_WRITE = 6
    Const RY_RANDOM = 7
    Const RY_SEED = 8
    Const RY_WRITE_USERID = 9
    Const RY_READ_USERID = 10
    Const RY_SET_MOUDLE = 11
    Const RY_CHECK_MOUDLE = 12
    Const RY_WRITE_ARITHMETIC = 13
    Const RY_CALCULATE1 = 14
    Const RY_CALCULATE2 = 15
    Const RY_CALCULATE3 = 16
    Const RY_DECREASE = 17

    Dim com As New CRockey4ND.CCRockey4ND
    Dim m_Handle(32) As Integer
    Dim m_HandleNum As Integer = 0


    Private Sub btnOpenAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenAll.Click

        TextBox1.Text = ""
        Dim ret As Integer

        com.p1 = &HC44C
        com.p2 = &HC8F8
        com.p3 = &H799
        com.p4 = &HC43B

        ret = com.RockeyCM(RY_FIND)

        If ret <> 0 Then
            MessageBox.Show("RY_FIND error")
            Return
        Else
            TextBox1.Text = "HID: " + com.lp1.ToString("X") + vbCrLf
        End If
        ret = com.RockeyCM(RY_OPEN)
        If ret <> 0 Then
            MessageBox.Show("RY_OPEN error")
            Return
        End If

        m_Handle(0) = com.handle
        m_HandleNum = 1

        While ret = 0
            ret = com.RockeyCM(RY_FIND_NEXT)
            If ret <> 0 Then
                Exit While
            Else
                TextBox1.Text += "HID: " + com.lp1.ToString("X") + vbCrLf
            End If
            ret = com.RockeyCM(RY_OPEN)
            If ret <> 0 Then
                Exit While
            End If

            m_Handle(m_HandleNum) = com.handle
            m_HandleNum = m_HandleNum + 1

        End While
    End Sub

    Private Sub btnCloseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseAll.Click

        TextBox1.Text = ""
        Dim i As Integer
        Dim ret As Integer

        For i = 0 To m_HandleNum - 1
            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_CLOSE)
            If ret <> 0 Then
                MessageBox.Show("RY_CLOSE error")
            End If
        Next
    End Sub

    Private Sub btnWriteUserID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteUserID.Click

        TextBox1.Text = ""
        Dim i As Integer
        Dim ret As Integer

        For i = 0 To m_HandleNum - 1
            com.handle = m_Handle(i)
            com.lp1 = &H12345678
            ret = com.RockeyCM(RY_WRITE_USERID)
            If ret <> 0 Then
                MessageBox.Show("RY_WRITE_USERID error")
            Else
                TextBox1.Text += "Write User ID to Dongle: " + com.lp1.ToString("X") + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnReadUserID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadUserID.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As Integer

        For i = 0 To m_HandleNum - 1
            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_READ_USERID)
            If ret <> 0 Then
                MessageBox.Show("RY_READ_USERID error")
            Else
                TextBox1.Text += "Read User ID from Dongle: " + com.lp1.ToString("X") + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnRandom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRandom.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As Integer

        For i = 0 To m_HandleNum - 1
            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_RANDOM)
            If ret <> 0 Then
                MessageBox.Show("RY_RANDOM error")
            Else
                TextBox1.Text += "Get Random Number are: " + _
                            com.p1.ToString("X") + " " + _
                            com.p2.ToString("X") + " " + _
                            com.p3.ToString("X") + " " + _
                            com.p4.ToString("X") + " " + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnSeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeed.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As Integer

        For i = 0 To m_HandleNum - 1

            com.lp2 = i + 100 'Seed Number
            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_SEED)
            If ret <> 0 Then
                MessageBox.Show("RY_SEED error")
            Else
                TextBox1.Text += "Get Transform Number from Seed are: " + _
                            com.p1.ToString("X") + " " + _
                            com.p2.ToString("X") + " " + _
                            com.p3.ToString("X") + " " + _
                            com.p4.ToString("X") + " " + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnWriteModule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteModule.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As Integer

        For i = 0 To m_HandleNum - 1
            com.p1 = 63 'Module Index
            com.p2 = 5  'Set Value
            com.p3 = 1  'allow decrease, 0 or 1
            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_SET_MOUDLE)
            If ret <> 0 Then
                MessageBox.Show("RY_SET_MOUDLE error")
            Else
                TextBox1.Text += "Write Module: Module No. is " + com.p1.ToString + _
                    ", Value is " + com.p2.ToString + ", Allow Decrease is " + com.p3.ToString + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnReadModule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadModule.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As Integer

        For i = 0 To m_HandleNum - 1
            com.p1 = 63 'Module Index
            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_CHECK_MOUDLE)
            If ret <> 0 Then
                MessageBox.Show("RY_CHECK_MOUDLE error")
            Else
                TextBox1.Text += "Read Module: Module No. is " + com.p1.ToString + _
                    ", Enable is " + com.p2.ToString + ", Allow Decrease is " + com.p3.ToString + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnDecModule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecModule.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As Integer

        For i = 0 To m_HandleNum - 1
            com.p1 = 63 'Module Index
            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_DECREASE)
            If ret <> 0 Then
                MessageBox.Show("RY_DECREASE error")
            Else
                TextBox1.Text += "Decrease Module value: Module No. is " + com.p1.ToString + _
                    ", Decreased" + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnWriteMemory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteMemory.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As Integer

        Dim str1 As String = "how do you turn this on"

        For i = 0 To m_HandleNum - 1
            com.p1 = 0 'offset
            com.p2 = 100 'length
            com.buffer = str1
            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_WRITE)
            If ret <> 0 Then
                MessageBox.Show("RY_WRITE error")
            Else
                TextBox1.Text += "Write a String, offset = " + com.p1.ToString + ", length = " + com.p2.ToString + ", >" + str1 + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnReadMomory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadMomory.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As Integer

        Dim str1(m_HandleNum) As String

        For i = 0 To m_HandleNum - 1
            com.p1 = 0 'offset
            com.p2 = 100 'length
            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_READ)
            If ret <> 0 Then
                MessageBox.Show("RY_READ error")
            Else
                str1(i) = com.buffer
                TextBox1.Text += "Read a String, offset = " + com.p1.ToString + ", length = " + com.p2.ToString + ", >" + str1(i) + vbCrLf
            End If
        Next

    End Sub


    Private Sub btnWriteArith_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteArith.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As Integer

        Dim str1 As String = "H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D"
        Dim str2 As String = "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H"
        Dim str3 As String = "A=E|E, B=F|F, C=G|G, D=H|H"

        For i = 0 To m_HandleNum - 1

            'arithmetic 1
            com.p1 = 0 'start position
            com.buffer = str1
            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_WRITE_ARITHMETIC)
            If ret <> 0 Then
                MessageBox.Show("RY_WRITE_ARITHMETIC error")
            Else
                TextBox1.Text += "Start Position: " + com.p1.ToString + ", " + str1 + vbCrLf
            End If

            'arithmetic 2
            com.p1 = 40 'start position
            com.buffer = str2
            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_WRITE_ARITHMETIC)
            If ret <> 0 Then
                MessageBox.Show("RY_WRITE_ARITHMETIC error")
            Else
                TextBox1.Text += "Start Position: " + com.p1.ToString + ", " + str2 + vbCrLf
            End If

            'arithmetic 3
            com.p1 = 80 'start position
            com.buffer = str3
            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_WRITE_ARITHMETIC)
            If ret <> 0 Then
                MessageBox.Show("RY_WRITE_ARITHMETIC error")
            Else
                TextBox1.Text += "Start Position: " + com.p1.ToString + ", " + str3 + vbCrLf + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnCalc1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc1.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As Integer

        For i = 0 To m_HandleNum - 1

            com.lp1 = 0 'start position
            com.lp2 = 7 'module No.
            com.p1 = 5
            com.p2 = 3
            com.p3 = 1
            com.p4 = &HFFFF

            TextBox1.Text += "Input: Start=" + com.lp1.ToString + ", " + _
                "Module=" + com.lp2.ToString + ", " + _
                "p1=" + com.p1.ToString("X") + ", " + _
                "p2=" + com.p2.ToString("X") + ", " + _
                "p3=" + com.p3.ToString("X") + ", " + _
                "p4=" + com.p4.ToString("X") + ", " + vbCrLf

            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_CALCULATE1)
            If ret <> 0 Then
                MessageBox.Show("RY_CALCULATE1 error")
            Else
                TextBox1.Text += "Output: p1= " + com.p1.ToString("X") + ", " + _
                    "p2= " + com.p2.ToString("X") + ", " + _
                    "p3= " + com.p3.ToString("X") + ", " + _
                    "p4= " + com.p4.ToString("X") + ", " + vbCrLf + vbCrLf
            End If

        Next

    End Sub

    Private Sub btnCalc2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc2.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As Integer

        For i = 0 To m_HandleNum - 1

            com.lp1 = 40 'start position
            com.lp2 = &H12345678 'module No.
            com.p1 = 1
            com.p2 = 2
            com.p3 = 3
            com.p4 = 4

            TextBox1.Text += "Input: Start=" + com.lp1.ToString + ", " + _
                "Seed=" + com.lp2.ToString("X") + ", " + _
                "p1=" + com.p1.ToString("X") + ", " + _
                "p2=" + com.p2.ToString("X") + ", " + _
                "p3=" + com.p3.ToString("X") + ", " + _
                "p4=" + com.p4.ToString("X") + ", " + vbCrLf

            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_CALCULATE2)
            If ret <> 0 Then
                MessageBox.Show("RY_CALCULATE2 error")
            Else
                TextBox1.Text += "Output: p1= " + com.p1.ToString("X") + ", " + _
                    "p2= " + com.p2.ToString("X") + ", " + _
                    "p3= " + com.p3.ToString("X") + ", " + _
                    "p4= " + com.p4.ToString("X") + ", " + vbCrLf + vbCrLf
            End If

        Next

    End Sub

    Private Sub btnCalc3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc3.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As Integer

        For i = 0 To m_HandleNum - 1

            com.lp1 = 80 'start position
            com.lp2 = 6 'module No.
            com.p1 = 1
            com.p2 = 2
            com.p3 = 3
            com.p4 = 4

            TextBox1.Text += "Input: Arithmetic Start=" + com.lp1.ToString + ", " + _
                "Module Start=" + com.lp2.ToString + ", " + _
                "p1=" + com.p1.ToString("X") + ", " + _
                "p2=" + com.p2.ToString("X") + ", " + _
                "p3=" + com.p3.ToString("X") + ", " + _
                "p4=" + com.p4.ToString("X") + ", " + vbCrLf

            com.handle = m_Handle(i)
            ret = com.RockeyCM(RY_CALCULATE3)
            If ret <> 0 Then
                MessageBox.Show("RY_CALCULATE3 error")
            Else
                TextBox1.Text += "Output: p1=" + com.p1.ToString("X") + ", " + _
                    "p2=" + com.p2.ToString("X") + ", " + _
                    "p3=" + com.p3.ToString("X") + ", " + _
                    "p4=" + com.p4.ToString("X") + ", " + vbCrLf
            End If

        Next

    End Sub

End Class
