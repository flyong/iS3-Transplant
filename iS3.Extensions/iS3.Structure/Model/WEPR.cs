using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //防水板
    [Table("Structure_WEPR")]
    public partial class WEPR : DGObject
    {

        //主洞ID
        public Nullable<int> TUNL_ID { get; set; }
        //衬砌类型
        public string LINI_TYPE { get; set; }
        //防水板规格
        public string PROO_STAN { get; set; }
        //防水板厚度
        public Nullable<decimal> PROO_THIC { get; set; }
        //防水板设置方式
        public Nullable<int> PROO_METH { get; set; }


    }
}
