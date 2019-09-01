using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //明洞工程
    //
    [Table("Structure_GALL")]
    public partial class GALL : DGObject
    {
        //明洞ID
        public string TUNL_ID { get; set; }
        //是否有明洞
        public  string GALL_LOCA { get; set; }
        //明洞形式
        public string GALL_TYPE { get; set; }
        //明暗洞交界处桩号
        public string GALL_CONN { get; set; }
        //明洞衬砌类型
        public string GALL_LINI { get; set; }
        //明洞防排水类型
        public string GALL_DRAI { get; set; }
        //是否有套拱
        public  string UMBR_YN { get; set; }
    }
}
