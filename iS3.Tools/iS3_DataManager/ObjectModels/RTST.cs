using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_RTST")]
	public class RTST:DGObject
 	{ 
/// <summary>
///
///工程名称 </summary>
		public string PROJ_ID {get;set;}
/// <summary>
///
///试验位置 </summary>
		public string RTST_LOCA {get;set;}
/// <summary>
///
///样本ID </summary>
		public string SPEC_ID {get;set;}
/// <summary>
///
///试验单位 </summary>
		public string ORGA_ID {get;set;}
/// <summary>
///
///试验日期 </summary>
		public string RTST_DATE {get;set;}
/// <summary>
///
///试验人员 </summary>
		public string PEOP_ID {get;set;}
/// <summary>
///
///试验设备 </summary>
		public string RTST_EQUP {get;set;}
/// <summary>
///
///参照标准 </summary>
		public string RTST_CRED {get;set;}
/// <summary>
///
///关联文件 </summary>
		public string FILE_FSET {get;set;}
/// <summary>
///
///试验集编号 </summary>
		public string RTST_TESN {get;set;}
/// <summary>
///
///试验方法 </summary>
		public string RTST_METH {get;set;}
/// <summary>
///
///测试状态 </summary>
		public string RTST_STAT {get;set;}
/// <summary>
///
///地层编号 </summary>
		public string STRA_ID {get;set;}
/// <summary>
///
///试样含水率 </summary>
		public Nullable<double> RTST_MC {get;set;}
/// <summary>
///
///试样直径 </summary>
		public Nullable<double> RTST_SDIA {get;set;}
/// <summary>
///
///试样高度 </summary>
		public Nullable<double> RTST_HEIG {get;set;}
/// <summary>
///
///试样试验时概述 </summary>
		public string RTST_COND {get;set;}
/// <summary>
///
///试验持续时间 </summary>
		public string RTST_DURN {get;set;}
/// <summary>
///
///压力变化率 </summary>
		public Nullable<int> RTST_STRA {get;set;}
/// <summary>
///
///抗拉强度 </summary>
		public string RTST_TENS {get;set;}
/// <summary>
///
///备注 </summary>
		public string RTST_REM {get;set;}
	}
}