using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Construction.Model
{
    //三台阶开挖参数
    [Table("Construction_EPS")]
    public partial class EPS : DGObject
    {
        //掌子面桩号
        public string EP_CHAI { get; set; }
        //上台阶步长
        public Nullable<decimal> EP_SSS { get; set; }
        //中台阶步长
        public Nullable<decimal> EP_XSS { get; set; }
        //开挖高度
        public string EP_EH { get; set; }
        //开挖宽度
        public string EP_EW { get; set; }
        //循环进尺
        public string EP_CYCF { get; set; }
    }
}
