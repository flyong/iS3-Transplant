using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_TPSI")]
	public class TPSI:DGObject
 	{ 
/// <summary>
///
///标段号 </summary>
		public string TPSI_SECTION {get;set;}
/// <summary>
///
///检测单位 </summary>
		public string TPSI_CHECKER {get;set;}
/// <summary>
///
///检测时间 </summary>
		public string TPSI_DATE {get;set;}
/// <summary>
///
///桩号区间 </summary>
		public string TPSI_ZHQJ {get;set;}
/// <summary>
///
///检测问题 </summary>
		public string TPSI_JCWT {get;set;}
/// <summary>
///
///整改责任人 </summary>
		public string TPSI_ZGZRR {get;set;}
/// <summary>
///
///整改结果 </summary>
		public string TPSI_ZGJG {get;set;}
/// <summary>
///
///整改进度 </summary>
		public string TPSI_ZGJD {get;set;}
/// <summary>
///
///关联文件（现场日志表） </summary>
		public string FILE_FSET {get;set;}
	}
}