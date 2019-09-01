using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //沿桩衬砌类型
    [Table("Structure_MILI")]
    public partial class MILI : DGObject
    {

        /// <summary>
        ///工程ID 
        ///</summary>
        public string PROJ_ID { get; set; }
        /// <summary>
        ///起始里程桩号 
        ///</summary>
        public string MILI_STAR { get; set; }
        /// <summary>
        ///终止里程桩号 
        ///</summary>
        public string MILI_END { get; set; }
        /// <summary>
        ///衬砌类型 
        ///</summary>
        public string MILI_LNTY { get; set; }

        //关联文件（现场日志表)
        public string FILE_FSET { get; set; }

    }
}
