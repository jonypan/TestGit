using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Hanvet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail()
        {
            return View();
        }
        public string VideoGetLink()
        {
            object result = new
            {
                status = true,
                source = "https://www.youtube.com/embed/m303WqGQPAM"
            };
            return JsonConvert.SerializeObject(result);
        }
    }
}