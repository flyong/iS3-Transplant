using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //路面钢筋
    [Table("Structure_ROST")]
    public partial class ROST : DGObject
    {

        //区间ID
        public string SECT_ID { get; set; }
        //是否是混凝土路面
        public  Nullable<bool> CONC_YN { get; set; }
        //边缘补强钢筋型号
        public string FIST_TYPE { get; set; }
        //边缘补强钢筋间距
        public Nullable<decimal> FIST_DIST { get; set; }
        //边缘补强钢筋长度
        public Nullable<decimal> FIST_LENG { get; set; }
        //面层钢筋型号
        public string FAST_TYPE { get; set; }
        //面层钢筋长度
        public Nullable<decimal> FAST_LENG { get; set; }
        //面层钢筋间距
        public Nullable<decimal> FAST_DIST { get; set; }

    }
}
