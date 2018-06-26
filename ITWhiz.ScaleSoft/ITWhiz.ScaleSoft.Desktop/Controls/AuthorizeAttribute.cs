using ITWhiz.ScaleSoft.BusinessOperations.Models;
using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LibraScales.ScaleSoft.GlobalsHelper;

namespace ITWhiz.ScaleSoft.Desktop.Controls
{
    [Serializable]
    public class AuthorizeAttribute : OnMethodBoundaryAspect
    {
        private AccessType _AccessType = AccessType.READ;
        private ScreenName _ScreenName = ScreenName.CATEGORY_ENTRY;
        //private ScreenName _ScreenName = ScreenName.SUPPLIER_ENTRY;

        public AuthorizeAttribute(ScreenName ScreenName, AccessType AccessType)
        {
            _AccessType = AccessType;
            _ScreenName = ScreenName;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {

            UserSecurityRoleDetail usrd = null;
            MainForm.statusBar.Items[0].Text = string.Empty;

            switch (_AccessType)
            {
                case AccessType.READ:
                    usrd = LoggedInUserRoleDetails.Where(o => o.ScreenName == _ScreenName.ToString() && o.Read.ToUpper() == "TRUE").FirstOrDefault();
                    break;
                case AccessType.WRITE:
                    usrd = LoggedInUserRoleDetails.Where(o => o.ScreenName == _ScreenName.ToString() && o.Write.ToUpper() == "TRUE").FirstOrDefault();
                    break;
                case AccessType.REMOVE:
                    usrd = LoggedInUserRoleDetails.Where(o => o.ScreenName == _ScreenName.ToString() && o.Remove.ToUpper() == "TRUE").FirstOrDefault();
                    break;
            }

            //base.OnEntry(args);

            if (usrd == null)
            {
                MainForm.statusBar.Items[0].Text = "You are not authorised to perform this operation. Contact to the system administrator.";
                args.FlowBehavior = FlowBehavior.Return;
            }

        }
    }
}
