using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //设备洞室
    [Table("Structure_EQCA")]
    public partial class EQCA : DGObject
    {

        //隧道ID
        public string TUNL_ID { get; set; }
        //设备洞室编号
        public string EQCA_NUMB { get; set; }
        //设备洞室中心桩号
        public string EQCA_MILE { get; set; }


    }
}
