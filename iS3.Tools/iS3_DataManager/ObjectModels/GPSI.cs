using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_GPSI")]
	public class GPSI:DGObject
 	{ 
/// <summary>
///
///分段信息ID </summary>
		public string GPSI_ID {get;set;}
/// <summary>
///
///里程冠号 </summary>
		public string GPSI_MILE {get;set;}
/// <summary>
///
///开始里程值 </summary>
		public Nullable<double> GPSI_SMIL {get;set;}
/// <summary>
///
///结束里程值 </summary>
		public Nullable<double> GPSI_EMIL {get;set;}
/// <summary>
///
///生成时间 </summary>
		public string GPSI_TIME {get;set;}
/// <summary>
///
///风险类别 </summary>
		public string GPSI_RISC {get;set;}
/// <summary>
///
///地质级别 </summary>
		public string GPSI_GEOL {get;set;}
/// <summary>
///
///围岩等级 </summary>
		public string GPSI_SRG {get;set;}
/// <summary>
///
///探测结论 </summary>
		public string GPSI_FORC {get;set;}
/// <summary>
///
///备注 </summary>
		public string GPSI_REM {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
	}
}