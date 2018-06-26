using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.BusinessOperations.Models
{
    public class Product : Base
    {
        public double Id { get; set; } = 0;
        //public int CategoryId { get; set; }
      
        public string Name { get; set; }
        public string ProductType { get; set; }
        public string Status { get; set; }
        public float Price { get; set; }
        
        //public string Category { get; set; }
    }
}
