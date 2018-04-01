using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Extend.DataAccess.DTO;
namespace Hanvet.Models
{
    public class CategoryContainer
    {
        public List<Category> cateList { set; get; }
        public List<Category> getCateByParent(int parent)
        {
            var list= cateList.FindAll(x => x.ParentID == parent);
            return list;
        }
    }
}