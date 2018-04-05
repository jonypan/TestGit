using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using Extend.DataAccess.DAO;
using Extend.Utilities;
using Extend.DataAccess.DTO;
using System.Collections.Generic;
using Extend.Utilities.IpAddress;

namespace Extend.DataAccess.DAOImpl
{
    public class AccountDAOlmpl : IAccountDAO
    {
        private DBHelper db = null;
        public AccountDAOlmpl()
        {
            db = new DBHelper(Config.SQLConnectionString);
        }

        public int User_Login(string username, string password)
        {
            try
            {
                int responseStatus = 0;
                int userID = 0;
                var oCommand = new SqlCommand("[cms].[SP_User_Login]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_Username", username));
                oCommand.Parameters.Add(new SqlParameter("@_Password", password));
                oCommand.Parameters.Add(new SqlParameter("@_ClientIP", IPAddressHelper.GetClientIP()));

                var p_UserID = new SqlParameter("@_UserID", SqlDbType.Int);
                var p_ResponseStatus = new SqlParameter("@_ResponseStatus", SqlDbType.Int);
                p_UserID.Direction = ParameterDirection.Output;
                p_ResponseStatus.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_UserID);
                oCommand.Parameters.Add(p_ResponseStatus);
                db.ExecuteNonQuery(oCommand);

                userID = p_ResponseStatus.SqlValue.ToString() != "Null" ? (int)p_UserID.Value : 0;
                responseStatus = p_ResponseStatus.SqlValue.ToString() != "Null" ? (int)p_ResponseStatus.Value : 0;
                if (responseStatus > 0)
                    return userID;
                else return responseStatus;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return -69;
            }
        }
        public List<Category> GetCate(string siteName)
        {
            try
            {
                var oCommand = new SqlCommand("[dbo].[SP_Cate_Get_List]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_SiteName", siteName));

                return db.GetList<Category>(oCommand);
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
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
        public List<Product> GetListProductByOrder(int pageNum, int pageSize, out int totalPage)
        {
            totalPage = 0;
            try
            {
                List<Product> results;
                var oCommand = new SqlCommand("[dbo].[SP_Product_Get_List_ByOrder]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_PageNumber", pageNum));
                oCommand.Parameters.Add(new SqlParameter("@_PageSize", pageSize));

                var p_totalPage = new SqlParameter("@_TotalPage", SqlDbType.Int);
                p_totalPage.Direction = ParameterDirection.Output;

                oCommand.Parameters.Add(p_totalPage);

                results = db.GetList<Product>(oCommand);
                totalPage = p_totalPage.SqlValue.ToString() != "Null" ? (int)p_totalPage.Value : 0;
                return results;
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return null;
            }
        }
        public ProductDetail GetProductDetail(int id)
        {
            List<ProductDetail> results;
            try
            {
                var oCommand = new SqlCommand("[dbo].[SP_Product_Get_Detail]");
                oCommand.CommandType = CommandType.StoredProcedure;
                oCommand.Parameters.Add(new SqlParameter("@_ProductID", id));
                oCommand.Parameters.Add(new SqlParameter("@_View", 1));

                results = db.GetList<ProductDetail>(oCommand);
                if (results.Count > 0)
                    return results[0];
                return new ProductDetail();
            }
            catch (Exception ex)
            {
                NLogManager.PublishException(ex);
                return new ProductDetail();
            }
        }
    }
}
