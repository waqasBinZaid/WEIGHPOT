Public Class Form1


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

    Dim r4nd As New Rockey4NDControl.Rockey4ND
    Dim m_HIndex(32) As UInt16
    Dim m_HandleNum As Integer = 0

    Private Sub btnOpenAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenAll.Click

        TextBox1.Text = ""

        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        p1 = Convert.ToUInt16(&HC44C)
        p2 = Convert.ToUInt16(&HC8F8)
        p3 = Convert.ToUInt16(&H799)
        p4 = Convert.ToUInt16(&HC43B)

        ret = r4nd.Rockey(RY_FIND, m_HIndex(0), lp1, lp2, p1, p2, p3, p4, buffer)
        If ret <> 0 Then
            MessageBox.Show("RY_FIND error")
            Return
        Else
            TextBox1.Text = "HID: " + lp1.ToString("X") + vbCrLf
        End If

        ret = r4nd.Rockey(RY_OPEN, m_HIndex(0), lp1, lp2, p1, p2, p3, p4, buffer)
        If ret <> 0 Then
            MessageBox.Show("RY_OPEN error")
            Return
        End If

        m_HandleNum = 1
        While ret = 0
            ret = r4nd.Rockey(RY_FIND_NEXT, m_HIndex(m_HandleNum), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                Exit While
            Else
                TextBox1.Text += "HID: " + lp1.ToString("X") + vbCrLf
            End If
            ret = r4nd.Rockey(RY_OPEN, m_HIndex(m_HandleNum), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                Exit While
            End If
            m_HandleNum = m_HandleNum + 1
        End While
    End Sub

    Private Sub btnCloseAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseAll.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        For i = 0 To m_HandleNum - 1
            ret = r4nd.Rockey(RY_CLOSE, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_CLOSE error")
            End If
        Next
    End Sub

    Private Sub btnWriteUserID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteUserID.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        lp1 = Convert.ToUInt32(&H12345678)

        For i = 0 To m_HandleNum - 1
            ret = r4nd.Rockey(RY_WRITE_USERID, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_WRITE_USERID error")
            Else
                TextBox1.Text += "Write User ID to Dongle: " + lp1.ToString("X") + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnReadUserID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadUserID.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        For i = 0 To m_HandleNum - 1
            ret = r4nd.Rockey(RY_READ_USERID, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_READ_USERID error")
            Else
                TextBox1.Text += "Read User ID from Dongle: " + lp1.ToString("X") + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnRandom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRandom.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        For i = 0 To m_HandleNum - 1
            ret = r4nd.Rockey(RY_RANDOM, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_RANDOM error")
            Else
                TextBox1.Text += "Get Random Number are: " + _
                            p1.ToString("X") + " " + _
                            p2.ToString("X") + " " + _
                            p3.ToString("X") + " " + _
                            p4.ToString("X") + " " + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnSeed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeed.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        For i = 0 To m_HandleNum - 1
            lp2 = Convert.ToUInt32(i + 100) 'Seed Number
            ret = r4nd.Rockey(RY_SEED, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_SEED error")
            Else
                TextBox1.Text += "Get Transform Number from Seed are: " + _
                            p1.ToString("X") + " " + _
                            p2.ToString("X") + " " + _
                            p3.ToString("X") + " " + _
                            p4.ToString("X") + " " + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnWriteModule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteModule.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        For i = 0 To m_HandleNum - 1
            p1 = Convert.ToUInt16(63) 'Module Index
            p2 = Convert.ToUInt16(5)  'Set Value
            p3 = Convert.ToUInt16(1)  'allow decrease, 0 or 1
            ret = r4nd.Rockey(RY_SET_MOUDLE, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_SET_MOUDLE error")
            Else
                TextBox1.Text += "Write Module: Module No. is " + p1.ToString + _
                    ", Value is " + p2.ToString + ", Allow Decrease is " + p3.ToString + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnReadModule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadModule.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        For i = 0 To m_HandleNum - 1
            p1 = Convert.ToUInt16(63) 'Module Index
            ret = r4nd.Rockey(RY_CHECK_MOUDLE, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_CHECK_MOUDLE error")
            Else
                TextBox1.Text += "Read Module: Module No. is " + p1.ToString + _
                    ", Enable is " + p2.ToString + ", Allow Decrease is " + p3.ToString + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnDecModule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDecModule.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        For i = 0 To m_HandleNum - 1
            p1 = Convert.ToUInt16(63) 'Module Index
            ret = r4nd.Rockey(RY_DECREASE, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_DECREASE error")
            Else
                TextBox1.Text += "Decrease Module value: Module No. is " + p1.ToString + _
                    ", Decreased" + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnWriteMemory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteMemory.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        Dim str1 As String = "how do you turn this on"
        For i = 0 To str1.Length - 1
            buffer(i) = Convert.ToByte(str1.Chars(i))
        Next
        buffer(str1.Length) = 0

        For i = 0 To m_HandleNum - 1
            p1 = Convert.ToUInt16(0) 'offset
            p2 = Convert.ToUInt16(100) 'length
            ret = r4nd.Rockey(RY_WRITE, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_WRITE error")
            Else
                TextBox1.Text += "Write a String, offset = " + p1.ToString + ", length = " + p2.ToString + ", >" + str1 + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnReadMomory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReadMomory.Click

        TextBox1.Text = ""

        Dim i, k As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        Dim str1(m_HandleNum) As String

        For i = 0 To m_HandleNum - 1
            p1 = Convert.ToUInt16(0) 'offset
            p2 = Convert.ToUInt16(100) 'length
            ret = r4nd.Rockey(RY_READ, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_READ error")
            Else
                For k = 0 To Convert.ToInt32(p2)
                    If buffer(k) = 0 Then
                        Exit For
                    End If
                    str1(i) += Convert.ToChar(buffer(k))
                Next
                TextBox1.Text += "Read a String, offset = " + p1.ToString + ", length = " + p2.ToString + ", >" + str1(i) + vbCrLf
            End If
        Next

    End Sub


    Private Sub btnWriteArith_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWriteArith.Click

        TextBox1.Text = ""

        Dim i, k As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        Dim str1 As String = "H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D"
        Dim str2 As String = "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H"
        Dim str3 As String = "A=E|E, B=F|F, C=G|G, D=H|H"

        For i = 0 To m_HandleNum - 1

            'arithmetic 1
            p1 = Convert.ToUInt16(0) 'start position
            For k = 0 To str1.Length - 1
                buffer(k) = Convert.ToByte(str1.Chars(k))
            Next
            buffer(str1.Length) = 0
            ret = r4nd.Rockey(RY_WRITE_ARITHMETIC, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_WRITE_ARITHMETIC error")
            Else
                TextBox1.Text += "Start Position: " + p1.ToString + ", " + str1 + vbCrLf
            End If

            'arithmetic 2
            p1 = Convert.ToUInt16(40) 'start position
            For k = 0 To str2.Length - 1
                buffer(k) = Convert.ToByte(str2.Chars(k))
            Next
            buffer(str2.Length) = 0
            ret = r4nd.Rockey(RY_WRITE_ARITHMETIC, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_WRITE_ARITHMETIC error")
            Else
                TextBox1.Text += "Start Position: " + p1.ToString + ", " + str2 + vbCrLf
            End If

            'arithmetic 3
            p1 = Convert.ToUInt16(80) 'start position
            For k = 0 To str3.Length - 1
                buffer(k) = Convert.ToByte(str3.Chars(k))
            Next
            buffer(str3.Length) = 0
            ret = r4nd.Rockey(RY_WRITE_ARITHMETIC, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_WRITE_ARITHMETIC error")
            Else
                TextBox1.Text += "Start Position: " + p1.ToString + ", " + str3 + vbCrLf + vbCrLf
            End If
        Next

    End Sub

    Private Sub btnCalc1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc1.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        For i = 0 To m_HandleNum - 1

            lp1 = Convert.ToUInt32(0) 'start position
            lp2 = Convert.ToUInt32(7) 'module No.
            p1 = Convert.ToUInt16(5)
            p2 = Convert.ToUInt16(3)
            p3 = Convert.ToUInt16(1)
            p4 = Convert.ToUInt16(&HFFFF)

            TextBox1.Text += "Input: Start=" + lp1.ToString + ", " + _
                "Module=" + lp2.ToString + ", " + _
                "p1=" + p1.ToString("X") + ", " + _
                "p2=" + p2.ToString("X") + ", " + _
                "p3=" + p3.ToString("X") + ", " + _
                "p4=" + p4.ToString("X") + ", " + vbCrLf

            ret = r4nd.Rockey(RY_CALCULATE1, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_CALCULATE1 error")
            Else
                TextBox1.Text += "Output: p1= " + p1.ToString("X") + ", " + _
                    "p2= " + p2.ToString("X") + ", " + _
                    "p3= " + p3.ToString("X") + ", " + _
                    "p4= " + p4.ToString("X") + ", " + vbCrLf + vbCrLf
            End If

        Next

    End Sub

    Private Sub btnCalc2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc2.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        For i = 0 To m_HandleNum - 1

            lp1 = Convert.ToUInt32(40) 'start position
            lp2 = Convert.ToUInt32(&H12345678) 'module No.
            p1 = Convert.ToUInt16(1)
            p2 = Convert.ToUInt16(2)
            p3 = Convert.ToUInt16(3)
            p4 = Convert.ToUInt16(4)

            TextBox1.Text += "Input: Start=" + lp1.ToString + ", " + _
                "Seed=" + lp2.ToString("X") + ", " + _
                "p1=" + p1.ToString("X") + ", " + _
                "p2=" + p2.ToString("X") + ", " + _
                "p3=" + p3.ToString("X") + ", " + _
                "p4=" + p4.ToString("X") + ", " + vbCrLf

            ret = r4nd.Rockey(RY_CALCULATE2, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_CALCULATE2 error")
            Else
                TextBox1.Text += "Output: p1= " + p1.ToString("X") + ", " + _
                    "p2= " + p2.ToString("X") + ", " + _
                    "p3= " + p3.ToString("X") + ", " + _
                    "p4= " + p4.ToString("X") + ", " + vbCrLf + vbCrLf
            End If

        Next

    End Sub

    Private Sub btnCalc3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalc3.Click

        TextBox1.Text = ""

        Dim i As Integer
        Dim ret As UInt16
        Dim p1, p2, p3, p4 As UInt16
        Dim lp1, lp2 As UInt32
        Dim buffer(1000) As Byte

        For i = 0 To m_HandleNum - 1

            lp1 = Convert.ToUInt32(80) 'start position
            lp2 = Convert.ToUInt32(6) 'module No.
            p1 = Convert.ToUInt16(1)
            p2 = Convert.ToUInt16(2)
            p3 = Convert.ToUInt16(3)
            p4 = Convert.ToUInt16(4)

            TextBox1.Text += "Input: Arithmetic Start=" + lp1.ToString + ", " + _
                "Module Start=" + lp2.ToString + ", " + _
                "p1=" + p1.ToString("X") + ", " + _
                "p2=" + p2.ToString("X") + ", " + _
                "p3=" + p3.ToString("X") + ", " + _
                "p4=" + p4.ToString("X") + ", " + vbCrLf

            ret = r4nd.Rockey(RY_CALCULATE3, m_HIndex(i), lp1, lp2, p1, p2, p3, p4, buffer)
            If ret <> 0 Then
                MessageBox.Show("RY_CALCULATE3 error")
            Else
                TextBox1.Text += "Output: p1=" + p1.ToString("X") + ", " + _
                    "p2=" + p2.ToString("X") + ", " + _
                    "p3=" + p3.ToString("X") + ", " + _
                    "p4=" + p4.ToString("X") + ", " + vbCrLf
            End If

        Next

    End Sub

End Class
