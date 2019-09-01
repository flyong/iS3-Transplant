using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Construction.Model
{
    //ES开挖方案
    [Table("Construction_ES")]
    public partial class ES : DGObject
    {
        //编号
        public string ES_NO { get; set; }
        //ES_ID
        public string ES_ID { get; set; }
        //掌子面桩号
        public string ES_CHAI { get; set; }
        //桩号区间
        public string ES_INTE { get; set; }
        //开挖方法
        public string ES_EXCA { get; set; }
        //设计围岩级别
        public string ES_SURR { get; set; }
        //预报围岩级别
        public string ES_RESU { get; set; }
        //关联文件（现场日志表)
        public string FILE_FSET { get; set; }
    }
}
