using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.BusinessOperations.Models
{
    public class User : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        //public string Role { get; set; }
    }
}
