using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Construction.Model
{
    //图片资料
    //
    [Table("Construction_TPZL")]
    public class TPZL : DGObject
    {

        //标段号
        public string TPZL_SECTION { get; set; }
        //上传者
        public string TPZL_UPLOADER { get; set; }
        //照片时间
        public Nullable<DateTime> TPZL_DATE { get; set; }
        //桩号区间
        public string TPZL_ZHQJ { get; set; }
        //图片名称
        public string TPZL_TPMC { get; set; }
        //图片描述
        public string TPZL_DISC { get; set; }

        //关联文件（现场日志表）
        public string FILE_FSET { get; set; }

    }
}
