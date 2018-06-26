using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWhiz.ScaleSoft.BusinessOperations.Models
{
    public class UserSecurityRole : Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        //public List<UserSecurityRoleDetail> Details { get; set; }
    }

    public class UserSecurityRoleDetail : Base
    {
        public int RoleId { get; set; }
        public string Module { get; set; }
        public string SubModule { get; set; }
        public string ScreenName { get; set; }
        public string Read { get; set; }
        public string Write { get; set; }
        public string Remove { get; set; }
    }
}
