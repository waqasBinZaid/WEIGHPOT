namespace IWeigh
{
    partial class FrmConfiguration
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
            this.btnChangeIndicator = new System.Windows.Forms.Button();
            this.chkIndicatorOn = new System.Windows.Forms.CheckBox();
            this.cmbCommPortNo = new System.Windows.Forms.ComboBox();
            this.cmbParityBit = new System.Windows.Forms.ComboBox();
            this.cmbDataBit = new System.Windows.Forms.ComboBox();
            this.cmbBoudRate = new System.Windows.Forms.ComboBox();
            this.cmbStopBit = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtCurrentIndicator = new IWeigh.Controls.iTextBox();
            this.txtDelay = new IWeigh.Controls.iTextBox();
            this.SuspendLayout();
            // 
            // btnChangeIndicator
            // 
            this.btnChangeIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChangeIndicator.Location = new System.Drawing.Point(457, 61);
            this.btnChangeIndicator.Name = "btnChangeIndicator";
            this.btnChangeIndicator.Size = new System.Drawing.Size(143, 64);
            this.btnChangeIndicator.TabIndex = 24;
            this.btnChangeIndicator.Text = "Change Indicator ...";
            this.btnChangeIndicator.UseVisualStyleBackColor = true;
            this.btnChangeIndicator.Click += new System.EventHandler(this.btnPartyList_Click);
            // 
            // chkIndicatorOn
            // 
            this.chkIndicatorOn.AutoSize = true;
            this.chkIndicatorOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIndicatorOn.Location = new System.Drawing.Point(457, 25);
            this.chkIndicatorOn.Name = "chkIndicatorOn";
            this.chkIndicatorOn.Size = new System.Drawing.Size(143, 28);
            this.chkIndicatorOn.TabIndex = 22;
            this.chkIndicatorOn.Text = "Indicator On";
            this.chkIndicatorOn.UseVisualStyleBackColor = true;
            this.chkIndicatorOn.CheckedChanged += new System.EventHandler(this.chkIndicatorOn_CheckedChanged);
            // 
            // cmbCommPortNo
            // 
            this.cmbCommPortNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCommPortNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCommPortNo.FormattingEnabled = true;
            this.cmbCommPortNo.Items.AddRange(new object[] {
            "Select Comm Port No"});
            this.cmbCommPortNo.Location = new System.Drawing.Point(50, 150);
            this.cmbCommPortNo.Name = "cmbCommPortNo";
            this.cmbCommPortNo.Size = new System.Drawing.Size(250, 32);
            this.cmbCommPortNo.TabIndex = 21;
            this.cmbCommPortNo.SelectedIndexChanged += new System.EventHandler(this.cmbCommPortNo_SelectedIndexChanged_1);
            // 
            // cmbParityBit
            // 
            this.cmbParityBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParityBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParityBit.FormattingEnabled = true;
            this.cmbParityBit.Items.AddRange(new object[] {
            "Select Parity Bit"});
            this.cmbParityBit.Location = new System.Drawing.Point(52, 207);
            this.cmbParityBit.Name = "cmbParityBit";
            this.cmbParityBit.Size = new System.Drawing.Size(250, 32);
            this.cmbParityBit.TabIndex = 25;
            // 
            // cmbDataBit
            // 
            this.cmbDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDataBit.FormattingEnabled = true;
            this.cmbDataBit.Items.AddRange(new object[] {
            "Select Data Bit"});
            this.cmbDataBit.Location = new System.Drawing.Point(350, 207);
            this.cmbDataBit.Name = "cmbDataBit";
            this.cmbDataBit.Size = new System.Drawing.Size(250, 32);
            this.cmbDataBit.TabIndex = 26;
            this.cmbDataBit.SelectedIndexChanged += new System.EventHandler(this.cmbDataBit_SelectedIndexChanged_1);
            // 
            // cmbBoudRate
            // 
            this.cmbBoudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBoudRate.FormattingEnabled = true;
            this.cmbBoudRate.Items.AddRange(new object[] {
            "Select Boud Rate"});
            this.cmbBoudRate.Location = new System.Drawing.Point(350, 150);
            this.cmbBoudRate.Name = "cmbBoudRate";
            this.cmbBoudRate.Size = new System.Drawing.Size(250, 32);
            this.cmbBoudRate.TabIndex = 27;
            this.cmbBoudRate.SelectedIndexChanged += new System.EventHandler(this.CmbBoudRate_SelectedIndexChanged);
            // 
            // cmbStopBit
            // 
            this.cmbStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStopBit.FormattingEnabled = true;
            this.cmbStopBit.Items.AddRange(new object[] {
            "Select Stop Bit"});
            this.cmbStopBit.Location = new System.Drawing.Point(52, 264);
            this.cmbStopBit.Name = "cmbStopBit";
            this.cmbStopBit.Size = new System.Drawing.Size(250, 32);
            this.cmbStopBit.TabIndex = 28;
            this.cmbStopBit.SelectedIndexChanged += new System.EventHandler(this.cmbStopBit_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(500, 321);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 29);
            this.btnCancel.TabIndex = 30;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(350, 321);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(100, 29);
            this.btnOk.TabIndex = 29;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtCurrentIndicator
            // 
            this.txtCurrentIndicator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCurrentIndicator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtCurrentIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentIndicator.Location = new System.Drawing.Point(50, 25);
            this.txtCurrentIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.txtCurrentIndicator.Multiline = true;
            this.txtCurrentIndicator.Name = "txtCurrentIndicator";
            this.txtCurrentIndicator.PlaceholderText = "Current Indicator";
            this.txtCurrentIndicator.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCurrentIndicator.Size = new System.Drawing.Size(400, 100);
            this.txtCurrentIndicator.TabIndex = 23;
            this.txtCurrentIndicator.TextChanged += new System.EventHandler(this.txtCurrentIndicator_TextChanged);
            // 
            // txtDelay
            // 
            this.txtDelay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDelay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelay.Location = new System.Drawing.Point(350, 267);
            this.txtDelay.Margin = new System.Windows.Forms.Padding(0);
            this.txtDelay.Name = "txtDelay";
            this.txtDelay.PlaceholderText = "Delay (mili Seconds)";
            this.txtDelay.Size = new System.Drawing.Size(250, 29);
            this.txtDelay.TabIndex = 20;
            this.txtDelay.TextChanged += new System.EventHandler(this.txtTicketNo_TextChanged);
            // 
            // FrmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 362);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.cmbStopBit);
            this.Controls.Add(this.cmbBoudRate);
            this.Controls.Add(this.cmbDataBit);
            this.Controls.Add(this.cmbParityBit);
            this.Controls.Add(this.btnChangeIndicator);
            this.Controls.Add(this.txtCurrentIndicator);
            this.Controls.Add(this.chkIndicatorOn);
            this.Controls.Add(this.cmbCommPortNo);
            this.Controls.Add(this.txtDelay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurations";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frmconfiguration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangeIndicator;
        private Controls.iTextBox txtCurrentIndicator;
        private System.Windows.Forms.CheckBox chkIndicatorOn;
        private System.Windows.Forms.ComboBox cmbCommPortNo;
        private Controls.iTextBox txtDelay;
        private System.Windows.Forms.ComboBox cmbParityBit;
        private System.Windows.Forms.ComboBox cmbDataBit;
        private System.Windows.Forms.ComboBox cmbBoudRate;
        private System.Windows.Forms.ComboBox cmbStopBit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}