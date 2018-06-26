using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
using IWeigh;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITWhiz.ScaleSoft.Desktop
{
    public partial class FrmSpecialUser : Form
    {
        public FrmSpecialUser()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSpecialUser_Click(object sender, EventArgs e)
        {
           
        User    users = ReferencesHelper.GetUserById();
         string username=   users.LoginId;
            string userpass = (users.Password);
          string pass= UtilsHelper.GetHash(txtPassword.Text);
            if (txtUserName.Text == username && pass == userpass)
            {
                this.Close();
                FrmUpdateWeighmentEntry form = new FrmUpdateWeighmentEntry();
                form.ShowDialog();
                
            }
            else if (txtUserName.Text != username) {

                MessageBox.Show("Please Enter Correct UserName.");
            }
            else if (txtPassword.Text!=userpass) {
                MessageBox.Show("Please Enter Correct Password.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
