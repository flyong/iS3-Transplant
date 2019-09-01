using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //建筑限界
    [Table("Structure_BULI")]
    public partial class BULI : DGObject
    {
        //工程ID
        public Nullable<int> PROJ_ID { get; set; }
        //隧道ID
        public string TUNL_ID { get; set; }

        //行车道宽度
        public Nullable<decimal> BULI_WIDT { get; set; }

        //限高
        public Nullable<decimal> BULI_HIGH { get; set; }
        //检修道宽度
        public Nullable<decimal> OVHA_WIDT { get; set; }


    }
}
