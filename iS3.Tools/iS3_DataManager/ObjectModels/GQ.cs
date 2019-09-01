using System; 
using System.ComponentModel.DataAnnotations.Schema;
using iS3.Core.Model;

namespace iS3.Geology.Model
 { 
 	[Table("Geology_GQ")]
	public class GQ:DGObject
 	{ 
/// <summary>
///
///编号 </summary>
		public string GQ_NO {get;set;}
/// <summary>
///
///GQ_ID </summary>
		public string GQ_ID {get;set;}
/// <summary>
///
///衬砌类型 </summary>
		public string GQ_CHAI {get;set;}
/// <summary>
///
///桩号区间 </summary>
		public string GQ_INTE {get;set;}
/// <summary>
///
///设计注浆半径 </summary>
		public string GQ_GESC {get;set;}
/// <summary>
///
///实际注浆半径 </summary>
		public string GQ_WATE {get;set;}
/// <summary>
///
///设计围岩级别 </summary>
		public string GQ_SURR {get;set;}
/// <summary>
///
///预报围岩级别 </summary>
		public string GQ_RESU {get;set;}
/// <summary>
///
///关联文件（现场日志表 </summary>
		public string FILE_FSET {get;set;}
	}
}