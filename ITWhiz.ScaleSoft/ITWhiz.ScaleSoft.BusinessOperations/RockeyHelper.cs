using ITWhiz.ScaleSoft.BusinessOperations.Models;

using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITWhiz.ScaleSoft.BusinessOperations
{
    public class RockeyHelper
    {
        private static Logger _Logger = LogManager.GetCurrentClassLogger();

        [DllImport("Rockey2.dll")]
        internal static extern int RY2_Find();
        [DllImport("Rockey2.dll")]
        public static extern int RY2_Open(int mode, UInt32 uid, out UInt32 hid);
        [DllImport("Rockey2.dll")]
        internal static extern int RY2_Close(int handle);
        //[DllImport("Rockey2.dll")]
        //internal static extern int RY2_GenUID(int handle, out UInt32 uid, [MarshalAs(UnmanagedType.LPArray)] char[] seed, int isProtect);
        [DllImport("Rockey2.dll")]
        internal static extern int RY2_Read(int handle, int block_index, [MarshalAs(UnmanagedType.LPArray)] char[] buffer512);
        [DllImport("Rockey2.dll")]
        internal static extern int RY2_Write(int handle, int block_index, [MarshalAs(UnmanagedType.LPArray)] char[] buffer512);
        //[DllImport("MSVCRT.dll")]
        //internal static extern long atol([MarshalAs(UnmanagedType.LPArray)] char[] sTemp);

        static UInt32 uid;
        public static LicenseInfo GetLicense(UInt32 licenseKey)
        {
            LicenseInfo info = new LicenseInfo();

            info.Serial = licenseKey;
            info.InternalSerial = ReadHidFromRockey2(licenseKey);
           
            return info;
        }
       
        private static UInt32 ReadHidFromRockey2(UInt32 _uid)
        {
            char[] buffer = new char[512];
            int handle = 0;
            int retcode;
            UInt32 hid = 0;

            uid = _uid;
            
            // find rockey 2 attached with PC or not
            retcode = RY2_Find();
            if (retcode < 0)
            {
                _Logger.Info("Error: not find any rockey2 : " + retcode);
                MessageBox.Show("Error: could not found Rockey2 attached: " + retcode, "License Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return hid;
            }
       
            _Logger.Info("Sucess: find rockey2 : " + retcode);

            // open the Rockey2 using provided UID

            retcode = RY2_Open(0, uid, out hid);
            if (retcode < 0)
            {
                _Logger.Info("Error: can not open the rockey2 : " + retcode);
                MessageBox.Show("Error: could not opened the Rockey2: " + retcode, "License Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return hid;
            }

            _Logger.Info("Sucess: open rockey2");

            // read the HID from Rockey
            retcode = RY2_Read(handle, 0, buffer);
            //string writebuffer = "ibtsol.com";
            //retcode = RY2_Write(handle, 0, writebuffer.ToCharArray());
            RY2_Close(handle);

            _Logger.Info("The uid is : " + uid + " and hid " + hid);

            return hid;
        }
       
    }
}
