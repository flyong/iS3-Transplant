using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //套拱工字钢架
    [Table("Structure_TUAR")]
    public partial class TUAR : DGObject
    {

        //区间ID
        public string SECT_ID { get; set; }
        //衬砌型号
        public string LINE_TYPE { get; set; }
        //是否存在钢架
        public  Nullable<bool> TUAR_YN { get; set; }
        //工字钢架间距
        public Nullable<decimal> TUAR_DIST { get; set; }
        //工字钢架型号
        public string TUAR_TYPE { get; set; }
        //工字钢架单元数
        public Nullable<int> TUAR_ELEM { get; set; }
        //拱部工字钢架半径
        public Nullable<decimal> TOP_RADI { get; set; }
        //拱部钢架单元圆心角
        public string TUAR_ANGL { get; set; }
        //拱墙工字钢架长度
        public Nullable<decimal> WALL_LENG { get; set; }


        
    }
}
