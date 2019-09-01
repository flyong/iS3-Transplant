using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //钢筋笼
    [Table("Structure_SEST")]
    public partial class SEST : DGObject
    {

        //区间ID
        public string SECT_ID { get; set; }
        //衬砌型号
        public string LINI_TYPE { get; set; }
        //钢筋笼ID
        public Nullable<int> SEST_ID { get; set; }
        //是否存在二衬
        public  Nullable<bool> SELI_YN { get; set; }
        //二衬是否设置钢筋笼
        public  Nullable<bool> SEST_YN { get; set; }
        //保护层厚度
        public Nullable<decimal> COCV_THIC { get; set; }
        //内侧环向钢筋型号
        public string IHST_TYPE { get; set; }
        //外侧环向钢筋型号
        public string OHST_TYPE { get; set; }
        //内侧环向钢筋直径
        public Nullable<decimal> IHST_DIAM { get; set; }
        //外侧环向钢筋直径
        public Nullable<decimal> OHST_DIAM { get; set; }
        //环向钢筋间距
        public Nullable<decimal> HOST_DIST { get; set; }
        //环向钢筋拱顶圆心角
        public string TPHS_ANGL { get; set; }
        //环向钢筋拱侧圆心角
        public string SPHS_ANGL { get; set; }
        //环向钢筋拱脚圆心角
        public string FPHS_ANGL { get; set; }
        //环向钢筋仰拱圆心角
        public string IVHS_ANGL { get; set; }
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
