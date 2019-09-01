using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //锁口圈
    [Table("Structure_SIWE")]
    public partial class SIWE : DGObject
    {

        //区间ID
        public string SECT_ID { get; set; }
        //竖井ID
        public string VENT_ID { get; set; }
        //锁口内径
        public Nullable<decimal> SIWE_DRAI { get; set; }
        //锁口圈高度
        public Nullable<decimal> SIWE_HIGH { get; set; }
        //放脚宽度
        public Nullable<decimal> SIWE_WIDE { get; set; }
        //放脚比率
        public string SIWE_SLOP { get; set; }


        

    }
}
