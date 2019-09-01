using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //里程桩号
    [Table("Structure_MILE")]
    public partial class MILE : DGObject
    {

        //隧道ID
        public string TUNL_ID { get; set; }
        //里程桩号编号
        public string MILE_NUMB { get; set; }
        //X坐标
        public Nullable<decimal> MILE_X { get; set; }
        //Y坐标
        public Nullable<decimal> MILE_Y { get; set; }
        //Z坐标
        public Nullable<decimal> MILE_Z { get; set; }



    }
}
