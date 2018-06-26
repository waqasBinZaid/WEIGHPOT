namespace IWeigh
{
    partial class FrmWeighmentEntry
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
            this.cmbItem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboParty = new System.Windows.Forms.ComboBox();
            this.picBarcode = new System.Windows.Forms.PictureBox();
            this.txtProduct = new IWeigh.Controls.iTextBox();
            this.txtParty = new IWeigh.Controls.iTextBox();
            this.txtTotalNetWeight = new IWeigh.Controls.iTextBox();
            this.txtRemark = new IWeigh.Controls.iTextBox();
            this.txtNoOfBags = new IWeigh.Controls.iTextBox();
            this.txtDriverName = new IWeigh.Controls.iTextBox();
            this.txtSealNo = new IWeigh.Controls.iTextBox();
            this.txtBiltyNo = new IWeigh.Controls.iTextBox();
            this.txtContainerNo = new IWeigh.Controls.iTextBox();
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
            this.dtpDate.Location = new System.Drawing.Point(5, 83);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(155, 29);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // cmbItem
            // 
            this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem.Enabled = false;
            this.cmbItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Items.AddRange(new object[] {
            "Select Product"});
            this.cmbItem.Location = new System.Drawing.Point(163, 183);
            this.cmbItem.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(155, 32);
            this.cmbItem.TabIndex = 4;
            this.cmbItem.Visible = false;
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.cmbItem_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Serial No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "Product";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Party";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // CmdCancel
            // 
            this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancel.Location = new System.Drawing.Point(803, 396);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(95, 29);
            this.CmdCancel.TabIndex = 10;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // CmdOK
            // 
            this.CmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdOK.Location = new System.Drawing.Point(704, 396);
            this.CmdOK.Name = "CmdOK";
            this.CmdOK.Size = new System.Drawing.Size(93, 29);
            this.CmdOK.TabIndex = 9;
            this.CmdOK.Text = "Print";
            this.CmdOK.UseVisualStyleBackColor = true;
            this.CmdOK.Visible = false;
            this.CmdOK.Click += new System.EventHandler(this.CmdOK_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 16);
            this.label9.TabIndex = 38;
            this.label9.Text = "Weighment Details";
            // 
            // btnWeighmentEntry
            // 
            this.btnWeighmentEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWeighmentEntry.Location = new System.Drawing.Point(713, 180);
            this.btnWeighmentEntry.Name = "btnWeighmentEntry";
            this.btnWeighmentEntry.Size = new System.Drawing.Size(185, 33);
            this.btnWeighmentEntry.TabIndex = 6;
            this.btnWeighmentEntry.Text = "Add Weighment Entry";
            this.btnWeighmentEntry.UseVisualStyleBackColor = true;
            this.btnWeighmentEntry.Click += new System.EventHandler(this.btnWeighmentEntry_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(201, 5);
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
            this.lst.Location = new System.Drawing.Point(5, 244);
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
            this.btnNew.Location = new System.Drawing.Point(603, 396);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(95, 29);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "Save";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 16);
            this.label11.TabIndex = 53;
            this.label11.Text = "Container #";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(212, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 16);
            this.label12.TabIndex = 54;
            this.label12.Text = "Bilty #";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(381, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 16);
            this.label13.TabIndex = 55;
            this.label13.Text = "Seal #";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(381, 164);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 16);
            this.label14.TabIndex = 57;
            this.label14.Text = "Driver\'s Name";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 403);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(105, 16);
            this.label16.TabIndex = 60;
            this.label16.Text = "Remarks(if any):";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(580, 164);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 16);
            this.label15.TabIndex = 62;
            this.label15.Text = "No of Bags :";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(402, 403);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 64;
            this.label3.Text = "Net Weight :";
            // 
            // cboParty
            // 
            this.cboParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParty.Enabled = false;
            this.cboParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboParty.FormattingEnabled = true;
            this.cboParty.Items.AddRange(new object[] {
            "Select Product"});
            this.cboParty.Location = new System.Drawing.Point(5, 183);
            this.cboParty.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cboParty.Name = "cboParty";
            this.cboParty.Size = new System.Drawing.Size(155, 32);
            this.cboParty.TabIndex = 66;
            this.cboParty.Visible = false;
            this.cboParty.SelectedIndexChanged += new System.EventHandler(this.cboParty_SelectedIndexChanged);
            // 
            // picBarcode
            // 
            this.picBarcode.Location = new System.Drawing.Point(322, 26);
            this.picBarcode.Name = "picBarcode";
            this.picBarcode.Size = new System.Drawing.Size(177, 77);
            this.picBarcode.TabIndex = 67;
            this.picBarcode.TabStop = false;
            // 
            // txtProduct
            // 
            this.txtProduct.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtProduct.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtProduct.Enabled = false;
            this.txtProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProduct.Location = new System.Drawing.Point(163, 184);
            this.txtProduct.Margin = new System.Windows.Forms.Padding(0);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.PlaceholderText = "";
            this.txtProduct.Size = new System.Drawing.Size(155, 29);
            this.txtProduct.TabIndex = 69;
            this.txtProduct.Visible = false;
            // 
            // txtParty
            // 
            this.txtParty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtParty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtParty.Enabled = false;
            this.txtParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtParty.Location = new System.Drawing.Point(5, 183);
            this.txtParty.Margin = new System.Windows.Forms.Padding(0);
            this.txtParty.Name = "txtParty";
            this.txtParty.PlaceholderText = "";
            this.txtParty.Size = new System.Drawing.Size(155, 29);
            this.txtParty.TabIndex = 68;
            this.txtParty.Visible = false;
            // 
            // txtTotalNetWeight
            // 
            this.txtTotalNetWeight.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtTotalNetWeight.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtTotalNetWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalNetWeight.Location = new System.Drawing.Point(483, 396);
            this.txtTotalNetWeight.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotalNetWeight.Name = "txtTotalNetWeight";
            this.txtTotalNetWeight.PlaceholderText = "";
            this.txtTotalNetWeight.ReadOnly = true;
            this.txtTotalNetWeight.Size = new System.Drawing.Size(102, 29);
            this.txtTotalNetWeight.TabIndex = 63;
            // 
            // txtRemark
            // 
            this.txtRemark.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRemark.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtRemark.BackColor = System.Drawing.SystemColors.Window;
            this.txtRemark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemark.Location = new System.Drawing.Point(114, 394);
            this.txtRemark.Margin = new System.Windows.Forms.Padding(0);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.PlaceholderText = "";
            this.txtRemark.Size = new System.Drawing.Size(245, 29);
            this.txtRemark.TabIndex = 61;
            // 
            // txtNoOfBags
            // 
            this.txtNoOfBags.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtNoOfBags.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtNoOfBags.BackColor = System.Drawing.SystemColors.Window;
            this.txtNoOfBags.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoOfBags.Location = new System.Drawing.Point(558, 184);
            this.txtNoOfBags.Margin = new System.Windows.Forms.Padding(0);
            this.txtNoOfBags.Name = "txtNoOfBags";
            this.txtNoOfBags.PlaceholderText = "";
            this.txtNoOfBags.Size = new System.Drawing.Size(140, 29);
            this.txtNoOfBags.TabIndex = 58;
            this.txtNoOfBags.TextChanged += new System.EventHandler(this.txtNoOfBags_TextChanged);
            // 
            // txtDriverName
            // 
            this.txtDriverName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtDriverName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtDriverName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDriverName.Location = new System.Drawing.Point(323, 184);
            this.txtDriverName.Margin = new System.Windows.Forms.Padding(0);
            this.txtDriverName.Name = "txtDriverName";
            this.txtDriverName.PlaceholderText = "";
            this.txtDriverName.Size = new System.Drawing.Size(222, 29);
            this.txtDriverName.TabIndex = 56;
            this.txtDriverName.TextChanged += new System.EventHandler(this.txtDriverName_TextChanged);
            // 
            // txtSealNo
            // 
            this.txtSealNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSealNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtSealNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSealNo.Location = new System.Drawing.Point(327, 131);
            this.txtSealNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtSealNo.Name = "txtSealNo";
            this.txtSealNo.PlaceholderText = "";
            this.txtSealNo.Size = new System.Drawing.Size(155, 29);
            this.txtSealNo.TabIndex = 52;
            // 
            // txtBiltyNo
            // 
            this.txtBiltyNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBiltyNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtBiltyNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBiltyNo.Location = new System.Drawing.Point(163, 131);
            this.txtBiltyNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtBiltyNo.Name = "txtBiltyNo";
            this.txtBiltyNo.PlaceholderText = "";
            this.txtBiltyNo.Size = new System.Drawing.Size(155, 29);
            this.txtBiltyNo.TabIndex = 51;
            // 
            // txtContainerNo
            // 
            this.txtContainerNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtContainerNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtContainerNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContainerNo.Location = new System.Drawing.Point(5, 131);
            this.txtContainerNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtContainerNo.Name = "txtContainerNo";
            this.txtContainerNo.PlaceholderText = "";
            this.txtContainerNo.Size = new System.Drawing.Size(155, 29);
            this.txtContainerNo.TabIndex = 50;
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
            this.txtVehicleNo.Location = new System.Drawing.Point(163, 26);
            this.txtVehicleNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.PlaceholderText = "";
            this.txtVehicleNo.Size = new System.Drawing.Size(155, 29);
            this.txtVehicleNo.TabIndex = 1;
            // 
            // txtSerialNo
            // 
            this.txtSerialNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtSerialNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialNo.Location = new System.Drawing.Point(5, 25);
            this.txtSerialNo.Margin = new System.Windows.Forms.Padding(0);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.PlaceholderText = "";
            this.txtSerialNo.ReadOnly = true;
            this.txtSerialNo.Size = new System.Drawing.Size(155, 29);
            this.txtSerialNo.TabIndex = 8;
            this.txtSerialNo.TextChanged += new System.EventHandler(this.txtSerialNo_TextChanged);
            this.txtSerialNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSerialNo_KeyDown);
            // 
            // FrmWeighmentEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 437);
            this.Controls.Add(this.txtProduct);
            this.Controls.Add(this.txtParty);
            this.Controls.Add(this.picBarcode);
            this.Controls.Add(this.cboParty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotalNetWeight);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtNoOfBags);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtDriverName);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtSealNo);
            this.Controls.Add(this.txtBiltyNo);
            this.Controls.Add(this.txtContainerNo);
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
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbItem);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtSerialNo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWeighmentEntry";
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
        private System.Windows.Forms.ComboBox cmbItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private Controls.iTextBox txtSealNo;
        private Controls.iTextBox txtBiltyNo;
        private Controls.iTextBox txtContainerNo;
        private System.Windows.Forms.Label label14;
        private Controls.iTextBox txtDriverName;
        private Controls.iTextBox txtNoOfBags;
        private System.Windows.Forms.Label label16;
        private Controls.iTextBox txtRemark;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label3;
        private Controls.iTextBox txtTotalNetWeight;
        private System.Windows.Forms.ComboBox cboParty;
        private System.Windows.Forms.PictureBox picBarcode;
        private Controls.iTextBox txtProduct;
        private Controls.iTextBox txtParty;
    }
}