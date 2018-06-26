using ITWhiz.ScaleSoft.BusinessOperations.Models;
using IWeigh;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraScales.ScaleSoft
{
    public static class GlobalsHelper
    {
        public const string COMPANY_NAME = "RICE PARTNERS (PVT)LTD.";
        public static User LoggedInUser { get; set; }
        public static List<UserSecurityRoleDetail> LoggedInUserRoleDetails { get; set; }
        public static List<SystemSetting> SystemSettings { get; set; }

        public static ApplicationMode UserApplicationMode{ get; set; }

        public static FrmMain MainForm { get; set; }

        public enum UIMode
        {
            NEW_RECORD,
            EDIT_RECORD
        }

        public enum ReportType
        {
            GENERAL_WEIGHMENT_LISTING,
            PARTY_WISE_WEIGHMENT_LISTING,
            PRODUCT_WISE_WEIGHMENT_LISTING
        }

        public enum SystemSettingKeys
        {
            APPLICATION_NAME,
            APPLICATION_CUSTOMER_NAME,
            INDICATOR_COM_PORT,
            INDICATOR_BAUD_RATE,
            INDICATOR_PARITY,
            INDICATOR_DATA_BITS,
            INDICATOR_STOP_BIT,

            INDICATOR_CONTROL_CHARACTER,
            INDICATOR_READ_DIRECTION,
            INDICATOR_READ_DELAY,
            INDICATOR_FILTER_START_FROM,
            INDICATOR_FILTER_STRING_LENGTH,
            INDICATOR_FILTER_DECIMAL_INCLUDED,

            ALLOW_DUPLICATE_PRODUCTS,
            ALLOW_PRODUCT_PRICING,
            ALLOW_PRODUCT_PRICING_CHANGE_ON_WEIGHMENT,

            ALLOW_MANUAL_WEIGHMENT,

            LICENSE_INFO
        }

        public enum AccessType
        {
            READ,
            WRITE,
            REMOVE
        }

        public enum ScreenName
        {
            PARTY_ENTRY,
            PARTY_LISTING,
            CATEGORY_ENTRY,
            CATEGORY_LISTING,
            PRODUCT_ENTRY,
            PRODUCT_LISTING,
            REPORT_PRODUCT_LISTING,
            REPORT_PARTIES_LISTING,
            REPORT_WEIGHMENT_LISTING,
            REPORT_PARTY_WISE_LISTING,
            REPORT_PRODUCT_WISE_LISTING,
            ADMINISTRATION_SYSTEM_SETTINGS,
            ADMINISTRATION_USERS_ENTRY,
            ADMINISTRATION_USERS_LISTING,
            ADMINISTRATION_SECURITY_ROLE_ENTRY,
            ADMINISTRATION_SECURITY_ROLE_LISTING,
            WEIGHMENT_ENTRY,
            WEIGHMENT_LISTING,
            ADMINISTRATION_BACKUP_DATABASE,
            ADMINISTRATION_RESTORE_DATABASE
        }

        public enum ApplicationMode
        {
            TRIAL,
            LICSENSED
         
        }

        public static bool IsNumeric(this string s)
        {
            float output;
            return float.TryParse(s, out output);
        }

        public static string Serialze(object obj)
        {
            var serialiser = new XmlSerializer(obj.GetType());

            TextWriter writer = new StringWriter();
            serialiser.Serialize(writer, obj);

            return writer.ToString();

        }

        public static object DeSerialze(string serialisedString, object obj)
        {
            var serialiser = new XmlSerializer(obj.GetType());
            StringReader reader = new StringReader(serialisedString);

            return serialiser.Deserialize(reader);
        }



    }
}
