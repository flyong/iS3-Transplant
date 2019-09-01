using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace iS3.Environment.Model
{
    //地表水源
    [Table("Environment_SWSO")]
    public partial class SWSO : DGObject
    {
        //工程ID
        public string PROJ_ID { get; set; }
        //水源名称
        public string SWSO_NAME { get; set; }
        //地理位置
        public string SWSO_LOCA { get; set; }
        //所属水系
        public string SWSO_SYS { get; set; }
        //水源长度
        public Nullable<int> SWSO_LENG { get; set; }
        //汇流面积
        public Nullable<int> SWSO_CFAR { get; set; }
        //关联文件索引
        public string FILE_FSET { get; set; }
    }
}
