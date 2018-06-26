using ITWhiz.ScaleSoft.BusinessOperations;
using ITWhiz.ScaleSoft.BusinessOperations.Models;
using ITWhiz.ScaleSoft.Desktop.Controls;
using LibraScales.ScaleSoft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IWeigh
{
    public partial class FrmSystemSettings : Form
    {
        private List<SystemSetting> _SystemSettings;

        public FrmSystemSettings()
        {
            InitializeComponent();
            InitSystemSettings();
        }

        [Authorize(GlobalsHelper.ScreenName.ADMINISTRATION_SYSTEM_SETTINGS, GlobalsHelper.AccessType.WRITE)]
        private void CmdLogin_Click(object sender, EventArgs e)
        {
            if (ValidateLogin())
            {
                if (ReferencesHelper.UpdateSystemSettings(GetSystemSettings()))
                {

                    this.Close();
                }                 
                   
            }
            this.Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void CmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateLogin()
        {
            bool Result = true;

            this.ep.Clear();

            return Result;

        }

        private void InitSystemSettings()
        {
            this.dgv.Rows.Clear();

            List<SystemSetting> SystemSettings = ReferencesHelper.GetSystemSettings().Where(o => o.AttributeType == "PUBLIC").ToList();
            _SystemSettings = SystemSettings;
        
            foreach (SystemSetting item in SystemSettings)
            {
                this.dgv.Rows.Add(item.AttributeLabel, item.AttributeValue, item.AttributeKey);
            }
        }

        private List<SystemSetting> GetSystemSettings()
        {
            foreach (DataGridViewRow item in dgv.Rows)
            {
                SystemSetting setting = _SystemSettings.Where(o => o.AttributeKey == item.Cells[2].Value.ToString()).First();


                //if (item.Cells[1].Value.ToString()!= null && item.Cells[1].Value.ToString()!="")
                //{
                try {
                    setting.AttributeValue = item.Cells[1].Value.ToString();
                } catch (Exception) {
                    setting.AttributeValue = " ";
                }
                   

                //}
                //else
                //{
                //    setting.AttributeValue = " ";
                //}

                //byte[] imagebt = null;
                //FileStream fstream = new FileStream((item.Cells[2].Value).ToString(),FileMode.Open,FileAccess.Read);
                //BinaryReader br = new BinaryReader(fstream);
                //imagebt = br.ReadBytes((int)fstream.Length);
                //setting.LOGO =(imagebt);
            }

            return _SystemSettings;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
