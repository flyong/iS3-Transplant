using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //管棚支护
    [Table("Structure_TUSH")]
    public partial class TUSH : DGObject
    {
        //区间ID
        public string SECT_ID { get; set; }
        //钢管型号
        public string PIPE_TYPE { get; set; }
        //钢管分段长
        public Nullable<decimal> PIPE_LENG { get; set; }
        //钢管直径
        public Nullable<decimal> PIPE_DILA { get; set; }
        //钢管间距
        public Nullable<decimal> PIPE_SPAC { get; set; }
        //注浆孔内径
        public Nullable<decimal> SLIP_RADI { get; set; }
        //注浆孔布设形式
        public string SLIP_TYPE { get; set; }
        //注浆孔间距
        public Nullable<decimal> SLIP_DIST { get; set; }
        
    }
}
