using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Structure.Model
{
    //公路等级
    [Table("Structure_HIGR")]
    public partial class HIGR : DGObject
    {


        //工程名称
        public string PROJ_NAME { get; set; }
        //公路等级
        public string HIGR_HIGR { get; set; }
        //车道
        public string HIGR_CHAN { get; set; }
        //设计时速
        public Nullable<decimal> HIGR_DESP { get; set; }

    }
}
