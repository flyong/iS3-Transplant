using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //横通道加强段
    [Table("Structure_TRAF")]
    public partial class TRAF : DGObject
    {

        //横通道编号
        public string TRAF_NUMB { get; set; }
        //混凝土型号
        public string CONC_TYPE { get; set; }

        //横通道内轮廓高度
        public Nullable<int> TRAF_HIGH { get; set; }
        //横通道内轮廓宽度
        public Nullable<int> TRAF_WIDT { get; set; }
        //横通道长度
        public Nullable<int> TRAF_LENG { get; set; }

    }
}
