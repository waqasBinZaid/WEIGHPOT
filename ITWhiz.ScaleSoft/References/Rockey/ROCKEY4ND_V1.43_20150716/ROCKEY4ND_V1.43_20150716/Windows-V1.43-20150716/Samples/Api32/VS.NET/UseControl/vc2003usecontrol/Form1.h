#pragma once


namespace sample_vc
{
	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
    using namespace Rockey4NDControl;
	/// <summary> 
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the 
	///          'Resource File Name' property for the managed resource compiler tool 
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public __gc class Form1 : public System::Windows::Forms::Form
	{	
	public:
		Form1(void)
		{
			InitializeComponent();
		}
  
	protected:
		void Dispose(Boolean disposing)
		{
			if (disposing && components)
			{
				components->Dispose();
			}
			__super::Dispose(disposing);
		}
	private: System::Windows::Forms::TextBox *  textBox1;
	private: System::Windows::Forms::Button *  button1;

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container * components;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->textBox1 = new System::Windows::Forms::TextBox();
			this->button1 = new System::Windows::Forms::Button();
			this->SuspendLayout();
			// 
			// textBox1
			// 
			this->textBox1->Location = System::Drawing::Point(32, 16);
			this->textBox1->Multiline = true;
			this->textBox1->Name = S"textBox1";
			this->textBox1->Size = System::Drawing::Size(260, 171);
			this->textBox1->TabIndex = 3;
			this->textBox1->Text = S"textBox1";
			// 
			// button1
			// 
			this->button1->Location = System::Drawing::Point(32, 216);
			this->button1->Name = S"button1";
			this->button1->Size = System::Drawing::Size(260, 22);
			this->button1->TabIndex = 2;
			this->button1->Text = S"test";
			this->button1->Click += new System::EventHandler(this, button1_Click);
			// 
			// Form1
			// 
			this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
			this->ClientSize = System::Drawing::Size(320, 286);
			this->Controls->Add(this->textBox1);
			this->Controls->Add(this->button1);
			this->Name = S"Form1";
			this->Text = S"Form1";
			this->ResumeLayout(false);

		}	
	private: System::Void button1_Click(System::Object *  sender, System::EventArgs *  e)
			 {unsigned short handle, p1, p2, p3, p4, retcode;
	             unsigned int lp1, lp2;
	             unsigned char buffer __gc[]=new unsigned char __gc[1024];
	
	             Rockey4ND *r4nd=new Rockey4ND();	
	             p1 = 0xc44c;
	             p2 = 0xc8f8;
	             p3 = 0x0799;
	             p4 = 0xc43b;
	
	//find rockey4nd
   retcode= r4nd->Rockey(1,handle, lp1, lp2, p1, p2, p3, p4, buffer);
   if(0!=retcode)
   {
	   textBox1->Text="Find rockey4nd error\r\n"; 
	   return;
   }
   //open rockey4nd
   retcode=r4nd->Rockey(3,handle,lp1,lp2, p1, p2, p3, p4, buffer);
   if(0!=retcode)
   {
	  textBox1->Text="open rockey4nd error\r\n"; 
	   return;
   }
   //read rockey4nd
   p1=0;
   p2=10;
   retcode=r4nd->Rockey(5,handle,lp1,lp2, p1, p2, p3, p4, buffer);
   if(0!=retcode)
   {
	   textBox1->Text="read rockey4nd error\r\n";
	   return;
   }
    //close rockey4nd
   retcode=r4nd->Rockey(4,handle,lp1,lp2, p1, p2, p3, p4, buffer);
   if(0!=retcode)
   {
	   textBox1->Text="close rockey4nd error\r\n";
	   return;
   }
   textBox1->Text="Success!";
			 }

	};
}


