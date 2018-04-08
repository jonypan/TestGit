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
    }
}
