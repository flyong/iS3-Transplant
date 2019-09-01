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
    [Table("Construction_SPZL")]
    public class SPZL : DGObject
    {
        //标段号
        public string SPZL_SECTION { get; set; }
        //上传者
        public string SPZL_UPLOADER { get; set; }
        //视频时间
        public Nullable<DateTime> SPZL_DATE { get; set; }
        //桩号区间
        public string SPZL_ZHQJ { get; set; }
        //视频名称
        public string SPZL_SPMC { get; set; }
        //视频描述
        public string SPZL_DISC { get; set; }
        //关联文件（现场日志表）
        public string FILE_FSET { get; set; }

    }
}
