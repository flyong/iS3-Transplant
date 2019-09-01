using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_SSP")]
	public class SSP:DGObject
 	{ 
/// <summary>
///
///编号 </summary>
		public string SSP_NO {get;set;}
/// <summary>
///
///SSP_ID </summary>
		public string SSP_ID {get;set;}
/// <summary>
///
///掌子面桩号 </summary>
		public string SSP_CHAI {get;set;}
/// <summary>
///
///桩号区间 </summary>
		public string SSP_INTE {get;set;}
/// <summary>
///
///二次支护方案 </summary>
		public string SSP_SUPP {get;set;}
/// <summary>
///
///设计围岩级别 </summary>
		public string SSP_SURR {get;set;}
/// <summary>
///
///预报围岩级别 </summary>
		public string SSP_RSSPU {get;set;}
/// <summary>
///
///关联文件（现场日志表 </summary>
		public string FILE_FSET {get;set;}
	}
}