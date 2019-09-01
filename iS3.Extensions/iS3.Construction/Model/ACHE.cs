using iS3.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iS3.Construction.Model
{
    //施工实际进度信息
    //
    [Table("Construction_ACHE")]
    public class ACHE : DGObject
    {
        public string PROJ_ID { get; set; }
        //标段号
        public string PROG_NAME { get; set; }
        //左右幅
        public string PROG_LORR { get; set; }
        //记录时间
        public Nullable<DateTime> PROG_DATE { get; set; }
        //终点桩号
        public string PROG_END { get; set; }
        //施工面进度
        public string PROG_SGJD { get; set; }
        //超前支护进度
        public string PROG_CQJD { get; set; }
        //初衬进度
        public string PROG_CCJD { get; set; }
        //二衬进度
        public string PROG_ECJD { get; set; }
        //仰拱进度
        public string PROG_YGJD { get; set; }
        //关联文件（现场日志表）
        public string FILE_FSET { get; set; }

    }
}
