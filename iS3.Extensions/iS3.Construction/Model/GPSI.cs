using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
namespace iS3.Construction.Model
{
    //地球物探GPR
    [Table("Construction_GPSI")]
    public partial class GPSI : DGObject
    {
        /// <summary>
		///掌子面ID 
		///</summary>
		public string GPSI_ID { get; set; }
        /// <summary>
        ///掌子面里程值 
        ///</summary>
        public string GPSI_TUFM { get; set; }
        /// <summary>
        ///时间 
        ///</summary>
        public Nullable<DateTime> GPSI_TIME { get; set; }
        /// <summary>
        ///开挖宽度 
        ///</summary>
        public Nullable<decimal> GPSI_EXAW { get; set; }
        /// <summary>
        ///开挖高度 
        ///</summary>
        public Nullable<decimal> GPSI_EXAH { get; set; }
        /// <summary>
        ///开挖面积 
        ///</summary>
        public Nullable<decimal> GPSI_EXAA { get; set; }
        /// <summary>
        ///开挖方式 
        ///</summary>
        public string GPSI_METH { get; set; }
        /// <summary>
        ///岩土特征类别 
        ///</summary>
        public string GPSI_TYPE { get; set; }
        /// <summary>
        ///岩层产状 
        ///</summary>
        public string GPSI_FORM { get; set; }

        /// <summary>
        ///围岩基本分级 
        ///</summary>
        public string GPSI_SRG { get; set; }
        /// <summary>
        ///渗水量 
        ///</summary>
        public Nullable<decimal> GPSI_WATS { get; set; }
        /// <summary>
        ///地下水状态 
        ///</summary>
        public string GPSI_GROS { get; set; }
        /// <summary>
        ///地质构造应力状态 
        ///</summary>
        public string GPSI_GTSS { get; set; }
        /// <summary>
        ///初始地应力状态 
        ///</summary>
        public string GPSI_INGS { get; set; }
        /// <summary>
        ///修正后围岩级别 
        ///</summary>
        public string GPSI_CSRG { get; set; }
        /// <summary>
        ///风化程度 
        ///</summary>
        public string GPSI_WEA { get; set; }
        /// <summary>
        ///毛洞稳定情况 
        ///</summary>
        public string GPSI_STAB { get; set; }
        /// <summary>
        ///预报结论 
        ///</summary>
        public string GPSI_FORC { get; set; }
        /// <summary>
        ///后续建议 
        ///</summary>
        public string GPSI_ADVC { get; set; }
        /// <summary>
        ///实际采取措施 
        ///</summary>
        public string GPSI_ACME { get; set; }
        /// <summary>
        ///断层 
        ///</summary>
        public string GPSI_FAUL { get; set; }
        /// <summary>
        ///初始应力 
        ///</summary>
        public string GPSI_STRE { get; set; }
        /// <summary>
        ///岩体出露状态 
        ///</summary>
        public string GPSI_LEAK { get; set; }
        /// <summary>
        ///支护情况 
        ///</summary>
        public string GPSI_SUPP { get; set; }
        /// <summary>
        ///备注 
        ///</summary>
        public string GPSI_REM { get; set; }
        /// <summary>
        ///关联文件 
        ///</summary>
        public string FILE_FSET { get; set; }


    }
}
