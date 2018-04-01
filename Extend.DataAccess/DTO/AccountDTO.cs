using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extend.DataAccess.DTO
{
    public class SP_CMS_Account_GetInfo
    {
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public DateTime BirthDay { get; set; }
        public long SumVipPoint { get; set; }
        public int PreviewLevel { get; set; }
        public int PreviewVipPoint { get; set; }
        public int CurrentLevel { get; set; }
        public string Name { get; set; }
        public long GiftPoint { get; set; }
        public int VipPoint { get; set; }
        public int VipPointUse { get; set; }
        public int PreviewStarBirthday { get; set; }
        public int StarYearInMonth { get; set; }
        public int StarYear { get; set; }
    }
}
