using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //明洞回填
    [Table("Structure_BAFI")]
    public partial class BAFI : DGObject
    {
        //区间ID
        public string SECT_ID { get; set; }
        //衬砌类型
        public string LINE_TYPE { get; set; }
        //夯填土石坡度
        public string GABA_SLOP { get; set; }
        //拱顶距回填层距离
        public string GABA_HIGH { get; set; }
        //侧墙回填材料
        public string WALL_MATE { get; set; }
        //侧墙回填高度
        public Nullable<decimal> WALL_HIGH { get; set; }
    }
}
