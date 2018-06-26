using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
using ITWhiz.ScaleSoft.Desktop.Controls;
using IWeigh;
using LibraScales.ScaleSoft;
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

namespace ITWhiz.ScaleSoft.Desktop
{
    public partial class SetupForm : Form
    {
        Image i;
        Bitmap b;
        string Base64;
        string party;
       // List<SystemSetting> _SystemSettings;
        List<SystemSetting> _System;
        public SetupForm()
        {
            InitializeComponent();
            InitIndicators();
            Radio();
            SetText();
 
            InitSystem();
           
        }
        private void Radio() {
            if (radiogsm.Checked == true)
            {
                lblsmsport.Visible = true;
                txtClientPhonePort.Visible = true;
            }
            else {
                lblsmsport.Visible = false;
                txtClientPhonePort.Visible = false;
            }
        }
        private void SetText() {
            List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().ToList();
            foreach (var item in SystemSettings)
            {
                if (item.Id == 1)
                    txtClientName.Text=item.AttributeValue;
                if (item.Id == 2)
                     txtClientAddress.Text= item.AttributeValue;
                if (item.Id == 3)
                    txtClientCity.Text= item.AttributeValue;
                if (item.Id == 5)
                    txtIndicatorPort.Text = item.AttributeValue;
                if (item.Id == 35)
                    txtClientPhone.Text= item.AttributeValue;
         
                if (item.Id == 33)
                    txtClientPhonePort.Text= item.AttributeValue;

                if (item.Id == 36 && item.AttributeValue!="")
                {
                        Base64 = item.AttributeValue;
                        var pic = Convert.FromBase64String(item.AttributeValue);                
                        using (MemoryStream ms = new MemoryStream(pic))
                        {
                            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox1.Image = Image.FromStream(ms);
                        }
                }
        
                if (item.Id == 38)
                    cmbcompanysms.Text = item.AttributeValue;
                if (item.Id == 39) 
                    cmbpartysms.Text = item.AttributeValue;    
                if (item.Id == 40)
                    cmbcompanytype.Text = item.AttributeValue;
                if (item.Id == 41)
                    cmbpartyenable.Text = item.AttributeValue;
                if (item.Id == 42)
                    cmbproductenable.Text = item.AttributeValue;
                if (item.Id == 43) {
                    if (item.AttributeValue == "Google API")
                        radiogoogleapi.Checked = true;
                    else
                        radiogsm.Checked = true;
                }
                   
            }
        }

        private void InitSystem()
        {
        
            List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().ToList();
            _System = SystemSettings;
        }
       
        private List<SystemSetting> GetSystemIndicator()
        {
          int IndicatorId=  (int)cmbIndicators.SelectedValue;
         var list=   ReferencesHelper.GetIndicatorDetails(IndicatorId);
            List<SystemSetting> setting = _System.ToList();
            foreach (var item in setting) {
                if (item.Id == 1)
                    item.AttributeValue = txtClientName.Text;
                if (item.Id == 2)
                    item.AttributeValue = txtClientAddress.Text;
                if (item.Id == 3)
                    item.AttributeValue = txtClientCity.Text;      
                if (item.Id == 5)
                    item.AttributeValue = txtIndicatorPort.Text;
                if (radiogsm.Checked == true)
                {
                    if (item.Id == 33)
                        item.AttributeValue = txtClientPhonePort.Text;
                }
                if (item.Id == 35)
                    item.AttributeValue = txtClientPhone.Text;
                if (item.Id == 36)
                    item.AttributeValue = Base64;
               
                if (item.Id == 38)
                    item.AttributeValue = cmbcompanysms.Text;
                if (item.Id == 39)
                    item.AttributeValue = cmbpartysms.Text;
                if (item.Id == 40)
                    item.AttributeValue = cmbcompanytype.Text;
                if (item.Id == 41)
                    item.AttributeValue = cmbpartyenable.Text;
                if (item.Id == 42)
                    item.AttributeValue = cmbproductenable.Text;
                if (item.Id == 43)
                {
                    if (radiogoogleapi.Checked == true)
                        item.AttributeValue = "Google API";
                    else
                        item.AttributeValue = "GSM/Mobile";
                }
                // from dropdownvalue select

                if (item.Id == 6)
                    item.AttributeValue = (list.BaudRate).ToString();
                if (item.Id == 7)
                {
                    int p = list.Parity;
                    if(p==0)
                    item.AttributeValue = "None";
                    if (p == 1)
                        item.AttributeValue = "Odd";
                    if (p == 2)
                        item.AttributeValue = "Even";
                }
                   
                if (item.Id == 8)
                    item.AttributeValue = (list.ControlCharacter).ToString();
                if (item.Id == 9)
                    item.AttributeValue = list.Direction;
                if (item.Id == 11)
                    item.AttributeValue = list.FromBytes.ToString();
                if (item.Id == 12)
                    item.AttributeValue = list.BytesLength.ToString();
               if (item.Id==19)
                    item.AttributeValue = list.DataBit.ToString();
                if (item.Id == 20)
                {
                    int p = list.StopBit;
                   
                    if (p == 1)
                        item.AttributeValue = "One";
                    if (p == 2)
                        item.AttributeValue = "Two";
                }

            }
               
                //byte[] imagebt = null;
                //FileStream fstream = new FileStream((item.Cells[2].Value).ToString(),FileMode.Open,FileAccess.Read);
                //BinaryReader br = new BinaryReader(fstream);
                //imagebt = br.ReadBytes((int)fstream.Length);
                //setting.LOGO =(imagebt);
            

            return _System;
        }
        private bool IsValidate()
        {
            bool Result = false;
            string REQUIRED = "Required";

            if (this.txtClientName.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.txtClientName, REQUIRED);
                return Result;
            }

            if (this.txtIndicatorPort.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.txtIndicatorPort, REQUIRED);
                return Result;
            }
            if (this.cmbcompanysms.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.cmbcompanysms, REQUIRED);
                return Result;
            }
            if (this.cmbpartysms.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.cmbpartysms, REQUIRED);
                return Result;
            }
            if (this.cmbcompanytype.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.cmbcompanytype, REQUIRED);
                return Result;
            }
            if (this.cmbpartyenable.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.cmbpartyenable, REQUIRED);
                return Result;
            }
            if (this.cmbproductenable.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.cmbproductenable, REQUIRED);
                return Result;
            }
            return true;

        }
        // On Save Click start
        private void btnSave_Click(object sender, EventArgs e)
        {  
            if (IsValidate())
            {

                ReferencesHelper.UpdateSystemSettings(GetSystemIndicator());

                MessageBox.Show("Save Successfully");
                this.Hide();
               
                FrmMain obj = new FrmMain();
                GlobalsHelper.MainForm = obj;
                obj.ShowDialog();             
            }
           
          
           
        }
        // On Save Click end
        // On Cancel Click start
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // On Cancel Click end

        // Mathod For Get Base64 From Image start
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
        // Mathod For Get Base64 From Image end

        // Mathod For Get Image From Base64 start
        public static Image GetImageFromString(string base64String)
        {
            byte[] buffer = Convert.FromBase64String(base64String);

            if (buffer != null)
            {
                ImageConverter ic = new ImageConverter();
                return ic.ConvertFrom(buffer) as Image;
            }
            else
                return null;
        }
        // Mathod For Get Image From Base64 end

        private void BrowseLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult re = ofd.ShowDialog();
            if (re == DialogResult.OK)
            {
                i = Image.FromFile(ofd.FileName);
                b = (Bitmap)i;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = b;
          Base64=       GetStringFromImage(b);



            }
        }
        // Indicator Dropdown Load start
        private void InitIndicators()
        {
            List<Indicators> indicator = ReferencesHelper.AllIndicators();

            indicator = indicator.ToList();
            indicator.Add(new Indicators() { ID = 0, ModelNo = string.Empty });

            this.cmbIndicators.DataSource = indicator;
            this.cmbIndicators.DisplayMember = "ModelNo";
            this.cmbIndicators.ValueMember = "ID";

        }
        //Indicator Dropdown Load end

        private void SetupForm_Load(object sender, EventArgs e)
        {

        }

       

        private void cmbpartysms_TextChanged(object sender, EventArgs e)
        {
            string partysms = cmbpartysms.Text;
            if (partysms == "TRUE")
            {
                cmbpartyenable.Text = "TRUE";
            }
            else {
                cmbpartyenable.Text = "FALSE";
            }
        }

        private void radiogoogleapi_CheckedChanged(object sender, EventArgs e)
        {
            if (radiogoogleapi.Checked == true)
            {
                lblsmsport.Visible = false;
                txtClientPhonePort.Visible = false;
            }
            else {
                lblsmsport.Visible = true;
                txtClientPhonePort.Visible = true;
            }
        }

        private void radiogsm_CheckedChanged(object sender, EventArgs e)
        {
            if (radiogsm.Checked == true)
            {
                lblsmsport.Visible = true;
                txtClientPhonePort.Visible = true;
            }
            else
            {
                lblsmsport.Visible = false;
                txtClientPhonePort.Visible = false;
            }
        }
    }
}
