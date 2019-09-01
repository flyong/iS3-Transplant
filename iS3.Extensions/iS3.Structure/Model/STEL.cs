using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //钢筋网
    [Table("Structure_STEL")]
    public partial class STEL : DGObject
    {

        //区间ID
        public string SECT_ID { get; set; }
        //衬砌类型
        public string LINE_TYPE { get; set; }
        //是否设置钢筋网
        public  Nullable<bool> STEL_YN { get; set; }
        //钢筋网布置位置
        public string STEL_SITU { get; set; }
        //钢筋网型号
        public string STEL_TYPE { get; set; }
        //环向间距
        public Nullable<decimal> HOOP_DIST { get; set; }
        //环向钢筋型号
        public string HOOP_TYPE { get; set; }
        //纵向钢筋型号
        public string LENG_TYPE { get; set; }
                  
               
    }
}
