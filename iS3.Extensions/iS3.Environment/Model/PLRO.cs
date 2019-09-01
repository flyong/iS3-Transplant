using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Environment.Model
{
    //植被根系
    [Table("Environment_PLRO")]
    public partial class PLRO : DGObject
    {
        //工程ID
        public string PROJ_ID { get; set; }
        //植被名称
        public string PLRO_NAME { get; set; }
        //根长
        public Nullable<decimal> PLRO_LEOR { get; set; }
        //根系类型 
        public string PLRO_TYPE { get; set; }
        //根系作用
        public string PLRO_USE { get; set; }
        //X坐标
        public Nullable<decimal> LOCA_NATE { get; set; }
        //Y坐标
        public Nullable<decimal> LOCA_NATN { get; set; }
        //备注
        public string PLRO_REM { get; set; }
        //关联文件索引
        public string FILE_FSET { get; set; }
    }
}
