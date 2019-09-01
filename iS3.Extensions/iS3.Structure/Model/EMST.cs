using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //紧急停车带
    [Table("Structure_EMST")]
    public partial class EMST : DGObject
    {

        //隧道ID
        public string TUNL_ID { get; set; }
        //紧急停车带编号
        public string EMST_NUMB { get; set; }
        //紧急停车带中心桩号
        public string EMST_MILE { get; set; }
    }
}
