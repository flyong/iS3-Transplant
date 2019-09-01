using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace iS3.Environment.Model
{
    // 开挖洞渣
    [Table("Environment_TUEG")]
    public partial class TUEG : DGObject
    {
        //工程ID
        public string PROJ_ID { get; set; }
        //洞渣主要成分
        public string TUEG_COMP { get; set; }

        //洞渣PH值
        public Nullable<decimal> TUEG_PH { get; set; }
        //洞渣利用率
        public Nullable<decimal> TUEG_RATE { get; set; }
        //备注
        public string PLRO_REM { get; set; }
        //关联文件索引
        public string FILE_FSET { get; set; }
    }
}
