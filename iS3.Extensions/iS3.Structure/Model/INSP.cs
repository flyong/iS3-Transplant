using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //斜井接头
    [Table("Structure_INSP")]
    public partial class INSP : DGObject
    {
        //斜井ID
        public string INLI_ID { get; set; }
        //衬砌类型
        public string LINI_TYPE { get; set; }
        //接头隧道中心桩号
        public string LINI_MILG { get; set; }
        //接头与衬砌空间夹角
        public Nullable<int> LINI_DEG { get; set; }



    }
}
