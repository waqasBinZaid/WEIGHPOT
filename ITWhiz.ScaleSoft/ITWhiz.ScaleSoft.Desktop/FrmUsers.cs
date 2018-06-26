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
    public partial class FrmUsers : Form
    {
        public static string pass;
        public FrmUsers()
        {
            InitializeComponent();
            InitList();
        }

        private void InitList()
        {
      var user=GlobalsHelper.LoggedInUser;
            int roleid = user.RoleId; 
            if (roleid==1) {
                List<User> Users = ReferencesHelper.GetUsers();
                this.lst.Items.Clear();
                foreach (User item in Users)
                {
                    ListViewItem nItem = this.lst.Items.Add(item.Name);
                    nItem.Tag = item;
                    nItem.SubItems.Add(item.LoginId);
                    nItem.SubItems.Add(item.RoleId.ToString());

                }
            }
            else
            {
                List<User> Users = ReferencesHelper.GetUsers().Where(o => o.Id == user.Id).ToList();
                this.lst.Items.Clear();
                foreach (User item in Users)
                {
                    ListViewItem nItem = this.lst.Items.Add(item.Name);
                nItem.Tag = item;
                nItem.SubItems.Add(item.LoginId);
                nItem.SubItems.Add(item.RoleId.ToString());

                }
            }


        }

      //  [Authorize(GlobalsHelper.ScreenName.ADMINISTRATION_USERS_ENTRY, GlobalsHelper.AccessType.WRITE)]
        private void tsbNew_Click(object sender, EventArgs e)
        {
            var user = GlobalsHelper.LoggedInUser;
            if (user.RoleId == 1)
            {
                FrmUserEntry UserEntry = new FrmUserEntry();
                if (UserEntry.ShowDialog() == DialogResult.OK)
                    InitList();
            }
            else {
                MessageBox.Show("You Have No Permission!");
            }
        }

     //   [Authorize(GlobalsHelper.ScreenName.ADMINISTRATION_USERS_ENTRY, GlobalsHelper.AccessType.WRITE)]
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.lst.SelectedItems.Count > 0)
            {
                User UserEntry = (User) this.lst.SelectedItems[0].Tag;
                int id = UserEntry.Id;
                var record = ReferencesHelper.GetUserPassword().Where(o => o.Id == id).FirstOrDefault();
                pass = record.Password;
                FrmUserEntry UserEntryForm = new FrmUserEntry(UserEntry);
                if (UserEntryForm.ShowDialog() == DialogResult.OK)
                    InitList();
            }
        }

        private void lst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tsbEdit_Click(sender, new EventArgs());
        }

        private void lst_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (this.lst.Sorting == SortOrder.Ascending)
                this.lst.Sorting = SortOrder.Descending;
            else
                this.lst.Sorting = SortOrder.Ascending;

            // Set the ListViewItemSorter property to a new ListViewItemComparer object.
            this.lst.ListViewItemSorter = new ListViewItemComparer(e.Column, this.lst.Sorting);
            // Call the sort method to manually sort.
            lst.Sort();
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
