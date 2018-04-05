using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extend.DataAccess.DTO;
using Extend.DataAccess;
using Extend.DataAccess.DAO;
namespace Hanvet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int totalPage = 0;
            IAccountDAO dbAccount = ADODAOFactory.Instance().CreateAccountDao();
            List<Article> listArticleByOrder = dbAccount.GetListArticleByOrder(1,10,out totalPage);
            List<Product> listProductByOrder = dbAccount.GetListProductByOrder(1, 10, out totalPage);

            ViewBag.listArticleByOrder = listArticleByOrder;
            ViewBag.listProductByOrder = listProductByOrder;
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