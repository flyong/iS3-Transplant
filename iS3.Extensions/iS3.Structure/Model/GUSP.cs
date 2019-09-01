using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //导向钢管
    [Table("Structure_GUSP")]
    public partial class GUSP : DGObject
    {

        //区间ID
        public string SECT_ID { get; set; }
        //衬砌型号
        public string LINE_TYPE { get; set; }
        //导向钢管中心距套拱内轮廓距离
        public Nullable<decimal> GUSP_SPAC { get; set; }
        //断面内导向钢管数量
        public Nullable<int> GUSP_NUM { get; set; }
        //导向钢管间距
        public Nullable<decimal> GUSP_DIST { get; set; }
        //导向钢管外径
        public Nullable<decimal> GUSP_DIAM { get; set; }
        //导向钢管壁厚
        public Nullable<decimal> GUSP_THIC { get; set; }
        //导向钢管单节长
        public Nullable<decimal> GUSP_LENG { get; set; }

        
        
    }
}
