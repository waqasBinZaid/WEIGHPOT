using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
using ITWhiz.ScaleSoft.Desktop;
using ITWhiz.ScaleSoft.Common;
using ITWhiz.ScaleSoft.Desktop.Controls;
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

namespace IWeigh
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            SetTrip();
            var setting = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
            var party = setting.Where(o => o.Id == 40).FirstOrDefault();

            if (party.AttributeValue == "Commercial")
            {
                weighmentUserWiseToolStripMenuItem.Enabled = true;
                weighmentUserWiseToolStripMenuItem.Visible = true;
            }
            else {

                weighmentUserWiseToolStripMenuItem.Enabled = false;
                weighmentUserWiseToolStripMenuItem.Visible = false;
            }
            SystemSetting SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.Id == 1).First();
            this.Text =SystemSettings.AttributeValue;
            //UserApplicationMode.ToString()

            
            if (GlobalsHelper.UserApplicationMode == GlobalsHelper.ApplicationMode.LICSENSED) {
                this.Text = this.Text + " (Application mode - " + GlobalsHelper.ApplicationMode.LICSENSED + ")" + "\t \t \t \t \t IBTS - WeighPot";
                this.statusBar.Items[1].Text = GlobalsHelper.LoggedInUser.Name;
            }
            else 
            if (GlobalsHelper.UserApplicationMode == GlobalsHelper.ApplicationMode.TRIAL) {
                this.Text = this.Text + " (Application mode - " + GlobalsHelper.ApplicationMode.TRIAL + ")" + "\t \t \t \t \t IBTS - WeighPot";
                this.statusBar.Items[1].Text = GlobalsHelper.LoggedInUser.Name;

            }
            //this.statusBar.Items[1].Text = GlobalsHelper.LoggedInUserRole;
           
        }
        public static string FirstWeightClick;
        public static string SecondWeightClick;
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void weighbridgeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            FrmWeighbridge newMDIChild = new FrmWeighbridge();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show(); 
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConfiguration newMDIChild = new FrmConfiguration();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show(); 

        }

        private void tsConfigurations_Click(object sender, EventArgs e)
        {
            FrmConfiguration Configurations = new FrmConfiguration();
            Configurations.MdiParent = this;
            Configurations.Show();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsWeighment_Click(object sender, EventArgs e)
        {
            FrmWeighbridge Weighbridges = new FrmWeighbridge();
            Weighbridges.MdiParent = this;
            Weighbridges.Show();

        }

      //  [Authorize(GlobalsHelper.ScreenName.PARTY_LISTING, GlobalsHelper.AccessType.READ)]
        private void tsParties_Click(object sender, EventArgs e)
        {
            FrmParties Parties = new FrmParties();
            Parties.MdiParent = this;
            Parties.Show();
        }

        private void tsProducts_Click(object sender, EventArgs e)
        {
            FrmProducts Products = new FrmProducts();
            Products.MdiParent = this;
            Products.Show();
        }

        //private void tsmiCategory_Click(object sender, EventArgs e)
        //{
        //    FrmCategory Categories = new FrmCategory();
        //    Categories.MdiParent = this;
        //    Categories.Show();
        //}

     //   [Authorize(GlobalsHelper.ScreenName.ADMINISTRATION_SECURITY_ROLE_LISTING, GlobalsHelper.AccessType.READ)]
        private void tsmiSecurityRole_Click(object sender, EventArgs e)
        {
            FrmSecurityRole SecurityRoles = new FrmSecurityRole();
            SecurityRoles.MdiParent = this;
            SecurityRoles.Show();
        }

    //    [Authorize(GlobalsHelper.ScreenName.REPORT_PARTIES_LISTING, GlobalsHelper.AccessType.READ)]
        private void tsmiPartiesListing_Click(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource dsReport = null;
            dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("ClientsListing", ReferencesHelper.GetDataTable("Client", string.Empty));
            FrmReportViewer ReportViewer = new FrmReportViewer("Clients.rdlc", null, dsReport);
            //ReportViewer.MdiParent = this;
            ReportViewer.ShowDialog();
        }

     //   [Authorize(GlobalsHelper.ScreenName.ADMINISTRATION_USERS_LISTING, GlobalsHelper.AccessType.READ)]
        private void tsmiUser_Click(object sender, EventArgs e)
        {
            FrmUsers Users = new FrmUsers();
            Users.MdiParent = this;
            Users.Show();
        }

      //  [Authorize(GlobalsHelper.ScreenName.ADMINISTRATION_BACKUP_DATABASE, GlobalsHelper.AccessType.READ)]
        private void tsmiBackup_Click(object sender, EventArgs e)
        {
            saveBackupFile.FileName = Program.COMPANY_NAME + "-" + DateTime.Now.ToString("yyyy-MM-dd hhmmss") + ".db3";
            if (saveBackupFile.ShowDialog() == DialogResult.OK)
            {
                string sourceDatabaseFile = AppDomain.CurrentDomain.GetData("DataDirectory") + @"\ScaleSoft.db3";
                File.Copy(sourceDatabaseFile, saveBackupFile.FileName);
            }
        }

      //  [Authorize(GlobalsHelper.ScreenName.ADMINISTRATION_RESTORE_DATABASE, GlobalsHelper.AccessType.READ)]
        private void tsmiRestore_Click(object sender, EventArgs e)
        {
            if (openRestoreFile.ShowDialog() == DialogResult.OK)
            {

            }
        }

     //   [Authorize(GlobalsHelper.ScreenName.WEIGHMENT_LISTING, GlobalsHelper.AccessType.READ)]
        private void tsmiWeighments_Click(object sender, EventArgs e)
        {
            FrmWeighments Weighments = new FrmWeighments();
            Weighments.MdiParent = this;
            Weighments.Show();
        }

    //    [Authorize(GlobalsHelper.ScreenName.WEIGHMENT_ENTRY, GlobalsHelper.AccessType.WRITE)]
        private void tsmiWeighmentEntry_Click(object sender, EventArgs e)
        {
            //FrmOption opt = new FrmOption();
            //try
            //{
            //    opt.ShowDialog();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
            var type = SystemSettings.Where(o => o.Id == 40).FirstOrDefault();
            if (type.AttributeValue == "Non Commercial")
            {
                FirstWeightClick = "First Weight";
                FrmWeighmentEntry WeighmentEntry = new FrmWeighmentEntry(ITWhiz.ScaleSoft.Common.Globals.WEIGHMENT_ENTRY.FIRST);
                WeighmentEntry.ShowDialog();
            }
            else if (type.AttributeValue == "Commercial")
            {
                FirstWeightClick = "First Weight";
                FrmComWeighmentEntry WeighmentEntry = new FrmComWeighmentEntry(ITWhiz.ScaleSoft.Common.Globals.WEIGHMENT_ENTRY.FIRST);
                WeighmentEntry.ShowDialog();
            }
        }

        //[Authorize(GlobalsHelper.ScreenName.CATEGORY_LISTING, GlobalsHelper.AccessType.READ)]
        //private void tsmiPCategory_Click(object sender, EventArgs e)
        //{
        //    FrmCategory Categories = new FrmCategory();
        //    Categories.MdiParent = this;
        //    Categories.Show();
        //}

    //    [Authorize(GlobalsHelper.ScreenName.PRODUCT_LISTING, GlobalsHelper.AccessType.READ)]
        private void tsmiProducts_Click(object sender, EventArgs e)
        {
            FrmProducts Products = new FrmProducts();
            Products.MdiParent = this;
            Products.Show();
        }
        private void tsmiParties_Click(object sender, EventArgs e)
        {
            FrmParties Parties = new FrmParties();
            Parties.MdiParent = this;
            Parties.Show();
        }
    //    [Authorize(GlobalsHelper.ScreenName.ADMINISTRATION_SYSTEM_SETTINGS, GlobalsHelper.AccessType.READ)]
        private void tsmiSystemSettings_Click(object sender, EventArgs e)
        {
            FrmSystemSettings SystemSettings = new FrmSystemSettings();
            //SystemSettings.MdiParent = this;
            SystemSettings.ShowDialog();
        }

    //    [Authorize(GlobalsHelper.ScreenName.REPORT_WEIGHMENT_LISTING, GlobalsHelper.AccessType.READ)]
        private void tsmiWeighmentListing_Click(object sender, EventArgs e)
        {
            FrmReportParameter ReportParamForm = new FrmReportParameter(GlobalsHelper.ReportType.GENERAL_WEIGHMENT_LISTING);
            ReportParamForm.Text = "General Weighment Listing";
            ReportParamForm.ShowDialog();
            
        }

    //    [Authorize(GlobalsHelper.ScreenName.REPORT_PARTY_WISE_LISTING, GlobalsHelper.AccessType.READ)]
        private void tsmiProductWiseListing_Click(object sender, EventArgs e)
        {
            FrmReportParameter ReportParamForm = new FrmReportParameter(GlobalsHelper.ReportType.PARTY_WISE_WEIGHMENT_LISTING);
            ReportParamForm.Text = "Party wise Weighment Listing";
            ReportParamForm.ShowDialog();
        }

    //    [Authorize(GlobalsHelper.ScreenName.REPORT_PRODUCT_WISE_LISTING, GlobalsHelper.AccessType.READ)]
        private void tsmiProductwise_Click(object sender, EventArgs e)
        {
            FrmReportParameter ReportParamForm = new FrmReportParameter(GlobalsHelper.ReportType.PRODUCT_WISE_WEIGHMENT_LISTING);
            ReportParamForm.Text = "Product wise Weighment Listing";
            ReportParamForm.ShowDialog();
        }

    //    [Authorize(GlobalsHelper.ScreenName.REPORT_PRODUCT_LISTING, GlobalsHelper.AccessType.READ)]
        private void tsmiProductsListing_Click(object sender, EventArgs e)
        {
            Microsoft.Reporting.WinForms.ReportDataSource dsReport = null;
            dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsProductsListing", ReferencesHelper.GetDataTable("vwProductsListing", string.Empty));
            FrmReportViewer ReportViewer = new FrmReportViewer("Products.rdlc", null, dsReport);
            //ReportViewer.MdiParent = this;
            ReportViewer.ShowDialog();
        }

       
        private void tsbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiAboutSettings_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }
        public string RoundOff(string data)
        {
            string OldString = data;
            string NewString = System.Text.RegularExpressions.Regex.Replace(OldString, " {2,}", " ");
            string GetString = NewString.Trim();
            return GetString;
        }
        private void SetTrip() {
            var setting = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
            var party = setting.Where(o => o.Id == 41).FirstOrDefault();
            string p = RoundOff(party.AttributeValue);
            p = p.ToUpper();
            var product = setting.Where(o => o.Id == 42).FirstOrDefault();
            string pro = RoundOff(product.AttributeValue);
            pro = pro.ToUpper();
            if (p == "TRUE")
            {
                tsmiParties.Enabled = true;
                tsmiParties.Visible = true;
            }

            else
            {
                tsmiParties.Enabled = false;
                tsmiParties.Visible = false;
            }


            if (pro == "TRUE")
            {
                tsmiProducts.Enabled = true;
                tsmiProducts.Visible = true;
            }

            else
            {
                tsmiProducts.Enabled = false;
                tsmiProducts.Visible = false;
            }
        }
        private void SetType()
        {
            var setting = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
            var party = setting.Where(o => o.Id == 40).FirstOrDefault();
           
            if (party.AttributeValue == "Commercial")
            {
                FrmUpdateComWeighmentEntry com = new FrmUpdateComWeighmentEntry();
                com.ShowDialog();
            }

            else
            {
                FrmUpdateWeighmentEntry update = new FrmUpdateWeighmentEntry();
                update.ShowDialog();
            }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            
                
        }

        private void tsbAdministration_Click(object sender, EventArgs e)
        {

        }

        private void tsWeighments_Click(object sender, EventArgs e)
        {

        }

        private void tsmiReports_Click(object sender, EventArgs e)
        {

        }

        private void tsmiWeigmentDateWise_Click(object sender, EventArgs e)
        {
            FrmWeighmentDateWiseReport User = new FrmWeighmentDateWiseReport();
            User.MdiParent = this;
            User.Show();
        }

        private void tsmiWeigmentSerialWise_Click(object sender, EventArgs e)
        { 
            FrmWeighmentSerialWise Weighment = new FrmWeighmentSerialWise();
            Weighment.MdiParent = this;
            Weighment.Show();
        
    }

        private void tsmiUpdateWeighmentEntry_Click(object sender, EventArgs e)
        {
            var user = GlobalsHelper.LoggedInUser;
            if (user.RoleId == 1)
            {
                SetType();
            }
            else {
                MessageBox.Show("You Have No Permission!");
              }
           
        }

        private void tsddProducts_Click(object sender, EventArgs e)
        {
            SetTrip();
        }

        private void weighmentUserWiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmWeighmentUserWiseReport rpt = new FrmWeighmentUserWiseReport();
            rpt.ShowDialog();
        }

        private void companySettigsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetupForm frm = new SetupForm();
            frm.ShowDialog();
        }

        private void secondWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
            var type = SystemSettings.Where(o => o.Id == 40).FirstOrDefault();
            if (type.AttributeValue == "Non Commercial")
            {
                SecondWeightClick = "Second Weight";
                FrmWeighmentEntry WeighmentEntry = new FrmWeighmentEntry(ITWhiz.ScaleSoft.Common.Globals.WEIGHMENT_ENTRY.SECOND);

                WeighmentEntry.ShowDialog();
            }
            else if (type.AttributeValue == "Commercial")
            {
                SecondWeightClick = "Second Weight";
                FrmComWeighmentEntry WeighmentEntry = new FrmComWeighmentEntry(ITWhiz.ScaleSoft.Common.Globals.WEIGHMENT_ENTRY.SECOND);
                WeighmentEntry.ShowDialog();
            }
        }

        private void thirdWeightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PRIVATE").ToList();
            var type = SystemSettings.Where(o => o.Id == 40).FirstOrDefault();
           
            if (type.AttributeValue == "Commercial")
            {
                FirstWeightClick = "First Weight";
                FrmThirdWeighmentEntry WeighmentEntry = new FrmThirdWeighmentEntry(ITWhiz.ScaleSoft.Common.Globals.WEIGHMENT_ENTRY.SECOND);
                WeighmentEntry.ShowDialog();
            }
        }
    }
}
