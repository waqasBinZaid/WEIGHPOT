using ITWhiz.ScaleSoft.BusinessOperations;
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
    public partial class DailyReportViewer : Form
    {
        public DailyReportViewer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime fromdat = Convert.ToDateTime(this.dateTimePicker1.Value.ToString());
            DateTime todat = Convert.ToDateTime(this.dateTimePicker2.Value.ToString());
            todat = todat.AddHours(12);
            if (todat >= fromdat)
            {
                FrmReportViewer ReportViewer = null;
                Microsoft.Reporting.WinForms.ReportDataSource dsReport = null;
                List<Microsoft.Reporting.WinForms.ReportParameter> Parameters = new List<Microsoft.Reporting.WinForms.ReportParameter>();
                Parameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("FromDate", this.dateTimePicker1.Value.ToString()));
                Parameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("ToDate", todat.ToString()));
                string WhereClause = " WHERE DATE(CreatedOn) >=  '" + this.dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' AND DATE(CreatedOn) <= '" + todat.ToString("yyyy-MM-dd") + "' ";

                dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsDaily", ReferencesHelper.GetDataTable("Weighment", WhereClause));
                ReportViewer = new FrmReportViewer("Daily.rdlc", Parameters, dsReport);
                ReportViewer.ShowDialog();
            }
            else
            {

                MessageBox.Show("ToDate Should Be Equal Or Greater Than FromDate.");
            }
        }
    }
}
