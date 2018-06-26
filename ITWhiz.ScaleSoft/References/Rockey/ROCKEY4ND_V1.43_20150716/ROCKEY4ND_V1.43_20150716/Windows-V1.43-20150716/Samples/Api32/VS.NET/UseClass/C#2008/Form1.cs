using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace sample3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

		//======================================================================================================

		const ushort RY_FIND = 1;
		const ushort RY_FIND_NEXT = 2;
		const ushort RY_OPEN = 3;
		const ushort RY_CLOSE = 4;
		const ushort RY_READ = 5;
		const ushort RY_WRITE = 6;
		const ushort RY_RANDOM = 7;
		const ushort RY_SEED = 8;
		const ushort RY_WRITE_USERID = 9;
		const ushort RY_READ_USERID = 10;
		const ushort RY_SET_MOUDLE = 11;
		const ushort RY_CHECK_MOUDLE = 12;
		const ushort RY_WRITE_ARITHMETIC = 13;
		const ushort RY_CALCULATE1 = 14;
		const ushort RY_CALCULATE2 = 15;
		const ushort RY_CALCULATE3 = 16;
		const ushort RY_DECREASE = 17;

        Rockey4NDClass.Rockey4ND r4nd = new Rockey4NDClass.Rockey4ND();
		ushort[] m_Handle = new ushort[32];
		int m_HandleNum = 0;

		private void btnOpenAll_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
	
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			p1 = 0xC44C;
			p2 = 0xC8F8;
			p3 = 0x799;
			p4 = 0xC43B;

			ret = r4nd.Rockey(RY_FIND, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
			if(ret != 0)
			{
				MessageBox.Show("RY_FIND error");
				return;
			}
			else
			{
				TextBox1.Text = "HID: " + lp1.ToString("X") + "\r\n";
			}

			ret = r4nd.Rockey(RY_OPEN, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
			if(ret != 0)
			{
				MessageBox.Show("RY_OPEN error");
				return;
			}

			m_HandleNum = 1;
			while(ret == 0)
			{
				ret = r4nd.Rockey(RY_FIND_NEXT, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					break;
				}
				else
				{
					TextBox1.Text += "HID: " + lp1.ToString("X") + "\r\n";
				}
				ret = r4nd.Rockey(RY_OPEN, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					break;
				}
				m_HandleNum = m_HandleNum + 1;
			}
		}

		private void btnCloseAll_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			for(i = 0; i < m_HandleNum; i++)
			{
				ret = r4nd.Rockey(RY_CLOSE, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_CLOSE error");
				}
			}
		}

		private void btnWriteMemory_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			String str1 = "how do you turn this on";
			for(i = 0; i < str1.Length; i++)
			{
				buffer[i] = Convert.ToByte(str1[i]);
			}
			buffer[str1.Length] = 0;

			for(i = 0; i < m_HandleNum; i++)
			{
				p1 = 0; //offset
				p2 = 100; //length
				ret = r4nd.Rockey(RY_WRITE, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_WRITE error");
				}
				else
				{
					TextBox1.Text += "Write a String, offset = " + p1.ToString() + ", length = " + p2.ToString() + ", >" + str1 + "\r\n";
				}
			}
		}

		private void btnReadMomory_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i, k;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			String[] str1 = new String[m_HandleNum];

			for(i = 0; i < m_HandleNum; i++)
			{
				p1 = 0; //offset
				p2 = 100; //length
				ret = r4nd.Rockey(RY_READ, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_READ error");
				}
				else
				{
					for(k = 0; k < p2; k++)
					{
						if(buffer[k] == 0)
						{
							break;
						}
						str1[i] += Convert.ToChar(buffer[k]);
					}
					TextBox1.Text += "Read a String, offset = " + p1.ToString() + ", length = " + p2.ToString() + ", >" + str1[i] + "\r\n";
				}
			}
		}

		private void btnWriteModule_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			for(i = 0; i < m_HandleNum; i++)
			{
				p1 = 63; //Module Index
				p2 = 5;  //Set Value
				p3 = 1;  //allow decrease, 0 or 1
				ret = r4nd.Rockey(RY_SET_MOUDLE, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_SET_MOUDLE error");
				}
				else
				{
					TextBox1.Text += "Write Module: Module No. is " + p1.ToString() +
						", Value is " + p2.ToString() + ", Allow Decrease is " + p3.ToString() + "\r\n";
				}
			}
		}

		private void btnReadModule_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			for(i = 0; i < m_HandleNum; i++)
			{
				p1 = 63; //Module Index+
				ret = r4nd.Rockey(RY_CHECK_MOUDLE, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_CHECK_MOUDLE error");
				}
				else
				{
					TextBox1.Text += "Read Module: Module No. is " + p1.ToString() +
						", Enable is " + p2.ToString() + ", Allow Decrease is " + p3.ToString() + "\r\n";
				}
			}
		}

		private void btnDecModule_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			for(i = 0; i < m_HandleNum; i++)
			{
				p1 = 63; //Module Index
				ret = r4nd.Rockey(RY_DECREASE, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_DECREASE error");
				}
				else
				{
					TextBox1.Text += "Decrease Module value: Module No. is " + p1.ToString() +
						", Decreased" + "\r\n";
				}
			}
		}

		private void btnWriteUserID_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			lp1 = 0x12345678;

			for(i = 0; i < m_HandleNum; i++)
			{
				ret = r4nd.Rockey(RY_WRITE_USERID, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_WRITE_USERID error");
				}
				else
				{
					TextBox1.Text += "Write User ID to Dongle: " + lp1.ToString("X") + "\r\n";
				}
			}
		}

		private void btnReadUserID_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			for(i = 0; i < m_HandleNum; i++)
			{
				ret = r4nd.Rockey(RY_READ_USERID, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_READ_USERID error");
				}
				else
				{
					TextBox1.Text += "Read User ID from Dongle: " + lp1.ToString("X") + "\r\n";
				}
			}
		}

		private void btnWriteArith_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i, k;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			String str1 = "H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D";
			String str2 = "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H";
			String str3 = "A=E|E, B=F|F, C=G|G, D=H|H";

			for(i = 0; i < m_HandleNum; i++)
			{
				//arithmetic 1
				p1 = 0; //start position
				for(k = 0; k < str1.Length; k++)
				{
					buffer[k] = Convert.ToByte(str1[k]);
				}
				buffer[str1.Length] = 0;
				ret = r4nd.Rockey(RY_WRITE_ARITHMETIC, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_WRITE_ARITHMETIC error");
				}
				else
				{
					TextBox1.Text += "Start Position: " + p1.ToString() + ", " + str1 + "\r\n";
				}

				//arithmetic 2
				p1 = 40; //start position
				for(k = 0; k < str2.Length; k++)
				{
					buffer[k] = Convert.ToByte(str2[k]);
				}
				buffer[str2.Length] = 0;
				ret = r4nd.Rockey(RY_WRITE_ARITHMETIC, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_WRITE_ARITHMETIC error");
				}
				else
				{
					TextBox1.Text += "Start Position: " + p1.ToString() + ", " + str2 + "\r\n";
				}

				//arithmetic 3
				p1 = 80; //start position
				for(k = 0; k < str3.Length; k++)
				{
					buffer[k] = Convert.ToByte(str3[k]);
				}
				buffer[str3.Length] = 0;
				ret = r4nd.Rockey(RY_WRITE_ARITHMETIC, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_WRITE_ARITHMETIC error");
				}
				else
				{
					TextBox1.Text += "Start Position: " + p1.ToString() + ", " + str3 + "\r\n" + "\r\n";
				}
			}
		}

		private void btnCalc1_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			for(i = 0; i < m_HandleNum; i++)
			{
				lp1 = 0; //start position
				lp2 = 7; //module No.
				p1 = 5;
				p2 = 3;
				p3 = 1;
				p4 = 0xFFFF;

				TextBox1.Text += "Input: Start=" + lp1.ToString() + ", " +
					"Module=" + lp2.ToString() + ", " +
					"p1=" + p1.ToString("X") + ", " +
					"p2=" + p2.ToString("X") + ", " +
					"p3=" + p3.ToString("X") + ", " +
					"p4=" + p4.ToString("X") + ", " + "\r\n";

				ret = r4nd.Rockey(RY_CALCULATE1, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_CALCULATE1 error");
				}
				else
				{
					TextBox1.Text += "Output: p1= " + p1.ToString("X") + ", " +
						"p2= " + p2.ToString("X") + ", " +
						"p3= " + p3.ToString("X") + ", " +
						"p4= " + p4.ToString("X") + ", " + "\r\n" + "\r\n";
				}

			}
		}

		private void btnCalc2_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			for(i = 0; i < m_HandleNum; i++)
			{
				lp1 = 40; //start position
				lp2 = 0x12345678; //module No.
				p1 = 1;
				p2 = 2;
				p3 = 3;
				p4 = 4;

				TextBox1.Text += "Input: Start=" + lp1.ToString() + ", " +
					"Seed=" + lp2.ToString("X") + ", " +
					"p1=" + p1.ToString("X") + ", " +
					"p2=" + p2.ToString("X") + ", " +
					"p3=" + p3.ToString("X") + ", " +
					"p4=" + p4.ToString("X") + ", " + "\r\n";

				ret = r4nd.Rockey(RY_CALCULATE2, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_CALCULATE2 error");
                
				}
				else
				{
					TextBox1.Text += "Output: p1= " + p1.ToString("X") + ", " +
						"p2= " + p2.ToString("X") + ", " +
						"p3= " + p3.ToString("X") + ", " +
						"p4= " + p4.ToString("X") + ", " + "\r\n" + "\r\n";
				}
			}
		}

		private void btnCalc3_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			for(i = 0; i < m_HandleNum; i++)
			{
				lp1 = 80; //start position
				lp2 = 6; //module No.
				p1 = 1;
				p2 = 2;
				p3 = 3;
				p4 = 4;

				TextBox1.Text += "Input: Arithmetic Start=" + lp1.ToString() + ", " +
					"Module Start=" + lp2.ToString() + ", " +
					"p1=" + p1.ToString("X") + ", " +
					"p2=" + p2.ToString("X") + ", " +
					"p3=" + p3.ToString("X") + ", " +
					"p4=" + p4.ToString("X") + ", " + "\r\n";

				ret = r4nd.Rockey(RY_CALCULATE3, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_CALCULATE3 error");
				}
				else
				{
					TextBox1.Text += "Output: p1=" + p1.ToString("X") + ", " +
						"p2=" + p2.ToString("X") + ", " +
						"p3=" + p3.ToString("X") + ", " +
						"p4=" + p4.ToString("X") + ", " + "\r\n";
				}
			}
		}

		private void btnRandom_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			for(i = 0; i < m_HandleNum; i++)
			{
				ret = r4nd.Rockey(RY_RANDOM, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_RANDOM error");
				}
				else
				{
					TextBox1.Text += "Get Random Number are: " +
						p1.ToString("X") + " " +
						p2.ToString("X") + " " +
						p3.ToString("X") + " " +
						p4.ToString("X") + " " + "\r\n";
				}
			}
		}

		private void btnSeed_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			uint i;
			ushort ret;
			ushort p1 = 0, p2 = 0, p3 = 0, p4 = 0;
			uint lp1 = 0, lp2 = 0;
			byte[] buffer = new byte[1000];

			for(i = 0; i < m_HandleNum; i++)
			{
				lp2 = i + 100; //Seed Number
				ret = r4nd.Rockey(RY_SEED, ref m_Handle[0], ref lp1, ref lp2, ref p1, ref p2, ref p3, ref p4, buffer);
				if(ret != 0)
				{
					MessageBox.Show("RY_SEED error");
				}
				else
				{
					TextBox1.Text += "Get Transform Number from Seed are: " +
						p1.ToString("X") + " " +
						p2.ToString("X") + " " +
						p3.ToString("X") + " " +
						p4.ToString("X") + " " + "\r\n";
				}
			}
		}
	}
}