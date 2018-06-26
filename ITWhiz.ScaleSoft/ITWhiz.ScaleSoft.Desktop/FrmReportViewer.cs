using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IWeigh
{
    public partial class FrmReportViewer : Form
    {
        private string _SOURCE_REPORT = string.Empty;
        private List<Microsoft.Reporting.WinForms.ReportParameter> _Parameters = null;
        private Microsoft.Reporting.WinForms.ReportDataSource _DataSource = null;

        public FrmReportViewer()
        {
            InitializeComponent();
        }

        public FrmReportViewer(string SourceReport)
        {
            InitializeComponent();
            _SOURCE_REPORT = SourceReport;
        }

        public FrmReportViewer(string SourceReport, List<Microsoft.Reporting.WinForms.ReportParameter> Parameters, Microsoft.Reporting.WinForms.ReportDataSource DataSource)
        {
            InitializeComponent();
            _SOURCE_REPORT = SourceReport;
            _Parameters = Parameters;
            _DataSource = DataSource;
        }

        private void FrmReportViewer_Load(object sender, EventArgs e)
        {
            string wanted_path = Environment.CurrentDirectory; //Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            this.viewer.LocalReport.ReportPath = wanted_path + @"\Reports\" + _SOURCE_REPORT;
            this.viewer.LocalReport.ReportEmbeddedResource = _SOURCE_REPORT;
            this.viewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            
            this.viewer.LocalReport.Refresh();
            if (_Parameters != null)
               this.viewer.LocalReport.SetParameters(_Parameters);

            if (_DataSource != null)
                this.viewer.LocalReport.DataSources.Add(_DataSource);

            this.viewer.RefreshReport();

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.P))
            {
                viewer.PrintDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void viewer_PrintingBegin(object sender, Microsoft.Reporting.WinForms.ReportPrintEventArgs e)
        {

        }

        private void viewer_Load(object sender, EventArgs e)
        {

        }
    }
}
