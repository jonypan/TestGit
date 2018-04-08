using Extend.DataAccess.DAO;
using Extend.DataAccess.DTO;
using Extend.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.DataAccess.DAOImpl
{
    public class ArticleDAOImpl : IArticle
    {
        private DBHelper db = null;
        public ArticleDAOImpl()
        {
            db = new DBHelper(Config.SQLConnectionString);
        }

        public List<Article> GetListArticleByOrder(int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<Article> results;
                var oCommand = new SqlCommand("[dbo].[SP_Article_Get_List_ByOrder]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<Article>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public List<Article> GetListArticleNew(int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<Article> results;
                var oCommand = new SqlCommand("[dbo].[SP_Article_Get_List_New]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<Article>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public List<Article> GetListArticleMostView(int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<Article> results;
                var oCommand = new SqlCommand("[dbo].[SP_Article_Get_List_MostView]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<Article>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public List<Article> GetArticleByTag(string TagName, int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<Article> results;
                var oCommand = new SqlCommand("[dbo].[SP_Article_Get_List_ByTag]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_TagName", TagName));
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<Article>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public ArticleDetail GetArticleDetail(int id)
        {
            List<ArticleDetail> results;
            try
            {
                var oCommand = new SqlCommand("[dbo].[SP_Article_Get_Detail]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_ArticleID", id));
                oCommand.Parameters.Add(new SqlParameter("@_View", 1));

                results = db.GetList<ArticleDetail>(oCommand);
                if (results.Count > 0)
                    return results[0];
                return new ArticleDetail();
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return new ArticleDetail();
            }
        }
    }
}
