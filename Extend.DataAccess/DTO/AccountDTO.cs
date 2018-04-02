using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.DataAccess.DTO
{
    public class Category
    {
        public int CateId { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string IconPath { get; set; }
        public string Url { get; set; }
        public string RewriteUrl { get; set; }
        public string SiteName { get; set; }
        public int Type { get; set; }
    }
}
