using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
{
    //航空航片信息
    [Table("Geology_SCYS")]
    public partial class SCYS : DGObject
    {
        //量测时间
        public Nullable<DateTime> SCYS_DATE { get; set; }
        //标段号
        public string SCYS_BDH { get; set; }
        //边沟位置
        public string SCYS_BGWZ { get; set; }
        //桩号区间
        public string SCYS_ZHQJ { get; set; }
        //桩号位置描述
        public string SCYS_WZMS { get; set; }
        //流速1(m/s)
        public string SCYS_LS1 { get; set; }
        //流速2(m/s)
        public string SCYS_LS2 { get; set; }
        //流速3(m/s)
        public string SCYS_LS3 { get; set; }
        //平均流速(m/s)
        public string SCYS_PJLS { get; set; }
        //断面深1(cm)
        public string SCYS_DMS1 { get; set; }
        //断面深2(cm)
        public string SCYS_DMS2 { get; set; }
        //断面深3(cm)
        public string SCYS_DMS3 { get; set; }
        //平均深度(cm)
        public string SCYS_PJSD { get; set; }
        //断面宽(cm)
        public string SCYS_DMK { get; set; }
        //流量(m3/s)
        public string SCYS_LLM { get; set; }
        //流量(m3/d)
        public string SCYS_LLT { get; set; }
        //左右沟总量(m3/d)
        public string SCYS_ZYGZL { get; set; }
        //掌子面位置
        public string SCYS_ZZM { get; set; }

        //关联文件
        public string FILE_FSET { get; set; }
    }
}
