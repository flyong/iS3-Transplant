using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Construction.Model
{
    // CD法开挖参数
    [Table("Construction_EPCD")]
    public partial class EPCD : DGObject
    {
        //掌子面桩号
        public string EP_CHAI { get; set; }
        //Ⅰ台阶步长
        public Nullable<decimal> EP_SSS { get; set; }
        //Ⅱ台阶步长
        public Nullable<decimal> EP_XSS { get; set; }
        //Ⅲ台阶步长
        public Nullable<decimal> EP_PSS { get; set; }
        //开挖高度
        public string EP_EH { get; set; }
        //开挖宽度
        public string EP_EW { get; set; }
        //循环进尺
        public string EP_CYCF { get; set; }
    }
}
