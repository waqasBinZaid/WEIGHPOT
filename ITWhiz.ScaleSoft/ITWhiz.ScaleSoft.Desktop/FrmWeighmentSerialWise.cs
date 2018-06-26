using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
using static LibraScales.ScaleSoft.GlobalsHelper;
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
    public partial class FrmWeighmentSerialWise : Form
    {
        public FrmWeighmentSerialWise()
        {
            InitializeComponent();
        }

        private void FrmWeighmentSerialWise_Load(object sender, EventArgs e)
        {

        }
        private bool IsValidate()
        {
            bool Result = true;

            this.ep.Clear();

            if (this.txtSerialNo.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.txtSerialNo, "Required");
                return false;
            }

            if (!this.txtSerialNo.Text.IsNumeric())
            {
                this.ep.SetError(this.txtSerialNo, "Only Numeric values allow!");
                return false;
            }

            return Result;

        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            if (IsValidate()) {
                int ticketNumber = Convert.ToInt32(this.txtSerialNo.Text);
                Weighment duplicateWeighment = ReferencesHelper.GetDetailsForDuplicateSecondWeight(ticketNumber);
                int serial = Convert.ToInt32(duplicateWeighment.TicketNumber);
                if (serial > 0)
                {
                    FrmReportViewer ReportViewer = null;
                    Microsoft.Reporting.WinForms.ReportDataSource dsReport = null;
                    List<Microsoft.Reporting.WinForms.ReportParameter> Parameters = new List<Microsoft.Reporting.WinForms.ReportParameter>();
                    Parameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("SerialNumber", this.txtSerialNo.Text.ToString()));
                    string WhereClause = " WHERE SerialNo=" + this.txtSerialNo.Text.ToString();
                    var setting = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
                    var party = setting.Where(o => o.Id == 40).FirstOrDefault();

                    if (party.AttributeValue == "Commercial")
                    {
                        dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighmentListing", ReferencesHelper.GetDataTable("vwWeighmentList", WhereClause));
                        ReportViewer = new FrmReportViewer("CWeighmentSerialWiseSlip.rdlc", Parameters, dsReport);
                      
                        ReportViewer.ShowDialog();
                    }
                    else
                    {
                        dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighmentListing", ReferencesHelper.GetDataTable("vwWeighmentList", WhereClause));
                        ReportViewer = new FrmReportViewer("WeighmentSerialWiseSlip.rdlc", Parameters, dsReport);
                     
                        ReportViewer.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No Record Against This Serial No");
                }
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
