using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //仰拱回填
    [Table("Structure_INBA")]
    public partial class INBA : DGObject
    {

        //主洞ID
        public Nullable<int> TUNL_ID { get; set; }
        //衬砌ID
        public string LINL_ID { get; set; }
        //回填材料
        public string INBA_MATI { get; set; }

       
    }
}
