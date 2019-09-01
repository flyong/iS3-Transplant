using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //封堵墙
    [Table("Structure_BLWA")]
    public partial class BLWA : DGObject
    {

        //紧急停车带ID
        public string EMTU_ID { get; set; }
        //隧道ID
        public string TUNL_ID { get; set; }
        //封堵墙宽度
        public Nullable<decimal> BLWA_WIDH { get; set; }
        //初衬厚度
        public Nullable<decimal> BLFL_THIC { get; set; }
        //二衬厚度
        public Nullable<decimal> BLSL_THIC { get; set; }


       
    }
}
