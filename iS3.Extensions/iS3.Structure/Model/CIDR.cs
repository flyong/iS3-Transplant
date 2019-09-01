using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //环向排水管
    [Table("Structure_CIDR")]
    public partial class CIDR : DGObject
    {

        //主洞ID
        public Nullable<int> TUNL_ID { get; set; }
        //衬砌类型
        public string LINI_TYPE { get; set; }
        //环向排水管规格
        public string CPIP_TYPE { get; set; }
        //环向排水管间距
        public Nullable<decimal> CPIP_DIST { get; set; }


    }
}
