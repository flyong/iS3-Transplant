using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //清水沟
    [Table("Structure_CWDI")]
    public partial class CWDI : DGObject
    {

        //主洞ID
        public Nullable<int> TUNL_ID { get; set; }
        //衬砌类型
        public string LINE_TYPE { get; set; }
        //清水沟混凝土型号
        public string QCON_TYPE { get; set; }
        //清水沟盖板厚度
        public Nullable<decimal> QCOV_COVER_THIC { get; set; }
        //清水沟内宽
        public Nullable<decimal> QCOV_WIDE { get; set; }
        //清水沟内高
        public Nullable<decimal> QCOV_HIGH { get; set; }
        //清水沟厚度
        public Nullable<decimal> QCOV_THIC { get; set; }

    }
}
