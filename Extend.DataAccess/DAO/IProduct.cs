using Extend.DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.DataAccess.DAO
{
    public interface IProduct
    {
        List<Product> GetListProductByOrder(int pageNum, int pageSize, out int totalPage);

        ProductDetail GetProductDetail(int id);

        long Product_Edit(int ExeType, int ExeUserID, ProductDetail product);
        List<ProductDetail> GetCMSListProduct(int CateID,string Search, int pageNum, int pageSize, out int totalPage);
    }
}
