using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Construction.Model
{
    //GQ注浆施工质量
    [Table("Construction_GQ")]
    public partial class GQ : DGObject
    {
        //编号
        public string GQ_NO { get; set; }
        //GQ_ID
        public string GQ_ID { get; set; }
        //衬砌类型
        public string GQ_CHAI { get; set; }
        //桩号区间
        public string GQ_INTE { get; set; }
        //设计注浆半径
        public string GQ_GESC { get; set; }
        //实际注浆半径
        public string GQ_WATE { get; set; }
        //设计围岩级别
        public string GQ_SURR { get; set; }
        //预报围岩级别
        public string GQ_RESU { get; set; }
        //关联文件（现场日志表)
        public string FILE_FSET { get; set; }
    }
}
