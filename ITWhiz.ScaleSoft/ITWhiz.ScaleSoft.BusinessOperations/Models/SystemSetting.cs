using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.BusinessOperations.Models
{
    public class SystemSetting : Base
    {
        public int Id { get; set; }
        public string AttributeKey { get; set; }
        public string AttributeValue { get; set; }
        public string AttributeLabel { get; set; }
        public string AttributeType { get; set; }
       
    }
}
