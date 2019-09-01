using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace iS3.Environment.Model
{
    //植被种类
    [Table("Environment_PLTY")]
    public partial class PLTY : DGObject
    {
        //工程ID
        public string PROJ_ID { get; set; }
        //植被名称
        public string PLTY_NAME { get; set; }
        //所属科
        public string PLTY_DEPA { get; set; }
        //高度
        public Nullable<decimal> PLTY_HEIG { get; set; }
        //日均蒸腾量
        public Nullable<decimal> PLTY_DATR { get; set; }
        //X坐标
        public Nullable<decimal> LOCA_NATE { get; set; }
        //Y坐标
        public Nullable<decimal> LOCA_NATN { get; set; }
        //备注
        public string PLTY_REM { get; set; }
        //关联文件索引
        public string FILE_FSET { get; set; }
    }
}
