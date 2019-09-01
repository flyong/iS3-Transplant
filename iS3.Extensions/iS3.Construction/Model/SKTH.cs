using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
namespace iS3.Construction.Model
{
    //掌子面地质素描
    [Table("Construction_SKTH")]
    public partial class SKTH : DGObject
    {
        //编号
        public string SKTH_NO { get; set; }
        public string SKTH_ID { get; set; }
        //掌子面桩号
        public string SKTH_CHAI { get; set; }
        //桩号区间
        public string SKTH_INTE { get; set; }
        //地下水状态
        public string SKTH_WATE { get; set; }

        public string SKTH_WATG { get; set; }
        //岩性
        public string SKTH_LITH { get; set; }
        //岩层产状
        public string SKTH_FORM { get; set; }
        //风化程度
        public string SKTH_WEA { get; set; }

        public Nullable<decimal> SKTH_JOIQ { get; set; }
        //节理
        public string SKTH_JOIN { get; set; }

        public string SKTH_INTE1 { get; set; }
        //完整性
        public string SKTH_INTG { get; set; }
        //围岩级别
        public string SKTH_SURR { get; set; }
        //结构面形状及产状
        public string SKTH_STRU { get; set; }
        //断层
        public string SKTH_FAUL { get; set; }
        //初始应力
        public string SKTH_STRE { get; set; }
        //围岩稳定情况
        public string SKTH_STAB { get; set; }
        //岩体出漏情况
        public string SKTH_LEAK { get; set; }
         

        //关联文件（现场日志表）
        public string FILE_FSET { get; set; }


    }
}
