namespace IWeigh
{
    //partial class FrmCategoryEntry
    //{
    //    /// <summary>
    //    /// Required designer variable.
    //    /// </summary>
    //    private System.ComponentModel.IContainer components = null;

    //    /// <summary>
    //    /// Clean up any resources being used.
    //    /// </summary>
    //    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && (components != null))
    //        {
    //            components.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }

    //    #region Windows Form Designer generated code

    //    /// <summary>
    //    /// Required method for Designer support - do not modify
    //    /// the contents of this method with the code editor.
    //    /// </summary>
    //    private void InitializeComponent()
    //    {
    //        this.components = new System.ComponentModel.Container();
    //        this.label1 = new System.Windows.Forms.Label();
    //        this.label2 = new System.Windows.Forms.Label();
    //        this.chkStatus = new System.Windows.Forms.CheckBox();
    //        this.CmdCancel = new System.Windows.Forms.Button();
    //        this.CmdOK = new System.Windows.Forms.Button();
    //        this.ep = new System.Windows.Forms.ErrorProvider(this.components);
    //        this.txtName = new IWeigh.Controls.iTextBox();
    //        ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
    //        this.SuspendLayout();
    //        // 
    //        // label1
    //        // 
    //        this.label1.AutoSize = true;
    //        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    //        this.label1.Location = new System.Drawing.Point(26, 14);
    //        this.label1.Name = "label1";
    //        this.label1.Size = new System.Drawing.Size(155, 16);
    //        this.label1.TabIndex = 0;
    //        this.label1.Text = "Category Information";
    //        // 
    //        // label2
    //        // 
    //        this.label2.AutoSize = true;
    //        this.label2.Location = new System.Drawing.Point(26, 40);
    //        this.label2.Name = "label2";
    //        this.label2.Size = new System.Drawing.Size(35, 13);
    //        this.label2.TabIndex = 1;
    //        this.label2.Text = "Name";
    //        // 
    //        // chkStatus
    //        // 
    //        this.chkStatus.AutoSize = true;
    //        this.chkStatus.Checked = true;
    //        this.chkStatus.CheckState = System.Windows.Forms.CheckState.Checked;
    //        this.chkStatus.Location = new System.Drawing.Point(29, 95);
    //        this.chkStatus.Name = "chkStatus";
    //        this.chkStatus.Size = new System.Drawing.Size(56, 17);
    //        this.chkStatus.TabIndex = 4;
    //        this.chkStatus.Text = "Active";
    //        this.chkStatus.UseVisualStyleBackColor = true;
    //        // 
    //        // CmdCancel
    //        // 
    //        this.CmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
    //        this.CmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    //        this.CmdCancel.Location = new System.Drawing.Point(330, 130);
    //        this.CmdCancel.Name = "CmdCancel";
    //        this.CmdCancel.Size = new System.Drawing.Size(95, 29);
    //        this.CmdCancel.TabIndex = 6;
    //        this.CmdCancel.Text = "Cancel";
    //        this.CmdCancel.UseVisualStyleBackColor = true;
    //        this.CmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
    //        // 
    //        // CmdOK
    //        // 
    //        this.CmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    //        this.CmdOK.Location = new System.Drawing.Point(229, 130);
    //        this.CmdOK.Name = "CmdOK";
    //        this.CmdOK.Size = new System.Drawing.Size(95, 29);
    //        this.CmdOK.TabIndex = 5;
    //        this.CmdOK.Text = "OK";
    //        this.CmdOK.UseVisualStyleBackColor = true;
    //        this.CmdOK.Click += new System.EventHandler(this.CmdOK_Click);
    //        // 
    //        // ep
    //        // 
    //        this.ep.ContainerControl = this;
    //        // 
    //        // txtName
    //        // 
    //        this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
    //        this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
    //        this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
    //        this.txtName.Location = new System.Drawing.Point(29, 56);
    //        this.txtName.Name = "txtName";
    //        this.txtName.PlaceholderText = "Name";
    //        this.txtName.Size = new System.Drawing.Size(396, 21);
    //        this.txtName.TabIndex = 0;
    //        // 
    //        // FrmCategoryEntry
    //        // 
    //        //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    //        //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    //        //this.CancelButton = this.CmdCancel;
    //        //this.ClientSize = new System.Drawing.Size(453, 184);
    //        //this.Controls.Add(this.CmdCancel);
    //        //this.Controls.Add(this.CmdOK);
    //        //this.Controls.Add(this.chkStatus);
    //        //this.Controls.Add(this.txtName);
    //        //this.Controls.Add(this.label2);
    //        //this.Controls.Add(this.label1);
    //        //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
    //        //this.KeyPreview = true;
    //        //this.MaximizeBox = false;
    //        //this.MinimizeBox = false;
    //        //this.Name = "FrmCategoryEntry";
    //        //this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
    //        //this.Text = "Category Information";
    //        //this.Load += new System.EventHandler(this.FrmCategoryEntry_Load);
    //        //this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCategoryEntry_KeyDown);
    //        //((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
    //        //this.ResumeLayout(false);
    //        //this.PerformLayout();

    //    }

    //    #endregion

    //    private System.Windows.Forms.Label label1;
    //    private System.Windows.Forms.Label label2;
    //    private Controls.iTextBox txtName;
    //    private System.Windows.Forms.CheckBox chkStatus;
    //    private System.Windows.Forms.Button CmdCancel;
    //    private System.Windows.Forms.Button CmdOK;
    //    private System.Windows.Forms.ErrorProvider ep;
    //}
}