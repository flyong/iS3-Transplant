using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Construction.Model
{
    //GCS注浆施工方案
    [Table("Construction_GCS")]
    public partial class GCS : DGObject
    {
        //编号
        public string GCS_NO { get; set; }
        //GCS_ID
        public string GCS_ID { get; set; }
        //掌子面桩号
        public string GCS_CHAI { get; set; }
        //桩号区间
        public string GCS_INTE { get; set; }
        //注浆施工方案
        public string GCS_SUPP { get; set; }
        //设计围岩级别
        public string GCS_SURR { get; set; }
        //预报围岩级别
        public string GCS_RGCSU { get; set; }
        //关联文件（现场日志表)
        public string FILE_FSET { get; set; }
    }
}
