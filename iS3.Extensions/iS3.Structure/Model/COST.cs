using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //施工单位
    [Table("Structure_COST")]
    public partial class COST : DGObject
    {

        //工程ID
        public Nullable<int> PROJ_ID { get; set; }
        //工程名称
        public string PROJ_NAME { get; set; }
        //施工单位
        public string COST_COPM { get; set; }
        //主要负责人
        public string MAIN_CHAI { get; set; }
        
    }
}
