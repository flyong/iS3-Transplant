using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace iS3.Environment.Model
{
    // 弃渣场地
    [Table("Environment_WASS")]
    public partial class WASS : DGObject
    {
        //工程ID
        public string PROJ_ID { get; set; }
        //弃渣场地位置
        public string WASS_LOCA { get; set; }
        //弃渣场管辖桩号范围
        public string WASS_MILG { get; set; }
        //备注
        public string PLRO_REM { get; set; }
        //关联文件索引
        public string FILE_FSET { get; set; }
    }
}
