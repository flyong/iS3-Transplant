using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace iS3.Construction.Model
{
    //超前钻探
    [Table("Construction_AD")]
    public partial class AD : DGObject
    {
        //位置ID
        public string LOCA_ID { get; set; }
        //钻孔ID
        public string HDPH_ID { get; set; }
        //掌子面桩号
        public string GCS_CHAI { get; set; }
        //钻探长度
        public Nullable<decimal> DETL_TOP { get; set; }

        //地层年代
        public string DETL_GEO1 { get; set; }


        //地层岩性
        public string DETL_GEO2 { get; set; }
        //RQD值
        public Nullable<decimal> DETL_RQD { get; set; }

        //承载力
        public Nullable<decimal> DETL_BEAR { get; set; }
        //摩阻力
        public Nullable<decimal> DETL_FRIC { get; set; }
        //标贯N
        public Nullable<decimal> DETL_BLOW { get; set; }
        //动探Nd
        public Nullable<decimal> DETL_DBLOW { get; set; }
        //细节描述
        public string DETL_DESC { get; set; }
        //备注
        public string DETL_REM { get; set; }

        //关联文件（现场日志表)
        public string FILE_FSET { get; set; }
    }
}
