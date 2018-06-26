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
    public partial class FrmParties : Form
    {
        public FrmParties()
        {
            InitializeComponent();
            InitList();
        }

        private void InitList()
        {
            List<Client>  Clients = ReferencesHelper.GetClients();
            this.lst.Items.Clear();
            foreach (Client item in Clients)
            {
                ListViewItem nItem = this.lst.Items.Add(item.Name);
                nItem.Tag = item;
                nItem.SubItems.Add(item.Type);
                nItem.SubItems.Add(item.City);
                nItem.SubItems.Add(item.Address);
                nItem.SubItems.Add(item.Status);
                nItem.SubItems.Add(item.ClientPhone);
            }

        }

      //  [Authorize(GlobalsHelper.ScreenName.PARTY_ENTRY, GlobalsHelper.AccessType.WRITE)]
        private void tsbNew_Click(object sender, EventArgs e)
        {
            FrmPartyEntry PartyEntry = new FrmPartyEntry();
            if (PartyEntry.ShowDialog() == DialogResult.OK)
                InitList();
        }

     //   [Authorize(GlobalsHelper.ScreenName.PARTY_ENTRY, GlobalsHelper.AccessType.WRITE)]
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.lst.SelectedItems.Count > 0)
            {
                Client ClientEntry = (Client) this.lst.SelectedItems[0].Tag;
                FrmPartyEntry PartyEntry = new FrmPartyEntry(ClientEntry);
                if (PartyEntry.ShowDialog() == DialogResult.OK)
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
