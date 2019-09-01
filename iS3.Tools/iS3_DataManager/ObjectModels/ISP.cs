using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_ISP")]
	public class ISP:DGObject
 	{ 
/// <summary>
///
///编号 </summary>
		public string ISP_NO {get;set;}
/// <summary>
///
///ISP_ID </summary>
		public string ISP_ID {get;set;}
/// <summary>
///
///掌子面桩号 </summary>
		public string ISP_CHAI {get;set;}
/// <summary>
///
///桩号区间 </summary>
		public string ISP_INTE {get;set;}
/// <summary>
///
///初期支护方案 </summary>
		public string ISP_SUPP {get;set;}
/// <summary>
///
///设计围岩级别 </summary>
		public string ISP_SURR {get;set;}
/// <summary>
///
///预报围岩级别 </summary>
		public string ISP_RESU {get;set;}
/// <summary>
///
///关联文件（现场日志表 </summary>
		public string FILE_FSET {get;set;}
	}
}