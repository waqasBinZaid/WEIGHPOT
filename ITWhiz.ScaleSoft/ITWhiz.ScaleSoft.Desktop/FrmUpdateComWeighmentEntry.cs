using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
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
    public partial class FrmUpdateComWeighmentEntry : Form
    {
        private int wId = 0;
        private int wproId = 0;

        public FrmUpdateComWeighmentEntry()
        {
            InitializeComponent();
        }
        private void InitProducts()
        {
            List<Product> products = ReferencesHelper.AllProducts();

            products = products.ToList();
            products.Add(new Product() { Id = 0, Name = string.Empty });

            this.cmbItem.DataSource = products;
            this.cmbItem.DisplayMember = "Name";
            this.cmbItem.ValueMember = "Id";

        }
        private void InitParties()
        {
            List<Client> products = ReferencesHelper.GetClients();

            products = products.ToList();
            products.Add(new Client() { Name = string.Empty });

            this.cmbParty.DataSource = products;
            this.cmbParty.DisplayMember = "Name";
            this.cmbParty.ValueMember = "Name";

        }
        private void SetUIMode()
        {

            this.txtSerialNo.Text = string.Empty;
            this.txtSerialNo.Enabled = true;
            this.txtSerialNo.ReadOnly = false;
            this.txtVehicleNo.Text = string.Empty;
            this.txtVehicleNo.Enabled = false;
            this.dtpTicketDate.Value = DateTime.Now;
            this.dtpTicketDate.Enabled = false;
            // start .. party ,product dropdown ,textbox configuration
            List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
            var party = SystemSettings.Where(o => o.Id == 41).FirstOrDefault();
            string p = RoundOff(party.AttributeValue);
            p = p.ToUpper();
            var product = SystemSettings.Where(o => o.Id == 42).FirstOrDefault();
            string pro = RoundOff(product.AttributeValue);
            pro = pro.ToUpper();
            if (p=="TRUE")
            {
                cmbParty.Visible = true;
                this.cmbParty.Text = string.Empty;
                this.cmbParty.Enabled = false;
            }

            else
            {
                txtPartyName.Visible = true;
                this.txtPartyName.Text = string.Empty;
                this.txtPartyName.Enabled = false;
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
         
            this.txtRemark.Text = string.Empty;
            this.txtRemark.Enabled = false;
            this.txtType.Text = string.Empty;
            this.txtType.Enabled = false;
            this.txtManualWeight.Text = string.Empty;
            this.txtManualWeight.Enabled = false;
            this.txtFirstWeight.Text = string.Empty;
            this.txtFirstWeight.Enabled = false;
            this.txtSecondWeight.Text = string.Empty;
            this.txtSecondWeight.Enabled = false;
            this.txtNetWeight.Text = string.Empty;
            this.txtNetWeight.Enabled = false;
            this.txtFrom.Text = string.Empty;
            this.txtFrom.Enabled = false;
            this.txtTo.Text = string.Empty;
            this.txtTo.Enabled = false;
            this.txtAmount.Text = string.Empty;
            this.txtAmount.Enabled = false;
            this.txtReceivedAmount.Text = string.Empty;
            this.txtReceivedAmount.Enabled = false;
            this.dtpTicketDate.Enabled = false;
            this.btnCancel.Enabled = true;
            this.btnCancel.Visible = true;
            
            this.btnUpdate.Visible = true;
            this.btnUpdate.Enabled = false;
        }
        private void SetUIModeEnable()
        {

            //this.txtSerialNo.Text = string.Empty;
            this.txtSerialNo.Enabled = false;
            this.txtSerialNo.ReadOnly = true;
        //    this.txtVehicleNo.Text = string.Empty;
            this.txtVehicleNo.Enabled = true;
      //      this.dtpTicketDate.Value = DateTime.Now;
            this.dtpTicketDate.Enabled = true;
            // start .. party ,product dropdown ,textbox configuration
            List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
            var party = SystemSettings.Where(o => o.Id == 41).FirstOrDefault();
            string p = RoundOff(party.AttributeValue);
            p = p.ToUpper();
            var product = SystemSettings.Where(o => o.Id == 42).FirstOrDefault();
            string pro = RoundOff(product.AttributeValue);
            pro = pro.ToUpper();
            if (p == "TRUE")
            {
                cmbParty.Visible = true;
                this.cmbParty.Enabled = true;
            }

            else
            {
                txtPartyName.Visible = true;

                this.txtPartyName.Enabled = true;
            }


            if (pro == "TRUE")
            {
                cmbItem.Visible = true;

                this.cmbItem.Enabled = true;
            }

            else
            {
                txtProduct.Visible = true;

                this.txtProduct.Enabled = true;
            }
            // end .. party ,product dropdown ,textbox configuration
            this.txtDriverName.Enabled = true;
 
       //     this.txtRemark.Text = string.Empty;
            this.txtRemark.Enabled = true;
        //    this.txtType.Text = string.Empty;
            this.txtType.Enabled = true;
       //     this.txtManualWeight.Text = string.Empty;
            this.txtManualWeight.Enabled = true;
      //      this.txtFirstWeight.Text = string.Empty;
            this.txtFirstWeight.Enabled = true;
     //       this.txtSecondWeight.Text = string.Empty;
            this.txtSecondWeight.Enabled = true;
   //         this.txtNetWeight.Text = string.Empty;
            this.txtNetWeight.Enabled = false;
            this.txtFrom.Enabled = true;
            this.txtTo.Enabled = true;
            this.txtAmount.Enabled = true;
            this.txtReceivedAmount.Enabled = true;
            this.dtpTicketDate.Enabled = true;
            this.btnCancel.Enabled = true;
            this.btnCancel.Visible = true;

            this.btnUpdate.Visible = true;
            this.btnUpdate.Enabled = true;
        }
        public string RoundOff(string data)
        {
            string OldString = data;
            string NewString = System.Text.RegularExpressions.Regex.Replace(OldString, " {2,}", " ");
            string GetString = NewString.Trim();
            return GetString;
        }
        private void FrmUpdateWeighmentEntry_Load(object sender, EventArgs e)
        {
            InitProducts();
            InitParties();
            SetUIMode();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try {
                int ticketNumber = Convert.ToInt32(this.txtSerialNo.Text);
                Weighment selectedWeighment = ReferencesHelper.GetWeighmentDetails(ticketNumber);
                int wId = selectedWeighment.Id;
                Weighment WeigmentEntry = new Weighment();
                // start .. party ,product dropdown ,textbox configuration
                List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
                var party = SystemSettings.Where(o => o.Id == 41).FirstOrDefault();
                string p = RoundOff(party.AttributeValue);
                p = p.ToUpper();
                var product = SystemSettings.Where(o => o.Id == 42).FirstOrDefault();
                string pro = RoundOff(product.AttributeValue);
                pro = pro.ToUpper();
                if (p == "TRUE")
                {
                    WeigmentEntry.ClientId = this.cmbParty.Text;

                }

                else
                {
                    WeigmentEntry.ClientId = txtPartyName.Text;
                }


                if (pro == "TRUE")
                {
                    WeigmentEntry.ProductName = cmbItem.Text;
                }

                else
                {
                    WeigmentEntry.ProductName = txtProduct.Text;
                }
                // end .. party ,product dropdown ,textbox configuration
                WeigmentEntry.TicketNumber = Convert.ToInt32(this.txtSerialNo.Text);
           
                WeigmentEntry.TicketDate = this.dtpTicketDate.Value;
                WeigmentEntry.ReferenceNumber = this.txtVehicleNo.Text;
              
                WeigmentEntry.DriverName = this.txtDriverName.Text;
            
                WeigmentEntry.Remark = txtRemark.Text;
                WeigmentEntry.RevisionNumber = 2;
                WeigmentEntry.Id = wId;
                User users = ReferencesHelper.GetUserById();
                string username = users.LoginId;
                WeigmentEntry.ModifiedBy = username;
                WeigmentEntry.ModifiedOn = DateTime.Now;
                WeigmentEntry.FirstWeight =Convert.ToDouble( txtFirstWeight.Text);

                WeigmentEntry.FirstType = txtType.Text;
                WeigmentEntry.SecondWeight = Convert.ToDouble(txtSecondWeight.Text);
           
                WeigmentEntry.SecondDateTime = DateTime.Now;
                WeigmentEntry.SecondType = txtType.Text;

                Double fweight = Double.Parse(txtFirstWeight.Text);
                Double sweight = Double.Parse(txtSecondWeight.Text);
                if (fweight >= sweight)
                {
                    Double nweight = (fweight - sweight);
                    double result = Math.Round(nweight, 2);
                    WeigmentEntry.Weight = result;
                 
                }
                else
                {
                    Double nweight = (sweight - fweight);
                    double result = Math.Round(nweight, 2);
                    WeigmentEntry.Weight = result;
                
                }
                
             
                WeigmentEntry.MWeight = Convert.ToBoolean(txtManualWeight.Text);
                WeigmentEntry.From = txtFrom.Text;
                WeigmentEntry.To = txtTo.Text;
                WeigmentEntry.Amount = Convert.ToDouble(txtAmount.Text);
                WeigmentEntry.ReceivedAmount = Convert.ToDouble(txtReceivedAmount.Text);
                WeighmentHelper.UpdateWeighmentManual(WeigmentEntry, GlobalsHelper.LoggedInUser.LoginId);
                MessageBox.Show("Record Is Updated Successfully.");
                SetUIMode();
                this.Close();
            }
            catch (Exception) {
                MessageBox.Show("An Error Occur No Data Is Updated.");  
            }
           
        }

        private void txtSerialNo_KeyDown(object sender, KeyEventArgs e)
        {

            

            if (e.KeyCode == Keys.Enter)
            {
                int ticketNumber;
                if (txtSerialNo.Text != "" && txtSerialNo.Text.Trim().Length > 9)
                {
                    string brsr = txtSerialNo.Text;
                    int ln = brsr.Length;
                    ln = ln - 9;
                    brsr = brsr.Substring(9, ln);
                    ticketNumber = Convert.ToInt32(brsr);
                    Weighment duplicateWeighment = ReferencesHelper.GetDetailsForDuplicateSecondWeight(ticketNumber);
                    double dupsecondweight = Convert.ToDouble(duplicateWeighment.SecondWeight);
                    double dupfirstweight = Convert.ToDouble(duplicateWeighment.FirstWeight);
                    int dupweighmentid = duplicateWeighment.Id;
                    Weighment selectedWeighment = ReferencesHelper.GetWeighmentDetails(ticketNumber);
                    if (dupweighmentid > 0)
                    {
                        this.txtVehicleNo.Text = selectedWeighment.ReferenceNumber;

                        if (selectedWeighment.TicketNumber != 0)
                        {
                            this.dtpTicketDate.Value = selectedWeighment.TicketDate;
                        }
                        // start .. party ,product dropdown ,textbox configuration
                        List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
                        var party = SystemSettings.Where(o => o.Id == 41).FirstOrDefault();
                        string p = RoundOff(party.AttributeValue);
                        p = p.ToUpper();
                        var product = SystemSettings.Where(o => o.Id == 42).FirstOrDefault();
                        string pro = RoundOff(product.AttributeValue);
                        pro = pro.ToUpper();
                        if (p == "TRUE")
                        {
                            this.cmbParty.Text = selectedWeighment.ClientId;

                        }

                        else
                        {
                            txtPartyName.Text = selectedWeighment.ClientId;
                        }


                        if (pro== "TRUE")
                        {
                            cmbItem.Text = selectedWeighment.ProductName;
                        }

                        else
                        {
                            txtProduct.Text = selectedWeighment.ProductName;
                        }
                        // end .. party ,product dropdown ,textbox configuration

                        this.txtDriverName.Text = selectedWeighment.DriverName;

                        this.txtRemark.Text = selectedWeighment.Remark;
                        this.txtType.Text = selectedWeighment.FirstType;
                        this.txtFrom.Text = selectedWeighment.From;
                        this.txtTo.Text = selectedWeighment.To;
                        this.txtAmount.Text = selectedWeighment.Amount.ToString();
                        this.txtReceivedAmount.Text = selectedWeighment.ReceivedAmount.ToString();
                        this.txtManualWeight.Text = (selectedWeighment.MWeight).ToString();
                        this.txtFirstWeight.Text = (selectedWeighment.FirstWeight).ToString();
                        this.txtSecondWeight.Text = (selectedWeighment.SecondWeight).ToString();

                        Double fweight = Double.Parse(txtFirstWeight.Text);
                        Double sweight = Double.Parse(txtSecondWeight.Text);
                        this.txtNetWeight.Text = (selectedWeighment.Weight).ToString();
                        txtSerialNo.Text = ticketNumber.ToString();
                        SetUIModeEnable();

                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }
                }
                else
                   if (txtSerialNo.Text.Trim().Length < 9)
                {

                    ticketNumber = Convert.ToInt32(this.txtSerialNo.Text);
                    Weighment duplicateWeighment = ReferencesHelper.GetDetailsForDuplicateSecondWeight(ticketNumber);
                    double dupsecondweight = Convert.ToDouble(duplicateWeighment.SecondWeight);
                    double dupfirstweight = Convert.ToDouble(duplicateWeighment.FirstWeight);
                    int dupweighmentid = duplicateWeighment.Id;
                    Weighment selectedWeighment = ReferencesHelper.GetWeighmentDetails(ticketNumber);
                    if (dupweighmentid > 0)
                    {
                        this.txtVehicleNo.Text = selectedWeighment.ReferenceNumber;

                        if (selectedWeighment.TicketNumber != 0)
                        {
                            this.dtpTicketDate.Value = selectedWeighment.TicketDate;
                        }
                        // start .. party ,product dropdown ,textbox configuration
                        List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
                        var party = SystemSettings.Where(o => o.Id == 41).FirstOrDefault();
                        string p = RoundOff(party.AttributeValue);
                        p = p.ToUpper();
                        var product = SystemSettings.Where(o => o.Id == 42).FirstOrDefault();
                        string pro = RoundOff(product.AttributeValue);
                        pro = pro.ToUpper();
                        if (p == "TRUE")
                        {
                            this.cmbParty.Text = selectedWeighment.ClientId;

                        }

                        else
                        {
                            txtPartyName.Text = selectedWeighment.ClientId;
                        }


                        if (pro== "TRUE")
                        {
                            cmbItem.Text = selectedWeighment.ProductName;
                        }

                        else
                        {
                            txtProduct.Text = selectedWeighment.ProductName;
                        }
                        // end .. party ,product dropdown ,textbox configuration

                        this.txtDriverName.Text = selectedWeighment.DriverName;

                        this.txtRemark.Text = selectedWeighment.Remark;
                        this.txtType.Text = selectedWeighment.FirstType;
                        this.txtFrom.Text = selectedWeighment.From;
                        this.txtTo.Text = selectedWeighment.To;
                        this.txtAmount.Text = selectedWeighment.Amount.ToString();
                        this.txtReceivedAmount.Text = selectedWeighment.ReceivedAmount.ToString();
                        this.txtManualWeight.Text = (selectedWeighment.MWeight).ToString();
                        this.txtFirstWeight.Text = (selectedWeighment.FirstWeight).ToString();
                        this.txtSecondWeight.Text = (selectedWeighment.SecondWeight).ToString();

                        Double fweight = Double.Parse(txtFirstWeight.Text);
                        Double sweight = Double.Parse(txtSecondWeight.Text);
                        this.txtNetWeight.Text = (selectedWeighment.Weight).ToString();
                        SetUIModeEnable();

                    }
                    else
                    {
                        MessageBox.Show("No Record Found.");
                    }

                }
               

                }
            }

        private void txtFirstWeight_TextChanged(object sender, EventArgs e)
        {
            double f,s;
            if (txtFirstWeight.Text != "")
            {
                f = Convert.ToDouble(txtFirstWeight.Text);
            }
            else {
                f = 0;
            }
            if (txtSecondWeight.Text != "")
            {
                s = Convert.ToDouble(txtSecondWeight.Text);
            }
            else {
                s = 0;
            }

            if (f>=s)
            {
                double net = Math.Round((f - s), 2);
               txtNetWeight.Text =net.ToString();
            }
            else {
                double net = Math.Round((s-f),2);
                txtNetWeight.Text = net.ToString();
                }
           
        }

        private void txtSecondWeight_TextChanged(object sender, EventArgs e)
        {
            double f, s;
            if (txtFirstWeight.Text != "")
            {

                f = Convert.ToDouble(txtFirstWeight.Text);
            }
            else
            {
                f = 0;
            }
            if (txtSecondWeight.Text != "")
            {
                s = Convert.ToDouble(txtSecondWeight.Text);
            }
            else
            {
                s = 0;
            }
            if (f >= s)
            {
                double net = Math.Round((f - s), 2);
                txtNetWeight.Text = net.ToString();
            }
            else
            {
                double net = Math.Round((s - f), 2);
                txtNetWeight.Text = net.ToString();
            }
        }
    }
}
