using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;


namespace iS3.Structure.Model
{
    //二次衬砌
    [Table("Structure_SELI")]
    public partial class SELI: DGObject
    {
        //区间ID
        public string LINE_TYPE { get; set; }
        //是否设置仰拱
        public  string INVE_YN { get; set; }
        //二衬混凝土型号
        public string SELI_TYPE { get; set; }
        //拱顶二衬内半径
        public Nullable<int> TOP_RADI { get; set; }
        //拱顶二衬圆心角
        public string TOP_ANGL { get; set; }
        //拱脚二衬内半径
        public Nullable<int> ARSP_RADI { get; set; }
        //拱脚二衬圆心角
        public string ARSP_ANGL { get; set; }
        //仰拱二衬内半径
        public string INVE_RADI { get; set; }
        //仰拱二衬圆心角
        public string INVE_ANGL { get; set; }
        //拱顶二衬厚度
        public Nullable<int> TOP_THIC { get; set; }
        //侧墙二衬厚度
        public Nullable<int> SIDE_THIC { get; set; }
        //仰拱厚度
        public Nullable<int> INVE_THIC { get; set; }
        //仰拱混凝土型号
        public string INVE_TYPE { get; set; }
    }
}
