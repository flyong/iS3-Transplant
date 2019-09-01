using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //锚杆
    [Table("Structure_BOLT")]
    public partial class BOLT : DGObject
    {

        //区间ID
        public string LINE_TYPE { get; set; }
        //锚杆类型
        public string BOLT_TYPE { get; set; }
        //锚杆布置形式
        public string BOLT_FORM { get; set; }

        public string BOLT_SITU { get; set; }
        //锚杆长度
        public Nullable<int> BOLT_LENG { get; set; }
        //孔径
        public Nullable<int> BOLT_RADI { get; set; }
        //环向间距
        public Nullable<int> HOOP_DIST { get; set; }
        //纵向间距
        public Nullable<int> LENG_DIST { get; set; }
        //仰拱处是否设置锚杆
        public  string INVE_YNBO { get; set; }

              
               
    }
}
