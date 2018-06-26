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
using static LibraScales.ScaleSoft.GlobalsHelper;

namespace IWeigh
{
    public partial class FrmWeighments : Form
    {
        public FrmWeighments()
        {
            InitializeComponent();
            InitList();
        }

        private void InitList()
        {
            List<Weighment> Weighments = WeighmentHelper.GetWeighments();
            this.lst.Items.Clear();
            foreach (Weighment item in Weighments)
            {
                ListViewItem nItem = this.lst.Items.Add(item.ClientName);
                nItem.Tag = item;
                nItem.SubItems.Add(item.TicketDate.ToString());
                nItem.SubItems.Add((item.TicketNumber).ToString());
                nItem.SubItems.Add(item.ReferenceNumber);
            }

        }

        [Authorize(GlobalsHelper.ScreenName.WEIGHMENT_ENTRY, GlobalsHelper.AccessType.WRITE)]
        private void tsbNew_Click(object sender, EventArgs e)
        {
            FrmWeighmentEntry WeighmentEntry = new FrmWeighmentEntry();
            if (WeighmentEntry.ShowDialog() == DialogResult.OK)
                InitList();
        }

        [Authorize(GlobalsHelper.ScreenName.WEIGHMENT_ENTRY, GlobalsHelper.AccessType.WRITE)]
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.lst.SelectedItems.Count > 0)
            {
                Weighment WeighmentEntry = (Weighment)this.lst.SelectedItems[0].Tag;
                //MessageBox.Show("Revision number " + WeighmentEntry.RevisionNumber);
                //WeighmentEntry.Details = WeighmentHelper.GetWeighmentDetails(WeighmentEntry.Id);
                FrmWeighmentEntry WeighmentEntryForm = new FrmWeighmentEntry(WeighmentEntry);
                if (WeighmentEntryForm.ShowDialog() == DialogResult.OK)
                    InitList();
            }
        }

        private void lst_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tsbEdit_Click(sender, new EventArgs());
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            if (this.lst.SelectedItems.Count > 0)
            {
                Weighment WeighmentEntry = (Weighment)this.lst.SelectedItems[0].Tag;
                Microsoft.Reporting.WinForms.ReportDataSource dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighmentListing", ReferencesHelper.GetDataTable("vwWeighmentList", " WHERE Id = " + WeighmentEntry.Id));
                this.WindowState = FormWindowState.Maximized;

                bool PricingMode = false;
                bool.TryParse(GlobalsHelper.SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.ALLOW_PRODUCT_PRICING.ToString()).FirstOrDefault().AttributeValue, out PricingMode);

                string ReportName = "WeighmentSlip.rdlc";
                if (PricingMode)
                    ReportName = "WeighmentSlipWithPrice.rdlc";

                FrmReportViewer ReportViewer = new FrmReportViewer(ReportName, null, dsReport);

                ReportViewer.MdiParent = this.ParentForm;
                ReportViewer.Show();
                ReportViewer.BringToFront();
            }
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

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            InitList();
        }
    }
}
