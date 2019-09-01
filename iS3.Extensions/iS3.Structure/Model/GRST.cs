using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //格栅钢架
    [Table("Structure_GRST")]
    public partial class GRST : DGObject
    {
        //区间ID
        public string SECT_ID { get; set; }
        //格栅钢架布设位置
        public string GRST_SITU { get; set; }
        //拱顶格栅单元型号
        public string TOP_TYPE { get; set; }
        //拱顶格栅钢架半径
        public Nullable<decimal> TOP_RADI { get; set; }
        //拱顶格栅钢架圆心角
        public Nullable<decimal> TOP_ANGL { get; set; }
        //拱侧格栅钢架半径
        public Nullable<decimal> SIDE_RADI { get; set; }
        //拱侧格栅钢架圆心角
        public Nullable<decimal> SIDE_ANGL { get; set; }
        //仰拱格栅钢架半径
        public Nullable<decimal> INVE_RADI { get; set; }
        //仰拱格栅钢架圆心角
        public Nullable<decimal> INVE_ANGL { get; set; }
    }
}
