using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Construction.Model
{
    //ISP初期支护方案
    [Table("Construction_ISP")]
    public partial class ISP : DGObject
    {
        //编号
        public string ISP_NO { get; set; }
        //ISP_ID
        public string ISP_ID { get; set; }
        //掌子面桩号
        public string ISP_CHAI { get; set; }
        //桩号区间
        public string ISP_INTE { get; set; }
        //初期支护方案
        public string ISP_SUPP { get; set; }
        //设计围岩级别
        public string ISP_SURR { get; set; }
        //预报围岩级别
        public string ISP_RESU { get; set; }
        //关联文件（现场日志表)
        public string FILE_FSET { get; set; }
    }
}
