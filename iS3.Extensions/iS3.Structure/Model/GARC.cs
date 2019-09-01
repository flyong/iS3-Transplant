using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //衬砌钢筋笼
    [Table("Structure_GARC")]
    public partial class GARC : DGObject
    {

        //区间ID
        public string SECT_ID { get; set; }
        //衬砌型号
        public string LINE_TYPE { get; set; }
        //保护层厚度
        public Nullable<decimal> COCV_THIC { get; set; }
        //环向钢筋型号
        public string HOST_TYPE { get; set; }
        //环向钢筋直径
        public Nullable<decimal> HOST_DIAM { get; set; }
        //环向钢筋间距
        public Nullable<decimal> HOST_DIST { get; set; }
        //环向内侧钢筋拱圈圆心角
        public string ITHS_ANGL { get; set; }
        //环向外侧钢筋拱圈圆心角
        public string OTHS_ANGL { get; set; }
        //环向外侧钢筋仰拱圆心角
        public string OIHS_ANGL { get; set; }
        //环向外侧钢筋拱墙处长度
        public Nullable<decimal> OSHS_LENG { get; set; }
        //环向钢筋拱脚处长度
        public Nullable<decimal> SPHS_LENG { get; set; }
        //纵向钢筋型号
        public string VEST_TYPE { get; set; }
        //纵向钢筋直径
        public Nullable<decimal> VEST_DIAM { get; set; }
        //纵向钢筋间距
        public Nullable<decimal> VEST_DIST { get; set; }
        //拉结筋型号
        public string SLIP_TYPE { get; set; }
        //拉结筋直径
        public Nullable<decimal> SLIP_DIAM { get; set; }
        //拉结筋间距
        public Nullable<decimal> SLIP_DIST { get; set; }
    }
}
