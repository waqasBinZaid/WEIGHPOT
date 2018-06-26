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
    public partial class FrmReportParameter : Form
    {
        private ReportType _ReportType = ReportType.GENERAL_WEIGHMENT_LISTING;
        private List<Product> _Products = null;
        private List<Supplier> _Suppliers = null;

        public FrmReportParameter()
        {
            InitializeComponent();
            _ReportType = ReportType.GENERAL_WEIGHMENT_LISTING;
            SetUI();
        }

        public FrmReportParameter(ReportType ReportType)
        {
            InitializeComponent();
            _ReportType = ReportType;
            SetUI();
        }

        private void SetUI()
        {
            switch(_ReportType)
            {
                case ReportType.GENERAL_WEIGHMENT_LISTING:
                    this.grpParty.Enabled = false;
                    this.grpProduct.Enabled = false;
                    break;
                case ReportType.PARTY_WISE_WEIGHMENT_LISTING:
                    this.grpParty.Enabled = true;
                    this.grpProduct.Enabled = false;
                    InitClients();
                    this.cmbParty.Text = string.Empty;
                    break;
                case ReportType.PRODUCT_WISE_WEIGHMENT_LISTING:
                    this.grpParty.Enabled = false;
                    this.grpProduct.Enabled = true;
                    InitSuppliers();
                    this.cmbSupplier.Text = string.Empty;
                    break;
            }
        }

        //private void InitCategories()
        //{
        //    List<Category> categories = ReferencesHelper.GetCategories();
        //    _Products = ReferencesHelper.GetProducts();
        //    categories = categories.Where(o => o.Status == "TRUE").OrderBy(o => o.Name).ToList();
        //    categories.Add(new Category() { Id = 0, Name = "" });

        //    //this.cmbCategory.Items.Clear();
        //    this.cmbCategory.DataSource = categories;
        //    this.cmbCategory.DisplayMember = "Name";
        //    this.cmbCategory.ValueMember = "Id";
        //}

        //private void InitProducts(int CategoryId)
        private void InitProducts()
        {
            //this.cmbItem.Items.Clear();
            List<Product> products = _Products.Where(o => o.Status == "TRUE").OrderBy(o => o.Name).ToList();
            products.Add(new Product() { Id = 0, Name = "" });
            this.cmbItem.DataSource = products;
            this.cmbItem.DisplayMember = "Name";
            this.cmbItem.ValueMember = "Id";
        }

        private void InitSuppliers()
        {
            //this.cmbItem.Items.Clear();
            List<Supplier> suppliers = _Suppliers.OrderBy(o => o.SupplierName).ToList();
            suppliers.Add(new Supplier() { Id = 0, SupplierName = "" });
            this.cmbItem.DataSource = suppliers;
            this.cmbItem.DisplayMember = "Name";
            this.cmbItem.ValueMember = "Id";
        }

        private void InitSuppliers(int SupplierId)
        {
            //this.cmbItem.Items.Clear();
            _Suppliers = ReferencesHelper.GetSuppliers();
            List<Supplier> suppliers = _Suppliers.Where(o => o.Id == SupplierId).OrderBy(o => o.SupplierName).ToList();
            suppliers.Add(new Supplier() { Id = 0, SupplierName = "" });
            this.cmbItem.DataSource = suppliers;
            this.cmbItem.DisplayMember = "Name";
            this.cmbItem.ValueMember = "Id";
        }

        private void InitClients()
        {
            List<Client> clients = ReferencesHelper.GetClients();

            //this.cmbParty.Items.Clear();
            clients = clients.Where(o => o.Status == "TRUE").OrderBy(o => o.Name).ToList();
            clients.Add(new Client() { Id = 0, Name = string.Empty });
            this.cmbParty.DataSource = clients;
            this.cmbParty.DisplayMember = "Name";
            this.cmbParty.ValueMember = "Id";
        }


        private void CmdOK_Click(object sender, EventArgs e)
        {
            FrmReportViewer ReportViewer = null;
            Microsoft.Reporting.WinForms.ReportDataSource dsReport = null;
            List<Microsoft.Reporting.WinForms.ReportParameter> Parameters = new List<Microsoft.Reporting.WinForms.ReportParameter>();
            Parameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("FromDate", this.dtpFrom.Value.ToString()));
            Parameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("ToDate", this.dtpTo.Value.ToString()));

            string WhereClause = " WHERE DATE(TicketDate) >=  '" + this.dtpFrom.Value.ToString("yyyy-MM-dd") + "' AND DATE(TicketDate) <= '" + this.dtpTo.Value.ToString("yyyy-MM-dd") + "' ";

            switch (_ReportType)
            {
                case ReportType.GENERAL_WEIGHMENT_LISTING:
                    dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighmentListing", ReferencesHelper.GetDataTable("vwWeighmentList", WhereClause));
                    ReportViewer = new FrmReportViewer("WeighmentListing.rdlc", Parameters, dsReport);
                    break;
                case ReportType.PARTY_WISE_WEIGHMENT_LISTING:

                    if (this.cmbParty.SelectedItem != null)
                    {
                        int clientId = 0;
                        int.TryParse(this.cmbParty.SelectedValue.ToString(), out clientId);

                        WhereClause +=  (clientId == 0 ? string.Empty :  " AND ClientId = " + clientId);
                    }
                    dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighmentListing", ReferencesHelper.GetDataTable("vwWeighmentList", WhereClause));
                    ReportViewer = new FrmReportViewer("PartyWiseListing.rdlc", Parameters, dsReport);
                    break;

                case ReportType.PRODUCT_WISE_WEIGHMENT_LISTING:

                    //if (this.cmbCategory.SelectedItem != null)
                    //{
                    //    int categoryId = 0;
                    //    int.TryParse(this.cmbCategory.SelectedValue.ToString(), out categoryId);

                    //    WhereClause += (categoryId == 0 ? string.Empty : " AND CategoryId = " + categoryId);
                    //}

                    if (this.cmbItem.SelectedItem != null)
                    {
                        int productId = 0;
                        int.TryParse(this.cmbItem.SelectedValue.ToString(), out productId);

                        WhereClause += (productId == 0 ? string.Empty : " AND ProductId = " + productId);
                    }

                    dsReport = new Microsoft.Reporting.WinForms.ReportDataSource("dsWeighmentListing", ReferencesHelper.GetDataTable("vwWeighmentList", WhereClause));
                    ReportViewer = new FrmReportViewer("ProductWiseListing.rdlc", Parameters, dsReport);
                    break;
            }

            //ReportViewer.MdiParent = this;
            ReportViewer.Show();
        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //private void FrmCategoryEntry_Load(object sender, EventArgs e)
        //{

        //}

        //private void FrmCategoryEntry_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        SendKeys.Send("{TAB}");
        //}

        //private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    int CategoryId = 0;
        //    int.TryParse(this.cmbCategory.SelectedValue.ToString(), out CategoryId);
        //    InitProducts(CategoryId);
        //}

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SupplierId = 0;
            int.TryParse(this.cmbSupplier.SelectedValue.ToString(), out SupplierId);
            InitSuppliers(SupplierId);
        }

        private void FrmReportParameter_Load(object sender, EventArgs e)
        {

        }
    }
}
