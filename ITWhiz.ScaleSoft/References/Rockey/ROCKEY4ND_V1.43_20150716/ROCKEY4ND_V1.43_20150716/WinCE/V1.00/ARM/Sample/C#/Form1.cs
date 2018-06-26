using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;




namespace Sample
{
    enum Ry4Cmd : ushort
    {
        RY_FIND = 1,
        RY_FIND_NEXT,
        RY_OPEN,
        RY_CLOSE,
        RY_READ,
        RY_WRITE,
        RY_RANDOM,
        RY_SEED,
        RY_WRITE_USERID,
        RY_READ_USERID,
        RY_SET_MOUDLE,
        RY_CHECK_MOUDLE,
        RY_WRITE_ARITHMETIC,
        RY_CALCULATE1,
        RY_CALCULATE2,
        RY_CALCULATE3,
        RY_DECREASE
    };

    enum Ry4ErrCode : uint
    {
        ERR_SUCCESS = 0,
        ERR_NO_DRIVER,
        ERR_NO_ROCKEY,
        ERR_INVALID_PASSWORD,
        ERR_INVALID_PASSWORD_OR_ID,
        ERR_SETID,
        ERR_INVALID_ADDR_OR_SIZE,
        ERR_UNKNOWN_COMMAND,
        ERR_NOTBELEVEL3,
        ERR_READ,
        ERR_WRITE,
        ERR_RANDOM,
        ERR_SEED,
        ERR_CALCULATE,
        ERR_NO_OPEN,
        ERR_OPEN_OVERFLOW,
        ERR_NOMORE,
        ERR_NEED_FIND,
        ERR_DECREASE,
        ERR_AR_BADCOMMAND,
        ERR_AR_UNKNOWN_OPCODE,
        ERR_AR_WRONGBEGIN,
        ERR_AR_WRONG_END,
        ERR_AR_VALUEOVERFLOW,

        ERR_UNKNOWN = 0x8030ffff,

        ERR_RECEIVE_NULL = 0x80300100,
        ERR_PRNPORT_BUSY = 0x80300101

    };

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[1000];
            ushort handle = 0;

            ushort p1 = 0;
            ushort p2 = 0;
            ushort p3 = 0;
            ushort p4 = 0;
            uint lp1 = 0;
            uint lp2 = 0;

            int iMaxRockey = 0;
            uint[] uiarrRy4ID = new uint[32];
            uint iCurrID;
            string strRet;

            p1 = 0xc44c; p2 = 0xc8f8; p3 = 0x0799; p4 = 0xc43b;

            listBox.Items.Clear();
            ushort ret = Rockey4ND.Rockey((ushort)Ry4Cmd.RY_FIND, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
            if (ret!=0)
            {
                strRet = string.Format("Not find any rockey,ret:{0}.", ret);
                listBox.Items.Add(strRet);
                return;
            }
            uiarrRy4ID[iMaxRockey] = lp1;
            iMaxRockey++;

            ushort flag = 0;
            while (flag == 0)
            {
                flag = Rockey4ND.Rockey((ushort)Ry4Cmd.RY_FIND_NEXT, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);

                if (flag == 0)
                {
                    uiarrRy4ID[iMaxRockey] = lp1;
                    iMaxRockey++;
                }

            }

            strRet = "Found " + iMaxRockey + " Rockey4ND(s)";
            listBox.Items.Add(strRet);

            for (int i = 0; i < iMaxRockey; i++)
            {

                strRet = string.Format("({0}): {1:X8}", i + 1, uiarrRy4ID[i]);
                listBox.Items.Add(strRet);

            }




            iCurrID = uiarrRy4ID[0];
            for (int n = 0; n < iMaxRockey; n++)
            {
                lp1 = uiarrRy4ID[n];
                p1 = 0xc44c; p2 = 0xc8f8; p3 = 0x0799; p4 = 0xc43b;

                ret=Rockey4ND.Rockey((ushort)Ry4Cmd.RY_OPEN, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
                if (ret != 0)
                {
                    strRet = string.Format("Open rockey failed,ret:{0}.", ret);
                    listBox.Items.Add(strRet);
                    return;
                }

                for (int i = 0; i < 20; i++) buffer[i] = (byte)i;

                listBox.Items.Add((string)("Writting 20 bytes to user data zone..."));

                p1 = 0; p2 = 20;
                Rockey4ND.Rockey((ushort)Ry4Cmd.RY_WRITE, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);

                strRet = string.Format("Reading 20 bytes from user data zone...");

                p1 = 0; p2 = 20;
                Rockey4ND.Rockey((ushort)Ry4Cmd.RY_READ, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
                listBox.Items.Add(strRet);

                ushort[] usRandom = new ushort[4];
                strRet = string.Format("Generating 8 bytes random...");

                for (int i = 0; i < 4; i++)
                {
                    Rockey4ND.Rockey((ushort)Ry4Cmd.RY_RANDOM, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
                    usRandom[i] = p1;
                }

                foreach (ushort i in usRandom)
                {
                    strRet += string.Format("{0:X4} ", i); 
                }

                listBox.Items.Add(strRet);
                //Demo7:Generate seed code. lp2 is seed.
                strRet = string.Format("Generating seed code, seed=0x12345678...");
                listBox.Items.Add(strRet);
                lp2 = 0x12345678;
                Rockey4ND.Rockey((ushort)Ry4Cmd.RY_SEED, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);

                strRet = string.Format("seed code is {0:X4} {1:X2} {2:X4} {3:X4}", p1, p2, p3, p4);
                listBox.Items.Add(strRet);
                //Demo8:Write UID to 0x19303A78.
                strRet = string.Format("Writting user ID    ID=0x55667788...");
                listBox.Items.Add(strRet);
                lp1 = 0x55667788;
                Rockey4ND.Rockey((ushort)Ry4Cmd.RY_WRITE_USERID, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
                lp1 = 0;

                //Demo9: Read UID.
                strRet = string.Format("Reading user ID    ");
                Rockey4ND.Rockey((ushort)Ry4Cmd.RY_READ_USERID, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
                //listBox.Items.Add(strRet);
                strRet += string.Format("User ID is {0:X8}", lp1);
                listBox.Items.Add(strRet);
                //Demo10:Set module 0x08, number is 3, can be decreased.
                strRet = string.Format("Setting module 8, number is 3, can be decreased...");
                listBox.Items.Add(strRet);
                p1 = 8; p2 = 3; p3 = 1;
                Rockey4ND.Rockey((ushort)Ry4Cmd.RY_SET_MOUDLE, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);

                //Demo11:Check module. p1=module index
                strRet = string.Format("Checking module 8...");
                listBox.Items.Add(strRet);
                p1 = 8;
                Rockey4ND.Rockey((ushort)Ry4Cmd.RY_CHECK_MOUDLE, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);

                strRet = string.Format("bValidate={0}, bDecreasable={1}", p2, p3);
                listBox.Items.Add(strRet);
                //Demo12: Decrease. p1=module index.
                for (int i = 0; i < 3; i++)
                {
                    p1 = 8;

                    strRet = string.Format((string)("Module 8,Decrease {0}... "), i);
                    listBox.Items.Add(strRet);
                    Rockey4ND.Rockey((ushort)Ry4Cmd.RY_DECREASE, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);

                    //Check module status
                    p1 = 8;
                    Rockey4ND.Rockey((ushort)Ry4Cmd.RY_CHECK_MOUDLE, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);


                    strRet = string.Format("bValidate={0}, bDecreasable={1}", p2, p3);
                    listBox.Items.Add(strRet);
                }

                //Demo13:Write arithmetic to UAZ,

                string csArith = "A=A+B,C=C+D,B=E+F,D=G+H";

                strRet = string.Format("Writting arithmetic to UAZ,{0}", csArith);
                listBox.Items.Add(strRet);
                p1 = 0;
                int nArith = 0;
                while (nArith < csArith.Length)
                {
                    buffer[nArith] = (byte)(csArith[nArith]);
                    nArith++;
                }
                buffer[nArith] = 0;
                Rockey4ND.Rockey((ushort)Ry4Cmd.RY_WRITE_ARITHMETIC, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);



                //Demo14,Calculate 1
                strRet = "Calculate 1,A=1,B=2,C=3,D=4...";
                listBox.Items.Add(strRet);
                lp1 = 0; lp2 = 8; p1 = 1; p2 = 2; p3 = 3; p4 = 4;
                Rockey4ND.Rockey((ushort)Ry4Cmd.RY_CALCULATE1, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);

                strRet = string.Format("result: A={0:X4},B={1:X4},C={2:X4},D={3:X4}", p1, p2, p3, p4);
                listBox.Items.Add(strRet);

                strRet = "Calculate 2,A=1,B=2,C=3,D=4...";
                listBox.Items.Add(strRet);

                lp1 = 0; lp2 = 0x19303A09; p1 = 1; p2 = 2; p3 = 3; p4 = 4;
                Rockey4ND.Rockey((ushort)Ry4Cmd.RY_CALCULATE2, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);

                strRet = string.Format("result: A={0:X4},B={1:X4},C={2:X4},D={3:X4}", p1, p2, p3, p4);
                listBox.Items.Add(strRet);
                //Demo16,Calculate 3
                strRet = "Calculate 3,A=1,B=2,C=3,D=4...";
                listBox.Items.Add(strRet);

                lp1 = 0; lp2 = 8; p1 = 1; p2 = 2; p3 = 3; p4 = 4;
                Rockey4ND.Rockey((ushort)Ry4Cmd.RY_CALCULATE3, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);

                strRet = string.Format("result: A={0:X4},B={1:X4},C={2:X4},D={3:X4}", p1, p2, p3, p4);
                listBox.Items.Add(strRet);
                //Demo17,Close.
                strRet = string.Format("Closing handle {0:X4}...", handle);
                listBox.Items.Add(strRet);
                Rockey4ND.Rockey((ushort)Ry4Cmd.RY_CLOSE, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);

                strRet = string.Format("[OK]");
                listBox.Items.Add(strRet);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}