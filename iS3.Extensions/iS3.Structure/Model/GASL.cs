using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //洞门衬砌
    //
    [Table("Structure_GASL")]
    public partial class GASL : DGObject
    {
        //区间ID
        public string SECT_ID { get; set; }
        //是否存在仰拱
        public  Nullable<bool> INVE_YN { get; set; }
        //衬砌型号
        public string LINE_TYPE { get; set; }
        //混凝土型号
        public string CONC_TYPE { get; set; }
        //拱顶衬砌内半径
        public Nullable<decimal> TOP_RADI { get; set; }
        //拱顶衬砌圆心角
        public string TOP_ANGL { get; set; }
        //拱脚衬砌内半径
        public Nullable<decimal> ARSP_RADI { get; set; }
        //拱脚衬砌圆心角
        public string ARSP_ANGL { get; set; }
        //仰拱衬砌内半径
        public Nullable<decimal> INVE_RADI { get; set; }
        //仰拱衬砌圆心角
        public string INVE_ANGL { get; set; }
        //拱顶衬砌厚度
        public Nullable<decimal> TOP_THIC { get; set; }
        //拱脚宽度
        public Nullable<decimal> ARCF_WIDE { get; set; }
        //侧墙高度
        public Nullable<decimal> SIDE_HEIG { get; set; }
        //仰拱厚度
        public Nullable<decimal> INVE_THIC { get; set; }
        //仰拱混凝土型号
        public string INVE_TYPE { get; set; }

    }
}
