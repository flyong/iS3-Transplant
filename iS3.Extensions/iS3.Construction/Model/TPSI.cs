using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Construction.Model
{
    //第三方抽检
    //
    [Table("Construction_TPSI")]
    public class TPSI : DGObject
    {
        
        //标段号
        public string TPSI_SECTION { get; set; }
        //检测单位
        public string TPSI_CHECKER { get; set; }
        //检测时间
        public Nullable<DateTime> TPSI_DATE { get; set; }
        //桩号区间
        public string TPSI_ZHQJ { get; set; }
        //检测问题
        public string TPSI_JCWT { get; set; }
        //整改责任人
        public string TPSI_ZGZRR { get; set; }
        //整改结果
        public string TPSI_ZGJG { get; set; }
        //整改进度
        public string TPSI_ZGJD { get; set; }
       
        //关联文件（现场日志表）
        public string FILE_FSET { get; set; }

    }
}
