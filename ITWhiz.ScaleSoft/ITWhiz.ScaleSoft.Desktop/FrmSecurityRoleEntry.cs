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

namespace IWeigh
{
    public partial class FrmSecurityRoleEntry : Form
    {
        private UserSecurityRole _SecurityRole = null;

        public FrmSecurityRoleEntry()
        {
            InitializeComponent();
            Init();
        }

        public FrmSecurityRoleEntry(UserSecurityRole RoleEntry)
        {
            InitializeComponent();
            _SecurityRole = RoleEntry;
            Init();
            Set(RoleEntry);
        }

        private void Set(UserSecurityRole RoleEntry)
        {
            if (RoleEntry != null)
            {
                this.txtName.Text = RoleEntry.Name;
                this.txtName.Tag = RoleEntry;
                this.chkStatus.Checked = (RoleEntry.Status == "TRUE" ? true : false);
                SetRoleDetails(RoleEntry.Id);
            }
        }

        private void Init()
        {
            this.txtName.Text = string.Empty;
            this.txtName.Tag = null;
            //this.chkStatus.Checked = false;

            InitRoleDetails();
        }

        private bool IsValidate()
        {
            bool Result = false;
            string REQUIRED = "Required";

            if (this.txtName.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.txtName, REQUIRED);
                return Result;
            }

            return true;

        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                UserSecurityRole USREntry = new UserSecurityRole();
                if (this.txtName.Tag != null)
                {
                    USREntry = (UserSecurityRole)this.txtName.Tag;
                    USREntry.Name = this.txtName.Text;
                    USREntry.Status = (this.chkStatus.Checked ? "TRUE" : "FALSE");
                    

                    ReferencesHelper.UpdateSecurityRole(USREntry, GetUserSecurityRoleDetail());

                }
                else
                {
                    USREntry.Name = this.txtName.Text;
                    USREntry.Status = (this.chkStatus.Checked ? "TRUE" : "FALSE");
                   
                    ReferencesHelper.AddSecurityRole(USREntry, GetUserSecurityRoleDetail());
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void InitRoleDetails()
        {
            this.dgv.Rows.Clear();

            this.dgv.Rows.Add("Weighment", "Weighment Entry", false, false, "WEIGHMENT_ENTRY");
            this.dgv.Rows.Add("Weighment", "Weighment Listing", false, false, "WEIGHMENT_LISTING");

            this.dgv.Rows.Add("Parties", "Party Entry", false, false, "PARTY_ENTRY");
            this.dgv.Rows.Add("Parties", "Party Listing", false, false, "PARTY_LISTING");

            //this.dgv.Rows.Add("Products", "Category Entry", false, false, "CATEGORY_ENTRY");
            this.dgv.Rows.Add("Products", "Product Entry", false, false, "PRODUCT_ENTRY");

            //this.dgv.Rows.Add("Products", "Category Listing", false, false, "CATEGORY_LISTING");
            this.dgv.Rows.Add("Products", "Products Listing", false, false, "PRODUCT_LISTING");

            this.dgv.Rows.Add("Reports", "Products Listing", false, false, "REPORT_PRODUCT_LISTING");
            this.dgv.Rows.Add("Reports", "Parties Listing", false, false, "REPORT_PARTIES_LISTING");
            this.dgv.Rows.Add("Reports", "Weighment Listing", false, false, "REPORT_WEIGHMENT_LISTING");
            this.dgv.Rows.Add("Reports", "Party wise Weighment Listing", false, false, "REPORT_PARTY_WISE_LISTING");
            this.dgv.Rows.Add("Reports", "Product wise Weighment Listing", false, false, "REPORT_PRODUCT_WISE_LISTING");

            this.dgv.Rows.Add("Administration", "System Settings", false, false, "ADMINISTRATION_SYSTEM_SETTINGS");
            this.dgv.Rows.Add("Administration", "User Entry", false, false, "ADMINISTRATION_USERS_ENTRY");
            this.dgv.Rows.Add("Administration", "User Listing", false, false, "ADMINISTRATION_USERS_LISTING");
            this.dgv.Rows.Add("Administration", "Security Role Entry", false, false, "ADMINISTRATION_SECURITY_ROLE_ENTRY");
            this.dgv.Rows.Add("Administration", "Security Role Listing", false, false, "ADMINISTRATION_SECURITY_ROLE_LISTING");
            this.dgv.Rows.Add("Administration", "Backup Database", false, false, "ADMINISTRATION_BACKUP_DATABASE");
            this.dgv.Rows.Add("Administration", "Restore Database", false, false, "ADMINISTRATION_RESTORE_DATABASE");

        }

        private void SetRoleDetails(int RoleId)
        {
            if (RoleId != 0)
            {
                List<UserSecurityRoleDetail> RoleDetails = ReferencesHelper.GetSecurityRoleDetails(RoleId);

                foreach (DataGridViewRow item in this.dgv.Rows)
                {
                    string screenName = item.Cells[4].Value.ToString();
                    UserSecurityRoleDetail usrd = RoleDetails.Where(o => o.ScreenName == screenName).FirstOrDefault();

                    if (usrd != null)
                    {
                        item.Cells[2].Value = usrd.Read;
                        item.Cells[3].Value = usrd.Write;
                    }
                }

            }

        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
            cell = (DataGridViewCheckBoxCell)dgv.Rows[dgv.CurrentRow.Index].Cells[e.ColumnIndex];

            if (cell.Value == null)
                cell.Value = false;
            switch (cell.Value.ToString().ToLower())
            {
                case "true":
                    cell.Value = false;
                    break;
                case "false":
                    cell.Value = true;
                    break;
            }
        }

        private List<UserSecurityRoleDetail> GetUserSecurityRoleDetail()
        {
            List<UserSecurityRoleDetail> USRDs = new List<UserSecurityRoleDetail>();

            foreach (DataGridViewRow item in this.dgv.Rows)
            {
                if (item.Cells[2].Value.ToString().ToLower() == "true" || item.Cells[3].Value.ToString().ToLower() == "true")
                {

                    UserSecurityRoleDetail usrd = new UserSecurityRoleDetail();
                    usrd.Module = item.Cells[0].Value.ToString();
                    usrd.SubModule = item.Cells[1].Value.ToString();
                    usrd.Read = item.Cells[2].Value.ToString();
                    usrd.Write = item.Cells[3].Value.ToString();
                    //usrd.Remove = item.Cells[0].Value.ToString();
                    usrd.ScreenName = item.Cells[4].Value.ToString();

                    USRDs.Add(usrd);

                }
            }

            return USRDs;
        }

        private void chkReadAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in this.dgv.Rows)
            {
                row.Cells[2].Value = chkReadAll.Checked;
            }
        }

        private void chkWriteAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dgv.Rows)
            {
                row.Cells[3].Value = chkReadAll.Checked;
            }
        }
    }
}
