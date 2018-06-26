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
namespace ITWhiz.ScaleSoft.Desktop
{
    public partial class FrmOption : Form
    {
        private Logger _Logger = LogManager.GetCurrentClassLogger();
        public FrmOption()
        {
            InitializeComponent();
        }

        private void FrmOption_Load(object sender, EventArgs e)
        {

        }
        public static string FirstWeightClick;
        public static string SecondWeightClick;
        private void CheckingLicensing()
        {
            List<SystemSetting> systemSettings = ReferencesHelper.GetSystemSettings();
            SystemSetting licenseInfo = systemSettings.Where(o => o.AttributeKey == SystemSettingKeys.LICENSE_INFO.ToString()).FirstOrDefault();

           
                LicenseInfo license = (LicenseInfo)GlobalsHelper.DeSerialze(licenseInfo.AttributeValue, new LicenseInfo());
            uint SerialNo = 2618208898;
                LicenseInfo rLicense = RockeyHelper.GetLicense(SerialNo);

                if (rLicense.InternalSerial== 2564932284)
                {
                    _Logger.Info("Valid license found + " + license.InternalSerial);
                    this.Hide();
                FirstWeightClick = "First Weight";
                FrmWeighmentEntry WeighmentEntry = new FrmWeighmentEntry(Common.Globals.WEIGHMENT_ENTRY.FIRST);
                WeighmentEntry.ShowDialog();
                this.Close();
                }
                else
                {
                    Weighment recordcount = ReferencesHelper.WeighmentRecordCount().First();
                    int record = recordcount.Id;
                    if (record <= 100)
                    {
                        this.Hide();
                    FirstWeightClick = "First Weight";
                    FrmWeighmentEntry WeighmentEntry = new FrmWeighmentEntry(Common.Globals.WEIGHMENT_ENTRY.FIRST);
                    WeighmentEntry.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Trial Period Over!");
                        this.Close();
                    }

                }
               
            }

   
        private void btnfirstweight_Click(object sender, EventArgs e)
        {
            List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
            var type = SystemSettings.Where(o => o.Id == 40).FirstOrDefault();
            if (type.AttributeValue == "Non Commercial")
            {
                FirstWeightClick = "First Weight";
                FrmWeighmentEntry WeighmentEntry = new FrmWeighmentEntry(Common.Globals.WEIGHMENT_ENTRY.FIRST);
                WeighmentEntry.ShowDialog();
            }
            else if(type.AttributeValue=="Commercial"){
                FirstWeightClick = "First Weight";
                FrmComWeighmentEntry WeighmentEntry = new FrmComWeighmentEntry(Common.Globals.WEIGHMENT_ENTRY.FIRST);
                WeighmentEntry.ShowDialog();
            }
        }
        private void btnsecondweight_Click(object sender, EventArgs e)
        {
            List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
            var type = SystemSettings.Where(o => o.Id == 40).FirstOrDefault();
            if (type.AttributeValue == "Non Commercial")
            {
                SecondWeightClick = "Second Weight";
                FrmWeighmentEntry WeighmentEntry = new FrmWeighmentEntry(Common.Globals.WEIGHMENT_ENTRY.SECOND);

                WeighmentEntry.ShowDialog();
            }
            else if (type.AttributeValue == "Commercial")
            {
                SecondWeightClick = "Second Weight";
                FrmComWeighmentEntry WeighmentEntry = new FrmComWeighmentEntry(Common.Globals.WEIGHMENT_ENTRY.SECOND);
                WeighmentEntry.ShowDialog();
            }
        }
        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        
    }
}
