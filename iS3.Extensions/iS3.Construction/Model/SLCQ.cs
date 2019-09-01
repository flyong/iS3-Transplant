using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;
namespace iS3.Construction.Model
{
    //二衬施工质量
    [Table("Construction_SLCQ")]
    public partial class SLCQ : DGObject
    {
        //编号
        public string SLCQ_NO { get; set; }
        //SLCQ_ID
        public string SLCQ_ID { get; set; }
        //衬砌类型
        public string SLCQ_CHAI { get; set; }
        //桩号区间
        public string SLCQ_INTE { get; set; }
        //衬砌设计厚度
        public string SLCQ_GESC { get; set; }
        //衬砌实际厚度
        public string SLCQ_WATE { get; set; }
        //设计围岩级别
        public string SLCQ_SURR { get; set; }
        //预报围岩级别
        public string SLCQ_RESU { get; set; }
        //关联文件（现场日志表)
        public string FILE_FSET { get; set; }
    }
}
