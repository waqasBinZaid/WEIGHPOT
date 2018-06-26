#pragma once


namespace VC2005ND {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class Form1 : public System::Windows::Forms::Form
	{
	public:
		Form1(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~Form1()
		{
			if (components)
			{
				delete components;
			}
		}
	public: System::Windows::Forms::Label^  lbl_close;
	protected: 
	public: System::Windows::Forms::Label^  lbl_moudle;
	public: System::Windows::Forms::Label^  lbl_userid;
	public: System::Windows::Forms::Label^  lbl_seed;
	public: System::Windows::Forms::Label^  lbl_open;
	public: System::Windows::Forms::Label^  lbl_find;
	public: System::Windows::Forms::Button^  btn_moudle;
	public: System::Windows::Forms::Button^  btn_userid;
	public: System::Windows::Forms::Button^  btn_close;
	public: System::Windows::Forms::Button^  btn_seed;
	public: System::Windows::Forms::Button^  btn_open;
	public: System::Windows::Forms::Button^  btn_find;
	private: System::Windows::Forms::Label^  label1;
	private: System::Windows::Forms::Button^  btn_memory;
	public: System::Windows::Forms::Label^  lbl_memory;
	private: 
	public: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->lbl_close = (gcnew System::Windows::Forms::Label());
			this->lbl_moudle = (gcnew System::Windows::Forms::Label());
			this->lbl_userid = (gcnew System::Windows::Forms::Label());
			this->lbl_seed = (gcnew System::Windows::Forms::Label());
			this->lbl_open = (gcnew System::Windows::Forms::Label());
			this->lbl_find = (gcnew System::Windows::Forms::Label());
			this->btn_moudle = (gcnew System::Windows::Forms::Button());
			this->btn_userid = (gcnew System::Windows::Forms::Button());
			this->btn_close = (gcnew System::Windows::Forms::Button());
			this->btn_seed = (gcnew System::Windows::Forms::Button());
			this->btn_open = (gcnew System::Windows::Forms::Button());
			this->btn_find = (gcnew System::Windows::Forms::Button());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->btn_memory = (gcnew System::Windows::Forms::Button());
			this->lbl_memory = (gcnew System::Windows::Forms::Label());
			this->SuspendLayout();
			// 
			// lbl_close
			// 
			this->lbl_close->AutoSize = true;
			this->lbl_close->ForeColor = System::Drawing::Color::Red;
			this->lbl_close->Location = System::Drawing::Point(132, 301);
			this->lbl_close->Name = L"lbl_close";
			this->lbl_close->Size = System::Drawing::Size(77, 12);
			this->lbl_close->TabIndex = 23;
			this->lbl_close->Text = L"............";
			// 
			// lbl_moudle
			// 
			this->lbl_moudle->AutoSize = true;
			this->lbl_moudle->ForeColor = System::Drawing::Color::Red;
			this->lbl_moudle->Location = System::Drawing::Point(132, 221);
			this->lbl_moudle->Name = L"lbl_moudle";
			this->lbl_moudle->Size = System::Drawing::Size(77, 12);
			this->lbl_moudle->TabIndex = 22;
			this->lbl_moudle->Text = L"............";
			// 
			// lbl_userid
			// 
			this->lbl_userid->AutoSize = true;
			this->lbl_userid->ForeColor = System::Drawing::Color::Red;
			this->lbl_userid->Location = System::Drawing::Point(132, 181);
			this->lbl_userid->Name = L"lbl_userid";
			this->lbl_userid->Size = System::Drawing::Size(77, 12);
			this->lbl_userid->TabIndex = 21;
			this->lbl_userid->Text = L"............";
			// 
			// lbl_seed
			// 
			this->lbl_seed->AutoSize = true;
			this->lbl_seed->ForeColor = System::Drawing::Color::Red;
			this->lbl_seed->Location = System::Drawing::Point(132, 141);
			this->lbl_seed->Name = L"lbl_seed";
			this->lbl_seed->Size = System::Drawing::Size(77, 12);
			this->lbl_seed->TabIndex = 20;
			this->lbl_seed->Text = L"............";
			// 
			// lbl_open
			// 
			this->lbl_open->AutoSize = true;
			this->lbl_open->ForeColor = System::Drawing::Color::Red;
			this->lbl_open->Location = System::Drawing::Point(132, 101);
			this->lbl_open->Name = L"lbl_open";
			this->lbl_open->Size = System::Drawing::Size(77, 12);
			this->lbl_open->TabIndex = 19;
			this->lbl_open->Text = L"............";
			// 
			// lbl_find
			// 
			this->lbl_find->AutoSize = true;
			this->lbl_find->ForeColor = System::Drawing::Color::Red;
			this->lbl_find->Location = System::Drawing::Point(132, 61);
			this->lbl_find->Name = L"lbl_find";
			this->lbl_find->Size = System::Drawing::Size(77, 12);
			this->lbl_find->TabIndex = 18;
			this->lbl_find->Text = L"............";
			// 
			// btn_moudle
			// 
			this->btn_moudle->Location = System::Drawing::Point(12, 216);
			this->btn_moudle->Name = L"btn_moudle";
			this->btn_moudle->Size = System::Drawing::Size(107, 23);
			this->btn_moudle->TabIndex = 17;
			this->btn_moudle->Text = L"Read Moudle";
			this->btn_moudle->UseVisualStyleBackColor = true;
			this->btn_moudle->Click += gcnew System::EventHandler(this, &Form1::btn_moudle_Click);
			// 
			// btn_userid
			// 
			this->btn_userid->Location = System::Drawing::Point(12, 176);
			this->btn_userid->Name = L"btn_userid";
			this->btn_userid->Size = System::Drawing::Size(107, 23);
			this->btn_userid->TabIndex = 16;
			this->btn_userid->Text = L"Read UserID";
			this->btn_userid->UseVisualStyleBackColor = true;
			this->btn_userid->Click += gcnew System::EventHandler(this, &Form1::btn_userid_Click);
			// 
			// btn_close
			// 
			this->btn_close->Location = System::Drawing::Point(12, 296);
			this->btn_close->Name = L"btn_close";
			this->btn_close->Size = System::Drawing::Size(107, 23);
			this->btn_close->TabIndex = 15;
			this->btn_close->Text = L"Close Rockey";
			this->btn_close->UseVisualStyleBackColor = true;
			this->btn_close->Click += gcnew System::EventHandler(this, &Form1::btn_close_Click);
			// 
			// btn_seed
			// 
			this->btn_seed->Location = System::Drawing::Point(12, 136);
			this->btn_seed->Name = L"btn_seed";
			this->btn_seed->Size = System::Drawing::Size(107, 23);
			this->btn_seed->TabIndex = 14;
			this->btn_seed->Text = L"Use Seed";
			this->btn_seed->UseVisualStyleBackColor = true;
			this->btn_seed->Click += gcnew System::EventHandler(this, &Form1::btn_seed_Click);
			// 
			// btn_open
			// 
			this->btn_open->Location = System::Drawing::Point(12, 96);
			this->btn_open->Name = L"btn_open";
			this->btn_open->Size = System::Drawing::Size(107, 23);
			this->btn_open->TabIndex = 13;
			this->btn_open->Text = L"Open Rockey";
			this->btn_open->UseVisualStyleBackColor = true;
			this->btn_open->Click += gcnew System::EventHandler(this, &Form1::btn_open_Click);
			// 
			// btn_find
			// 
			this->btn_find->Location = System::Drawing::Point(12, 56);
			this->btn_find->Name = L"btn_find";
			this->btn_find->Size = System::Drawing::Size(107, 23);
			this->btn_find->TabIndex = 12;
			this->btn_find->Text = L"Find Rockey";
			this->btn_find->UseVisualStyleBackColor = true;
			this->btn_find->Click += gcnew System::EventHandler(this, &Form1::btn_find_Click);
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(12, 21);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(251, 12);
			this->label1->TabIndex = 24;
			this->label1->Text = L"click buttons one by one, down orderly :)";
			// 
			// btn_memory
			// 
			this->btn_memory->Location = System::Drawing::Point(12, 256);
			this->btn_memory->Name = L"btn_memory";
			this->btn_memory->Size = System::Drawing::Size(107, 23);
			this->btn_memory->TabIndex = 25;
			this->btn_memory->Text = L"Read Memory";
			this->btn_memory->UseVisualStyleBackColor = true;
			this->btn_memory->Click += gcnew System::EventHandler(this, &Form1::btn_memory_Click);
			// 
			// lbl_memory
			// 
			this->lbl_memory->AutoSize = true;
			this->lbl_memory->ForeColor = System::Drawing::Color::Red;
			this->lbl_memory->Location = System::Drawing::Point(132, 261);
			this->lbl_memory->Name = L"lbl_memory";
			this->lbl_memory->Size = System::Drawing::Size(77, 12);
			this->lbl_memory->TabIndex = 26;
			this->lbl_memory->Text = L"............";
			// 
			// Form1
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 12);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(577, 366);
			this->Controls->Add(this->lbl_memory);
			this->Controls->Add(this->btn_memory);
			this->Controls->Add(this->label1);
			this->Controls->Add(this->lbl_close);
			this->Controls->Add(this->lbl_moudle);
			this->Controls->Add(this->lbl_userid);
			this->Controls->Add(this->lbl_seed);
			this->Controls->Add(this->lbl_open);
			this->Controls->Add(this->lbl_find);
			this->Controls->Add(this->btn_moudle);
			this->Controls->Add(this->btn_userid);
			this->Controls->Add(this->btn_close);
			this->Controls->Add(this->btn_seed);
			this->Controls->Add(this->btn_open);
			this->Controls->Add(this->btn_find);
			this->Name = L"Form1";
			this->Text = L"Form1";
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion


//-----------------------------------------------------------------------------
// ROCKEY4ND DLL
//

typedef  unsigned char   BYTE;
typedef  unsigned short  WORD;
typedef  unsigned int    DWORD;

[System::Runtime::InteropServices::DllImport("Rockey4ND.dll")]
static WORD Rockey(WORD function, WORD* handle, DWORD* lp1,  DWORD* lp2, 
            WORD* p1, WORD* p2, WORD* p3, WORD* p4, BYTE* buffer);

//
// ROCKEY4ND DLL
//-----------------------------------------------------------------------------

UInt16  m_HIndex;
UInt32  m_Hid;


private: System::Void btn_find_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			 WORD  retcode, function, handle, p1, p2, p3, p4; //parameter
			 DWORD lp1, lp2;
			 BYTE  buffer[4];

			 function = 1;  //RY_FIND
			 p1 = 0xC44C;   //please change to you key
			 p2 = 0xC8F8;

			 retcode = Rockey(function, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
			 if(retcode != 0)
			 {				 
				 lbl_find->Text = "not found, error code is: " + retcode.ToString();
			 }
			 else
			 {
				 m_Hid = lp1;
				 lbl_find->Text = "find ok, the first rockey hid is: " + m_Hid.ToString("X8");
			 }		
		 }
private: System::Void btn_open_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			 WORD  retcode, function, handle, p1, p2, p3, p4; //parameter
			 DWORD lp1, lp2;
			 BYTE  buffer[4];

			 function = 3;  //RY_OPEN
			 p1 = 0xC44C;   //please change to you key
			 p2 = 0xC8F8;
			 lp1 = m_Hid;

			 retcode = Rockey(function, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
			 if(retcode != 0)
			 {				 
				 lbl_open->Text = "cannot open, error code is: " + retcode.ToString();
			 }
			 else
			 {
				 m_HIndex = handle;
				 lbl_open->Text = "open ok, the handle index is: " + m_HIndex.ToString("D2");
			 }	
		 }
private: System::Void btn_seed_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			 WORD  retcode, function, handle, p1, p2, p3, p4; //parameter
			 DWORD lp1, lp2;
			 BYTE  buffer[4];

			 function = 8;  //RY_SEED
			 handle = m_HIndex;
			 lp1 = 0x12345678; //seed code

			 retcode = Rockey(function, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
			 if(retcode != 0)
			 {				 
				 lbl_seed->Text = "failed, error code is: " + retcode.ToString();
			 }
			 else
			 {
				 m_HIndex = handle;
				 lbl_seed->Text = "ok, generate new codes are:  " 
					 + p1.ToString("X4") + " " + p2.ToString("X4") + " "
					 + p1.ToString("X4") + " " + p2.ToString("X4");
			 }
		 }
private: System::Void btn_userid_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			 WORD  retcode, function, handle, p1, p2, p3, p4; //parameter
			 DWORD lp1, lp2;
			 BYTE  buffer[4];

			 function = 10;  //RY_READ_USERID
			 handle = m_HIndex;

			 retcode = Rockey(function, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
			 if(retcode != 0)
			 {				 
				 lbl_userid->Text = "failed, error code is: " + retcode.ToString();
			 }
			 else
			 {
				 lbl_userid->Text = "ok, the UserID is: " + lp1.ToString("X8");
			 }	
		 }
private: System::Void btn_moudle_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			 WORD  retcode, function, handle, p1, p2, p3, p4; //parameter
			 DWORD lp1, lp2;
			 BYTE  buffer[4];

			 function = 12;     //RY_CHECK_MOUDLE
			 handle = m_HIndex;
			 p1 = 0;            //Moudle Index

			 retcode = Rockey(function, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
			 if(retcode != 0)
			 {				 
				 lbl_open->Text = "failed, error code is: " + retcode.ToString();
			 }
			 else
			 {
				 lbl_moudle->Text = "ok, the Module 0 is: ";

				 if(p2 == 1)
					 lbl_moudle->Text += "enabled ";
				 else
					 lbl_moudle->Text += "disabled ";

				if(p3 == 1)
					lbl_moudle->Text += "and can be decreased";
				else
					lbl_moudle->Text += "and cannot decrease";
			 }	
		 }
private: System::Void btn_memory_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			 {
				 WORD  retcode, function, handle, p1, p2, p3, p4; //parameter
				 DWORD lp1, lp2;
				 BYTE  buffer[64];

				 function = 5;      //RY_READ
				 handle = m_HIndex;
				 p1 = 0;            //offset
				 p2 = 20;           //length

				 retcode = Rockey(function, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
				 if(retcode != 0)
				 {				 
					 lbl_memory->Text = "failed, error code is: " + retcode.ToString();
				 }
				 else
				 {
					 lbl_memory->Text = "ok, memory data are: ";

					 for(int i = 0; i < p2; i++)
					 {
						lbl_memory->Text += buffer[i].ToString("X2") + " ";
					 }
				 }	
			 }
		 }
private: System::Void btn_close_Click(System::Object^  sender, System::EventArgs^  e) 
		 {
			 WORD  retcode, function, handle, p1, p2, p3, p4; //parameter
			 DWORD lp1, lp2;
			 BYTE  buffer[4];

			 function = 4;  //RY_CLOSE
			 handle = m_HIndex;

			 retcode = Rockey(function, &handle, &lp1, &lp2, &p1, &p2, &p3, &p4, buffer);
			 if(retcode != 0)
			 {				 
				 lbl_close->Text = "failed, error code is: " + retcode.ToString();
			 }
			 else
			 {
				 lbl_close->Text = "ok ";
			 }
		 }


};
}

