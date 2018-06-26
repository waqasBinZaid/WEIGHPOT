namespace IWeigh
{
    partial class FrmWeighments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWeighments));
            this.tsActions = new System.Windows.Forms.ToolStrip();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbNew = new System.Windows.Forms.ToolStripButton();
            this.lst = new System.Windows.Forms.ListView();
            this.colParty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTicketNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReference = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsActions
            // 
            this.tsActions.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsActions.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefresh,
            this.tsbPrint,
            this.tsbEdit,
            this.tsbNew});
            this.tsActions.Location = new System.Drawing.Point(0, 0);
            this.tsActions.Name = "tsActions";
            this.tsActions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tsActions.Size = new System.Drawing.Size(717, 39);
            this.tsActions.TabIndex = 0;
            // 
            // tsbPrint
            // 
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(68, 36);
            this.tsbPrint.Text = "&Print";
            this.tsbPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(63, 36);
            this.tsbEdit.Text = "&Edit";
            this.tsbEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbNew
            // 
            this.tsbNew.Image = ((System.Drawing.Image)(resources.GetObject("tsbNew.Image")));
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(67, 36);
            this.tsbNew.Text = "&New";
            this.tsbNew.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsbNew.ToolTipText = "Add a new record";
            this.tsbNew.Click += new System.EventHandler(this.tsbNew_Click);
            // 
            // lst
            // 
            this.lst.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colParty,
            this.colDate,
            this.colTicketNumber,
            this.colReference});
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.FullRowSelect = true;
            this.lst.GridLines = true;
            this.lst.HoverSelection = true;
            this.lst.Location = new System.Drawing.Point(0, 39);
            this.lst.MultiSelect = false;
            this.lst.Name = "lst";
            this.lst.ShowGroups = false;
            this.lst.Size = new System.Drawing.Size(717, 341);
            this.lst.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lst.TabIndex = 1;
            this.lst.UseCompatibleStateImageBehavior = false;
            this.lst.View = System.Windows.Forms.View.Details;
            this.lst.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lst_ColumnClick);
            this.lst.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_MouseDoubleClick);
            // 
            // colParty
            // 
            this.colParty.DisplayIndex = 1;
            this.colParty.Text = "Party";
            this.colParty.Width = 280;
            // 
            // colDate
            // 
            this.colDate.DisplayIndex = 0;
            this.colDate.Text = "Date";
            this.colDate.Width = 140;
            // 
            // colTicketNumber
            // 
            this.colTicketNumber.Text = "Ticket Number";
            this.colTicketNumber.Width = 130;
            // 
            // colReference
            // 
            this.colReference.Text = "Reference Number";
            this.colReference.Width = 130;
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(82, 36);
            this.tsbRefresh.Text = "&Refresh";
            this.tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // FrmWeighments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(717, 380);
            this.ControlBox = false;
            this.Controls.Add(this.lst);
            this.Controls.Add(this.tsActions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWeighments";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Weighments";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tsActions.ResumeLayout(false);
            this.tsActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsActions;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbNew;
        private System.Windows.Forms.ListView lst;
        private System.Windows.Forms.ColumnHeader colParty;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colReference;
        private System.Windows.Forms.ColumnHeader colTicketNumber;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
    }
}