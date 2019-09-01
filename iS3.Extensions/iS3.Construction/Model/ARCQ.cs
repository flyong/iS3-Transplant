using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Construction.Model
{
    //ARCQ锚杆施工质量
    [Table("Construction_ARCQ")]
    public partial class ARCQ : DGObject
    {
        //编号
        public string ARCQ_NO { get; set; }
        //ARCQ_ID
        public string ARCQ_ID { get; set; }
        //锚杆类型
        public string ARCQ_CHAI { get; set; }
        //桩号区间
        public string ARCQ_INTE { get; set; }
        //锚杆设计数量
        public string ARCQ_GESC { get; set; }
        //锚杆实际数量
        public string ARCQ_WATE { get; set; }
        //锚杆设计长度
        public string ARCQ_SURR { get; set; }
        //锚杆实际长度
        public string ARCQ_RESU { get; set; }
        //关联文件（现场日志表)
        public string FILE_FSET { get; set; }
    }
}
