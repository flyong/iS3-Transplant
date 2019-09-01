using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Environment.Model
{
    //承压水埋深
    [Table("Environment_DOCG")]
    public partial class DOCG : DGObject
    {
        //工程ID
        public string PROJ_ID { get; set; }
        //X坐标
        public Nullable<decimal> LOCA_NATE { get; set; }
        //Y坐标
        public Nullable<decimal> LOCA_NATN { get; set; }
        //埋深
        public Nullable<decimal> DOCG_DEPT { get; set; }
        //备注
        public string DOCG_MEMO { get; set; }
        //关联文件索引
        public string FILE_FSET { get; set; }
    }
}
