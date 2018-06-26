namespace ITWhiz.ScaleSoft.Desktop
{
    partial class SetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblsmsport = new System.Windows.Forms.Label();
            this.txtClientName = new System.Windows.Forms.TextBox();
            this.txtClientAddress = new System.Windows.Forms.TextBox();
            this.txtClientPhone = new System.Windows.Forms.TextBox();
            this.txtClientCity = new System.Windows.Forms.TextBox();
            this.txtClientPhonePort = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.BrowseLogo = new System.Windows.Forms.Button();
            this.cmbIndicators = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIndicatorPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbcompanysms = new System.Windows.Forms.ComboBox();
            this.cmbpartysms = new System.Windows.Forms.ComboBox();
            this.cmbcompanytype = new System.Windows.Forms.ComboBox();
            this.cmbpartyenable = new System.Windows.Forms.ComboBox();
            this.cmbproductenable = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.radiogoogleapi = new System.Windows.Forms.RadioButton();
            this.radiogsm = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "City";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Phone";
            // 
            // lblsmsport
            // 
            this.lblsmsport.AutoSize = true;
            this.lblsmsport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsmsport.Location = new System.Drawing.Point(40, 184);
            this.lblsmsport.Name = "lblsmsport";
            this.lblsmsport.Size = new System.Drawing.Size(67, 15);
            this.lblsmsport.TabIndex = 9;
            this.lblsmsport.Text = "SMS Port";
            this.lblsmsport.Visible = false;
            // 
            // txtClientName
            // 
            this.txtClientName.Location = new System.Drawing.Point(177, 25);
            this.txtClientName.Name = "txtClientName";
            this.txtClientName.Size = new System.Drawing.Size(164, 20);
            this.txtClientName.TabIndex = 1;
            // 
            // txtClientAddress
            // 
            this.txtClientAddress.Location = new System.Drawing.Point(177, 51);
            this.txtClientAddress.Name = "txtClientAddress";
            this.txtClientAddress.Size = new System.Drawing.Size(164, 20);
            this.txtClientAddress.TabIndex = 2;
            // 
            // txtClientPhone
            // 
            this.txtClientPhone.Location = new System.Drawing.Point(177, 104);
            this.txtClientPhone.Name = "txtClientPhone";
            this.txtClientPhone.Size = new System.Drawing.Size(164, 20);
            this.txtClientPhone.TabIndex = 4;
            // 
            // txtClientCity
            // 
            this.txtClientCity.Location = new System.Drawing.Point(177, 77);
            this.txtClientCity.Name = "txtClientCity";
            this.txtClientCity.Size = new System.Drawing.Size(164, 20);
            this.txtClientCity.TabIndex = 3;
            // 
            // txtClientPhonePort
            // 
            this.txtClientPhonePort.Location = new System.Drawing.Point(177, 183);
            this.txtClientPhonePort.Name = "txtClientPhonePort";
            this.txtClientPhonePort.Size = new System.Drawing.Size(164, 20);
            this.txtClientPhonePort.TabIndex = 7;
            this.txtClientPhonePort.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(614, 256);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(517, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 93);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(512, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // BrowseLogo
            // 
            this.BrowseLogo.Location = new System.Drawing.Point(512, 204);
            this.BrowseLogo.Name = "BrowseLogo";
            this.BrowseLogo.Size = new System.Drawing.Size(96, 30);
            this.BrowseLogo.TabIndex = 10;
            this.BrowseLogo.Text = "BrowseLogo";
            this.BrowseLogo.UseVisualStyleBackColor = true;
            this.BrowseLogo.Click += new System.EventHandler(this.BrowseLogo_Click);
            // 
            // cmbIndicators
            // 
            this.cmbIndicators.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbIndicators.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIndicators.FormattingEnabled = true;
            this.cmbIndicators.Location = new System.Drawing.Point(177, 262);
            this.cmbIndicators.Name = "cmbIndicators";
            this.cmbIndicators.Size = new System.Drawing.Size(164, 21);
            this.cmbIndicators.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(174, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "Indicator";
            // 
            // txtIndicatorPort
            // 
            this.txtIndicatorPort.Location = new System.Drawing.Point(177, 209);
            this.txtIndicatorPort.Name = "txtIndicatorPort";
            this.txtIndicatorPort.Size = new System.Drawing.Size(164, 20);
            this.txtIndicatorPort.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(40, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 15);
            this.label9.TabIndex = 20;
            this.label9.Text = "Indicator Port";
            // 
            // cmbcompanysms
            // 
            this.cmbcompanysms.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbcompanysms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompanysms.FormattingEnabled = true;
            this.cmbcompanysms.Items.AddRange(new object[] {
            "FALSE",
            "TRUE"});
            this.cmbcompanysms.Location = new System.Drawing.Point(347, 50);
            this.cmbcompanysms.Name = "cmbcompanysms";
            this.cmbcompanysms.Size = new System.Drawing.Size(164, 21);
            this.cmbcompanysms.TabIndex = 21;
            // 
            // cmbpartysms
            // 
            this.cmbpartysms.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbpartysms.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbpartysms.FormattingEnabled = true;
            this.cmbpartysms.Items.AddRange(new object[] {
            "FALSE",
            "TRUE"});
            this.cmbpartysms.Location = new System.Drawing.Point(347, 104);
            this.cmbpartysms.Name = "cmbpartysms";
            this.cmbpartysms.Size = new System.Drawing.Size(164, 21);
            this.cmbpartysms.TabIndex = 22;
            this.cmbpartysms.TextChanged += new System.EventHandler(this.cmbpartysms_TextChanged);
            // 
            // cmbcompanytype
            // 
            this.cmbcompanytype.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbcompanytype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbcompanytype.FormattingEnabled = true;
            this.cmbcompanytype.Items.AddRange(new object[] {
            "Non Commercial",
            "Commercial"});
            this.cmbcompanytype.Location = new System.Drawing.Point(347, 158);
            this.cmbcompanytype.Name = "cmbcompanytype";
            this.cmbcompanytype.Size = new System.Drawing.Size(164, 21);
            this.cmbcompanytype.TabIndex = 23;
            // 
            // cmbpartyenable
            // 
            this.cmbpartyenable.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbpartyenable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbpartyenable.FormattingEnabled = true;
            this.cmbpartyenable.Items.AddRange(new object[] {
            "FALSE",
            "TRUE"});
            this.cmbpartyenable.Location = new System.Drawing.Point(347, 210);
            this.cmbpartyenable.Name = "cmbpartyenable";
            this.cmbpartyenable.Size = new System.Drawing.Size(164, 21);
            this.cmbpartyenable.TabIndex = 24;
            // 
            // cmbproductenable
            // 
            this.cmbproductenable.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbproductenable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbproductenable.FormattingEnabled = true;
            this.cmbproductenable.Items.AddRange(new object[] {
            "FALSE",
            "TRUE"});
            this.cmbproductenable.Location = new System.Drawing.Point(347, 262);
            this.cmbproductenable.Name = "cmbproductenable";
            this.cmbproductenable.Size = new System.Drawing.Size(164, 21);
            this.cmbproductenable.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(347, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 15);
            this.label10.TabIndex = 26;
            this.label10.Text = "Company SMS";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(347, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 15);
            this.label11.TabIndex = 27;
            this.label11.Text = "Party SMS";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(347, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 15);
            this.label12.TabIndex = 28;
            this.label12.Text = "Company Type";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(347, 192);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 15);
            this.label13.TabIndex = 29;
            this.label13.Text = "Party Enable";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(347, 244);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(105, 15);
            this.label14.TabIndex = 30;
            this.label14.Text = "Product Enable";
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // radiogoogleapi
            // 
            this.radiogoogleapi.AutoSize = true;
            this.radiogoogleapi.Location = new System.Drawing.Point(171, 138);
            this.radiogoogleapi.Name = "radiogoogleapi";
            this.radiogoogleapi.Size = new System.Drawing.Size(79, 17);
            this.radiogoogleapi.TabIndex = 31;
            this.radiogoogleapi.TabStop = true;
            this.radiogoogleapi.Text = "Google API";
            this.radiogoogleapi.UseVisualStyleBackColor = true;
            this.radiogoogleapi.CheckedChanged += new System.EventHandler(this.radiogoogleapi_CheckedChanged);
            // 
            // radiogsm
            // 
            this.radiogsm.AutoSize = true;
            this.radiogsm.Location = new System.Drawing.Point(256, 140);
            this.radiogsm.Name = "radiogsm";
            this.radiogsm.Size = new System.Drawing.Size(85, 17);
            this.radiogsm.TabIndex = 32;
            this.radiogsm.TabStop = true;
            this.radiogsm.Text = "GSM/Mobile";
            this.radiogsm.UseVisualStyleBackColor = true;
            this.radiogsm.CheckedChanged += new System.EventHandler(this.radiogsm_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 33;
            this.label5.Text = "SMS Type";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 324);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radiogsm);
            this.Controls.Add(this.radiogoogleapi);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbproductenable);
            this.Controls.Add(this.cmbpartyenable);
            this.Controls.Add(this.cmbcompanytype);
            this.Controls.Add(this.cmbpartysms);
            this.Controls.Add(this.cmbcompanysms);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtIndicatorPort);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbIndicators);
            this.Controls.Add(this.BrowseLogo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtClientCity);
            this.Controls.Add(this.txtClientPhone);
            this.Controls.Add(this.txtClientPhonePort);
            this.Controls.Add(this.txtClientAddress);
            this.Controls.Add(this.txtClientName);
            this.Controls.Add(this.lblsmsport);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SetupForm";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblsmsport;
        private System.Windows.Forms.TextBox txtClientName;
        private System.Windows.Forms.TextBox txtClientAddress;
        private System.Windows.Forms.TextBox txtClientPhone;
        private System.Windows.Forms.TextBox txtClientCity;
        private System.Windows.Forms.TextBox txtClientPhonePort;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button BrowseLogo;
        private System.Windows.Forms.ComboBox cmbIndicators;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIndicatorPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbcompanysms;
        private System.Windows.Forms.ComboBox cmbpartysms;
        private System.Windows.Forms.ComboBox cmbcompanytype;
        private System.Windows.Forms.ComboBox cmbpartyenable;
        private System.Windows.Forms.ComboBox cmbproductenable;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radiogsm;
        private System.Windows.Forms.RadioButton radiogoogleapi;
    }
}