using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Construction.Model
{
    //  预留核心土法开挖参数
    [Table("Construction_EPY")]
    public partial class EPY : DGObject
    {
        //掌子面桩号
        public string EP_CHAI { get; set; }
        //预留核心土宽度
        public Nullable<decimal> EP_RCSW { get; set; }
        //台阶步长
        public Nullable<decimal> EP_XSS { get; set; }
        //开挖高度
        public string EP_EH { get; set; }
        //开挖宽度
        public string EP_EW { get; set; }
        //循环进尺
        public string EP_CYCF { get; set; }
    }
}
