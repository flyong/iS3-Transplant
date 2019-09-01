using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Environment.Model
{
    //既有工程
    [Table("Environment_EPRO")]
    public partial class EPRO : DGObject
    {
        //位置ID
        public string LOCA_ID { get; set; }
        //已有工程区ID
        public string EPRO_ID { get; set; }
        //已有工程类型
        public string EPRO_TYPE { get; set; }
        //使用情况
        public string EPRO_SERV { get; set; }
        //分布范围
        public string EPRO_DSRG { get; set; }
        //备注
        public string EPRO_REM { get; set; }
        //关联文件索引
        public string FILE_FSET { get; set; }
    }
}
