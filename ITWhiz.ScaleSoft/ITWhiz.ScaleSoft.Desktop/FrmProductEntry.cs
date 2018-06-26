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
using static LibraScales.ScaleSoft.GlobalsHelper;

namespace IWeigh
{
    public partial class FrmProductEntry : Form
    {
        private UIMode _UIMode = UIMode.NEW_RECORD;
        private Product _ProductEntry = new Product();

        public FrmProductEntry()
        {
            InitializeComponent();
            Init();
           
            _UIMode = UIMode.NEW_RECORD;
        }

        public FrmProductEntry(Product ProductEntry)
        {
            InitializeComponent();
            Set(ProductEntry);
            _UIMode = UIMode.EDIT_RECORD;
            _ProductEntry = ProductEntry;
        }

        private void Set(Product ProductEntry)
        {
            if (ProductEntry != null)
            {
                this.txtName.Text = ProductEntry.Name;
                this.txtName.Tag = ProductEntry;
                this.cboType.Text = ProductEntry.ProductType;               
                this.chkStatus.Checked = (ProductEntry.Status == "TRUE" ? true : false);
                this.txtPrice.Text = ProductEntry.Price.ToString();
            }
        }

        private void Init()
        {
            this.txtName.Text = string.Empty;
            this.txtName.Tag = null;
            bool PricingMode = false;
            bool.TryParse(GlobalsHelper.SystemSettings.Where(o => o.AttributeKey == SystemSettingKeys.ALLOW_PRODUCT_PRICING.ToString()).FirstOrDefault().AttributeValue, out PricingMode);

            this.lblPrice.Visible = PricingMode;
            this.txtPrice.Visible = PricingMode;
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

       
            if (ReferencesHelper.DuplicateEntryFound("Product", "Name", this.txtName.Text, " AND Id != " + _ProductEntry.Id))
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
                Product ProductEntry = new Product();
                float price = 0;

                if (this.txtName.Tag != null)
                {
                    ProductEntry = (Product)this.txtName.Tag;
                    ProductEntry.Name = this.txtName.Text;
                    ProductEntry.ProductType = this.cboType.Text;
                    ProductEntry.Status = (this.chkStatus.Checked ? "TRUE" : "FALSE");
                    float.TryParse(this.txtPrice.Text, out price);
                    ProductEntry.Price = price;

                    ReferencesHelper.UpdateProduct(ProductEntry);

                }
                else
                {
                    ProductEntry.Name = this.txtName.Text;
                    ProductEntry.ProductType = this.cboType.Text;
                    ProductEntry.Status = (this.chkStatus.Checked ? "TRUE" : "FALSE");
                    float.TryParse(this.txtPrice.Text, out price);
                    ProductEntry.Price = price;

                    ReferencesHelper.AddProduct(ProductEntry);
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

        private void FrmProductEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
    }
}
