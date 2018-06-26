using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
using IWeigh;
using LibraScales.ScaleSoft;
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
    public partial class NewWeightManual : Form
    {
        string Base64;
        private Weighment _WeighmentEntry = new Weighment();
        public NewWeightManual()
        {
            InitializeComponent();
        }
        private bool ValidateWeighment() {
            bool Result = true;

            this.ep.Clear();

            if (string.IsNullOrEmpty(this.txtSerialNo.Text))
            {
                this.ep.SetError(this.txtSerialNo, "Required");
                return false;
            }
           
           
            if (this.txtVehicleNo == null || this.txtVehicleNo.Text.Trim().Length == 0)
                {
                    this.ep.SetError(this.txtVehicleNo, "Required");
                    return false;
                }

            string ticketNumber = this.txtVehicleNo.Text;
            Weighment duplicateWeighment = ReferencesHelper.GetDetailsForDuplicateSecondWeight2(ticketNumber);
            Double dupsecondweight = Convert.ToDouble(duplicateWeighment.SecondWeight);
            Double dupfirstweight = Convert.ToDouble(duplicateWeighment.FirstWeight);
            if (dupfirstweight > 0 && dupsecondweight <= 0)
            {
                MessageBox.Show("This VehicleNo is in process of second weight.");
                return false;
            }



            if (this.txtWeight.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.txtWeight, "Empty weight cannot be saved.");
                return false;
            }

            if (!this.txtWeight.Text.IsNumeric())
            {
                this.ep.SetError(this.txtWeight, "Only numeric value is allowed");
                return false;
            }

            if (this.txtWeight.Text.Trim() == "0")
            {
                this.ep.SetError(this.txtWeight, "Zero weight cannot be saved.");
                return false;
            }

            if (txtAmount.Text != null && txtAmount.Text != "")
            {
                if (!this.txtAmount.Text.IsNumeric())
                {
                    this.ep.SetError(this.txtAmount, "Only numeric value is allowed.");
                    return false;
                }
            }
           



            return Result;
        }
        public static string GetStringFromImage(Image image)
        {
            if (image != null)
            {
                ImageConverter ic = new ImageConverter();
                byte[] buffer = (byte[])ic.ConvertTo(image, typeof(byte[]));
                return Convert.ToBase64String(
                    buffer,
                    Base64FormattingOptions.InsertLineBreaks);
            }
            else
                return null;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateWeighment()) {

                string A = "000000000";
                A = A + txtSerialNo.Text;
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                picBarcode.Image = barcode.Draw(A, 50);
                Base64 = GetStringFromImage(picBarcode.Image);
                _WeighmentEntry.BarCode = Base64;
                _WeighmentEntry.ClientId = this.txtParty.Text;

                if (txtAmount.Text == null || txtAmount.Text == "")
                    _WeighmentEntry.Amount = 0;
                else
                _WeighmentEntry.Amount = Convert.ToDouble(txtAmount.Text);

                _WeighmentEntry.ProductName = txtProduct.Text;

                _WeighmentEntry.TicketDate = DateTime.Now;
                _WeighmentEntry.TicketNumber = Convert.ToInt32(this.txtSerialNo.Text);
                _WeighmentEntry.ReferenceNumber = this.txtVehicleNo.Text;

                _WeighmentEntry.DriverName = this.txtDriverName.Text;

                _WeighmentEntry.Remark = txtRemark.Text;
                _WeighmentEntry.RevisionNumber = 1;

                _WeighmentEntry.Weight = Convert.ToDouble(this.txtWeight.Text);

                _WeighmentEntry.FirstWeight = Convert.ToDouble(this.txtWeight.Text);
                _WeighmentEntry.FirstDateTime = DateTime.Now;
                _WeighmentEntry.FirstType = "Auto";
                _WeighmentEntry.SecondWeight = 0.0;
                DateTime dt = new DateTime();
                _WeighmentEntry.SecondDateTime = dt;
                _WeighmentEntry.SecondType = "";
                Boolean Manual = true;
                _WeighmentEntry.MWeight = Manual;
                _WeighmentEntry.From = txtFrom.Text;
                _WeighmentEntry.To = txtTo.Text;
                uint SerialNo = 2618208898;
                LicenseInfo rLicense = RockeyHelper.GetLicense(SerialNo);

                if (rLicense.InternalSerial == 2564932284)
                {
                    WeighmentHelper.AddWeighment(ref _WeighmentEntry, GlobalsHelper.LoggedInUser.LoginId);
                    MessageBox.Show("Data Saved Successfully..!");
                    this.Close();
                }
                else {
                    Weighment recordcount = ReferencesHelper.WeighmentRecordCount().First();
                    int record = recordcount.Id;
                    if (record <= 100)
                    {
                        WeighmentHelper.AddWeighment(ref _WeighmentEntry, GlobalsHelper.LoggedInUser.LoginId);
                        MessageBox.Show("Data Saved Successfully..!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Trial Period Over!");
                        this.Close();
                    }
                }

            }
        }

        private void NewWeightManual_Load(object sender, EventArgs e)
        {
            Weighment Weight = ReferencesHelper.GetWeight().Last();
            int Ticket = Convert.ToInt32(Weight.TicketNumber);
            int a = (Ticket) + 1;
            txtSerialNo.Text = a.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (ValidateWeighment())
            {

                string A = "000000000";
                A = A + txtSerialNo.Text;
                Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                picBarcode.Image = barcode.Draw(A, 50);
                Base64 = GetStringFromImage(picBarcode.Image);
                _WeighmentEntry.BarCode = Base64;
                _WeighmentEntry.ClientId = this.txtParty.Text;

                _WeighmentEntry.Amount = Convert.ToDouble(txtAmount.Text);
                _WeighmentEntry.ProductName = txtProduct.Text;

                _WeighmentEntry.TicketDate = DateTime.Now;
                _WeighmentEntry.TicketNumber = Convert.ToInt32(this.txtSerialNo.Text);
                _WeighmentEntry.ReferenceNumber = this.txtVehicleNo.Text;

                _WeighmentEntry.DriverName = this.txtDriverName.Text;

                _WeighmentEntry.Remark = txtRemark.Text;
                _WeighmentEntry.RevisionNumber = 1;

                _WeighmentEntry.Weight = Convert.ToDouble(this.txtWeight.Text);

                _WeighmentEntry.FirstWeight = Convert.ToDouble(this.txtWeight.Text);
                _WeighmentEntry.FirstDateTime = DateTime.Now;
                _WeighmentEntry.FirstType = "Auto";
                _WeighmentEntry.SecondWeight = 0.0;
                DateTime dt = new DateTime();
                _WeighmentEntry.SecondDateTime = dt;
                _WeighmentEntry.SecondType = "";
                Boolean Manual = true;
                _WeighmentEntry.MWeight = Manual;
                _WeighmentEntry.From = txtFrom.Text;
                _WeighmentEntry.To = txtTo.Text;

                uint SerialNo = 2618208898;
                LicenseInfo rLicense = RockeyHelper.GetLicense(SerialNo);

                if (rLicense.InternalSerial == 2564932284)
                {
                    WeighmentHelper.AddWeighment(ref _WeighmentEntry, GlobalsHelper.LoggedInUser.LoginId);
                    MessageBox.Show("Saved Successfully!");
                    Microsoft.Reporting.WinForms.ReportDataSource dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighmentListing", ReferencesHelper.GetDataTable("vwWeighmentList", " WHERE SerialNo= " + Convert.ToInt32(txtSerialNo.Text)));
                    string ReportName = "WeighmentSlip.rdlc";
                    FrmReportViewer ReportViewer = new FrmReportViewer(ReportName, null, dsReport);


                    ReportViewer.ShowDialog();
                    this.Close();
                }
                else {
                    Weighment recordcount = ReferencesHelper.WeighmentRecordCount().First();
                    int record = recordcount.Id;
                    if (record <= 100)
                    {
                     
                        WeighmentHelper.AddWeighment(ref _WeighmentEntry, GlobalsHelper.LoggedInUser.LoginId);
                        MessageBox.Show("Saved Successfully!");
                        Microsoft.Reporting.WinForms.ReportDataSource dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighmentListing", ReferencesHelper.GetDataTable("vwWeighmentList", " WHERE SerialNo= " + Convert.ToInt32(txtSerialNo.Text)));
                        string ReportName = "WeighmentSlip.rdlc";
                        FrmReportViewer ReportViewer = new FrmReportViewer(ReportName, null, dsReport);


                        ReportViewer.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Trial Period Over!");
                        this.Close();
                    }
                }

            }
        }
    }
}