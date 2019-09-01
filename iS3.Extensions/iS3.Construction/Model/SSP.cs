using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Construction.Model
{
    //SSP二次支护方案
    [Table("Construction_SSP")]
    public partial class SSP : DGObject
    {
        //编号
        public string SSP_NO { get; set; }
        //SSP_ID
        public string SSP_ID { get; set; }
        //掌子面桩号
        public string SSP_CHAI { get; set; }
        //桩号区间
        public string SSP_INTE { get; set; }
        //二次支护方案
        public string SSP_SUPP { get; set; }
        //设计围岩级别
        public string SSP_SURR { get; set; }
        //预报围岩级别
        public string SSP_RSSPU { get; set; }
        //关联文件（现场日志表)
        public string FILE_FSET { get; set; }
    }
}
