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
using static LibraScales.ScaleSoft.GlobalsHelper;

namespace IWeigh
{
    public partial class FrmPartyEntry : Form
    {

        private UIMode _UIMode = UIMode.NEW_RECORD;
        private Client _ClientEntry = new Client();

        public FrmPartyEntry()
        {
            InitializeComponent();
            Init();
            _UIMode = UIMode.NEW_RECORD;
        }

        public FrmPartyEntry(Client ClientEntry)
        {
            InitializeComponent();
            Set(ClientEntry);
            _UIMode = UIMode.EDIT_RECORD;
            _ClientEntry = ClientEntry;
        }

        private void Set(Client ClientEntry)
        {
            if (ClientEntry != null)
            {
                this.txtName.Text = ClientEntry.Name;
                this.txtName.Tag = ClientEntry;
                this.txtCity.Text = ClientEntry.City;
                this.txtAddress.Text = ClientEntry.Address;
                this.cboType.Text = ClientEntry.Type;
                this.txtPhone.Text = ClientEntry.ClientPhone;
                this.chkStatus.Checked = (ClientEntry.Status == "TRUE" ? true : false);
            }
        }

        private void Init()
        {
            this.txtName.Text = string.Empty;
            this.txtName.Tag = null;
            this.txtCity.Text = string.Empty;
            this.txtAddress.Text = string.Empty;
            this.cboType.Text = string.Empty;
            this.txtPhone.Text = string.Empty;
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

            if (ReferencesHelper.DuplicateEntryFound("Client", "Name", this.txtName.Text, " AND Id != " + _ClientEntry.Id))
            {
                this.ep.SetError(this.txtName, "Name already exist");
                return Result;
            }
            
            return true;

        }

        private void CmdOK_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                Client ClientEntry = new Client();
                if (this.txtName.Tag != null)
                {
                    ClientEntry = (Client)this.txtName.Tag;
                    ClientEntry.Name = this.txtName.Text;
                    ClientEntry.Type = this.cboType.Text;
                    ClientEntry.City = this.txtCity.Text;
                    ClientEntry.Address = this.txtAddress.Text;
                    ClientEntry.Status = (this.chkStatus.Checked ? "TRUE" : "FALSE");
                    ClientEntry.ClientPhone = this.txtPhone.Text;
                    ReferencesHelper.UpdateClient(ClientEntry);

                }
                else
                {
                    ClientEntry.Name = this.txtName.Text;
                    ClientEntry.Type = this.cboType.Text;
                    ClientEntry.City = this.txtCity.Text;
                    ClientEntry.Address = this.txtAddress.Text;
                    ClientEntry.Status = (this.chkStatus.Checked ? "TRUE" : "FALSE");
                    ClientEntry.ClientPhone = this.txtPhone.Text;
                    ReferencesHelper.AddClient(ClientEntry);
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

        private void FrmPartyEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
