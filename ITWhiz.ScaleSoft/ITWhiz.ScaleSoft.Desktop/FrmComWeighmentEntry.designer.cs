namespace IWeigh
{
    partial class FrmComWeighmentEntry
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
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CmdCancel = new System.Windows.Forms.Button();
            this.CmdOK = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnWeighmentEntry = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lst = new System.Windows.Forms.ListView();
            this.colSr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLegend = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWeights = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnNew = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblRemarks = new System.Windows.Forms.Label();
            this.lblNetWeight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblReceivedAmount = new System.Windows.Forms.Label();
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.cboParty = new System.Windows.Forms.ComboBox();
            this.txtReceivedAmount = new IWeigh.Controls.iTextBox();
            this.txtTo = new IWeigh.Controls.iTextBox();
            this.txtFrom = new IWeigh.Controls.iTextBox();
            this.txtParty = new IWeigh.Controls.iTextBox();
            this.txtProduct = new IWeigh.Controls.iTextBox();
            this.txtAmount = new IWeigh.Controls.iTextBox();
            this.txtTotalNetWeight = new IWeigh.Controls.iTextBox();
            this.txtRemark = new IWeigh.Controls.iTextBox();
            this.txtDriverName = new IWeigh.Controls.iTextBox();
            this.txtWeightIndicator = new IWeigh.Controls.iTextBox();
            this.txtVehicleNo = new IWeigh.Controls.iTextBox();
            this.txtSerialNo = new IWeigh.Controls.iTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.AllowDrop = true;
            this.dtpDate.CustomFormat = "dd-MM-yyyy";
            this.dtpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(344, 66);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(155, 29);
            this.dtpDate.TabIndex = 4;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Serial No";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Product";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Weighment Party";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // CmdCancel
            // 
            this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancel.Location = new System.Drawing.Point(802, 429);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(95, 29);
            this.CmdCancel.TabIndex = 17;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // CmdOK
            // 
            this.CmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdOK.Location = new System.Drawing.Point(703, 429);
            this.CmdOK.Name = "CmdOK";
            this.CmdOK.Size = new System.Drawing.Size(93, 29);
            this.CmdOK.TabIndex = 16;
            this.CmdOK.Text = "Print";
            this.CmdOK.UseVisualStyleBackColor = true;
            this.CmdOK.Visible = false;
            this.CmdOK.Click += new System.EventHandler(this.CmdOK_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 239);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(138, 16);
            this.label9.TabIndex = 38;
            this.label9.Text = "Weighment Details";
            // 
            // btnWeighmentEntry
            // 
            this.btnWeighmentEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeighmentEntry.Location = new System.Drawing.Point(712, 196);
            this.btnWeighmentEntry.Name = "btnWeighmentEntry";
            this.btnWeighmentEntry.Size = new System.Drawing.Size(185, 33);
            this.btnWeighmentEntry.TabIndex = 12;
            this.btnWeighmentEntry.Text = "Add Weighment Entry";
            this.btnWeighmentEntry.UseVisualStyleBackColor = true;
            this.btnWeighmentEntry.Click += new System.EventHandler(this.btnWeighmentEntry_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(212, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 16);
            this.label10.TabIndex = 41;
            this.label10.Text = "Vehicle No";
            // 
            // lst
            // 
            this.lst.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSr,
            this.colLegend,
            this.colWeights,
            this.colTime,
            this.colDate,
            this.colType});
            this.lst.FullRowSelect = true;
            this.lst.GridLines = true;
            this.lst.HoverSelection = true;
            this.lst.Location = new System.Drawing.Point(4, 267);
            this.lst.MultiSelect = false;
            this.lst.Name = "lst";
            this.lst.ShowGroups = false;
            this.lst.Size = new System.Drawing.Size(893, 146);
            this.lst.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lst.TabIndex = 42;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.SelectedIndexChanged += new System.EventHandler(this.lst_SelectedIndexChanged);
            // 
            // colSr
            // 
            this.colSr.Text = "#";
            this.colSr.Width = 40;
            // 
            // colLegend
            // 
            this.colLegend.Text = "Legend";
            this.colLegend.Width = 205;
            // 
            // colWeights
            // 
            this.colWeights.Text = "Weight";
            this.colWeights.Width = 222;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTime.Width = 150;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDate.Width = 150;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colType.Width = 122;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(602, 429);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 29);
            this.btnNew.TabIndex = 15;
            this.btnNew.Text = "Save";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(386, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 16);
            this.label14.TabIndex = 57;
            this.label14.Text = "Driver\'s Name";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // lblRemarks
            // 
            this.lblRemarks.AutoSize = true;
            this.lblRemarks.Location = new System.Drawing.Point(5, 429);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(105, 16);
            this.lblRemarks.TabIndex = 60;
            this.lblRemarks.Text = "Remarks(if any):";
            // 
            // lblNetWeight
            // 
            this.lblNetWeight.AutoSize = true;
            this.lblNetWeight.Location = new System.Drawing.Point(400, 436);
            this.lblNetWeight.Name = "lblNetWeight";
            this.lblNetWeight.Size = new System.Drawing.Size(80, 16);
            this.lblNetWeight.TabIndex = 64;
            this.lblNetWeight.Text = "Net Weight :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(401, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 68;
            this.label4.Text = "Amount";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // picBarcode
            // 
            this.picBarcode.Location = new System.Drawing.Point(306, 12);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(193, 50);
            this.picBarcode.TabIndex = 71;
            this.picBarcode.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 28);
            this.button1.TabIndex = 72;
            this.button1.Text = "New Weight";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 16);
            this.label1.TabIndex = 76;
            this.label1.Text = "From Location/Party";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(195, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 16);
            this.label7.TabIndex = 77;
            this.label7.Text = "To Location/Party";
            // 
            // lblReceivedAmount
            // 
            this.lblReceivedAmount.AutoSize = true;
            this.lblReceivedAmount.Location = new System.Drawing.Point(541, 176);
            this.lblReceivedAmount.Name = "lblReceivedAmount";
            this.lblReceivedAmount.Size = new System.Drawing.Size(115, 16);
            this.lblReceivedAmount.TabIndex = 79;
            this.lblReceivedAmount.Text = "Received Amount";
            // 
            // cmbItem
            // 
            this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem.Enabled = false;
            this.cmbItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Items.AddRange(new object[] {
            "Select Product"});
            this.cmbItem.Location = new System.Drawing.Point(175, 202);
            this.cmbItem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(155, 32);
            this.cmbItem.TabIndex = 80;
            this.cmbItem.Visible = false;
            // 
            // cboParty
            // 
            this.cboParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParty.Enabled = false;
            this.cboParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboParty.FormattingEnabled = true;
            this.cboParty.Items.AddRange(new object[] {
            "Select Product"});
            this.cboParty.Location = new System.Drawing.Point(8, 202);
            this.cboParty.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboParty.Name = "cboParty";
            this.cboParty.Size = new System.Drawing.Size(155, 32);
            this.cboParty.TabIndex = 81;
            this.cboParty.Visible = false;
            // 
            // txtReceivedAmount
            // 
            this.txtReceivedAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtReceivedAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtReceivedAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReceivedAmount.Location = new System.Drawing.Point(524, 202);
            this.txtReceivedAmount.Margin = new System.Windows.Forms.Padding(0);
            this.txtReceivedAmount.Name = "txtReceivedAmount";
            this.txtReceivedAmount.PlaceholderText = "";
            this.txtReceivedAmount.Size = new System.Drawing.Size(155, 29);
            this.txtReceivedAmount.TabIndex = 11;
            // 
            // txtTo
            // 
            this.txtTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTo.Location = new System.Drawing.Point(176, 138);
            this.txtTo.Margin = new System.Windows.Forms.Padding(0);
            this.txtTo.Name = "txtTo";
            this.txtTo.PlaceholderText = "";
            this.txtTo.Size = new System.Drawing.Size(155, 29);
            this.txtTo.TabIndex = 6;
            // 
            // txtFrom
            // 
            this.txtFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrom.Location = new System.Drawing.Point(9, 138);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(0);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.PlaceholderText = "";
            this.txtFrom.Size = new System.Drawing.Size(155, 29);
            this.txtFrom.TabIndex = 5;
            // 
            // txtParty
            // 
            this.txtParty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtParty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtParty.Enabled = false;
            this.txtParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParty.Location = new System.Drawing.Point(8, 202);
            this.txtParty.Margin = new System.Windows.Forms.Padding(0);
            this.txtParty.Name = "txtParty";
            this.txtParty.PlaceholderText = "";
            this.txtParty.Size = new System.Drawing.Size(155, 29);
            this.txtParty.TabIndex = 8;
            this.txtParty.Visible = false;
            this.txtParty.TextChanged += new System.EventHandler(this.cboParty_TextChanged);
            // 
            // txtProduct
            // 
            this.txtProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtProduct.Enabled = false;
            this.txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.Location = new System.Drawing.Point(175, 202);
            this.txtProduct.Margin = new System.Windows.Forms.Padding(0);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.PlaceholderText = "";
            this.txtProduct.Size = new System.Drawing.Size(155, 29);
            this.txtProduct.TabIndex = 9;
            this.txtProduct.Visible = false;
            this.txtProduct.TextChanged += new System.EventHandler(this.cmbItem_TextChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtAmount.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(352, 202);
            this.txtAmount.Margin = new System.Windows.Forms.Padding(0);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.PlaceholderText = "";
            this.txtAmount.Size = new System.Drawing.Size(155, 29);
            this.txtAmount.TabIndex = 10;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            // 
            // txtTotalNetWeight
            // 
            this.txtTotalNetWeight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTotalNetWeight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtTotalNetWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNetWeight.Location = new System.Drawing.Point(486, 429);
            this.txtTotalNetWeight.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalNetWeight.Name = "txtTotalNetWeight";
            this.txtTotalNetWeight.PlaceholderText = "";
            this.txtTotalNetWeight.ReadOnly = true;
            this.txtTotalNetWeight.Size = new System.Drawing.Size(102, 29);
            this.txtTotalNetWeight.TabIndex = 14;
            // 
            // txtRemark
            // 
            this.txtRemark.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRemark.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtRemark.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(113, 429);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(0);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PlaceholderText = "";
            this.txtRemark.Size = new System.Drawing.Size(245, 29);
            this.txtRemark.TabIndex = 13;
            // 
            // txtDriverName
            // 
            this.txtDriverName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDriverName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtDriverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDriverName.Location = new System.Drawing.Point(352, 138);
            this.txtDriverName.Margin = new System.Windows.Forms.Padding(0);
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.PlaceholderText = "";
            this.txtDriverName.Size = new System.Drawing.Size(155, 29);
            this.txtDriverName.TabIndex = 7;
            this.txtDriverName.TextChanged += new System.EventHandler(this.txtDriverName_TextChanged);
            // 
            // txtWeightIndicator
            // 
            this.txtWeightIndicator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtWeightIndicator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtWeightIndicator.BackColor = System.Drawing.Color.Black;
            this.txtWeightIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 65.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeightIndicator.ForeColor = System.Drawing.Color.Lime;
            this.txtWeightIndicator.Location = new System.Drawing.Point(502, 5);
            this.txtWeightIndicator.Margin = new System.Windows.Forms.Padding(0);
            this.txtWeightIndicator.Name = "txtWeightIndicator";
            this.txtWeightIndicator.PlaceholderText = "";
            this.txtWeightIndicator.Size = new System.Drawing.Size(419, 106);
            this.txtWeightIndicator.TabIndex = 45;
            this.txtWeightIndicator.Text = "0";
            this.txtWeightIndicator.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtVehicleNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicleNo.Location = new System.Drawing.Point(176, 67);
            this.txtVehicleNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.PlaceholderText = "";
            this.txtVehicleNo.Size = new System.Drawing.Size(155, 29);
            this.txtVehicleNo.TabIndex = 3;
            this.txtVehicleNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehicleNo_KeyDown);
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSerialNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Location = new System.Drawing.Point(9, 66);
            this.txtSerialNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.PlaceholderText = "";
            this.txtSerialNo.ReadOnly = true;
            this.txtSerialNo.Size = new System.Drawing.Size(155, 29);
            this.txtSerialNo.TabIndex = 2;
            this.txtSerialNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerialNo_KeyDown);
            // 
            // FrmComWeighmentEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 467);
            this.Controls.Add(this.cboParty);
            this.Controls.Add(this.cmbItem);
            this.Controls.Add(this.lblReceivedAmount);
            this.Controls.Add(this.txtReceivedAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picBarcode);
            this.Controls.Add(this.txtParty);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblNetWeight);
            this.Controls.Add(this.txtTotalNetWeight);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.lblRemarks);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtDriverName);
            this.Controls.Add(this.txtWeightIndicator);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lst);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtVehicleNo);
            this.Controls.Add(this.btnWeighmentEntry);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdOK);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtSerialNo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmComWeighmentEntry";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Weighment Entry";
            this.Load += new System.EventHandler(this.FrmWeighmentEntry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBarcode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Controls.iTextBox txtSerialNo;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button CmdCancel;
        private System.Windows.Forms.Button CmdOK;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnWeighmentEntry;
        private System.Windows.Forms.Label label10;
        private Controls.iTextBox txtVehicleNo;
        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colWeights;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colSr;
        private System.Windows.Forms.ColumnHeader colLegend;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Button btnNew;
        private Controls.iTextBox txtWeightIndicator;
        private System.Windows.Forms.Label label14;
        private Controls.iTextBox txtDriverName;
        private System.Windows.Forms.Label lblRemarks;
        private Controls.iTextBox txtRemark;
        private System.Windows.Forms.Label lblNetWeight;
        private Controls.iTextBox txtTotalNetWeight;
        private System.Windows.Forms.Label label4;
        private Controls.iTextBox txtAmount;
        private Controls.iTextBox txtParty;
        private Controls.iTextBox txtProduct;
        private System.Windows.Forms.PictureBox picBarcode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblReceivedAmount;
        private Controls.iTextBox txtReceivedAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private Controls.iTextBox txtTo;
        private Controls.iTextBox txtFrom;
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.ComboBox cboParty;
    }
}