using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //监理单位
    [Table("Structure_MOIN")]
    public partial class MOIN : DGObject
    {

        //工程ID
        public Nullable<int> PROJ_ID { get; set; }
        //工程名称
        public string PROJ_NAME { get; set; }
        //监理单位
        public string MOIN_COPM { get; set; }
        //主要负责人
        public string MAIN_CHAI { get; set; }
        
    }
}
