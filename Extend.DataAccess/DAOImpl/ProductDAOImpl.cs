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
    public class ProductDAOImpl : IProduct
    {
        private DBHelper db = null;
        public ProductDAOImpl()
        {
            db = new DBHelper(Config.SQLConnectionString);
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
