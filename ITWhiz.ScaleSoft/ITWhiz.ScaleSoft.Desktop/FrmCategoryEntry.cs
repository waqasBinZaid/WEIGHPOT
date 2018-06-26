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
    //public partial class FrmCategoryEntry : Form
    //{
    //    private UIMode _UIMode = UIMode.NEW_RECORD;
    //    private Category _CategoryEntry = new Category();

    //    public FrmCategoryEntry()
    //    {
    //        InitializeComponent();
    //        Init();
    //        _UIMode = UIMode.NEW_RECORD;
    //    }

    //    public FrmCategoryEntry(Category CategoryEntry)
    //    {
    //        InitializeComponent();
    //        Set(CategoryEntry);
    //        _UIMode = UIMode.EDIT_RECORD;
    //        _CategoryEntry = CategoryEntry;
    //    }

    //    private void Set(Category CategoryEntry)
    //    {
    //        if (CategoryEntry != null)
    //        {
    //            this.txtName.Text = CategoryEntry.Name;
    //            this.txtName.Tag = CategoryEntry;
    //            this.chkStatus.Checked = (CategoryEntry.Status == "TRUE" ? true : false);
    //        }
    //    }

    //    private void Init()
    //    {
    //        this.txtName.Text = string.Empty;
    //        this.txtName.Tag = null;
    //        //this.chkStatus.Checked = false;
    //    }

    //    private bool IsValidate()
    //    {
    //        bool Result = false;
    //        string REQUIRED = "Required";

    //        if (this.txtName.Text.Trim().Length == 0)
    //        {
    //            this.ep.SetError(this.txtName, REQUIRED);
    //            return Result;
    //        }


    //        if (ReferencesHelper.DuplicateEntryFound("Category", "Name", this.txtName.Text, " AND Id != " + _CategoryEntry.Id))
    //        {
    //            this.ep.SetError(this.txtName, "Name already exist");
    //            return Result;
    //        }

    //        return true;

    //    }

    //    private void CmdOK_Click(object sender, EventArgs e)
    //    {
    //        if (IsValidate())
    //        {
    //            Category CategoryEntry = new Category();
    //            if (this.txtName.Tag != null)
    //            {
    //                CategoryEntry = (Category)this.txtName.Tag;
    //                CategoryEntry.Name = this.txtName.Text;
    //                CategoryEntry.Status = (this.chkStatus.Checked ? "TRUE" : "FALSE");

    //                //ReferencesHelper.UpdateCategory(CategoryEntry);

    //            }
    //            else
    //            {
    //                CategoryEntry.Name = this.txtName.Text;
    //                CategoryEntry.Status = (this.chkStatus.Checked ? "TRUE" : "FALSE");

    //                //ReferencesHelper.AddCategory(CategoryEntry);
    //            }

    //            this.DialogResult = DialogResult.OK;
    //            this.Close();
    //        }
    //    }

    //    private void CmdCancel_Click(object sender, EventArgs e)
    //    {
    //        this.DialogResult = DialogResult.Cancel;
    //        this.Close();
    //    }

    //    private void FrmCategoryEntry_Load(object sender, EventArgs e)
    //    {

    //    }

    //    private void FrmCategoryEntry_KeyDown(object sender, KeyEventArgs e)
    //    {
    //        if (e.KeyCode == Keys.Enter)
    //            SendKeys.Send("{TAB}");
    //    }
    //}
}
