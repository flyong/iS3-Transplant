using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //横通道普通段
    [Table("Structure_TRAC")]
    public partial class TRAC : DGObject
    {

        //横通道编号
        public string TRAC_NUMB { get; set; }
        //左洞桩号
        public string LEFT_MILE { get; set; }
        //右洞桩号
        public string RIGH_MILE { get; set; }
        //混凝土型号
        public string CONC_TYPE { get; set; }
        //横通道内轮廓高度
        public Nullable<int> TRAC_HIGH { get; set; }
        //横通道内轮廓宽度
        public Nullable<int> TRAC_WIDT { get; set; }
        //横通道长度
        public Nullable<int> TRAC_LENG { get; set; }


    }
}
