namespace IWeigh
{
    partial class FrmReportViewer
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
            this.viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // viewer
            // 
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.ShowBackButton = false;
            this.viewer.ShowContextMenu = false;
            this.viewer.ShowCredentialPrompts = false;
            this.viewer.ShowDocumentMapButton = false;
            this.viewer.ShowParameterPrompts = false;
            this.viewer.Size = new System.Drawing.Size(284, 261);
            this.viewer.TabIndex = 0;
            this.viewer.PrintingBegin += new Microsoft.Reporting.WinForms.ReportPrintEventHandler(this.viewer_PrintingBegin);
            this.viewer.Load += new System.EventHandler(this.viewer_Load);
            // 
            // FrmReportViewer
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.viewer);
            this.KeyPreview = true;
            this.Name = "FrmReportViewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmReportViewer_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer viewer;
    }
}