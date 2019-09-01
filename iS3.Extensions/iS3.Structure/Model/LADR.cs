using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //横向排水管
    [Table("Structure_LADR")]
    public partial class LADR : DGObject
    {

        //主洞ID
        public Nullable<int> TUNL_ID { get; set; }
        //衬砌类型
        public string LINI_TYPE { get; set; }
        //横向排水管规格
        public string HPIP_TYPE { get; set; }
        //横向排水管间距
        public Nullable<decimal> HPIP_DIST { get; set; }
        //横向排水管长度
        public Nullable<decimal> HPIP_LENG { get; set; }
        //三通管数量
        public string BRAN_NUMB { get; set; }
        //是否有检修口
        public  Nullable<bool> INSE_YN { get; set; }
        //检修口规格
        public string INSE_TYPE { get; set; }
        //是否有渗水引水管
        public  Nullable<bool> AQUE_YN { get; set; }
        //渗水引水管型号
        public string AQUE_TYPE { get; set; }


    }
}
