using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;


namespace iS3.Geology.Model
{
    [Table("Geology_RSVR")]
    public partial class RSVR : DGObject
    {
        //工程ID
        public string PROJ_ID { get; set; }

        //
        public string RSVR_RWTT { get; set; }
        //
        public string RSVR_ENCH { get; set; }
        //
        public string RSVR_NAME { get; set; }
        //关联文件
        public string FILE_FSET { get; set; }
    }
}
