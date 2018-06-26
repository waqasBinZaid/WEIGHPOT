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
    public partial class FrmWeighmentUserWiseReport : Form
    {
        public FrmWeighmentUserWiseReport()
        {
            InitializeComponent();
            InitUser();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void InitUser() {
            List<User> users = ReferencesHelper.GetUsers();

            users = users.ToList();
            users.Add(new User() { LoginId = string.Empty });

            this.cmbUser.DataSource = users;
            this.cmbUser.DisplayMember = "LoginId";
            this.cmbUser.ValueMember = "LoginId";
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            ///////////
            string name = cmbUser.Text;
            DateTime fromdat = Convert.ToDateTime(this.FromDatePicker.Value.ToString());    
            DateTime todat=   Convert.ToDateTime(this.ToDatePicker.Value.ToString());
            
            todat = todat.AddHours(24);
            if (todat >= fromdat)
            {
                FrmReportViewer ReportViewer = null;
                Microsoft.Reporting.WinForms.ReportDataSource dsReport = null;
                List<Microsoft.Reporting.WinForms.ReportParameter> Parameters = new List<Microsoft.Reporting.WinForms.ReportParameter>();
                Parameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("FromDate", this.FromDatePicker.Value.ToString()));
                Parameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("ToDate", this.ToDatePicker.Value.ToString()));
                string WhereClause = " WHERE SecondDateTime >=  '" + this.FromDatePicker.Value.ToString("yyyy-MM-dd") + "' AND SecondDateTime <= '" + todat.ToString("yyyy-MM-dd") + "' And ModifiedBy='"+name+"'";

                dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighment", ReferencesHelper.GetDataTable("vwWeighmentList", WhereClause));
                ReportViewer = new FrmReportViewer("CWeighmentUserWise.rdlc", Parameters, dsReport);
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
