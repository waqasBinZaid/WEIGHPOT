using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWeigh;
using NLog;
using System.Threading;
using static LibraScales.ScaleSoft.GlobalsHelper;
using LibraScales.ScaleSoft;
using System.Net.NetworkInformation;

namespace ITWhiz.ScaleSoft.Desktop
{
    public partial class FrmSpalsh : Form
    {
        private Logger _Logger = LogManager.GetCurrentClassLogger();
        public static string GetMACAddress2()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }
        public FrmSpalsh()
        {
            InitializeComponent();
            this.lblMessage.Text = "Initialising Components...";
            _Logger.Info(this.lblMessage.Text);


        }

        private void initUSBDrives()
        {
            //this.cboUSBDrives.Items.Clear();

            //List<USBDeviceInfo> usbDevices = UtilsHelper.GetUSBDrives();

            //this.cboUSBDrives.DataSource = usbDevices.OrderBy(o => o.Name).ToList();
            //this.cboUSBDrives.DisplayMember = "Name";
            //this.cboUSBDrives.ValueMember = "Id";
        }

        private void CheckingDatabaseConnection()
        {
            UtilsHelper.TestDatabaseConnection();
        }

        private void CheckingLicensing()
        {
            List<SystemSetting> systemSettings = ReferencesHelper.GetSystemSettings();

            SystemSetting licenseInfo = systemSettings.Where(o => o.AttributeKey == SystemSettingKeys.LICENSE_INFO.ToString()).FirstOrDefault();

            if (licenseInfo == null)
            {
                FrmSetup setupForm = new FrmSetup();
                if (setupForm.ShowDialog() == DialogResult.OK)
                {
                    this.Hide();
                    FrmLogin FrmLogin = new FrmLogin(ApplicationMode.LICSENSED);
                    FrmLogin.ShowDialog();
                    this.Close();
                }
                else
                Application.Exit();
               
            }
            else
            {
            //    LicenseInfo license = (LicenseInfo)GlobalsHelper.DeSerialze(licenseInfo.AttributeValue, new LicenseInfo());
                uint SerialNo = 2618208898;
                LicenseInfo rLicense = RockeyHelper.GetLicense(SerialNo);
                
             
                if (rLicense.InternalSerial== 2564932284)
                {
                    _Logger.Info("Valid license found + " + rLicense.InternalSerial);
                    this.Hide();
                    FrmLogin FrmLogin = new FrmLogin(ApplicationMode.LICSENSED);
                    FrmLogin.ShowDialog();
                    this.Close();
                }
                else {
                    Weighment recordcount = ReferencesHelper.WeighmentRecordCount().First();
                    int record = recordcount.Id;
                    if (record <= 100)
                    {
                        this.Hide();
                        FrmLogin FrmLogin = new FrmLogin(ApplicationMode.TRIAL);
                        FrmLogin.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Trial Period Over!");
                        this.Close();
                    }

                }
                //Commented by Tahir ... Once it will be tested then will be reinstated 
                //else
                //{
                //    MessageBox.Show("Not valid license found", "License validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    //Application.Exit();
                //}
            }

        }
        private void CheckingMacAddress() {
            SystemSetting Mac = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeLabel == "Mac Address").First();
            var dbMacAddress = Mac.AttributeValue;
            string macaddress = GetMACAddress2().ToString();


            if (macaddress == dbMacAddress)
            {

                FrmLogin FrmLogin = new FrmLogin(ApplicationMode.LICSENSED);
                FrmLogin.ShowDialog();
                this.Close();
            }
            if (macaddress != dbMacAddress)
            {

                Weighment recordcount = ReferencesHelper.WeighmentRecordCount().First();
                int record = recordcount.Id;
                if (record <= 100)
                {
                    FrmLogin FrmLogin = new FrmLogin(ApplicationMode.TRIAL);
                }
                else
                {
                    MessageBox.Show("Trial Period Over!");
                    this.Close();
                }
            }

        }
        private void SetDelay()
        {
            Thread.Sleep(3000);
        }


        private void FrmSpalsh_Activated(object sender, EventArgs e)
        {

        }

        private void FrmSpalsh_Shown(object sender, EventArgs e)
        {
            
            
               

            SetDelay();

            this.lblMessage.Text = "Checking Database Connection...";
            _Logger.Info(this.lblMessage.Text);
            CheckingDatabaseConnection();
            SetDelay();

            this.lblMessage.Text = "Checking License...";
            _Logger.Info(this.lblMessage.Text);
            CheckingLicensing();

            SetDelay();
            //CheckingMacAddress();
            //SetDelay();
            this.lblMessage.Text = "Finishing Initialisation...";
            _Logger.Info(this.lblMessage.Text);

            

            
            
        }
        
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            FrmLogin FrmLogin = new FrmLogin(ApplicationMode.TRIAL);
            FrmLogin.ShowDialog();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmSpalsh_Load(object sender, EventArgs e)
        {

        }
    }
}
