using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
using ITWhiz.ScaleSoft.Desktop;
using LibraScales.ScaleSoft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibraScales.ScaleSoft.GlobalsHelper;

namespace IWeigh
{
    public partial class FrmLogin : Form
    {
        private string Title = "Login - Welcome to IBTS - WeighPot";

        //public static PhysicalAddress GetMacAddress()

        //{
        //    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
        //    {
        //        // Only consider Ethernet network interfaces
        //        if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
        //            nic.OperationalStatus == OperationalStatus.Up)
        //        {
        //            return nic.GetPhysicalAddress();
        //        }
        //    }
        //    return null;
        //}
       

        public FrmLogin(ApplicationMode mode)
        {
            
            GlobalsHelper.UserApplicationMode = mode;
            this.Text = Title + " (Application mode - " + mode.ToString() +")";
            InitializeComponent();
        }


        private void CmdLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLogin())
            {
                this.Hide();
                SystemSetting ClientName = ReferencesHelper.GetSystemSettings().Where(o => o.Id == 1).First();
                string clientname = ClientName.AttributeValue;
                SystemSetting ClientIndicatorPort = ReferencesHelper.GetSystemSettings().Where(o => o.Id == 5).First();
                string clientindicatorport= ClientIndicatorPort.AttributeValue;
                SystemSetting ClientLogo = ReferencesHelper.GetSystemSettings().Where(o => o.Id == 36).First();
                string clientlogo= ClientLogo.AttributeValue;
                if (clientname.Trim() != "")
                {
                    this.Hide();
                    FrmMain FrmMain = new FrmMain();
                    GlobalsHelper.MainForm = FrmMain;
                    FrmMain.ShowDialog();
                    this.Close();
                }
                else {
                    this.Hide();
                    SetupForm obj = new SetupForm();
                    obj.ShowDialog();

                } 
            }
            
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //this.Close();
        }

        private bool ValidateLogin()
        {
            bool Result = true;
            
            this.ep.Clear();

            if (this.txtLoginId.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.txtLoginId, "Required");
                return false;
            }

            if (this.txtPassword.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.txtPassword, "Required");
                return false;
            }

            User loginUser = ReferencesHelper.ValidateLogin(this.txtLoginId.Text, this.txtPassword.Text);

            if (loginUser == null)
            {
                this.ep.SetError(this.txtPassword, "Login Id or Password is incorrect");
                return false;
            }

            GlobalsHelper.LoggedInUser = loginUser;
            GlobalsHelper.LoggedInUserRoleDetails = ReferencesHelper.GetSecurityRoleDetails(loginUser.RoleId);
            GlobalsHelper.SystemSettings = ReferencesHelper.GetSystemSettings();

            return Result;

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
