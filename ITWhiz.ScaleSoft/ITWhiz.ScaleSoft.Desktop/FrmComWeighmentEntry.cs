using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
using ITWhiz.ScaleSoft.Desktop.Controls;
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
using MailKit;
using MailKit.Net.Smtp;
using ITWhiz;
using ITWhiz.ScaleSoft;
using static LibraScales.ScaleSoft.GlobalsHelper;
using MimeKit;
using System.Net.Http;
using System.IO;
using System.Net;
using System.IO.Ports;
using System.Threading;
using ITWhiz.ScaleSoft.Desktop;
using ITWhiz.ScaleSoft.Common;


namespace IWeigh
{
    public partial class FrmComWeighmentEntry : Form
    {
        private List<Product> _Products = null;
        private Weighment _WeighmentEntry = new Weighment();
        private UIMode _UIMode = UIMode.NEW_RECORD;
        bool PricingMode = false;
        bool AllowManualWeighment = false;

        private string RawDataFromIndicator = string.Empty;
        private string FilteredDataFromIndicator = string.Empty;

        private double fwght = 0.0;
        private int datacontrol = 0;
        private int ControlCharacter = 2; // 0
        private string FilterDirection = "Left"; // R
        private int FilteredStartIndex = 1; // 0
        private int FilterByteSize = 7;  // 5
        private int ReadDelay = 1; // milli seconds
        private int wId = 0;
        private int wprodId = 0;
        private double swght = 0.0;
        private DateTime sdatetime;
        private string stype = "";
        private double netWeight = 0;
        private DateTime fdatetime;
        private string ftype = "";
        private double result = 0;
        private static System.IO.Ports.SerialPort spIndicator;
        private static string Base64;
        private Globals.WEIGHMENT_ENTRY _weighmentEntry;

    
        public FrmComWeighmentEntry()
        {
            InitializeComponent();
            spIndicator = new System.IO.Ports.SerialPort();
            spIndicator.ReadBufferSize  = 1024;

           
            SetUIMode();
            InitParty();
            InitProducts();
            InitIndicatorSettings();
            _weighmentEntry = Globals.WEIGHMENT_ENTRY.FIRST;
           

        }

        public FrmComWeighmentEntry(Globals.WEIGHMENT_ENTRY weighmentEntry)
        {
            InitializeComponent();

            

            _weighmentEntry = weighmentEntry;
            spIndicator = new System.IO.Ports.SerialPort();

           
            SetUIMode();
            InitParty();
            InitProducts();
            InitIndicatorSettings();
         

        }

        public FrmComWeighmentEntry(Weighment WeighmentEntry)
        {
            InitializeComponent();
           
            _WeighmentEntry = WeighmentEntry;
            _UIMode = UIMode.EDIT_RECORD;
            SetUIMode();
            InitParty();
            InitProducts();
        }
        public string RoundOff(string data)
        {
            string OldString = data;
            string NewString = System.Text.RegularExpressions.Regex.Replace(OldString, " {2,}", " ");
            string GetString = NewString.Trim();
            return GetString;
        }
        private void InitParty()
        {
            List<Client> clients = ReferencesHelper.GetClients();

            clients = clients.ToList();
            clients.Add(new Client() { Id = 0, Name = string.Empty });

            this.cboParty.DataSource = clients;
            this.cboParty.DisplayMember = "Name";
            this.cboParty.ValueMember = "Id";

        }
        private void InitProducts()
        {
            List<Product> products = ReferencesHelper.AllProducts();

            products = products.ToList();
            products.Add(new Product() { Name = string.Empty });

            this.cmbItem.DataSource = products;
            this.cmbItem.DisplayMember = "Name";
            this.cmbItem.ValueMember = "Name";

        }
        #region private methods

        private void AddWeighmentEntry()
        {
            if (ValidateWeighment() == false)
                return;

          

            //int serialNumber = 0;

            string timee = DateTime.Now.ToString("HH:mm:ss tt");
            string datee = (DateTime.Now).ToString("MM/dd/yyyy");
            string A = "000000000";
            A = A + txtSerialNo.Text;
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            picBarcode.Image = barcode.Draw(A,50);
            Base64 = GetStringFromImage(picBarcode.Image);
            if (_weighmentEntry == Globals.WEIGHMENT_ENTRY.FIRST)
            {
                if (datacontrol == 0)
                {
                    Weighment WeighmentDetail = new Weighment();

                    int SerialNumber = this.lst.Items.Count + 1;
                    ListViewItem item = this.lst.Items.Add(SerialNumber.ToString());
                    item.Tag = SerialNumber;

                    item.SubItems.Add("First Weight");
                    item.SubItems.Add(this.txtWeightIndicator.Text);

                    item.SubItems.Add(timee);
                    item.SubItems.Add(datee);
                    item.SubItems.Add("Auto");

                    //netWeight = 0.0;
                    //netWeight = Convert.ToDouble(this.txtWeightIndicator.Text);
                    //result = Math.Round(netWeight, 2);
                    //this.txtTotalNetWeight.Text = result.ToString();

                    //CalculateTotals();
                    SetUIAfterValidation();
                    datacontrol = 1;
                }
            }
            else
            {
                int iCounter = 2;
                ListViewItem lst = new ListViewItem(iCounter.ToString());

                lst.SubItems.Add("Second Weight");
                lst.SubItems.Add(this.txtWeightIndicator.Text.Trim());
                lst.SubItems.Add(timee);
                lst.SubItems.Add(datee);
                lst.SubItems.Add("Auto");

                this.lst.Items.Add(lst);

                double nwht = 0.0;
                nwht = Convert.ToDouble(this.txtWeightIndicator.Text);

                if (netWeight > nwht)
                {
                    netWeight = netWeight - nwht;
                    result = Math.Round(netWeight, 2);
                    this.txtTotalNetWeight.Text = result.ToString();
                }
                   
                else
                {
                    netWeight = nwht - netWeight;
                    result = Math.Round(netWeight, 2);
                    this.txtTotalNetWeight.Text = result.ToString();
                }

         

                //CalculateTotals();
            }

        }

        private void SetUIAfterValidation()
        {
            this.btnNew.Enabled = true;
        }
        private bool ValidateWeighmentDetail()
        {
            bool Result = true;

            this.ep.Clear();

            if (this.txtVehicleNo == null || this.txtVehicleNo.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.txtVehicleNo, "Vehicle is Required");
                return false;
            }

  



            if (this.txtWeightIndicator.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.txtWeightIndicator, "Zero weight cannot be saved.");
                return false;
            }

            if (!this.txtWeightIndicator.Text.IsNumeric())
            {
                this.ep.SetError(this.txtWeightIndicator, "Only numeric value is allowed");
                return false;
            }

            return Result;
        }

        private bool ValidateWeighment()
        {
            bool Result = true;

            this.ep.Clear();

            if (_weighmentEntry == Globals.WEIGHMENT_ENTRY.FIRST)
            {
                if (txtAmount.Text != null && txtAmount.Text != "") {
                    if (!this.txtAmount.Text.IsNumeric())
                    {
                        this.ep.SetError(this.txtAmount, "Only numeric value is allowed.");
                        return false;
                    }
                }
              
                if (this.txtVehicleNo == null || this.txtVehicleNo.Text.Trim().Length == 0)
                {
                    this.ep.SetError(this.txtVehicleNo, "Required");
                    return false;
                }

                string vno = this.txtVehicleNo.Text.Trim();

                int cnt = 0;

                Weighment selectedWeighment = ReferencesHelper.PendingSecondWeight(vno, cnt);

                if (cnt > 0)
                {
                    this.ep.SetError(this.txtVehicleNo, "Vehicle is already in the factory.. ");
                    return false;
                }
               

            }

            if (this.txtWeightIndicator.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.txtWeightIndicator, "Zero weight cannot be saved.");
                return false;
            }

            if (!this.txtWeightIndicator.Text.IsNumeric())
            {
                this.ep.SetError(this.txtWeightIndicator, "Only numeric value is allowed");
                return false;
            }

            if (this.txtWeightIndicator.Text.Trim() == "0")
            {
                this.ep.SetError(this.txtWeightIndicator, "Zero weight cannot be saved.");
                return false;
            }
           
            int ticketNumber = Convert.ToInt32(this.txtSerialNo.Text);
            Weighment selectedWeighments = ReferencesHelper.GetDetailsPendingForSecondWeight(ticketNumber);

            if (_weighmentEntry == Globals.WEIGHMENT_ENTRY.SECOND)

            {
              
                if (txtAmount.Text != null || txtAmount.Text != "")
                {
                    if (!this.txtAmount.Text.IsNumeric())
                    {
                        this.ep.SetError(this.txtAmount, "Only numeric value is allowed.");
                        return false;
                    }
                }
                if (txtReceivedAmount.Text != null && txtReceivedAmount.Text != "")
                {
                    if (!this.txtReceivedAmount.Text.IsNumeric())
                    {
                        this.ep.SetError(this.txtReceivedAmount, "Only numeric value is allowed.");
                        return false;
                    }
                }
            }

            return Result;
        }

        private void SetUIMode()
        {
            if (_weighmentEntry == Globals.WEIGHMENT_ENTRY.FIRST)
            {

                _WeighmentEntry = new Weighment();

                this.txtSerialNo.Focus();
                this.txtSerialNo.TabIndex = 0;
                this.txtVehicleNo.TabIndex = 1;
               
           
                this.txtParty.TabIndex = 5;
                this.txtProduct.TabIndex = 6;
                this.txtDriverName.TabIndex = 7;
             
                this.btnWeighmentEntry.TabIndex = 9;
                this.txtRemark.TabIndex = 10;
                this.CmdOK.TabIndex = 11;
                this.CmdCancel.TabIndex = 12;

                this.txtSerialNo.Text = string.Empty;
                this.txtSerialNo.Enabled = false;
                this.txtSerialNo.ReadOnly = true;
                this.txtVehicleNo.Text = string.Empty;
                this.txtVehicleNo.Enabled = true;
                this.dtpDate.Value = DateTime.Now;
                this.dtpDate.Enabled = false;

                //START.. Show Hide Party,PRODUCT  DROPDOWN AND TEXTBOX
                List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
                var party = SystemSettings.Where(o => o.Id == 41).FirstOrDefault();
                string p = RoundOff(party.AttributeValue);
                p = p.ToUpper();
                var product = SystemSettings.Where(o => o.Id == 42).FirstOrDefault();
                string pro = RoundOff(product.AttributeValue);
                pro = pro.ToUpper();
                if (p == "TRUE")
                {
                    cboParty.Visible = true;
                    this.cboParty.TabIndex = 5;
                    this.cboParty.Text = string.Empty;
                    this.cboParty.Enabled = true;
                }

                else
                {
                    txtParty.Visible = true;
                    this.txtParty.TabIndex = 5;
                    this.txtParty.Text = string.Empty;
                    this.txtParty.Enabled = true;
                }


                if (pro == "TRUE")
                {
                    cmbItem.Visible = true;
                    this.cmbItem.TabIndex = 6;
                    this.cmbItem.Text = string.Empty;
                    this.cmbItem.Enabled = true;
                }

                else
                {
                    txtProduct.Visible = true;
                    this.txtProduct.TabIndex = 6;
                    this.txtProduct.Text = string.Empty;
                    this.txtProduct.Enabled = true;
                }

                //END.. Show Hide Party,PRODUCT  DROPDOWN AND TEXTBOX   


                this.txtDriverName.Text = string.Empty;
                this.txtDriverName.Enabled = true;

                lblRemarks.Visible = false;
                txtRemark.Visible = false;
                lblNetWeight.Visible = false;
                txtTotalNetWeight.Visible = false;

                this.CmdCancel.Enabled = true;
                this.CmdOK.Visible = false;
                this.CmdOK.Enabled = false;
                this.btnNew.Visible = true;
                this.btnNew.Enabled = false;
                this.button1.Visible = false;
             
                this.lblReceivedAmount.Visible = false;
                this.txtReceivedAmount.Visible = false;
                this.lst.Items.Clear();


            }
            else if (_weighmentEntry == Globals.WEIGHMENT_ENTRY.SECOND)
            {

                this.txtSerialNo.Text = string.Empty;
                this.txtSerialNo.Enabled = true;
                this.txtSerialNo.ReadOnly = false;
                this.txtVehicleNo.Text = string.Empty;
                this.txtVehicleNo.Enabled = true;
                this.dtpDate.Value = DateTime.Now;
                this.dtpDate.Enabled = false;
       // start..party ,product dropdown, textbox configuration

                List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
                var party = SystemSettings.Where(o => o.Id == 41).FirstOrDefault();
                string p = RoundOff(party.AttributeValue);
                p = p.ToUpper();
                var product = SystemSettings.Where(o => o.Id == 42).FirstOrDefault();
                string pro = RoundOff(product.AttributeValue);
                pro = pro.ToUpper();
                if (p == "TRUE")
                {
                    cboParty.Visible = true;
                    this.cboParty.Text = string.Empty;
                    this.cboParty.Enabled = false;
                }

                else
                {
                    txtParty.Visible = true;
                    this.txtParty.Text = string.Empty;
                    this.txtParty.Enabled = false;
                }


                if (pro == "TRUE")
                {
                    cmbItem.Visible = true;
                    this.cmbItem.Text = string.Empty;
                    this.cmbItem.Enabled = false;
                }

                else
                {
                    txtProduct.Visible = true;
                    this.txtProduct.Text = string.Empty;
                    this.txtProduct.Enabled = false;
                }

          // end .. party ,product dropdown ,textbox configuration

                this.txtDriverName.Text = string.Empty;
                this.txtDriverName.Enabled = false;

                lblRemarks.Visible = true;
                txtRemark.Visible = true;
                lblNetWeight.Visible = true;
                txtTotalNetWeight.Visible = true;
                this.txtTotalNetWeight.Text = string.Empty;
                this.txtTotalNetWeight.Enabled = false;
                this.CmdCancel.Enabled = true;
                this.btnNew.Visible = false;
                this.btnNew.Enabled = false;
                this.CmdOK.Visible = true;
                this.CmdOK.Enabled = false;
                this.button1.Visible = true;
       
                this.lblReceivedAmount.Visible = true;
                this.txtReceivedAmount.Visible = true;
                this.lst.Items.Clear();
            }

        }

        private void InitIndicatorSettings()
        {
            try
            {
                if (!spIndicator.IsOpen)
                {
                    List<SystemSetting> SystemSettings = new List<SystemSetting>();

                    SystemSettings = ReferencesHelper.GetSystemSettings();

                    bool.TryParse(SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.ALLOW_MANUAL_WEIGHMENT.ToString()).FirstOrDefault().AttributeValue, out AllowManualWeighment);

                   // this.txtWeightIndicator.ReadOnly = !AllowManualWeighment;

                    if (!AllowManualWeighment)
                    {
                        ControlCharacter = int.Parse(SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.INDICATOR_CONTROL_CHARACTER.ToString()).First().AttributeValue);
                        FilterDirection = SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.INDICATOR_READ_DIRECTION.ToString()).First().AttributeValue;
                        FilteredStartIndex = int.Parse(SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.INDICATOR_FILTER_START_FROM.ToString()).First().AttributeValue);
                        FilterByteSize = int.Parse(SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.INDICATOR_FILTER_STRING_LENGTH.ToString()).First().AttributeValue); ;

                        ReadDelay = int.Parse(SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.INDICATOR_READ_DELAY.ToString()).First().AttributeValue); ;

                        spIndicator.DataReceived += spIndicator_DataReceived;
                        spIndicator.ErrorReceived += spIndicator_ErrorReceived;
                        spIndicator.ReceivedBytesThreshold = ReadDelay;

                        if (!spIndicator.IsOpen)
                        {
                            spIndicator.PortName = SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.INDICATOR_COM_PORT.ToString()).First().AttributeValue;
                            spIndicator.BaudRate = int.Parse(SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.INDICATOR_BAUD_RATE.ToString()).First().AttributeValue);
                            spIndicator.Parity = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.INDICATOR_PARITY.ToString()).First().AttributeValue, true);
                            spIndicator.DataBits = int.Parse(SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.INDICATOR_DATA_BITS.ToString()).First().AttributeValue);
                            spIndicator.StopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.INDICATOR_STOP_BIT.ToString()).First().AttributeValue, true);

                            spIndicator.Open();
                        }

            
                    }
              

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("COM Port status :" + ex.Message);
            }

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
        #endregion

        private void btnWeighmentEntry_Click(object sender, EventArgs e)
        {
            CloseComPort();

            if (_weighmentEntry == Globals.WEIGHMENT_ENTRY.FIRST)
                if (ValidateWeighmentDetail())
                {
                    AddWeighmentEntry();
                }

            if (_weighmentEntry == Globals.WEIGHMENT_ENTRY.SECOND)
                if (ValidateWeighment())
                {
                    int ticketNumber = Convert.ToInt32(this.txtSerialNo.Text);
                    Weighment selectedWeighments = ReferencesHelper.GetDetailsForDuplicateSecondWeight(ticketNumber);
                  
                    double sw = selectedWeighments.SecondWeight;
                    double secondweight = Convert.ToDouble(sw);
                    if (secondweight <= 0)
                    {
                        AddWeighmentEntry();
                    }
                    else
                    {
                       
                        MessageBox.Show("Second Weight Is Already Saved Against This Serial No.");
                    }
                }

        }

        private void CalculateTotals()
        {
            double fw, sw, nt;
            fw =Convert.ToDouble( _WeighmentEntry.FirstWeight);
            sw = Convert.ToDouble(_WeighmentEntry.SecondWeight);

            if (fw > sw)
            {
                netWeight = fw - sw;
                result = Math.Round(netWeight, 2);
                this.txtTotalNetWeight.Text = result.ToString();
            }
                

            else
            {
                netWeight = sw - fw;
                result = Math.Round(netWeight, 2);
                this.txtTotalNetWeight.Text = result.ToString();
            }
        }
               

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            CloseComPort();
            this.Close();
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
             if (ValidateWeighment())
            {
                //start.. party product add with respect to dropdown or textbox

                List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
                var party = SystemSettings.Where(o => o.Id == 41).FirstOrDefault();
                string p = RoundOff(party.AttributeValue);
                p = p.ToUpper();
                var product = SystemSettings.Where(o => o.Id == 42).FirstOrDefault();
                string pro = RoundOff(product.AttributeValue);
                pro = pro.ToUpper();
                if (p == "TRUE")
                {
                    _WeighmentEntry.ClientId = this.cboParty.Text;
                }

                else
                {

                    _WeighmentEntry.ClientId = this.txtParty.Text;
                }


                if (pro == "TRUE")
                {

                    _WeighmentEntry.ProductName = this.cmbItem.Text;
                }

                else
                {

                    _WeighmentEntry.ProductName = this.txtProduct.Text;
                }

                //end.. party product add with respect to dropdown or textbox

                _WeighmentEntry.TicketNumber = Convert.ToInt32(this.txtSerialNo.Text);
                _WeighmentEntry.BarCode = Base64;
                
                _WeighmentEntry.TicketDate = this.dtpDate.Value;
                _WeighmentEntry.ReferenceNumber = this.txtVehicleNo.Text;
                
                _WeighmentEntry.DriverName = this.txtDriverName.Text;
             
                _WeighmentEntry.Remark = txtRemark.Text;
                _WeighmentEntry.RevisionNumber = 2;
                _WeighmentEntry.Id = wId;
            
              

                swght = double.Parse(this.txtWeightIndicator.Text);
                sdatetime = DateTime.Now;
                stype = "Auto";
                _WeighmentEntry.FirstWeight = fwght;
    
                _WeighmentEntry.FirstDateTime = fdatetime;
                _WeighmentEntry.FirstType = ftype;
                _WeighmentEntry.SecondWeight = swght;

                _WeighmentEntry.SecondDateTime = sdatetime;
                _WeighmentEntry.SecondType = stype;
                _WeighmentEntry.From = this.txtFrom.Text;
                _WeighmentEntry.To = this.txtTo.Text;
                if (txtAmount.Text == null || txtAmount.Text == "")
                    _WeighmentEntry.Amount = 0;
                else
                    _WeighmentEntry.Amount = Convert.ToDouble(txtAmount.Text);

                if (txtReceivedAmount.Text == null || txtReceivedAmount.Text == "")
                    _WeighmentEntry.ReceivedAmount = 0;
                else
                    _WeighmentEntry.ReceivedAmount = Convert.ToDouble(txtReceivedAmount.Text);

                if (fwght > swght)
                {
                    netWeight = fwght - swght;
                   result = Math.Round(netWeight, 2);
                }
                    
                else
                {
                    netWeight = swght - fwght;
                    result = Math.Round(netWeight, 2);
                }

                _WeighmentEntry.Weight = result;
          

                WeighmentHelper.UpdateWeighment(_WeighmentEntry, GlobalsHelper.LoggedInUser.LoginId);
                MessageBox.Show("Data Saved Successfully..!");

                Microsoft.Reporting.WinForms.ReportDataSource dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighmentListing", ReferencesHelper.GetDataTable("vwWeighmentList", " WHERE Id = " +wId));
                string ReportName = "CWeighmentSlip.rdlc";
                if (PricingMode)
                    ReportName = "CWeighmentSlip.rdlc";
                FrmReportViewer ReportViewer = new FrmReportViewer(ReportName, null, dsReport);
                SystemSetting compsms = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "Company SMS").First();
                SystemSetting partysms = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "Party SMS").First();
                SystemSetting smstype = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "SMS Type").First();
                if (compsms.AttributeValue == "TRUE")
                {
                    SystemSetting phone = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "Client SMS #").First();
                    var Phone = phone.AttributeValue;
                    if (Phone != null && Phone != "")
                    {
                        if (smstype.AttributeValue == "Google API")
                            SendShortMessageAPI(Phone, txtWeightIndicator.Text);
                        if (smstype.AttributeValue == "GSM/Mobile")
                            SendShortMessage(Phone, txtWeightIndicator.Text);
                    }
                }
                if (partysms.AttributeValue == "TRUE")
                {
                    var reslt = ReferencesHelper.GetClients().Where(m => m.Name == _WeighmentEntry.ClientId).FirstOrDefault();
                    if (reslt != null)
                    {
                        var Phone = reslt.ClientPhone;
                        if (Phone != null && Phone != "")
                        {
                            if (smstype.AttributeValue == "Google API")
                                SendShortMessageAPI(Phone, txtWeightIndicator.Text);
                            if (smstype.AttributeValue == "GSM/Mobile")
                                SendShortMessage(Phone, txtWeightIndicator.Text);
                        }
                    }

                }
                ReportViewer.ShowDialog();
                this.Close();      
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (ValidateWeighmentDetail())
            {
                //start.. party product add with respect to dropdown or textbox

                List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
                var party = SystemSettings.Where(o => o.Id == 41).FirstOrDefault();
                string p = RoundOff(party.AttributeValue);
                p = p.ToUpper();
                var product = SystemSettings.Where(o => o.Id == 42).FirstOrDefault();
                string pro = RoundOff(product.AttributeValue);
                pro = pro.ToUpper();
                if (p == "TRUE")
                {
                    _WeighmentEntry.ClientId = this.cboParty.Text;
                }

                else
                {

                    _WeighmentEntry.ClientId = this.txtParty.Text;
                }


                if (pro == "TRUE")
                {

                    _WeighmentEntry.ProductName = this.cmbItem.Text;
                }

                else
                {

                    _WeighmentEntry.ProductName = this.txtProduct.Text;
                }

                //end.. party product add with respect to dropdown or textbox

                _WeighmentEntry.BarCode = Base64;
                if (txtAmount.Text==null || txtAmount.Text=="") 
                    _WeighmentEntry.Amount = 0;
                else
                _WeighmentEntry.Amount = Convert.ToDouble(txtAmount.Text);

                _WeighmentEntry.TicketDate = this.dtpDate.Value;
                _WeighmentEntry.TicketNumber = Convert.ToInt32(this.txtSerialNo.Text);
                _WeighmentEntry.ReferenceNumber = this.txtVehicleNo.Text;             
                _WeighmentEntry.DriverName = this.txtDriverName.Text;              
                _WeighmentEntry.Remark = txtRemark.Text;
                _WeighmentEntry.RevisionNumber = 1;           
                _WeighmentEntry.Weight =0;             
                _WeighmentEntry.FirstWeight = Convert.ToDouble(this.txtWeightIndicator.Text);
                _WeighmentEntry.From = this.txtFrom.Text;
                _WeighmentEntry.To = this.txtTo.Text;
                _WeighmentEntry.ReceivedAmount = 0;
                _WeighmentEntry.FirstDateTime = DateTime.Now;
                _WeighmentEntry.FirstType = "Auto";
                _WeighmentEntry.SecondWeight = 0.0;
                 DateTime dt = new DateTime();
                _WeighmentEntry.SecondDateTime = dt;
                _WeighmentEntry.SecondType = "";
                Boolean Manual = !(txtWeightIndicator.ReadOnly);
                _WeighmentEntry.MWeight =Manual;

                uint SerialNo = 2618208898;
                LicenseInfo rLicense = RockeyHelper.GetLicense(SerialNo);

                if (rLicense.InternalSerial == 2564932284)
                {
                    WeighmentHelper.AddWeighment(ref _WeighmentEntry, GlobalsHelper.LoggedInUser.LoginId);
                    MessageBox.Show("Data Saved Successfully..!");
                    Weighment Weight = ReferencesHelper.GetWeight().Last();
                    int wId = Weight.Id;


                    // Report view

                    Microsoft.Reporting.WinForms.ReportDataSource dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighmentListing", ReferencesHelper.GetDataTable("vwWeighmentList", " WHERE Id = " + wId));
                    string ReportName = "CWeighmentSlip.rdlc";
                    if (PricingMode)
                        ReportName = "CWeighmentSlip.rdlc";
                    FrmReportViewer ReportViewer = new FrmReportViewer(ReportName, null, dsReport);
                    SystemSetting compsms = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "Company SMS").First();
                    SystemSetting partysms = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "Party SMS").First();
                    SystemSetting smstype = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "SMS Type").First();
                    if (compsms.AttributeValue == "TRUE")
                    {
                        SystemSetting phone = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "Client SMS #").First();
                        
                        var Phone = phone.AttributeValue;
                        if (Phone != null && Phone != "")
                        {
                            if (smstype.AttributeValue == "Google API")
                            SendShortMessageAPI(Phone,txtWeightIndicator.Text);
                            if(smstype.AttributeValue == "GSM/Mobile")
                            SendShortMessage(Phone, txtWeightIndicator.Text);
                        }
                    }
                    if (partysms.AttributeValue == "TRUE")
                    {
                        var reslt = ReferencesHelper.GetClients().Where(m => m.Name == _WeighmentEntry.ClientId).FirstOrDefault();
                        if (reslt != null)
                        {
                            var Phone = reslt.ClientPhone;
                            if (Phone != null && Phone != "")
                            {
                                if (smstype.AttributeValue == "Google API")
                                    SendShortMessageAPI(Phone, txtWeightIndicator.Text);
                                if (smstype.AttributeValue == "GSM/Mobile")
                                    SendShortMessage(Phone, txtWeightIndicator.Text);
                            }
                        }

                    }

                    ReportViewer.ShowDialog();
            
                    this.Close();

                }

                else {
                    Weighment recordcount = ReferencesHelper.WeighmentRecordCount().First();
                    int record = recordcount.Id;
                    if (record <= 100)
                    {
                        WeighmentHelper.AddWeighment(ref _WeighmentEntry, GlobalsHelper.LoggedInUser.LoginId);
                        MessageBox.Show("Data Saved Successfully..!");
                        Weighment Weight = ReferencesHelper.GetWeight().Last();
                        int wId = Weight.Id;


                        // Report view

                        Microsoft.Reporting.WinForms.ReportDataSource dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighmentListing", ReferencesHelper.GetDataTable("vwWeighmentList", " WHERE Id = " + wId));
                        string ReportName = "CWeighmentSlip.rdlc";
                        if (PricingMode)
                            ReportName = "CWeighmentSlip.rdlc";
                        FrmReportViewer ReportViewer = new FrmReportViewer(ReportName, null, dsReport);
                        SystemSetting compsms = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "Company SMS").First();
                        SystemSetting partysms = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "Party SMS").First();
                        SystemSetting smstype = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "SMS Type").First();
                        if (compsms.AttributeValue == "TRUE")
                        {
                            SystemSetting phone = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "Client SMS #").First();
                            var Phone = phone.AttributeValue;
                            if (Phone != null && Phone != "")
                            {
                                if (smstype.AttributeValue == "Google API")
                                    SendShortMessageAPI(Phone, txtWeightIndicator.Text);
                                if (smstype.AttributeValue == "GSM/Mobile")
                                    SendShortMessage(Phone, txtWeightIndicator.Text);
                            }
                        }
                        if (partysms.AttributeValue == "TRUE")
                        {
                            var reslt = ReferencesHelper.GetClients().Where(m => m.Name == _WeighmentEntry.ClientId).FirstOrDefault();
                            if (reslt!=null) {
                                var Phone = reslt.ClientPhone;
                                if (Phone != null && Phone != "")
                                {
                                    if (smstype.AttributeValue == "Google API")
                                        SendShortMessageAPI(Phone, txtWeightIndicator.Text);
                                    if (smstype.AttributeValue == "GSM/Mobile")
                                        SendShortMessage(Phone, txtWeightIndicator.Text);
                                }
                            }
                           

                        }

                        ReportViewer.ShowDialog();
                        this.Close();
                        // Report 
                    }
                    else
                    {
                        MessageBox.Show("Trial Period Over!");
                        this.Close();
                    }

                }
                datacontrol = 0;
                SetUIMode();
           
                this.Close();
                this.DialogResult = DialogResult.OK;
               
            } 
        }
        public static string SendShortMessageAPI(string Phone,string weight)
        {

            Console.WriteLine("SMS is being sent .............");

            string message;
            string from = "Tahir";
            string to = Phone;
            string api_key = "7ddde7df";
            string api_secret = "11e68de41f3ef305";
            string text ="  Weight = " + weight.Trim();
            string wsUrl = "https://rest.nexmo.com/sms/json";

            message = "?api_key=" + api_key + "&api_secret=" + api_secret + "&from=" + from + "&to=" + to + "&text=" + '"' + text + '"';
            wsUrl = wsUrl + message;

            string Out = String.Empty;
            System.Net.WebRequest req = System.Net.WebRequest.Create(wsUrl);
            try
            {
                req.Method = "POST";
                req.Timeout = 100000;
                req.ContentType = "application/x-www-form-urlencoded";
                byte[] sentData = Encoding.UTF8.GetBytes(message);
                req.ContentLength = sentData.Length;
                using (System.IO.Stream sendStream = req.GetRequestStream())
                {
                    sendStream.Write(sentData, 0, sentData.Length);
                    sendStream.Close();
                }
                System.Net.WebResponse res = req.GetResponse();
                System.IO.Stream ReceiveStream = res.GetResponseStream();
                using (System.IO.StreamReader sr = new System.IO.StreamReader(ReceiveStream, Encoding.UTF8))
                {
                    Char[] read = new Char[256];
                    int count = sr.Read(read, 0, 256);

                    while (count > 0)
                    {
                        String str = new String(read, 0, count);
                        Out += str;
                        count = sr.Read(read, 0, 256);
                    }
                }
            }
            catch (ArgumentException ex)
            {
                Out = string.Format("HTTP_ERROR :: The second HttpWebRequest object has raised an Argument Exception as 'Connection' Property is set to 'Close' :: {0}", ex.Message);
            }
            catch (WebException ex)
            {
                Out = string.Format("HTTP_ERROR :: WebException raised! :: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Out = string.Format("HTTP_ERROR :: Exception raised! :: {0}", ex.Message);
            }

            Console.WriteLine("SMS has been sent succesfully.........");

            return Out;

            //*********Commented to check other logic ************ Tahir
            ////var stream = new MemoryStream();
            //var multipart = new MultipartContent
            //{
            //    new StringContent("This string will be sent repeatedly"),
            //    new FormUrlEncodedContent(new[] {new KeyValuePair<string, string>("foo", "bar"),}),
            //    //new StreamContent(stream)
            //};

            //Console.WriteLine("Data has been arranged .............");

            //var contentdata = new ReusableContent(multipart);

            //HttpClient client = new HttpClient();
            ////HttpResponseMessage response = await client.PostAsync(wsUrl, contentdata);
            //var response = await client.PostAsync(wsUrl, contentdata);
            ////HttpContent content = response.Content;
            ////string mycontent = await content.ReadAsStringAsync();

        }
        public void SendShortMessage(string Number, string msg)
        {
            try
            {
                SystemSetting phoneport = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "Phone PortName").First();
                var PhonePort = phoneport.AttributeValue;
                SerialPort sp = new SerialPort();
                sp.PortName = PhonePort;
                sp.BaudRate = 9600;
                sp.Parity = Parity.None;
                sp.Open();
                sp.WriteLine(@"AT" + (char)(13));
                Thread.Sleep(200);
                sp.WriteLine("AT+CMGF=1" + (char)(13));
                Thread.Sleep(200);
                sp.WriteLine(@"AT+CMGS=""" + Number + @"""" + (char)(13));
                Thread.Sleep(200);
                sp.WriteLine(msg + (char)(26));
                sp.Close();
                Thread.Sleep(6000);

                Thread.Sleep(3000);
                MessageBox.Show("Message Sent Successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message Not Send.");
            }
        }

        private void spIndicator_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            string DataBlok = spIndicator.ReadExisting();

     

            char[] DataBlokArray = DataBlok.ToCharArray();

        

            foreach (char item in DataBlokArray)
            {
       


               if (item == ControlCharacter)
                {
                    if (FilteredDataFromIndicator.Length >= (FilteredStartIndex + FilterByteSize))
                        SetText(FilteredDataFromIndicator.Substring(FilteredStartIndex, FilterByteSize));
                  
                    FilteredDataFromIndicator = string.Empty;
                }
                else
                {

                    FilteredDataFromIndicator += item;
                
                }
            }

            

        }

        private void CloseComPort()
        {
            try
            {
                if (!AllowManualWeighment && spIndicator.IsOpen)
                {
                    spIndicator.Close();
                }

                RawDataFromIndicator = string.Empty;

                //MessageBox.Show("COM Port status :" + spIndicator.IsOpen);
            }
            catch (Exception EX)
            {
                MessageBox.Show("Error raised on closing COM port " + EX.Message);
            }
        }

        private void ClosePort()
        {

            spIndicator.Close();

        }

        private void spIndicator_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
            MessageBox.Show("Serial port error received " + e.EventType.ToString());
        }

    

        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
      
            if (this.txtWeightIndicator.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                try
                {
                    this.Invoke(d, new object[] { text });

                }
                catch (Exception ex)
                {
                    
                }
            }
            else
            {
                this.txtWeightIndicator.Text = text;
            }
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtTotalQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmWeighmentEntry_Load(object sender, EventArgs e)
        {
            if (_weighmentEntry == Globals.WEIGHMENT_ENTRY.FIRST)
            {
                Weighment Weight = ReferencesHelper.GetWeight().Last();
                int Ticket = Convert.ToInt32(Weight.TicketNumber);
                int a = (Ticket) + 1;
                txtSerialNo.Text = a.ToString();
            }

        }

        private void txtSerialNo_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {

        }

    
      

        private void txtSerialNo_KeyDown(object sender, KeyEventArgs e)
        {

            this.ep.Clear();

            if (e.KeyCode == Keys.Enter)
            {
                int ticketNumber;
                if (txtSerialNo.Text != "" && txtSerialNo.Text.Trim().Length > 9)
                {
                    string brsr = txtSerialNo.Text;
                    int ln = brsr.Length;
                    ln = ln - 9;
                    brsr = brsr.Substring(9, ln);
                    lst.Items.Clear();
                    ticketNumber = Convert.ToInt32(brsr);
                    Weighment duplicateWeighment = ReferencesHelper.GetDetailsForDuplicateSecondWeight(ticketNumber);
                    Double dupsecondweight = Convert.ToDouble(duplicateWeighment.SecondWeight);
                    Double dupfirstweight = Convert.ToDouble(duplicateWeighment.FirstWeight);

                    Weighment selectedWeighment = ReferencesHelper.GetDetailsPendingForSecondWeight(ticketNumber);
                    wId = 0;
                    if (dupsecondweight <= 0 && dupfirstweight > 0)
                    {
                        this.txtVehicleNo.Text = selectedWeighment.ReferenceNumber;

                        if (selectedWeighment.TicketNumber != 0)
                        {
                            this.dtpDate.Value = selectedWeighment.TicketDate;
                        }
                        //start.. party , product code
                        List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
                        var party = SystemSettings.Where(o => o.Id == 41).FirstOrDefault();
                        string p = RoundOff(party.AttributeValue);
                        p = p.ToUpper();
                        var product = SystemSettings.Where(o => o.Id == 42).FirstOrDefault();
                        string pro = RoundOff(product.AttributeValue);
                        pro = pro.ToUpper();
                        if (p == "TRUE")
                        {
                            this.cboParty.Text = selectedWeighment.ClientId;
                            this.cboParty.Enabled = true;

                        }

                        else
                        {

                            this.txtParty.Text = selectedWeighment.ClientId;
                            this.txtParty.Enabled = true;
                        }


                        if (pro == "TRUE")
                        {

                            this.cmbItem.Text = selectedWeighment.ProductName;
                            this.cmbItem.Enabled = true;
                        }

                        else
                        {

                            this.txtProduct.Text = selectedWeighment.ProductName;
                            this.txtProduct.Enabled = true;
                        }
                        // end .. party product code
                        this.txtDriverName.Text = selectedWeighment.DriverName;
                        this.txtAmount.Text = selectedWeighment.Amount.ToString();
                        result = Math.Round(Convert.ToDouble(selectedWeighment.Weight), 2);
                        this.txtTotalNetWeight.Text = result.ToString();
                        this.txtRemark.Text = selectedWeighment.Remark;
                        this.txtFrom.Text = selectedWeighment.From;
                        this.txtTo.Text = selectedWeighment.To;
                        this.txtReceivedAmount.Text = selectedWeighment.ReceivedAmount.ToString();
                        wId = selectedWeighment.Id;

                        int iCounter = 1;


                        fwght = 0.0;

                        {

                            ListViewItem lst = new ListViewItem(iCounter.ToString());

                            lst.SubItems.Add("First Weight");
                            lst.SubItems.Add(selectedWeighment.FirstWeight.ToString());
                            lst.SubItems.Add(selectedWeighment.FirstDateTime.ToString("HH:mm:ss tt"));
                            lst.SubItems.Add(selectedWeighment.FirstDateTime.ToString("MM/dd/yyyy"));
                            lst.SubItems.Add(selectedWeighment.FirstType);

                            this.lst.Items.Add(lst);

                        }

                        fwght = Convert.ToDouble(selectedWeighment.FirstWeight);
                        fdatetime = selectedWeighment.FirstDateTime;
                        ftype = selectedWeighment.FirstType;

                        netWeight = 0.0;
                        netWeight = fwght;

               
                        this.txtSerialNo.Text = ticketNumber.ToString();
                        this.txtSerialNo.Enabled = false;
                        this.txtSerialNo.ReadOnly = false;
                        this.txtVehicleNo.Enabled = true;
                        this.dtpDate.Enabled = false;

                        this.txtDriverName.Enabled = true;

                        this.txtRemark.Enabled = true;
                        this.txtTotalNetWeight.Enabled = false;
                        this.CmdCancel.Enabled = true;
                        this.btnNew.Visible = false;
                        this.btnNew.Enabled = false;
                        this.CmdOK.Visible = true;
                        this.CmdOK.Enabled = true;
                    }

                    else if (dupsecondweight > 0)
                    {

                        MessageBox.Show("Second Weight Is Already Saved Against This Serial No.");
                    }
                    else if (selectedWeighment.TicketNumber == 0)
                    {
                        MessageBox.Show("No Record Found Please Add First Weight.");
                    }

                }
                else
                    if (txtSerialNo.Text.Trim().Length < 9)
                {
                    ticketNumber = Convert.ToInt32(this.txtSerialNo.Text);
                    Weighment duplicateWeighment = ReferencesHelper.GetDetailsForDuplicateSecondWeight(ticketNumber);
                    Double dupsecondweight = Convert.ToDouble(duplicateWeighment.SecondWeight);
                    Double dupfirstweight = Convert.ToDouble(duplicateWeighment.FirstWeight);

                    Weighment selectedWeighment = ReferencesHelper.GetDetailsPendingForSecondWeight(ticketNumber);
                    wId = 0;
                    if (dupsecondweight <= 0 && dupfirstweight > 0)
                    {
                        this.txtVehicleNo.Text = selectedWeighment.ReferenceNumber;

                        if (selectedWeighment.TicketNumber != 0)
                        {
                            this.dtpDate.Value = selectedWeighment.TicketDate;
                        }
                        //start.. party , product code
                        List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
                        var party = SystemSettings.Where(o => o.Id == 41).FirstOrDefault();
                        string p = RoundOff(party.AttributeValue);
                        p = p.ToUpper();
                        var product = SystemSettings.Where(o => o.Id == 42).FirstOrDefault();
                        string pro = RoundOff(product.AttributeValue);
                        pro = pro.ToUpper();
                        if (p == "TRUE")
                        {
                            this.cboParty.Text = selectedWeighment.ClientId;
                            this.cboParty.Enabled = true;

                        }

                        else
                        {

                            this.txtParty.Text = selectedWeighment.ClientId;
                            this.txtParty.Enabled = true;
                        }


                        if (pro == "TRUE")
                        {

                            this.cmbItem.Text = selectedWeighment.ProductName;
                            this.cmbItem.Enabled = true;
                        }

                        else
                        {

                            this.txtProduct.Text = selectedWeighment.ProductName;
                            this.txtProduct.Enabled = true;
                        }
                        // end .. party product code
                        this.txtDriverName.Text = selectedWeighment.DriverName;
                        this.txtAmount.Text = selectedWeighment.Amount.ToString();
                        result = Math.Round(Convert.ToDouble(selectedWeighment.Weight), 2);
                        this.txtTotalNetWeight.Text = result.ToString();
                        this.txtRemark.Text = selectedWeighment.Remark;
                        this.txtFrom.Text = selectedWeighment.From;
                        this.txtTo.Text = selectedWeighment.To;
                        this.txtReceivedAmount.Text = selectedWeighment.ReceivedAmount.ToString();
                        wId = selectedWeighment.Id;

                        int iCounter = 1;


                        fwght = 0.0;

                        {

                            ListViewItem lst = new ListViewItem(iCounter.ToString());

                            lst.SubItems.Add("First Weight");
                            lst.SubItems.Add(selectedWeighment.FirstWeight.ToString());
                            lst.SubItems.Add(selectedWeighment.FirstDateTime.ToString("HH:mm:ss tt"));
                            lst.SubItems.Add(selectedWeighment.FirstDateTime.ToString("MM/dd/yyyy"));
                            lst.SubItems.Add(selectedWeighment.FirstType);

                            this.lst.Items.Add(lst);

                        }

                        fwght = Convert.ToDouble(selectedWeighment.FirstWeight);
                        fdatetime = selectedWeighment.FirstDateTime;
                        ftype = selectedWeighment.FirstType;

                        netWeight = 0.0;
                        netWeight = fwght;

                        this.txtTotalNetWeight.Text = netWeight.ToString();

                        this.txtSerialNo.Enabled = false;
                        this.txtSerialNo.ReadOnly = false;
                        this.txtVehicleNo.Enabled = true;
                        this.dtpDate.Enabled = false;

                        this.txtDriverName.Enabled = true;

                        this.txtRemark.Enabled = true;
                        this.txtTotalNetWeight.Enabled = false;
                        this.CmdCancel.Enabled = true;
                        this.btnNew.Visible = false;
                        this.btnNew.Enabled = false;
                        this.CmdOK.Visible = true;
                        this.CmdOK.Enabled = true;
                    }

                    else if (dupsecondweight > 0)
                    {

                        MessageBox.Show("Second Weight Is Already Saved Against This Serial No.");
                    }
                    else if (selectedWeighment.TicketNumber == 0)
                    {
                        MessageBox.Show("No Record Found Please Add First Weight.");
                    }

                }

                   
               

            }
            // Enter Key End
        }

        private void txtVehicleNo_KeyDown(object sender, KeyEventArgs e)
        {
            this.ep.Clear();
            lst.Items.Clear();
            if (e.KeyCode == Keys.Enter)
            {

                string ticketNumber = this.txtVehicleNo.Text;
                Weighment duplicateWeighment = ReferencesHelper.GetDetailsForDuplicateSecondWeight2(ticketNumber);
                Double dupsecondweight = Convert.ToDouble(duplicateWeighment.SecondWeight);
                Double dupfirstweight = Convert.ToDouble(duplicateWeighment.FirstWeight);

                Weighment selectedWeighment = ReferencesHelper.GetDetailsPendingForSecondWeight2(ticketNumber);
                wId = 0;
                if (dupsecondweight <= 0 && dupfirstweight > 0)
                {
                    this.txtVehicleNo.Text = selectedWeighment.ReferenceNumber;

                    if (selectedWeighment.TicketNumber != 0)
                    {
                        this.dtpDate.Value = selectedWeighment.TicketDate;
                    }
                    //start.. party , product code
                    List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
                    var party = SystemSettings.Where(o => o.Id == 41).FirstOrDefault();
                    string p = RoundOff(party.AttributeValue);
                    p = p.ToUpper();
                    var product = SystemSettings.Where(o => o.Id == 42).FirstOrDefault();
                    string pro = RoundOff(product.AttributeValue);
                    pro = pro.ToUpper();
                    if (p == "TRUE")
                    {
                        this.cboParty.Text = selectedWeighment.ClientId;
                        this.cboParty.Enabled = true;

                    }

                    else
                    {

                        this.txtParty.Text = selectedWeighment.ClientId;
                        this.txtParty.Enabled = true;
                    }


                    if (pro == "TRUE")
                    {

                        this.cmbItem.Text = selectedWeighment.ProductName;
                        this.cmbItem.Enabled = true;
                    }

                    else
                    {

                        this.txtProduct.Text = selectedWeighment.ProductName;
                        this.txtProduct.Enabled = true;
                    }
                    // end .. party product code
                    this.txtSerialNo.Text = selectedWeighment.TicketNumber.ToString();
                    this.txtDriverName.Text = selectedWeighment.DriverName;
                    this.txtAmount.Text = selectedWeighment.Amount.ToString();
                    result = Math.Round(Convert.ToDouble(selectedWeighment.Weight), 2);
                    this.txtTotalNetWeight.Text = result.ToString();
                    this.txtRemark.Text = selectedWeighment.Remark;
                    this.txtFrom.Text = selectedWeighment.From;
                    this.txtTo.Text = selectedWeighment.To;
                    
                    this.txtReceivedAmount.Text = selectedWeighment.ReceivedAmount.ToString();
                    wId = selectedWeighment.Id;

                    int iCounter = 1;


                    fwght = 0.0;

                    {

                        ListViewItem lst = new ListViewItem(iCounter.ToString());

                        lst.SubItems.Add("First Weight");
                        lst.SubItems.Add(selectedWeighment.FirstWeight.ToString());
                        lst.SubItems.Add(selectedWeighment.FirstDateTime.ToString("HH:mm:ss tt"));
                        lst.SubItems.Add(selectedWeighment.FirstDateTime.ToString("MM/dd/yyyy"));
                        lst.SubItems.Add(selectedWeighment.FirstType);

                        this.lst.Items.Add(lst);

                    }

                    fwght = Convert.ToDouble(selectedWeighment.FirstWeight);
                    fdatetime = selectedWeighment.FirstDateTime;
                    ftype = selectedWeighment.FirstType;

                    netWeight = 0.0;
                    netWeight = fwght;

                    this.txtTotalNetWeight.Text = netWeight.ToString();

                    this.txtSerialNo.Enabled = false;
                    this.txtSerialNo.ReadOnly = false;
                    this.txtVehicleNo.Enabled = true;
                    this.dtpDate.Enabled = false;
                    this.txtDriverName.Enabled = true;

                    this.txtRemark.Enabled = true;
                    this.txtTotalNetWeight.Enabled = false;
                    this.CmdCancel.Enabled = true;
                    this.btnNew.Visible = false;
                    this.btnNew.Enabled = false;
                    this.CmdOK.Visible = true;
                    this.CmdOK.Enabled = true;
                }

                else if (dupsecondweight > 0)
                {

                    MessageBox.Show("Second Weight Is Already Saved Against This Serial No.");
                }
                else if (selectedWeighment.TicketNumber == 0)
                {
                    MessageBox.Show("No Record Found Please Add First Weight.");
                }

            }
            // Enter Key End
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lst.Items.Clear();
            NewWeightManual frm = new NewWeightManual();
            frm.ShowDialog();
        }
        private void cboParty_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void cmbItem_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtDriverName_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class ReusableContent2 : HttpContent
    {
        private readonly HttpContent _innerContent;

        public ReusableContent2(HttpContent innerContent)
        {
            _innerContent = innerContent;
        }

        protected override async Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            await _innerContent.CopyToAsync(stream);
        }

        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }

        protected override void Dispose(bool disposing)
        {
     
        }

    }
}