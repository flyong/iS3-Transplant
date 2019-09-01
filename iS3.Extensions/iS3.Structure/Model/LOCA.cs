using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;


namespace iS3.Structure.Model
{
    //位置信息
    [Table("Structure_LOCA")]
    public partial class LOCA : DGObject
    {
        //工程ID
        public Nullable<int> PROJ_ID { get; set; }

        public string PROJ_NAME { get; set; }

        public string PROJ_STAR { get; set; }

        public string PROJ_END { get; set; }
    }
}
