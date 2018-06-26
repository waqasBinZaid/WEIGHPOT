Module Module1
    Enum Ry4CMD As Short
        RY_FIND = 1             '/Find NetRockey4ND
        RY_FIND_NEXT            'Find next
        RY_OPEN                 'Open NetRockey4ND
        RY_CLOSE                'Close NetRockey4ND
        RY_READ                 'Read NetRockey4ND
        RY_WRITE                'Write NetRockey4ND
        RY_RANDOM               'Generate random
        RY_SEED                 'Generate seed
        RY_READ_USERID = 10     'Read UID
        RY_CHECK_MODULE = 12    'Check Module
        RY_CALCULATE1 = 14      'Calculate1
        RY_CALCULATE2           'Calculate1
        RY_CALCULATE3           'Calculate1
    End Enum

    Enum Ry4ErrCode As Integer
        ERR_SUCCESS = 0                         'No error
        ERR_NO_PARALLEL_PORT = &H80300001       'No parallel port.
        ERR_NO_DRIVER                           '(0x80300002)No drive
        ERR_NO_ROCKEY                           '(0x80300003)No NetRockey4ND
        ERR_INVALID_PASSWORD                    '(0x80300004)Invalid password
        ERR_INVALID_PASSWORD_OR_ID              '(0x80300005)Invalid password or ID
        ERR_SETID                               '(0x80300006)Set id error
        ERR_INVALID_ADDR_OR_SIZE                '(0x80300007)Invalid address or size
        ERR_UNKNOWN_COMMAND                     '(0x80300008)Unkown command
        ERR_NOTBELEVEL3                         '(0x80300009)Inner error
        ERR_READ                                '(0x8030000A)Read error
        ERR_WRITE                               '(0x8030000B)Write error
        ERR_RANDOM                              '(0x8030000C)Generate random error
        ERR_SEED '								//(0x8030000D)Generate seed error
        ERR_CALCULATE '							//(0x8030000E)Calculate error
        ERR_NO_OPEN '							//(0x8030000F)The NetRockey4ND is not opened
        ERR_OPEN_OVERFLOW '						//(0x80300010)Open NetRockey4ND too more(>16)
        ERR_NOMORE '							//(0x80300011)No more NetRockey4ND
        ERR_NEED_FIND '							//(0x80300012)Need Find before FindNext
        ERR_DECREASE '							//(0x80300013)Dcrease error
        ERR_AR_BADCOMMAND '						//(0x80300014)Band command

        ERR_AR_UNKNOWN_OPCODE '					//(0x80300015)Unkown op code
        ERR_AR_WRONGBEGIN '						//(0x80300016)There could not be constant in first instruction in arithmetic 
        ERR_AR_WRONG_END '						//(0x80300017)There could not be constant in last instruction in arithmetic 
        ERR_AR_VALUEOVERFLOW '					//(0x80300018)The constant in arithmetic overflow
        ERR_UNKNOWN = &H8030FFFF                '(0x8030FFFF)Unkown error.
        ERR_RECEIVE_NULL = &H80300100           '(0x80300100)Receive null.
        ERR_PRNPORT_BUSY = &H80300101           '(0x80300101)Parallel port busy.
    End Enum
    Sub Main()
        Dim FuncID As UInt16            'Function ID
        Dim handle As UInt16            'Handle
        Dim Lp1, Lp2 As UInt32          'Long parameters
        Dim p1, p2, p3, p4 As UInt16    'Short parameters
        Dim Buf(1024) As Byte

        Dim Class1 As New NetRockey4NDCom.CCNetRockey4ND




        'record found Rockey4(s).
        Dim iMaxRockey As Integer = 0
        Dim uiarrRy4ID(32) As UInt32
        Dim iCurrID As UInt32
        Dim iRet As System.UInt32

        FuncID = Convert.ToUInt16(Ry4CMD.RY_FIND)
        p1 = Convert.ToUInt16(&HC44C)
        p2 = Convert.ToUInt16(&HC8F8)
        p3 = Convert.ToUInt16(&H799)
        p4 = Convert.ToUInt16(&HC43B)

        iRet = Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)

        If Convert.ToInt32(iRet) <> 0 Then
            Console.WriteLine("No Rockey Found! Error code:{0:X}", iRet)
            Return
        End If

        Console.WriteLine("Rockey One Found!")
        uiarrRy4ID(iMaxRockey) = Lp1
        iMaxRockey = iMaxRockey + 1

        Console.WriteLine("({0}) {1:X} ", iMaxRockey, Lp1)
        Dim iflag As Integer
        iflag = 0
        While iflag = 0
            FuncID = Convert.ToUInt16(Ry4CMD.RY_FIND_NEXT)
            Buf(0) = 0
            iRet = Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)
            iflag = Convert.ToInt32(iRet)
            If (iflag = 0) Then
                uiarrRy4ID(iMaxRockey) = Lp1
                iMaxRockey = iMaxRockey + 1
                Console.WriteLine("({0}) {1:X} ", iMaxRockey, Lp1)
            End If
        End While

        If (iMaxRockey > 1) Then
            Console.WriteLine("Please input the index to open.(>=0,<{0})", iMaxRockey)
            iCurrID = uiarrRy4ID(Convert.ToInt32(Console.ReadLine()))
        Else
            iCurrID = uiarrRy4ID(Convert.ToInt32(0))
        End If

        'Demo3: Open. LP1 is Ry4ID, LP2 is Module number.
        FuncID = Convert.ToUInt16(Ry4CMD.RY_OPEN)
        Lp1 = iCurrID
        Lp2 = 0
        p1 = Convert.ToUInt16(&HC44C)
        p2 = Convert.ToUInt16(&HC8F8)
        p3 = Convert.ToUInt16(&H799)
        p4 = Convert.ToUInt16(&HC43B)

        iRet = Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)
        If Convert.ToInt32(iRet) <> 0 Then
            Console.WriteLine("Open Rockey failed! Error code:{0}", iRet)
            Return
        End If

        'opened succeeded. handle ID in handle, type information in lp2.
        Dim rType As Integer = Convert.ToInt32(Lp2)
        Console.WriteLine("Opened,handle is {0:X4},type is {1}", handle, rType.ToString)
        'Demo4: Write 24 bytes to UDZ. p1=index of first address, p2=length,obBuffer=data,in byte array..
        Dim byWriteData(24) As Byte
        Dim i As Byte
        For i = 0 To 23
            byWriteData(i) = i
        Next
        Console.Write("Writting 24 bytes to user data zone...")
        FuncID = Convert.ToUInt16(Ry4CMD.RY_WRITE)
        p1 = Convert.ToUInt16(0)
        p2 = Convert.ToUInt16(24)       '24 bytes
        Buf = byWriteData               'Set buf to byte array. you can also set it to a string.

        Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)
        Console.WriteLine("[OK]")
        'Demo5: Read UDZ Zone, 24 bytes.
        Console.WriteLine("Reading 24 bytes from user data zone...")
        FuncID = Convert.ToUInt16(Ry4CMD.RY_READ)
        p1 = Convert.ToUInt16(0)
        p2 = Convert.ToUInt16(24)       '24 bytes
        '            Buf = 0                         'no input data
        Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)

        Dim byReadData() As Byte = Buf

        For i = 0 To 23
            Console.Write("{0:X2} ", byReadData(i))
        Next

        Console.WriteLine("[OK]")

        'Demo6: Generate 4 random number.

        Dim usRandom(4) As UInt16

        Console.WriteLine("Generating 8 bytes random...")

        For i = 0 To 3
            FuncID = Convert.ToUInt16(Ry4CMD.RY_RANDOM)
            '                Buf = 0                         'no input data
            Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)
            usRandom(i) = p1        'Random in p1.
        Next

        ' Print result to screen
        For i = 0 To 3
            Console.Write("{0:X4} ", usRandom(i))
        Next

        Console.WriteLine("[OK]")

        'Demo7: Generate seed code. lp2 is seed.
        Console.WriteLine("Generating seed code, seed=0x193F4701...")

        FuncID = Convert.ToUInt16(Ry4CMD.RY_SEED)
        Lp2 = Convert.ToUInt32(&H193F4701)              'a 32 bit seed
        Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)

        Console.WriteLine("[OK], seed code is {0:X4} {1:X2} {2:X4} {3:X4}", p1, p2, p3, p4)
        'Demo9: Read UID.
        Console.WriteLine("Reading user ID...")

        FuncID = Convert.ToUInt16(Ry4CMD.RY_READ_USERID)
        Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)

        ' UID in lp1
        Console.WriteLine("[OK],User ID is {0:X8}", Lp1)

        'Demo11:Check module. p1=module index
        Console.WriteLine("Checking module 8...")

        FuncID = Convert.ToUInt16(Ry4CMD.RY_CHECK_MODULE)
        p1 = Convert.ToUInt16(8)
        Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)

        Console.WriteLine("[OK], bValidate={0}, bDecreasable={1}", p2, p3)

        'Demo14,Calculate 1
        Console.Write("Calculate 1 ...")

        FuncID = Convert.ToUInt16(Ry4CMD.RY_CALCULATE1)

        'Set parameters
        Lp1 = Convert.ToUInt32(0)
        Lp2 = Convert.ToUInt32(8)

        p1 = Convert.ToUInt16(1)
        p2 = Convert.ToUInt16(2)
        p3 = Convert.ToUInt16(3)
        p4 = Convert.ToUInt16(4)

        Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)

        'print result to screen.
        Console.WriteLine("[OK],result: A={0:X4},B={1:X4},C={2:X4},D={3:X4}", p1, p2, p3, p4)


        'Demo15,Calculate 2
        Console.Write("Calculate 2 ...")

        FuncID = Convert.ToUInt16(Ry4CMD.RY_CALCULATE2)

        'Set parameters
        Lp1 = Convert.ToUInt32(0)
        Lp2 = Convert.ToUInt32(&H19303A09)

        p1 = Convert.ToUInt16(1)
        p2 = Convert.ToUInt16(2)
        p3 = Convert.ToUInt16(3)
        p4 = Convert.ToUInt16(4)

        Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)

        'print result to screen.
        Console.WriteLine("[OK],result: A={0:X4},B={1:X4},C={2:X4},D={3:X4}", p1, p2, p3, p4)

        'Demo16,Calculate 3
        Console.Write("Calculate 3 ...")

        FuncID = Convert.ToUInt16(Ry4CMD.RY_CALCULATE3)

        'Set parameters
        Lp1 = Convert.ToUInt32(0)
        Lp2 = Convert.ToUInt32(8)

        p1 = Convert.ToUInt16(1)
        p2 = Convert.ToUInt16(2)
        p3 = Convert.ToUInt16(3)
        p4 = Convert.ToUInt16(4)

        Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)

        'print result to screen.
        Console.WriteLine("[OK],result: A={0:X4},B={1:X4},C={2:X4},D={3:X4}", p1, p2, p3, p4)

        'Demo17,Close.           
        Console.Write("Closing handle {0:X}...", handle)

        FuncID = Convert.ToUInt16(Ry4CMD.RY_CLOSE)
        '            Buf = 0
        Class1.NetRockey(FuncID, handle, Lp1, Lp2, p1, p2, p3, p4, Buf)

        Console.WriteLine("[OK]")

        'Press any key to exit.
        Console.ReadLine()

    End Sub

End Module
