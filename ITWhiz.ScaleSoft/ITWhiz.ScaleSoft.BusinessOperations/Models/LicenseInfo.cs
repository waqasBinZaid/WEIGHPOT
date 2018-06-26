using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.BusinessOperations.Models
{
    [Serializable]
    public class LicenseInfo
    {
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string LicenseType { get; set; }
        public UInt32 Serial { get; set; }
        public UInt32 InternalSerial { get; set; }
    }
}
