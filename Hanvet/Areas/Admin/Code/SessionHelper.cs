using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hanvet.Areas.Admin.Code
{
    public class SessionHelper
    {
        public static AdminSession getAdminSession()
        {
            var admin = HttpContext.Current.Session["AdminSession"];
            if (admin != null)
                return (AdminSession)admin;
            return null;
        }
        public static void setAdminSession(AdminSession admin)
        {
            HttpContext.Current.Session["AdminSession"] = admin;
        }
    }
}