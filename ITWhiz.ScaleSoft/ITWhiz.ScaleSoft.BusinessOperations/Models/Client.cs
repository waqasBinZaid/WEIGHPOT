using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.BusinessOperations.Models
{
    public class Client : Base
    {
        public double Id { get; set; } = 0;
        public string Type { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ClientPhone { get; set; }
    }
}
