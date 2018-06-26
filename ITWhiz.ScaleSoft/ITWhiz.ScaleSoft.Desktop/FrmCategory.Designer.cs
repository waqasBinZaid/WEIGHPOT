namespace IWeigh
{
    //partial class FrmCategory
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
    //        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCategory));
    //        this.tsActions = new System.Windows.Forms.ToolStrip();
    //        this.tsbEdit = new System.Windows.Forms.ToolStripButton();
    //        this.tsbNew = new System.Windows.Forms.ToolStripButton();
    //        this.lst = new System.Windows.Forms.ListView();
    //        this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
    //        this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
    //        this.tsActions.SuspendLayout();
    //        this.SuspendLayout();
    //        // 
    //        // tsActions
    //        // 
    //        this.tsActions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
    //        this.tsActions.ImageScalingSize = new System.Drawing.Size(32, 32);
    //        this.tsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
    //        this.tsbEdit,
    //        this.tsbNew});
    //        this.tsActions.Location = new System.Drawing.Point(0, 0);
    //        this.tsActions.Name = "tsActions";
    //        this.tsActions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
    //        this.tsActions.Size = new System.Drawing.Size(284, 39);
    //        this.tsActions.TabIndex = 0;
    //        // 
    //        // tsbEdit
    //        // 
    //        this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
    //        this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
    //        this.tsbEdit.Name = "tsbEdit";
    //        this.tsbEdit.Size = new System.Drawing.Size(63, 36);
    //        this.tsbEdit.Text = "&Edit";
    //        this.tsbEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
    //        //this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
    //        // 
    //        // tsbNew
    //        // 
    //        this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
    //        this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
    //        this.tsbNew.Name = "tsbNew";
    //        this.tsbNew.Size = new System.Drawing.Size(67, 36);
    //        this.tsbNew.Text = "&New";
    //        this.tsbNew.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
    //        this.tsbNew.ToolTipText = "Add a new record";
    //        //this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
    //        // 
    //        // lst
    //        // 
    //        this.lst.Activation = System.Windows.Forms.ItemActivation.OneClick;
    //        this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
    //        this.colName,
    //        this.colStatus});
    //        this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
    //        this.lst.FullRowSelect = true;
    //        this.lst.GridLines = true;
    //        this.lst.HoverSelection = true;
    //        this.lst.Location = new System.Drawing.Point(0, 39);
    //        this.lst.MultiSelect = false;
    //        this.lst.Name = "lst";
    //        this.lst.ShowGroups = false;
    //        this.lst.Size = new System.Drawing.Size(284, 222);
    //        this.lst.Sorting = System.Windows.Forms.SortOrder.Ascending;
    //        this.lst.TabIndex = 1;
    //        this.lst.UseCompatibleStateImageBehavior = false;
    //        this.lst.View = System.Windows.Forms.View.Details;
    //        this.lst.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lst_ColumnClick);
    //        //this.lst.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDoubleClick);
    //        // 
    //        // colName
    //        // 
    //        this.colName.Text = "Name";
    //        this.colName.Width = 200;
    //        // 
    //        // colStatus
    //        // 
    //        this.colStatus.Text = "Status";
    //        // 
    //        // FrmCategory
    //        // 
    //        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
    //        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    //        this.AutoSize = true;
    //        this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
    //        this.ClientSize = new System.Drawing.Size(284, 261);
    //        this.ControlBox = false;
    //        this.Controls.Add(this.lst);
    //        this.Controls.Add(this.tsActions);
    //        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
    //        this.HelpButton = true;
    //        this.MaximizeBox = false;
    //        this.MinimizeBox = false;
    //        this.Name = "FrmCategory";
    //        this.ShowIcon = false;
    //        this.ShowInTaskbar = false;
    //        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
    //        this.Text = "Categories";
    //        this.TopMost = true;
    //        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
    //        this.tsActions.ResumeLayout(false);
    //        this.tsActions.PerformLayout();
    //        this.ResumeLayout(false);
    //        this.PerformLayout();

    //    }

    //    #endregion

    //    private System.Windows.Forms.ToolStrip tsActions;
    //    private System.Windows.Forms.ToolStripButton tsbEdit;
    //    private System.Windows.Forms.ToolStripButton tsbNew;
    //    private System.Windows.Forms.ListView lst;
    //    private System.Windows.Forms.ColumnHeader colName;
    //    private System.Windows.Forms.ColumnHeader colStatus;
    //}
}