using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iS3.Core.Model;
namespace iS3.Construction.Model
{
    //地球物探TSP
    [Table("Construction_TFSI")]
    public partial class TFSI : DGObject
    {
        /// <summary>
        ///分段信息ID 
        ///</summary>
        public string TFSI_ID { get; set; }
        /// <summary>
        ///里程冠号 
        ///</summary>
        public string TFSI_MILE { get; set; }
        /// <summary>
        ///生成时间 
        ///</summary>
        public Nullable<DateTime> TFSI_TIME { get; set; }
        /// <summary>
        ///风险类别 
        ///</summary>
        public string TFSI_RISC { get; set; }
        /// <summary>
        ///地质级别 
        ///</summary>
        public string TFSI_GEOL { get; set; }
        /// <summary>
        ///围岩等级 
        ///</summary>
        public string TFSI_SRG { get; set; }
        /// <summary>
        ///探测结论 
        ///</summary>
        public string TFSI_FORC { get; set; }
        /// <summary>
        ///备注 
        ///</summary>
        public string TFSI_REM { get; set; }
        /// <summary>
        ///关联文件 
        ///</summary>
        public string FILE_FSET { get; set; }
    }
}
