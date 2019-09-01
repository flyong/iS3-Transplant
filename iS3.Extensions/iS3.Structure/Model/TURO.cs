using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //路面层
    [Table("Structure_TURO")]
    public partial class TURO : DGObject
    {

        //区间ID
        public string SECT_ID { get; set; }
        //主洞ID
        public string GALL_ID { get; set; }
        //路面层ID
        public string ROLA_ID { get; set; }
        //路面层材料
        public string ROLA_MATI { get; set; }
        //路面层宽度
        public Nullable<decimal> ROLA_WIDE { get; set; }
        //路面层厚度
        public Nullable<decimal> ROLA_THIC { get; set; }
        //路面层坡度
        public Nullable<decimal> ROLA_GRAD { get; set; }


       
    }
}
