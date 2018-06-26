using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
using IWeigh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITWhiz.ScaleSoft.Desktop
{
    public partial class FrmWeighmentDateWiseReport : Form
    {
        public FrmWeighmentDateWiseReport()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ///////////
            DateTime fromdat = Convert.ToDateTime(this.FromDatePicker.Value.ToString());    
            DateTime todat=   Convert.ToDateTime(this.ToDatePicker.Value.ToString());
            todat = todat.AddHours(24);
            if (todat >= fromdat)
            {
                FrmReportViewer ReportViewer = null;
                Microsoft.Reporting.WinForms.ReportDataSource dsReport = null;
                List<Microsoft.Reporting.WinForms.ReportParameter> Parameters = new List<Microsoft.Reporting.WinForms.ReportParameter>();
                Parameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("FromDate", this.FromDatePicker.Value.ToString()));
                Parameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("ToDate", todat.ToString()));
                string WhereClause = " WHERE SecondDateTime >=  '" + this.FromDatePicker.Value.ToString("yyyy-MM-dd hh:mm") + "' AND SecondDateTime <= '" + todat.ToString("yyyy-MM-dd hh:mm") + "' ";

                dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighment", ReferencesHelper.GetDataTable("vwWeighmentList", WhereClause));

                var setting = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
                var party = setting.Where(o => o.Id == 40).FirstOrDefault();

                if (party.AttributeValue == "Commercial")
                {
                    ReportViewer = new FrmReportViewer("CWeighmentDateWise.rdlc", Parameters, dsReport);
                }
                else {
                    ReportViewer = new FrmReportViewer("WeighmentDateWise.rdlc", Parameters, dsReport);
                }
                ReportViewer.ShowDialog();
            }
            else {

                MessageBox.Show("ToDate Should Be Equal Or Greater Than FromDate.");
            }
            
            ////////
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmWeighmentDateWiseReport_Load(object sender, EventArgs e)
        {

        }
    }
}
