using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //洞门端墙
    //
    [Table("Structure_PORT")]
    public partial class PORT : DGObject
    {
        //隧道ID
        public string TUNL_ID { get; set; }
        //洞口形式
        public string PORT_TYPE { get; set; }
        
        public string DRAI_LOCA { get; set; }

    }
}
