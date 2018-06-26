using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NetRockey4NDCom;

namespace UseCom
{
    enum Ry4Cmd : ushort
    {
        RY_FIND = 1,			//Find NetRockey4ND
        RY_FIND_NEXT,		//Find next
        RY_OPEN,			//Open NetRockey4ND
        RY_CLOSE,			//Close NetRockey4ND
        RY_READ,			//Read NetRockey4ND
        RY_WRITE,			//Write NetRockey4ND
        RY_RANDOM,			//Generate random
        RY_SEED,			//Generate seed
        RY_READ_USERID = 10,	//Read UID
        RY_CHECK_MODULE = 12,	//Check Module
        RY_CALCULATE1 = 14,	//Calculate1
        RY_CALCULATE2,		//Calculate1
        RY_CALCULATE3,		//Calculate1
    };

    enum Ry4ErrCode : uint
    {
        ERR_SUCCESS = 0,							//No error
        ERR_NO_PARALLEL_PORT = 0x80300001,		//(0x80300001)No parallel port
        ERR_NO_DRIVER,							//(0x80300002)No drive
        ERR_NO_ROCKEY,							//(0x80300003)No NetRockey4ND
        ERR_INVALID_PASSWORD,					//(0x80300004)Invalid password
        ERR_INVALID_PASSWORD_OR_ID,				//(0x80300005)Invalid password or ID
        ERR_SETID,								//(0x80300006)Set id error
        ERR_INVALID_ADDR_OR_SIZE,				//(0x80300007)Invalid address or size
        ERR_UNKNOWN_COMMAND,					//(0x80300008)Unkown command
        ERR_NOTBELEVEL3,						//(0x80300009)Inner error
        ERR_READ,								//(0x8030000A)Read error
        ERR_WRITE,								//(0x8030000B)Write error
        ERR_RANDOM,								//(0x8030000C)Generate random error
        ERR_SEED,								//(0x8030000D)Generate seed error
        ERR_CALCULATE,							//(0x8030000E)Calculate error
        ERR_NO_OPEN,							//(0x8030000F)The NetRockey4ND is not opened
        ERR_OPEN_OVERFLOW,						//(0x80300010)Open NetRockey4ND too more(>16)
        ERR_NOMORE,								//(0x80300011)No more NetRockey4ND
        ERR_NEED_FIND,							//(0x80300012)Need Find before FindNext
        ERR_DECREASE,							//(0x80300013)Dcrease error
        ERR_AR_BADCOMMAND,						//(0x80300014)Band command
        ERR_AR_UNKNOWN_OPCODE,					//(0x80300015)Unkown op code
        ERR_AR_WRONGBEGIN,						//(0x80300016)There could not be constant in first instruction in arithmetic 
        ERR_AR_WRONG_END,						//(0x80300017)There could not be constant in last instruction in arithmetic 
        ERR_AR_VALUEOVERFLOW,					//(0x80300018)The constant in arithmetic overflow
        ERR_UNKNOWN = 0x8030ffff,					//(0x8030FFFF)Unkown error

        ERR_RECEIVE_NULL = 0x80300100,			//(0x80300100)Receive null
        ERR_PRNPORT_BUSY = 0x80300101				//(0x80300101)Parallel port busy

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
            object obbuffer = new object();
            ushort handle = 0;
            ushort function = 0;
            ushort p1 = 0;
            ushort p2 = 0;
            ushort p3 = 0;
            ushort p4 = 0;
            uint lp1 = 0;
            uint lp2 = 0;

            int iMaxRockey = 0;
            uint[] uiarrRy4ID = new uint[32];
            uint iCurrID;


            p1 = 0xc44c; p2 = 0xc8f8; p3 = 0; p4 = 0;
            CCNetRockey4ND NetR4ND = new CCNetRockey4ND();
            obbuffer = (object)buffer;
            ulong ret = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_FIND, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);//Find NetRockey4ND

            string strRet;
            listBox.Items.Clear();
            if (0 != ret)
            {
                strRet = string.Format("No Rockey Found! Error code:{0}", ret);
                listBox.Items.Add(strRet);
                return;
            }
            uiarrRy4ID[iMaxRockey] = lp1;
            iMaxRockey++;

            ulong flag = 0;
            while (flag == 0)
            {//Find next NetRockey4ND
                flag = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_FIND_NEXT, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);

                if (flag == 0)
                {
                    uiarrRy4ID[iMaxRockey] = lp1;
                    iMaxRockey++;
                }

            }

            strRet = "Found " + iMaxRockey + " NetRockey4ND";
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
                lp2 = 0;
                //Open NetRockey4ND
                ret = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_OPEN, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);

                if (0 != ret)
                {
                    strRet = string.Format("Open Rockey failed! Error code:{0}", ret);
                    listBox.Items.Add(strRet);
                    return;
                }


                //write NetRockey4ND
                for (int i = 0; i < 20; i++) buffer[i] = (byte)i;
                obbuffer = (object)buffer;

                listBox.Items.Add((string)("Writting 20 bytes to user data zone..."));

                p1 = 0; p2 = 20;
                ret = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_WRITE, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);
                if (0 != ret)
                {
                    strRet = string.Format("Write Rockey failed! Error code:{0}", ret);
                    listBox.Items.Add(strRet);
                    return;
                }

                //Read NetRockey4ND
                strRet = string.Format("Reading 20 bytes from user data zone...");
                listBox.Items.Add(strRet);

                p1 = 0; p2 = 20;
                ret = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_READ, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);
                if (0 != ret)
                {
                    strRet = string.Format("Read Rockey failed! Error code:{0}", ret);
                    listBox.Items.Add(strRet);
                    return;
                }
                listBox.Items.Add(strRet);

                //Generate random
                ushort[] usRandom = new ushort[4];
                strRet = string.Format("Generating 8 bytes random...");

                for (int i = 0; i < 4; i++)
                {
                    ret = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_RANDOM, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);
                    if (0 != ret)
                    {
                        strRet = string.Format("Build Random failed! Error code:{0}", ret);
                        listBox.Items.Add(strRet);
                        return;
                    }
                    usRandom[i] = p1;
                }

                foreach (ushort i in usRandom)
                {
                    strRet += string.Format("{0:X4} ", i);
                }

                listBox.Items.Add(strRet);


                //Generate seed code. lp2 is seed.

                strRet = string.Format("Generating seed code, seed=0x12345678...");
                listBox.Items.Add(strRet);
                lp2 = 0x12345678;
                ret = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_SEED, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);
                if (0 != ret)
                {
                    strRet = string.Format("Generate seed failed! Error code:{0}", ret);
                    listBox.Items.Add(strRet);
                    return;
                }

                strRet = string.Format("seed code is {0:X4} {1:X2} {2:X4} {3:X4}", p1, p2, p3, p4);
                listBox.Items.Add(strRet);

                // Read UID.
                strRet = string.Format("Reading user ID    ");
                ret = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_READ_USERID, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);
                if (0 != ret)
                {
                    strRet = string.Format("Read UID failed! Error code:{0}", ret);
                    listBox.Items.Add(strRet);
                    return;
                }
                strRet += string.Format("User ID is {0:X8}", lp1);
                listBox.Items.Add(strRet);

                //Check module. p1=module index
                strRet = string.Format("Checking module 8...");
                listBox.Items.Add(strRet);
                p1 = 8;
                ret = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_CHECK_MODULE, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);
                if (0 != ret)
                {
                    strRet = string.Format("Check module failed! Error code:{0}", ret);
                    listBox.Items.Add(strRet);
                    return;
                }

                strRet = string.Format("bValidate={0}, bDecreasable={1}", p2, p3);
                listBox.Items.Add(strRet);


                //Calculate 1
                strRet = "Calculate 1,A=1,B=2,C=3,D=4...";
                listBox.Items.Add(strRet);
                lp1 = 0; lp2 = 8; p1 = 1; p2 = 2; p3 = 3; p4 = 4;
                ret = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_CALCULATE1, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);
                if (0 != ret)
                {
                    strRet = string.Format("Calcullate1 failed! Error code:{0}", ret);
                    listBox.Items.Add(strRet);
                    return;
                }

                strRet = string.Format("result: A={0:X4},B={1:X4},C={2:X4},D={3:X4}", p1, p2, p3, p4);
                listBox.Items.Add(strRet);

                strRet = "Calculate 2,Seed=0x12345678,A=1,B=2,C=3,D=4...";
                listBox.Items.Add(strRet);

                //Calculate 2
                lp1 = 0; lp2 = 0x12345678; p1 = 1; p2 = 2; p3 = 3; p4 = 4;
                ret = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_CALCULATE2, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);
                if (0 != ret)
                {
                    strRet = string.Format("Calcullate2 failed! Error code:{0}", ret);
                    listBox.Items.Add(strRet);
                    return;
                }

                strRet = string.Format("result: A={0:X4},B={1:X4},C={2:X4},D={3:X4}", p1, p2, p3, p4);
                listBox.Items.Add(strRet);

                //Calculate 3
                strRet = "Calculate 3,A=1,B=2,C=3,D=4...";
                listBox.Items.Add(strRet);

                lp1 = 0; lp2 = 8; p1 = 1; p2 = 2; p3 = 3; p4 = 4;
                ret = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_CALCULATE3, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);
                if (0 != ret)
                {
                    strRet = string.Format("Calcullate3 failed! Error code:{0}", ret);
                    listBox.Items.Add(strRet);
                    return;
                }

                strRet = string.Format("result: A={0:X4},B={1:X4},C={2:X4},D={3:X4}", p1, p2, p3, p4);
                listBox.Items.Add(strRet);

                //Close NetRockey4ND
                strRet = string.Format("Closing handle {0:X4}...", handle);
                listBox.Items.Add(strRet);
                ret = NetR4ND.NetRockey((ushort)Ry4Cmd.RY_CLOSE, ref handle, ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, ref obbuffer);

                strRet = string.Format("[OK]");
                listBox.Items.Add(strRet);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose(true);
        }
    }
}