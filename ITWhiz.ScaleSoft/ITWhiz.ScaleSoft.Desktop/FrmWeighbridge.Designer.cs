namespace IWeigh
{
    partial class FrmWeighbridge
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkWithDriver = new System.Windows.Forms.CheckBox();
            this.cmbParty = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblWeightIndicator = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.btnPartyList = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.dgwWeightDetails = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtCharges = new IWeigh.Controls.iTextBox();
            this.txtTotalNetWeight = new IWeigh.Controls.iTextBox();
            this.txtVehicleNo = new IWeigh.Controls.iTextBox();
            this.txtTicketNo = new IWeigh.Controls.iTextBox();
            this.WeightNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Party = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime1st = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight1st = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateTime2nd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight2nd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgwWeightDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // chkWithDriver
            // 
            this.chkWithDriver.AutoSize = true;
            this.chkWithDriver.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWithDriver.Location = new System.Drawing.Point(625, 28);
            this.chkWithDriver.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.chkWithDriver.Name = "chkWithDriver";
            this.chkWithDriver.Size = new System.Drawing.Size(100, 22);
            this.chkWithDriver.TabIndex = 13;
            this.chkWithDriver.Text = "With Driver";
            this.chkWithDriver.UseVisualStyleBackColor = true;
            // 
            // cmbParty
            // 
            this.cmbParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbParty.FormattingEnabled = true;
            this.cmbParty.Items.AddRange(new object[] {
            "Select Party"});
            this.cmbParty.Location = new System.Drawing.Point(25, 85);
            this.cmbParty.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbParty.Name = "cmbParty";
            this.cmbParty.Size = new System.Drawing.Size(590, 32);
            this.cmbParty.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(1072, 560);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 36);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(939, 560);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(133, 36);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lblWeightIndicator
            // 
            this.lblWeightIndicator.AutoSize = true;
            this.lblWeightIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeightIndicator.Location = new System.Drawing.Point(824, 25);
            this.lblWeightIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.lblWeightIndicator.Name = "lblWeightIndicator";
            this.lblWeightIndicator.Padding = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.lblWeightIndicator.Size = new System.Drawing.Size(416, 120);
            this.lblWeightIndicator.TabIndex = 14;
            this.lblWeightIndicator.Text = "8888888";
            // 
            // cmbProduct
            // 
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Items.AddRange(new object[] {
            "Select Product"});
            this.cmbProduct.Location = new System.Drawing.Point(25, 145);
            this.cmbProduct.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(590, 32);
            this.cmbProduct.TabIndex = 16;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // btnPartyList
            // 
            this.btnPartyList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPartyList.Location = new System.Drawing.Point(625, 82);
            this.btnPartyList.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnPartyList.Name = "btnPartyList";
            this.btnPartyList.Size = new System.Drawing.Size(67, 39);
            this.btnPartyList.TabIndex = 17;
            this.btnPartyList.Text = "...";
            this.btnPartyList.UseVisualStyleBackColor = true;
            this.btnPartyList.Click += new System.EventHandler(this.btnPartyList_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.Location = new System.Drawing.Point(625, 142);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(67, 39);
            this.btnProduct.TabIndex = 18;
            this.btnProduct.Text = "...";
            this.btnProduct.UseVisualStyleBackColor = true;
            // 
            // dgwWeightDetails
            // 
            this.dgwWeightDetails.AllowUserToDeleteRows = false;
            this.dgwWeightDetails.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwWeightDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgwWeightDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwWeightDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WeightNo,
            this.Party,
            this.Product,
            this.DateTime1st,
            this.Weight1st,
            this.DateTime2nd,
            this.Weight2nd,
            this.NetWeight});
            this.dgwWeightDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgwWeightDetails.Location = new System.Drawing.Point(25, 205);
            this.dgwWeightDetails.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dgwWeightDetails.Name = "dgwWeightDetails";
            this.dgwWeightDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgwWeightDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwWeightDetails.Size = new System.Drawing.Size(1180, 262);
            this.dgwWeightDetails.TabIndex = 20;
            this.dgwWeightDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(806, 560);
            this.btnSave.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 36);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(673, 560);
            this.btnNew.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(133, 36);
            this.btnNew.TabIndex = 23;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtCharges
            // 
            this.txtCharges.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtCharges.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCharges.Location = new System.Drawing.Point(25, 500);
            this.txtCharges.Margin = new System.Windows.Forms.Padding(0);
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.PlaceholderText = "Charges";
            this.txtCharges.Size = new System.Drawing.Size(399, 29);
            this.txtCharges.TabIndex = 22;
            // 
            // txtTotalNetWeight
            // 
            this.txtTotalNetWeight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTotalNetWeight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtTotalNetWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNetWeight.Location = new System.Drawing.Point(806, 500);
            this.txtTotalNetWeight.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalNetWeight.Name = "txtTotalNetWeight";
            this.txtTotalNetWeight.PlaceholderText = "Total Net Weight";
            this.txtTotalNetWeight.Size = new System.Drawing.Size(399, 29);
            this.txtTotalNetWeight.TabIndex = 21;
            this.txtTotalNetWeight.TextChanged += new System.EventHandler(this.txtTotalNetWeight_TextChanged);
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtVehicleNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicleNo.Location = new System.Drawing.Point(350, 25);
            this.txtVehicleNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.PlaceholderText = "Vehicle No";
            this.txtVehicleNo.Size = new System.Drawing.Size(265, 29);
            this.txtVehicleNo.TabIndex = 15;
            // 
            // txtTicketNo
            // 
            this.txtTicketNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTicketNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtTicketNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTicketNo.Location = new System.Drawing.Point(25, 25);
            this.txtTicketNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtTicketNo.Name = "txtTicketNo";
            this.txtTicketNo.PlaceholderText = "Ticket No";
            this.txtTicketNo.Size = new System.Drawing.Size(265, 29);
            this.txtTicketNo.TabIndex = 8;
            this.txtTicketNo.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // WeightNo
            // 
            this.WeightNo.HeaderText = "Weight No";
            this.WeightNo.MaxInputLength = 8;
            this.WeightNo.Name = "WeightNo";
            this.WeightNo.Width = 80;
            // 
            // Party
            // 
            this.Party.HeaderText = "Party";
            this.Party.MaxInputLength = 300;
            this.Party.MinimumWidth = 50;
            this.Party.Name = "Party";
            this.Party.Width = 250;
            // 
            // Product
            // 
            this.Product.HeaderText = "Product";
            this.Product.MaxInputLength = 300;
            this.Product.MinimumWidth = 50;
            this.Product.Name = "Product";
            this.Product.Width = 250;
            // 
            // DateTime1st
            // 
            this.DateTime1st.HeaderText = "1st Date/Time";
            this.DateTime1st.MaxInputLength = 20;
            this.DateTime1st.Name = "DateTime1st";
            this.DateTime1st.Width = 150;
            // 
            // Weight1st
            // 
            this.Weight1st.HeaderText = "1st Weight";
            this.Weight1st.MaxInputLength = 8;
            this.Weight1st.Name = "Weight1st";
            this.Weight1st.Width = 80;
            // 
            // DateTime2nd
            // 
            this.DateTime2nd.HeaderText = "2nd Date/Time";
            this.DateTime2nd.MaxInputLength = 20;
            this.DateTime2nd.Name = "DateTime2nd";
            this.DateTime2nd.Width = 150;
            // 
            // Weight2nd
            // 
            this.Weight2nd.HeaderText = "2nd Weight";
            this.Weight2nd.MaxInputLength = 8;
            this.Weight2nd.Name = "Weight2nd";
            this.Weight2nd.Width = 80;
            // 
            // NetWeight
            // 
            this.NetWeight.HeaderText = "Net Weight";
            this.NetWeight.MaxInputLength = 8;
            this.NetWeight.Name = "NetWeight";
            this.NetWeight.Width = 79;
            // 
            // FrmWeighbridge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 617);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtCharges);
            this.Controls.Add(this.txtTotalNetWeight);
            this.Controls.Add(this.dgwWeightDetails);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnPartyList);
            this.Controls.Add(this.cmbProduct);
            this.Controls.Add(this.txtVehicleNo);
            this.Controls.Add(this.lblWeightIndicator);
            this.Controls.Add(this.chkWithDriver);
            this.Controls.Add(this.cmbParty);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtTicketNo);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmWeighbridge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmWeighbridge";
            this.Load += new System.EventHandler(this.FrmWeighbridge_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwWeightDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkWithDriver;
        private System.Windows.Forms.ComboBox cmbParty;
        private System.Windows.Forms.Button btnCancel;
        private Controls.iTextBox txtTicketNo;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblWeightIndicator;
        private Controls.iTextBox txtVehicleNo;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Button btnPartyList;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.DataGridView dgwWeightDetails;
        private Controls.iTextBox txtTotalNetWeight;
        private Controls.iTextBox txtCharges;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Party;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime1st;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight1st;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateTime2nd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight2nd;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetWeight;
    }
}