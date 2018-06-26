namespace IWeigh
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.ToptoolbarItems = new System.Windows.Forms.ToolStrip();
            this.tsWeighments = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiWeighmentEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUpdateWeighmentEntry = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsddProducts = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiParties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiReports = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiWeigmentSerialWise = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWeigmentDateWise = new System.Windows.Forms.ToolStripMenuItem();
            this.weighmentUserWiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAdministration = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiSystemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiUser = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSep = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAboutSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.tsHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.toolbarIcons = new System.Windows.Forms.ImageList(this.components);
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.tsslMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslUserRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveBackupFile = new System.Windows.Forms.SaveFileDialog();
            this.openRestoreFile = new System.Windows.Forms.OpenFileDialog();
            this.companySettigsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secondWeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thirdWeightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToptoolbarItems.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToptoolbarItems
            // 
            this.ToptoolbarItems.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.ToptoolbarItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsWeighments,
            this.toolStripSeparator1,
            this.tsddProducts,
            this.toolStripSeparator2,
            this.tsmiReports,
            this.toolStripSeparator4,
            this.tsbAdministration,
            this.tsHelp,
            this.toolStripSeparator5,
            this.tsbExit});
            this.ToptoolbarItems.Location = new System.Drawing.Point(0, 0);
            this.ToptoolbarItems.Name = "ToptoolbarItems";
            this.ToptoolbarItems.Size = new System.Drawing.Size(1184, 71);
            this.ToptoolbarItems.Stretch = true;
            this.ToptoolbarItems.TabIndex = 1;
            // 
            // tsWeighments
            // 
            this.tsWeighments.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiWeighmentEntry,
            this.secondWeightToolStripMenuItem,
            this.thirdWeightToolStripMenuItem,
            this.tsmiUpdateWeighmentEntry});
            this.tsWeighments.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsWeighments.Image = global::ITWhiz.ScaleSoft.Desktop.Properties.Resources._1438447545_autoship;
            this.tsWeighments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsWeighments.Name = "tsWeighments";
            this.tsWeighments.Size = new System.Drawing.Size(162, 68);
            this.tsWeighments.Text = "&Weighment";
            this.tsWeighments.Click += new System.EventHandler(this.tsWeighments_Click);
            // 
            // tsmiWeighmentEntry
            // 
            this.tsmiWeighmentEntry.Name = "tsmiWeighmentEntry";
            this.tsmiWeighmentEntry.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.tsmiWeighmentEntry.Size = new System.Drawing.Size(259, 24);
            this.tsmiWeighmentEntry.Text = "First Weight";
            this.tsmiWeighmentEntry.Click += new System.EventHandler(this.tsmiWeighmentEntry_Click);
            // 
            // tsmiUpdateWeighmentEntry
            // 
            this.tsmiUpdateWeighmentEntry.Name = "tsmiUpdateWeighmentEntry";
            this.tsmiUpdateWeighmentEntry.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.U)));
            this.tsmiUpdateWeighmentEntry.Size = new System.Drawing.Size(259, 24);
            this.tsmiUpdateWeighmentEntry.Text = "Weighment Update";
            this.tsmiUpdateWeighmentEntry.Click += new System.EventHandler(this.tsmiUpdateWeighmentEntry_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 71);
            // 
            // tsddProducts
            // 
            this.tsddProducts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiProducts,
            this.tsmiParties});
            this.tsddProducts.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsddProducts.Image = global::ITWhiz.ScaleSoft.Desktop.Properties.Resources._1447724089_inventory_maintenance;
            this.tsddProducts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddProducts.Name = "tsddProducts";
            this.tsddProducts.Size = new System.Drawing.Size(176, 68);
            this.tsddProducts.Text = "&Manage Data";
            this.tsddProducts.Click += new System.EventHandler(this.tsddProducts_Click);
            // 
            // tsmiProducts
            // 
            this.tsmiProducts.Name = "tsmiProducts";
            this.tsmiProducts.Size = new System.Drawing.Size(135, 24);
            this.tsmiProducts.Text = "Products";
            this.tsmiProducts.Click += new System.EventHandler(this.tsmiProducts_Click);
            // 
            // tsmiParties
            // 
            this.tsmiParties.Name = "tsmiParties";
            this.tsmiParties.Size = new System.Drawing.Size(135, 24);
            this.tsmiParties.Text = "Parties";
            this.tsmiParties.Click += new System.EventHandler(this.tsmiParties_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 71);
            // 
            // tsmiReports
            // 
            this.tsmiReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiWeigmentSerialWise,
            this.tsmiWeigmentDateWise,
            this.weighmentUserWiseToolStripMenuItem});
            this.tsmiReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsmiReports.Image = ((System.Drawing.Image)(resources.GetObject("tsmiReports.Image")));
            this.tsmiReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsmiReports.Name = "tsmiReports";
            this.tsmiReports.Size = new System.Drawing.Size(141, 68);
            this.tsmiReports.Text = "&Reports";
            this.tsmiReports.ToolTipText = "Reports";
            this.tsmiReports.Click += new System.EventHandler(this.tsmiReports_Click);
            // 
            // tsmiWeigmentSerialWise
            // 
            this.tsmiWeigmentSerialWise.Name = "tsmiWeigmentSerialWise";
            this.tsmiWeigmentSerialWise.Size = new System.Drawing.Size(226, 26);
            this.tsmiWeigmentSerialWise.Text = "WeigmentSerialWise";
            this.tsmiWeigmentSerialWise.Click += new System.EventHandler(this.tsmiWeigmentSerialWise_Click);
            // 
            // tsmiWeigmentDateWise
            // 
            this.tsmiWeigmentDateWise.Name = "tsmiWeigmentDateWise";
            this.tsmiWeigmentDateWise.Size = new System.Drawing.Size(226, 26);
            this.tsmiWeigmentDateWise.Text = "WeighmentDateWise";
            this.tsmiWeigmentDateWise.Click += new System.EventHandler(this.tsmiWeigmentDateWise_Click);
            // 
            // weighmentUserWiseToolStripMenuItem
            // 
            this.weighmentUserWiseToolStripMenuItem.Name = "weighmentUserWiseToolStripMenuItem";
            this.weighmentUserWiseToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.weighmentUserWiseToolStripMenuItem.Text = "WeighmentUserWise";
            this.weighmentUserWiseToolStripMenuItem.Click += new System.EventHandler(this.weighmentUserWiseToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 71);
            // 
            // tsbAdministration
            // 
            this.tsbAdministration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSystemSettings,
            this.toolStripSeparator3,
            this.tsmiUser,
            this.tsmiSep,
            this.tsmiBackup,
            this.restoreToolStripMenuItem,
            this.tsmiAboutSettings,
            this.companySettigsToolStripMenuItem});
            this.tsbAdministration.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbAdministration.Image = global::ITWhiz.ScaleSoft.Desktop.Properties.Resources._1438447704_1_08;
            this.tsbAdministration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdministration.Name = "tsbAdministration";
            this.tsbAdministration.Size = new System.Drawing.Size(184, 68);
            this.tsbAdministration.Text = "&Administration";
            this.tsbAdministration.ToolTipText = "Administration";
            this.tsbAdministration.Click += new System.EventHandler(this.tsbAdministration_Click);
            // 
            // tsmiSystemSettings
            // 
            this.tsmiSystemSettings.Name = "tsmiSystemSettings";
            this.tsmiSystemSettings.Size = new System.Drawing.Size(186, 24);
            this.tsmiSystemSettings.Text = "System Settings";
            this.tsmiSystemSettings.Click += new System.EventHandler(this.tsmiSystemSettings_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(183, 6);
            // 
            // tsmiUser
            // 
            this.tsmiUser.Name = "tsmiUser";
            this.tsmiUser.Size = new System.Drawing.Size(186, 24);
            this.tsmiUser.Text = "User";
            this.tsmiUser.Click += new System.EventHandler(this.tsmiUser_Click);
            // 
            // tsmiSep
            // 
            this.tsmiSep.Name = "tsmiSep";
            this.tsmiSep.Size = new System.Drawing.Size(183, 6);
            // 
            // tsmiBackup
            // 
            this.tsmiBackup.Name = "tsmiBackup";
            this.tsmiBackup.Size = new System.Drawing.Size(186, 24);
            this.tsmiBackup.Text = "Backup";
            this.tsmiBackup.Click += new System.EventHandler(this.tsmiBackup_Click);
            // 
            // restoreToolStripMenuItem
            // 
            this.restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            this.restoreToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.restoreToolStripMenuItem.Text = "Restore";
            this.restoreToolStripMenuItem.Click += new System.EventHandler(this.tsmiRestore_Click);
            // 
            // tsmiAboutSettings
            // 
            this.tsmiAboutSettings.Name = "tsmiAboutSettings";
            this.tsmiAboutSettings.Size = new System.Drawing.Size(186, 24);
            this.tsmiAboutSettings.Text = "About";
            this.tsmiAboutSettings.Click += new System.EventHandler(this.tsmiAboutSettings_Click);
            // 
            // tsHelp
            // 
            this.tsHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout,
            this.tsmiExit});
            this.tsHelp.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsHelp.Image = global::ITWhiz.ScaleSoft.Desktop.Properties.Resources._1438447979_help_browser;
            this.tsHelp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsHelp.Name = "tsHelp";
            this.tsHelp.Size = new System.Drawing.Size(118, 68);
            this.tsHelp.Text = "&Help";
            this.tsHelp.Visible = false;
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Image = global::ITWhiz.ScaleSoft.Desktop.Properties.Resources._1438448241_Information;
            this.tsmiAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(171, 38);
            this.tsmiAbout.Text = "About";
            // 
            // tsmiExit
            // 
            this.tsmiExit.Image = global::ITWhiz.ScaleSoft.Desktop.Properties.Resources._1438448300_Exit;
            this.tsmiExit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.tsmiExit.Size = new System.Drawing.Size(171, 38);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 71);
            // 
            // tsbExit
            // 
            this.tsbExit.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(101, 68);
            this.tsbExit.Text = "&Exit";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // toolbarIcons
            // 
            this.toolbarIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolbarIcons.ImageStream")));
            this.toolbarIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.toolbarIcons.Images.SetKeyName(0, "1438446911_TruckYellow.png");
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMessage,
            this.tsslUser,
            this.tsslUserRole});
            this.statusBar.Location = new System.Drawing.Point(0, 711);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1184, 22);
            this.statusBar.TabIndex = 3;
            // 
            // tsslMessage
            // 
            this.tsslMessage.AutoSize = false;
            this.tsslMessage.AutoToolTip = true;
            this.tsslMessage.Image = global::ITWhiz.ScaleSoft.Desktop.Properties.Resources._1438448241_Information;
            this.tsslMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsslMessage.Name = "tsslMessage";
            this.tsslMessage.Size = new System.Drawing.Size(853, 17);
            this.tsslMessage.Spring = true;
            this.tsslMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslUser
            // 
            this.tsslUser.AutoSize = false;
            this.tsslUser.AutoToolTip = true;
            this.tsslUser.Image = global::ITWhiz.ScaleSoft.Desktop.Properties.Resources._1438440898_2;
            this.tsslUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsslUser.Name = "tsslUser";
            this.tsslUser.Size = new System.Drawing.Size(300, 17);
            this.tsslUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsslUser.ToolTipText = "Logged-In User";
            // 
            // tsslUserRole
            // 
            this.tsslUserRole.Image = global::ITWhiz.ScaleSoft.Desktop.Properties.Resources._1452972623_f_shield_256;
            this.tsslUserRole.Name = "tsslUserRole";
            this.tsslUserRole.Size = new System.Drawing.Size(16, 17);
            this.tsslUserRole.ToolTipText = "User Security Role";
            // 
            // saveBackupFile
            // 
            this.saveBackupFile.ShowHelp = true;
            this.saveBackupFile.Title = "Select Database Backup Location";
            // 
            // openRestoreFile
            // 
            this.openRestoreFile.AddExtension = false;
            this.openRestoreFile.DefaultExt = "*.db3";
            // 
            // companySettigsToolStripMenuItem
            // 
            this.companySettigsToolStripMenuItem.Name = "companySettigsToolStripMenuItem";
            this.companySettigsToolStripMenuItem.Size = new System.Drawing.Size(186, 24);
            this.companySettigsToolStripMenuItem.Text = "CompanySettigs";
            this.companySettigsToolStripMenuItem.Click += new System.EventHandler(this.companySettigsToolStripMenuItem_Click);
            // 
            // secondWeightToolStripMenuItem
            // 
            this.secondWeightToolStripMenuItem.Name = "secondWeightToolStripMenuItem";
            this.secondWeightToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.secondWeightToolStripMenuItem.Size = new System.Drawing.Size(259, 24);
            this.secondWeightToolStripMenuItem.Text = "Second Weight";
            this.secondWeightToolStripMenuItem.Click += new System.EventHandler(this.secondWeightToolStripMenuItem_Click);
            // 
            // thirdWeightToolStripMenuItem
            // 
            this.thirdWeightToolStripMenuItem.Name = "thirdWeightToolStripMenuItem";
            this.thirdWeightToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.thirdWeightToolStripMenuItem.Size = new System.Drawing.Size(259, 24);
            this.thirdWeightToolStripMenuItem.Text = "Third Weight";
            this.thirdWeightToolStripMenuItem.Click += new System.EventHandler(this.thirdWeightToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 733);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.ToptoolbarItems);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WeighPot - IBTS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ToptoolbarItems.ResumeLayout(false);
            this.ToptoolbarItems.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToptoolbarItems;
        private System.Windows.Forms.ImageList toolbarIcons;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton tsHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        public System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripDropDownButton tsbAdministration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator tsmiSep;
        private System.Windows.Forms.SaveFileDialog saveBackupFile;
        private System.Windows.Forms.OpenFileDialog openRestoreFile;
        private System.Windows.Forms.ToolStripStatusLabel tsslUser;
        private System.Windows.Forms.ToolStripDropDownButton tsWeighments;
        private System.Windows.Forms.ToolStripMenuItem tsmiWeighmentEntry;
        private System.Windows.Forms.ToolStripDropDownButton tsddProducts;
        //private System.Windows.Forms.ToolStripMenuItem tsmiPCategory;
        private System.Windows.Forms.ToolStripMenuItem tsmiProducts;
        private System.Windows.Forms.ToolStripMenuItem tsmiSystemSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiAboutSettings;
        private System.Windows.Forms.ToolStripStatusLabel tsslUserRole;
        private System.Windows.Forms.ToolStripStatusLabel tsslMessage;
        private System.Windows.Forms.ToolStripMenuItem tsmiParties;
        private System.Windows.Forms.ToolStripDropDownButton tsmiReports;
        private System.Windows.Forms.ToolStripMenuItem tsmiWeigmentDateWise;
        private System.Windows.Forms.ToolStripMenuItem tsmiWeigmentSerialWise;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdateWeighmentEntry;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackup;
        private System.Windows.Forms.ToolStripMenuItem restoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weighmentUserWiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companySettigsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secondWeightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thirdWeightToolStripMenuItem;
    }
}