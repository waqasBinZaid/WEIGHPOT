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
			this.btnOpenAll.Click += new System.EventHandler(this.btnOpenAll_Click_1);
			// 
			// btnCloseAll
			// 
			this.btnCloseAll.Location = new System.Drawing.Point(272, 16);
			this.btnCloseAll.Name = "btnCloseAll";
			this.btnCloseAll.Size = new System.Drawing.Size(168, 23);
			this.btnCloseAll.TabIndex = 1;
			this.btnCloseAll.Text = "Close All Rockey4ND Dongles";
			this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click_1);
			// 
			// btnCalc2
			// 
			this.btnCalc2.Location = new System.Drawing.Point(264, 256);
			this.btnCalc2.Name = "btnCalc2";
			this.btnCalc2.Size = new System.Drawing.Size(104, 23);
			this.btnCalc2.TabIndex = 2;
			this.btnCalc2.Text = "Calculate2";
			this.btnCalc2.Click += new System.EventHandler(this.btnCalc2_Click_1);
			// 
			// btnCalc1
			// 
			this.btnCalc1.Location = new System.Drawing.Point(152, 256);
			this.btnCalc1.Name = "btnCalc1";
			this.btnCalc1.Size = new System.Drawing.Size(96, 23);
			this.btnCalc1.TabIndex = 3;
			this.btnCalc1.Text = "Calculate1";
			this.btnCalc1.Click += new System.EventHandler(this.btnCalc1_Click_1);
			// 
			// btnWriteArith
			// 
			this.btnWriteArith.Location = new System.Drawing.Point(40, 256);
			this.btnWriteArith.Name = "btnWriteArith";
			this.btnWriteArith.Size = new System.Drawing.Size(96, 23);
			this.btnWriteArith.TabIndex = 4;
			this.btnWriteArith.Text = "Write Arithmetic";
			this.btnWriteArith.Click += new System.EventHandler(this.btnWriteArith_Click_1);
			// 
			// btnCalc3
			// 
			this.btnCalc3.Location = new System.Drawing.Point(384, 256);
			this.btnCalc3.Name = "btnCalc3";
			this.btnCalc3.Size = new System.Drawing.Size(104, 24);
			this.btnCalc3.TabIndex = 5;
			this.btnCalc3.Text = "Calculate3";
			this.btnCalc3.Click += new System.EventHandler(this.btnCalc3_Click_1);
			// 
			// btnReadModule
			// 
			this.btnReadModule.Location = new System.Drawing.Point(152, 192);
			this.btnReadModule.Name = "btnReadModule";
			this.btnReadModule.Size = new System.Drawing.Size(96, 23);
			this.btnReadModule.TabIndex = 6;
			this.btnReadModule.Text = "Read Module";
			this.btnReadModule.Click += new System.EventHandler(this.btnReadModule_Click_1);
			// 
			// btnReadMomory
			// 
			this.btnReadMomory.Location = new System.Drawing.Point(152, 160);
			this.btnReadMomory.Name = "btnReadMomory";
			this.btnReadMomory.Size = new System.Drawing.Size(96, 23);
			this.btnReadMomory.TabIndex = 7;
			this.btnReadMomory.Text = "Read Memory";
			this.btnReadMomory.Click += new System.EventHandler(this.btnReadMomory_Click_1);
			// 
			// btnWriteModule
			// 
			this.btnWriteModule.Location = new System.Drawing.Point(40, 192);
			this.btnWriteModule.Name = "btnWriteModule";
			this.btnWriteModule.Size = new System.Drawing.Size(96, 23);
			this.btnWriteModule.TabIndex = 8;
			this.btnWriteModule.Text = "Write Module";
			this.btnWriteModule.Click += new System.EventHandler(this.btnWriteModule_Click_1);
			// 
			// btnSeed
			// 
			this.btnSeed.Location = new System.Drawing.Point(152, 288);
			this.btnSeed.Name = "btnSeed";
			this.btnSeed.Size = new System.Drawing.Size(96, 23);
			this.btnSeed.TabIndex = 9;
			this.btnSeed.Text = "Transform Number";
			this.btnSeed.Click += new System.EventHandler(this.btnSeed_Click_1);
			// 
			// btnWriteUserID
			// 
			this.btnWriteUserID.Location = new System.Drawing.Point(40, 224);
			this.btnWriteUserID.Name = "btnWriteUserID";
			this.btnWriteUserID.Size = new System.Drawing.Size(96, 23);
			this.btnWriteUserID.TabIndex = 10;
			this.btnWriteUserID.Text = "Write UserID";
			this.btnWriteUserID.Click += new System.EventHandler(this.btnWriteUserID_Click_1);
			// 
			// btnReadUserID
			// 
			this.btnReadUserID.Location = new System.Drawing.Point(152, 224);
			this.btnReadUserID.Name = "btnReadUserID";
			this.btnReadUserID.Size = new System.Drawing.Size(96, 23);
			this.btnReadUserID.TabIndex = 11;
			this.btnReadUserID.Text = "Read UserID";
			this.btnReadUserID.Click += new System.EventHandler(this.btnReadUserID_Click_1);
			// 
			// btnRandom
			// 
			this.btnRandom.Location = new System.Drawing.Point(40, 288);
			this.btnRandom.Name = "btnRandom";
			this.btnRandom.Size = new System.Drawing.Size(96, 23);
			this.btnRandom.TabIndex = 12;
			this.btnRandom.Text = "Random Number";
			this.btnRandom.Click += new System.EventHandler(this.btnRandom_Click_1);
			// 
			// btnWriteMemory
			// 
			this.btnWriteMemory.Location = new System.Drawing.Point(40, 160);
			this.btnWriteMemory.Name = "btnWriteMemory";
			this.btnWriteMemory.Size = new System.Drawing.Size(96, 23);
			this.btnWriteMemory.TabIndex = 13;
			this.btnWriteMemory.Text = "Write Memory";
			this.btnWriteMemory.Click += new System.EventHandler(this.btnWriteMemory_Click_1);
			// 
			// btnDecModule
			// 
			this.btnDecModule.Location = new System.Drawing.Point(264, 192);
			this.btnDecModule.Name = "btnDecModule";
			this.btnDecModule.Size = new System.Drawing.Size(104, 23);
			this.btnDecModule.TabIndex = 14;
			this.btnDecModule.Text = "Decrease Module";
			this.btnDecModule.Click += new System.EventHandler(this.btnDecModule_Click_1);
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

		private void btnOpenAll_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";	
			int ret;

			com.p1 = 0xC44C;
			com.p2 = 0xC8F8;
			com.p3 = 0x799;
			com.p4 = 0xC43B;

			ret = com.RockeyCM(RY_FIND);
			if(ret != 0)
			{
				MessageBox.Show("RY_FIND error");
				return;
			}
			else
			{
				TextBox1.Text = "HID: " + com.lp1.ToString("X") + "\r\n";
			}
			ret = com.RockeyCM(RY_OPEN);
			if(ret != 0)
			{
				MessageBox.Show("RY_OPEN error");
				return;
			}

			m_Handle[0] = com.handle;
			m_HandleNum = 1;

			while(ret == 0)
			{
				ret = com.RockeyCM(RY_FIND_NEXT);
				if(ret != 0)
				{
					break;
				}
				else
				{
					TextBox1.Text += "HID: " + com.lp1.ToString("X") + "\r\n";
				}
				ret = com.RockeyCM(RY_OPEN);
				if(ret != 0)
				{
					break;
				}

				m_Handle[m_HandleNum] = com.handle;
				m_HandleNum = m_HandleNum + 1;
			}
		}

		private void btnCloseAll_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			for(i = 0; i < m_HandleNum; i++)
			{
				com.handle = m_Handle[i];
				ret = com.RockeyCM(RY_CLOSE);
				if(ret != 0)
				{
					MessageBox.Show("RY_CLOSE error");
				}
			}
		}

		private void btnWriteMemory_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			String str1 = "how do you turn this on";

			for(i = 0; i < m_HandleNum; i++)
			{
				com.buffer = str1;
				com.p1 = 0; //offset
				com.p2 = 100; //length
				com.handle = m_Handle[i];
				ret = com.RockeyCM(RY_WRITE);
				if(ret != 0)
				{
					MessageBox.Show("RY_WRITE error");
				}
				else
				{
					TextBox1.Text += "Write a String, offset = " + com.p1.ToString() + ", length = " + com.p2.ToString() + ", >" + str1 + "\r\n";
				}
			}
		}

		private void btnReadMomory_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			String[] str1 = new String[m_HandleNum];

			for(i = 0; i < m_HandleNum; i++)
			{
				com.p1 = 0; //offset
				com.p2 = 100; //length
				com.handle = m_Handle[i];
				ret = com.RockeyCM(RY_READ);
				if(ret != 0)
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

		private void btnWriteModule_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			for(i = 0; i < m_HandleNum; i++)
			{
				com.p1 = 63; //Module Index
				com.p2 = 5;  //Set Value
				com.p3 = 1;  //allow decrease, 0 or 1
				com.handle = m_Handle[i];
				ret = com.RockeyCM(RY_SET_MOUDLE);
				if(ret != 0)
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

		private void btnReadModule_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			for(i = 0; i < m_HandleNum; i++)
			{
				com.p1 = 63; //Module Index
				com.handle = m_Handle[i];
				ret = com.RockeyCM(RY_CHECK_MOUDLE);
				if(ret != 0)
				{
					MessageBox.Show("RY_CHECK_MOUDLE error");
				}
				else
				{
					TextBox1.Text += "Read Module: Module No. is " +com. p1.ToString() +
						", Enable is " + com.p2.ToString() + ", Allow Decrease is " + com.p3.ToString() + "\r\n";
				}
			}
		}

		private void btnDecModule_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			for(i = 0; i < m_HandleNum; i++)
			{
				com.p1 = 63; //Module Index
				com.handle = m_Handle[i];
				ret = com.RockeyCM(RY_DECREASE);
				if(ret != 0)
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

		private void btnWriteUserID_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			for(i = 0; i < m_HandleNum; i++)
			{
				com.lp1 = 0x12345678;
				com.handle = m_Handle[i];
				ret = com.RockeyCM(RY_WRITE_USERID);
				if(ret != 0)
				{
					MessageBox.Show("RY_WRITE_USERID error");
				}
				else
				{
					TextBox1.Text += "Write User ID to Dongle: " + com.lp1.ToString("X") + "\r\n";
				}
			}
		}

		private void btnReadUserID_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			for(i = 0; i < m_HandleNum; i++)
			{
				com.handle = m_Handle[i];
				ret = com.RockeyCM(RY_READ_USERID);
				if(ret != 0)
				{
					MessageBox.Show("RY_READ_USERID error");
				}
				else
				{
					TextBox1.Text += "Read User ID from Dongle: " + com.lp1.ToString("X") + "\r\n";
				}
			}
		}

		private void btnWriteArith_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			String str1 = "H=H^H, A=A*23, F=B*17, A=A+F, A=A+G, A=A<C, A=A^D, B=B^B, C=C^C, D=D^D";
			String str2 = "A=A+B, A=A+C, A=A+D, A=A+E, A=A+F, A=A+G, A=A+H";
			String str3 = "A=E|E, B=F|F, C=G|G, D=H|H";

			for(i = 0; i < m_HandleNum; i++)
			{
				//arithmetic 1
				com.p1 = 0; //start position
				com.buffer = str1;
				com.handle = m_Handle[i];
				ret = com.RockeyCM(RY_WRITE_ARITHMETIC);
				if(ret != 0)
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
				if(ret != 0)
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
				if(ret != 0)
				{
					MessageBox.Show("RY_WRITE_ARITHMETIC error");
				}
				else
				{
					TextBox1.Text += "Start Position: " + com.p1.ToString() + ", " + str3 + "\r\n" + "\r\n";
				}
			}
		}

		private void btnCalc1_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			for(i = 0; i < m_HandleNum; i++)
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
				if(ret != 0)
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

		private void btnCalc2_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			for(i = 0; i < m_HandleNum; i++)
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
				if(ret != 0)
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

		private void btnCalc3_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			for(i = 0; i < m_HandleNum; i++)
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
				if(ret != 0)
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

		private void btnRandom_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			for(i = 0; i < m_HandleNum; i++)
			{
				com.handle = m_Handle[i];
				ret = com.RockeyCM(RY_RANDOM);
				if(ret != 0)
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

		private void btnSeed_Click_1(object sender, System.EventArgs e)
		{
			TextBox1.Text = "";
			int i;
			int ret;

			for(i = 0; i < m_HandleNum; i++)
			{
				com.lp2 = i + 100; //Seed Number
				com.handle = m_Handle[i];
				ret = com.RockeyCM(RY_SEED);
				if(ret != 0)
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
