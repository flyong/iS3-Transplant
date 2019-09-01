using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //竖井衬砌
    [Table("Structure_SILO")]
    public partial class SILO : DGObject
    {

        //区间ID
        public string SECT_ID { get; set; }
        //竖井ID
        public string VENT_ID { get; set; }
        //竖井桩号
        public string VENT_STAS { get; set; }
        //竖井断面形式
        public string SILO_TYPE { get; set; }
       
    }
}
