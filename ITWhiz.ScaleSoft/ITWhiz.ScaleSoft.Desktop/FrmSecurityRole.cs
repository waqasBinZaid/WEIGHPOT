using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
using ITWhiz.ScaleSoft.Desktop.Controls;
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
    public partial class FrmSecurityRole : Form
    {
        public FrmSecurityRole()
        {
            InitializeComponent();
            InitList();
        }

        private void InitList()
        {
            List<UserSecurityRole>  SecurityRoles = ReferencesHelper.GetSecurityRoles();
            this.lst.Items.Clear();
            foreach (UserSecurityRole item in SecurityRoles)
            {
                ListViewItem nItem = this.lst.Items.Add(item.Name);
                nItem.SubItems.Add(item.Status);
                nItem.Tag = item;
            }

        }

        [Authorize(GlobalsHelper.ScreenName.ADMINISTRATION_SECURITY_ROLE_ENTRY, GlobalsHelper.AccessType.WRITE)]
        private void tsbNew_Click(object sender, EventArgs e)
        {
            FrmSecurityRoleEntry SecurityRoleEntry = new FrmSecurityRoleEntry();
            if (SecurityRoleEntry.ShowDialog() == DialogResult.OK)
                InitList();
        }

        [Authorize(GlobalsHelper.ScreenName.ADMINISTRATION_SECURITY_ROLE_ENTRY, GlobalsHelper.AccessType.WRITE)]
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.lst.SelectedItems.Count > 0)
            {
                UserSecurityRole RoleEntry = (UserSecurityRole)this.lst.SelectedItems[0].Tag;
                FrmSecurityRoleEntry CategoryEntryForm = new FrmSecurityRoleEntry(RoleEntry);
                if (CategoryEntryForm.ShowDialog() == DialogResult.OK)
                    InitList();
            }
        }

        private void lst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tsbEdit_Click(sender, new EventArgs());
        }
    }
}
