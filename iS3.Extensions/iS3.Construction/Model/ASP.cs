using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Construction.Model
{
    //ASP超前支护方案
    [Table("Construction_ASP")]
    public partial class ASP : DGObject
    {
        //编号
        public string ASP_NO { get; set; }
        //ASP_ID
        public string ASP_ID { get; set; }
        //桩号区间
        public string ASP_INTE { get; set; }
        //超前支护方案
        public string ASP_SUPP { get; set; }
        //预报围岩级别
        public string ASP_SRL { get; set; }
        //关联文件（现场日志表)
        public string FILE_FSET { get; set; }
    }
}
