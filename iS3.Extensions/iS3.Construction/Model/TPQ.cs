using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace iS3.Construction.Model
{
    //TPQ隧道路面质量
    [Table("Construction_TPQ")]
    public partial class TPQ : DGObject
    {
        //编号
        public string TPQ_NO { get; set; }
        //TPQ_ID
        public string TPQ_ID { get; set; }
        //锚杆类型
        public string TPQ_CHAI { get; set; }
        //桩号区间
        public string TPQ_INTE { get; set; }
        //锚杆设计数量
        public string TPQ_GESC { get; set; }
        //锚杆实际数量
        public string TPQ_WATE { get; set; }
        //锚杆设计长度
        public string TPQ_SURR { get; set; }
        //锚杆实际长度
        public string TPQ_RESU { get; set; }
        //关联文件（现场日志表)
        public string FILE_FSET { get; set; }
    }
}
