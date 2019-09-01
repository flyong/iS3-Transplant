using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //电缆沟
    [Table("Structure_CATR")]
    public partial class CATR : DGObject
    {

        //主洞ID
        public Nullable<int> TUNL_ID { get; set; }
        //衬砌类型
        public string LINE_TYPE { get; set; }
        //电缆沟材料
        public string CABL_MATE { get; set; }
        //电缆沟盖板厚度
        public Nullable<decimal> CABL_THIC { get; set; }
        //电缆沟盖板长度
        public Nullable<decimal> CABL_LENG { get; set; }



    }
}
