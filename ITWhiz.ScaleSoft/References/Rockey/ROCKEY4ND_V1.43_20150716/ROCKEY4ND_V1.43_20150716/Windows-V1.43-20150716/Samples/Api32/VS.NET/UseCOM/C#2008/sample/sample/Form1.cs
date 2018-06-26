using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        const int RY_FIND = 1;
        const int RY_FIND_NEXT = 2;
        const int RY_OPEN = 3;
        const int RY_CLOSE = 4;
        const int RY_READ = 5;
        const int RY_WRITE = 6;
        const int RY_RANDOM = 7;
        const int RY_SEED = 8;
        const int RY_WRITE_USERID = 9;
        const int RY_READ_USERID = 10;
        const int RY_SET_MOUDLE = 11;
        const int RY_CHECK_MOUDLE = 12;
        const int RY_WRITE_ARITHMETIC = 13;
        const int RY_CALCULATE1 = 14;
        const int RY_CALCULATE2 = 15;
        const int RY_CALCULATE3 = 16;
        const int RY_DECREASE = 17;

        CRockey4ND.CCRockey4ND com = new CRockey4ND.CCRockey4ND();
        int[] m_Handle = new int[32];
        int m_HandleNum = 0;

        private void btnOpenAll_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            int ret;

            com.p1 = 0xC44C;
            com.p2 = 0xC8F8;
            com.p3 = 0x799;
            com.p4 = 0xC43B;

            ret = com.RockeyCM(RY_FIND);
            if (ret != 0)
            {
                MessageBox.Show("RY_FIND error");
                return;
            }
            else
            {
                TextBox1.Text = "HID: " + com.lp1.ToString("X") + "\r\n";
            }
            ret = com.RockeyCM(RY_OPEN);
            if (ret != 0)
            {
                MessageBox.Show("RY_OPEN error");
                return;
            }

            m_Handle[0] = com.handle;
            m_HandleNum = 1;

            while (ret == 0)
            {
                ret = com.RockeyCM(RY_FIND_NEXT);
                if (ret != 0)
                {
                    break;
                }
                else
                {
                    TextBox1.Text += "HID: " + com.lp1.ToString("X") + "\r\n";
                }
                ret = com.RockeyCM(RY_OPEN);
                if (ret != 0)
                {
                    break;
                }

                m_Handle[m_HandleNum] = com.handle;
                m_HandleNum = m_HandleNum + 1;
            }
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            for (i = 0; i < m_HandleNum; i++)
            {
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_CLOSE);
                if (ret != 0)
                {
                    MessageBox.Show("RY_CLOSE error");
                }
            }
        }

        private void btnWriteMemory_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            String str1 = "how do you turn this on";

            for (i = 0; i < m_HandleNum; i++)
            {
                com.buffer = str1;
                com.p1 = 0; //offset
                com.p2 = 100; //length
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_WRITE);
                if (ret != 0)
                {
                    MessageBox.Show("RY_WRITE error");
                }
                else
                {
                    TextBox1.Text += "Write a String, offset = " + com.p1.ToString() + ", length = " + com.p2.ToString() + ", >" + str1 + "\r\n";
                }
            }
        }

        private void btnReadMomory_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            String[] str1 = new String[m_HandleNum];

            for (i = 0; i < m_HandleNum; i++)
            {
                com.p1 = 0; //offset
                com.p2 = 100; //length
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_READ);
                if (ret != 0)
                {
                    MessageBox.Show("RY_READ error");
                }
                else
                {
                    str1[i] = com.buffer;
                    TextBox1.Text += "Read a String, offset = " + com.p1.ToString() + ", length = " + com.p2.ToString() + ", >" + str1[i] + "\r\n";
                }
            }
        }

        private void btnWriteModule_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            for (i = 0; i < m_HandleNum; i++)
            {
                com.p1 = 63; //Module Index
                com.p2 = 5;  //Set Value
                com.p3 = 1;  //allow decrease, 0 or 1
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_SET_MOUDLE);
                if (ret != 0)
                {
                    MessageBox.Show("RY_SET_MOUDLE error");
                }
                else
                {
                    TextBox1.Text += "Write Module: Module No. is " + com.p1.ToString() +
                        ", Value is " + com.p2.ToString() + ", Allow Decrease is " + com.p3.ToString() + "\r\n";
                }
            }
        }

        private void btnReadModule_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            for (i = 0; i < m_HandleNum; i++)
            {
                com.p1 = 63; //Module Index
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_CHECK_MOUDLE);
                if (ret != 0)
                {
                    MessageBox.Show("RY_CHECK_MOUDLE error");
                }
                else
                {
                    TextBox1.Text += "Read Module: Module No. is " + com.p1.ToString() +
                        ", Enable is " + com.p2.ToString() + ", Allow Decrease is " + com.p3.ToString() + "\r\n";
                }
            }
        }

        private void btnDecModule_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            for (i = 0; i < m_HandleNum; i++)
            {
                com.p1 = 63; //Module Index
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_DECREASE);
                if (ret != 0)
                {
                    MessageBox.Show("RY_DECREASE error");
                }
                else
                {
                    TextBox1.Text += "Decrease Module value: Module No. is " + com.p1.ToString() +
                        ", Decreased" + "\r\n";
                }
            }
        }

        private void btnWriteUserID_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            for (i = 0; i < m_HandleNum; i++)
            {
                com.lp1 = 0x12345678;
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_WRITE_USERID);
                if (ret != 0)
                {
                    MessageBox.Show("RY_WRITE_USERID error");
                }
                else
                {
                    TextBox1.Text += "Write User ID to Dongle: " + com.lp1.ToString("X") + "\r\n";
                }
            }
        }

        private void btnReadUserID_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            for (i = 0; i < m_HandleNum; i++)
            {
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_READ_USERID);
                if (ret != 0)
                {
                    MessageBox.Show("RY_READ_USERID error");
                }
                else
                {
                    TextBox1.Text += "Read User ID from Dongle: " + com.lp1.ToString("X") + "\r\n";
                }
            }
        }

        private void btnWriteArith_Click(object sender, System.EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            String str1 = "H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D";
            String str2 = "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H";
            String str3 = "A=E|E, B=F|F, C=G|G, D=H|H";

            for (i = 0; i < m_HandleNum; i++)
            {
                //arithmetic 1
                com.p1 = 0; //start position
                com.buffer = str1;
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_WRITE_ARITHMETIC);
                if (ret != 0)
                {
                    MessageBox.Show("RY_WRITE_ARITHMETIC error");
                }
                else
                {
                    TextBox1.Text += "Start Position: " + com.p1.ToString() + ", " + str1 + "\r\n";
                }

                //arithmetic 2
                com.p1 = 40; //start position
                com.buffer = str2;
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_WRITE_ARITHMETIC);
                if (ret != 0)
                {
                    MessageBox.Show("RY_WRITE_ARITHMETIC error");
                }
                else
                {
                    TextBox1.Text += "Start Position: " + com.p1.ToString() + ", " + str2 + "\r\n";
                }

                //arithmetic 3
                com.p1 = 80; //start position
                com.buffer = str3;
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_WRITE_ARITHMETIC);
                if (ret != 0)
                {
                    MessageBox.Show("RY_WRITE_ARITHMETIC error");
                }
                else
                {
                    TextBox1.Text += "Start Position: " + com.p1.ToString() + ", " + str3 + "\r\n" + "\r\n";
                }
            }
        }

        private void btnCalc1_Click(object sender, System.EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            for (i = 0; i < m_HandleNum; i++)
            {
                com.lp1 = 0; //start position
                com.lp2 = 7; //module No.
                com.p1 = 5;
                com.p2 = 3;
                com.p3 = 1;
                com.p4 = 0xFFFF;

                TextBox1.Text += "Input: Start=" + com.lp1.ToString() + ", " +
                    "Module=" + com.lp2.ToString() + ", " +
                    "p1=" + com.p1.ToString("X") + ", " +
                    "p2=" + com.p2.ToString("X") + ", " +
                    "p3=" + com.p3.ToString("X") + ", " +
                    "p4=" + com.p4.ToString("X") + ", " + "\r\n";

                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_CALCULATE1);
                if (ret != 0)
                {
                    MessageBox.Show("RY_CALCULATE1 error");
                }
                else
                {
                    TextBox1.Text += "Output: p1= " + com.p1.ToString("X") + ", " +
                        "p2= " + com.p2.ToString("X") + ", " +
                        "p3= " + com.p3.ToString("X") + ", " +
                        "p4= " + com.p4.ToString("X") + ", " + "\r\n" + "\r\n";
                }

            }
        }

        private void btnCalc2_Click(object sender, System.EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            for (i = 0; i < m_HandleNum; i++)
            {
                com.lp1 = 40; //start position
                com.lp2 = 0x12345678; //module No.
                com.p1 = 1;
                com.p2 = 2;
                com.p3 = 3;
                com.p4 = 4;

                TextBox1.Text += "Input: Start=" + com.lp1.ToString() + ", " +
                    "Seed=" + com.lp2.ToString("X") + ", " +
                    "p1=" + com.p1.ToString("X") + ", " +
                    "p2=" + com.p2.ToString("X") + ", " +
                    "p3=" + com.p3.ToString("X") + ", " +
                    "p4=" + com.p4.ToString("X") + ", " + "\r\n";

                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_CALCULATE2);
                if (ret != 0)
                {
                    MessageBox.Show("RY_CALCULATE2 error");
                }
                else
                {
                    TextBox1.Text += "Output: p1= " + com.p1.ToString("X") + ", " +
                        "p2= " + com.p2.ToString("X") + ", " +
                        "p3= " + com.p3.ToString("X") + ", " +
                        "p4= " + com.p4.ToString("X") + ", " + "\r\n" + "\r\n";
                }
            }
        }

        private void btnCalc3_Click(object sender, System.EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            for (i = 0; i < m_HandleNum; i++)
            {
                com.lp1 = 80; //start position
                com.lp2 = 6; //module No.
                com.p1 = 1;
                com.p2 = 2;
                com.p3 = 3;
                com.p4 = 4;

                TextBox1.Text += "Input: Arithmetic Start=" + com.lp1.ToString() + ", " +
                    "Module Start=" + com.lp2.ToString() + ", " +
                    "p1=" + com.p1.ToString("X") + ", " +
                    "p2=" + com.p2.ToString("X") + ", " +
                    "p3=" + com.p3.ToString("X") + ", " +
                    "p4=" + com.p4.ToString("X") + ", " + "\r\n";

                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_CALCULATE3);
                if (ret != 0)
                {
                    MessageBox.Show("RY_CALCULATE3 error");
                }
                else
                {
                    TextBox1.Text += "Output: p1=" + com.p1.ToString("X") + ", " +
                        "p2=" + com.p2.ToString("X") + ", " +
                        "p3=" + com.p3.ToString("X") + ", " +
                        "p4=" + com.p4.ToString("X") + ", " + "\r\n";
                }
            }
        }

        private void btnRandom_Click(object sender, System.EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            for (i = 0; i < m_HandleNum; i++)
            {
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_RANDOM);
                if (ret != 0)
                {
                    MessageBox.Show("RY_RANDOM error");
                }
                else
                {
                    TextBox1.Text += "Get Random Number are: " +
                        com.p1.ToString("X") + " " +
                        com.p2.ToString("X") + " " +
                        com.p3.ToString("X") + " " +
                        com.p4.ToString("X") + " " + "\r\n";
                }
            }
        }

        private void btnSeed_Click(object sender, System.EventArgs e)
        {
            TextBox1.Text = "";
            int i;
            int ret;

            for (i = 0; i < m_HandleNum; i++)
            {
                com.lp2 = i + 100; //Seed Number
                com.handle = m_Handle[i];
                ret = com.RockeyCM(RY_SEED);
                if (ret != 0)
                {
                    MessageBox.Show("RY_SEED error");
                }
                else
                {
                    TextBox1.Text += "Get Transform Number from Seed are: " +
                        com.p1.ToString("X") + " " +
                        com.p2.ToString("X") + " " +
                        com.p3.ToString("X") + " " +
                        com.p4.ToString("X") + " " + "\r\n";
                }
            }
        }
    }
}