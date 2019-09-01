using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //临空断面
    [Table("Structure_INSE")]
    public partial class INSE : DGObject
    {
        //工程ID
        public Nullable<int> PROJ_ID { get; set; }
        //隧道ID
        public string TUNL_ID { get; set; }
        //断面类型
        public string INSE_TYPE { get; set; }

        //最大宽度
        public Nullable<decimal> INSE_HIGH { get; set; }
        //最大高度
        public Nullable<decimal> OVHA_WIDT { get; set; }


    }
}
