using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extend.DataAccess.DTO;
using Extend.DataAccess;
using Extend.DataAccess.DAO;
using PagedList;
namespace Hanvet.Controllers
{
    public class SanphamController : Controller
    {
        // GET: Sanpham
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            int totalPage = 0;
            IProduct dbProduct = ADODAOFactory.Instance().CreateProductDao();
            List<Product> listProductByOrder = dbProduct.GetListProductByOrder(1, 10000, out totalPage);
            return View(listProductByOrder.ToPagedList(page, pageSize));
        }
        public ActionResult Detail(int id)
        {
            int totalPage = 0;
            IProduct dbProduct = ADODAOFactory.Instance().CreateProductDao();

            ProductDetail product = dbProduct.GetProductDetail(id);

            //List<Article> listArticleByTag = dbAccount.GetArticleByTag(article.Tags, 1, 6, out totalPage);

            //ViewBag.listArticleByTag = listArticleByTag;

            return View(product);
        }
    }
}