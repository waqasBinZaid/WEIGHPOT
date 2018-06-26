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
using static LibraScales.ScaleSoft.GlobalsHelper;

namespace ITWhiz.ScaleSoft.Desktop
{
    public partial class FrmSetup : Form
    {
        public FrmSetup()
        {
            InitializeComponent();
        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            SaveLicense();
        }

        private void SaveLicense()
        {
            LicenseInfo license = ValidateInputs();

            if (license != null)
            {
                string serialisedString = GlobalsHelper.Serialze(license);
                SystemSetting licenseSetting = new SystemSetting()
                {
                    AttributeKey = SystemSettingKeys.LICENSE_INFO.ToString(),
                    AttributeValue = serialisedString,
                    AttributeLabel = "License",
                    AttributeType = "PRIVATE"
                };

                ReferencesHelper.AddSystemSetting(licenseSetting);

                this.Close();
            }

        }

        private LicenseInfo ValidateInputs()
        {
            LicenseInfo license = null;
            this.ep.Clear();

            if (this.txtName.TextLength == 0)
            {
                this.txtName.Focus();
                this.ep.SetError(this.txtName, "required");
                return license;
            }

            if (this.txtContactNumber.TextLength == 0)
            {
                this.txtContactNumber.Focus();
                this.ep.SetError(this.txtContactNumber, "required");
                return license;
            }

            if (this.cboType.SelectedItem.ToString().Length == 0)
            {
                this.cboType.Focus();
                this.ep.SetError(this.cboType, "required");
                return license;
            }

            if (this.txtSerial.TextLength == 0)
            {
                this.txtSerial.Focus();
                this.ep.SetError(this.txtSerial, "required");
                return license;
            }

            if (this.txtSerial.TextLength != 0)
            {
                UInt32 uid = Convert.ToUInt32(this.txtSerial.Text);
                license = RockeyHelper.GetLicense(uid);

                if (license.InternalSerial == 0)
                {
                    this.txtSerial.Focus();
                    this.ep.SetError(this.txtSerial, "License serial and USB token are not matched");
                    return null;
                }

                license.Name = this.txtName.Text;
                license.ContactNumber = this.txtContactNumber.Text;
                license.LicenseType = this.cboType.Text;
            }

            return license;

        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
