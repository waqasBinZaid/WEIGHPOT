using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.BusinessOperations.Models
{
    public class Category : Base
    {
        public int Id { get; set; } = 0;
        public string Code { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }
}
