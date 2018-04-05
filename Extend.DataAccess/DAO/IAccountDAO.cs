using Extend.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.DataAccess.DAO
{
    public interface IAccountDAO
    {
        int User_Login(string username, string password);
        List<Category> GetCate(string siteName);
        List<Article> GetListArticleByOrder(int pageNum, int pageSize, out int totalPage);
        List<Article> GetListArticleNew(int pageNum, int pageSize, out int totalPage);
        List<Article> GetListArticleMostView(int pageNum, int pageSize, out int totalPage);

        List<Article> GetArticleByTag(string TagName,int pageNum, int pageSize, out int totalPage);

        ArticleDetail GetArticleDetail(int id);

        List<Product> GetListProductByOrder(int pageNum, int pageSize, out int totalPage);

        ProductDetail GetProductDetail(int id);
    }
}
