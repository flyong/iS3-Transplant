using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //接头衬砌
    [Table("Structure_CORS")]
    public partial class CORS : DGObject
    {

        //隧道ID
        public string TUNL_ID { get; set; }
        //横通道ID
        public string CORS_ID { get; set; }
        //衬砌类型
        public string LINI_TYPE { get; set; }
        //接头与衬砌空间夹角
        public string CORS_DEG { get; set; }



    }
}
