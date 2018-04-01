using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Extend.DataAccess.DTO;
using Hanvet.Models;

namespace Hanvet.Code
{
    public class SessionHelper
    {
        public static CategoryContainer getCateSession()
        {
            var cate = HttpContext.Current.Session["CateSession"];
            if (cate != null)
                return (CategoryContainer)cate;
            return null;
        }
        public static void setCateSession(CategoryContainer cate)
        {
            HttpContext.Current.Session["CateSession"] = cate;
        }
        public static string getLanguageSession()
        {
            var lang = HttpContext.Current.Session["Language"];
            if (lang != null)
                return (string)lang;
            return "vi";
        }
        public static void setLanguageSession(string lang)
        {
            HttpContext.Current.Session["Language"] = lang;
        }
    }
}