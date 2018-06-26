using IWeigh;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITWhiz.ScaleSoft.Desktop
{
    static class Program
    {
        public static readonly string COMPANY_NAME = "IBTS";
        private static Logger _Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetApplicationVariables();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmSpalsh());
         //   FrmSpalsh()
        }

        private static void SetApplicationVariables()
        {
            string Path = Environment.CurrentDirectory;
            string[] appPath = Path.Split(new string[] { "bin" }, StringSplitOptions.None);
            // MessageBox.Show("Database location : " + appPath[0]);
            _Logger.Info("Database file location: " + appPath[0]);
            AppDomain.CurrentDomain.SetData("DataDirectory", appPath[0]);
        }
    }
}
