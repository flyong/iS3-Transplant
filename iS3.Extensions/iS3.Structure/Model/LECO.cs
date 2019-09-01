using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //超前小导管
    [Table("Structure_LECO")]
    public partial class LECO : DGObject
    {
        //区间ID
        public string SECT_ID { get; set; }
        //导管规格
        public string PIPE_TYPE { get; set; }
        //导管外径
        public Nullable<decimal> PIPE_RADI { get; set; }
        //导管长度
        public Nullable<decimal> PIPE_LENG { get; set; }
        //注浆孔间距
        public Nullable<decimal> SLIP_DIST { get; set; }
        //注浆孔尾部长
        public Nullable<decimal> SLTA_LENG { get; set; }
        //小导管环向设置间距
        public Nullable<decimal> HOOP_DIST { get; set; }
        //小导管外插角
        public string PIPE_ANGL { get; set; }
        //纵向水平搭接距离
        public Nullable<decimal> OVLA_DIST { get; set; }
        

    }
}
