using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Construction.Model
{
    //初衬施工质量
    [Table("Construction_ILCQ")]
    public partial class ILCQ : DGObject
    {
        //编号
        public string ILCQ_NO { get; set; }
        //ILCQ_ID
        public string ILCQ_ID { get; set; }
        //衬砌类型
        public string ILCQ_CHAI { get; set; }
        //桩号区间
        public string ILCQ_INTE { get; set; }
        //衬砌设计厚度
        public string ILCQ_GESC { get; set; }
        //衬砌实际厚度
        public string ILCQ_WATE { get; set; }
        //设计围岩级别
        public string ILCQ_SURR { get; set; }
        //预报围岩级别
        public string ILCQ_RESU { get; set; }
        //关联文件（现场日志表)
        public string FILE_FSET { get; set; }
    }
}
