using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //斜井衬砌
    [Table("Structure_INLI")]
    public partial class INLI : DGObject
    {

        //衬砌类型
        public string LINE_TYPE { get; set; }
        //混凝土型号
        public string CONC_TYPE { get; set; }
        //拱顶二衬内半径
        public Nullable<int> TOP_RADI { get; set; }
        //拱顶二衬圆心角
        public Nullable<int> TOP_ANGL { get; set; }
        //拱脚二衬内半径
        public Nullable<int> ARSP_RADI { get; set; }
        //拱脚二衬圆心角
        public Nullable<int> ARSP_ANGL { get; set; }
        //仰拱二衬内半径
        public Nullable<int> INVE_RADI { get; set; }
        //仰拱二衬圆心角
        public Nullable<int> INVE_ANGL { get; set; }
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
