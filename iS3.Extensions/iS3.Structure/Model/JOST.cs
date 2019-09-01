using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //工字钢拱架
    [Table("Structure_JOST")]
    public partial class JOST : DGObject
    {
        //区间ID
        public string SECT_ID { get; set; }
        //钢拱架布设位置
        public string JOST_SITU { get; set; }
        //工字钢型号
        public string JOST_TYPE { get; set; }
        //拱顶钢架半径
        public Nullable<decimal> TOP_RADI { get; set; }
        //拱顶圆心角
        public Nullable<decimal> TOP_ANGL { get; set; }
        //拱侧钢架半径
        public Nullable<decimal> SIDE_RADI { get; set; }
        //仰拱钢架
        public Nullable<decimal> JOST_INVE { get; set; }
        //仰拱圆心角
        public Nullable<decimal> INVE_ANGL { get; set; }
        //纵向设计间距
        public Nullable<decimal> JOST_DIST { get; set; }
    }
}
