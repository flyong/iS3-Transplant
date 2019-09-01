using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace iS3.Environment.Model
{
    //重要建筑物
    [Table("Environment_IMAR")]
    public partial class IMAR : DGObject
    {
        //工程ID
        public string PROJ_ID { get; set; }
        //建筑物名称
        public string IMAR_NAME { get; set; }
        //建筑物用途
        public string IMAR_USE { get; set; }
        //距离最近的河流
        public string IMAR_NRRV { get; set; }
        //X坐标
        public Nullable<decimal> LOCA_NATE { get; set; }
        //Y坐标
        public Nullable<decimal> LOCA_NATN { get; set; }
        //地下水位
        public Nullable<decimal> LOCA_WATA { get; set; }
        //地下水埋深
        public Nullable<decimal> LOCA_DEOG { get; set; }
        //备注
        public string IMAR_REM { get; set; }
        //关联文件索引
        public string FILE_FSET { get; set; }
    }
}
