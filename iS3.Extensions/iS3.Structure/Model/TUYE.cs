using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //送风口
    [Table("Structure_TUYE")]
    public partial class TUYE : DGObject
    {

        //隧道ID
        public string TUNL_ID { get; set; }
        //联络风道编号
        public string COAI_NUMB { get; set; }
        //风口截面类型
        public string TUYE_TYPE { get; set; }
       
    }
}
