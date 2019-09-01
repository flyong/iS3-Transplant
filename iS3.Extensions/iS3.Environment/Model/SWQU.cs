using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace iS3.Environment.Model
{
    //地表水质
    [Table("Environment_SWQU")]
    public partial class SWQU : DGObject
    {
        //工程ID
        public string PROJ_ID { get; set; }
        //测量时间
        public string SWQU_METI { get; set; }
        //X坐标
        public Nullable<decimal> LOCA_NATE { get; set; }
        //Y坐标
        public Nullable<decimal> LOCA_NATN { get; set; }
        //污染物名称
        public string SWQU_POLL { get; set; }
        //污染物含量
        public Nullable<decimal> SWQU_CONT { get; set; }
        //关联文件索引
        public string FILE_FSET { get; set; }
    }
}
