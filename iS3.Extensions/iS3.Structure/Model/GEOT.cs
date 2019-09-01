using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //土工布
    [Table("Structure_GEOT")]
    public partial class GEOT : DGObject
    {

        //主洞ID
        public Nullable<int> TUNL_ID { get; set; }
        //衬砌类型
        public string LINI_TYPE { get; set; }
        //土工布规格
        public string GETE_STAN { get; set; }
        //土工布厚度
        public Nullable<decimal> GETE_THIC { get; set; }
        //土工布布设方式
        public Nullable<int> GETE_METH { get; set; }


    }
}
