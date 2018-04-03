using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Extend.DataAccess.DAO;
using Extend.DataAccess.DTO;
using Extend.DataAccess;
using PagedList;
namespace Hanvet.Controllers
{
    public class TintucController : Controller
    {
        // GET: Tintuc
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            int totalPage = 0;
            IAccountDAO dbAccount = ADODAOFactory.Instance().CreateAccountDao();
            List<Article> listNewArticle = dbAccount.GetListArticleNew(1, 4, out totalPage);
            List<Article> listArticleMostView = dbAccount.GetListArticleMostView(1, 4, out totalPage);
            List<Article> listArticleByOrder = dbAccount.GetListArticleByOrder(1, 100, out totalPage);

            ViewBag.listNewArticle = listNewArticle;
            ViewBag.listArticleMostView = listArticleMostView;

            return View(listArticleByOrder.ToPagedList(page, pageSize));
        }
        public ActionResult Detail(int id)
        {
            int totalPage = 0;
            IAccountDAO dbAccount = ADODAOFactory.Instance().CreateAccountDao();
            List<Article> listNewArticle = dbAccount.GetListArticleNew(1, 4, out totalPage);
            List<Article> listArticleMostView = dbAccount.GetListArticleMostView(1, 4, out totalPage);

            ArticleDetail article = dbAccount.GetArticleDetail(id);
            
            List<Article> listArticleByTag = dbAccount.GetArticleByTag(article.Tags,1, 6, out totalPage);

            ViewBag.listNewArticle = listNewArticle;
            ViewBag.listArticleMostView = listArticleMostView;
            ViewBag.listArticleByTag = listArticleByTag;

            return PartialView(article);
        }

    }
}