namespace IWeigh
{
    partial class FrmSecurityRoleEntry
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
            this.CmdCancel = new System.Windows.Forms.Button();
            this.CmdOK = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.dgv = new System.Windows.Forms.DataGridView();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.Module = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubModule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Read = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Write = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtName = new IWeigh.Controls.iTextBox();
            this.chkReadAll = new System.Windows.Forms.CheckBox();
            this.chkWriteAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Security Role Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // CmdCancel
            // 
            this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdCancel.Location = new System.Drawing.Point(449, 393);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(95, 29);
            this.CmdCancel.TabIndex = 6;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // CmdOK
            // 
            this.CmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdOK.Location = new System.Drawing.Point(348, 393);
            this.CmdOK.Name = "CmdOK";
            this.CmdOK.Size = new System.Drawing.Size(95, 29);
            this.CmdOK.TabIndex = 5;
            this.CmdOK.Text = "OK";
            this.CmdOK.UseVisualStyleBackColor = true;
            this.CmdOK.Click += new System.EventHandler(this.CmdOK_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Module,
            this.SubModule,
            this.Read,
            this.Write,
            this.colKey});
            this.dgv.Location = new System.Drawing.Point(29, 107);
            this.dgv.Name = "dgv";
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(516, 277);
            this.dgv.TabIndex = 7;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Checked = true;
            this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkStatus.Location = new System.Drawing.Point(29, 401);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(56, 17);
            this.chkStatus.TabIndex = 8;
            this.chkStatus.Text = "Active";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // Module
            // 
            this.Module.HeaderText = "Module";
            this.Module.Name = "Module";
            this.Module.ReadOnly = true;
            this.Module.Width = 175;
            // 
            // SubModule
            // 
            this.SubModule.HeaderText = "Sub-Module";
            this.SubModule.Name = "SubModule";
            this.SubModule.ReadOnly = true;
            this.SubModule.Width = 175;
            // 
            // Read
            // 
            this.Read.HeaderText = "Read";
            this.Read.Name = "Read";
            this.Read.ReadOnly = true;
            this.Read.Width = 50;
            // 
            // Write
            // 
            this.Write.HeaderText = "Write";
            this.Write.Name = "Write";
            this.Write.ReadOnly = true;
            this.Write.Width = 50;
            // 
            // colKey
            // 
            this.colKey.HeaderText = "colKey";
            this.colKey.Name = "colKey";
            this.colKey.Visible = false;
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(29, 56);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Name";
            this.txtName.Size = new System.Drawing.Size(516, 21);
            this.txtName.TabIndex = 0;
            // 
            // chkReadAll
            // 
            this.chkReadAll.AutoSize = true;
            this.chkReadAll.Location = new System.Drawing.Point(434, 91);
            this.chkReadAll.Name = "chkReadAll";
            this.chkReadAll.Size = new System.Drawing.Size(15, 14);
            this.chkReadAll.TabIndex = 9;
            this.chkReadAll.UseVisualStyleBackColor = true;
            this.chkReadAll.CheckedChanged += new System.EventHandler(this.chkReadAll_CheckedChanged);
            // 
            // chkWriteAll
            // 
            this.chkWriteAll.AutoSize = true;
            this.chkWriteAll.Location = new System.Drawing.Point(479, 91);
            this.chkWriteAll.Name = "chkWriteAll";
            this.chkWriteAll.Size = new System.Drawing.Size(15, 14);
            this.chkWriteAll.TabIndex = 10;
            this.chkWriteAll.UseVisualStyleBackColor = true;
            this.chkWriteAll.CheckedChanged += new System.EventHandler(this.chkWriteAll_CheckedChanged);
            // 
            // FrmSecurityRoleEntry
            // 
            this.AcceptButton = this.CmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CmdCancel;
            this.ClientSize = new System.Drawing.Size(576, 445);
            this.Controls.Add(this.chkWriteAll);
            this.Controls.Add(this.chkReadAll);
            this.Controls.Add(this.chkStatus);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdOK);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSecurityRoleEntry";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Security Role Information";
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controls.iTextBox txtName;
        private System.Windows.Forms.Button CmdCancel;
        private System.Windows.Forms.Button CmdOK;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Module;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubModule;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Read;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Write;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.CheckBox chkWriteAll;
        private System.Windows.Forms.CheckBox chkReadAll;
    }
}