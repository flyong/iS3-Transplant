using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //联络风道
    [Table("Structure_COAI")]
    public partial class COAI : DGObject
    {

        //隧道ID
        public string TUNL_ID { get; set; }
        //联络风道编号
        public string COAI_NUMB { get; set; }
        //联络风道中心桩号
        public string COAI_MILE { get; set; }
       
    }
}
