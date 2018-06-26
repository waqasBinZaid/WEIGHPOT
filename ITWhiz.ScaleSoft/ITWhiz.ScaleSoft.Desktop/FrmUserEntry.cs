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

namespace IWeigh
{
    public partial class FrmUserEntry : Form
    {
        public FrmUserEntry()
        {
            InitializeComponent();
            Init();
            InitRoles();
        }

        public FrmUserEntry(User UserEntry)
        {
            InitializeComponent();
            InitRoles();
            Set(UserEntry);
        }

        private void Set(User UserEntry)
        {
            if (UserEntry != null)
            {
                this.txtName.Text = UserEntry.Name;
                this.txtName.Tag = UserEntry;
                //this.txtPassword.Text = UserEntry.Password;
                this.txtLoginId.Text = UserEntry.LoginId;
                this.cboType.SelectedValue = UserEntry.RoleId;
                //this.chkStatus.Checked = (UserEntry.Status == "TRUE" ? true : false);
            }
        }

        private void Init()
        {
            this.txtName.Text = string.Empty;
            this.txtName.Tag = null;
            this.txtPassword.Text = string.Empty;
            this.txtLoginId.Text = string.Empty;
            this.cboType.Text = string.Empty;
            this.chkStatus.Checked = false;
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

            if (this.cboType.Text.Trim().Length == 0)
            {
                this.ep.SetError(this.cboType, REQUIRED);
                return Result;
            }

            return true;    

        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                User UserEntry = new User();
                if (this.txtName.Tag != null)
                {
                    UserEntry = (User)this.txtName.Tag;
                    UserEntry.Name = this.txtName.Text;
                    UserEntry.LoginId = this.txtLoginId.Text;
                    string password = FrmUsers.pass;

                    if (this.txtPassword.Text == null || this.txtPassword.Text.Trim() == "")
                        UserEntry.Password = password;
                    else
                        UserEntry.Password = UtilsHelper.GetHash(this.txtPassword.Text);

                    UserEntry.RoleId = (int) this.cboType.SelectedValue;
                    
                    //UserEntry.Status = (this.chkStatus.Checked ? "TRUE" : "FALSE");

                    ReferencesHelper.UpdateUser(UserEntry);

                }
                else
                {
                    UserEntry.Name = this.txtName.Text;
                    UserEntry.LoginId = this.txtLoginId.Text;
                    UserEntry.Password = UtilsHelper.GetHash(this.txtPassword.Text);
                    UserEntry.RoleId = (int)this.cboType.SelectedValue;

                    ReferencesHelper.AddUser(UserEntry);
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

        private void InitRoles()
        {
            this.cboType.Items.Clear();

            List<UserSecurityRole> SecurityRoles = ReferencesHelper.GetSecurityRoles();

            this.cboType.DataSource = SecurityRoles.OrderBy(o => o.Name).ToList();
            this.cboType.DisplayMember = "Name";
            this.cboType.ValueMember = "Id";
        }

        private void FrmUserEntry_Load(object sender, EventArgs e)
        {
            var user = GlobalsHelper.LoggedInUser;
            if (user.RoleId == 1)
            {
                cboType.Enabled = true;
            }
            else {
                cboType.Enabled = false;
            }
        }
    }
}
