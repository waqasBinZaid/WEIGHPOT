using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace sample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOpenAll;
		private System.Windows.Forms.Button btnCloseAll;
		private System.Windows.Forms.Button btnCalc2;
		private System.Windows.Forms.Button btnCalc1;
		private System.Windows.Forms.Button btnWriteArith;
		private System.Windows.Forms.Button btnCalc3;
		private System.Windows.Forms.Button btnReadModule;
		private System.Windows.Forms.Button btnReadMomory;
		private System.Windows.Forms.Button btnWriteModule;
		private System.Windows.Forms.Button btnSeed;
		private System.Windows.Forms.Button btnReadUserID;
		private System.Windows.Forms.Button btnRandom;
		private System.Windows.Forms.Button btnWriteMemory;
		private System.Windows.Forms.Button btnDecModule;
		internal System.Windows.Forms.TextBox TextBox1;
		private System.Windows.Forms.Button btnWriteUserID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnOpenAll = new System.Windows.Forms.Button();
			this.btnCloseAll = new System.Windows.Forms.Button();
			this.btnCalc2 = new System.Windows.Forms.Button();
			this.btnCalc1 = new System.Windows.Forms.Button();
			this.btnWriteArith = new System.Windows.Forms.Button();
			this.btnCalc3 = new System.Windows.Forms.Button();
			this.btnReadModule = new System.Windows.Forms.Button();
			this.btnReadMomory = new System.Windows.Forms.Button();
			this.btnWriteModule = new System.Windows.Forms.Button();
			this.btnSeed = new System.Windows.Forms.Button();
			this.btnWriteUserID = new System.Windows.Forms.Button();
			this.btnReadUserID = new System.Windows.Forms.Button();
			this.btnRandom = new System.Windows.Forms.Button();
			this.btnWriteMemory = new System.Windows.Forms.Button();
			this.btnDecModule = new System.Windows.Forms.Button();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnOpenAll
			// 
			this.btnOpenAll.Location = new System.Drawing.Point(40, 16);
			this.btnOpenAll.Name = "btnOpenAll";
			this.btnOpenAll.Size = new System.Drawing.Size(176, 23);
			this.btnOpenAll.TabIndex = 0;
			this.btnOpenAll.Text = "Open All Rockey4ND Dongles";
			this.btnOpenAll.Click += new System.EventHandler(this.btnOpenAll_Click);
			// 
			// btnCloseAll
			// 
			this.btnCloseAll.Location = new System.Drawing.Point(272, 16);
			this.btnCloseAll.Name = "btnCloseAll";
			this.btnCloseAll.Size = new System.Drawing.Size(168, 23);
			this.btnCloseAll.TabIndex = 1;
			this.btnCloseAll.Text = "Close All Rockey4ND Dongles";
			this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
			// 
			// btnCalc2
			// 
			this.btnCalc2.Location = new System.Drawing.Point(264, 256);
			this.btnCalc2.Name = "btnCalc2";
			this.btnCalc2.Size = new System.Drawing.Size(104, 23);
			this.btnCalc2.TabIndex = 2;
			this.btnCalc2.Text = "Calculate2";
			this.btnCalc2.Click += new System.EventHandler(this.btnCalc2_Click);
			// 
			// btnCalc1
			// 
			this.btnCalc1.Location = new System.Drawing.Point(152, 256);
			this.btnCalc1.Name = "btnCalc1";
			this.btnCalc1.Size = new System.Drawing.Size(96, 23);
			this.btnCalc1.TabIndex = 3;
			this.btnCalc1.Text = "Calculate1";
			this.btnCalc1.Click += new System.EventHandler(this.btnCalc1_Click);
			// 
			// btnWriteArith
			// 
			this.btnWriteArith.Location = new System.Drawing.Point(40, 256);
			this.btnWriteArith.Name = "btnWriteArith";
			this.btnWriteArith.Size = new System.Drawing.Size(96, 23);
			this.btnWriteArith.TabIndex = 4;
			this.btnWriteArith.Text = "Write Arithmetic";
			this.btnWriteArith.Click += new System.EventHandler(this.btnWriteArith_Click);
			// 
			// btnCalc3
			// 
			this.btnCalc3.Location = new System.Drawing.Point(384, 256);
			this.btnCalc3.Name = "btnCalc3";
			this.btnCalc3.Size = new System.Drawing.Size(104, 24);
			this.btnCalc3.TabIndex = 5;
			this.btnCalc3.Text = "Calculate3";
			this.btnCalc3.Click += new System.EventHandler(this.btnCalc3_Click);
			// 
			// btnReadModule
			// 
			this.btnReadModule.Location = new System.Drawing.Point(152, 192);
			this.btnReadModule.Name = "btnReadModule";
			this.btnReadModule.Size = new System.Drawing.Size(96, 23);
			this.btnReadModule.TabIndex = 6;
			this.btnReadModule.Text = "Read Module";
			this.btnReadModule.Click += new System.EventHandler(this.btnReadModule_Click);
			// 
			// btnReadMomory
			// 
			this.btnReadMomory.Location = new System.Drawing.Point(152, 160);
			this.btnReadMomory.Name = "btnReadMomory";
			this.btnReadMomory.Size = new System.Drawing.Size(96, 23);
			this.btnReadMomory.TabIndex = 7;
			this.btnReadMomory.Text = "Read Memory";
			this.btnReadMomory.Click += new System.EventHandler(this.btnReadMomory_Click);
			// 
			// btnWriteModule
			// 
			this.btnWriteModule.Location = new System.Drawing.Point(40, 192);
			this.btnWriteModule.Name = "btnWriteModule";
			this.btnWriteModule.Size = new System.Drawing.Size(96, 23);
			this.btnWriteModule.TabIndex = 8;
			this.btnWriteModule.Text = "Write Module";
			this.btnWriteModule.Click += new System.EventHandler(this.btnWriteModule_Click);
			// 
			// btnSeed
			// 
			this.btnSeed.Location = new System.Drawing.Point(152, 288);
			this.btnSeed.Name = "btnSeed";
			this.btnSeed.Size = new System.Drawing.Size(96, 23);
			this.btnSeed.TabIndex = 9;
			this.btnSeed.Text = "Transform Number";
			this.btnSeed.Click += new System.EventHandler(this.btnSeed_Click);
			// 
			// btnWriteUserID
			// 
			this.btnWriteUserID.Location = new System.Drawing.Point(40, 224);
			this.btnWriteUserID.Name = "btnWriteUserID";
			this.btnWriteUserID.Size = new System.Drawing.Size(96, 23);
			this.btnWriteUserID.TabIndex = 10;
			this.btnWriteUserID.Text = "Write UserID";
			this.btnWriteUserID.Click += new System.EventHandler(this.btnWriteUserID_Click);
			// 
			// btnReadUserID
			// 
			this.btnReadUserID.Location = new System.Drawing.Point(152, 224);
			this.btnReadUserID.Name = "btnReadUserID";
			this.btnReadUserID.Size = new System.Drawing.Size(96, 23);
			this.btnReadUserID.TabIndex = 11;
			this.btnReadUserID.Text = "Read UserID";
			this.btnReadUserID.Click += new System.EventHandler(this.btnReadUserID_Click);
			// 
			// btnRandom
			// 
			this.btnRandom.Location = new System.Drawing.Point(40, 288);
			this.btnRandom.Name = "btnRandom";
			this.btnRandom.Size = new System.Drawing.Size(96, 23);
			this.btnRandom.TabIndex = 12;
			this.btnRandom.Text = "Random Number";
			this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click);
			// 
			// btnWriteMemory
			// 
			this.btnWriteMemory.Location = new System.Drawing.Point(40, 160);
			this.btnWriteMemory.Name = "btnWriteMemory";
			this.btnWriteMemory.Size = new System.Drawing.Size(96, 23);
			this.btnWriteMemory.TabIndex = 13;
			this.btnWriteMemory.Text = "Write Memory";
			this.btnWriteMemory.Click += new System.EventHandler(this.btnWriteMemory_Click);
			// 
			// btnDecModule
			// 
			this.btnDecModule.Location = new System.Drawing.Point(264, 192);
			this.btnDecModule.Name = "btnDecModule";
			this.btnDecModule.Size = new System.Drawing.Size(104, 23);
			this.btnDecModule.TabIndex = 14;
			this.btnDecModule.Text = "Decrease Module";
			this.btnDecModule.Click += new System.EventHandler(this.btnDecModule_Click);
			// 
			// TextBox1
			// 
			this.TextBox1.AutoSize = false;
			this.TextBox1.Location = new System.Drawing.Point(40, 64);
			this.TextBox1.Multiline = true;
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.ReadOnly = true;
			this.TextBox1.Size = new System.Drawing.Size(400, 80);
			this.TextBox1.TabIndex = 15;
			this.TextBox1.Text = "TextBox1";
			this.TextBox1.WordWrap = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(496, 358);
			this.Controls.Add(this.TextBox1);
			this.Controls.Add(this.btnDecModule);
			this.Controls.Add(this.btnWriteMemory);
			this.Controls.Add(this.btnRandom);
			this.Controls.Add(this.btnReadUserID);
			this.Controls.Add(this.btnWriteUserID);
			this.Controls.Add(this.btnSeed);
			this.Controls.Add(this.btnWriteModule);
			this.Controls.Add(this.btnReadMomory);
			this.Controls.Add(this.btnReadModule);
			this.Controls.Add(this.btnCalc3);
			this.Controls.Add(this.btnWriteArith);
			this.Controls.Add(this.btnCalc1);
			this.Controls.Add(this.btnCalc2);
			this.Controls.Add(this.btnCloseAll);
			this.Controls.Add(this.btnOpenAll);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
	    }
		[System.Runtime.InteropServices.DllImport("Rockey4ND.dll")]
		static extern ushort Rockey(ushort function, out ushort handle, out uint lp1, out uint lp2,
			out ushort p1, out ushort p2, out ushort p3, out ushort p4, ref byte buffer);

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

		ushort[] m_Handle = new ushort[32];
		int m_HandleNum = 0;

		private void btnOpenAll_Click(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
	
			ushort ret;
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

			p1 = 0xC44C;
			p2 = 0xC8F8;
			p3 = 0x799;
			p4 = 0xC43B;

			ret = Rockey(RY_FIND, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
			if(ret != 0)
			{
				MessageBox.Show("RY_FIND error");
				return;
			}
			else
			{
				TextBox1.Text = "HID: " + lp1.ToString("X") + "\r\n";
			}

			ret = Rockey(RY_OPEN, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
			if(ret != 0)
			{
				MessageBox.Show("RY_OPEN error");
				return;
			}

			m_HandleNum = 1;
			while(ret == 0)
			{
				ret = Rockey(RY_FIND_NEXT, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
				if(ret != 0)
				{
					break;
				}
				else
				{
					TextBox1.Text += "HID: " + lp1.ToString("X") + "\r\n";
				}
				ret = Rockey(RY_OPEN, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

			for(i = 0; i < m_HandleNum; i++)
			{
				ret = Rockey(RY_CLOSE, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

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
				ret = Rockey(RY_WRITE, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

			String[] str1 = new String[m_HandleNum];

			for(i = 0; i < m_HandleNum; i++)
			{
				p1 = 0; //offset
				p2 = 100; //length
				ret = Rockey(RY_READ, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

			for(i = 0; i < m_HandleNum; i++)
			{
				p1 = 63; //Module Index
				p2 = 5;  //Set Value
				p3 = 1;  //allow decrease, 0 or 1
				ret = Rockey(RY_SET_MOUDLE, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

			for(i = 0; i < m_HandleNum; i++)
			{
				p1 = 63; //Module Index
				ret = Rockey(RY_CHECK_MOUDLE, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

			for(i = 0; i < m_HandleNum; i++)
			{
				p1 = 63; //Module Index
				ret = Rockey(RY_DECREASE, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

			lp1 = 0x12345678;

			for(i = 0; i < m_HandleNum; i++)
			{
				ret = Rockey(RY_WRITE_USERID, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

			for(i = 0; i < m_HandleNum; i++)
			{
				ret = Rockey(RY_READ_USERID, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

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
				ret = Rockey(RY_WRITE_ARITHMETIC, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
				ret = Rockey(RY_WRITE_ARITHMETIC, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
				ret = Rockey(RY_WRITE_ARITHMETIC, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

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

				ret = Rockey(RY_CALCULATE1, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

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

				ret = Rockey(RY_CALCULATE2, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

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

				ret = Rockey(RY_CALCULATE3, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

			for(i = 0; i < m_HandleNum; i++)
			{
				ret = Rockey(RY_RANDOM, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
			ushort p1, p2, p3, p4;
			uint lp1, lp2;
			byte[] buffer = new byte[1024];

			for(i = 0; i < m_HandleNum; i++)
			{
				lp2 = i + 100; //Seed Number
				ret = Rockey(RY_SEED, out m_Handle[0], out lp1, out lp2, out p1, out p2, out p3, out p4, ref buffer[0]);
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
