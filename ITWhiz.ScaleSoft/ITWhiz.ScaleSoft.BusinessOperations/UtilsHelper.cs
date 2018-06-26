using ITWhiz.ScaleSoft.BusinessOperations.Models;
using ITWhiz.ScaleSoft.DataAccess;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace ITWhiz.ScaleSoft.BusinessOperations
{
    public class UtilsHelper
    {
        private static Logger _Logger = LogManager.GetCurrentClassLogger();

        public static string GetHash(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);

            string hashString = Convert.ToBase64String(hash);

            //string hashString = string.Empty; 

            //foreach (byte x in hash)
            //{
            //    hashString += String.Format("{0:x2}", x);
            //}


            return hashString;
        }

        public static List<USBDeviceInfo> GetUSBDrives()
        {
            List<USBDeviceInfo> usbDevices = new List<USBDeviceInfo>();
            ManagementObjectCollection collection;

            //////////using (var searcher = new ManagementObjectSearcher(@"select * from Win32_USBHub Where DeviceID Like '%VID_XXXX&PID_XXXX%'"))
            ////////using (var searcher = new ManagementObjectSearcher(@"select * from Win32_USBHub"))
            ////////    collection = searcher.Get();

            ////////foreach (ManagementObject device in collection)
            ////////{
            ////////    //foreach (PropertyData item in device.Properties)
            ////////    //{
            ////////    //    Console.Write(item.Name + ":" + item.Value);
            ////////    //}

            ////////    //// associate physical disks with partitions
            ////////    //foreach (ManagementObject partition in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + device["DeviceID"] + "'} WHERE AssocClass=Win32_DiskDriveToDiskPartition").Get())
            ////////    //{
            ////////    //    // associate partitions with logical disks (drive letter volumes)
            ////////    //    foreach (ManagementObject disk in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + partition["DeviceID"] + "'} WHERE AssocClass=Win32_LogicalDiskToPartition").Get())
            ////////    //    {
            ////////    //        //yield return (string)disk["DeviceID"];
            ////////    //        usbDevices.Add(new USBDeviceInfo() { Id = (string)device.GetPropertyValue("DeviceID"), Name = (string)device.GetPropertyValue("Name"), Description = (string)device.GetPropertyValue("Description"), SerialNumber = (string)device.GetPropertyValue("PNPDeviceID"), Status = (string)device.GetPropertyValue("Status") });
            ////////    //    }
            ////////    //}

            ////////    //foreach (ManagementObject controller in device.GetRelated("Win32_USBController"))
            ////////    //{
            ////////    //    foreach (ManagementObject obj in new ManagementObjectSearcher("ASSOCIATORS OF {Win32_USBController.DeviceID='" + controller["PNPDeviceID"].ToString() + "'}").Get())
            ////////    //    {
            ////////    //        if (obj.ToString().Contains("DeviceID"))
            ////////    //            usbDevices.Add(new USBDeviceInfo() { Id = (string)obj.GetPropertyValue("DeviceID"), Name = (string)obj.GetPropertyValue("Name"), Description = (string)obj.GetPropertyValue("Description"), SerialNumber = (string)obj.GetPropertyValue("PNPDeviceID"), Status = (string)obj.GetPropertyValue("Status") });

            ////////    //    }
            ////////    //}




            ////////}

            foreach (DriveInfo item in DriveInfo.GetDrives())
            {
                if (item.IsReady && item.DriveType == DriveType.Removable)
                    usbDevices.Add(new USBDeviceInfo() { Id = item.Name, Name = item.VolumeLabel, Description = item.DriveFormat });
            }

            return usbDevices;
        }

        public static void TestDatabaseConnection()
        {
            try
            {
                using (SQLiteHelper SQLite = new SQLiteHelper())
                {

                }
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, ex.Message);
            }
        }
    }
}
